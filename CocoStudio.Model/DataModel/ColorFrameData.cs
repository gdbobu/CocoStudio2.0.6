// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ColorFrameData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [MonoDevelop.Core.Serialization.DataItem(Name = "ColorFrame")]
  [DataModelExtension(typeof (ColorFrame))]
  public class ColorFrameData : FrameData
  {
    [ItemProperty]
    [JsonProperty]
    public int Alpha { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ColorData Color { get; set; }

    public override bool FrameEquals(FrameData framedata)
    {
      ColorFrameData colorFrameData = framedata as ColorFrameData;
      return colorFrameData != null && base.FrameEquals(framedata) && this.Alpha == colorFrameData.Alpha && this.Color.Equals((object) colorFrameData.Color);
    }
  }
}
