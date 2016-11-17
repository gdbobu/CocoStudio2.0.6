// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.EditorInfo
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;

namespace CocoStudio.UserStatistics
{
  public class EditorInfo
  {
    public string Type { get; private set; }

    public Version Version { get; private set; }

    public EditorInfo(string type, Version version)
    {
      this.Type = type;
      this.Version = version;
    }
  }
}
