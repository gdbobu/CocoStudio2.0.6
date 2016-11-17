// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceFolder
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CocoStudio.Projects
{
  [DataItem(Name = "Folder")]
  [DataInclude(typeof (PlistImageFolder))]
  public class ResourceFolder : ResourceItem, IFoldeItem, IProjectFile, IInitialize, ICustomDataItem
  {
    public const string tempAppendFileName = "TempAppendFileName.Folder";
    private ResourceItemCollection items;

    [ResourcePathItemProperty("Name")]
    public FilePath BaseDirectory { get; protected set; }

    public ResourceItemCollection Items
    {
      get
      {
        if (this.items == null)
          this.items = new ResourceItemCollection((ResourceItem) this);
        return this.items;
      }
    }

    public override string Name
    {
      get
      {
        return this.BaseDirectory.FileName;
      }
      protected set
      {
        if (!(this.BaseDirectory.FileName != value))
          return;
        this.BaseDirectory = this.BaseDirectory.ParentDirectory.Combine(new string[1]{ value });
      }
    }

    public override string FullPath
    {
      get
      {
        return (string) this.BaseDirectory.FullPath;
      }
    }

    public bool IsLoaded
    {
      get
      {
        return false;
      }
    }

    public ResourceFolder()
    {
    }

    public ResourceFolder(FilePath directoryPath)
      : this()
    {
      if (!directoryPath.IsAbsolute)
        throw new ArgumentException("Must be absolute path.");
      this.BaseDirectory = directoryPath;
    }

    public override ResourceData GetResourceData()
    {
      return this.CreateResourceData(this.BaseDirectory);
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename = true)
    {
      if (!Directory.Exists((string) newFilePath))
        Directory.CreateDirectory((string) newFilePath);
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.items)
      {
        string str = (string) newFilePath.Combine(new string[1]
        {
          resourceItem.Name
        });
        resourceItem.SetLocation((FilePath) str, isRename);
      }
      if (Directory.Exists((string) this.BaseDirectory) && !isRename)
        this.BaseDirectory.Delete();
      this.BaseDirectory = newFilePath;
      base.OnSetLocation(newFilePath, isRename);
    }

    public DataCollection Serialize(ITypeSerializer handler)
    {
      DataCollection dataCollection = handler.Serialize((object) this);
      string baseFile = handler.SerializationContext.BaseFile;
      handler.SerializationContext.BaseFile = (string) this.BaseDirectory.Combine(new string[1]
      {
        "TempAppendFileName.Folder"
      });
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        DataNode entry = handler.SerializationContext.Serializer.Serialize((object) resourceItem);
        dataCollection.Add(entry);
      }
      handler.SerializationContext.BaseFile = baseFile;
      return dataCollection;
    }

    public void Deserialize(ITypeSerializer handler, DataCollection data)
    {
      string baseFile = handler.SerializationContext.BaseFile;
      handler.Deserialize((object) this, data);
      handler.SerializationContext.BaseFile = (string) this.BaseDirectory.Combine(new string[1]
      {
        "TempAppendFileName.Folder"
      });
      foreach (DataNode dataNode in data)
      {
        DataItem dataItem = dataNode as DataItem;
        if (dataItem != null)
          this.Items.Add(handler.SerializationContext.Serializer.DataContext.GetConfigurationDataType(dataNode.Name).Deserialize(handler.SerializationContext, (object) null, (DataNode) dataItem) as ResourceItem);
      }
      this.ExtendedProperties.Clear();
      handler.SerializationContext.BaseFile = baseFile;
    }

    protected override void OnDelete()
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.items)
        resourceItem.Delete();
      this.BaseDirectory.Delete();
      base.OnDelete();
    }

    void IInitialize.Initialize(IProgressMonitor monitor)
    {
      this.OnInitialize(monitor);
    }

    void IProjectFile.Load(IProgressMonitor monitor)
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        IProjectFile projectFile = resourceItem as IProjectFile;
        if (projectFile != null)
          projectFile.Load(monitor);
      }
    }

    void IProjectFile.Save(IProgressMonitor monitor)
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        IProjectFile projectFile = resourceItem as IProjectFile;
        if (projectFile != null)
          projectFile.Save(monitor);
      }
    }

    void IProjectFile.UnLoad(IProgressMonitor monitor)
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        IProjectFile projectFile = resourceItem as IProjectFile;
        if (projectFile != null)
          projectFile.UnLoad(monitor);
      }
    }

    protected virtual void OnInitialize(IProgressMonitor monitor)
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        IProjectFile projectFile = resourceItem as IProjectFile;
        if (projectFile != null)
          projectFile.Initialize(monitor);
      }
    }

    HashSet<ResourceData> IProjectFile.GetUsedResources(IProgressMonitor monitor)
    {
      return this.GetUsedResources(monitor, false);
    }

    public HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor, bool isSearchReferenceProject)
    {
      HashSet<ResourceData> resourceDataSet1 = new HashSet<ResourceData>();
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        try
        {
          if (resourceItem is IProjectFile)
          {
            IProjectFile projectFile = resourceItem as IProjectFile;
            HashSet<ResourceData> resourceDataSet2 = !(projectFile is Project) ? projectFile.GetUsedResources(monitor) : ((Project) projectFile).GetUsedResources(monitor, isSearchReferenceProject);
            if (resourceDataSet2 != null)
              resourceDataSet1.UnionWith((IEnumerable<ResourceData>) resourceDataSet2);
          }
        }
        catch (Exception ex)
        {
          string message = string.Format("Resource {0} publish failed, the error is {1}", (object) resourceItem.FullPath, (object) ex.Message);
          monitor.ReportError(message, ex);
          LogConfig.Output.Error((object) string.Format("Resource {0} publish failed!", (object) resourceItem.FullPath));
        }
      }
      return resourceDataSet1;
    }

    bool IProjectFile.UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourcesCollection)
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        IProjectFile projectFile = resourceItem as IProjectFile;
        if (projectFile != null)
          projectFile.UpdateUsedResources(monitor, changedResourcesCollection);
      }
      return false;
    }

    protected override void OnRefresh()
    {
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.items)
        resourceItem.Refresh(true);
    }
  }
}
