// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TextAtlasObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_Deprecated", 2, 0)]
  [DisplayName("Display_Component_UILableAtlas")]
  [ModelExtension(true, 4)]
  public class TextAtlasObject : WidgetObject
  {
    private ResourceFile file = (ResourceFile) null;
    private string _startChar = "";
    private string _labelText = "";

    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [ResourceFilter(EnumResourceType.Normal, new string[] {"png", "jpg"})]
    [UndoProperty]
    [DefaultValue(null)]
    [DisplayName("Display_TagImage")]
    [Category("Group_Feature")]
    [PropertyOrder(53)]
    public virtual ResourceFile LabelAtlasFileImage_CNB
    {
      get
      {
        return this.file;
      }
      set
      {
        if (value != null && !(value is ImageFile))
          return;
        this.file = value;
        if (this.file == null || !this.file.IsValid)
          this.file = (ResourceFile) new ImageFile((ResourceData) TextAtlasObjectData.DefaultFile);
        using (CompositeTask.Run("刷新数字标签的资源"))
        {
          this.GetInnerWidget().SetAtlasFile(this.file.GetResourceData());
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.CharWidth));
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.CharHeight));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.LabelAtlasFileImage_CNB));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
        }
      }
    }

    [DisplayName("Display_LabelFirstChar")]
    [UndoProperty]
    [Category("Group_Feature")]
    [DefaultValue("")]
    [Browsable(false)]
    [PropertyOrder(55)]
    public virtual string StartChar
    {
      get
      {
        return this.GetInnerWidget().GetStartChar();
      }
      set
      {
        if (!(this.GetInnerWidget().GetStartChar() != value))
          return;
        this._startChar = value;
        this.GetInnerWidget().SetStartChar(value);
        using (CompositeTask.Run("刷新数字标签的起始字符"))
        {
          this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.StartChar));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
        }
      }
    }

    [ValueRange(0, 2147483647, 1.0)]
    [UndoProperty]
    [DisplayName("Display_LabelCharWidth")]
    [Category("Group_Feature")]
    [DefaultValue(12)]
    [Browsable(false)]
    [PropertyOrder(56)]
    public virtual int CharWidth
    {
      get
      {
        return this.GetInnerWidget().GetCharacterWidth();
      }
      set
      {
        if (this.GetInnerWidget().GetCharacterWidth() == value || value < 0)
          return;
        this.GetInnerWidget().SetCharacterWidth(value);
        using (CompositeTask.Run("刷新数字标签的字符宽"))
        {
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.CharWidth));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
        }
      }
    }

    [Browsable(false)]
    [PropertyOrder(57)]
    [ValueRange(0, 2147483647, 1.0)]
    [UndoProperty]
    [DisplayName("Display_LabelCharHeight")]
    [Category("Group_Feature")]
    [DefaultValue(12)]
    public virtual int CharHeight
    {
      get
      {
        return this.GetInnerWidget().GetCharacterHeight();
      }
      set
      {
        if (this.GetInnerWidget().GetCharacterHeight() == value || value < 0)
          return;
        this.GetInnerWidget().SetCharacterHeight(value);
        using (CompositeTask.Run("刷新数字标签的字符高"))
        {
          this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.CharHeight));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
        }
      }
    }

    [DefaultValue("")]
    [System.ComponentModel.Editor(typeof (NumberEntryEditor), typeof (NumberEntryEditor))]
    [UndoProperty]
    [PropertyOrder(58)]
    [DisplayName("Display_Text")]
    [Category("Group_Feature")]
    public virtual string LabelText
    {
      get
      {
        return this.GetInnerWidget().GetText();
      }
      set
      {
        if (!(this.GetInnerWidget().GetText() != value))
          return;
        this._labelText = value;
        this.GetInnerWidget().SetText(value);
        using (CompositeTask.Run("刷新数字标签的文本"))
        {
          if (string.IsNullOrEmpty(value))
            this.Size = new PointF(0.0f, this.Size.Y);
          this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.LabelText));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
        }
      }
    }

    [Category("Group_Feature")]
    [PropertyOrder(54)]
    [DefaultValue("")]
    [System.ComponentModel.Editor(typeof (LabelTooltipEditor), typeof (LabelTooltipEditor))]
    [DisplayName("")]
    public string LabelToop
    {
      get
      {
        return LanguageInfo.TextAtlasResourceExplain;
      }
    }

    public TextAtlasObject()
    {
    }

    public TextAtlasObject(CSTextAtlas customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSTextAtlas GetInnerWidget()
    {
      return (CSTextAtlas) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSTextAtlas();
    }

    protected override void InitData()
    {
      base.InitData();
      this.LabelAtlasFileImage_CNB = (ResourceFile) null;
      this.StartChar = ".";
      this.LabelText = "./0123456789";
      this.CharWidth = 14;
      this.CharHeight = 18;
      this.Name = "AtlasLabel_" + (object) this.ObjectIndex;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      TextAtlasObject textAtlasObject = cObject as TextAtlasObject;
      if (textAtlasObject == null)
        return;
      textAtlasObject.LabelAtlasFileImage_CNB = this.LabelAtlasFileImage_CNB;
      textAtlasObject.StartChar = this.StartChar;
      textAtlasObject.CharWidth = this.CharWidth;
      textAtlasObject.CharHeight = this.CharHeight;
      textAtlasObject.LabelText = this.LabelText;
    }

    protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
    {
      TextEditorWindow textEditorWindow = new TextEditorWindow((object) this, "LabelText", (string) null, (string) null, false);
    }
  }
}
