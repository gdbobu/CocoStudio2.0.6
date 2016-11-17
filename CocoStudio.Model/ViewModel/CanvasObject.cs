// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.CanvasObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_Canvas")]
  public class CanvasObject : VisualObject
  {
    private Gdk.Size sceneSize = new Gdk.Size(480, 320);
    private ScaleValue scale = new ScaleValue();
    private const float MaxZoom = 4f;
    private const float MinZoom = 0.1f;
    public const float DeltaZoom = 0.1f;
    private CSCanvas canvasEntity;

    [Browsable(false)]
    [UndoProperty]
    public ObservableCollection<NodeObject> Children { get; set; }

    [Category("Group_Routine")]
    public override PointF Size
    {
      get
      {
        Gdk.Size canvasSize = this.canvasEntity.GetCanvasSize();
        return new PointF((float) canvasSize.Width, (float) canvasSize.Height);
      }
      set
      {
        this.canvasEntity.SetCanvasSize(new Gdk.Size((int) value.X, (int) value.Y));
        this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
      }
    }

    [Browsable(false)]
    [System.ComponentModel.Editor(typeof (ScaleEditor), typeof (ScaleEditor))]
    [DisplayName("Display_Scale")]
    [Category("Group_Routine")]
    public override ScaleValue Scale
    {
      get
      {
        return this.canvasEntity.GetScale();
      }
      set
      {
        if (!this.CheckScaleValue(value) || this.scale.Equals((object) value))
          return;
        this.scale = value;
        this.canvasEntity.SetScale(this.scale);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.Scale));
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
        this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Position), false);
      }
    }

    [Browsable(false)]
    public override float Rotation { get; set; }

    [Browsable(false)]
    public override int ZOrder { get; set; }

    [Browsable(false)]
    private NodeObject CurrentNodeObject
    {
      get
      {
        return Services.ProjectOperations.CurrentSelectedProject.GetRootNode();
      }
    }

    internal CanvasObject(CSCanvas canvasEntity)
    {
      this.canvasEntity = canvasEntity;
      this.CanEdit = false;
      this.IsSelected = false;
      this.SetSceneSize(Services.ProjectOperations.CurrentSelectedSolution.GetSceneSize(), true);
      this.BindingRecorder((string) null);
      this.Children = new ObservableCollection<NodeObject>();
      this.Children.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ChildrenList_CollectionChanged);
    }

    public Gdk.Size GetSceneSize()
    {
      return this.sceneSize;
    }

    public void SetSceneSize(Gdk.Size value, bool refreshSize = true)
    {
      this.sceneSize = value;
      if (!refreshSize)
        return;
      this.Size = new PointF((float) value.Width, (float) value.Height);
      this.RaiseCanvasSizeChangeEvent(value);
    }

    internal override CSVisualObject GetCSVisual()
    {
      return (CSVisualObject) this.canvasEntity;
    }

    public override IEnumerable<VisualObject> GetVisualChildren()
    {
      return (IEnumerable<VisualObject>) this.Children;
    }

    private void ChildrenList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        int newStartingIndex = e.NewStartingIndex;
        foreach (object newItem in (IEnumerable) e.NewItems)
        {
          NodeObject nodeObject1 = newItem as NodeObject;
          this.GetCSVisual().InsertChild(newStartingIndex, nodeObject1.GetCSVisual());
          ++newStartingIndex;
          nodeObject1.BindingRecorder((string) null);
          nodeObject1.AncestorObjectChanged((BaseObject) nodeObject1, NotifyCollectionChangedAction.Add);
          nodeObject1.IsHitTestVisible = false;
          NodeObject nodeObject2 = nodeObject1;
          int operationFlag = (int) nodeObject2.OperationFlag;
          int num = 0;
          nodeObject2.OperationFlag = (OperationMask) num;
        }
      }
      else
      {
        if (e.Action != NotifyCollectionChangedAction.Remove)
          return;
        foreach (object oldItem in (IEnumerable) e.OldItems)
        {
          NodeObject nodeObject = oldItem as NodeObject;
          nodeObject.AncestorObjectChanged((BaseObject) nodeObject, NotifyCollectionChangedAction.Remove);
          this.GetCSVisual().RemoveChild(nodeObject.GetCSVisual());
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgsExtend args)
    {
      if (this.lastClickPoint == null)
        return;
      PointF parent = this.canvasEntity.TransformToParent(args.Point);
      this.Position = new PointF(this.Position.X + parent.X - this.lastClickPoint.X, this.Position.Y + parent.Y - this.lastClickPoint.Y);
      this.lastClickPoint = parent;
      args.Handled = true;
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
      e.SetAllowDragAction((DragAction) 0);
    }

    protected override void OnDragDrop(DragDropArgs e)
    {
      this.CurrentNodeObject.DragDrop(e);
    }

    public bool CheckScaleValue(ScaleValue scale)
    {
      return (double) scale.ScaleX >= 0.100000001490116 && (double) scale.ScaleY >= 0.100000001490116 && (double) scale.ScaleX <= 4.0 && (double) scale.ScaleY <= 4.0;
    }

    public ScaleValue CheckScaleValueAndGetNearestValue(float delta)
    {
      ScaleValue scale = new ScaleValue(this.Scale.ScaleX + delta, this.Scale.ScaleY + delta, 0.1, -99999999.0, 99999999.0);
      if (this.CheckScaleValue(scale))
        return scale;
      if ((double) delta > 0.0 && this.CanZoom())
      {
        scale.ScaleX = scale.ScaleY = 4f;
        return scale;
      }
      if ((double) delta >= 0.0 || !this.CanDecreaseZoom())
        return (ScaleValue) null;
      scale.ScaleX = scale.ScaleY = 0.1f;
      return scale;
    }

    public bool CanZoom()
    {
      return (double) this.Scale.ScaleX < 4.0 && (double) this.Scale.ScaleY < 4.0;
    }

    public bool CanDecreaseZoom()
    {
      return (double) this.Scale.ScaleX > 0.100000001490116 && (double) this.Scale.ScaleY > 0.100000001490116;
    }

    private void RaiseCanvasSizeChangeEvent(Gdk.Size newSize)
    {
      CanvasSizeChangeEvent canvasSizeChangeEvent = EventAggregator.Instance.GetEvent<CanvasSizeChangeEvent>();
      canvasSizeChangeEvent.Unsubscribe(new System.Action<CanvasSizeChangeEventArgs>(this.CanvasSizeChangeEventHandle));
      canvasSizeChangeEvent.Publish(new CanvasSizeChangeEventArgs(string.Empty, newSize));
      canvasSizeChangeEvent.Subscribe(new System.Action<CanvasSizeChangeEventArgs>(this.CanvasSizeChangeEventHandle));
    }

    private void CanvasSizeChangeEventHandle(CanvasSizeChangeEventArgs args)
    {
      this.sceneSize = args.NewSize;
      Project currentSelectedProject = Services.ProjectOperations.CurrentSelectedProject;
      if (currentSelectedProject == null || !(currentSelectedProject.GetProjectType() != NodeType.Node.ToString()))
        return;
      Gdk.Size newSize = args.NewSize;
      double width = (double) newSize.Width;
      newSize = args.NewSize;
      double height = (double) newSize.Height;
      this.Size = new PointF((float) width, (float) height);
    }

    public void ResetCanvas(bool isClean = true)
    {
      for (int index = this.Children.Count - 1; index >= 0; --index)
        this.Children.RemoveAt(index);
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
