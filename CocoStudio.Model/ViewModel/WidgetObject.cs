// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.WidgetObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.ImplementationDetails_c065fe4d;
using PostSharp.Reflection;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public class WidgetObject : NodeObject
  {
    private EnumCallBack callBackType = EnumCallBack.None;
    protected string callBackName = "";

    [Browsable(false)]
    public CSWidget CustomWidgetInstance { get; private set; }

    [DisplayName("Display_CanUse")]
    [Category("Group_Routine")]
    [UndoProperty]
    [DefaultValue(true)]
    [PropertyOrder(2)]
    [Browsable(true)]
    public virtual bool TouchEnable
    {
      get
      {
        return this.\u003Cget_TouchEnable\u003Ez__OriginalMethod();
      }
      set
      {
        LocationInterceptionArgsImpl<bool> interceptionArgsImpl = new LocationInterceptionArgsImpl<bool>((object) this, Arguments.Empty);
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439099322360L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) WidgetObject.\u003CTouchEnable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "TouchEnable";
        \u003C\u003Ez__a_1.a0.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
      }
    }

    [Browsable(true)]
    [UndoProperty]
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

    public WidgetObject()
    {
    }

    public WidgetObject(CSWidget comEntiy)
      : base((CSNode) comEntiy)
    {
      this.CustomWidgetInstance = comEntiy;
    }

    private CSWidget GetInnerWidget()
    {
      return this.innerNode as CSWidget;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSWidget();
    }

    protected override void InitData()
    {
      base.InitData();
      this.IsAddToCurrent = false;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      CSWidget csWidget = cInnerObject as CSWidget;
      if (csWidget != null)
        csWidget.CloneWidgetCustomProperty(this.GetInnerWidget());
      base.SetValue(cObject, cInnerObject);
      WidgetObject widgetObject = cObject as WidgetObject;
      if (widgetObject == null)
        return;
      widgetObject.TouchEnable = this.TouchEnable;
      widgetObject.CallBackName = this.CallBackName;
      widgetObject.CallBackType = this.CallBackType;
    }

    private bool <get_TouchEnable>z__OriginalMethod()
    {
      return this.GetInnerWidget().GetTouchEnabled();
    }
  }
}
