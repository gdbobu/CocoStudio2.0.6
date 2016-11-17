// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.IMainWindow
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Core.View
{
  public interface IMainWindow : IWindowClosed
  {
    IViewService ViewService { get; }

    event EventHandler<CancelEventArgs> Closing;

    event EventHandler<EventArgs> Closed;

    event EventHandler ActiveWorkbenchWindowChanged;

    bool Close();

    bool Quit();
  }
}
