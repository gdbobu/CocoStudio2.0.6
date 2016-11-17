// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.DocumentWindow
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.View;
using Gtk;
using MonoDevelop.Components.DockNotebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CocoStudio.Core
{
  public class DocumentWindow : EventBox, IDocumentWindow, ITabContent
  {
    private bool show_notification = false;
    private VBox box;
    private MainWindow workbench;
    private MonoDevelop.Components.DockNotebook.DockNotebook tabControl;
    private IViewContentExtend content;
    private DockNotebookTab tab;
    private Widget tabPage;
    private string _titleHolder;

    public string Title
    {
      get
      {
        return this._titleHolder;
      }
      set
      {
        this._titleHolder = value;
        if (this.content.ContentName == null)
        {
          string untitledName = this.content.UntitledName;
        }
        this.OnTitleChanged((EventArgs) null);
      }
    }

    public IViewContentExtend ViewContent
    {
      get
      {
        return this.content;
      }
    }

    public string DocumentType { get; set; }

    public event EventHandler TitleChanged;

    public event EventHandler<DocumentWindowEventArgs> Closed;

    public event EventHandler<DocumentWindowEventArgs> Closing;

    public DocumentWindow(MainWindow workbench, IViewContentExtend content, MonoDevelop.Components.DockNotebook.DockNotebook tabControl, DockNotebookTab tabLabel)
    {
      this.workbench = workbench;
      this.tabControl = tabControl;
      this.content = content;
      this.tab = tabLabel;
      this.tabPage = content.Control;
      content.WorkbenchWindow = (IDocumentWindow) this;
      this.box = new VBox();
      this.box.PackStart(content.Control, true, true, 0U);
      this.box.Show();
      this.Add((Widget) this.box);
      content.ContentNameChanged += new EventHandler(this.SetTitleEvent);
      content.DirtyChanged += new EventHandler(this.HandleDirtyChanged);
      content.ContentChanged += new EventHandler(this.OnContentChanged);
      content.BeforeSave += new EventHandler(this.OnBeforeSave);
      this.SetTitleEvent((object) null, (EventArgs) null);
    }

    private void SetTitleEvent(object sender, EventArgs e)
    {
      if (this.content == null)
        return;
      string fileName = System.IO.Path.GetFileName(this.content.ContentName);
      if (this.content.IsDirty)
      {
        if (!string.IsNullOrEmpty(this.content.ContentName))
          Services.ProjectOperations.MarkFileDirty(this.content.ContentName);
      }
      else if (this.content.IsReadOnly)
        fileName += "+";
      if (!(fileName != this.Title))
        return;
      this.Title = fileName;
    }

    private void HandleDirtyChanged(object sender, EventArgs e)
    {
      this.OnTitleChanged((EventArgs) null);
    }

    public void SelectWindow()
    {
      this.tabControl.CurrentTabIndex = this.tab.Index;
      if (this.tabControl.FocusChild != null)
        this.tabControl.FocusChild.GrabFocus();
      else
        DocumentWindow.DeepGrabFocus(this.content.Control);
    }

    private void OnContentChanged(object sender, EventArgs e)
    {
    }

    private static void DeepGrabFocus(Widget widget)
    {
      Widget widget1 = (Widget) null;
      foreach (Widget focussableWidget in DocumentWindow.GetFocussableWidgets(widget))
      {
        if (focussableWidget.HasFocus)
          return;
        if (widget1 == null)
          widget1 = focussableWidget;
      }
      if (widget1 == null)
        return;
      widget1.GrabFocus();
    }

    private static IEnumerable<Widget> GetFocussableWidgets(Widget widget)
    {
      Container c = widget as Container;
      if (widget.CanFocus)
        yield return widget;
      if (c != null)
      {
        foreach (Widget widget1 in ((IEnumerable<Widget>) c.FocusChain).SelectMany<Widget, Widget>((Func<Widget, IEnumerable<Widget>>) (x => DocumentWindow.GetFocussableWidgets(x))).Where<Widget>((Func<Widget, bool>) (y => y != null)))
          yield return widget1;
      }
    }

    public bool CloseWindow(bool force)
    {
      return this.CloseWindow(force, false);
    }

    public bool CloseWindow(bool force, bool animate)
    {
      bool wasActive = this.workbench.ActiveWorkbenchWindow == this;
      DocumentWindowEventArgs e = new DocumentWindowEventArgs(force, wasActive);
      e.Cancel = false;
      this.OnClosing(e);
      if (e.Cancel)
        return false;
      this.workbench.RemoveTab(this.tabControl, this.tab.Index, animate);
      this.OnClosed(e);
      this.box.Remove(this.content.Control);
      this.Destroy();
      return true;
    }

    protected virtual void OnClosing(DocumentWindowEventArgs e)
    {
      if (this.Closing == null)
        return;
      this.Closing((object) this, e);
    }

    protected virtual void OnClosed(DocumentWindowEventArgs e)
    {
      this.ViewContent.Closed();
      if (this.Closed == null)
        return;
      this.Closed((object) this, e);
    }

    protected virtual void OnTitleChanged(EventArgs e)
    {
      this.tab.Text = this.Title;
      this.tab.Notify = this.show_notification;
      this.tab.Dirty = this.content.IsDirty;
      if (this.tab.Dirty)
        this.tab.Text += "*";
      if (this.content.ContentName != null && this.content.ContentName != "")
        this.tab.Tooltip = this.content.ContentName;
      if (this.TitleChanged == null)
        return;
      this.TitleChanged((object) this, e);
    }

    private void OnBeforeSave(object sender, EventArgs e)
    {
    }

    internal void OnActivated()
    {
      if (this.box.Children.Length == 0 && this.content.Control != null)
      {
        this.box.Add(this.content.Control);
        this.box.ShowAll();
      }
      this.content.Activated();
    }

    internal void OnDeactivated()
    {
      this.content.Deactivated();
      if (this.box.Children.Length <= 0 || this.content.Control == null)
        return;
      this.box.Remove(this.content.Control);
    }

    void ITabContent.BeforeRemoved()
    {
      if (!(this.content is ITabContent))
        return;
      (this.content as ITabContent).BeforeRemoved();
    }

    void ITabContent.AfterAdded()
    {
      if (!(this.content is ITabContent))
        return;
      (this.content as ITabContent).AfterAdded();
    }
  }
}
