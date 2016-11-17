// Decompiled with JetBrains decompiler
// Type: Gtk.GtkWindowHelper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using GLib;
using MonoDevelop.Core;
using OpenDialogs;
using System;

namespace Gtk
{
  public static class GtkWindowHelper
  {
    public static void CanActivationTop(Window window)
    {
      if (window == null)
        return;
      window.WidgetEvent += new WidgetEventHandler(GtkWindowHelper.GtkWindow_WidgetEvent);
      window.Destroyed += new EventHandler(GtkWindowHelper.window_Destroyed);
    }

    private static void window_Destroyed(object sender, EventArgs e)
    {
      Window window = sender as Window;
      if (window == null)
        return;
      window.Destroyed -= new EventHandler(GtkWindowHelper.window_Destroyed);
      window.WidgetEvent -= new WidgetEventHandler(GtkWindowHelper.GtkWindow_WidgetEvent);
    }

    [ConnectBefore]
    private static void GtkWindow_WidgetEvent(object o, WidgetEventArgs args)
    {
      if (!Platform.IsWindows)
        return;
      Window window = o as Window;
      if (window != null && !window.IsFocus && args.Event.ToString().Equals("Gdk.EventButton"))
        WindowHelper.ShowCurrentWindowHandle();
    }

    public static T GetParentWidget<T>(this Widget widget) where T : Widget
    {
      Widget widget1 = widget;
      while (widget1 != null)
      {
        widget1 = widget1.Parent;
        if (widget1 == null || widget1 is T)
          break;
      }
      return widget1 as T;
    }
  }
}
