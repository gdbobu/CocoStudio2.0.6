using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Model.ViewModel.HitTest;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	public abstract class VisualObject : ModelObject, IComparable, ICloneable, ITimeline, ITransform
	{
		private CocoStudio.Model.PointF lastclickpoint;

		internal static int tag = 0;

		private bool isTransformEnabled = true;

		private bool m_bEdit = true;

		private bool _isSelected = false;

		private bool uniformScale = false;

		private ObservableCollection<Frame> frames = new ObservableCollection<Frame>();

		private ObservableCollection<Timeline> timelines = new ObservableCollection<Timeline>();

		protected CocoStudio.Model.PointF lastClickPoint
		{
			get
			{
				return this.lastclickpoint;
			}
			set
			{
				this.lastclickpoint = value;
			}
		}

		public bool IsHitTestVisible
		{
			get;
			set;
		}

		public bool IsTransformEnabled
		{
			get
			{
				return this.isTransformEnabled;
			}
			set
			{
				this.isTransformEnabled = value;
				this.RaisePropertyChanged<bool>(() => this.IsTransformEnabled);
			}
		}

		public virtual OperationMask OperationFlag
		{
			get;
			set;
		}

		[UndoProperty]
		public virtual bool CanEdit
		{
			get
			{
				return this.m_bEdit;
			}
			set
			{
				this.m_bEdit = value;
				this.RaisePropertyChanged<bool>(() => this.CanEdit);
			}
		}

		public virtual bool IsExpanded
		{
			get;
			set;
		}

		public virtual bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				this._isSelected = value;
				this.RaisePropertyChanged<bool>(() => this.IsSelected);
			}
		}

		public virtual int ActionTag
		{
			get;
			set;
		}

		public virtual int OrderOfArrival
		{
			get
			{
				return this.GetCSVisual().GetOrderOfArrival();
			}
		}

		[PropertyOrder(0), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_Visible")]
		public virtual bool Visible
		{
			get
			{
				return this.GetCSVisual().GetVisible();
			}
			set
			{
				this.GetCSVisual().SetVisible(value);
				this.RaisePropertyChanged<bool>(() => this.Visible);
			}
		}

		[UndoProperty]
		public virtual CocoStudio.Model.PointF Position
		{
			get
			{
				return this.GetCSVisual().GetPosition();
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetPosition(value);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Position);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.RelativePosition);
				}
			}
		}

		[PropertyOrder(6), Browsable(true), Category("Group_Routine"), DisplayName("Display_Position"), Editor(typeof(PositionEditor), typeof(PositionEditor))]
		public virtual CocoStudio.Model.PointF RelativePosition
		{
			get
			{
				return this.GetCSVisual().GetRelativePosition();
			}
			set
			{
				this.GetCSVisual().SetRelativePosition(value);
				this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Position);
			}
		}

		[PropertyOrder(7), UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_AnchorPoint"), Editor(typeof(AnchorPointEditor), typeof(AnchorPointEditor))]
		public virtual ScaleValue AnchorPoint
		{
			get
			{
				return this.GetCSVisual().GetAnchorPoint();
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetAnchorPoint(value);
					this.RaisePropertyChanged<ScaleValue>(() => this.AnchorPoint);
				}
			}
		}

		[PropertyOrder(8), UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_Scale"), Editor(typeof(ScaleEditor), typeof(ScaleEditor))]
		public virtual ScaleValue Scale
		{
			get
			{
				return this.GetCSVisual().GetScale();
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetScale(value);
					this.RaisePropertyChanged<ScaleValue>(() => this.Scale);
				}
			}
		}

		[UndoProperty]
		public virtual bool UniformScale
		{
			get
			{
				return this.uniformScale;
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.uniformScale = value;
					this.RaisePropertyChanged<bool>(() => this.UniformScale);
				}
			}
		}

		[PropertyOrder(9), Browsable(true), Category("Group_Routine"), DefaultValue(0f), DisplayName("Display_Rotation"), Editor(typeof(RotationEditor), typeof(RotationEditor))]
		public virtual float Rotation
		{
			get
			{
				return this.GetCSVisual().GetRotationSkewX();
			}
			set
			{
				float num = value - this.Rotation;
				float scaleY = this.RotationSkew.ScaleY + num;
				this.RotationSkew = new ScaleValue(value, scaleY, 0.1, -99999999.0, 99999999.0);
			}
		}

		[PropertyOrder(10), UndoProperty, Browsable(true), Category("Group_Routine"), DefaultValue(0f), DisplayName("Display_RotationSkew"), Editor(typeof(SkewEditor), typeof(SkewEditor))]
		public virtual ScaleValue RotationSkew
		{
			get
			{
				return new ScaleValue(this.GetCSVisual().GetRotationSkewX(), this.GetCSVisual().GetRotationSkewY(), 0.1, -99999999.0, 99999999.0);
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetRotationSkewX(value.ScaleX);
					this.GetCSVisual().SetRotationSkewY(value.ScaleY);
					this.RaisePropertyChanged<ScaleValue>(() => this.RotationSkew);
					this.RaisePropertyChanged<float>(() => this.Rotation);
				}
			}
		}

		public virtual float RotationSkewX
		{
			get
			{
				return this.GetCSVisual().GetRotationSkewX();
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetRotationSkewX(value);
					this.RaisePropertyChanged<float>(() => this.Rotation);
					this.RaisePropertyChanged<ScaleValue>(() => this.RotationSkew);
				}
			}
		}

		public virtual float RotationSkewY
		{
			get
			{
				return this.GetCSVisual().GetRotationSkewY();
			}
			set
			{
				if (this.IsTransformEnabled)
				{
					this.GetCSVisual().SetRotationSkewY(value);
					this.RaisePropertyChanged<float>(() => this.Rotation);
					this.RaisePropertyChanged<ScaleValue>(() => this.RotationSkew);
				}
			}
		}

		[PropertyOrder(11), ValueRange(0, 255, 1.0), UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_Capacity"), Editor(typeof(SliderEditor), typeof(SliderEditor))]
		public virtual int Alpha
		{
			get
			{
				return this.GetCSVisual().GetAlpha();
			}
			set
			{
				if (this.GetCSVisual().GetAlpha() != value)
				{
					this.GetCSVisual().SetAlpha(value);
					this.RaisePropertyChanged<int>(() => this.Alpha);
				}
			}
		}

		[PropertyOrder(12), UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_ColorBlend"), Editor(typeof(ColorsEditor), typeof(ColorsEditor))]
		public virtual System.Drawing.Color CColor
		{
			get
			{
				return this.GetCSVisual().GetColor();
			}
			set
			{
				this.GetCSVisual().SetColor(value);
				this.RaisePropertyChanged<System.Drawing.Color>(() => this.CColor);
			}
		}

		[PropertyOrder(12), UndoProperty, Browsable(false), Category("Group_Routine"), DefaultValue(1), DisplayName("Display_RenderLevel")]
		public virtual int ZOrder
		{
			get
			{
				return this.GetCSVisual().GetZOrder();
			}
			set
			{
				this.GetCSVisual().SetZOrder(value);
				this.RaisePropertyChanged<int>(() => this.ZOrder);
			}
		}

		[PropertyOrder(1), UndoProperty, Browsable(true), Category("Group_Routine"), DisplayName("Display_Visible")]
		public virtual bool VisibleForFrame
		{
			get
			{
				return this.GetCSVisual().GetVisibleForFrame();
			}
			set
			{
				this.GetCSVisual().SetVisibleForFrame(value);
				this.RaisePropertyChanged<bool>(() => this.VisibleForFrame);
			}
		}

		[PropertyOrder(101), UndoProperty, Browsable(true), Category("Frame_Feature"), DisplayName("Display_FrameEvents")]
		public virtual string FrameEvent
		{
			get
			{
				return this.GetCSVisual().GetFrameEvent();
			}
			set
			{
				this.GetCSVisual().SetFrameEvent(value);
				this.RaisePropertyChanged<string>(() => this.FrameEvent);
			}
		}

		[PropertyOrder(16), UndoProperty, Browsable(true), Category("grid_sudoku"), DisplayName("grid_sudoku_size"), Editor(typeof(UIControlSizeEditor), typeof(UIControlSizeEditor))]
		public virtual CocoStudio.Model.PointF Size
		{
			get
			{
				return this.GetCSVisual().GetSize();
			}
			set
			{
				this.GetCSVisual().SetSize(value);
				this.RefreshBoundingBox(false);
				this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
			}
		}

		[UndoProperty]
		public virtual bool IsAutoSize
		{
			get
			{
				return this.GetCSVisual().IsAutoSize();
			}
			set
			{
				this.GetCSVisual().SetAutoSize(value);
				this.RaisePropertyChanged<bool>(() => this.IsAutoSize);
			}
		}

		public ObservableCollection<Frame> Frames
		{
			get
			{
				return this.frames;
			}
		}

		public ObservableCollection<Timeline> Timelines
		{
			get
			{
				return this.timelines;
			}
		}

		public VisualObject()
		{
			this.CanEdit = true;
			this.OperationFlag = OperationMask.AllFlag;
			this.IsHitTestVisible = true;
			this.ActionTag = ActionTagManager.CreateObjectActionTag();
		}

		protected CocoStudio.Model.PointF GetVectorByKey(Gdk.Key key)
		{
			CocoStudio.Model.PointF pointF = new CocoStudio.Model.PointF(0f, 0f);
			switch (key)
			{
			case Gdk.Key.Left:
				pointF.X = -1f;
				break;
			case Gdk.Key.Up:
				pointF.Y = 1f;
				break;
			case Gdk.Key.Right:
				pointF.X = 1f;
				break;
			case Gdk.Key.Down:
				pointF.Y = -1f;
				break;
			}
			CocoStudio.Model.PointF result;
			if (pointF.X == 0f && pointF.Y == 0f)
			{
				result = null;
			}
			else
			{
				result = pointF;
			}
			return result;
		}

		internal virtual CSVisualObject GetCSVisual()
		{
			throw new NotImplementedException();
		}

		public virtual object Clone()
		{
			return null;
		}

		public virtual CocoStudio.Model.PointF GetBoundingSize()
		{
			return this.GetCSVisual().GetBoundingSize();
		}

		public virtual ScaleValue GetBoundingAnchorPoint()
		{
			CocoStudio.Model.PointF boundingAnchorPoint = this.GetCSVisual().GetBoundingAnchorPoint();
			return new ScaleValue(boundingAnchorPoint.X, boundingAnchorPoint.Y, 0.1, -99999999.0, 99999999.0);
		}

		internal virtual void RefreshBoundingBox(bool bRefresh = false)
		{
		}

		public void MouseDown(MouseEventArgsExtend args)
		{
			this.lastClickPoint = args.Point;
			this.OnMouseDown(args);
		}

		public void MouseMove(MouseEventArgsExtend args)
		{
			if (this.OperationFlag.HasFlag(OperationMask.MoveFlag) && this.lastClickPoint != null)
			{
				this.OnMouseMove(args);
				this.lastClickPoint = args.Point;
			}
		}

		public void MouseUp(MouseEventArgsExtend args)
		{
			if (this.lastClickPoint != null)
			{
				this.OnMouseUp(args);
				this.lastClickPoint = null;
			}
		}

		public void MouseDoubleClick(MouseEventArgsExtend args)
		{
			this.OnMouseDoubleClick(args);
		}

		public void KeyDown(KeyPressEventArgs e)
		{
			this.OnKeyDown(e);
		}

		public void KeyUp(KeyReleaseEventArgs e)
		{
			this.OnKeyUp(e);
		}

		public bool DragOver(DragMotionArgs e)
		{
			return this.OnDragOver(e);
		}

		public void DragLeave(DragMotionArgs e)
		{
			this.OnDragLeave(e);
		}

		public void DragEnter(DragMotionArgs e)
		{
			this.OnDragEnter(e);
		}

		public void DragDrop(DragDropArgs e)
		{
			this.OnDragDrop(e);
		}

		protected virtual void OnMouseDown(MouseEventArgsExtend args)
		{
		}

		protected virtual void OnMouseMove(MouseEventArgsExtend args)
		{
		}

		protected virtual void OnMouseUp(MouseEventArgsExtend args)
		{
		}

		protected virtual void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
		}

		protected virtual void OnKeyDown(KeyPressEventArgs e)
		{
			CocoStudio.Model.PointF vectorByKey = this.GetVectorByKey(e.Event.Key);
			if (vectorByKey != null)
			{
				this.Position = new CocoStudio.Model.PointF(this.Position.X + vectorByKey.X, this.Position.Y + vectorByKey.Y);
			}
		}

		protected virtual void OnKeyUp(KeyReleaseEventArgs e)
		{
		}

		protected virtual bool OnDragOver(DragMotionArgs e)
		{
			return true;
		}

		protected virtual void OnDragLeave(DragMotionArgs e)
		{
		}

		protected virtual void OnDragEnter(DragMotionArgs e)
		{
		}

		protected virtual void OnDragDrop(DragDropArgs e)
		{
		}

		public virtual HitTestResult HitTest(CocoStudio.Model.PointF point)
		{
			HitTestResult result;
			if (!this.IsHitTestVisible || !this.Visible || !this.VisibleForFrame || !this.CanEdit)
			{
				result = new HitTestResult(point, this.Visible);
			}
			else
			{
				result = this.HitTestCore(point);
			}
			return result;
		}

		protected virtual HitTestResult HitTestCore(CocoStudio.Model.PointF point)
		{
			int num = this.GetCSVisual().HitTest(point);
			HitTestResult result;
			if (num != -1)
			{
				result = new HitTestResult(this, point, OperationType.OPERATION_POSITION, ControlPointType.POINT_NONE);
			}
			else
			{
				result = new HitTestResult(point, this.CanContinueTest());
			}
			return result;
		}

		public virtual RectTestResult RectTest(Gdk.Rectangle rect)
		{
			RectTestResult result;
			if (!this.IsHitTestVisible || !this.Visible || !this.VisibleForFrame || !this.CanEdit)
			{
				result = new RectTestResult(rect, this.Visible);
			}
			else
			{
				result = this.RectTestCore(rect);
			}
			return result;
		}

		protected virtual RectTestResult RectTestCore(Gdk.Rectangle rect)
		{
			RectTestResult result;
			if (this.GetCSVisual().RectTest(rect))
			{
				result = new RectTestResult(this, rect, this.CanContinueTest());
			}
			else
			{
				result = new RectTestResult(rect, this.CanContinueTest());
			}
			return result;
		}

		protected virtual bool CanContinueTest()
		{
			return this.Visible;
		}

		public virtual IEnumerable<VisualObject> GetVisualChildren()
		{
			return null;
		}

		public virtual int CompareTo(object other)
		{
			VisualObject visualObject = other as VisualObject;
			int result;
			if (this.ZOrder > visualObject.ZOrder)
			{
				result = -1;
			}
			else if (this.ZOrder < visualObject.ZOrder)
			{
				result = 1;
			}
			else if (this.OrderOfArrival > visualObject.OrderOfArrival)
			{
				result = -1;
			}
			else if (this.OrderOfArrival < visualObject.OrderOfArrival)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public virtual CocoStudio.Model.PointF TransformToSelf(CocoStudio.Model.PointF sencePoint)
		{
			return this.GetCSVisual().TransformToSelf(sencePoint);
		}

		public virtual CocoStudio.Model.PointF TransformToSence(CocoStudio.Model.PointF selfPoint)
		{
			return this.GetCSVisual().TransformToScene(selfPoint);
		}

		public virtual CocoStudio.Model.PointF TransformToParent(CocoStudio.Model.PointF selfPoint)
		{
			return this.GetCSVisual().TransformToParent(selfPoint);
		}
	}
}
