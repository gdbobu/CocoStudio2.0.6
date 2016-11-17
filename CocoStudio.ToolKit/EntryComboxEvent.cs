// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EntryComboxEvent
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  public class EntryComboxEvent : EventArgs
  {
    public int Type { get; set; }

    public int EntryValue { get; set; }

    public EntryComboxEvent(int type, int text)
    {
      this.Type = type;
      this.EntryValue = text;
    }
  }
}
