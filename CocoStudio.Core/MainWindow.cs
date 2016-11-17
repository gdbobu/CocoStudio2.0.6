// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.MainWindow
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.Core.Commands;
using CocoStudio.Core.Events;
using CocoStudio.Core.View;
using CocoStudio.Projects;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Addins;
using MonoDevelop.Components;
using MonoDevelop.Components.Commands;
using MonoDevelop.Components.Docking;
using MonoDevelop.Components.DockNotebook;
using MonoDevelop.Components.DockToolbars;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Codons;
using MonoDevelop.Ide.Gui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace CocoStudio.Core
{
  public class MainWindow : WorkbenchWindow, IWorkbench, IMainWindow, IWindowClosed
  {
    private static string configFile = Option.GetUserConfigFileByName("Layout.config");
    private static string defaultLayoutFile = Option.GetUserConfigFileByName("DefaultLayout.config");
    private List<string> layouts = new List<string>();
    private List<PadCodon> padContentCollection = new List<PadCodon>();
    private List<IViewContentExtend> viewContentCollection = new List<IViewContentExtend>();
    private Dictionary<PadCodon, IPadWindow> padWindows = new Dictionary<PadCodon, IPadWindow>();
    private Dictionary<IPadWindow, PadCodon> padCodons = new Dictionary<IPadWindow, PadCodon>();
    private LinkedList<IDocumentWindow> lastActiveWindows = new LinkedList<IDocumentWindow>();
    private Rectangle normalBounds = new Rectangle(0, 0, 1000, 600);
    private int activeWindowChangeLock = 0;
    private const string fullViewModeTag = "[FullViewMode]";
    public const string defaultLayoutID = "DefaultLayout";
    private const int MinimumWidth = 1000;
    private const int MinimumHeight = 600;
    public readonly int MainThreadId;
    private IDocumentWindow lastActive;
    private bool closeAll;
    private bool ignorePageSwitch;
    private bool fullscreen;
    private Gtk.Container rootWidget;
    private DockToolbarFrame toolbarFrame;
    private DockFrame dock;
    private MonoDevelop.Components.DockNotebook.DockNotebook tabControl;
    private Widget topMenu;
    private VBox fullViewVBox;
    private DockItem documentDockItem;
    private Widget toolbar;
    private Widget bottomBar;
    private VBox sideBox;
    private bool initializing;
    private ViewService viewService;

    public List<PadCodon> PadContentCollection
    {
      get
      {
        return this.padContentCollection;
      }
    }

    public List<IViewContent> InternalViewContentCollection
    {
      get
      {
        return this.viewContentCollection.Cast<IViewContent>().ToList<IViewContent>();
      }
    }

    public IDocumentWindow ActiveWorkbenchWindow
    {
      get
      {
        if (this.tabControl == null || this.tabControl.CurrentTabIndex < 0 || this.tabControl.CurrentTabIndex >= this.tabControl.TabCount)
          return (IDocumentWindow) null;
        return (IDocumentWindow) this.tabControl.CurrentTab.Content;
      }
    }

    public DockFrame DockFrame
    {
      get
      {
        return this.dock;
      }
    }

    public MonoDevelop.Components.DockNotebook.DockNotebook DockNotebook
    {
      get
      {
        return this.tabControl;
      }
    }

    public bool FullScreen
    {
      get
      {
        return DesktopService.GetIsFullscreen((Gtk.Window) this);
      }
      set
      {
        DesktopService.SetIsFullscreen((Gtk.Window) this, value);
      }
    }

    public IList<string> Layouts
    {
      get
      {
        return (IList<string>) this.layouts;
      }
    }

    public string CurrentLayout
    {
      get
      {
        if (this.dock == null || this.dock.CurrentLayout == null)
          return "";
        string currentLayout = this.dock.CurrentLayout;
        string str = currentLayout.Substring(currentLayout.IndexOf(".") + 1);
        if (str.EndsWith("[FullViewMode]"))
          return str.Substring(0, str.Length - "[FullViewMode]".Length);
        return str;
      }
      set
      {
        string currentLayout = this.dock.CurrentLayout;
        this.InitializeLayout(value);
        this.toolbarFrame.CurrentLayout = this.dock.CurrentLayout = value;
        this.DestroyFullViewLayouts(currentLayout);
        this.FocusActiveDocumentWindow();
      }
    }

    private bool IsInFullViewMode
    {
      get
      {
        return this.dock.CurrentLayout.EndsWith("[FullViewMode]");
      }
    }

    public ViewService ViewService
    {
      get
      {
        if (this.viewService == null)
          this.viewService = new ViewService(this);
        return this.viewService;
      }
    }

    IViewService IMainWindow.ViewService
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public event EventHandler ActiveWorkbenchWindowChanged;

    public event EventHandler<EventArgs> InitializeCompleted;

    public event EventHandler LayoutReset;

    public event EventHandler<CancelEventArgs> Closing;

    public event EventHandler<EventArgs> Closed;

    public MainWindow(string title)
    {
      this.Title = title;
      this.MainThreadId = Thread.CurrentThread.ManagedThreadId;
      this.WidthRequest = this.normalBounds.Width;
      this.HeightRequest = this.normalBounds.Height;
      this.Maximize();
      if (Platform.IsWindows)
        this.DeleteEvent += new DeleteEventHandler(this.OnClosing);
      if (Platform.IsMac)
        this.DeleteEvent += new DeleteEventHandler(this.OnHiding);
      Services.MainWindow = this;
      this.SetAppIcons();
    }

    private void SetAppIcons()
    {
    }

    protected void OnHiding(object o, DeleteEventArgs e)
    {
      e.RetVal = (object) true;
      this.Visible = false;
    }

    protected void OnClosing(object o, DeleteEventArgs e)
    {
      if (this.Closing != null)
      {
        CancelEventArgs e1 = new CancelEventArgs(false);
        this.Closing((object) this, e1);
        if (e1.Cancel)
        {
          e.RetVal = (object) true;
          return;
        }
      }
      if (this.Close())
        Application.Quit();
      else
        e.RetVal = (object) true;
    }

    public bool Quit()
    {
      if (this.Closing != null)
      {
        CancelEventArgs e = new CancelEventArgs(false);
        this.Closing((object) this, e);
        if (e.Cancel)
          return true;
      }
      if (!this.Close())
        return false;
      Application.Quit();
      return true;
    }

    protected void OnClosed(EventArgs e)
    {
      foreach (string layout in this.dock.Layouts)
      {
        if (layout.EndsWith("[FullViewMode]"))
          this.dock.DeleteLayout(layout);
      }
      try
      {
        this.dock.SaveLayouts(MainWindow.configFile);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Error while saving layout.", ex);
      }
      this.UninstallMenuBar();
      this.Remove((Widget) this.rootWidget);
      foreach (PadCodon padContent in this.PadContentCollection)
      {
        if (padContent.Initialized)
          padContent.PadContent.Dispose();
      }
      this.rootWidget.Destroy();
      this.Destroy();
      if (this.Closed == null)
        return;
      this.Closed((object) this, new EventArgs());
    }

    public bool Close()
    {
      bool flag = false;
      foreach (IViewContent viewContent in this.viewContentCollection)
      {
        if (viewContent.IsDirty)
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        this.Present();
        ButtonText btnText = new ButtonText(LanguageInfo.Dialog_ButtonYes, LanguageInfo.Dialog_ButtonNo, LanguageInfo.Dialog_ButtonCancel);
        switch (MessageBox.Show(LanguageInfo.MessageBox_Content57, btnText, (Gtk.Window) null, (string) null, MessageBoxImage.Info))
        {
          case MessageBoxResult.Cancel:
            return false;
          case MessageBoxResult.No:
            break;
          default:
            Services.Workbench.SaveAll();
            goto case MessageBoxResult.No;
        }
      }
      Services.Workspace.CloseWorkspaceItem((WorkspaceItem) Services.ProjectOperations.CurrentSelectedSolution, true);
      this.CloseAllViews();
      this.OnClosed((EventArgs) null);
      return true;
    }

    public void LockActiveWindowChangeEvent()
    {
      ++this.activeWindowChangeLock;
    }

    public void UnlockActiveWindowChangeEvent()
    {
      --this.activeWindowChangeLock;
      this.OnActiveWindowChanged((object) null, (EventArgs) null);
    }

    private void OnActiveWindowChanged(object sender, EventArgs e)
    {
      if (this.activeWindowChangeLock > 0 || this.lastActive == this.ActiveWorkbenchWindow)
        return;
      if (this.lastActive != null)
        ((DocumentWindow) this.lastActive).OnDeactivated();
      this.lastActive = this.ActiveWorkbenchWindow;
      if (!this.closeAll && this.ActiveWorkbenchWindow != null)
        ((DocumentWindow) this.ActiveWorkbenchWindow).OnActivated();
      Services.ProjectOperations.CurrentSelectedProject = this.lastActive == null ? (Project) null : this.lastActive.ViewContent.Project;
      if (this.closeAll || this.ActiveWorkbenchWindowChanged == null)
        return;
      this.ActiveWorkbenchWindowChanged((object) this, e);
    }

    public void Initialize()
    {
      Services.Intinalize();
      ImageService.Initialize();
      this.InitializeLayout();
      this.CreateMenuBar();
      this.InstallMenuBar();
      Services.ProjectOperations.CurrentSelectedSolutionChanged += new EventHandler<SolutionEventArgs>(this.HandleCurrentSelectedSolutionChanged);
      if (this.InitializeCompleted == null)
        return;
      this.InitializeCompleted((object) this, new EventArgs());
    }

    private void InitializeLayout()
    {
      this.CreateComponents();
      this.initializing = true;
      AddinManager.AddExtensionNodeHandler("/CocoStudio/Ide/Pads", new ExtensionNodeEventHandler(this.OnExtensionChanged));
      this.initializing = false;
    }

    private void InitializeLayout(string name)
    {
      if (!this.layouts.Contains(name))
        this.layouts.Add(name);
      if (((IEnumerable<string>) this.dock.Layouts).Contains<string>(name))
        return;
      this.dock.CreateLayout(name, true);
      this.dock.CurrentLayout = name;
      this.documentDockItem.Visible = true;
      HashSet<string> stringSet = new HashSet<string>();
      foreach (PadCodon padContent in this.padContentCollection)
      {
        if (!stringSet.Contains(padContent.PadId) && padContent.DefaultLayouts != null && (padContent.DefaultLayouts.Contains("DefaultLayout") || padContent.DefaultLayouts.Contains("*")))
        {
          DockItem dockItem = this.dock.GetItem(padContent.PadId);
          if (dockItem != null)
          {
            dockItem.Visible = true;
            if (!string.IsNullOrEmpty(padContent.DefaultPlacement))
              dockItem.SetDockLocation(this.ToDockLocation(padContent.DefaultPlacement));
            dockItem.Status = padContent.DefaultStatus;
            stringSet.Add(padContent.PadId);
          }
        }
      }
      foreach (DockItem dockItem in this.dock.GetItems())
      {
        if (!stringSet.Contains(dockItem.Id) && (dockItem.Behavior & DockItemBehavior.Sticky) == DockItemBehavior.Normal && dockItem != this.documentDockItem)
          dockItem.Visible = false;
      }
    }

    private void CreateComponents()
    {
      this.fullViewVBox = new VBox(false, 0);
      this.rootWidget = (Gtk.Container) this.fullViewVBox;
      this.Realize();
      this.toolbar = MainWindowPartFactory.CreateMainToolbarWidget();
      HBox hbox1 = new HBox(false, 0);
      this.fullViewVBox.PackStart((Widget) hbox1, false, false, 0U);
      this.toolbarFrame = new DockToolbarFrame();
      this.fullViewVBox.PackStart((Widget) this.toolbarFrame, true, true, 0U);
      this.dock = new DockFrame();
      this.dock.DefaultItemWidth = (int) byte.MaxValue;
      this.dock.CompactGuiLevel = 2;
      this.toolbarFrame.ModifyBg(StateType.Normal, new Gdk.Color(byte.MaxValue, (byte) 0, (byte) 0));
      this.toolbarFrame.AddContent((Widget) this.dock);
      this.tabControl = new MonoDevelop.Components.DockNotebook.DockNotebook();
      this.tabControl.NavigationButtonsVisible = false;
      this.tabControl.SwitchPage += new EventHandler(this.OnActiveWindowChanged);
      this.tabControl.PageRemoved += new EventHandler(this.OnActiveWindowChanged);
      this.tabControl.PageAdded += new EventHandler(this.OnActiveWindowChanged);
      this.tabControl.TabClosed += new EventHandler<TabEventArgs>(this.CloseClicked);
      this.tabControl.TabActivated += (EventHandler<TabEventArgs>) ((sender, e) => this.ToggleFullViewMode());
      this.tabControl.DoPopupMenu = new System.Action<MonoDevelop.Components.DockNotebook.DockNotebook, int, EventButton>(this.ShowPopup);
      this.tabControl.TabsReordered += new TabsReorderedHandler(this.OnTabsReordered);
      MonoDevelop.Components.DockNotebook.DockNotebook.ActiveNotebookChanged += (EventHandler) ((param0, param1) => this.OnActiveWindowChanged((object) null, (EventArgs) null));
      this.Add((Widget) this.fullViewVBox);
      this.fullViewVBox.ShowAll();
      HBox hbox2 = new HBox(false, 0);
      this.bottomBar = MainWindowPartFactory.CreateMainStatus();
      this.bottomBar.Show();
      hbox2.PackStart(this.bottomBar, true, true, 0U);
      this.fullViewVBox.PackEnd((Widget) hbox2, false, false, 0U);
      hbox2.ShowAll();
      hbox1.PackStart(this.toolbar, true, true, 0U);
      this.tabControl.InitSize();
      int barHeight = this.tabControl.BarHeight;
      this.documentDockItem = this.dock.AddItem("Documents");
      this.documentDockItem.Behavior = DockItemBehavior.Locked;
      this.documentDockItem.Expand = true;
      this.documentDockItem.DrawFrame = false;
      this.documentDockItem.Label = "Documents";
      this.documentDockItem.Content = (Widget) this.tabControl;
      this.documentDockItem.ContentVisibleChanged += new EventHandler(this.DockTabControlVisibleChanged);
      this.dock.DefaultVisualStyle = new DockVisualStyle()
      {
        PadTitleLabelColor = new Gdk.Color?(Styles.PadLabelColor),
        PadBackgroundColor = new Gdk.Color?(Styles.PadBackground),
        InactivePadBackgroundColor = new Gdk.Color?(Styles.InactivePadBackground),
        PadTitleHeight = new int?(barHeight)
      };
      DockVisualStyle style1 = new DockVisualStyle();
      style1.PadTitleLabelColor = new Gdk.Color?(Styles.PadLabelColor);
      style1.PadTitleHeight = new int?(barHeight);
      style1.ShowPadTitleIcon = new bool?(false);
      style1.UppercaseTitles = new bool?(false);
      style1.ExpandedTabs = new bool?(true);
      style1.PadBackgroundColor = new Gdk.Color?(Styles.BrowserPadBackground);
      style1.InactivePadBackgroundColor = new Gdk.Color?(Styles.InactiveBrowserPadBackground);
      style1.TreeBackgroundColor = new Gdk.Color?(Styles.BrowserPadBackground);
      this.dock.SetDockItemStyle("ProjectPad", style1);
      this.dock.SetDockItemStyle("ClassPad", style1);
      this.dock.SetRegionStyle("Documents/Left", style1);
      this.dock.SetRegionStyle("Documents/Right", style1);
      DockVisualStyle style2 = new DockVisualStyle();
      style2.SingleColumnMode = new bool?(true);
      this.dock.SetRegionStyle("Documents/Left;Documents/Right", style2);
      this.dock.SetDockItemStyle("Documents", style2);
      DockItem dockItem1 = this.dock.AddItem("__left");
      dockItem1.DefaultLocation = "Documents/Left";
      dockItem1.Behavior = DockItemBehavior.Locked;
      dockItem1.DefaultVisible = false;
      DockItem dockItem2 = this.dock.AddItem("__bottom");
      dockItem2.DefaultLocation = "Documents/Bottom";
      dockItem2.Behavior = DockItemBehavior.Locked;
      dockItem2.DefaultVisible = false;
      DockItem dockItem3 = this.dock.AddItem("__right");
      dockItem3.DefaultLocation = "Documents/Right";
      dockItem3.Behavior = DockItemBehavior.Locked;
      dockItem3.DefaultVisible = false;
      DockItem dockItem4 = this.dock.AddItem("__top");
      dockItem4.DefaultLocation = "Documents/Top";
      dockItem4.Behavior = DockItemBehavior.Locked;
      dockItem4.DefaultVisible = false;
      foreach (ExtensionNode extensionNode in AddinManager.GetExtensionNodes("/CocoStudio/Ide/Pads"))
        this.ShowPadNode(extensionNode);
      this.InitializeLayout("DefaultLayout");
      this.LoadLayoutFromFile(MainWindow.configFile);
    }

    private void DockTabControlVisibleChanged(object sender, EventArgs e)
    {
      this.FocusActiveDocumentWindow();
    }

    private void FocusActiveDocumentWindow()
    {
      if (!this.documentDockItem.ContentVisible || this.ActiveWorkbenchWindow == null)
        return;
      this.LockActiveWindowChangeEvent();
      DockNotebookTab currentTab = this.tabControl.CurrentTab;
      this.tabControl.CurrentTab = (DockNotebookTab) null;
      this.tabControl.CurrentTab = currentTab;
      DocumentWindow activeWorkbenchWindow = this.ActiveWorkbenchWindow as DocumentWindow;
      if (activeWorkbenchWindow != null)
        activeWorkbenchWindow.ViewContent.Activated();
      this.UnlockActiveWindowChangeEvent();
    }

    private void CreateMenuBar()
    {
      this.topMenu = MainWindowPartFactory.CreateMainMenu();
      GlobalCommand.GlobalCmdManager.SetMultiRootWindow((Gtk.Window) this);
    }

    private void InstallMenuBar()
    {
      if (!Platform.IsWindows || this.topMenu == null)
        return;
      ((Box) this.rootWidget).PackStart(this.topMenu, false, false, 0U);
      ((Box.BoxChild) this.rootWidget[this.topMenu]).Position = 0;
      this.topMenu.ShowAll();
    }

    private void UninstallMenuBar()
    {
      if (this.topMenu == null)
        return;
      this.rootWidget.Remove(this.topMenu);
      this.topMenu.Destroy();
      this.topMenu = (Widget) null;
    }

    private void OnExtensionChanged(object s, ExtensionNodeEventArgs args)
    {
      if (this.initializing)
        return;
      if (args.Change == ExtensionChange.Add)
        this.ShowPadNode(args.ExtensionNode);
      else
        this.RemovePadNode(args.ExtensionNode);
    }

    private void OnLayoutsExtensionChanged(object s, ExtensionNodeEventArgs args)
    {
    }

    public void CloseContent(IViewContentExtend content)
    {
      if (!this.viewContentCollection.Contains(content))
        return;
      this.viewContentCollection.Remove(content);
    }

    public void CloseAllViews()
    {
      try
      {
        this.closeAll = true;
        foreach (IBaseViewContent baseViewContent in new List<IViewContent>((IEnumerable<IViewContent>) this.viewContentCollection))
        {
          IWorkbenchWindow workbenchWindow = baseViewContent.WorkbenchWindow;
          if (workbenchWindow != null)
            workbenchWindow.CloseWindow(true);
        }
      }
      finally
      {
        this.closeAll = false;
        this.OnActiveWindowChanged((object) null, (EventArgs) null);
      }
    }

    public virtual void ShowView(IViewContentExtend content, bool bringToFront)
    {
      if (this.viewContentCollection.Contains(content))
      {
        this.SelectView((IViewContent) content);
      }
      else
      {
        this.viewContentCollection.Add(content);
        Xwt.Drawing.Image image = (Xwt.Drawing.Image) null;
        DockNotebookTab tabLabel = this.tabControl.InsertTab(-1);
        DocumentWindow documentWindow = new DocumentWindow(this, content, this.tabControl, tabLabel);
        documentWindow.Closed += new EventHandler<DocumentWindowEventArgs>(this.CloseWindowEvent);
        documentWindow.Show();
        tabLabel.Content = (Widget) documentWindow;
        if (image != null)
          tabLabel.Icon = image;
        if (bringToFront)
          documentWindow.SelectWindow();
        documentWindow.ShowAll();
        this.OnActiveWindowChanged((object) null, (EventArgs) null);
      }
    }

    private void CloseWindowEvent(object sender, DocumentWindowEventArgs e)
    {
      DocumentWindow documentWindow = (DocumentWindow) sender;
      if (documentWindow.ViewContent == null)
        return;
      this.CloseContent(documentWindow.ViewContent);
    }

    private void SelectView(IViewContent content)
    {
      if (!(content is ViewContent))
        return;
      (content as ViewContent).WorkbenchWindow.SelectWindow();
    }

    private void ShowPadNode(ExtensionNode node)
    {
      if (node is PadCodon)
      {
        PadCodon padCodon = (PadCodon) node;
        this.AddPad(padCodon, padCodon.DefaultPlacement, padCodon.DefaultStatus);
      }
      else
      {
        if (!(node is CategoryNode))
          return;
        foreach (ExtensionNode childNode in node.ChildNodes)
          this.ShowPadNode(childNode);
      }
    }

    private void RemovePadNode(ExtensionNode node)
    {
      if (node is PadCodon)
      {
        this.RemovePad((PadCodon) node);
      }
      else
      {
        if (!(node is CategoryNode))
          return;
        foreach (ExtensionNode childNode in node.ChildNodes)
          this.RemovePadNode(childNode);
      }
    }

    public void ShowPad(PadCodon content)
    {
      this.AddPad(content, true);
    }

    public void AddPad(PadCodon content)
    {
      this.AddPad(content, false);
    }

    private void RegisterPad(PadCodon content)
    {
      this.padContentCollection.Add(content);
    }

    private void AddPad(PadCodon content, bool show)
    {
      DockItem dockItem = this.GetDockItem(content);
      if (this.padContentCollection.Contains(content))
      {
        if (!show || dockItem == null)
          return;
        dockItem.Visible = true;
      }
      else
      {
        this.RegisterPad(content);
        if (dockItem != null)
        {
          if (!show)
            return;
          dockItem.Visible = true;
        }
        else
          this.AddPad(content, content.DefaultPlacement, content.DefaultStatus);
      }
    }

    public void RemovePad(PadCodon codon)
    {
      if (codon.HasId)
      {
        Command command = IdeApp.CommandService.GetCommand((object) codon.Id);
        if (command != null)
          IdeApp.CommandService.UnregisterCommand(command);
      }
      DockItem dockItem = this.GetDockItem(codon);
      this.padContentCollection.Remove(codon);
      PadWindow padWindow = (PadWindow) this.GetPadWindow(codon);
      if (padWindow != null)
      {
        padWindow.NotifyDestroyed();
        this.padCodons.Remove((IPadWindow) padWindow);
      }
      if (dockItem != null)
        this.dock.RemoveItem(dockItem);
      this.padWindows.Remove(codon);
    }

    public void BringToFront(PadCodon content)
    {
      this.BringToFront(content, false);
    }

    public virtual void BringToFront(PadCodon content, bool giveFocus)
    {
      if (!this.IsVisible(content))
        this.ShowPad(content);
      this.ActivatePad(content, giveFocus);
    }

    public void ResetDefaultLayout()
    {
      this.LoadLayoutFromFile(MainWindow.defaultLayoutFile);
      this.CurrentLayout = "DefaultLayout";
      if (this.ActiveWorkbenchWindow == null)
        return;
      ((DocumentWindow) this.ActiveWorkbenchWindow).OnActivated();
    }

    private void LoadLayoutFromFile(string filePath)
    {
      try
      {
        if (!File.Exists(filePath))
          return;
        this.dock.LoadLayouts(filePath);
        foreach (string layout in this.dock.Layouts)
        {
          if (!this.layouts.Contains(layout) && !layout.EndsWith("[FullViewMode]"))
            this.layouts.Add(layout);
        }
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex.ToString());
      }
    }

    private void HandleCurrentSelectedSolutionChanged(object sender, SolutionEventArgs e)
    {
      this.SetDefaultTitle();
    }

    private void SetWorkbenchTitle()
    {
      try
      {
        IDocumentWindow activeWorkbenchWindow = this.ActiveWorkbenchWindow;
        if (activeWorkbenchWindow != null)
        {
          if (activeWorkbenchWindow.ViewContent.IsUntitled)
          {
            this.SetDefaultTitle();
          }
          else
          {
            string str = string.Empty;
            if (activeWorkbenchWindow.ViewContent.IsDirty)
              str = "*";
            if (activeWorkbenchWindow.ViewContent.Project != null)
              this.Title = activeWorkbenchWindow.ViewContent.Project.Name + " - " + activeWorkbenchWindow.ViewContent.PathRelativeToProject + str + " - " + BrandingService.ApplicationName;
            else
              this.Title = activeWorkbenchWindow.ViewContent.ContentName + str + " - " + BrandingService.ApplicationName;
          }
        }
        else
        {
          this.SetDefaultTitle();
          if (this.IsInFullViewMode)
            this.ToggleFullViewMode();
        }
      }
      catch (Exception )
      {
        this.SetDefaultTitle();
      }
    }

    private void SetDefaultTitle()
    {
      if (Services.ProjectOperations.CurrentSelectedSolution != null)
        this.Title = Services.ProjectOperations.CurrentSelectedSolution.Name + " - Cocos Studio";
      else
        this.Title = "Cocos Studio";
    }

    public Properties GetStoredMemento(IViewContent content)
    {
      if (content != null && content.ContentName != null)
      {
        string path = (string) UserProfile.Current.CacheDir.Combine(new string[1]{ "temp" });
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string str1 = content.ContentName.Substring(3).Replace('/', '.').Replace('\\', '.').Replace(System.IO.Path.DirectorySeparatorChar, '.');
        string str2 = path + (object)System.IO.Path.DirectorySeparatorChar + str1;
        if (FileService.IsValidPath(str2) && File.Exists(str2))
          return Properties.Load(str2);
      }
      return (Properties) null;
    }

    private void ShowPopup(MonoDevelop.Components.DockNotebook.DockNotebook arg1, int arg2, EventButton arg3)
    {
      this.tabControl.CurrentTabIndex = arg2;
      CommandManager.Main.ShowContextMenu((Widget) this.tabControl, arg3, FileTabCommand.TabPopupMenu, (object) null);
    }

    private void OnTabsReordered(Widget widget, int oldPlacement, int newPlacement)
    {
      if (this.viewContentCollection == null)
        return;
      IViewContentExtend viewContent = this.viewContentCollection[oldPlacement];
      this.viewContentCollection.RemoveAt(oldPlacement);
      this.viewContentCollection.Insert(newPlacement, viewContent);
      Services.Workbench.RecoderDocuments(oldPlacement, newPlacement);
    }

    private void DestroyFullViewLayouts(string oldLayout)
    {
      if (oldLayout != null && oldLayout.EndsWith("[FullViewMode]"))
      {
        this.dock.DeleteLayout(oldLayout);
        this.toolbarFrame.DeleteLayout(oldLayout);
      }
      if (this.LayoutReset == null)
        return;
      this.LayoutReset((object) this, (EventArgs) null);
    }

    public void ToggleFullViewMode()
    {
      if (this.IsInFullViewMode)
      {
        string currentLayout = this.dock.CurrentLayout;
        this.toolbarFrame.CurrentLayout = this.dock.CurrentLayout = this.CurrentLayout;
        this.DestroyFullViewLayouts(currentLayout);
      }
      else
      {
        string str = this.CurrentLayout + "[FullViewMode]";
        if (!this.dock.HasLayout(str))
          this.dock.CreateLayout(str, true);
        this.toolbarFrame.CurrentLayout = this.dock.CurrentLayout = str;
        foreach (DockItem dockItem in this.dock.GetItems())
        {
          if (dockItem.Behavior != DockItemBehavior.Locked && dockItem.Visible)
            dockItem.Status = DockItemStatus.AutoHide;
        }
        foreach (DockToolbar toolbar in (IEnumerable<DockToolbar>) this.toolbarFrame.Toolbars)
          toolbar.Status = new DockToolbarStatus(toolbar.Id, false, toolbar.Position);
      }
    }

    public void SetFullViewMode(bool IsFull)
    {
      if (IsFull)
      {
        string currentLayout = this.dock.CurrentLayout;
        this.toolbarFrame.CurrentLayout = this.dock.CurrentLayout = this.CurrentLayout;
        this.DestroyFullViewLayouts(currentLayout);
      }
      else
      {
        string str = this.CurrentLayout + "[FullViewMode]";
        if (!this.dock.HasLayout(str))
          this.dock.CreateLayout(str, true);
        this.toolbarFrame.CurrentLayout = this.dock.CurrentLayout = str;
        foreach (DockItem dockItem in this.dock.GetItems())
        {
          if (dockItem.Behavior != DockItemBehavior.Locked && dockItem.Visible)
            dockItem.Status = DockItemStatus.AutoHide;
        }
        foreach (DockToolbar toolbar in (IEnumerable<DockToolbar>) this.toolbarFrame.Toolbars)
          toolbar.Status = new DockToolbarStatus(toolbar.Id, false, toolbar.Position);
      }
    }

    private bool SelectLastActiveWindow(IDocumentWindow cur)
    {
      if (this.lastActiveWindows.Count == 0)
        return false;
      IDocumentWindow documentWindow;
      do
      {
        documentWindow = this.lastActiveWindows.Last.Value;
        this.lastActiveWindows.RemoveLast();
      }
      while (this.lastActiveWindows.Count > 0 && (documentWindow == cur || documentWindow == null || documentWindow != null && documentWindow.ViewContent == null));
      if (documentWindow == null || documentWindow == cur)
        return false;
      documentWindow.SelectWindow();
      return true;
    }

    private void CloseWindowEvent(object sender, WorkbenchWindowEventArgs e)
    {
      DocumentWindow documentWindow = (DocumentWindow) sender;
      this.lastActiveWindows.Remove((IDocumentWindow) documentWindow);
      if (documentWindow.ViewContent != null)
      {
        this.CloseContent(documentWindow.ViewContent);
        if (e.WasActive && !this.SelectLastActiveWindow((IDocumentWindow) documentWindow))
          this.OnActiveWindowChanged((object) this, (EventArgs) null);
      }
      this.lastActiveWindows.Remove((IDocumentWindow) documentWindow);
    }

    private void CloseClicked(object o, TabEventArgs e)
    {
      this.CloseView(((DocumentWindow) e.Tab.Content).ViewContent);
    }

    internal void CloseView(IViewContentExtend viewContent)
    {
      if (!this.viewContentCollection.Contains(viewContent) || !(viewContent is ViewContent) || !((DocumentWindow) viewContent.WorkbenchWindow).CloseWindow(false, true))
        return;
      this.CloseContent(viewContent);
    }

    public void RemoveTab(MonoDevelop.Components.DockNotebook.DockNotebook tabControl, int pageNum, bool animate)
    {
      try
      {
        this.LockActiveWindowChangeEvent();
        IDocumentWindow activeWorkbenchWindow = this.ActiveWorkbenchWindow;
        tabControl.RemoveTab(pageNum, animate);
      }
      finally
      {
        this.UnlockActiveWindowChangeEvent();
      }
    }

    internal void ReorderTab(int oldPlacement, int newPlacement)
    {
      this.tabControl.GetTab(oldPlacement);
      this.tabControl.GetTab(newPlacement);
    }

    public IPadWindow GetPadWindow(PadCodon content)
    {
      IPadWindow padWindow;
      this.padWindows.TryGetValue(content, out padWindow);
      return padWindow;
    }

    public bool IsVisible(PadCodon padContent)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      if (dockItem != null)
        return dockItem.Visible;
      return false;
    }

    public bool IsContentVisible(PadCodon padContent)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      if (dockItem != null)
        return dockItem.ContentVisible;
      return false;
    }

    public void HidePad(PadCodon padContent)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      if (dockItem == null)
        return;
      dockItem.Visible = false;
    }

    public void ActivatePad(PadCodon padContent, bool giveFocus)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      if (dockItem == null)
        return;
      dockItem.Present(giveFocus);
    }

    public bool IsSticky(PadCodon padContent)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      return dockItem != null && (dockItem.Behavior & DockItemBehavior.Sticky) != DockItemBehavior.Normal;
    }

    public void SetSticky(PadCodon padContent, bool sticky)
    {
      DockItem dockItem = this.GetDockItem(padContent);
      if (dockItem == null)
        return;
      if (sticky)
        dockItem.Behavior |= DockItemBehavior.Sticky;
      else
        dockItem.Behavior &= ~DockItemBehavior.Sticky;
    }

    internal DockItem GetDockItem(PadCodon content)
    {
      if (this.padContentCollection.Contains(content))
        return this.dock.GetItem(content.PadId);
      return (DockItem) null;
    }

    private void CreatePadContent(bool force, PadCodon padCodon, PadWindow window, DockItem item)
    {
      if (!force && item.Content != null)
        return;
      IPadContent padContent = padCodon.InitializePadContent((IPadWindow) window);
      Widget child;
      if (padContent is Widget)
      {
        child = padContent.Control;
      }
      else
      {
        PadCommandRouterContainer commandRouterContainer = new PadCommandRouterContainer(window, padContent.Control, (object) padContent, true);
        commandRouterContainer.Show();
        child = (Widget) commandRouterContainer;
      }
      PadCommandRouterContainer commandRouterContainer1 = new PadCommandRouterContainer(window, child, (object) this.toolbarFrame, false);
      commandRouterContainer1.Show();
      item.Content = (Widget) commandRouterContainer1;
    }

    private string ToDockLocation(string loc)
    {
      string str1 = "";
      string str2 = loc;
      char[] chArray = new char[1]{ ' ' };
      foreach (string str3 in str2.Split(chArray))
      {
        if (!string.IsNullOrEmpty(str3))
        {
          if (str1.Length > 0)
            str1 += ";";
          str1 = str3.IndexOf('/') != -1 ? str1 + str3 : str1 + "__" + str3.ToLower() + "/CenterBefore";
        }
      }
      return str1;
    }

    private void AddPad(PadCodon padCodon, string placement, DockItemStatus defaultStatus)
    {
      PadWindow window = new PadWindow((IWorkbench) this, padCodon);
      window.Icon = padCodon.Icon;
      this.padWindows[padCodon] = (IPadWindow) window;
      this.padCodons[(IPadWindow) window] = padCodon;
      window.StatusChanged += new EventHandler(this.UpdatePad);
      string dockLocation = this.ToDockLocation(placement);
      DockItem item = this.dock.AddItem(padCodon.PadId);
      item.Label = LanguageOption.GetValueBykey(padCodon.Label);
      item.DefaultLocation = dockLocation;
      item.DefaultVisible = false;
      item.DefaultStatus = defaultStatus;
      item.DockLabelProvider = (IDockItemLabelProvider) padCodon;
      window.Item = item;
      if (padCodon.Initialized)
        this.CreatePadContent(true, padCodon, window, item);
      else
        item.ContentRequired += (EventHandler) ((param0, param1) => this.CreatePadContent(false, padCodon, window, item));
      item.VisibleChanged += (EventHandler) ((param0, param1) =>
      {
        if (item.Visible)
          window.NotifyShown();
        else
          window.NotifyHidden();
      });
      item.ContentVisibleChanged += (EventHandler) ((param0, param1) =>
      {
        if (item.ContentVisible)
          window.NotifyContentShown();
        else
          window.NotifyContentHidden();
      });
      if (this.padContentCollection.Contains(padCodon))
        return;
      this.padContentCollection.Add(padCodon);
    }

    private void UpdatePad(object source, EventArgs args)
    {
      IPadWindow key = (IPadWindow) source;
      if (!this.padCodons.ContainsKey(key))
        return;
      PadCodon padCodon = this.padCodons[key];
      DockItem dockItem = this.GetDockItem(padCodon);
      if (dockItem == null)
        return;
      string str = key.Title;
      if (string.IsNullOrEmpty(str))
        str = padCodon.Label;
      if (key.HasErrors && !key.ContentVisible)
        str = "<span foreground='red'>" + str + "</span>";
      else if (key.HasNewData && !key.ContentVisible)
        str = "<b>" + str + "</b>";
      dockItem.Label = str;
      dockItem.Icon = ImageService.GetIcon((string) key.Icon).WithSize(IconSize.Menu);
    }
  }
}
