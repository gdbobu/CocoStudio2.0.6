// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.PanelObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (PanelObject))]
  public class PanelObjectData : WidgetObjectData
  {
    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool ClipAble { get; set; }

    [DefaultValue(255)]
    [ItemProperty(DefaultValue = 255)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int BackColorAlpha { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData FileData { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int ComboBoxIndex { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ColorData SingleColor { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ColorData FirstColor { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ColorData EndColor { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ScaleValue ColorVector { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public float ColorAngle { get; set; }

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool Scale9Enable { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int LeftEage { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    public int RightEage { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int TopEage { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int BottomEage { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int Scale9OriginX { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    public int Scale9OriginY { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    public int Scale9Width { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    public int Scale9Height { get; set; }

    public PanelObjectData()
    {
      this.BackColorAlpha = (int) byte.MaxValue;
      this.SingleColor = (ColorData) Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    public PanelObjectData(bool bWithColor)
      : this()
    {
      this.ComboBoxIndex = bWithColor ? 1 : 0;
    }
  }
}
