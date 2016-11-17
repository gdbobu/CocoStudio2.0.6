// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.FrameData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [MonoDevelop.Core.Serialization.DataItem(Name = "Frame")]
  [DataModelExtension(typeof (Frame))]
  public class FrameData : BaseObjectData
  {
    [ItemProperty]
    [JsonProperty]
    public int FrameIndex { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(true)]
    [ItemProperty(DefaultValue = true)]
    public bool Tween { get; set; }

    public FrameData()
    {
      this.Tween = true;
    }

    public virtual bool FrameEquals(FrameData framedata)
    {
      return this.Tween == framedata.Tween;
    }

    public static bool IsFloatEqual(float a, float b, float digit = 0.0001f)
    {
      return (double) Math.Abs(a - b) < (double) digit;
    }
  }
}
