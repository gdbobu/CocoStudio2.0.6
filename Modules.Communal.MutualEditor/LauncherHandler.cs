// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.LauncherHandler
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using Gtk;
using Xwt.GtkBackend;

namespace Modules.Communal.MutualEditor
{
  internal class LauncherHandler : BaseHandler
  {
    private const int portNumber = 9010;

    protected override int GetStartPort()
    {
      return 9010;
    }

    protected override void OnHandleMessageRecived(object sender, MessageArgs args)
    {
      if (args.Message.Action != Action.Show || ApplicationCurrent.MainWindow == null)
        return;
      if (MonoDevelop.Core.Platform.IsMac)
        GtkWorkarounds.GrabDesktopFocus();
      ApplicationCurrent.MainWindow.Present();
    }
  }
}
