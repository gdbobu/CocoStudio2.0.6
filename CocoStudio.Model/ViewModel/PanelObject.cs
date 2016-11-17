// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PanelObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
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
  [ModelExtension(true, 50)]
  [Catagory("Control_ContainerControl", 1, 0)]
  [DisplayName("Display_Component_UIPanel")]
  public class PanelObject : WidgetObject, IColorValue, IScale9
  {
    private ResourceFile file = (ResourceFile) null;
    private float _colorAngle = 0.0f;
    private bool _scale9Enabled = false;
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;
    private EnumCallBack callBackType = EnumCallBack.None;
    protected new string callBackName = "";

    [DisplayName("Display_Clip")]
    [UndoProperty]
    [Category("Group_Feature")]
    [PropertyOrder(18)]
    public virtual bool ClipAble
    {
      get
      {
        return this.GetInnerWidget().GetClipAble();
      }
      set
      {
        this.GetInnerWidget().SetClipAble(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.ClipAble));
      }
    }

    [Category("Group_Feature")]
    [DefaultValue(null)]
    [DisplayName("Display_BackgroundImage")]
    [PropertyOrder(23)]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [UndoProperty]
    public ResourceFile FileData
    {
      get
      {
        return this.file;
      }
      set
      {
        this.file = value;
        if (this.file == null || !this.file.IsValid)
        {
          this.GetInnerWidget().RemoveBackGroundFile();
        }
        else
        {
          this.GetInnerWidget().SetFilePath(this.file.GetResourceData());
          this.RefreshScale9();
        }
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
      }
    }

    [UndoProperty]
    [DisplayName("Fill_color")]
    [Category("Group_Feature")]
    [System.ComponentModel.Editor(typeof (ChangeColorEditor), typeof (ChangeColorEditor))]
    [PropertyOrder(24)]
    public int ComboBoxIndex
    {
      get
      {
        return this.GetInnerWidget().GetGroundColorType();
      }
      set
      {
        this.GetInnerWidget().SetGroundColorType(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.ComboBoxIndex));
      }
    }

    [UndoProperty]
    public System.Drawing.Color EndColor
    {
      get
      {
        return this.GetInnerWidget().GetGroundLineEndColor();
      }
      set
      {
        this.GetInnerWidget().SetGroundLineEndColor(value);
        this.RaisePropertyChanged<System.Drawing.Color>((Expression<Func<System.Drawing.Color>>) (() => this.EndColor));
      }
    }

    [UndoProperty]
    public System.Drawing.Color FirstColor
    {
      get
      {
        return this.GetInnerWidget().GetGroundLineStartColor();
      }
      set
      {
        this.GetInnerWidget().SetGroundSingleColor(value);
        this.GetInnerWidget().SetGroundLineStartColor(value);
        this.RaisePropertyChanged<System.Drawing.Color>((Expression<Func<System.Drawing.Color>>) (() => this.FirstColor));
      }
    }

    [UndoProperty]
    public System.Drawing.Color SingleColor
    {
      get
      {
        return this.GetInnerWidget().GetGroundSingleColor();
      }
      set
      {
        this.GetInnerWidget().SetGroundSingleColor(value);
        this.GetInnerWidget().SetGroundLineStartColor(value);
        this.RaisePropertyChanged<System.Drawing.Color>((Expression<Func<System.Drawing.Color>>) (() => this.SingleColor));
      }
    }

    [UndoProperty]
    public float ColorAngle
    {
      get
      {
        return this._colorAngle;
      }
      set
      {
        if ((double) this._colorAngle == (double) value)
          return;
        this._colorAngle = value;
        float num = (float) (Math.PI * (90.0 - (double) this._colorAngle) / 180.0);
        this.ColorVector = new ScaleValue((float) Math.Sin((double) num), (float) Math.Cos((double) num), 0.1, -99999999.0, 99999999.0);
        this.GetInnerWidget().SetGroundColorVector(this.ColorVector);
        this.RaisePropertyChanged<float>((Expression<Func<float>>) (() => this.ColorAngle));
      }
    }

    public ScaleValue ColorVector { get; set; }

    [System.ComponentModel.Editor(typeof (SliderEditor), typeof (SliderEditor))]
    [Category("Group_Feature")]
    [UndoProperty]
    [PropertyOrder(26)]
    [Browsable(false)]
    [ValueRange(0, 255, 1.0)]
    [DisplayName("Background_color_transparency")]
    public virtual int BackColorAlpha
    {
      get
      {
        return this.GetInnerWidget().GetGroundAlpha();
      }
      set
      {
        if (this.GetInnerWidget().GetGroundAlpha() == value)
          return;
        this.GetInnerWidget().SetGroundAlpha(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.BackColorAlpha));
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
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098732520L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) PanelObject.\u003CScale9Enable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "Scale9Enable";
        \u003C\u003Ez__a_4.a3.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
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

    public PanelObject()
    {
    }

    public PanelObject(CSPanel customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSPanel GetInnerWidget()
    {
      return (CSPanel) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSPanel();
    }

    protected override void InitData()
    {
      base.InitData();
      this.BackColorAlpha = 102;
      this.SingleColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
      this.FirstColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 150, 200, (int) byte.MaxValue);
      this.EndColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ComboBoxIndex = 1;
      this.ColorAngle = 90f;
      this.Size = new CocoStudio.Model.PointF(200f, 200f);
      this.TouchEnable = true;
      this.ClipAble = false;
      this.IsAddToCurrent = true;
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

    protected override bool CanReceiveModelObject(ModelDragData objectData)
    {
      return objectData != null;
    }

    protected override bool CanContinueTest()
    {
      return base.CanContinueTest() && !this.ClipAble;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      PanelObject panelObject = cObject as PanelObject;
      if (panelObject == null)
        return;
      panelObject.FileData = this.FileData;
      panelObject.Alpha = this.Alpha;
      panelObject.CColor = this.CColor;
      panelObject.BackColorAlpha = this.BackColorAlpha;
      panelObject.ClipAble = this.ClipAble;
      panelObject.SingleColor = this.SingleColor;
      panelObject.FirstColor = this.FirstColor;
      panelObject.EndColor = this.EndColor;
      panelObject.ColorAngle = this.ColorAngle;
      panelObject.ComboBoxIndex = this.ComboBoxIndex;
      panelObject.Scale9Enable = this.Scale9Enable;
      panelObject.LeftEage = this.LeftEage;
      panelObject.RightEage = this.RightEage;
      panelObject.TopEage = this.TopEage;
      panelObject.BottomEage = this.BottomEage;
      panelObject.Size = this.Size;
    }

    private bool \u003Cget_Scale9Enable\u003Ez__OriginalMethod()
    {
      return this._scale9Enabled;
    }
  }
}
