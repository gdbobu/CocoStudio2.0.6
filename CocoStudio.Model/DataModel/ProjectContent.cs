// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ProjectContent
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
  [DataInclude(typeof (GameProjectContent))]
  [Extension(typeof (IProjectContent))]
  public abstract class ProjectContent : IProjectContent, IProjectFile, IInitialize, IProject, IPublish
  {
    public abstract bool IsLoaded { get; }

    public IProjectFile ProjectFile { get; set; }

    public abstract void Load(IProgressMonitor monitor);

    public abstract void Save(IProgressMonitor monitor);

    public abstract void Initialize(IProgressMonitor monitor);

    public abstract void UnLoad(IProgressMonitor monitor);

    public virtual void ReloadReferencedProject(IProgressMonitor monitor)
    {
    }

    public abstract HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor);

    public virtual void Publish(IProgressMonitor monitor, PublishInfo info)
    {
    }

    public abstract bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourceCollection);

    public virtual bool HasReferencedProject(Project project)
    {
      return false;
    }
  }
}
