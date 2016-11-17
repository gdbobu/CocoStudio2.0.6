// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.UIControlEvent
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  public class UIControlEvent : EventArgs
  {
    public string Name { get; set; }

    public bool IsCheck { get; set; }

    public double UIValue { get; set; }

    public UIControlEvent(string name, bool isCheck, double value = 0.0)
    {
      this.Name = name;
      this.IsCheck = isCheck;
      this.UIValue = value;
    }
  }
}
