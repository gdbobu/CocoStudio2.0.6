// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.BoolEvent
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  public class BoolEvent : EventArgs
  {
    public bool IsCheck { get; set; }

    public string Text { get; set; }

    public double Value { get; set; }

    public BoolEvent(bool isCheck, string text, double num)
    {
      this.IsCheck = isCheck;
      this.Text = text;
      this.Value = num;
    }
  }
}
