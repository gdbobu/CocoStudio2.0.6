// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ScaleValue
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model
{
  [JsonObject(MemberSerialization.OptIn)]
  public sealed class ScaleValue
  {
    public static ScaleValue Empty = new ScaleValue(0.0f, 0.0f, 0.1, -99999999.0, 99999999.0);
    private bool canSetX;
    private bool canSetY;
    private double increment;
    private double minValue;
    private double maxValue;

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0.0f)]
    [DefaultValue(0.0f)]
    public float ScaleX { get; set; }

    [DefaultValue(0.0f)]
    [ItemProperty(DefaultValue = 0.0f)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public float ScaleY { get; set; }

    public bool CanSetX
    {
      get
      {
        return !this.canSetX;
      }
      set
      {
        this.canSetX = value;
      }
    }

    public bool CanSetY
    {
      get
      {
        return !this.canSetY;
      }
      set
      {
        this.canSetY = value;
      }
    }

    public double Increment
    {
      get
      {
        return this.increment;
      }
      set
      {
        if (this.increment == value)
          return;
        this.increment = value;
      }
    }

    public double MinValue
    {
      get
      {
        return this.minValue;
      }
      set
      {
        if (this.minValue == value)
          return;
        this.minValue = value;
      }
    }

    public double MaxValue
    {
      get
      {
        return this.maxValue;
      }
      set
      {
        if (this.maxValue == value)
          return;
        this.maxValue = value;
      }
    }

    public ScaleValue()
    {
      this.ScaleX = 0.0f;
      this.ScaleY = 0.0f;
    }

    public ScaleValue(float scaleX, float scaleY, double increment = 0.1, double minValue = -99999999.0, double maxValue = 99999999.0)
    {
      this.ScaleX = scaleX;
      this.ScaleY = scaleY;
      this.Increment = increment;
      this.MinValue = minValue;
      this.MaxValue = maxValue;
    }

    public ScaleValue(float zoom)
    {
      this.ScaleX = this.ScaleY = zoom;
    }

    public static explicit operator double(ScaleValue scaleValue)
    {
      return Math.Sqrt(Math.Pow((double) scaleValue.ScaleX, 2.0) + Math.Pow((double) scaleValue.ScaleY, 2.0));
    }

    public override string ToString()
    {
      return ((double) this.ScaleX).ToString() + "," + (object) this.ScaleY;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is ScaleValue))
        return false;
      ScaleValue scaleValue = (ScaleValue) obj;
      return obj != null && (double) this.ScaleX == (double) scaleValue.ScaleX && (double) this.ScaleY == (double) scaleValue.ScaleY;
    }

    public override int GetHashCode()
    {
      float num = this.ScaleX;
      int hashCode1 = num.GetHashCode();
      num = this.ScaleY;
      int hashCode2 = num.GetHashCode();
      return hashCode1 ^ hashCode2;
    }
  }
}
