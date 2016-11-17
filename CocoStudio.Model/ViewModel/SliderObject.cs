// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.SliderObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.ImplementationDetails_c065fe4d;
using PostSharp.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_UISlider")]
  [ModelExtension(true, 7)]
  public class SliderObject : WidgetObject, IDisplayState, ICallBackEvent
  {
    private bool isNormal = true;
    private ResourceFile backGroundFile = (ResourceFile) null;
    private ResourceFile progressBarFile = (ResourceFile) null;
    private ResourceFile ballNormalFile = (ResourceFile) null;
    private ResourceFile ballPressedFile = (ResourceFile) null;
    private ResourceFile ballDisableFile = (ResourceFile) null;
    private bool _scale9Enabled = false;
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;

    [Category("Group_Feature")]
    [DefaultValue(true)]
    [PropertyOrder(48)]
    [System.ComponentModel.Editor(typeof (CheckBoxEditor), typeof (CheckBoxEditor))]
    [DisplayName("Display_State")]
    [UndoProperty]
    public virtual bool DisplayState
    {
      get
      {
        return this.isNormal;
      }
      set
      {
        this.isNormal = value;
        this.GetInnerWidget().ChangeState(this.isNormal);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.DisplayState));
      }
    }

    [DefaultValue(null)]
    [PropertyOrder(43)]
    [Category("Group_Feature")]
    [System.ComponentModel.Editor(typeof (ResourceGroupEditor), typeof (ResourceGroupEditor))]
    [DisplayName("Display_ImageResources")]
    public virtual List<string> ResourceValue
    {
      get
      {
        return new List<string>()
        {
          "BackGroundData",
          "ProgressBarData"
        };
      }
      set
      {
        throw new InvalidOperationException();
      }
    }

    [DefaultValue(null)]
    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DisplayName("ContexMenu_BackgroundStyle")]
    public virtual ResourceFile BackGroundData
    {
      get
      {
        return this.backGroundFile;
      }
      set
      {
        this.backGroundFile = value;
        if (this.backGroundFile == null || !this.backGroundFile.IsValid)
          this.backGroundFile = (ResourceFile) new ImageFile((ResourceData) SliderObjectData.DefaultBackgroundFile);
        this.GetInnerWidget().SetGroundBarTexture(this.backGroundFile.GetResourceData());
        this.RefreshScale9();
        using (CompositeTask.Run(this.GetType().Name + "BackGroundData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.BackGroundData));
        }
      }
    }

    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [DefaultValue(null)]
    [DisplayName("ContexMenu_InnerSliderStyle")]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public virtual ResourceFile ProgressBarData
    {
      get
      {
        return this.progressBarFile;
      }
      set
      {
        this.progressBarFile = value;
        if (this.progressBarFile == null || !this.progressBarFile.IsValid)
          this.progressBarFile = (ResourceFile) new ImageFile((ResourceData) SliderObjectData.DefaultProgressBarFile);
        this.RefreshScale9();
        this.GetInnerWidget().SetProgressBarTexture(this.progressBarFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.ProgressBarData));
      }
    }

    [PropertyOrder(47)]
    [Category("Group_Feature")]
    [System.ComponentModel.Editor(typeof (ResourceGroupEditor), typeof (ResourceGroupEditor))]
    [DisplayName("Display_NodeResource")]
    public virtual List<string> ResourceNodeValue
    {
      get
      {
        return new List<string>()
        {
          "BallNormalData",
          "BallPressedData",
          "BallDisabledData"
        };
      }
      set
      {
        throw new InvalidOperationException();
      }
    }

    [ResourceFilter(new string[] {"png", "jpg"})]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DefaultValue(null)]
    [DisplayName("ContexMenu_NodeNormalStyle")]
    public virtual ResourceFile BallNormalData
    {
      get
      {
        return this.ballNormalFile;
      }
      set
      {
        this.ballNormalFile = value;
        if (this.ballNormalFile == null || !this.ballNormalFile.IsValid)
          this.ballNormalFile = (ResourceFile) new ImageFile((ResourceData) SliderObjectData.DefaultBallNormalFile);
        this.GetInnerWidget().SetBallNormalTexture(this.ballNormalFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.BallNormalData));
      }
    }

    [DefaultValue(null)]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DisplayName("ContexMenu_NodePressedStyle")]
    [ResourceFilter(new string[] {"png", "jpg"})]
    public virtual ResourceFile BallPressedData
    {
      get
      {
        return this.ballPressedFile;
      }
      set
      {
        this.ballPressedFile = value;
        if (this.ballPressedFile == null || !this.ballNormalFile.IsValid)
          this.ballPressedFile = (ResourceFile) new ImageFile((ResourceData) SliderObjectData.DefaultBallPressedFile);
        this.GetInnerWidget().SetBallPressedTexture(this.ballPressedFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.BallPressedData));
      }
    }

    [ResourceFilter(new string[] {"png", "jpg"})]
    [DisplayName("ContexMenu_NodeDisabledStyle")]
    [DefaultValue(null)]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public virtual ResourceFile BallDisabledData
    {
      get
      {
        return this.ballDisableFile;
      }
      set
      {
        this.ballDisableFile = value;
        if (this.ballDisableFile == null || !this.ballDisableFile.IsValid)
          this.ballDisableFile = (ResourceFile) new ImageFile((ResourceData) SliderObjectData.DefaultBallDisabledFile);
        this.GetInnerWidget().SetBallDisabledTexture(this.ballDisableFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.BallDisabledData));
      }
    }

    [Category("Group_Feature")]
    [ValueRange(0, 100, 1.0)]
    [PropertyOrder(49)]
    [DefaultValue(50)]
    [UndoProperty]
    [DisplayName("Display_SliderProgress")]
    [System.ComponentModel.Editor(typeof (SliderEditor), typeof (SliderEditor))]
    public virtual int PercentInfo
    {
      get
      {
        return this.GetInnerWidget().GetPercent();
      }
      set
      {
        int percent = value;
        if (percent < 0)
          percent = 0;
        else if (percent > 100)
          percent = 100;
        this.GetInnerWidget().SetPercent(percent);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.PercentInfo));
      }
    }

    [UndoProperty]
    public virtual bool Scale9Enable
    {
      get
      {
        return this.\u003Cget_Scale9Enable\u003Ez__OriginalMethod();
      }
      set
      {
        LocationInterceptionArgsImpl<bool> interceptionArgsImpl = new LocationInterceptionArgsImpl<bool>((object) this, Arguments.Empty);
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098404840L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) SliderObject.\u003CScale9Enable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "Scale9Enable";
        \u003C\u003Ez__a_6.a5.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
      }
    }

    [UndoProperty]
    public virtual int LeftEage
    {
      get
      {
        return this._left;
      }
      set
      {
        this._left = value;
        this.RefreshScale9();
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.LeftEage));
      }
    }

    [UndoProperty]
    public virtual int RightEage
    {
      get
      {
        return this._right;
      }
      set
      {
        this._right = value;
        this.RefreshScale9();
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.RightEage));
      }
    }

    [UndoProperty]
    public virtual int TopEage
    {
      get
      {
        return this._top;
      }
      set
      {
        this._top = value;
        this.RefreshScale9();
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.TopEage));
      }
    }

    [UndoProperty]
    public virtual int BottomEage
    {
      get
      {
        return this._bottom;
      }
      set
      {
        this._bottom = value;
        this.RefreshScale9();
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.BottomEage));
      }
    }

    public virtual int Scale9OriginX { get; set; }

    public virtual int Scale9OriginY { get; set; }

    public virtual int Scale9Width { get; set; }

    public virtual int Scale9Height { get; set; }

    public SliderObject()
    {
    }

    public SliderObject(CSSlider customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSSlider GetInnerWidget()
    {
      return (CSSlider) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSSlider();
    }

    protected override void InitData()
    {
      base.InitData();
      this.BallPressedData = (ResourceFile) null;
      this.BallDisabledData = (ResourceFile) null;
      this.ProgressBarData = (ResourceFile) null;
      this.BackGroundData = (ResourceFile) null;
      this.BallNormalData = (ResourceFile) null;
      this.PercentInfo = 50;
      this.TouchEnable = true;
    }

    private void RefreshScale9()
    {
      Gdk.Size widgetAutoSize = this.GetInnerWidget().GetWidgetAutoSize();
      int num1 = this._left < widgetAutoSize.Width - this._right ? this._left : widgetAutoSize.Width - this._right;
      int num2 = this._left > widgetAutoSize.Width - this._right ? this._left : widgetAutoSize.Width - this._right;
      int num3 = this._bottom < widgetAutoSize.Height - this._top ? this._bottom : widgetAutoSize.Height - this._top;
      int num4 = this._bottom > widgetAutoSize.Height - this._top ? this._bottom : widgetAutoSize.Height - this._top;
      this.Scale9OriginX = num1;
      this.Scale9OriginY = widgetAutoSize.Height - num4;
      this.Scale9Width = num2 - num1;
      this.Scale9Height = num4 - num3;
      this.GetInnerWidget().SetScale9Rect(this.Scale9OriginX, this.Scale9OriginY, this.Scale9Width, this.Scale9Height);
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      SliderObject sliderObject = cObject as SliderObject;
      if (sliderObject == null)
        return;
      sliderObject.BackGroundData = this.BackGroundData;
      sliderObject.ProgressBarData = this.ProgressBarData;
      sliderObject.BallNormalData = this.BallNormalData;
      sliderObject.BallPressedData = this.BallPressedData;
      sliderObject.BallDisabledData = this.BallDisabledData;
      sliderObject.Scale9Enable = this.Scale9Enable;
      sliderObject.LeftEage = this.LeftEage;
      sliderObject.RightEage = this.RightEage;
      sliderObject.TopEage = this.TopEage;
      sliderObject.BottomEage = this.BottomEage;
      sliderObject.PercentInfo = this.PercentInfo;
      sliderObject.Size = this.Size;
      sliderObject.DisplayState = this.DisplayState;
    }

    private bool \u003Cget_Scale9Enable\u003Ez__OriginalMethod()
    {
      return this._scale9Enabled;
    }
  }
}
