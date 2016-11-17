// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TextAtlasObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (TextAtlasObject))]
  public class TextAtlasObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/TextAtlas.png");
    private static readonly PointF defaultTextSize = new PointF(168f, 18f);
    private ResourceItemData labelAtlasFileImage_CNB;

    [ItemProperty]
    [JsonProperty]
    public int CharWidth { get; set; }

    [ItemProperty]
    [JsonProperty]
    public int CharHeight { get; set; }

    [JsonProperty]
    [ItemProperty]
    public string LabelText { get; set; }

    [JsonProperty]
    [ItemProperty]
    public string StartChar { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData LabelAtlasFileImage_CNB
    {
      get
      {
        return this.labelAtlasFileImage_CNB;
      }
      set
      {
        this.labelAtlasFileImage_CNB = value;
        if (!((ResourceData) this.labelAtlasFileImage_CNB == (ResourceData) null))
          return;
        this.labelAtlasFileImage_CNB = TextAtlasObjectData.DefaultFile;
        this.Size = TextAtlasObjectData.defaultTextSize;
      }
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      TextAtlasObject textAtlasObject = vObject as TextAtlasObject;
      if (textAtlasObject == null || (!((ResourceData) this.LabelAtlasFileImage_CNB != (ResourceData) null) || textAtlasObject.LabelAtlasFileImage_CNB.GetResourceData().Type == this.LabelAtlasFileImage_CNB.Type) && textAtlasObject.LabelAtlasFileImage_CNB.GetResourceData().Type != EnumResourceType.Default)
        return;
      textAtlasObject.LabelAtlasFileImage_CNB = (ResourceFile) null;
    }
  }
}
