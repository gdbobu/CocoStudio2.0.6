using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
	[Extension(typeof(IProjectContent)), DataInclude(typeof(GameProjectContent))]
	public abstract class ProjectContent : IProjectContent, IProjectFile, IInitialize, IProject, IPublish
	{
		public abstract bool IsLoaded
		{
			get;
		}

		public IProjectFile ProjectFile
		{
			get;
			set;
		}

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
