// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.ICSLog
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using System;

namespace CocoStudio.Basic
{
  public interface ICSLog
  {
    event Action<string> Output;

    void Debug(object message);

    void Debug(object message, Exception exception);

    void Error(object message);

    void Error(object message, Exception exception);

    void Info(object message);

    void Info(object message, Exception exception);
  }
}
