// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TextFieldObjectData
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
  [DataModelExtension(typeof (TextFieldObject))]
  public class TextFieldObjectData : WidgetObjectData
  {
    [ItemProperty]
    [JsonProperty]
    public ResourceItemData FontResource { get; set; }

    [ItemProperty]
    [JsonProperty]
    public int FontSize { get; set; }

    [JsonProperty]
    [ItemProperty]
    public bool IsCustomSize { get; set; }

    [JsonProperty]
    [ItemProperty]
    public string LabelText { get; set; }

    [ItemProperty]
    [JsonProperty]
    public string PlaceHolderText { get; set; }

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool MaxLengthEnable { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int MaxLengthText { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    public bool PasswordEnable { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = "*")]
    [DefaultValue("*")]
    public string PasswordStyleText { get; set; }

    public TextFieldObjectData()
    {
      this.IsCustomSize = true;
    }
  }
}
