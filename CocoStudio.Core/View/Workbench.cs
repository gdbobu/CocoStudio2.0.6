// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.Workbench
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using CocoStudio.UndoManager;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using MonoDevelop.Ide.Codons;
using MonoDevelop.Ide.Gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xwt.GtkBackend;

namespace CocoStudio.Core.View
{
  public class Workbench
  {
    private readonly CocoStudio.Core.ProgressMonitorManager monitors = new CocoStudio.Core.ProgressMonitorManager();
    private readonly List<CocoStudio.Core.Document> documents = new List<CocoStudio.Core.Document>();
    private MainWindow mainWindow;
    private PadCollection pads;

    public IEnumerable<CocoStudio.Core.Document> Documents
    {
      get
      {
        return (IEnumerable<CocoStudio.Core.Document>) this.documents;
      }
    }

    public PadCollection Pads
    {
      get
      {
        if (this.pads == null)
        {
          this.pads = new PadCollection(this);
          foreach (PadCodon padContent in this.mainWindow.PadContentCollection)
            this.WrapPad(padContent);
        }
        return this.pads;
      }
    }

    public CocoStudio.Core.Document ActiveDocument
    {
      get
      {
        if (this.mainWindow.ActiveWorkbenchWindow == null)
          return (CocoStudio.Core.Document) null;
        return this.WrapDocument(this.mainWindow.ActiveWorkbenchWindow);
      }
    }

    public CocoStudio.Core.ProgressMonitorManager ProgressMonitors
    {
      get
      {
        return this.monitors;
      }
    }

    public MainWindow RootWindow
    {
      get
      {
        return this.mainWindow;
      }
    }

    public event EventHandler ActiveDocumentChanged;

    public event EventHandler<DocumentEventArgs> DocumentOpened;

    public event EventHandler<DocumentEventArgs> DocumentClosed;

    public event EventHandler<DocumentEventArgs> DocumentClosing;

    internal void Initialize(IProgressMonitor monitor)
    {
      Services.Workbench = this;
      this.mainWindow = new MainWindow(string.Empty);
      ApplicationCurrent.MainWindow = (Window) Services.MainWindow;
      this.mainWindow.Initialize();
      this.mainWindow.ActiveWorkbenchWindowChanged += new EventHandler(this.OnDocumentChanged);
    }

    private void OnDocumentChanged(object sender, EventArgs e)
    {
      using (TaskServiceLock.Lock())
      {
        if (this.ActiveDocumentChanged != null)
          this.ActiveDocumentChanged(sender, e);
        if (this.ActiveDocument != null)
          this.ActiveDocument.LastTimeActive = DateTime.Now;
        Services.TaskService.SetCurrentDocument((IEditableDocument) this.ActiveDocument);
      }
    }

    internal void Show(string title)
    {
      this.RootWindow.Title = title;
      this.RootWindow.Realize();
      this.RootWindow.ShowAll();
      this.RootWindow.Show();
      this.RootWindow.CurrentLayout = "DefaultLayout";
      if (MonoDevelop.Core.Platform.IsMac)
        GtkWorkarounds.GrabDesktopFocus();
      this.RootWindow.Present();
      this.monitors.Initialize();
    }

    public void SaveAll()
    {
      foreach (CocoStudio.Core.Document document in this.Documents.ToList<CocoStudio.Core.Document>())
      {
        if (document != this.ActiveDocument)
          document.Save();
      }
      if (this.ActiveDocument == null || this.ActiveDocument.Project == null)
        return;
      this.ActiveDocument.Project.ReloadReferencedProject(Services.ProgressMonitors.Default);
      this.ActiveDocument.Save();
    }

    public bool CloseAll(bool dontCloseCurrent = false)
    {
      CocoStudio.Core.Document document1 = !dontCloseCurrent ? (CocoStudio.Core.Document) null : this.ActiveDocument;
      bool flag = false;
      List<CocoStudio.Core.Document> documentList1 = new List<CocoStudio.Core.Document>();
      List<CocoStudio.Core.Document> documentList2 = new List<CocoStudio.Core.Document>();
      foreach (CocoStudio.Core.Document document2 in this.Documents)
      {
        if (document2 != document1)
        {
          documentList1.Add(document2);
          if (document2.IsDirty)
          {
            flag = true;
            documentList2.Add(document2);
          }
        }
      }
      if (flag)
      {
        string info;
        ButtonText btnText;
        if (documentList2.Count == 1)
        {
          info = string.Format(LanguageInfo.MessageBox188_AskSaveCurFile, (object) Path.GetFileName(documentList2[0].Name));
          btnText = new ButtonText(LanguageInfo.Command_Save, LanguageInfo.Dialog_ButtonDontSave, LanguageInfo.Dialog_ButtonCancel);
        }
        else
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append(LanguageInfo.MessageBox189_AskSaveFiles);
          foreach (CocoStudio.Core.Document document2 in documentList2)
            stringBuilder.Append("\r\n    " + Path.GetFileName(document2.Name));
          info = stringBuilder.ToString();
          btnText = new ButtonText(LanguageInfo.Command_SaveAll, LanguageInfo.Dialog_ButtonDontSave, LanguageInfo.Dialog_ButtonCancel);
        }
        switch (MessageBox.Show(info, btnText, (Window) null, (string) null, MessageBoxImage.Info))
        {
          case MessageBoxResult.Yes:
            foreach (CocoStudio.Core.Document document2 in documentList2)
              document2.Save();
            if (document1 != null && document1.Project != null)
            {
              using (TaskServiceLock.Lock())
              {
                document1.Project.ReloadReferencedProject(Services.ProgressMonitors.Default);
                break;
              }
            }
            else
              break;
          case MessageBoxResult.Cancel:
            return false;
        }
      }
      foreach (CocoStudio.Core.Document document2 in documentList1)
        document2.Close(true);
      return true;
    }

    public CocoStudio.Core.Document OpenDocument(Project project)
    {
      return this.OpenDocument(project.FileName, project, true);
    }

    public CocoStudio.Core.Document OpenDocument(FilePath file, Project project, bool bringToFront = true)
    {
      if (string.IsNullOrEmpty(file.FileName))
        return (CocoStudio.Core.Document) null;
      foreach (CocoStudio.Core.Document document in this.Documents)
      {
        IBaseViewContent baseViewContent = (IBaseViewContent) null;
        if (document.Window.ViewContent.CanReuseView((string) file))
          baseViewContent = (IBaseViewContent) document.Window.ViewContent;
        if (baseViewContent != null)
        {
          if (project != null && document.Project != project)
            document.SetProject(project);
          if (bringToFront)
          {
            document.Select();
            document.Window.SelectWindow();
          }
          return document;
        }
      }
      IProgressMonitor statusProgressMonitor = this.ProgressMonitors.GetStatusProgressMonitor();
      FileOpenInfo openFileInfo = new FileOpenInfo(file, project, bringToFront);
      this.RealOpenFile(statusProgressMonitor, openFileInfo);
      statusProgressMonitor.Dispose();
      if (openFileInfo.NewContent == null)
        return (CocoStudio.Core.Document) null;
      CocoStudio.Core.Document doc = this.WrapDocument(openFileInfo.NewContent.WorkbenchWindow);
      if (doc != null && openFileInfo.BringToFront)
        doc.RunWhenLoaded((System.Action) (() =>
        {
          if (doc.Window == null)
            return;
          doc.Window.SelectWindow();
        }));
      doc.SetProject(project);
      return doc;
    }

    public CocoStudio.Core.Document NewDocument(ResourceFolder parentFolder, IList<ResourceItem> selectesResource = null)
    {
      Project project = Services.ProjectOperations.AddNewProject(parentFolder, selectesResource);
      if (project != null)
        return this.OpenDocument(project);
      return (CocoStudio.Core.Document) null;
    }

    internal void RecoderDocuments(int oldPlacement, int newPlacement)
    {
      if (this.documents == null)
        return;
      CocoStudio.Core.Document document = this.documents[oldPlacement];
      this.documents.RemoveAt(oldPlacement);
      this.documents.Insert(newPlacement, document);
    }

    private void RealOpenFile(IProgressMonitor monitor, FileOpenInfo openFileInfo)
    {
      FilePath fileName = openFileInfo.FileName;
      if (fileName == (FilePath) ((string) null))
        monitor.ReportError("Invalid file name", (Exception) null);
      else if (fileName.IsDirectory)
        monitor.ReportError(string.Format("{0} is a directory", (object) fileName), (Exception) null);
      else if (!File.Exists((string) fileName))
      {
        monitor.ReportError(string.Format("File not found: {0}", (object) fileName), (Exception) null);
      }
      else
      {
        Project project = openFileInfo.Project;
        IViewDisplayBuilder binding;
        IDisplayBuilder displayBuilder;
        if (openFileInfo.DisplayBuilder != null)
        {
          displayBuilder = (IDisplayBuilder) (binding = openFileInfo.DisplayBuilder);
        }
        else
        {
          displayBuilder = DisplayBuilderService.GetDisplayBuilders(fileName, (string) null, project).FirstOrDefault<IDisplayBuilder>((Func<IDisplayBuilder, bool>) (d => d.CanUseAsDefault));
          binding = displayBuilder as IViewDisplayBuilder;
        }
        try
        {
          if (displayBuilder != null && binding != null)
            new LoadFileWrapper(monitor, this.mainWindow, binding, project, openFileInfo).Invoke((string) fileName);
        }
        catch (Exception ex)
        {
          monitor.ReportError("Create ViewContent failed.", ex);
        }
      }
    }

    internal CocoStudio.Core.Document WrapDocument(IDocumentWindow window)
    {
      if (window == null)
        return (CocoStudio.Core.Document) null;
      CocoStudio.Core.Document document = this.FindDocument(window);
      if (document != null)
        return document;
      CocoStudio.Core.Document doc = new CocoStudio.Core.Document(window);
      window.Closing += new EventHandler<DocumentWindowEventArgs>(this.OnWindowClosing);
      window.Closed += new EventHandler<DocumentWindowEventArgs>(this.OnWindowClosed);
      this.documents.Add(doc);
      doc.OnDocumentAttached();
      this.OnDocumentOpened(new DocumentEventArgs(doc));
      return doc;
    }

    private void OnWindowClosed(object sender, DocumentWindowEventArgs e)
    {
      IDocumentWindow window = (IDocumentWindow) sender;
      CocoStudio.Core.Document document = this.FindDocument(window);
      window.Closing -= new EventHandler<DocumentWindowEventArgs>(this.OnWindowClosing);
      window.Closed -= new EventHandler<DocumentWindowEventArgs>(this.OnWindowClosed);
      this.documents.Remove(document);
      this.OnDocumentClosed(document);
      document.DisposeDocument();
    }

    private void OnWindowClosing(object sender, DocumentWindowEventArgs args)
    {
      IDocumentWindow window = (IDocumentWindow) sender;
      if (!args.Forced && window.ViewContent != null && window.ViewContent.IsDirty)
      {
        string str = "";
        if (window.ViewContent.ContentName != null)
          str = Path.GetFileName(window.ViewContent.ContentName);
        switch (MessageBox.Show(string.Format(LanguageInfo.MessageBox188_AskSaveCurFile, (object) str), new ButtonText(LanguageInfo.Command_Save, LanguageInfo.Dialog_ButtonDontSave, LanguageInfo.Dialog_ButtonCancel), (Window) null, (string) null, MessageBoxImage.Info))
        {
          case MessageBoxResult.Yes:
            if (window.ViewContent.ContentName == null)
            {
              this.FindDocument(window).Save();
              args.Cancel = window.ViewContent.IsDirty;
            }
            else
            {
              try
              {
                window.ViewContent.Closing();
                if (window.ViewContent.IsFile)
                  window.ViewContent.Save(window.ViewContent.ContentName);
                else
                  window.ViewContent.Save();
                DocumentWindowEventArgs documentWindowEventArgs = args;
                int num = documentWindowEventArgs.Cancel | window.ViewContent.IsDirty ? 1 : 0;
                documentWindowEventArgs.Cancel = num != 0;
              }
              catch (Exception ex)
              {
                args.Cancel = true;
                MessageBox.Show(LanguageInfo.Output_FailedToSaveFile, (Window) null, (string) null, MessageBoxImage.Info);
              }
            }
            if (args.Cancel)
            {
              this.FindDocument(window).Select();
              break;
            }
            break;
          case MessageBoxResult.No:
            args.Cancel = false;
            window.ViewContent.DiscardChanges();
            break;
          case MessageBoxResult.Cancel:
            args.Cancel = true;
            break;
        }
      }
      this.OnDocumentClosing(this.FindDocument(window));
    }

    private static Project GetProjectContainingFile(FilePath fileName)
    {
      Project project = (Project) null;
      if (Services.ProjectOperations.CurrentSelectedProject != null && Services.ProjectOperations.CurrentSelectedProject.FileName == fileName)
        project = Services.ProjectOperations.CurrentSelectedProject;
      if (project == null && Services.ProjectOperations.CurrentSelectedWorkspaceItem != null)
      {
        project = Services.ProjectOperations.CurrentSelectedWorkspaceItem.GetProjectContainingFile(fileName);
        if (project == null)
        {
          for (WorkspaceItem parentWorkspace = (WorkspaceItem) Services.ProjectOperations.CurrentSelectedWorkspaceItem.ParentWorkspace; parentWorkspace != null && project == null; parentWorkspace = (WorkspaceItem) parentWorkspace.ParentWorkspace)
            project = parentWorkspace.GetProjectContainingFile(fileName);
        }
      }
      return project;
    }

    private void OnDocumentOpened(DocumentEventArgs documentEventArgs)
    {
    }

    private void OnDocumentClosed(CocoStudio.Core.Document doc)
    {
      try
      {
        DocumentEventArgs e = new DocumentEventArgs(doc);
        EventHandler<DocumentEventArgs> documentClosed = this.DocumentClosed;
        if (documentClosed != null)
          documentClosed((object) this, e);
        Services.TaskService.Clear((object) doc);
      }
      catch (Exception ex)
      {
        LoggingService.LogError("Exception while closing documents", ex);
      }
    }

    private void OnDocumentClosing(CocoStudio.Core.Document doc)
    {
      try
      {
        DocumentEventArgs e = new DocumentEventArgs(doc);
        EventHandler<DocumentEventArgs> documentClosing = this.DocumentClosing;
        if (documentClosing == null)
          return;
        documentClosing((object) this, e);
      }
      catch (Exception ex)
      {
        LoggingService.LogError("Exception before closing documents", ex);
      }
    }

    private Pad WrapPad(PadCodon padContent)
    {
      if (this.pads == null)
      {
        foreach (Pad pad1 in (List<Pad>) this.Pads)
        {
          if (pad1.InternalContent == padContent)
            return pad1;
        }
      }
      Pad pad = new Pad(this.mainWindow, padContent);
      this.Pads.Add(pad);
      pad.Window.PadDestroyed += (EventHandler) ((param0, param1) => this.Pads.Remove(pad));
      return pad;
    }

    internal CocoStudio.Core.Document FindDocument(IDocumentWindow window)
    {
      foreach (CocoStudio.Core.Document document in this.Documents)
      {
        if (document.Window == window)
          return document;
      }
      return (CocoStudio.Core.Document) null;
    }
  }
}
