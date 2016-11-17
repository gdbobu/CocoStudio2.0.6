// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ProjectsOperations
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.ControlLib;
using CocoStudio.Core.Commands;
using CocoStudio.Core.Events;
using CocoStudio.Core.ExtensionModel;
using CocoStudio.Core.ProgressMonitors;
using CocoStudio.Core.View;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model;
using CocoStudio.Projects;
using CocoStudio.UndoManager;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CocoStudio.Core
{
  public class ProjectsOperations
  {
    private Project currentSelectedProject;

    public WorkspaceItem CurrentSelectedWorkspaceItem { get; set; }

    public Project CurrentSelectedProject
    {
      get
      {
        return this.currentSelectedProject;
      }
      set
      {
        this.currentSelectedProject = value;
        if (this.CurrentProjectChanged == null)
          return;
        this.CurrentProjectChanged((object) this, new ProjectsOperations.ProjectEventArgs(value));
      }
    }

    public Solution CurrentSelectedSolution
    {
      get
      {
        return ProjectsService.Instance.CurrentSolution;
      }
      set
      {
        if (ProjectsService.Instance.CurrentSolution == value)
          return;
        ProjectsService.Instance.CurrentSolution = value;
        this.OnCurrentSolutionChanged();
      }
    }

    public SolutionItem CurrentSelectedSolutionItem { get; set; }

    public ResourceGroup CurrentResourceGroup
    {
      get
      {
        return Services.ProjectsService.CurrentResourceGroup;
      }
    }

    public event EventHandler<SolutionEventArgs> CurrentSelectedSolutionClosed;

    public event EventHandler<SolutionEventArgs> CurrentSelectedSolutionClosing;

    public event EventHandler<SolutionEventArgs> CurrentSelectedSolutionChanged;

    public event EventHandler<ProjectsOperations.ProjectEventArgs> CurrentProjectChanged;

    public event EventHandler<ProjectCreatedEventArgs> ProjectCreated;

    internal ProjectsOperations()
    {
    }

    public Project AddNewProject(ResourceFolder parentResourceItem, IList<ResourceItem> selectesItem = null)
    {
      IMainTool mainTool = MainWindowPartFactory.GetMainTool();
      if (mainTool == null)
        throw new MissingMethodException("Can not find GetMainTool...");
      FilePath baseDirectory = parentResourceItem.BaseDirectory;
      FileDialogResult fileDialogResult = new NewFileDialog((Window) Services.MainWindow, (string) parentResourceItem.BaseDirectory, mainTool.CanvasSize).ShowDialog();
      if (fileDialogResult == null)
        return (Project) null;
      return this.AddNewProject(parentResourceItem, new ProjectCreateInformation((FilePath) Path.Combine((string) baseDirectory, fileDialogResult.FileName), (IProjectContent) null, selectesItem, (float) fileDialogResult.Size.Width, (float) fileDialogResult.Size.Height)
      {
        ContentType = fileDialogResult.FileType.ToString()
      });
    }

    public Project AddNewProject(ResourceFolder parentResourceItem, ProjectCreateInformation info)
    {
      Project project = Services.ProjectsService.CreateProject(info.ContentType, info);
      parentResourceItem.Items.Add((ResourceItem) project);
      IProgressMonitor monitor = Services.ProgressMonitors.Default;
      project.Save(monitor);
      project.Initialize(monitor);
      this.CurrentSelectedSolution.Save(monitor);
      return project;
    }

    public Project CreateDefalutSceneProject(bool isUpdateUI = true)
    {
      IMainTool mainTool = MainWindowPartFactory.GetMainTool();
      float width = mainTool == null ? 480f : (float) mainTool.CanvasSize.Width;
      float height = mainTool == null ? 320f : (float) mainTool.CanvasSize.Height;
      ResourceFolder rootFolder = this.CurrentResourceGroup.RootFolder;
      Project project = this.AddNewProject(rootFolder, new ProjectCreateInformation((FilePath) Path.Combine(rootFolder.FullPath, "MainScene.csd"), (IProjectContent) null, (IList<ResourceItem>) null, width, height)
      {
        ContentType = "Scene"
      });
      if (isUpdateUI)
      {
        Services.EventsService.GetEvent<AddResourcesEvent>().Publish(new AddResourcesArgs(rootFolder, (IEnumerable<ResourceItem>) new List<ResourceItem>()
        {
          (ResourceItem) project
        }, true));
        Services.Workbench.OpenDocument(project);
      }
      return project;
    }

    public IProgressMonitor ImportResourcesAsync(ResourceFolder parent, IEnumerable<string> pathes, List<ResourceItem> resourceItems, System.Action<IProgressMonitor> continueAction = null)
    {
      MessageDialogProgressMonitor monitor = Services.ProgressMonitors.GetMessageDialogProgreeMonitor();
      CancellationTokenSource tokenSource = new CancellationTokenSource();
      CancellationToken token = tokenSource.Token;
      Task task = Task.Factory.StartNew((System.Action) (() =>
      {
        IEnumerable<ResourceItem> collection = (IEnumerable<ResourceItem>) this.ImportResources(parent, pathes, (IProgressMonitor) monitor, token, (HashSet<string>) null);
        if (resourceItems == null || collection == null)
          return;
        resourceItems.AddRange(collection);
      }), token);
      monitor.CancelRequested += (MonitorHandler) (m => tokenSource.Cancel());
      task.ContinueWith((System.Action<Task>) (a =>
      {
        Services.ProjectOperations.CurrentSelectedSolution.Save(Services.ProgressMonitors.Default);
        if (continueAction != null)
          continueAction((IProgressMonitor) monitor);
        int num = (int) GLib.Timeout.Add(0U, (TimeoutHandler) (() =>
        {
          monitor.Dispose();
          if (monitor != null && monitor.Errors.Count == 0 && monitor.Warnings.Count == 0)
            monitor.CloseDialogs();
          return false;
        }));
      }));
      return (IProgressMonitor) monitor;
    }

    public List<ResourceItem> ImportResources(ResourceFolder parent, IEnumerable<string> pathes, IProgressMonitor monitor, CancellationToken token, HashSet<string> fileTypeSuffix = null)
    {
      List<ResourceItem> resourceItemList = new List<ResourceItem>();
      ImportResourceResult dic = FileOptionHelp.CopyToDic(parent, pathes, monitor, token, (IEnumerable<string>) fileTypeSuffix);
      return dic.AddResourcePanelItems.Union<ResourceItem>((IEnumerable<ResourceItem>) dic.ImportResources).ToList<ResourceItem>();
    }

    public List<ResourceItem> MessgeDialogImprotResource(ResourceFolder parent, IEnumerable<string> pathes)
    {
      MessageDialogProgressMonitor dialogProgreeMonitor = Services.ProgressMonitors.GetMessageDialogProgreeMonitor();
      ImportResourceResult dic = FileOptionHelp.CopyToDic(parent, pathes, (IProgressMonitor) dialogProgreeMonitor, CancellationToken.None, (IEnumerable<string>) null);
      dialogProgreeMonitor.Dispose();
      if (dialogProgreeMonitor != null && dialogProgreeMonitor.Errors.Count == 0 && dialogProgreeMonitor.Warnings.Count == 0)
        dialogProgreeMonitor.CloseDialogs();
      IEnumerable<ResourceItem> addItems = dic.AddResourcePanelItems.Union<ResourceItem>((IEnumerable<ResourceItem>) dic.ImportResources);
      Services.EventsService.GetEvent<AddResourcesEvent>().Publish(new AddResourcesArgs(parent, addItems, true));
      return dic.ImportResources;
    }

    public ResourceItem AddResourceItem(ResourceFolder parentResourceItem, FilePath itemFileName, IProgressMonitor monitor)
    {
      ResourceItem resourceItem = this.CurrentResourceGroup.FindResourceItem((ResourceItem) parentResourceItem, (string) itemFileName);
      if (resourceItem == null)
      {
        resourceItem = Services.ProjectsService.ReadResourceItem(monitor, (string) itemFileName);
        if (resourceItem is IProjectFile)
          ((IInitialize) resourceItem).Initialize(monitor);
        parentResourceItem.Items.Add(resourceItem);
      }
      monitor.Step(1);
      return resourceItem;
    }

    internal ResourceItem AddResourceItem(ResourceFolder parentResourceItem, FilePath itemFileName, IProgressMonitor monitor, out ResourceItem importRoot)
    {
      Stack<string> parentStack = this.CreateParentStack(itemFileName);
      ResourceItem resourceItem1 = (ResourceItem) null;
      ResourceFolder resourceFolder = parentResourceItem;
      importRoot = (ResourceItem) null;
      while (parentStack.Count > 0)
      {
        FilePath fullPath = (FilePath) resourceFolder.FullPath;
        string name = parentStack.Pop();
        ResourceItem resourceItem2 = resourceFolder.Items.FirstOrDefault<ResourceItem>((Func<ResourceItem, bool>) (n => n.Name == name));
        if (resourceItem2 == null)
        {
          resourceItem1 = Services.ProjectsService.ReadResourceItem(monitor, (string) fullPath.Combine(new string[1]{ name }));
          if (resourceItem1 is IProjectFile)
            ((IInitialize) resourceItem1).Initialize(monitor);
          resourceFolder.Items.Add(resourceItem1);
          resourceFolder = resourceItem1 as ResourceFolder;
          if (importRoot == null)
            importRoot = resourceItem1;
        }
        else
        {
          if ((FilePath) resourceItem2.FullPath == itemFileName)
            return resourceItem2;
          resourceFolder = resourceItem2 as ResourceFolder;
        }
        if (resourceItem1 != null && (FilePath) resourceItem1.FullPath == itemFileName)
          return resourceItem1;
      }
      return resourceItem1;
    }

    private Stack<string> CreateParentStack(FilePath importPath)
    {
      Stack<string> stringStack = new Stack<string>();
      for (FilePath baseDirectory = this.CurrentResourceGroup.RootFolder.BaseDirectory; importPath != baseDirectory; importPath = importPath.ParentDirectory)
        stringStack.Push(importPath.FileName);
      return stringStack;
    }

    public List<ResourceItem> AddResourceItem(IEnumerable<string> filesPath, IEnumerable<string> fileTypeSuffix = null)
    {
      if (filesPath == null)
        return (List<ResourceItem>) null;
      string path = filesPath.FirstOrDefault<string>();
      ResourceFolder rootFolder = this.CurrentResourceGroup.RootFolder;
      List<ResourceItem> resourceItemList1 = new List<ResourceItem>();
      List<ResourceItem> resourceItemList2 = new List<ResourceItem>();
      IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
      if ((FilePath) Path.GetDirectoryName(path) != rootFolder.BaseDirectory)
      {
        HashSet<string> fileTypeSuffix1 = fileTypeSuffix == null ? (HashSet<string>) null : new HashSet<string>(fileTypeSuffix, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
        List<ResourceItem> resourceItemList3 = this.ImportResources(rootFolder, filesPath, consoleProgressMonitor, CancellationToken.None, fileTypeSuffix1);
        if (null != resourceItemList3)
        {
          resourceItemList1.AddRange((IEnumerable<ResourceItem>) resourceItemList3);
          resourceItemList2.AddRange((IEnumerable<ResourceItem>) resourceItemList3);
        }
      }
      else
      {
        foreach (string filePath in filesPath)
        {
          ResourceItem resourceItem = this.CurrentResourceGroup.FindResourceItem(filePath);
          if (resourceItem == null)
          {
            resourceItem = this.AddResourceItem(rootFolder, (FilePath) filePath, consoleProgressMonitor);
            resourceItemList2.Add(resourceItem);
          }
          if (resourceItem != null)
            resourceItemList1.Add(resourceItem);
        }
      }
      Services.ProjectOperations.CurrentSelectedSolution.Save(consoleProgressMonitor);
      Services.EventsService.GetEvent<AddResourcesEvent>().Publish(new AddResourcesArgs(rootFolder, (IEnumerable<ResourceItem>) resourceItemList2, true));
      return resourceItemList1;
    }

    public List<ResourceItem> AddResourceItems(ResourceFolder parent, IEnumerable<string> pathes, IProgressMonitor monitor)
    {
      if (pathes == null || pathes.Count<string>() <= 0)
        return (List<ResourceItem>) null;
      List<ResourceItem> resourceItemList = new List<ResourceItem>();
      foreach (string pathe in pathes)
      {
        ResourceItem resourceItem = this.AddResourceItem(parent, (FilePath) pathe, monitor);
        resourceItemList.Add(resourceItem);
        if (FileService.IsDirectory(pathe))
        {
          string[] fileSystemEntries = Directory.GetFileSystemEntries(pathe);
          this.AddResourceItems((ResourceFolder) resourceItem, (IEnumerable<string>) fileSystemEntries, monitor);
        }
      }
      Services.ProjectOperations.CurrentSelectedSolution.Save(monitor);
      return resourceItemList;
    }

    public Solution OpenSolution(IProgressMonitor monitor, string filePath)
    {
      Solution wrapperSolution = Services.ProjectsService.GetWrapperSolution(monitor, filePath);
      if (!ProjectsOperations.CheckProjectVersion(wrapperSolution.Version))
      {
        MessageBox.Show(LanguageInfo.MessageBox_Content71, (Window) null, (string) null, MessageBoxImage.Info);
        return (Solution) null;
      }
      wrapperSolution.Version = Option.EditorVersion;
      wrapperSolution.Save(monitor);
      ProjectsService.Instance.CurrentSolution = wrapperSolution;
      wrapperSolution.Initialize(monitor);
      this.CurrentSelectedWorkspaceItem = (WorkspaceItem) wrapperSolution;
      using (TaskServiceLock.Lock())
        this.OnCurrentSolutionChanged();
      Services.RecentFileService.AddFile((string) this.CurrentSelectedSolution.FileName);
      return wrapperSolution;
    }

    public Solution OpenSolution(Solution sln)
    {
      IProgressMonitor progressMonitor = Services.ProgressMonitors.GetProgressMonitor();
      sln.Initialize(progressMonitor);
      this.CurrentSelectedWorkspaceItem = (WorkspaceItem) sln;
      this.CurrentSelectedSolution = sln;
      Services.RecentFileService.AddFile((string) this.CurrentSelectedSolution.FileName);
      return sln;
    }

    public void OpenDefaultSolution(string directory, string name)
    {
      try
      {
        GlobalCommand.OpenCmd.RaiseExecute((object) Path.Combine(directory, name, name + ".ccs"));
        Project resourceItem = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(Path.Combine(directory, name, "CocosStudio".ToLower(), "MainScene.csd")) as Project;
        if (resourceItem == null)
          return;
        Services.Workbench.OpenDocument(resourceItem);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("打开默认项目失败：\r\n" + ex.ToString()));
      }
    }

    public Solution CreateNewSolution(string directory, string name)
    {
      Solution solution = Services.ProjectsService.CreateSolution(directory, name);
      Services.RecentFileService.LastCreatePrjDirectory = directory;
      RootWorkspace workspace = Services.Workspace;
      workspace.Items.Add((WorkspaceItem) solution);
      IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
      workspace.Save(consoleProgressMonitor);
      return solution;
    }

    public void Publish(IProgressMonitor monitor, PublishInfo info)
    {
      HashSet<ResourceData> usedResources = Services.ProjectOperations.CurrentResourceGroup.GetUsedResources(monitor);
      if (!monitor.AsyncOperation.Success)
        return;
      foreach (ResourceData resourceData in usedResources)
      {
        if (Services.ProjectsService.IsProjectFile(resourceData))
        {
          Project resourceItem = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(resourceData) as Project;
          if (resourceItem != null)
            resourceItem.Publish(monitor, info);
        }
        else
          ProjectsOperations.CopyResourceData(monitor, (FilePath) info.PublishDirectory, resourceData);
      }
    }

    private static void CopyResourceData(IProgressMonitor monitor, FilePath publishDirectory, ResourceData resourceData)
    {
      FilePath path = (FilePath) resourceData.Path;
      FilePath filePath1 = (FilePath) ((string) null);
      FilePath filePath2 = resourceData.Type != EnumResourceType.Default ? path.ToAbsolute(Services.ProjectOperations.CurrentSelectedSolution.ItemDirectory) : (FilePath) Option.GetEditorResourceFullPath(resourceData.Path);
      FilePath absolute = path.ToAbsolute(publishDirectory);
      if (!Directory.Exists((string) absolute.ParentDirectory))
        Directory.CreateDirectory((string) absolute.ParentDirectory);
      if (!File.Exists((string) filePath2))
        return;
      FileService.CopyFile((string) filePath2, (string) absolute);
    }

    public bool CloseSolution()
    {
      if (this.CurrentSelectedSolutionClosing != null)
        this.CurrentSelectedSolutionClosing((object) this, new SolutionEventArgs(this.CurrentSelectedSolution));
      if (Services.ProjectOperations.CurrentSelectedSolution == null)
        return true;
      if (!Services.Workbench.CloseAll(false))
        return false;
      if (Services.Workspace.Items.Count != 0)
        Services.Workspace.CloseWorkspaceItem(Services.Workspace.Items[0], true);
      if (this.CurrentSelectedSolutionClosed != null)
        this.CurrentSelectedSolutionClosed((object) this, new SolutionEventArgs(this.CurrentSelectedSolution));
      try
      {
        CSCocosHelp.ClearResurceCache();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Clear resource cache failed.", ex);
      }
      Services.ProjectOperations.CurrentSelectedSolution = (Solution) null;
      return true;
    }

    public void Save(IProjectFile projectFile)
    {
      IProgressMonitor monitor = Services.ProgressMonitors.Default;
      try
      {
        projectFile.Save(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Save failed.", ex);
      }
    }

    private void OnCurrentSolutionChanged()
    {
      if (this.CurrentSelectedSolutionChanged == null)
        return;
      this.CurrentSelectedSolutionChanged((object) this, new SolutionEventArgs(this.CurrentSelectedSolution));
    }

    public void MarkFileDirty(string filename)
    {
      try
      {
        FileInfo fileInfo = new FileInfo(filename);
        if (!fileInfo.Exists)
          return;
        fileInfo.LastWriteTime = DateTime.Now;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Error while marking file as dirty", ex);
      }
    }

    private static bool CheckProjectVersion(Version projectVersion)
    {
      return projectVersion.CompareTo(Option.EditorVersion) <= 0;
    }

    public class ProjectEventArgs : EventArgs
    {
      public Project Project { get; private set; }

      public ProjectEventArgs(Project project)
      {
        this.Project = project;
      }
    }
  }
}
