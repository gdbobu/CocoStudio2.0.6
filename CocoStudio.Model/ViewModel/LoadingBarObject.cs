// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.LoadingBarObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
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
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_UILoadingBar")]
  [ModelExtension(true, 6)]
  public class LoadingBarObject : WidgetObject
  {
    private ResourceFile file = (ResourceFile) null;
    private bool _scale9Enabled = false;
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;

    [DisplayName("Display_ImageResources")]
    [Category("Group_Feature")]
    [PropertyOrder(50)]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DefaultValue(null)]
    [UndoProperty]
    public ResourceFile ImageFileData
    {
      get
      {
        return this.file;
      }
      set
      {
        this.file = value;
        if (this.file == null || !this.file.IsValid)
          this.file = (ResourceFile) new ImageFile((ResourceData) LoadingBarObjectData.DefaultFile);
        this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        this.RefreshScale9();
        using (CompositeTask.Run(this.GetType().Name + "ImageFileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.ImageFileData));
        }
      }
    }

    [DisplayName("Display_Progress")]
    [PropertyOrder(51)]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (SliderEditor), typeof (SliderEditor))]
    [ValueRange(0, 100, 1.0)]
    [Category("Group_Feature")]
    public int ProgressInfo
    {
      get
      {
        return this.GetInnerWidget().GetProgressPercent();
      }
      set
      {
        int iInfo = value;
        if (iInfo < 0)
          iInfo = 0;
        else if (iInfo > 100)
          iInfo = 100;
        this.GetInnerWidget().SetProgressPercent(iInfo);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.ProgressInfo));
      }
    }

    [PropertyOrder(52)]
    [UndoProperty]
    [DefaultValue(null)]
    [DisplayName("Display_ProgressType")]
    [Category("Group_Feature")]
    public LoadingBarDirectionType ProgressType
    {
      get
      {
        return (LoadingBarDirectionType) this.GetInnerWidget().GetProgressType();
      }
      set
      {
        this.GetInnerWidget().SetProgressType((int) value);
        this.RaisePropertyChanged<LoadingBarDirectionType>((Expression<Func<LoadingBarDirectionType>>) (() => this.ProgressType));
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
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098601460L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) LoadingBarObject.\u003CScale9Enable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "Scale9Enable";
        \u003C\u003Ez__a_5.a4.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
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

    public LoadingBarObject()
    {
    }

    public LoadingBarObject(CSLoadingBar customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSLoadingBar GetInnerWidget()
    {
      return (CSLoadingBar) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSLoadingBar();
    }

    protected override void InitData()
    {
      base.InitData();
      this.ImageFileData = (ResourceFile) null;
      this.ProgressInfo = 80;
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
      LoadingBarObject loadingBarObject = cObject as LoadingBarObject;
      if (loadingBarObject == null)
        return;
      loadingBarObject.ImageFileData = this.ImageFileData;
      loadingBarObject.ProgressInfo = this.ProgressInfo;
      loadingBarObject.ProgressType = this.ProgressType;
      loadingBarObject.Scale9Enable = this.Scale9Enable;
      loadingBarObject.LeftEage = this.LeftEage;
      loadingBarObject.RightEage = this.RightEage;
      loadingBarObject.TopEage = this.TopEage;
      loadingBarObject.BottomEage = this.BottomEage;
      loadingBarObject.Size = this.Size;
    }

    private bool \u003Cget_Scale9Enable\u003Ez__OriginalMethod()
    {
      return this._scale9Enabled;
    }
  }
}
