// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ScrollViewObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Model.Visiter;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_ContainerControl", 1, 0)]
  [DisplayName("Display_Component_UIScrollview")]
  [ModelExtension(true, 51)]
  public class ScrollViewObject : PanelObject, ICallBackEvent
  {
    private EnumCallBack callBackType = EnumCallBack.None;
    protected new string callBackName = "";

    [Browsable(true)]
    [PropertyOrder(16)]
    [Category("grid_sudoku")]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (UIControlSizeEditor), typeof (UIControlSizeEditor))]
    [DisplayName("grid_sudoku_size")]
    public override CocoStudio.Model.PointF Size
    {
      get
      {
        return this.GetCSVisual().GetSize();
      }
      set
      {
        this.GetCSVisual().SetSize(value);
        using (CompositeTask.Run("InnerNodeSize"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<SizeValue>((Expression<Func<SizeValue>>) (() => this.InnerNodeSize));
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
        }
      }
    }

    [Browsable(true)]
    [PropertyOrder(19)]
    [System.ComponentModel.Editor(typeof (SizeEditor), typeof (SizeEditor))]
    [DisplayName("Description_ScrollAreaWidth")]
    [UndoProperty]
    [Description("Description_ScrollAreaWidth")]
    [Category("Group_Feature")]
    public virtual SizeValue InnerNodeSize
    {
      get
      {
        Gdk.Size innerSize = this.GetInnerWidget().GetInnerSize();
        int width = innerSize.Width;
        innerSize = this.GetInnerWidget().GetInnerSize();
        int height = innerSize.Height;
        return new SizeValue(width, height);
      }
      set
      {
        if (this.GetInnerWidget().GetInnerSize().Width == value.Width && this.GetInnerWidget().GetInnerSize().Height == value.Height)
          return;
        this.GetInnerWidget().SetInnerSize(new Gdk.Size(value.Width, value.Height));
        this.RaisePropertyChanged<SizeValue>((Expression<Func<SizeValue>>) (() => this.InnerNodeSize));
      }
    }

    [Description("Description_ScrollDirection")]
    [Category("Group_Feature")]
    [PropertyOrder(21)]
    [DisplayName("Description_ScrollDirection")]
    [UndoProperty]
    public virtual ScrollViewDirectionType ScrollDirectionType
    {
      get
      {
        return (ScrollViewDirectionType) this.GetInnerWidget().GetDirectionType();
      }
      set
      {
        this.GetInnerWidget().SetDirectionType((int) value);
        this.RaisePropertyChanged<ScrollViewDirectionType>((Expression<Func<ScrollViewDirectionType>>) (() => this.ScrollDirectionType));
      }
    }

    [DisplayName("Display_OpenResilience")]
    [PropertyOrder(20)]
    [UndoProperty]
    [Category("Group_Feature")]
    [Description("Display_OpenResilience")]
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
    public override EnumCallBack CallBackType
    {
      get
      {
        return this.callBackType;
      }
      set
      {
        this.callBackType = value;
        this.RaisePropertyChanged<EnumCallBack>((Expression<Func<EnumCallBack>>) (() => this.CallBackType));
      }
    }

    [UndoProperty]
    public override string CallBackName
    {
      get
      {
        return this.callBackName;
      }
      set
      {
        this.callBackName = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.CallBackName));
      }
    }

    public ScrollViewObject()
    {
    }

    public ScrollViewObject(CSScrollView customWidget)
      : base((CSPanel) customWidget)
    {
    }

    private CSScrollView GetInnerWidget()
    {
      return (CSScrollView) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSScrollView();
    }

    protected override void InitData()
    {
      base.InitData();
      this.SingleColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 150, 100);
      this.FirstColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 150, 100);
      this.EndColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ComboBoxIndex = 1;
      this.ScrollDirectionType = ScrollViewDirectionType.Vertical;
      this.InnerNodeSize = new SizeValue(200, 300);
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      ScrollViewObject scrollViewObject = cObject as ScrollViewObject;
      if (scrollViewObject == null)
        return;
      scrollViewObject.ScrollDirectionType = this.ScrollDirectionType;
      scrollViewObject.InnerNodeSize = this.InnerNodeSize;
      scrollViewObject.IsBounceEnabled = this.IsBounceEnabled;
    }

    protected virtual CocoStudio.Model.PointF TransFormToInner(CocoStudio.Model.PointF sencePoint)
    {
      return this.GetInnerWidget().TransformToSelfInner(sencePoint);
    }

    protected override void LoadNodeObject(NodeObject gObject, CocoStudio.Model.PointF coord)
    {
      if (gObject == null)
        return;
      CocoStudio.Model.PointF scene = SceneTransformHelp.ConvertControlToScene(coord);
      NodeObject nodeObject;
      CocoStudio.Model.PointF pointF;
      if (this.IsAddToCurrent)
      {
        nodeObject = (NodeObject) this;
        pointF = this.TransFormToInner(scene);
      }
      else
      {
        nodeObject = Services.ProjectOperations.CurrentSelectedProject.GetRootNode();
        pointF = nodeObject.TransformToSelf(scene);
      }
      gObject.Position = pointF;
      nodeObject.Children.Add(gObject);
    }
  }
}
