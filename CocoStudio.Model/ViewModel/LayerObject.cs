// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.LayerObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_Entity")]
  public class LayerObject : NodeObject
  {
    private string customClassName;

    [PropertyOrder(2)]
    [Category("Group_Routine")]
    [UndoProperty]
    [DisplayName("Display_CanUse")]
    [DefaultValue(false)]
    public virtual bool TouchEnable
    {
      get
      {
        return this.GetInnerObject().IsTouchEnabled();
      }
      set
      {
        if (this.GetInnerObject().IsTouchEnabled() == value)
          return;
        this.GetInnerObject().SetTouchEnabled(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.TouchEnable));
      }
    }

    [UndoProperty]
    [Browsable(true)]
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

    public LayerObject()
    {
    }

    public LayerObject(CSLayer customWidget)
      : base((CSNode) customWidget)
    {
    }

    private CSLayer GetInnerObject()
    {
      return (CSLayer) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSLayer();
    }

    protected override void InitData()
    {
      base.InitData();
      this.TouchEnable = true;
    }

    protected override bool CanReceiveModelObject(ModelDragData objectData)
    {
      return objectData != null && this.Parent == null;
    }
  }
}
