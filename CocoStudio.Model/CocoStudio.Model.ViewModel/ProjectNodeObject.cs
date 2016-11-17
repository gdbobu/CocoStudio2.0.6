using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using MonoDevelop.Core;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[DisplayName("Display_Component_Entity")]
	public class ProjectNodeObject : NodeObject, ISingleNode
	{
		private NodeObject rootObject;

		private ResourceFile filePath = null;

		public Project Project
		{
			get;
			private set;
		}

		[ResourceFilter(new string[]
		{
			"csd"
		}), PropertyOrder(81), UndoProperty, Browsable(true), Category("Group_Feature"), DefaultValue(null), DisplayName("Display_File"), Editor(typeof(ResourceFileEditor), typeof(ResourceFileEditor))]
		public ResourceFile FileData
		{
			get
			{
				return this.filePath;
			}
			set
			{
				if (this.filePath != value)
				{
					this.filePath = value;
					this.Project = (value as Project);
					this.ReloadProject();
					string compositeTaskName = base.GetType().Name + "FileData";
					using (CompositeTask.Run(compositeTaskName))
					{
						this.RaisePropertyChanged<PointF>(() => this.Size);
						this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
					}
				}
			}
		}

		[PropertyOrder(7), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_AnchorPoint"), Editor(typeof(AnchorPointEditor), typeof(AnchorPointEditor))]
		public override ScaleValue AnchorPoint
		{
			get
			{
				return this.GetCSVisual().GetAnchorPoint();
			}
			set
			{
				if (base.IsTransformEnabled)
				{
					this.GetCSVisual().SetAnchorPoint(value);
					this.RaisePropertyChanged<ScaleValue>(() => this.AnchorPoint);
				}
			}
		}

		private CSNode GetInnerObject()
		{
			return this.innerNode;
		}

		public ProjectNodeObject()
		{
		}

		public ProjectNodeObject(Project project)
		{
			this.FileData = project;
		}

		public ProjectNodeObject(CSNode customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			this.innerNode = new CSNode();
		}

		protected override void InitData()
		{
			base.InitData();
			this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
		}

		private void LoadProject(Project project)
		{
			if (project != null && project.IsValid)
			{
				string filename = this.Project.FileName;
				IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
				Project project2 = Services.ProjectsService.ReadProject(consoleProgressMonitor, filename);
				project2.Load(consoleProgressMonitor);
				if (consoleProgressMonitor.AsyncOperation.Success)
				{
					this.rootObject = project2.GetRootNode();
					if (this.rootObject != null)
					{
						this.rootObject.GetCSVisual().SetZOrder(-1);
					}
					this.innerNode.AddChild(this.rootObject.GetCSVisual());
				}
			}
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			ProjectNodeObject projectNodeObject = cObject as ProjectNodeObject;
			if (projectNodeObject != null)
			{
				projectNodeObject.FileData = this.FileData;
			}
		}

		internal void ReloadProject()
		{
			if (this.rootObject != null)
			{
				this.innerNode.RemoveChild(this.rootObject.GetCSVisual());
			}
			this.LoadProject(this.Project);
		}
	}
}
