// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TextBMFontObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (TextBMFontObject))]
  public class TextBMFontObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData DefaultFntFont = new ResourceItemData(EnumResourceType.Default, "Default/defaultBMFont.fnt");
    private static readonly PointF defaultFntSize = new PointF(162f, 36f);
    private ResourceItemData labelBMFontFile_CNB;

    [ItemProperty]
    [JsonProperty]
    public string LabelText { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData LabelBMFontFile_CNB
    {
      get
      {
        return this.labelBMFontFile_CNB;
      }
      set
      {
        this.labelBMFontFile_CNB = value;
        if (!((ResourceData) this.labelBMFontFile_CNB == (ResourceData) null))
          return;
        this.labelBMFontFile_CNB = TextBMFontObjectData.DefaultFntFont;
        this.Size = TextBMFontObjectData.defaultFntSize;
      }
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      TextBMFontObject textBmFontObject = vObject as TextBMFontObject;
      if (textBmFontObject == null || (!((ResourceData) this.labelBMFontFile_CNB != (ResourceData) null) || textBmFontObject.LabelBMFontFile_CNB.GetResourceData().Type == this.labelBMFontFile_CNB.Type))
        return;
      textBmFontObject.LabelBMFontFile_CNB = (ResourceFile) null;
    }
  }
}
