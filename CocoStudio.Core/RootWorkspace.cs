// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.RootWorkspace
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.Projects;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using MonoDevelop.Core.ProgressMonitoring;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CocoStudio.Core
{
  public class RootWorkspace
  {
    public ObservableCollection<WorkspaceItem> Items { get; private set; }

    public event EventHandler<EventArgs> LoadWorkspaceItemSuccessedEvent;

    public RootWorkspace()
    {
      this.Items = new ObservableCollection<WorkspaceItem>();
    }

    public void Save(IProgressMonitor monitor)
    {
      monitor.BeginTask("Saving workspace...", this.Items.Count);
      Services.Workbench.SaveAll();
      foreach (WorkspaceItem workspaceItem in (Collection<WorkspaceItem>) this.Items)
      {
        workspaceItem.Save(monitor);
        monitor.Step(1);
      }
      monitor.EndTask();
      LogConfig.Output.Info((object) LanguageInfo.Output_Saved);
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IAsyncOperation OpenWorkspaceItem(string filePath)
    {
      Solution selectedSolution = Services.ProjectOperations.CurrentSelectedSolution;
      if (selectedSolution != null && Path.GetFullPath((string) selectedSolution.FileName).Equals(Path.GetFullPath(filePath)))
        return (IAsyncOperation) null;
      IProgressMonitor monitor = Services.MainWindow != null ? Services.ProgressMonitors.GetConsoleProgressMonitor(false) : (IProgressMonitor) new SimpleProgressMonitor();
      if (this.Items.Count > 0)
      {
        if (MessageBox.Show(LanguageInfo.MessageBox172_AskCloseCurSln, MessageBoxButton.YesNo, (Window) null, (string) null, MessageBoxImage.Info) != MessageBoxResult.Yes)
          return monitor.AsyncOperation;
        this.CloseWorkspaceItem(this.Items[0], false);
      }
      this.LoadWorkspaceItem(monitor, filePath);
      return monitor.AsyncOperation;
    }

    private void LoadWorkspaceItem(IProgressMonitor monitor, string filePath)
    {
      if (!File.Exists(filePath))
      {
        monitor.ReportError("File not found." + filePath, (Exception) null);
      }
      else
      {
        Solution solution = Services.ProjectOperations.OpenSolution(monitor, filePath);
        if (solution == null)
          return;
        SolutionLockHandler.Instance.TryLockSolution(filePath);
        this.Items.Add((WorkspaceItem) solution);
        int num = (int) GLib.Timeout.Add(100U, (TimeoutHandler) (() =>
        {
          if (this.LoadWorkspaceItemSuccessedEvent != null)
            this.LoadWorkspaceItemSuccessedEvent((object) this, EventArgs.Empty);
          return false;
        }));
      }
    }

    public void CloseWorkspaceItem(WorkspaceItem item, bool isForceClose = false)
    {
      if (item == null)
        return;
      IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
      item.Save(consoleProgressMonitor);
      foreach (Document document in Services.Workbench.Documents.ToArray<Document>())
        document.Close(isForceClose);
      SolutionLockHandler.Instance.ReleaseLock();
      this.Items.Remove(item);
      item.Dispose();
    }

    public void SaveCurrentSolution()
    {
      Services.ProjectOperations.CurrentSelectedSolution.Save(Services.ProgressMonitors.Default);
    }
  }
}
