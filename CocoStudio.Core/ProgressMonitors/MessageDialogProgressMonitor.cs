// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ProgressMonitors.MessageDialogProgressMonitor
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.ControlLib;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Ide;
using MonoDevelop.Ide.ProgressMonitoring;
using System;

namespace CocoStudio.Core.ProgressMonitors
{
  public class MessageDialogProgressMonitor : BaseProgressMonitor
  {
    private ProgressDialog dialog;
    private bool hideWhenDone;
    private bool showDetails;

    public MessageDialogProgressMonitor(bool showProgress = true, bool allowCancel = true, bool showDetails = true, bool hideWhenDone = false)
    {
      if (!showProgress)
        return;
      this.dialog = new ProgressDialog(MessageService.RootWindow, allowCancel, showDetails);
      this.dialog.SetToDialogStyle(MessageService.RootWindow, true, true, true);
      this.dialog.Message = "";
      this.dialog.Show();
      this.dialog.AsyncOperation = this.AsyncOperation;
      this.dialog.OperationCancelled += (EventHandler) ((param0, param1) => this.OnCancelRequested());
      this.dialog.DeleteEvent += (DeleteEventHandler) ((param0, param1) => this.OnCancelRequested());
      this.RunPendingEvents();
      this.hideWhenDone = hideWhenDone;
      this.showDetails = showDetails;
    }

    protected override void OnWriteLog(string text)
    {
      if (this.dialog == null)
        return;
      this.dialog.WriteText(text);
      this.RunPendingEvents();
    }

    protected override void OnProgressChanged()
    {
      if (this.dialog == null)
        return;
      int num = (int) GLib.Timeout.Add(0U, (TimeoutHandler) (() =>
      {
        this.dialog.Message = this.CurrentTask;
        this.dialog.Progress = this.GlobalWork;
        this.RunPendingEvents();
        return false;
      }));
    }

    public override void BeginTask(string name, int totalWork)
    {
      if (this.dialog != null)
        this.dialog.BeginTask(name);
      base.BeginTask(name, totalWork);
    }

    public override void BeginStepTask(string name, int totalWork, int stepSize)
    {
      if (this.dialog != null)
        this.dialog.BeginTask(name);
      base.BeginStepTask(name, totalWork, stepSize);
    }

    public override void EndTask()
    {
      if (this.dialog != null)
        this.dialog.EndTask();
      base.EndTask();
      this.RunPendingEvents();
    }

    public override void ReportWarning(string message)
    {
      base.ReportWarning(message);
      if (this.dialog == null)
        return;
      this.dialog.WriteText(LanguageInfo.MessageBox_Notification + ": " + message + "\n");
      this.RunPendingEvents();
    }

    public override void ReportError(string message, Exception ex)
    {
      base.ReportError(message, ex);
      if (this.dialog == null)
        return;
      this.dialog.WriteText(LanguageInfo.MessageBox_Error + ": " + this.Errors[this.Errors.Count - 1] + "\n");
      this.RunPendingEvents();
    }

    protected override void OnCompleted()
    {
      DispatchService.GuiDispatch(new MessageHandler(this.ShowDialogs));
      base.OnCompleted();
    }

    private void ShowDialogs()
    {
      if (this.dialog != null)
      {
        this.dialog.ShowDone(this.Warnings.Count > 0, this.Errors.Count > 0);
        if (this.hideWhenDone)
          this.dialog.Destroy();
      }
      if (this.showDetails)
        return;
      this.ShowResultDialog();
    }

    public void CloseDialogs()
    {
      this.dialog.Destroy();
    }
  }
}
