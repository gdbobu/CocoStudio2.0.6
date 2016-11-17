// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PageViewObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_UIPageView")]
  [Catagory("Control_ContainerControl", 1, 0)]
  [ModelExtension(true, 53)]
  public class PageViewObject : PanelObject, ICallBackEvent
  {
    private EnumCallBack callBackType = EnumCallBack.None;
    protected new string callBackName = "";

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

    public PageViewObject()
    {
    }

    public PageViewObject(CSPageView customWidget)
      : base((CSPanel) customWidget)
    {
    }

    private CSPageView GetInnerWidget()
    {
      return (CSPageView) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSPageView();
    }

    protected override void InitData()
    {
      base.InitData();
      this.SingleColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 150, 100);
      this.FirstColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 150, 100);
      this.EndColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ComboBoxIndex = 1;
    }

    internal override void RefreshBoundingBox(bool bRefresh = false)
    {
      if (bRefresh)
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size), false);
      this.innerNode.RefreshBoundingObjects();
      foreach (VisualObject child in (Collection<NodeObject>) this.Children)
        child.RefreshBoundingBox(true);
    }

    internal override void InsertChild(int index, NodeObject nObject)
    {
      base.InsertChild(index, nObject);
      nObject.IsTransformEnabled = false;
    }

    internal override void RemoveChild(NodeObject nObject)
    {
      base.RemoveChild(nObject);
      nObject.IsTransformEnabled = true;
    }

    protected override bool CanReceiveModelObject(ModelDragData objectData)
    {
      if (!base.CanReceiveModelObject(objectData))
        return false;
      if (objectData.MetaData.Type.Equals(typeof (PanelObject)))
        return true;
      LogConfig.Logger.Error((object) LanguageInfo.OutputMessage);
      return false;
    }

    protected override bool OnDragOver(DragMotionArgs e)
    {
      if (!e.Context.GetDataPresent(typeof (ModelDragData)) || !((e.Context.GetDragData() as ModelDragData).MetaData.Type != typeof (PanelObject)))
        return base.OnDragOver(e);
      e.SetAllowDragAction((DragAction) 0);
      return false;
    }

    public override bool CanDrop(object node, DropPosition mode, bool copy)
    {
      if (mode != DropPosition.Add || node.GetType().Equals(typeof (PanelObject)))
        return base.CanDrop(node, mode, copy);
      LogConfig.Logger.Error((object) LanguageInfo.OutputMessage);
      return false;
    }

    protected override void OnDragDrop(DragDropArgs e)
    {
      using (CompositeTask.Run("ChangeParent"))
      {
        ModelDragData dragData = e.Context.GetDragData() as ModelDragData;
        if (dragData != null && dragData.MetaData != null)
        {
          if (dragData.MetaData.Type == typeof (PanelObject))
          {
            NodeObject nodeObject = dragData.MetaData.CreateObject();
            CocoStudio.Model.PointF scene = SceneTransformHelp.ConvertControlToScene(new CocoStudio.Model.PointF((float) e.X, (float) e.Y));
            nodeObject.Position = this.TransformToSelf(scene);
            this.Children.Add(nodeObject);
          }
          else
            LogConfig.Output.Error((object) LanguageInfo.OutputMessage);
        }
        this.SetObjectState(CSNode.ObjectState.Default);
      }
    }
  }
}
