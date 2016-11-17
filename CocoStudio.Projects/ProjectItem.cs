// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectItem
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  [DataInclude(typeof (ProjectFile))]
  public abstract class ProjectItem : IProjectFile, IInitialize, IProject, IPublish, IExtendedDataItem
  {
    private Hashtable hashtable;

    public IDictionary ExtendedProperties
    {
      get
      {
        if (this.hashtable == null)
          this.hashtable = new Hashtable();
        return (IDictionary) this.hashtable;
      }
    }

    public Project Project { get; set; }

    public bool IsLoaded { get; private set; }

    public void Initialize(IProgressMonitor monitor)
    {
      try
      {
        this.OnInitialize(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Project item initialize failed.", ex);
      }
    }

    protected virtual void OnInitialize(IProgressMonitor monitor)
    {
    }

    public void Load(IProgressMonitor monitor)
    {
      try
      {
        this.IsLoaded = true;
        this.OnLoad(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Load failed,", ex);
      }
    }

    protected virtual void OnLoad(IProgressMonitor monitor)
    {
    }

    public void Save(IProgressMonitor monitor)
    {
      try
      {
        this.OnSave(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Save failed,", ex);
      }
    }

    protected virtual void OnSave(IProgressMonitor monitor)
    {
    }

    public void UnLoad(IProgressMonitor monitor)
    {
      this.IsLoaded = false;
      this.OnUnLoad(monitor);
    }

    protected virtual void OnUnLoad(IProgressMonitor monitor)
    {
    }

    public HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor)
    {
      return this.OnGetUsedResources(monitor);
    }

    protected abstract HashSet<ResourceData> OnGetUsedResources(IProgressMonitor monitor);

    public bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourcesCollection)
    {
      return this.OnUpdateUsedResources(monitor, changedResourcesCollection);
    }

    protected abstract bool OnUpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourcesCollection);

    public void ReloadReferencedProject(IProgressMonitor monitor)
    {
      this.OnReloadReferencedProject(monitor);
    }

    protected virtual void OnReloadReferencedProject(IProgressMonitor monitor)
    {
    }

    public bool HasReferencedProject(Project project)
    {
      return this.OnHasReferencedProject(project);
    }

    protected abstract bool OnHasReferencedProject(Project project);

    public void Publish(IProgressMonitor monitor, PublishInfo info)
    {
      this.OnPublish(monitor, info);
    }

    internal void SetLocation(FilePath newFilePath)
    {
      this.OnSetLocation(newFilePath);
    }

    protected virtual void OnSetLocation(FilePath newFilePath)
    {
    }

    protected abstract void OnPublish(IProgressMonitor monitor, PublishInfo info);
  }
}
