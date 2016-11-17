// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ListViewObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Lib.Prism;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Event;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_UIListview")]
  [ModelExtension(true, 52)]
  [Catagory("Control_ContainerControl", 1, 0)]
  public class ListViewObject : PanelObject, IListViewType
  {
    private ListViewHorizontal horizontalType = ListViewHorizontal.Align_Left;
    private ListViewVertical verticalType = ListViewVertical.Align_Top;

    [UndoProperty]
    [PropertyOrder(20)]
    [Description("Display_OpenResilience")]
    [DisplayName("Display_OpenResilience")]
    [Category("Group_Feature")]
    public bool IsBounceEnabled
    {
      get
      {
        return this.GetInnerWidget().GetBounceEnabled();
      }
      set
      {
        if (this.GetInnerWidget().GetBounceEnabled() == value)
          return;
        this.GetInnerWidget().SetBounceEnabled(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsBounceEnabled));
      }
    }

    [UndoProperty]
    [Browsable(true)]
    [ValueRange(-10000, 10000, 1.0)]
    [DisplayName("Category_Component_Children_Interval")]
    [Category("Group_Feature")]
    [PropertyOrder(22)]
    public int ItemMargin
    {
      get
      {
        return this.GetInnerWidget().GetItemSpace();
      }
      set
      {
        if (this.GetInnerWidget().GetItemSpace() == value)
          return;
        this.GetInnerWidget().SetItemSpace(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.ItemMargin));
      }
    }

    [PropertyOrder(22)]
    [UndoProperty]
    [DisplayName("Display_Component_Layout")]
    [Category("Group_Feature")]
    [Browsable(true)]
    [System.ComponentModel.Editor(typeof (UIListViewEditor), typeof (UIListViewEditor))]
    public ListViewDirectionType DirectionType
    {
      get
      {
        return (ListViewDirectionType) this.GetInnerWidget().GetDirectionType();
      }
      set
      {
        this.GetInnerWidget().SetDirectionType((int) value);
        if (value == ListViewDirectionType.Horizontal)
          this.GetInnerWidget().SetGravityType((int) this.verticalType);
        else if (value == ListViewDirectionType.Vertical)
          this.GetInnerWidget().SetGravityType((int) this.horizontalType);
        this.RaisePropertyChanged<ListViewDirectionType>((Expression<Func<ListViewDirectionType>>) (() => this.DirectionType));
      }
    }

    [UndoProperty]
    public ListViewHorizontal HorizontalType
    {
      get
      {
        return this.horizontalType;
      }
      set
      {
        this.horizontalType = value;
        if (this.DirectionType == ListViewDirectionType.Vertical)
          this.GetInnerWidget().SetGravityType((int) value);
        this.RaisePropertyChanged<ListViewHorizontal>((Expression<Func<ListViewHorizontal>>) (() => this.HorizontalType));
      }
    }

    [UndoProperty]
    public ListViewVertical VerticalType
    {
      get
      {
        return this.verticalType;
      }
      set
      {
        this.verticalType = value;
        if (this.DirectionType == ListViewDirectionType.Horizontal)
          this.GetInnerWidget().SetGravityType((int) value);
        this.RaisePropertyChanged<ListViewVertical>((Expression<Func<ListViewVertical>>) (() => this.VerticalType));
      }
    }

    public ListViewObject()
    {
    }

    public ListViewObject(CSListView customWidget)
      : base((CSPanel) customWidget)
    {
    }

    private CSListView GetInnerWidget()
    {
      return (CSListView) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSListView();
    }

    protected override void InitData()
    {
      base.InitData();
      this.SingleColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 150, (int) byte.MaxValue);
      this.FirstColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 150, (int) byte.MaxValue);
      this.EndColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ComboBoxIndex = 1;
      this.DirectionType = ListViewDirectionType.Vertical;
      this.HorizontalType = ListViewHorizontal.Align_Left;
      this.VerticalType = ListViewVertical.Align_Top;
    }

    internal override void RefreshBoundingBox(bool bRefresh = false)
    {
      if (bRefresh)
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size), false);
      this.innerNode.RefreshBoundingObjects();
      foreach (VisualObject child in (Collection<NodeObject>) this.Children)
        child.RefreshBoundingBox(true);
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      ListViewObject listViewObject = cObject as ListViewObject;
      if (listViewObject == null)
        return;
      listViewObject.IsBounceEnabled = this.IsBounceEnabled;
      listViewObject.DirectionType = this.DirectionType;
      listViewObject.HorizontalType = this.HorizontalType;
      listViewObject.VerticalType = this.VerticalType;
      listViewObject.ItemMargin = this.ItemMargin;
    }

    private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == "Size"))
        return;
      foreach (NotificationObject child in (Collection<NodeObject>) this.Children)
        child.PropertyChanged -= new PropertyChangedEventHandler(this.ChildPropertyChanged);
      this.RefreshBoundingBox(false);
      foreach (NotificationObject child in (Collection<NodeObject>) this.Children)
        child.PropertyChanged += new PropertyChangedEventHandler(this.ChildPropertyChanged);
    }

    internal override void InsertChild(int index, NodeObject nObject)
    {
      base.InsertChild(index, nObject);
      nObject.IsTransformEnabled = false;
      nObject.PropertyChanged += new PropertyChangedEventHandler(this.ChildPropertyChanged);
    }

    internal override void RemoveChild(NodeObject nObject)
    {
      base.RemoveChild(nObject);
      nObject.IsTransformEnabled = true;
      nObject.PropertyChanged -= new PropertyChangedEventHandler(this.ChildPropertyChanged);
    }

    protected override bool CanReceiveModelObject(ModelDragData objectData)
    {
      if (!base.CanReceiveModelObject(objectData))
        return false;
      if (typeof (WidgetObject).IsAssignableFrom(objectData.MetaData.Type))
        return true;
      if (this.CanShowMessage)
      {
        LogConfig.Output.Info((object) LanguageInfo.ListViewOutputMessage);
        this.CanShowMessage = false;
      }
      return false;
    }

    protected override bool CanReceiveResourceObject(ResourceInfoDragData objectData)
    {
      if (this.CanShowMessage)
      {
        LogConfig.Output.Info((object) LanguageInfo.ListViewOutputMessage);
        this.CanShowMessage = false;
      }
      return false;
    }

    protected override bool OnDragOver(DragMotionArgs e)
    {
      if (!e.Context.GetDataPresent(typeof (ModelDragData)) || typeof (WidgetObject).IsAssignableFrom((e.Context.GetDragData() as ModelDragData).MetaData.Type))
        return base.OnDragOver(e);
      e.SetAllowDragAction((DragAction) 0);
      return false;
    }

    protected override void OnDragDrop(DragDropArgs e)
    {
      using (CompositeTask.Run("ChangeParent"))
      {
        ModelDragData dragData = e.Context.GetDragData() as ModelDragData;
        if (dragData != null && dragData.MetaData != null)
        {
          if (typeof (WidgetObject).IsAssignableFrom(dragData.MetaData.Type))
          {
            List<VisualObject> visualObjectList = new List<VisualObject>();
            NodeObject nodeObject = dragData.MetaData.CreateObject();
            CocoStudio.Model.PointF scene = SceneTransformHelp.ConvertControlToScene(new CocoStudio.Model.PointF((float) e.X, (float) e.Y));
            nodeObject.Position = this.TransformToSelf(scene);
            this.Children.Add(nodeObject);
            visualObjectList.Add((VisualObject) nodeObject);
            EventAggregator.Instance.GetEvent<SelectedVisualObjectsChangeEvent>().Publish(new SelectedVisualObjectsChangeEventArgs((IEnumerable<VisualObject>) visualObjectList, (IEnumerable<VisualObject>) visualObjectList, false));
          }
          else
            LogConfig.Output.Info((object) LanguageInfo.ListViewOutputMessage);
        }
        this.SetObjectState(CSNode.ObjectState.Default);
      }
    }

    public override bool CanDrop(object node, DropPosition mode, bool copy)
    {
      if (mode != DropPosition.Add || node is WidgetObject)
        return base.CanDrop(node, mode, copy);
      LogConfig.Output.Info((object) LanguageInfo.ListViewOutputMessage);
      return false;
    }
  }
}
