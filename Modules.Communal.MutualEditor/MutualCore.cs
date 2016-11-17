// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.MutualCore
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using Gtk;
using MonoDevelop.Core;

namespace Modules.Communal.MutualEditor
{
  public class MutualCore
  {
    private static IUDPHandler mutualcore;

    public static IUDPHandler Instance
    {
      get
      {
        if (MutualCore.mutualcore == null)
          MutualCore.Init();
        return MutualCore.mutualcore;
      }
    }

    public static void Init()
    {
      if (MutualCore.mutualcore != null)
        MutualCore.mutualcore.Dispose();
      if (Option.CurrentEditorIDE == EnumEditorIDE.Launcher)
        MutualCore.mutualcore = (IUDPHandler) new LauncherHandler();
      else
        MutualCore.mutualcore = (IUDPHandler) new EditorHandler();
    }

    public static void ShowCurrApplication()
    {
      if (Platform.IsMac)
      {
        if (ApplicationCurrent.MainWindow == null)
          return;
        ApplicationCurrent.MainWindow.Deiconify();
        ApplicationCurrent.MainWindow.Visible = true;
      }
      else
      {
        Services.MainWindow.GdkWindow.Show();
        Services.MainWindow.GdkWindow.Deiconify();
      }
    }
  }
}
