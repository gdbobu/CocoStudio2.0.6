// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ProgressMonitors.ConsoleProgressFullExceptionMonitor
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using MonoDevelop.Core.ProgressMonitoring;
using System;

namespace CocoStudio.Core.ProgressMonitors
{
  internal class ConsoleProgressFullExceptionMonitor : NullProgressMonitor
  {
    private bool isWriteLogFile = false;

    public ConsoleProgressFullExceptionMonitor(bool isWriteLogFile = false)
    {
      this.isWriteLogFile = isWriteLogFile;
    }

    public override void ReportError(string message, Exception ex)
    {
      if (ex != null)
        message = ex.ToString();
      Console.WriteLine(message);
      if (this.isWriteLogFile)
        LogConfig.Logger.Error((object) message, ex);
      base.ReportError(message, ex);
    }
  }
}
