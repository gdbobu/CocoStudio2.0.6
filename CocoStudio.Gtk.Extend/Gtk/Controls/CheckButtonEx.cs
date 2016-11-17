// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.CheckButtonEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;

namespace Gtk.Controls
{
  public class CheckButtonEx : CheckButton
  {
    protected override bool OnKeyReleaseEvent(EventKey evnt)
    {
      if (evnt.Key == Gdk.Key.space)
        return false;
      return base.OnKeyReleaseEvent(evnt);
    }
  }
}
