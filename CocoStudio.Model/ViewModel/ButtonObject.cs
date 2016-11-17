// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ButtonObject
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_BaseControl", 0, 0)]
  [ModelExtension(true, 0)]
  [DisplayName("Display_Component_UIButton")]
  public class ButtonObject : WidgetObject, IScale9, IDisplayState
  {
    private bool isNormal = true;
    private ResourceFile normalFile = (ResourceFile) null;
    private ResourceFile pressedFile = (ResourceFile) null;
    private ResourceFile disabledFile = (ResourceFile) null;
    private ResourceFile fontFile = (ResourceFile) null;
    private System.Drawing.Color _textColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private bool _scale9Enabled = false;
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;
    private string text;

    [DisplayName("Display_State")]
    [System.ComponentModel.Editor(typeof (CheckBoxEditor), typeof (CheckBoxEditor))]
    [DefaultValue(true)]
    [UndoProperty]
    [Category("Group_Feature")]
    [PropertyOrder(73)]
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

    [DisplayName("Display_ImageResources")]
    [Category("Group_Feature")]
    [PropertyOrder(72)]
    [System.ComponentModel.Editor(typeof (ResourceGroupEditor), typeof (ResourceGroupEditor))]
    public virtual List<string> ResourceValue
    {
      get
      {
        return new List<string>() { "NormalFileData", "PressedFileData", "DisabledFileData" };
      }
      set
      {
        throw new InvalidOperationException();
      }
    }

    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [DefaultValue(null)]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DisplayName("Display_NormalState")]
    public ResourceFile NormalFileData
    {
      get
      {
        return this.normalFile;
      }
      set
      {
        this.normalFile = value;
        if (this.normalFile == null || !this.normalFile.IsValid)
          this.normalFile = (ResourceFile) new ImageFile((ResourceData) ButtonObjectData.Default_NormalFile);
        this.GetInnerWidget().SetNormalFilePath(this.normalFile.GetResourceData());
        this.RefreshScale9();
        using (CompositeTask.Run(this.GetType().Name + "NormalFileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.NormalFileData));
        }
      }
    }

    [DisplayName("Display_BtnDown")]
    [UndoProperty]
    [DefaultValue(null)]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public ResourceFile PressedFileData
    {
      get
      {
        return this.pressedFile;
      }
      set
      {
        this.pressedFile = value;
        if (this.pressedFile == null || !this.pressedFile.IsValid)
          this.pressedFile = (ResourceFile) new ImageFile((ResourceData) ButtonObjectData.Default_PressedFile);
        this.GetInnerWidget().SetPressedFilePath(this.pressedFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.PressedFileData));
      }
    }

    [DefaultValue(null)]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DisplayName("Display_Disable")]
    [UndoProperty]
    public ResourceFile DisabledFileData
    {
      get
      {
        return this.disabledFile;
      }
      set
      {
        this.disabledFile = value;
        if (this.disabledFile == null || !this.disabledFile.IsValid)
          this.disabledFile = (ResourceFile) new ImageFile((ResourceData) ButtonObjectData.Default_DisabledFile);
        this.GetInnerWidget().SetDisabledFilePath(this.disabledFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.DisabledFileData));
      }
    }

    [System.ComponentModel.Editor(typeof (PropertyColorEditor), typeof (PropertyColorEditor))]
    [ResourceFilter(new string[] {"ttf", "ttc"})]
    [Category("Group_Feature")]
    [PropertyOrder(77)]
    [DisplayName("Display_FontStyle")]
    [DefaultValue(null)]
    [UndoProperty]
    public ResourceFile FontResource
    {
      get
      {
        return this.fontFile;
      }
      set
      {
        this.fontFile = value;
        if (this.fontFile == null || !this.fontFile.IsValid)
        {
          this.GetInnerWidget().SetFontName(WidgetObjectData.DefaultFont);
          this.GetInnerWidget().SetFontSize(this.FontSize);
        }
        else
          this.GetInnerWidget().SetFontName(this.fontFile.GetResourceData().Path);
        using (CompositeTask.Run(this.GetType().Name + "FontResource"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FontResource));
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
        }
      }
    }

    [Category("Group_Feature")]
    [Browsable(false)]
    [UndoProperty]
    [DefaultValue(24)]
    [ValueRange(5, 100, 1.0)]
    [DisplayName("Display_FontSize")]
    [PropertyOrder(76)]
    public int FontSize
    {
      get
      {
        return this.GetInnerWidget().GetFontSize();
      }
      set
      {
        if (value < 1)
          value = 1;
        if (this.GetInnerWidget().GetFontSize() == value)
          return;
        this.GetInnerWidget().SetFontSize(value);
        using (CompositeTask.Run(this.GetType().Name + "FontSize"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.FontSize));
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
        }
      }
    }

    [PropertyOrder(74)]
    [UndoProperty]
    [DisplayName("Display_Text")]
    [Category("Group_Feature")]
    public string ButtonText
    {
      get
      {
        return this.text;
      }
      set
      {
        if (!(value != this.text))
          return;
        this.text = value;
        if (value == null)
          value = "";
        this.GetInnerWidget().SetText(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.ButtonText));
        using (CompositeTask.Run(this.GetType().Name + "ButtonText"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.ButtonText));
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
        }
      }
    }

    [DisplayName("Display_TextColor")]
    [System.ComponentModel.Editor(typeof (ColorsEditor), typeof (ColorsEditor))]
    [PropertyOrder(75)]
    [UndoProperty]
    [Category("Group_Feature")]
    [Browsable(false)]
    public System.Drawing.Color TextColor
    {
      get
      {
        return this._textColor;
      }
      set
      {
        if ((int) this._textColor.B == (int) value.B && (int) this._textColor.G == (int) value.G && (int) this._textColor.R == (int) value.R)
          return;
        this._textColor = value;
        this.GetInnerWidget().SetTextColor(value);
        this.RaisePropertyChanged<System.Drawing.Color>((Expression<Func<System.Drawing.Color>>) (() => this.TextColor));
      }
    }

    [PropertyOrder(14)]
    [DefaultValue(false)]
    [UndoProperty]
    [Category("Group_Routine")]
    [Browsable(true)]
    [DisplayName("Display_Flip")]
    [System.ComponentModel.Editor(typeof (FilpEditor), typeof (FilpEditor))]
    public virtual FilpValue Filp
    {
      get
      {
        return new FilpValue(this.FlipX, this.FlipY);
      }
      set
      {
        this.FlipX = value.FlipX;
        this.FlipY = value.FlipY;
      }
    }

    public virtual bool FlipY
    {
      get
      {
        return this.GetInnerWidget().GetFlipY();
      }
      set
      {
        if (this.GetInnerWidget().GetFlipY() == value)
          return;
        this.GetInnerWidget().SetFlipY(value);
        this.RaisePropertyChanged<FilpValue>((Expression<Func<FilpValue>>) (() => this.Filp));
      }
    }

    public virtual bool FlipX
    {
      get
      {
        return this.GetInnerWidget().GetFlipX();
      }
      set
      {
        if (this.GetInnerWidget().GetFlipX() == value)
          return;
        this.GetInnerWidget().SetFlipX(value);
        this.RaisePropertyChanged<FilpValue>((Expression<Func<FilpValue>>) (() => this.Filp));
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
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439099191266L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) ButtonObject.\u003CScale9Enable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "Scale9Enable";
        \u003C\u003Ez__a_2.a1.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
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

    public ButtonObject()
    {
    }

    public ButtonObject(CSButton customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSButton GetInnerWidget()
    {
      return (CSButton) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSButton();
    }

    protected override void InitData()
    {
      base.InitData();
      this.FontResource = (ResourceFile) null;
      this.ButtonText = "Button";
      this.FontSize = 14;
      this.TextColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 65, 65, 70);
      this.PressedFileData = (ResourceFile) null;
      this.DisabledFileData = (ResourceFile) null;
      this.TouchEnable = true;
      this.Filp = new FilpValue(false, false);
      this.NormalFileData = (ResourceFile) null;
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
      ButtonObject buttonObject = cObject as ButtonObject;
      if (buttonObject == null)
        return;
      buttonObject.NormalFileData = this.NormalFileData;
      buttonObject.PressedFileData = this.PressedFileData;
      buttonObject.DisabledFileData = this.DisabledFileData;
      buttonObject.FontSize = this.FontSize;
      buttonObject.ButtonText = this.ButtonText;
      buttonObject.TextColor = this.TextColor;
      buttonObject.FlipX = this.FlipX;
      buttonObject.FlipY = this.FlipY;
      buttonObject.Scale9Enable = this.Scale9Enable;
      buttonObject.LeftEage = this.LeftEage;
      buttonObject.RightEage = this.RightEage;
      buttonObject.TopEage = this.TopEage;
      buttonObject.BottomEage = this.BottomEage;
      buttonObject.DisplayState = this.DisplayState;
      buttonObject.FontResource = this.FontResource;
      buttonObject.Size = this.Size;
      buttonObject.PreSizeEnable = this.PreSizeEnable;
      buttonObject.PreSize = this.PreSize;
      buttonObject.DisplayState = this.DisplayState;
    }

    protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
    {
      TextEditorWindow textEditorWindow = new TextEditorWindow((object) this, "ButtonText", "TextColor", "FontSize", false);
    }

    private bool \u003Cget_Scale9Enable\u003Ez__OriginalMethod()
    {
      return this._scale9Enabled;
    }
  }
}
