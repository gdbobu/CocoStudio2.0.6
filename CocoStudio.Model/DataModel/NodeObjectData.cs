// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.NodeObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (NodeObject))]
  public class NodeObjectData : VisualObjectData
  {
    [ItemProperty(DefaultValue = EnumCallBack.None)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(EnumCallBack.None)]
    public EnumCallBack CallBackType { get; set; }

    [ItemProperty(DefaultValue = "")]
    [DefaultValue("")]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public string CallBackName { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = "")]
    [DefaultValue("")]
    public string CustomClassName { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int Tag { get; set; }

    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int ObjectIndex { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    public bool IconVisible { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = true)]
    [DefaultValue(true)]
    public bool CascadeColor { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = true)]
    [DefaultValue(true)]
    public bool CascadeAlpha { get; set; }

    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(false)]
    public bool PrePositionEnabled { get; set; }

    [DefaultValue(LayoutRefrencePoint.BOTTOM_LEFT)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = LayoutRefrencePoint.BOTTOM_LEFT)]
    public LayoutRefrencePoint RefrencePoint { get; set; }

    [JsonProperty]
    [ItemProperty]
    public PointF PrePosition { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    public bool PreSizeEnable { get; set; }

    [JsonProperty]
    [ItemProperty]
    public PointF PreSize { get; set; }

    [ItemProperty]
    [JsonProperty]
    public List<NodeObjectData> Children { get; set; }

    public NodeObjectData()
    {
      this.CascadeColor = true;
      this.CascadeAlpha = true;
      this.CallBackType = EnumCallBack.None;
    }
  }
}
