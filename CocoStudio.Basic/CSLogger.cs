// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.CSLogger
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using log4net;
using System;

namespace CocoStudio.Basic
{
  internal class CSLogger : ICSLog
  {
    private bool isOutput;

    private static ILog Log
    {
      get
      {
        return Log4Wrap.Logger;
      }
    }

    public event Action<string> Output = param0 => {};

    internal CSLogger(bool isOutput)
    {
      this.isOutput = true;
    }

    private void RaiseOutput(object message)
    {
      if (message == null || !this.isOutput)
        return;
      this.Output(message.ToString());
    }

    public void Debug(object message)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Debug(message);
    }

    public void Debug(object message, Exception exception)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Debug(message, exception);
    }

    public void Error(object message)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Error(message);
    }

    public void Error(object message, Exception exception)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Error(message, exception);
    }

    public void Info(object message)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Info(message);
    }

    public void Info(object message, Exception exception)
    {
      this.RaiseOutput(message);
      CSLogger.Log.Info(message, exception);
    }
  }
}
