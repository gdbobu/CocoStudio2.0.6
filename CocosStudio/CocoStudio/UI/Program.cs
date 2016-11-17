// Decompiled with JetBrains decompiler
// Type: CocoStudio.UI.Program
// Assembly: CocosStudio, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: F931EF05-B4A9-479F-8470-995544832753
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocosStudio.exe

using CocoStudio.Basic;
using CocoStudio.Core;
using GLib;
using Gtk;
using Modules.Communal.Guide;
using Modules.Communal.MutualEditor;
using Modules.Communal.StartAutoRecover;
using System;
using System.ComponentModel;

namespace CocoStudio.UI
{
  internal class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      Services.IntinalizeCompleted += (System.Action<EventArgs>) (e => StartRecoverService.Instance.InitializeEvent());
      Starter.Initialize(EnumEditorIDE.Ui, (string) null);
      if (!StartInfoService.Instance.PreCheckArgs(args))
        return;
      Starter.Run();
      bool? guideConfig = GuideXMLHelp.GetGuideConfig();
      if ((!guideConfig.GetValueOrDefault() ? 0 : (guideConfig.HasValue ? 1 : 0)) != 0 && GuideXMLHelp.GetImagePathList() != null)
        new GuideUC().ShowAll();
      Services.TaskService.Clear((object) null);
      Services.MainWindow.Closing += (EventHandler<CancelEventArgs>) ((s, e) => MutualCore.Instance.Dispose());
      int num = (int) GLib.Timeout.Add(1000U, (TimeoutHandler) (() =>
      {
        StartInfoService.Instance.OpenArgsProjSln();
        return false;
      }));
      Application.Run();
    }
  }
}
