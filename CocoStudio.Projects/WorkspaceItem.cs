// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.WorkspaceItem
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Projects.Formates;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CocoStudio.Projects
{
  public abstract class WorkspaceItem : IWorkspaceFileObject, IFileItem, IWorkspaceObject, IExtendedDataItem, IFoldeItem, IDisposable, ILoadController
  {
    internal string cfgFileSuffix = ".cfg";
    private FilePath baseDirectory;
    private Hashtable extendedProperties;
    private PropertyBag userProperties;
    private HashSet<Type> solutionPropertyList;
    private FileFormat format;

    public PropertyBag UserProperties
    {
      get
      {
        if (this.userProperties == null)
        {
          this.LoadUserProperties();
          if (this.userProperties == null)
            this.userProperties = new PropertyBag();
        }
        return this.userProperties;
      }
      set
      {
        this.userProperties = value;
      }
    }

    public HashSet<Type> SolutionPropertyList
    {
      get
      {
        if (this.solutionPropertyList == null)
        {
          this.CollectDataModelType();
          if (this.solutionPropertyList == null)
            this.solutionPropertyList = new HashSet<Type>();
        }
        return this.solutionPropertyList;
      }
    }

    public Workspace ParentWorkspace { get; internal set; }

    public IDictionary ExtendedProperties
    {
      get
      {
        if (this.extendedProperties == null)
          this.extendedProperties = new Hashtable();
        return (IDictionary) this.extendedProperties;
      }
    }

    public virtual string Name { get; set; }

    public virtual FilePath FileName { get; set; }

    public virtual FilePath ItemDirectory
    {
      get
      {
        return this.FileName.ParentDirectory.FullPath;
      }
    }

    public FilePath BaseDirectory
    {
      get
      {
        if (this.baseDirectory.IsNull)
          return this.FileName.ParentDirectory.FullPath;
        return this.baseDirectory;
      }
      set
      {
        if (!value.IsNull && !this.FileName.IsNull && this.FileName.ParentDirectory.FullPath == value.FullPath)
          this.baseDirectory = (FilePath) ((string) null);
        else if (value.IsNullOrEmpty)
          this.baseDirectory = (FilePath) ((string) null);
        else
          this.baseDirectory = value.FullPath;
      }
    }

    internal virtual FileFormat FileFormat
    {
      get
      {
        if (this.format == null)
          this.format = ProjectsService.Instance.GetDefaultFormat((object) this);
        return this.format;
      }
    }

    public void Save(IProgressMonitor monitor)
    {
      try
      {
        ProjectsService.Instance.Save(monitor, this);
        this.SaveUserProperties();
        this.OnSaved(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Save failed.", ex);
      }
    }

    public void Dispose()
    {
    }

    public virtual Project GetProjectContainingFile(FilePath fileName)
    {
      return (Project) null;
    }

    protected internal virtual void OnSave(IProgressMonitor monitor)
    {
      ProjectsService.Instance.InternalWriteWorkspaceItem(monitor, this.FileName, this);
    }

    protected virtual void OnSaved(IProgressMonitor monitor)
    {
    }

    void ILoadController.BeginLoad()
    {
      throw new NotImplementedException();
    }

    void ILoadController.EndLoad()
    {
      throw new NotImplementedException();
    }

    private void CollectDataModelType()
    {
      this.solutionPropertyList = new HashSet<Type>();
      foreach (TypeExtensionNode extensionNode in AddinManager.GetExtensionNodes(typeof (ISolutionPropertyData)))
        this.solutionPropertyList.Add(extensionNode.Type);
      AddinManager.AddExtensionNodeHandler(typeof (ISolutionPropertyData), new ExtensionNodeEventHandler(this.OnDataModelExtensionChange));
    }

    private void OnDataModelExtensionChange(object sender, ExtensionNodeEventArgs args)
    {
      TypeExtensionNode extensionNode = args.ExtensionNode as TypeExtensionNode;
      if (this.solutionPropertyList.Contains(extensionNode.Type))
        return;
      this.solutionPropertyList.Add(extensionNode.Type);
    }

    private void DataContextIncludeType(XmlDataSerializer ser)
    {
      foreach (Type solutionProperty in this.SolutionPropertyList)
        ser.SerializationContext.Serializer.DataContext.IncludeType(solutionProperty);
    }

    public virtual void LoadUserProperties()
    {
      if (this.userProperties != null)
        this.userProperties.Dispose();
      this.userProperties = (PropertyBag) null;
      string preferencesFileName = this.GetPreferencesFileName();
      if (!File.Exists(preferencesFileName))
        return;
      XmlTextReader xmlTextReader = new XmlTextReader(preferencesFileName);
      try
      {
        int content = (int) xmlTextReader.MoveToContent();
        if (xmlTextReader.LocalName != "Properties")
          return;
        XmlDataSerializer ser = new XmlDataSerializer(new DataContext());
        this.DataContextIncludeType(ser);
        ser.SerializationContext.BaseFile = preferencesFileName;
        this.userProperties = (PropertyBag) ser.Deserialize((XmlReader) xmlTextReader, typeof (PropertyBag));
      }
      catch (Exception ex)
      {
        LoggingService.LogError("Exception while loading user solution preferences.", ex);
      }
      finally
      {
        xmlTextReader.Close();
      }
    }

    public virtual void SaveUserProperties()
    {
      PropertyBag userProperties = this.UserProperties;
      string preferencesFileName = this.GetPreferencesFileName();
      if (this.userProperties == null || this.userProperties.IsEmpty)
      {
        if (!File.Exists(preferencesFileName))
          return;
        File.Delete(preferencesFileName);
      }
      else
      {
        XmlTextWriter xmlTextWriter = (XmlTextWriter) null;
        try
        {
          xmlTextWriter = new XmlTextWriter(preferencesFileName, Encoding.UTF8);
          xmlTextWriter.Formatting = Formatting.Indented;
          XmlDataSerializer ser = new XmlDataSerializer(new DataContext());
          this.DataContextIncludeType(ser);
          ser.SerializationContext.BaseFile = preferencesFileName;
          ser.Serialize((XmlWriter) xmlTextWriter, (object) this.userProperties, typeof (PropertyBag));
        }
        catch (Exception ex)
        {
          LoggingService.LogWarning("Could not save solution preferences: " + this.GetPreferencesFileName(), ex);
        }
        finally
        {
          if (xmlTextWriter != null)
            xmlTextWriter.Close();
        }
      }
    }

    internal string GetPreferencesFileName()
    {
      return (string) this.FileName.ChangeExtension(this.cfgFileSuffix);
    }
  }
}
