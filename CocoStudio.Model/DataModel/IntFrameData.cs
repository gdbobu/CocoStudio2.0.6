// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.IntFrameData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (IntFrame))]
  [MonoDevelop.Core.Serialization.DataItem(Name = "IntFrame")]
  public class IntFrameData : FrameData
  {
    [ItemProperty]
    [JsonProperty]
    public int Value { get; set; }

    public override bool FrameEquals(FrameData framedata)
    {
      IntFrameData intFrameData = framedata as IntFrameData;
      return intFrameData != null && base.FrameEquals(framedata) && this.Value == intFrameData.Value;
    }
  }
}
