// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.SimpleAudioObjectData
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
  [DataModelExtension(typeof (SimpleAudioObject))]
  public class SimpleAudioObjectData : NodeObjectData
  {
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0.0f)]
    [DefaultValue(0.0f)]
    public float Volume { get; set; }

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool Loop { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData FileData { get; set; }
  }
}
