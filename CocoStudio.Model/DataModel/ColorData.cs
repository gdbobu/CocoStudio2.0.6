// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ColorData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (Color))]
  public sealed class ColorData : BaseObjectData, IDataConvert
  {
    [DefaultValue(255)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 255)]
    public byte A { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 255)]
    [DefaultValue(255)]
    public byte R { get; set; }

    [DefaultValue(255)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 255)]
    public byte G { get; set; }

    [DefaultValue(255)]
    [ItemProperty(DefaultValue = 255)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public byte B { get; set; }

    public ColorData()
    {
    }

    public ColorData(Color color)
      : this(color.A, color.R, color.G, color.B)
    {
    }

    public ColorData(byte a, byte r, byte g, byte b)
    {
      this.A = a;
      this.R = r;
      this.G = g;
      this.B = b;
    }

    public static implicit operator ColorData(Color color)
    {
      return new ColorData(color);
    }

    public static implicit operator Color(ColorData color)
    {
      return Color.FromArgb((int) byte.MaxValue, (int) color.R, (int) color.G, (int) color.B);
    }

    public object CreateViewModel()
    {
      return (object) (Color) this;
    }

    public void SetData(object viewObject)
    {
      if (!(viewObject is Color))
        throw new ArgumentException("Can only receive System.Drawing.Color object to apply value.");
      Color color = (Color) viewObject;
      this.A = color.A;
      this.R = color.R;
      this.G = color.G;
      this.B = color.B;
    }

    public override bool Equals(object obj)
    {
      ColorData colorData = obj as ColorData;
      return colorData != null && (int) this.R == (int) colorData.R && ((int) this.G == (int) colorData.G && (int) this.B == (int) colorData.B) && (int) this.A == (int) colorData.A;
    }
  }
}
