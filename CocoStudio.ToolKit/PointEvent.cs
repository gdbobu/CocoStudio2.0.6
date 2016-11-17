// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PointEvent
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  public class PointEvent : EventArgs
  {
    public double PointX { get; set; }

    public double PointY { get; set; }

    public bool IsCheck { get; set; }

    public PointEvent(double x, double y = 0.0, bool isCheck = false)
    {
      this.PointX = x;
      this.PointY = y;
      this.IsCheck = isCheck;
    }
  }
}
