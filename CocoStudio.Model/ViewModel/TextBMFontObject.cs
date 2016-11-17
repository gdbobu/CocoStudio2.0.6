// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TextBMFontObject
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
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [ModelExtension(true, 5)]
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_UILableBMFont")]
  public class TextBMFontObject : WidgetObject
  {
    private string _labelText = "";
    private ResourceFile filePath = (ResourceFile) null;

    [PropertyOrder(58)]
    [UndoProperty]
    [DefaultValue("")]
    [DisplayName("Display_Text")]
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
        this.GetInnerWidget().SetText(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.LabelText));
      }
    }

    [Category("Group_Feature")]
    [DefaultValue(null)]
    [PropertyOrder(53)]
    [UndoProperty]
    [DisplayName("Display_FNTFile")]
    [ResourceFilter(new string[] {"fnt"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public ResourceFile LabelBMFontFile_CNB
    {
      get
      {
        return this.filePath;
      }
      set
      {
        this.filePath = value;
        if (this.filePath == null || !this.filePath.IsValid)
          this.filePath = (ResourceFile) new FntFile((ResourceData) TextBMFontObjectData.DefaultFntFont);
        this.filePath.GetResourceData();
        this.GetInnerWidget().SetFntFile(this.filePath.GetResourceData());
        using (CompositeTask.Run(this.GetType().Name + "LabelBMFontFile_CNB"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.LabelBMFontFile_CNB));
        }
      }
    }

    public TextBMFontObject()
    {
    }

    public TextBMFontObject(CSTextBMFont customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSTextBMFont GetInnerWidget()
    {
      return (CSTextBMFont) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSTextBMFont();
    }

    protected override void InitData()
    {
      base.InitData();
      this.LabelBMFontFile_CNB = (ResourceFile) null;
      this.LabelText = "Fnt Text Label";
      this.Name = "BitmapFontLabel_" + (object) this.ObjectIndex;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      TextBMFontObject textBmFontObject = cObject as TextBMFontObject;
      if (textBmFontObject == null)
        return;
      textBmFontObject.LabelBMFontFile_CNB = this.LabelBMFontFile_CNB;
      textBmFontObject.LabelText = this.LabelText;
    }

    protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
    {
      TextEditorWindow textEditorWindow = new TextEditorWindow((object) this, "LabelText", "CColor", (string) null, false);
    }
  }
}
