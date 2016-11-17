// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.SingleNodeObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [ModelExtension(true, 13)]
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_Entity")]
  public class SingleNodeObject : NodeObject, ISingleNode
  {
    private string customClassName;

    [DisplayName("grid_sudoku_size")]
    [Category("grid_sudoku")]
    [System.ComponentModel.Editor(typeof (UIControlSizeEditor), typeof (UIControlSizeEditor))]
    [Browsable(true)]
    [UndoProperty]
    [PropertyOrder(16)]
    public override CocoStudio.Model.PointF Size
    {
      get
      {
        return this.GetCSVisual().GetSize();
      }
      set
      {
        this.GetCSVisual().SetSize(value);
        this.innerNode.RefreshLayout();
        this.RefreshBoundingBox(false);
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
      }
    }

    [UndoProperty]
    [Browsable(false)]
    public override ScaleValue AnchorPoint
    {
      get
      {
        return this.GetCSVisual().GetAnchorPoint();
      }
      set
      {
        this.GetCSVisual().SetAnchorPoint(value);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.AnchorPoint));
      }
    }

    [UndoProperty]
    [Browsable(false)]
    public override int Alpha
    {
      get
      {
        return this.GetCSVisual().GetAlpha();
      }
      set
      {
        this.GetCSVisual().SetAlpha(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Alpha));
      }
    }

    [UndoProperty]
    [Browsable(false)]
    public override Color CColor
    {
      get
      {
        return this.GetCSVisual().GetColor();
      }
      set
      {
        this.GetCSVisual().SetColor(value);
        this.RaisePropertyChanged<Color>((Expression<Func<Color>>) (() => this.CColor));
      }
    }

    [Browsable(true)]
    [UndoProperty]
    public override string CustomClassName
    {
      get
      {
        return this.customClassName;
      }
      set
      {
        this.customClassName = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.CustomClassName));
      }
    }

    public SingleNodeObject()
    {
    }

    public SingleNodeObject(CSNode customWidget)
      : base(customWidget)
    {
    }

    protected override void InitData()
    {
      base.InitData();
      this.Name = "Node_" + (object) this.ObjectIndex;
      this.IsAddToCurrent = false;
      this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
    }

    protected override bool CanReceiveModelObject(ModelDragData objectData)
    {
      return objectData != null && this.Parent == null;
    }
  }
}
