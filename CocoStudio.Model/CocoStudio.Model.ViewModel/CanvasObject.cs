using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Lib.Prism;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Event;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using CocoStudio.Projects.Visiter;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.Model.ViewModel
{
	[DisplayName("Display_Component_Canvas")]
	public class CanvasObject : VisualObject
	{
		private const float MaxZoom = 4f;

		private const float MinZoom = 0.1f;

		public const float DeltaZoom = 0.1f;

		private CSCanvas canvasEntity;

		private Size sceneSize = new Size(480, 320);

		private ScaleValue scale = new ScaleValue();

		[UndoProperty, Browsable(false)]
		public ObservableCollection<NodeObject> Children
		{
			get;
			set;
		}

		[Category("Group_Routine")]
		public override PointF Size
		{
			get
			{
				Size canvasSize = this.canvasEntity.GetCanvasSize();
				return new PointF((float)canvasSize.Width, (float)canvasSize.Height);
			}
			set
			{
				Size canvasSize = new Size((int)value.X, (int)value.Y);
				this.canvasEntity.SetCanvasSize(canvasSize);
				this.RaisePropertyChanged<PointF>(() => this.Size);
			}
		}

		[Browsable(false), Category("Group_Routine"), DisplayName("Display_Scale"), Editor(typeof(ScaleEditor), typeof(ScaleEditor))]
		public override ScaleValue Scale
		{
			get
			{
				return this.canvasEntity.GetScale();
			}
			set
			{
				if (this.CheckScaleValue(value) && !this.scale.Equals(value))
				{
					this.scale = value;
					this.canvasEntity.SetScale(this.scale);
					this.RaisePropertyChanged<ScaleValue>(() => this.Scale);
				}
			}
		}

		[Browsable(false)]
		public override PointF Position
		{
			get
			{
				return this.GetCSVisual().GetPosition();
			}
			set
			{
				this.GetCSVisual().SetPosition(value);
				this.RaisePropertyChanged<PointF>(() => this.Position, false);
			}
		}

		[Browsable(false)]
		public override float Rotation
		{
			get;
			set;
		}

		[Browsable(false)]
		public override int ZOrder
		{
			get;
			set;
		}

		[Browsable(false)]
		private NodeObject CurrentNodeObject
		{
			get
			{
				return Services.ProjectOperations.CurrentSelectedProject.GetRootNode();
			}
		}

		public Size GetSceneSize()
		{
			return this.sceneSize;
		}

		public void SetSceneSize(Size value, bool refreshSize = true)
		{
			this.sceneSize = value;
			if (refreshSize)
			{
				this.Size = new PointF((float)value.Width, (float)value.Height);
				this.RaiseCanvasSizeChangeEvent(value);
			}
		}

		internal CanvasObject(CSCanvas canvasEntity)
		{
			this.canvasEntity = canvasEntity;
			this.CanEdit = false;
			this.IsSelected = false;
			this.SetSceneSize(Services.ProjectOperations.CurrentSelectedSolution.GetSceneSize(), true);
			this.BindingRecorder(null);
			this.Children = new ObservableCollection<NodeObject>();
			this.Children.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ChildrenList_CollectionChanged);
		}

		internal override CSVisualObject GetCSVisual()
		{
			return this.canvasEntity;
		}

		public override IEnumerable<VisualObject> GetVisualChildren()
		{
			return this.Children;
		}

		private void ChildrenList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				int num = e.NewStartingIndex;
				foreach (object current in e.NewItems)
				{
					NodeObject nodeObject = current as NodeObject;
					this.GetCSVisual().InsertChild(num, nodeObject.GetCSVisual());
					num++;
					nodeObject.BindingRecorder(null);
					nodeObject.AncestorObjectChanged(nodeObject, NotifyCollectionChangedAction.Add);
					nodeObject.IsHitTestVisible = false;
					NodeObject expr_6D = nodeObject;
					OperationMask arg_73_0 = expr_6D.OperationFlag;
					expr_6D.OperationFlag = OperationMask.NoneFlag;
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (object current in e.OldItems)
				{
					NodeObject nodeObject = current as NodeObject;
					nodeObject.AncestorObjectChanged(nodeObject, NotifyCollectionChangedAction.Remove);
					this.GetCSVisual().RemoveChild(nodeObject.GetCSVisual());
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgsExtend args)
		{
			if (base.lastClickPoint != null)
			{
				PointF pointF = this.canvasEntity.TransformToParent(args.Point);
				float x = this.Position.X + pointF.X - base.lastClickPoint.X;
				float y = this.Position.Y + pointF.Y - base.lastClickPoint.Y;
				this.Position = new PointF(x, y);
				base.lastClickPoint = pointF;
				args.Handled = true;
			}
		}

		protected override void OnDragEnter(DragMotionArgs e)
		{
			this.CurrentNodeObject.DragEnter(e);
		}

		protected override bool OnDragOver(DragMotionArgs e)
		{
			return this.CurrentNodeObject.DragOver(e);
		}

		protected override void OnDragLeave(DragMotionArgs e)
		{
			e.SetAllowDragAction((DragAction)0);
		}

		protected override void OnDragDrop(DragDropArgs e)
		{
			this.CurrentNodeObject.DragDrop(e);
		}

		public bool CheckScaleValue(ScaleValue scale)
		{
			return scale.ScaleX >= 0.1f && scale.ScaleY >= 0.1f && scale.ScaleX <= 4f && scale.ScaleY <= 4f;
		}

		public ScaleValue CheckScaleValueAndGetNearestValue(float delta)
		{
			ScaleValue scaleValue = new ScaleValue(this.Scale.ScaleX + delta, this.Scale.ScaleY + delta, 0.1, -99999999.0, 99999999.0);
			ScaleValue result;
			if (this.CheckScaleValue(scaleValue))
			{
				result = scaleValue;
			}
			else if (delta > 0f && this.CanZoom())
			{
				scaleValue.ScaleX = (scaleValue.ScaleY = 4f);
				result = scaleValue;
			}
			else if (delta < 0f && this.CanDecreaseZoom())
			{
				scaleValue.ScaleX = (scaleValue.ScaleY = 0.1f);
				result = scaleValue;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public bool CanZoom()
		{
			return this.Scale.ScaleX < 4f && this.Scale.ScaleY < 4f;
		}

		public bool CanDecreaseZoom()
		{
			return this.Scale.ScaleX > 0.1f && this.Scale.ScaleY > 0.1f;
		}

		private void RaiseCanvasSizeChangeEvent(Size newSize)
		{
			CanvasSizeChangeEvent @event = EventAggregator.Instance.GetEvent<CanvasSizeChangeEvent>();
			@event.Unsubscribe(new Action<CanvasSizeChangeEventArgs>(this.CanvasSizeChangeEventHandle));
			@event.Publish(new CanvasSizeChangeEventArgs(string.Empty, newSize));
			@event.Subscribe(new Action<CanvasSizeChangeEventArgs>(this.CanvasSizeChangeEventHandle));
		}

		private void CanvasSizeChangeEventHandle(CanvasSizeChangeEventArgs args)
		{
			this.sceneSize = args.NewSize;
			Project currentSelectedProject = Services.ProjectOperations.CurrentSelectedProject;
			if (currentSelectedProject != null && currentSelectedProject.GetProjectType() != NodeType.Node.ToString())
			{
				this.Size = new PointF((float)args.NewSize.Width, (float)args.NewSize.Height);
			}
		}

		public void ResetCanvas(bool isClean = true)
		{
			for (int i = this.Children.Count - 1; i >= 0; i--)
			{
				this.Children.RemoveAt(i);
			}
			this.SetSceneSize(CanvasSizes.SizeList.First<string>().ConvertToSize(), true);
		}

		public void SetLayerColorVisible(bool visible)
		{
			this.canvasEntity.SetLayerColorVisible(visible);
		}

		public void SetCenterLineVisible(bool visible)
		{
			this.canvasEntity.SetCenterLineVisible(visible);
		}
	}
}
