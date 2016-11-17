// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.GtkInvokeHelp
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using GLib;
using System;

namespace CocoStudio.EngineAdapterWrap
{
  public class GtkInvokeHelp
  {
    private const int timeSpan = 500;

    public static void BeginInvoke(Action action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      int num = (int) Timeout.Add(500U, (TimeoutHandler) (() =>
      {
        action();
        return false;
      }));
    }
  }
}
