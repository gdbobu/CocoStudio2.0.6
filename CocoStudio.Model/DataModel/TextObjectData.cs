// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TextObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (TextObject))]
  [DataInclude(typeof (TextHorizontalType))]
  [DataInclude(typeof (TextVerticalType))]
  public class TextObjectData : WidgetObjectData
  {
    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool FlipX { get; set; }

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool FlipY { get; set; }

    [ItemProperty]
    [JsonProperty]
    public int FontSize { get; set; }

    [ItemProperty]
    [JsonProperty]
    public string LabelText { get; set; }

    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool IsCustomSize { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData FontResource { get; set; }

    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    public bool TouchScaleChangeAble { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = TextHorizontalType.HT_Left)]
    [DefaultValue(TextHorizontalType.HT_Left)]
    public TextHorizontalType HorizontalAlignmentType { get; set; }

    [DefaultValue(TextVerticalType.VT_Top)]
    [ItemProperty(DefaultValue = TextVerticalType.VT_Top)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public TextVerticalType VerticalAlignmentType { get; set; }

    public TextObjectData()
    {
      this.IsCustomSize = false;
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      TextObject textObject = vObject as TextObject;
      if (textObject == null || (!this.IsCustomSize || !((ResourceData) this.FontResource != (ResourceData) null) || textObject.FontResource.GetResourceData().Type != this.FontResource.Type) && this.IsCustomSize)
        return;
      textObject.Size = this.Size;
    }
  }
}
