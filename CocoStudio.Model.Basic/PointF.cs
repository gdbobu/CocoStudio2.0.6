// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.PointF
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

using Gdk;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model
{
  [JsonObject(MemberSerialization.OptIn)]
  [Serializable]
  public sealed class PointF : ICloneable
  {
    private float x;
    private float y;

    [ItemProperty]
    [JsonProperty]
    public float X
    {
      get
      {
        return this.x;
      }
      set
      {
        this.x = value;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public float Y
    {
      get
      {
        return this.y;
      }
      set
      {
        this.y = value;
      }
    }

    public PointF()
    {
    }

    public PointF(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    public PointF(Point p)
    {
      this.x = (float) p.X;
      this.y = (float) p.Y;
    }

    public static implicit operator PointF(Point p)
    {
      return new PointF(p);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is PointF))
        return false;
      PointF pointF = (PointF) obj;
      return obj != null && (double) this.X == (double) pointF.X && (double) this.Y == (double) pointF.Y;
    }

    public override int GetHashCode()
    {
      float num = this.X;
      int hashCode1 = num.GetHashCode();
      num = this.Y;
      int hashCode2 = num.GetHashCode();
      return hashCode1 ^ hashCode2;
    }

    public object Clone()
    {
      return (object) new PointF() { X = this.X, Y = this.Y };
    }
  }
}
