using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Lib.Prism;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Event;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[Catagory("Group_Feature", 2, 0), Catagory("Group_Routine", 0, 0), Catagory("grid_sudoku", 1, 0), Catagory("CallBack_Feature", 8, 1), Catagory("Thing_feature", 3, 0), Catagory("Display_ControlLayout", -1, 0), Catagory("Frame_Feature", 5, 1), Catagory("Physics_Feature", 6, 1), Catagory("Category_Component_Layout", 7, 1)]
	public class NodeObject : VisualObject, IDragSource, IDropTarget, IPropertyTitle
	{
		protected CSNode innerNode;

		protected bool IsAddToCurrent = true;

		private NodeObject parent;

		protected bool CanShowMessage = false;

		private CSNode.ObjectState OldState = CSNode.ObjectState.Default;

		[Browsable(false)]
		public NodeObject Parent
		{
			get
			{
				return this.parent;
			}
			internal set
			{
				this.parent = value;
				this.RaisePropertyChanged<NodeObject>(() => this.Parent);
			}
		}

		[UndoProperty, Browsable(false)]
		public NodeCollection Children
		{
			get;
			private set;
		}

		public virtual int ObjectIndex
		{
			get;
			set;
		}

		public override bool IsSelected
		{
			get
			{
				return base.IsSelected;
			}
			set
			{
				base.IsSelected = value;
				if (value)
				{
					this.SetObjectState(CSNode.ObjectState.Seleted);
				}
				else
				{
					this.SetObjectState(CSNode.ObjectState.Default);
				}
			}
		}

		[UndoProperty]
		public virtual bool PrePositionEnabled
		{
			get
			{
				return this.innerNode.IsPrePositionEnabled();
			}
			set
			{
				this.innerNode.SetPrePositionEnabled(value);
				bool isRunningCompositeTask = Services.TaskService.IsRunningCompositeTask;
				if (isRunningCompositeTask)
				{
					this.RaisePropertyChanged<PointF>(() => this.Position);
					this.RaisePropertyChanged<PointF>(() => this.PrePosition);
					this.RaisePropertyChanged<bool>(() => this.PrePositionEnabled);
				}
				else
				{
					using (CompositeTask.Run("PrePositionEnabled"))
					{
						this.RaisePropertyChanged<PointF>(() => this.Position);
						this.RaisePropertyChanged<PointF>(() => this.PrePosition);
						this.RaisePropertyChanged<bool>(() => this.PrePositionEnabled);
					}
				}
			}
		}

		[PropertyOrder(5), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_PositionType")]
		public virtual LayoutRefrencePoint RefrencePoint
		{
			get
			{
				return (LayoutRefrencePoint)this.innerNode.GetPositionType();
			}
			set
			{
				this.innerNode.SetPositionType((int)value);
				this.RaisePropertyChanged<LayoutRefrencePoint>(() => this.RefrencePoint);
			}
		}

		public virtual PointF PrePosition
		{
			get
			{
				return this.innerNode.GetPrePosition();
			}
			set
			{
				this.innerNode.SetPrePosition(value);
				this.RaisePropertyChanged<PointF>(() => this.Position);
			}
		}

		[UndoProperty]
		public virtual bool PreSizeEnable
		{
			get
			{
				return this.innerNode.IsPreSizeEnabled();
			}
			set
			{
				this.innerNode.SetPreSizeEnabled(value);
				this.RefreshBoundingBox(false);
				bool isRunningCompositeTask = Services.TaskService.IsRunningCompositeTask;
				if (isRunningCompositeTask)
				{
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<bool>(() => this.PreSizeEnable);
				}
				else
				{
					using (CompositeTask.Run("PreSizeEnable"))
					{
						this.RaisePropertyChanged<PointF>(() => this.Size);
						this.RaisePropertyChanged<bool>(() => this.PreSizeEnable);
					}
				}
			}
		}

		public virtual PointF PreSize
		{
			get
			{
				return this.innerNode.GetPreSize();
			}
			set
			{
				this.innerNode.SetPreSize(value);
				this.RefreshBoundingBox(false);
				this.RaisePropertyChanged<PointF>(() => this.Size);
			}
		}

		[PropertyOrder(3), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_CascadeColor")]
		public virtual bool CascadeColor
		{
			get
			{
				return this.innerNode.GetCascadeColorEnabled();
			}
			set
			{
				this.innerNode.SetCascadeColorEnabled(value);
				this.RaisePropertyChanged<bool>(() => this.CascadeColor);
			}
		}

		[PropertyOrder(4), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_CascadeAlpha")]
		public virtual bool CascadeAlpha
		{
			get
			{
				return this.innerNode.GetCascadeOpacityEnabled();
			}
			set
			{
				this.innerNode.SetCascadeOpacityEnabled(value);
				this.RaisePropertyChanged<bool>(() => this.CascadeAlpha);
			}
		}

		[UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_Name")]
		public override string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				base.Name = value;
			}
		}

		[UndoProperty, Browsable(true), Category("Group_Routine"), DefaultValue(-1), DisplayName("Display_Target")]
		public virtual int Tag
		{
			get
			{
				return this.GetCSVisual().GetTag();
			}
			set
			{
				this.GetCSVisual().SetTag(value);
				this.RaisePropertyChanged<int>(() => this.Tag);
			}
		}

		public bool IconVisible
		{
			get
			{
				return this.innerNode.GetIconVisible();
			}
			set
			{
				this.innerNode.SetIconVisible(value);
			}
		}

		[PropertyOrder(0), UndoProperty, Browsable(false), Category("CallBack_Feature"), DisplayName("CallBack_ClassName"), Editor(typeof(CallBackPropertyRootEditor), typeof(CallBackPropertyRootEditor))]
		public virtual string CustomClassName
		{
			get;
			set;
		}

		[PropertyOrder(0), UndoProperty, Browsable(false), Category("CallBack_Feature"), DisplayName("CallBack_Method"), Editor(typeof(CallBackPropertyEditor), typeof(CallBackPropertyEditor))]
		public virtual EnumCallBack CallBackType
		{
			get;
			set;
		}

		public virtual string CallBackName
		{
			get;
			set;
		}

		[Browsable(false)]
		public virtual bool IsDraggable
		{
			get
			{
				return true;
			}
		}

		public NodeObject()
		{
			this.CreateCSObject();
			this.InitData();
		}

		public NodeObject(CSNode comEntiy)
		{
			this.innerNode = comEntiy;
			this.CreateCSObject();
			this.InitData();
		}

		protected virtual void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSNode();
			}
		}

		internal override CSVisualObject GetCSVisual()
		{
			return this.innerNode;
		}

		protected virtual void RefreshObjectIndex()
		{
			if (Services.ProjectOperations.CurrentSelectedProject != null)
			{
				this.ObjectIndex = Services.ProjectOperations.CurrentSelectedProject.GetTypeIndex(base.GetType());
			}
		}

		protected virtual void InitData()
		{
			this.Tag = VisualObject.tag++;
			this.Children = new NodeCollection(this);
			this.RefreshObjectIndex();
			string name = base.GetType().Name;
			this.Name = name.Substring(0, name.Length - 6) + "_" + this.ObjectIndex;
			base.IsTransformEnabled = true;
			this.CallBackType = EnumCallBack.None;
		}

		public bool HasFrame(string frameType)
		{
			bool result;
			foreach (Timeline current in base.Timelines)
			{
				if (current.FrameType == frameType)
				{
					if (current.Frames.Count > 0)
					{
						result = true;
						return result;
					}
					break;
				}
			}
			result = false;
			return result;
		}

		internal override void RefreshBoundingBox(bool bRefresh = false)
		{
			if (bRefresh)
			{
				this.RaisePropertyChanged<PointF>(() => this.Size, false);
			}
			this.innerNode.RefreshBoundingObjects();
			foreach (NodeObject current in this.Children)
			{
				if (current.PreSizeEnable)
				{
					current.RefreshBoundingBox(true);
				}
			}
		}

		internal virtual void InsertChild(int index, NodeObject nObject)
		{
			this.GetCSVisual().InsertChild(index, nObject.GetCSVisual());
			nObject.OperationFlag |= OperationMask.MoveFlag;
			nObject.RefreshBoundingBox(true);
			nObject.Parent = this;
		}

		internal virtual void RemoveChild(NodeObject nObject)
		{
			this.GetCSVisual().RemoveChild(nObject.GetCSVisual());
			nObject.Parent = null;
		}

		internal virtual void AfterAdded()
		{
		}

		internal virtual void BeforeRemoved()
		{
		}

		public override IEnumerable<VisualObject> GetVisualChildren()
		{
			return this.Children;
		}

		protected override void OnDragEnter(DragMotionArgs e)
		{
			this.CanShowMessage = true;
			this.OldState = this.innerNode.GetObjectState();
			if (this.CanReceiveModelObject(e.Context.GetDragData() as ModelDragData))
			{
				if (base.IsHitTestVisible)
				{
					this.SetObjectState(CSNode.ObjectState.DragOver);
				}
			}
		}

		protected override void OnDragLeave(DragMotionArgs e)
		{
			this.CanShowMessage = false;
			e.SetAllowDragAction((DragAction)0);
			this.SetObjectState(this.OldState);
		}

		protected override bool OnDragOver(DragMotionArgs e)
		{
			bool result;
			if (e.Context.GetDataPresent(typeof(ResourceInfoDragData)))
			{
				if (!this.CanReceiveResourceObject(e.Context.GetDragData() as ResourceInfoDragData))
				{
					e.SetAllowDragAction((DragAction)0);
					result = false;
					return result;
				}
			}
			result = base.OnDragOver(e);
			return result;
		}

		protected override void OnDragDrop(DragDropArgs e)
		{
			if (e.Context.GetDataPresent(typeof(ResourceInfoDragData)))
			{
				string text = this.CanDragDrop(e);
				if (text != null)
				{
					LogConfig.Output.Error(text, null);
					return;
				}
			}
			bool isRunningCompositeTask = Services.TaskService.IsRunningCompositeTask;
			if (!isRunningCompositeTask)
			{
				Services.TaskService.BeginCompositeTask("Drag drop GameObject");
			}
			List<VisualObject> list = new List<VisualObject>();
			if (e.Context.GetDataPresent(typeof(ResourceInfoDragData)))
			{
				ResourceInfoDragData resourceInfoDragData = (ResourceInfoDragData)e.Context.GetDragData();
				if (resourceInfoDragData == null)
				{
					return;
				}
				foreach (ResourceItem current in resourceInfoDragData.Items)
				{
					if (!(current is ResourceFolder))
					{
						NodeObject nodeObject = this.CreateObjectFromFile(current);
						if (nodeObject != null)
						{
							this.LoadNodeObject(nodeObject, new PointF((float)e.X, (float)e.Y));
							list.Add(nodeObject);
						}
					}
				}
			}
			else if (e.Context.GetDataPresent(typeof(ModelDragData)))
			{
				ModelDragData modelDragData = (ModelDragData)e.Context.GetDragData();
				NodeObject nodeObject2 = modelDragData.MetaData.CreateObject();
				this.LoadNodeObject(nodeObject2, new PointF((float)e.X, (float)e.Y));
				list.Add(nodeObject2);
			}
			this.SetObjectState(CSNode.ObjectState.Default);
			EventAggregator.Instance.GetEvent<SelectedVisualObjectsChangeEvent>().Publish(new SelectedVisualObjectsChangeEventArgs(list, list, false));
			if (!isRunningCompositeTask)
			{
				Services.TaskService.EndCompositeTask();
			}
		}

		private string CanDragDrop(DragDropArgs e)
		{
			ResourceInfoDragData resourceInfoDragData = e.Context.GetDragData() as ResourceInfoDragData;
			GameProjectFile gameProjectFile = Services.ProjectOperations.CurrentSelectedProject.ProjectItem as GameProjectFile;
			string result;
			foreach (ResourceItem current in resourceInfoDragData.Items)
			{
				if (current.FullPath == gameProjectFile.FileName)
				{
					result = LanguageInfo.MessageBox207_NestedSelfError;
					return result;
				}
				Project project = current as Project;
				if (project != null)
				{
					string text = project.CheckNest(gameProjectFile.Project);
					if (!string.IsNullOrEmpty(text))
					{
						result = text;
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		protected virtual bool CanReceiveModelObject(ModelDragData objectData)
		{
			return false;
		}

		protected virtual bool CanReceiveResourceObject(ResourceInfoDragData objectData)
		{
			bool result;
			if (objectData == null)
			{
				result = false;
			}
			else
			{
				GameProjectFile gameProjectFile = Services.ProjectOperations.CurrentSelectedProject.ProjectItem as GameProjectFile;
				if (gameProjectFile == null)
				{
					result = false;
				}
				else
				{
					foreach (ResourceItem current in objectData.Items)
					{
						if (!(current is ImageFile) && !(current is PlistImageFile) && !(current is Project))
						{
							result = false;
							return result;
						}
					}
					result = true;
				}
			}
			return result;
		}

		protected virtual void LoadNodeObject(NodeObject gObject, PointF coord)
		{
			if (gObject != null)
			{
				PointF sencePoint = SceneTransformHelp.ConvertControlToScene(coord);
				NodeObject nodeObject;
				if (this.IsAddToCurrent)
				{
					nodeObject = this;
				}
				else
				{
					nodeObject = Services.ProjectOperations.CurrentSelectedProject.GetRootNode();
				}
				PointF position = nodeObject.TransformToSelf(sencePoint);
				gObject.Position = position;
				nodeObject.Children.Add(gObject);
			}
		}

		protected virtual NodeObject CreateObjectFromFile(ResourceItem resourceFile)
		{
			NodeObject result;
			if (resourceFile is ImageFile || resourceFile is PlistImageFile)
			{
				result = new SpriteObject(resourceFile as ResourceFile);
			}
			else
			{
				if (resourceFile is Project)
				{
					Project project = resourceFile as Project;
					if (project.IsGameProject())
					{
						result = new ProjectNodeObject(project);
						return result;
					}
				}
				else if (resourceFile is AudioFile)
				{
					result = new SimpleAudioObject(resourceFile as ResourceFile);
					return result;
				}
				result = null;
			}
			return result;
		}

		public virtual bool CanDrop(object node, DropPosition mode, bool copy)
		{
			bool result;
			if (copy || !(node is NodeObject) || this.IsAncestor(node as NodeObject))
			{
				result = false;
			}
			else
			{
				NodeObject nodeObject = node as NodeObject;
				switch (mode)
				{
				case DropPosition.InsertBefore:
					if (this.Parent == null || !this.Parent.CanDrop(node, DropPosition.Add, copy))
					{
						result = false;
						return result;
					}
					break;
				case DropPosition.InsertAfter:
					if (this.Parent == null || !this.Parent.CanDrop(node, DropPosition.Add, copy))
					{
						result = false;
						return result;
					}
					break;
				}
				result = true;
			}
			return result;
		}

		public virtual void Drop(List<object> node, DropPosition mode, bool copy)
		{
			bool isRunningCompositeTask = Services.TaskService.IsRunningCompositeTask;
			if (!isRunningCompositeTask)
			{
				Services.TaskService.BeginCompositeTask("Drag drop GameObject");
			}
			foreach (object current in node)
			{
				if (!copy)
				{
					IDragSource dragSource = current as IDragSource;
					if (dragSource != null)
					{
						dragSource.Detach();
					}
				}
				NodeObject nodeObject = current as NodeObject;
				if (nodeObject != null)
				{
					this.LoadDropObject(nodeObject, mode);
				}
			}
			if (!isRunningCompositeTask)
			{
				Services.TaskService.EndCompositeTask();
			}
		}

		public virtual void Detach()
		{
			if (this.Parent != null)
			{
				this.Parent.Children.Remove(this);
			}
		}

		protected virtual void LoadDropObject(NodeObject gameObjectData, DropPosition mode)
		{
			switch (mode)
			{
			case DropPosition.Add:
				this.Children.Add(gameObjectData);
				break;
			case DropPosition.InsertBefore:
			{
				int index = this.Parent.Children.IndexOf(this);
				this.Parent.Children.Insert(index, gameObjectData);
				break;
			}
			case DropPosition.InsertAfter:
			{
				int num = this.Parent.Children.IndexOf(this);
				this.Parent.Children.Insert(num + 1, gameObjectData);
				break;
			}
			}
		}

		internal bool IsAncestor(NodeObject obj)
		{
			return obj != null && (obj == this.Parent || (this.Parent != null && this.Parent.IsAncestor(obj)));
		}

		internal virtual void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
		{
			if (action == NotifyCollectionChangedAction.Add)
			{
				((IResourceObject)this).CollectResources();
			}
			else if (action == NotifyCollectionChangedAction.Remove)
			{
				((IResourceObject)this).ClearResources();
			}
			if (this.Children != null)
			{
				foreach (NodeObject current in this.Children)
				{
					current.AncestorObjectChanged(sourceObj, action);
				}
			}
		}

		protected override void OnKeyDown(KeyPressEventArgs e)
		{
			PointF vectorByKey = base.GetVectorByKey(e.Event.Key);
			if (vectorByKey != null)
			{
				if (this.OperationFlag.HasFlag(OperationMask.MoveFlag))
				{
					this.Position = new PointF(this.Position.X + vectorByKey.X, this.Position.Y + vectorByKey.Y);
				}
			}
		}

		protected override void OnKeyUp(KeyReleaseEventArgs e)
		{
		}

		protected override void OnMouseMove(MouseEventArgsExtend args)
		{
		}

		public override object Clone()
		{
			Type type = base.GetType();
			Type type2 = this.GetCSVisual().GetType();
			CSNode cSNode = Activator.CreateInstance(type2) as CSNode;
			NodeObject nodeObject = Activator.CreateInstance(type, new object[]
			{
				cSNode
			}) as NodeObject;
			this.SetValue(nodeObject, cSNode);
			this.SetAnimation(nodeObject);
			foreach (NodeObject current in this.Children)
			{
				nodeObject.Children.Add((NodeObject)current.Clone());
			}
			return nodeObject;
		}

		protected virtual void SetAnimation(object cObject)
		{
			foreach (Timeline current in base.Timelines)
			{
				Timeline timeline = Timeline.CreateTimeline(current.FrameType, cObject as NodeObject);
				foreach (Frame current2 in current.OrderedFrames)
				{
					Frame item = Frame.CreateFrame(current2);
					timeline.Frames.Add(item);
				}
			}
		}

		protected virtual void SetValue(object cObject, object cInnerObject)
		{
			NodeObject nodeObject = cObject as NodeObject;
			if (nodeObject != null)
			{
				nodeObject.Name = this.Name + "_Copy";
				nodeObject.CanEdit = this.CanEdit;
				nodeObject.OperationFlag = this.OperationFlag;
				nodeObject.Alpha = this.Alpha;
				nodeObject.CColor = this.CColor;
				nodeObject.Visible = this.Visible;
				nodeObject.ZOrder = this.ZOrder;
				nodeObject.Scale = this.Scale;
				nodeObject.Position = this.Position;
				nodeObject.RotationSkew = this.RotationSkew;
				nodeObject.AnchorPoint = this.AnchorPoint;
				nodeObject.VisibleForFrame = this.VisibleForFrame;
				nodeObject.Parent = this.Parent;
				nodeObject.PrePositionEnabled = this.PrePositionEnabled;
				nodeObject.FrameEvent = this.FrameEvent;
				nodeObject.CustomClassName = this.CustomClassName;
			}
		}

		public virtual bool GetChildGlobalIndex(NodeObject vObject, ref int index)
		{
			index++;
			bool result;
			if (this.Children == null || this.Children.Count == 0)
			{
				result = false;
			}
			else
			{
				foreach (NodeObject current in this.Children)
				{
					if (current == vObject)
					{
						result = true;
						return result;
					}
					if (current.GetChildGlobalIndex(vObject, ref index))
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}

		public virtual void SetObjectState(CSNode.ObjectState objectState)
		{
			this.innerNode.SetObjectState(objectState);
		}
	}
}
