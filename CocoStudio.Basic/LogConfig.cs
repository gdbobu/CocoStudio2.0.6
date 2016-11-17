// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.LogConfig
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

namespace CocoStudio.Basic
{
  public static class LogConfig
  {
    public static ICSLog Logger { get; private set; }

    public static ICSLog Output { get; private set; }

    static LogConfig()
    {
      LogConfig.Logger = (ICSLog) new CSLogger(false);
      LogConfig.Output = (ICSLog) new CSLogger(true);
    }
  }
}
