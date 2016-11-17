// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Service.Runtime
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Assemblies;
using MonoDevelop.Core.Execution;
using MonoDevelop.Ide.Gui;
using System;
using System.Threading;

namespace CocoStudio.Core.Service
{
  public static class Runtime
  {
    private static SystemAssemblyService systemAssemblyService;
    private static bool initialized;

    public static ProcessService ProcessService
    {
      get
      {
        return MonoDevelop.Core.Runtime.ProcessService;
      }
    }

    public static void Initialize(string configDir, string addinsDir)
    {
      if (Runtime.initialized)
        return;
      Platform.Initialize();
      if (SynchronizationContext.Current == null)
      {
        SynchronizationContext.SetSynchronizationContext((SynchronizationContext) new GtkSynchronizationContext());
        MonoDevelop.Core.Runtime.MainSynchronizationContext = SynchronizationContext.Current;
      }
      AddinManager.AddinLoadError += new AddinErrorEventHandler(Runtime.OnLoadError);
      AddinManager.AddinLoaded += new AddinEventHandler(Runtime.OnLoad);
      AddinManager.AddinUnloaded += new AddinEventHandler(Runtime.OnUnload);
      try
      {
        AddinManager.Initialize(configDir, addinsDir);
        AddinManager.Registry.Update((IProgressStatus) null);
        Runtime.systemAssemblyService = new SystemAssemblyService();
        MonoDevelop.Core.Runtime.SystemAssemblyService = Runtime.systemAssemblyService;
        Runtime.systemAssemblyService.Initialize();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "RunTime initialize failed.", ex);
        AddinManager.AddinLoadError -= new AddinErrorEventHandler(Runtime.OnLoadError);
        AddinManager.AddinLoaded -= new AddinEventHandler(Runtime.OnLoad);
        AddinManager.AddinUnloaded -= new AddinEventHandler(Runtime.OnUnload);
      }
      Runtime.initialized = true;
    }

    private static void OnLoadError(object s, AddinErrorEventArgs args)
    {
      LogConfig.Logger.Error((object) ("Add-in error (" + args.AddinId + "): " + args.Message), args.Exception);
    }

    private static void OnLoad(object s, AddinEventArgs args)
    {
      LogConfig.Logger.Info((object) ("Add-in loaded: " + args.AddinId));
    }

    private static void OnUnload(object s, AddinEventArgs args)
    {
    }
  }
}
