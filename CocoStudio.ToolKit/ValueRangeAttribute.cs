// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ValueRangeAttribute
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
  public sealed class ValueRangeAttribute : Attribute
  {
    public int MaxValue { get; set; }

    public int MinValue { get; set; }

    public double Step { get; set; }

    public ValueRangeAttribute(int min = 0, int max = 2147483647, double step = 1.0)
    {
      this.MaxValue = max;
      this.MinValue = min;
      this.Step = step;
    }
  }
}
