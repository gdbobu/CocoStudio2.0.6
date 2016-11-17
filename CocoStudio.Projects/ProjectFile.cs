// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects
{
  [JsonObject(MemberSerialization.OptIn)]
  [DataInclude(typeof (GameProjectFile))]
  public abstract class ProjectFile : ProjectItem, IFileItem
  {
    [JsonProperty(PropertyName = "Version")]
    [ItemProperty("PropertyGroup/Version")]
    private string version = Option.EditorVersion.ToString();
    private FileFormat format;
    [ItemProperty("PropertyGroup/ID")]
    [JsonProperty(PropertyName = "ID")]
    private string projectID;

    internal virtual FileFormat FileFormat
    {
      get
      {
        if (this.format == null)
          this.format = ProjectsService.Instance.GetDefaultFormat((object) this);
        return this.format;
      }
    }

    public FilePath FileName { get; set; }

    [JsonProperty(PropertyName = "Type")]
    [ItemProperty("PropertyGroup/Type")]
    public virtual string ProjectType { get; set; }

    public Guid ProjectID
    {
      get
      {
        return new Guid(this.projectID);
      }
    }

    public string Version
    {
      get
      {
        return this.version;
      }
      set
      {
        this.version = value;
      }
    }

    [JsonProperty(PropertyName = "Name")]
    [ItemProperty("PropertyGroup/Name")]
    public string Name
    {
      get
      {
        return this.FileName.FileNameWithoutExtension;
      }
      private set
      {
      }
    }

    [JsonProperty]
    [ItemProperty]
    public IProjectContent Content { get; set; }

    protected ProjectFile()
    {
      this.projectID = Guid.NewGuid().ToString();
    }

    public ProjectFile(FilePath file)
      : this()
    {
      this.FileName = file;
    }

    public ProjectFile(ProjectCreateInformation info)
      : this(info.FileName)
    {
      this.Content = info.Content;
    }

    protected override void OnInitialize(IProgressMonitor monitor)
    {
      if (this.Content == null)
        return;
      this.Content.Initialize(monitor);
      this.Content.ProjectFile = (IProjectFile) this;
    }

    protected override void OnSave(IProgressMonitor monitor)
    {
      if (this.Content != null)
        this.Content.Save(monitor);
      string directoryName = Path.GetDirectoryName((string) this.FileName);
      if (!Directory.Exists(directoryName))
        Directory.CreateDirectory(directoryName);
      ProjectsService.Instance.InternalWriteProjectFile(monitor, this.FileName, this);
    }

    protected override void OnLoad(IProgressMonitor monitor)
    {
      if (this.Content == null)
        return;
      this.Content.Load(monitor);
    }

    protected override void OnUnLoad(IProgressMonitor monitor)
    {
      if (this.Content == null)
        return;
      this.Content.UnLoad(monitor);
    }

    protected override void OnReloadReferencedProject(IProgressMonitor monitor)
    {
      if (this.Content == null)
        return;
      this.Content.ReloadReferencedProject(monitor);
    }

    protected override HashSet<ResourceData> OnGetUsedResources(IProgressMonitor monitor)
    {
      if (this.Content != null)
        return this.Content.GetUsedResources(monitor);
      return (HashSet<ResourceData>) null;
    }

    protected override void OnPublish(IProgressMonitor monitor, PublishInfo info)
    {
      if (this.Content == null)
        return;
      this.Content.Publish(monitor, info);
    }

    protected override bool OnUpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourcesCollection)
    {
      if (this.Content != null)
        return this.Content.UpdateUsedResources(monitor, changedResourcesCollection);
      return false;
    }

    protected override bool OnHasReferencedProject(Project project)
    {
      if (this.Content != null)
        return this.Content.HasReferencedProject(project);
      return false;
    }

    protected override void OnSetLocation(FilePath newFilePath)
    {
      this.FileName = newFilePath;
      base.OnSetLocation(newFilePath);
    }
  }
}
