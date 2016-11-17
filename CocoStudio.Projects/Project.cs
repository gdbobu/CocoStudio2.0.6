// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Project
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects
{
  [DataInclude(typeof (ProjectItem))]
  public class Project : ResourceFile, IProjectFile, IInitialize, IProject, IPublish
  {
    public const string FileSuffix = ".csd";
    private ProjectItem projectItem;

    public ProjectItem ProjectItem
    {
      get
      {
        return this.projectItem;
      }
    }

    public bool IsInitialized { get; private set; }

    public bool IsLoaded
    {
      get
      {
        if (this.projectItem == null)
          return false;
        return this.projectItem.IsLoaded;
      }
    }

    protected Project()
    {
    }

    public Project(FilePath file)
      : base(file)
    {
    }

    public Project(FilePath file, ProjectItem projectItem)
      : this(file)
    {
      this.projectItem = projectItem;
      this.projectItem.Project = this;
    }

    protected bool CheckInitialize(IProgressMonitor monitor)
    {
      if (this.projectItem == null)
        this.Initialize(monitor);
      return this.projectItem != null;
    }

    public void ReloadReferencedProject(IProgressMonitor monitor)
    {
      if (this.projectItem == null)
        return;
      this.projectItem.ReloadReferencedProject(monitor);
    }

    public bool HasReferencedProject(Project project)
    {
      if (this == project)
        return true;
      if (this.projectItem != null)
        return this.projectItem.HasReferencedProject(project);
      return false;
    }

    public void Load(IProgressMonitor monitor)
    {
      this.CheckInitialize(monitor);
      if (this.projectItem == null)
        return;
      this.projectItem.Load(monitor);
    }

    public bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourceCollection)
    {
      if (this.projectItem == null)
        return false;
      bool flag = this.projectItem.UpdateUsedResources(monitor, changedResourceCollection);
      if (flag)
        ProjectsService.Instance.InternalWriteProjectFile(monitor, this.FileName, this.projectItem as ProjectFile);
      return flag;
    }

    public void Save(IProgressMonitor monitor)
    {
      this.projectItem.Save(monitor);
    }

    public void Initialize(IProgressMonitor monitor)
    {
      if (!File.Exists((string) this.FileName))
        return;
      if (this.IsInitialized)
        return;
      try
      {
        this.projectItem = (ProjectItem) ProjectsService.Instance.InternalReadProjectFile(monitor, (string) this.FileName);
        this.projectItem.Project = this;
        this.projectItem.Initialize(monitor);
      }
      catch (Exception ex)
      {
        string message = string.Format("Project initialize failed. File is {0}.", (object) this.FileName);
        monitor.ReportError(message, ex);
      }
      this.IsInitialized = true;
    }

    public void UnLoad(IProgressMonitor monitor)
    {
      this.projectItem.UnLoad(monitor);
    }

    public void Reload(IProgressMonitor monitor)
    {
      this.IsInitialized = false;
      this.Initialize(monitor);
      if (!this.IsLoaded)
        return;
      this.Load(monitor);
    }

    public HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor)
    {
      return this.GetUsedResources(monitor, false);
    }

    public HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor, bool isSearchReferenceProjects)
    {
      if (this.projectItem == null)
        this.Initialize(monitor);
      HashSet<Project> searchedProjects = new HashSet<Project>();
      HashSet<ResourceData> resourceDataSet = new HashSet<ResourceData>();
      resourceDataSet.Add(this.GetResourceData());
      if (!isSearchReferenceProjects)
      {
        HashSet<ResourceData> usedResources = this.projectItem.GetUsedResources(monitor);
        if (usedResources != null)
          resourceDataSet.UnionWith((IEnumerable<ResourceData>) usedResources);
      }
      else
        Project.ScanProjectFile(monitor, this, resourceDataSet, searchedProjects);
      return Project.ProcessResourceDatas(resourceDataSet);
    }

    private static void ScanProjectFile(IProgressMonitor monitor, Project referenceProject, HashSet<ResourceData> resourceItems, HashSet<Project> searchedProjects)
    {
      HashSet<ResourceData> usedResources = referenceProject.ProjectItem.GetUsedResources(monitor);
      HashSet<Project> projectSet = new HashSet<Project>();
      foreach (ResourceData resourceData in usedResources)
      {
        if (ProjectsService.Instance.IsProjectFile(resourceData))
        {
          Project resourceItem = ProjectsService.Instance.CurrentResourceGroup.FindResourceItem(resourceData) as Project;
          if (resourceItem != null)
            projectSet.Add(resourceItem);
        }
      }
      resourceItems.UnionWith((IEnumerable<ResourceData>) usedResources);
      foreach (Project referenceProject1 in projectSet)
      {
        searchedProjects.Add(referenceProject1);
        Project.ScanProjectFile(monitor, referenceProject1, resourceItems, searchedProjects);
      }
    }

    private static HashSet<ResourceData> ProcessResourceDatas(HashSet<ResourceData> resourceDatas)
    {
      HashSet<ResourceData> resourceDataSet1 = new HashSet<ResourceData>();
      foreach (ResourceData resourceData in resourceDatas)
      {
        if (!(resourceData == (ResourceData) null))
        {
          IPublishProcesser publishProcesser = ProjectsService.Instance.GetPublishProcesser(resourceData);
          if (publishProcesser != null)
          {
            HashSet<ResourceData> resourceDataSet2 = publishProcesser.Process(resourceData);
            if (resourceDataSet2 != null)
              resourceDataSet1.UnionWith((IEnumerable<ResourceData>) resourceDataSet2);
          }
          else
            resourceDataSet1.Add(resourceData);
        }
      }
      return resourceDataSet1;
    }

    public virtual HashSet<ResourceData> Export(IProgressMonitor monitor)
    {
      return this.GetUsedResources(monitor, true);
    }

    public void Publish(IProgressMonitor monitor, PublishInfo info)
    {
      try
      {
        this.OnPublish(monitor, info);
      }
      catch (Exception ex)
      {
        string message = string.Format("Project {0} publish failed, the error is {1}", (object) this.FullPath, (object) ex.Message);
        monitor.ReportError(message, ex);
      }
    }

    protected virtual void OnPublish(IProgressMonitor monitor, PublishInfo info)
    {
      if (!this.CheckInitialize(monitor) || !this.CheckDestinationDirectory(monitor, info))
        return;
      info.SourceFilePath = (string) this.FileName;
      this.projectItem.Publish(monitor, info);
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename = true)
    {
      this.projectItem.SetLocation(newFilePath);
      base.OnSetLocation(newFilePath, isRename);
    }

    protected bool CheckDestinationDirectory(IProgressMonitor monitor, PublishInfo info)
    {
      FilePath absolute = this.FileName.ToRelative(ProjectsService.Instance.CurrentSolution.ItemDirectory).ToAbsolute((FilePath) info.PublishDirectory);
      info.DestinationFilePath = (string) absolute;
      string parentDirectory = (string) absolute.ParentDirectory;
      if (!Directory.Exists(parentDirectory))
      {
        try
        {
          Directory.CreateDirectory(parentDirectory);
        }
        catch (Exception ex)
        {
          string message = string.Format("Create directory {0} failed.", (object) parentDirectory);
          monitor.ReportError(message, ex);
          return false;
        }
      }
      return true;
    }
  }
}
