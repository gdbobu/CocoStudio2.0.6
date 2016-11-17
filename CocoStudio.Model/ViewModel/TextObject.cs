// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TextObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [ModelExtension(true, 8)]
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_UILable")]
  public class TextObject : WidgetObject, ISizeType
  {
    private ResourceFile file = (ResourceFile) null;
    private string _labelText = "";

    [UndoProperty]
    public bool IsCustomSize
    {
      get
      {
        return this.GetInnerWidget().GetSizeCustomEnabled();
      }
      set
      {
        this.GetInnerWidget().SetSizeCustomEnabled(value);
        using (CompositeTask.Run(this.GetType().Name + "IsCustomSize"))
        {
          if (!value)
            this.PreSizeEnable = false;
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsCustomSize));
        }
      }
    }

    [Category("Group_Feature")]
    [DefaultValue(255)]
    [PropertyOrder(32)]
    [UndoProperty]
    [DisplayName("Display_Animation")]
    public virtual bool TouchScaleChangeAble
    {
      get
      {
        return this.GetInnerWidget().GetTouchScaleChangeEanbleState();
      }
      set
      {
        this.GetInnerWidget().SetTouchScaleChangeEanbleState(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.TouchScaleChangeAble));
      }
    }

    [DisplayName("Display_Flip")]
    [UndoProperty]
    [Browsable(false)]
    [PropertyOrder(14)]
    [DefaultValue(false)]
    [System.ComponentModel.Editor(typeof (FilpEditor), typeof (FilpEditor))]
    [Category("Display_ControlLayout")]
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

    [Category("Group_Feature")]
    [DefaultValue(null)]
    [DisplayName("Display_FontStyle")]
    [PropertyOrder(38)]
    [UndoProperty]
    [ResourceFilter(new string[] {"ttf", "ttc"})]
    [System.ComponentModel.Editor(typeof (PropertyColorEditor), typeof (PropertyColorEditor))]
    public ResourceFile FontResource
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
          this.GetInnerWidget().SetFontName(WidgetObjectData.DefaultFont);
          this.GetInnerWidget().SetFontSize(this.FontSize);
        }
        else
          this.GetInnerWidget().SetFontName(this.file.GetResourceData().Path);
        using (CompositeTask.Run(this.GetType().Name + "FontResource"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FontResource));
        }
      }
    }

    [Category("Group_Routine")]
    [PropertyOrder(12)]
    [System.ComponentModel.Editor(typeof (ColorsEditor), typeof (ColorsEditor))]
    [DisplayName("Display_ColorBlend")]
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

    [DefaultValue(24)]
    [Browsable(false)]
    [PropertyOrder(37)]
    [ValueRange(5, 100, 1.0)]
    [Category("Group_Feature")]
    [UndoProperty]
    [DisplayName("Display_FontSize")]
    public int FontSize
    {
      get
      {
        return this.GetInnerWidget().GetFontSize();
      }
      set
      {
        if (this.FontSize == value || value < 1)
          return;
        this.GetInnerWidget().SetFontSize(value);
        using (CompositeTask.Run(this.GetType().Name + "FontSize"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.FontSize));
        }
      }
    }

    [UndoProperty]
    [PropertyOrder(34)]
    [DisplayName("Display_Text")]
    [System.ComponentModel.Editor(typeof (EntryTextViewEditor), typeof (EntryTextViewEditor))]
    [DefaultValue("")]
    [Category("Group_Feature")]
    public string LabelText
    {
      get
      {
        return this._labelText;
      }
      set
      {
        if (!(this._labelText != value))
          return;
        this._labelText = value;
        this.GetInnerWidget().SetLabelText(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.LabelText));
        this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
      }
    }

    [PropertyOrder(35)]
    [DefaultValue("")]
    [Category("Group_Feature")]
    [UndoProperty]
    [DisplayName("Display_HAlign")]
    public TextHorizontalType HorizontalAlignmentType
    {
      get
      {
        return (TextHorizontalType) this.GetInnerWidget().GetHorizontalAlignmentType();
      }
      set
      {
        this.GetInnerWidget().SetHorizontalAlignmentType((int) value);
        this.RaisePropertyChanged<TextHorizontalType>((Expression<Func<TextHorizontalType>>) (() => this.HorizontalAlignmentType));
      }
    }

    [Category("Group_Feature")]
    [PropertyOrder(36)]
    [DisplayName("Display_VAlign")]
    [UndoProperty]
    [DefaultValue("")]
    public TextVerticalType VerticalAlignmentType
    {
      get
      {
        return (TextVerticalType) this.GetInnerWidget().GetVerticalAlignmentType();
      }
      set
      {
        this.GetInnerWidget().SetVerticalAlignmentType((int) value);
        this.RaisePropertyChanged<TextVerticalType>((Expression<Func<TextVerticalType>>) (() => this.VerticalAlignmentType));
      }
    }

    public TextObject()
    {
    }

    public TextObject(CSText customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSText GetInnerWidget()
    {
      return (CSText) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSText();
    }

    protected override void InitData()
    {
      base.InitData();
      this.FontResource = (ResourceFile) null;
      this.LabelText = "Text Label";
      this.FontSize = 20;
      this.Filp = new FilpValue(false, false);
      this.IsCustomSize = false;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      TextObject textObject = cObject as TextObject;
      if (textObject == null)
        return;
      textObject.FontResource = this.FontResource;
      textObject.FontSize = this.FontSize;
      textObject.LabelText = this.LabelText;
      textObject.HorizontalAlignmentType = this.HorizontalAlignmentType;
      textObject.VerticalAlignmentType = this.VerticalAlignmentType;
      textObject.TouchScaleChangeAble = this.TouchScaleChangeAble;
      textObject.FlipX = this.FlipX;
      textObject.FlipY = this.FlipY;
      textObject.IsCustomSize = this.IsCustomSize;
      textObject.Size = this.Size;
    }

    protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
    {
      TextEditorWindow textEditorWindow = new TextEditorWindow((object) this, "LabelText", "CColor", "FontSize", true);
    }
  }
}
