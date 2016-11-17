// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TextFieldObject
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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_UIField")]
  [ModelExtension(true, 9)]
  [Catagory("Control_BaseControl", 0, 0)]
  public class TextFieldObject : WidgetObject, IAstrictLengthValue, IPasswordValue, ICallBackEvent
  {
    private ResourceFile file = (ResourceFile) null;
    private string _labelText = "";
    private string _placeText = "";

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
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsCustomSize));
      }
    }

    [PropertyOrder(38)]
    [ResourceFilter(new string[] {"ttf", "ttc"})]
    [DefaultValue(null)]
    [DisplayName("Display_FontStyle")]
    [Category("Group_Feature")]
    [UndoProperty]
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
    [System.ComponentModel.Editor(typeof (ColorsEditor), typeof (ColorsEditor))]
    [UndoProperty]
    [Browsable(false)]
    [PropertyOrder(12)]
    [DisplayName("Display_ColorBlend")]
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

    [ValueRange(5, 100, 1.0)]
    [DisplayName("Display_FontSize")]
    [Category("Group_Feature")]
    [Browsable(false)]
    [PropertyOrder(37)]
    [UndoProperty]
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
        this.GetInnerWidget().SetLabelText(this.LabelText);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.FontSize));
      }
    }

    [DefaultValue("input words here")]
    [DisplayName("Display_Text")]
    [Category("Group_Feature")]
    [PropertyOrder(34)]
    [UndoProperty]
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
      }
    }

    [DefaultValue("")]
    [DisplayName("Placeholder_Text")]
    [Category("Group_Feature")]
    [PropertyOrder(33)]
    [UndoProperty]
    public string PlaceHolderText
    {
      get
      {
        return this._placeText;
      }
      set
      {
        if (!(this._placeText != value))
          return;
        this._placeText = value;
        this.GetInnerWidget().SetPlaceHolderText(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.PlaceHolderText));
      }
    }

    [PropertyOrder(39)]
    [Browsable(true)]
    [DisplayName("ContexMenu_ShowCiphertext")]
    [Category("Group_Feature")]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (PasswordEditor), typeof (PasswordEditor))]
    public PasswordValue Password
    {
      get
      {
        return new PasswordValue(this.GetInnerWidget().GetPassWordEnabled(), this.GetInnerWidget().GetPasswordStyleText());
      }
      set
      {
        if (this.GetInnerWidget().GetPassWordEnabled() != value.PasswordEnable)
          this.GetInnerWidget().SetPassWordEnabled(value.PasswordEnable);
        if (value.PasswordStyleText != null)
          this.GetInnerWidget().SetPasswordStyleText(value.PasswordStyleText);
        this.RaisePropertyChanged<PasswordValue>((Expression<Func<PasswordValue>>) (() => this.Password));
      }
    }

    [UndoProperty]
    public bool PasswordEnable
    {
      get
      {
        return this.GetInnerWidget().GetPassWordEnabled();
      }
      set
      {
        this.GetInnerWidget().SetPassWordEnabled(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PasswordEnable));
      }
    }

    [UndoProperty]
    public string PasswordStyleText
    {
      get
      {
        return this.GetInnerWidget().GetPasswordStyleText();
      }
      set
      {
        this.GetInnerWidget().SetPasswordStyleText(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.PasswordStyleText));
      }
    }

    [System.ComponentModel.Editor(typeof (AstrictLengthEditor), typeof (AstrictLengthEditor))]
    [UndoProperty]
    [PropertyOrder(40)]
    [DisplayName("Length_limit")]
    [Category("Group_Feature")]
    [Browsable(true)]
    public AstrictLengthValue AstrictLength
    {
      get
      {
        return new AstrictLengthValue(this.GetInnerWidget().GetLengthLimited(), this.GetInnerWidget().GetMaxLength());
      }
      set
      {
        if (this.GetInnerWidget().GetLengthLimited() != value.MaxLengthEnable)
          this.GetInnerWidget().SetLengthLimited(value.MaxLengthEnable);
        this.GetInnerWidget().SetMaxLength(value.MaxLengthText);
        this.GetInnerWidget().SetLabelText(this._labelText);
        this.RaisePropertyChanged<AstrictLengthValue>((Expression<Func<AstrictLengthValue>>) (() => this.AstrictLength));
      }
    }

    [UndoProperty]
    public bool MaxLengthEnable
    {
      get
      {
        return this.GetInnerWidget().GetLengthLimited();
      }
      set
      {
        this.GetInnerWidget().SetLengthLimited(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.MaxLengthEnable));
      }
    }

    [UndoProperty]
    public int MaxLengthText
    {
      get
      {
        return this.GetInnerWidget().GetMaxLength();
      }
      set
      {
        this.GetInnerWidget().SetMaxLength(value);
        this.GetInnerWidget().SetLabelText(this._labelText);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.MaxLengthText));
      }
    }

    public TextFieldObject()
    {
    }

    public TextFieldObject(CSTextField customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSTextField GetInnerWidget()
    {
      return (CSTextField) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSTextField();
    }

    protected override void InitData()
    {
      base.InitData();
      this.IsCustomSize = true;
      this.FontResource = (ResourceFile) null;
      this.FontSize = 20;
      this.LabelText = "";
      this.PlaceHolderText = "Text Field";
      this.Password = new PasswordValue(false, "*");
      this.AstrictLength = new AstrictLengthValue(false, this.LabelText.Length);
      this.TouchEnable = true;
      this.MaxLengthText = 10;
      this.Size = new CocoStudio.Model.PointF(100f, 27f);
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      TextFieldObject textFieldObject = cObject as TextFieldObject;
      if (textFieldObject == null)
        return;
      textFieldObject.Password = this.Password;
      textFieldObject.AstrictLength = this.AstrictLength;
      textFieldObject.FontResource = this.FontResource;
      textFieldObject.FontSize = this.FontSize;
      textFieldObject.LabelText = this.LabelText;
      textFieldObject.PlaceHolderText = this.PlaceHolderText;
      textFieldObject.Size = this.Size;
    }

    protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
    {
      TextEditorWindow textEditorWindow = new TextEditorWindow((object) this, "PlaceHolderText", (string) null, "FontSize", false);
    }
  }
}
