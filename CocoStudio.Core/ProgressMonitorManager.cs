// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ProgressMonitorManager
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.ProgressMonitors;
using MonoDevelop.Core;
using MonoDevelop.Core.ProgressMonitoring;

namespace CocoStudio.Core
{
  public class ProgressMonitorManager
  {
    public IProgressMonitor Default
    {
      get
      {
        return this.GetConsoleProgressMonitor(false);
      }
    }

    internal void Initialize()
    {
    }

    public IProgressMonitor GetProgressMonitor()
    {
      return this.GetConsoleProgressMonitor(false);
    }

    internal IProgressMonitor GetStatusProgressMonitor()
    {
      return this.GetConsoleProgressMonitor(false);
    }

    public IProgressMonitor GetSimpleProgressMonitor()
    {
      return (IProgressMonitor) new SimpleProgressMonitor();
    }

    public IProgressMonitor GetConsoleProgressMonitor(bool isWriteLog = false)
    {
      return (IProgressMonitor) new ConsoleProgressFullExceptionMonitor(isWriteLog);
    }

    public MessageDialogProgressMonitor GetMessageDialogProgreeMonitor()
    {
      return new MessageDialogProgressMonitor(true, true, true, false);
    }
  }
}
