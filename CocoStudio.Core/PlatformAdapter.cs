// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.PlatformAdapter
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Desktop;
using System;
using System.Reflection;
using Xwt;

namespace CocoStudio.Core
{
  public static class PlatformAdapter
  {
    private static PlatformService platformService;
    private static Toolkit nativeToolkit;

    public static PlatformService PlatformService
    {
      get
      {
        if (PlatformAdapter.platformService == null)
          throw new InvalidOperationException("Not initialized");
        return PlatformAdapter.platformService;
      }
    }

    public static Toolkit NativeToolkit
    {
      get
      {
        if (PlatformAdapter.nativeToolkit == null)
          PlatformAdapter.nativeToolkit = PlatformAdapter.platformService.LoadNativeToolkit();
        return PlatformAdapter.nativeToolkit;
      }
    }

    public static void Initialize()
    {
      try
      {
        if (PlatformAdapter.platformService != null)
          return;
        Application.Initialize(ToolkitType.Gtk);
        Toolkit currentEngine = Toolkit.CurrentEngine;
        Type type = !Platform.IsMac ? Assembly.Load("CocoStudio.WindowsPlatform").GetType("CocoStudio.WindowsPlatform.CSWindowsPlatformService") : Assembly.Load("CocoStudio.MacPlatform").GetType("CocoStudio.MacPlatform.CSMacPlatformService");
        if (type != (Type) null)
          PlatformAdapter.platformService = Activator.CreateInstance(type) as PlatformService;
        DesktopService.PlatformService = PlatformAdapter.platformService;
        GC.KeepAlive((object) PlatformAdapter.NativeToolkit);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Initialize PlatformService failed.", ex);
      }
    }
  }
}
