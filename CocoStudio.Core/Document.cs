// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Document
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.View;
using CocoStudio.Projects;
using CocoStudio.UndoManager;
using System;

namespace CocoStudio.Core
{
  public class Document : IEditableDocument
  {
    public IDocumentWindow Window { get; private set; }

    public bool IsDirty
    {
      get
      {
        return !this.Window.ViewContent.IsViewOnly && (this.Window.ViewContent.ContentName == null || this.Window.ViewContent.IsDirty);
      }
      set
      {
        this.Window.ViewContent.IsDirty = value;
      }
    }

    public string Name
    {
      get
      {
        IViewContentExtend viewContent = this.Window.ViewContent;
        return viewContent.IsUntitled ? viewContent.UntitledName : viewContent.ContentName;
      }
    }

    public Project Project
    {
      get
      {
        return this.Window != null ? this.Window.ViewContent.Project : (Project) null;
      }
    }

    public DateTime LastTimeActive { get; set; }

    public Document(IDocumentWindow window)
    {
      this.Window = window;
    }

    public void Save()
    {
      if (this.Window.ViewContent.IsViewOnly || !this.Window.ViewContent.IsDirty || !this.Window.ViewContent.IsFile)
        return;
      this.Window.ViewContent.Save();
    }

    internal void OnDocumentAttached()
    {
    }

    public void RunWhenLoaded(Action action)
    {
      action();
    }

    internal void SetProject(Project newProject)
    {
      if (this.Project != null)
        this.Project.NameChanged -= new EventHandler<EventArgs>(this.OnProjectNameChanged);
      if (this.Window == null || this.Window.ViewContent == null)
        return;
      this.Window.ViewContent.Project = newProject;
      if (newProject == null)
        return;
      newProject.NameChanged += new EventHandler<EventArgs>(this.OnProjectNameChanged);
    }

    private void OnProjectNameChanged(object sender, EventArgs e)
    {
      this.Window.ViewContent.ContentName = this.Project.Name;
    }

    internal void Select()
    {
      this.Window.SelectWindow();
    }

    public void Close(bool force = false)
    {
      this.Window.CloseWindow(force);
    }

    private void OnViewChanged(EventArgs args)
    {
    }

    internal void DisposeDocument()
    {
      this.SetProject((Project) null);
    }
  }
}
