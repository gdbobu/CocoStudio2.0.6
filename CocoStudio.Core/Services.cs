// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Services
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.ModulesInterface;
using CocoStudio.Core.View;
using CocoStudio.Lib.Prism;
using CocoStudio.Projects;
using CocoStudio.UndoManager;
using Gtk;
using Mono.Addins;
using MonoDevelop.Ide;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Core
{
  public static class Services
  {
    private static Dictionary<Type, IService> servicesCollection = new Dictionary<Type, IService>();

    public static ProjectsService ProjectsService { get; private set; }

    public static ProjectsOperations ProjectOperations { get; private set; }

    public static IEventAggregator EventsService { get; private set; }

    public static RootWorkspace Workspace { get; private set; }

    public static MainWindow MainWindow { get; internal set; }

    public static IAutoSaveManager AutoSaveService { get; private set; }

    public static IUndoManager TaskService
    {
      get
      {
        return TaskServiceSingleton.Instance;
      }
    }

    public static RecentFilesService RecentFileService { get; private set; }

    public static Workbench Workbench { get; internal set; }

    public static ProgressMonitorManager ProgressMonitors { get; private set; }

    public static event System.Action<EventArgs> IntinalizeCompleted;

    public static void Intinalize()
    {
      Services.InternalIntinalize();
      MessageService.RootWindow = (Window) Services.MainWindow;
      if (Services.IntinalizeCompleted == null)
        return;
      Services.IntinalizeCompleted((EventArgs) new Services.CompletedEventArgs());
    }

    private static void InternalIntinalize()
    {
      Services.ProjectsService = ProjectsService.Instance;
      Services.EventsService = (IEventAggregator) EventAggregator.Instance;
      Services.ProjectOperations = new ProjectsOperations();
      Services.Workspace = new RootWorkspace();
      Services.RecentFileService = new RecentFilesService(false);
      Services.AutoSaveService = ((IEnumerable<IAutoSaveManager>) AddinManager.GetExtensionObjects<IAutoSaveManager>()).FirstOrDefault<IAutoSaveManager>();
      if (Services.AutoSaveService != null)
        Services.AutoSaveService.StartAutoSave();
      Services.ProgressMonitors = new ProgressMonitorManager();
      Services.ProjectsService.DefaultMonitor = Services.ProgressMonitors.Default;
      Services.TaskService.Enable = true;
    }

    internal static void TestIntinalize()
    {
      Services.InternalIntinalize();
    }

    public static void RegisterService<T>(T service) where T : class, IService
    {
      if (Services.servicesCollection.ContainsKey(typeof (T)))
        throw new ArgumentException("Already rigisted service.");
      Services.servicesCollection[typeof (T)] = (IService) service;
    }

    public static T GetService<T>() where T : class, IService
    {
      IService service;
      Services.servicesCollection.TryGetValue(typeof (T), out service);
      return service as T;
    }

    public class CompletedEventArgs : EventArgs
    {
    }
  }
}
