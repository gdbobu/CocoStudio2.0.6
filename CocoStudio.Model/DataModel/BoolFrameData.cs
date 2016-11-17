// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.BoolFrameData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (BoolFrame))]
  [MonoDevelop.Core.Serialization.DataItem(Name = "BoolFrame")]
  public class BoolFrameData : FrameData
  {
    [JsonProperty]
    [ItemProperty]
    public bool Value { get; set; }

    public override bool FrameEquals(FrameData framedata)
    {
      BoolFrameData boolFrameData = framedata as BoolFrameData;
      return boolFrameData != null && base.FrameEquals(framedata) && this.Value == boolFrameData.Value;
    }
  }
}
