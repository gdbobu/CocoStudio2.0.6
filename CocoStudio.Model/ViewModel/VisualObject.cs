// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.VisualObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Model.ViewModel.HitTest;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public abstract class VisualObject : ModelObject, IComparable, ICloneable, ITimeline, ITransform
  {
    internal static int tag = 0;
    private bool isTransformEnabled = true;
    private bool m_bEdit = true;
    private bool _isSelected = false;
    private bool uniformScale = false;
    private ObservableCollection<Frame> frames = new ObservableCollection<Frame>();
    private ObservableCollection<Timeline> timelines = new ObservableCollection<Timeline>();
    private CocoStudio.Model.PointF lastclickpoint;

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

    public bool IsHitTestVisible { get; set; }

    public bool IsTransformEnabled
    {
      get
      {
        return this.isTransformEnabled;
      }
      set
      {
        this.isTransformEnabled = value;
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsTransformEnabled));
      }
    }

    public virtual OperationMask OperationFlag { get; set; }

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
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.CanEdit));
      }
    }

    public virtual bool IsExpanded { get; set; }

    public virtual bool IsSelected
    {
      get
      {
        return this._isSelected;
      }
      set
      {
        this._isSelected = value;
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsSelected));
      }
    }

    public virtual int ActionTag { get; set; }

    public virtual int OrderOfArrival
    {
      get
      {
        return this.GetCSVisual().GetOrderOfArrival();
      }
    }

    [UndoProperty]
    [PropertyOrder(0)]
    [DisplayName("Display_Visible")]
    [Category("Group_Routine")]
    [Browsable(false)]
    public virtual bool Visible
    {
      get
      {
        return this.GetCSVisual().GetVisible();
      }
      set
      {
        this.GetCSVisual().SetVisible(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.Visible));
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
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetPosition(value);
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Position));
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.RelativePosition));
      }
    }

    [PropertyOrder(6)]
    [System.ComponentModel.Editor(typeof (PositionEditor), typeof (PositionEditor))]
    [DisplayName("Display_Position")]
    [Category("Group_Routine")]
    [Browsable(true)]
    public virtual CocoStudio.Model.PointF RelativePosition
    {
      get
      {
        return this.GetCSVisual().GetRelativePosition();
      }
      set
      {
        this.GetCSVisual().SetRelativePosition(value);
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Position));
      }
    }

    [Browsable(true)]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (AnchorPointEditor), typeof (AnchorPointEditor))]
    [Category("Group_Routine")]
    [PropertyOrder(7)]
    [DisplayName("Display_AnchorPoint")]
    public virtual ScaleValue AnchorPoint
    {
      get
      {
        return this.GetCSVisual().GetAnchorPoint();
      }
      set
      {
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetAnchorPoint(value);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.AnchorPoint));
      }
    }

    [Category("Group_Routine")]
    [System.ComponentModel.Editor(typeof (ScaleEditor), typeof (ScaleEditor))]
    [DisplayName("Display_Scale")]
    [PropertyOrder(8)]
    [UndoProperty]
    [Browsable(true)]
    public virtual ScaleValue Scale
    {
      get
      {
        return this.GetCSVisual().GetScale();
      }
      set
      {
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetScale(value);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.Scale));
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
        if (!this.IsTransformEnabled)
          return;
        this.uniformScale = value;
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.UniformScale));
      }
    }

    [System.ComponentModel.Editor(typeof (RotationEditor), typeof (RotationEditor))]
    [DefaultValue(0.0f)]
    [Category("Group_Routine")]
    [Browsable(true)]
    [PropertyOrder(9)]
    [DisplayName("Display_Rotation")]
    public virtual float Rotation
    {
      get
      {
        return this.GetCSVisual().GetRotationSkewX();
      }
      set
      {
        float num = value - this.Rotation;
        this.RotationSkew = new ScaleValue(value, this.RotationSkew.ScaleY + num, 0.1, -99999999.0, 99999999.0);
      }
    }

    [DefaultValue(0.0f)]
    [System.ComponentModel.Editor(typeof (SkewEditor), typeof (SkewEditor))]
    [DisplayName("Display_RotationSkew")]
    [Category("Group_Routine")]
    [PropertyOrder(10)]
    [Browsable(true)]
    [UndoProperty]
    public virtual ScaleValue RotationSkew
    {
      get
      {
        return new ScaleValue(this.GetCSVisual().GetRotationSkewX(), this.GetCSVisual().GetRotationSkewY(), 0.1, -99999999.0, 99999999.0);
      }
      set
      {
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetRotationSkewX(value.ScaleX);
        this.GetCSVisual().SetRotationSkewY(value.ScaleY);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.RotationSkew));
        this.RaisePropertyChanged<float>((Expression<Func<float>>) (() => this.Rotation));
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
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetRotationSkewX(value);
        this.RaisePropertyChanged<float>((Expression<Func<float>>) (() => this.Rotation));
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.RotationSkew));
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
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetRotationSkewY(value);
        this.RaisePropertyChanged<float>((Expression<Func<float>>) (() => this.Rotation));
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.RotationSkew));
      }
    }

    [Browsable(true)]
    [DisplayName("Display_Capacity")]
    [System.ComponentModel.Editor(typeof (SliderEditor), typeof (SliderEditor))]
    [PropertyOrder(11)]
    [Category("Group_Routine")]
    [UndoProperty]
    [ValueRange(0, 255, 1.0)]
    public virtual int Alpha
    {
      get
      {
        return this.GetCSVisual().GetAlpha();
      }
      set
      {
        if (this.GetCSVisual().GetAlpha() == value)
          return;
        this.GetCSVisual().SetAlpha(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Alpha));
      }
    }

    [DisplayName("Display_ColorBlend")]
    [Browsable(true)]
    [PropertyOrder(12)]
    [System.ComponentModel.Editor(typeof (ColorsEditor), typeof (ColorsEditor))]
    [UndoProperty]
    [Category("Group_Routine")]
    public virtual System.Drawing.Color CColor
    {
      get
      {
        return this.GetCSVisual().GetColor();
      }
      set
      {
        this.GetCSVisual().SetColor(value);
        this.RaisePropertyChanged<System.Drawing.Color>((Expression<Func<System.Drawing.Color>>) (() => this.CColor));
      }
    }

    [UndoProperty]
    [DefaultValue(1)]
    [PropertyOrder(12)]
    [Browsable(false)]
    [DisplayName("Display_RenderLevel")]
    [Category("Group_Routine")]
    public virtual int ZOrder
    {
      get
      {
        return this.GetCSVisual().GetZOrder();
      }
      set
      {
        this.GetCSVisual().SetZOrder(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.ZOrder));
      }
    }

    [Browsable(true)]
    [DisplayName("Display_Visible")]
    [Category("Group_Routine")]
    [UndoProperty]
    [PropertyOrder(1)]
    public virtual bool VisibleForFrame
    {
      get
      {
        return this.GetCSVisual().GetVisibleForFrame();
      }
      set
      {
        this.GetCSVisual().SetVisibleForFrame(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.VisibleForFrame));
      }
    }

    [DisplayName("Display_FrameEvents")]
    [Browsable(true)]
    [PropertyOrder(101)]
    [UndoProperty]
    [Category("Frame_Feature")]
    public virtual string FrameEvent
    {
      get
      {
        return this.GetCSVisual().GetFrameEvent();
      }
      set
      {
        this.GetCSVisual().SetFrameEvent(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.FrameEvent));
      }
    }

    [UndoProperty]
    [Category("grid_sudoku")]
    [PropertyOrder(16)]
    [Browsable(true)]
    [DisplayName("grid_sudoku_size")]
    [System.ComponentModel.Editor(typeof (UIControlSizeEditor), typeof (UIControlSizeEditor))]
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
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
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
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsAutoSize));
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
      CocoStudio.Model.PointF pointF = new CocoStudio.Model.PointF(0.0f, 0.0f);
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
      if ((double) pointF.X == 0.0 && (double) pointF.Y == 0.0)
        return (CocoStudio.Model.PointF) null;
      return pointF;
    }

    internal virtual CSVisualObject GetCSVisual()
    {
      throw new NotImplementedException();
    }

    public virtual object Clone()
    {
      return (object) null;
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
      if (!this.OperationFlag.HasFlag((Enum) OperationMask.MoveFlag) || this.lastClickPoint == null)
        return;
      this.OnMouseMove(args);
      this.lastClickPoint = args.Point;
    }

    public void MouseUp(MouseEventArgsExtend args)
    {
      if (this.lastClickPoint == null)
        return;
      this.OnMouseUp(args);
      this.lastClickPoint = (CocoStudio.Model.PointF) null;
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
      if (vectorByKey == null)
        return;
      this.Position = new CocoStudio.Model.PointF(this.Position.X + vectorByKey.X, this.Position.Y + vectorByKey.Y);
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
      if (!this.IsHitTestVisible || !this.Visible || !this.VisibleForFrame || !this.CanEdit)
        return new HitTestResult(point, this.Visible);
      return this.HitTestCore(point);
    }

    protected virtual HitTestResult HitTestCore(CocoStudio.Model.PointF point)
    {
      if (this.GetCSVisual().HitTest(point) != -1)
        return new HitTestResult(this, point, OperationType.OPERATION_POSITION, ControlPointType.POINT_NONE);
      return new HitTestResult(point, this.CanContinueTest());
    }

    public virtual RectTestResult RectTest(Gdk.Rectangle rect)
    {
      if (!this.IsHitTestVisible || !this.Visible || !this.VisibleForFrame || !this.CanEdit)
        return new RectTestResult(rect, this.Visible);
      return this.RectTestCore(rect);
    }

    protected virtual RectTestResult RectTestCore(Gdk.Rectangle rect)
    {
      if (this.GetCSVisual().RectTest(rect))
        return new RectTestResult(this, rect, this.CanContinueTest());
      return new RectTestResult(rect, this.CanContinueTest());
    }

    protected virtual bool CanContinueTest()
    {
      return this.Visible;
    }

    public virtual IEnumerable<VisualObject> GetVisualChildren()
    {
      return (IEnumerable<VisualObject>) null;
    }

    public virtual int CompareTo(object other)
    {
      VisualObject visualObject = other as VisualObject;
      if (this.ZOrder > visualObject.ZOrder)
        return -1;
      if (this.ZOrder < visualObject.ZOrder)
        return 1;
      if (this.OrderOfArrival > visualObject.OrderOfArrival)
        return -1;
      return this.OrderOfArrival < visualObject.OrderOfArrival ? 1 : 0;
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
