// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.PointFrameData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [MonoDevelop.Core.Serialization.DataItem(Name = "PointFrame")]
  [DataModelExtension(typeof (PointFrame))]
  public class PointFrameData : FrameData
  {
    [JsonProperty]
    [ItemProperty]
    public float X { get; set; }

    [JsonProperty]
    [ItemProperty]
    public float Y { get; set; }

    public override bool FrameEquals(FrameData framedata)
    {
      PointFrameData pointFrameData = framedata as PointFrameData;
      return pointFrameData != null && base.FrameEquals(framedata) && FrameData.IsFloatEqual(this.X, pointFrameData.X, 0.0001f) && FrameData.IsFloatEqual(this.Y, pointFrameData.Y, 0.0001f);
    }
  }
}
