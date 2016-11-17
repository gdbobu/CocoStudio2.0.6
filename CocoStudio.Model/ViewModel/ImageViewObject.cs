// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ImageViewObject
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
  [DisplayName("Display_Component_UIImageView")]
  [ModelExtension(true, 3)]
  public class ImageViewObject : WidgetObject, IScale9
  {
    private ResourceFile file = (ResourceFile) null;
    private bool _scale9Enabled = false;
    private int _left = 0;
    private int _right = 0;
    private int _top = 0;
    private int _bottom = 0;

    [System.ComponentModel.Editor(typeof (FilpEditor), typeof (FilpEditor))]
    [DefaultValue(false)]
    [Category("Group_Routine")]
    [DisplayName("Display_Flip")]
    [UndoProperty]
    [PropertyOrder(14)]
    [Browsable(true)]
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

    [DefaultValue(null)]
    [Category("Group_Feature")]
    [Description("Description_File")]
    [DisplayName("Display_ImageResource")]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [PropertyOrder(59)]
    [ResourceFilter(new string[] {"png", "jpg"})]
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
          this.file = (ResourceFile) new ImageFile((ResourceData) ImageViewObjectData.DefaultFile);
        this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        this.RefreshScale9();
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
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
        interceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098994674L);
        interceptionArgsImpl.TypedBinding = (LocationBinding<bool>) ImageViewObject.\u003CScale9Enable\u003Ec__Binding.singleton;
        interceptionArgsImpl.TypedValue = value;
        interceptionArgsImpl.LocationName = "Scale9Enable";
        \u003C\u003Ez__a_3.a2.OnSetValue((LocationInterceptionArgs) interceptionArgsImpl);
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

    public ImageViewObject()
    {
    }

    public ImageViewObject(CSImageView comEntiy)
      : base((CSWidget) comEntiy)
    {
    }

    private CSImageView GetInnerWidget()
    {
      return (CSImageView) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSImageView();
    }

    protected override void InitData()
    {
      base.InitData();
      this.Filp = new FilpValue(false, false);
      this.FileData = (ResourceFile) null;
      this.Name = "Image_" + (object) this.ObjectIndex;
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
      ImageViewObject imageViewObject = cObject as ImageViewObject;
      if (imageViewObject == null)
        return;
      imageViewObject.FileData = this.FileData;
      imageViewObject.FlipX = this.FlipX;
      imageViewObject.FlipY = this.FlipY;
      imageViewObject.Scale9Enable = this.Scale9Enable;
      imageViewObject.LeftEage = this.LeftEage;
      imageViewObject.RightEage = this.RightEage;
      imageViewObject.TopEage = this.TopEage;
      imageViewObject.BottomEage = this.BottomEage;
      imageViewObject.Size = this.Size;
    }

    private bool \u003Cget_Scale9Enable\u003Ez__OriginalMethod()
    {
      return this._scale9Enabled;
    }
  }
}
