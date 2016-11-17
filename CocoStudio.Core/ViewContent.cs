// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ViewContent
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.Core.View;
using CocoStudio.Projects;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;
using System;

namespace CocoStudio.Core
{
  public class ViewContent : AbstractViewContent, IViewContentExtend, IViewContent, IBaseViewContent, IDisposable
  {
    protected Widget widget;
    private Project project;

    public IDocumentWindow WorkbenchWindow { get; set; }

    public virtual Project Project
    {
      get
      {
        return this.project;
      }
      set
      {
        this.project = value;
      }
    }

    public override Widget Control
    {
      get
      {
        return this.widget;
      }
    }

    protected ViewContent()
    {
    }

    public ViewContent(Widget widget)
    {
      this.widget = widget;
    }

    public override bool CanReuseView(string fileName)
    {
      return this.Project.FileName.ToString().Equals(fileName);
    }

    public override void Load(string fileName)
    {
    }

    public override void Save(string fileName)
    {
      this.OnSave();
      this.IsDirty = false;
      this.OnSaved();
    }

    protected virtual void OnSave()
    {
      if (this.Project == null)
        return;
      IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
      this.Project.Save(consoleProgressMonitor);
      if (!consoleProgressMonitor.AsyncOperation.Success)
        throw new InvalidOperationException("Save failed.");
      LogConfig.Output.Info((object) LanguageInfo.Output_Saved);
    }

    protected virtual void OnSaved()
    {
    }

    public void Reload(bool isShowing)
    {
      throw new NotImplementedException();
    }

    public void Activated()
    {
      this.OnActivated();
    }

    protected virtual void OnActivated()
    {
    }

    public void Deactivated()
    {
      this.OnDeactivated();
    }

    protected virtual void OnDeactivated()
    {
    }

    public void Closing()
    {
      this.OnClosing();
    }

    protected virtual void OnClosing()
    {
    }

    public void Closed()
    {
      this.OnClosed();
    }

    protected virtual void OnClosed()
    {
    }
  }
}
