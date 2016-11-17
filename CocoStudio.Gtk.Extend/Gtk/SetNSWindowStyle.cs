// Decompiled with JetBrains decompiler
// Type: Gtk.SetNSWindowStyle
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using MonoDevelop.Core;
using MonoMac.AppKit;
using System;

namespace Gtk
{
  public static class SetNSWindowStyle
  {
    public static void SetToDialogStyle(this Window window, Window parentWindow = null, bool closeable = true, bool centerToParent = true, bool setTransient = true)
    {
      if (parentWindow == null)
        parentWindow = ApplicationCurrent.MainWindow;
      if (centerToParent)
        window.CenterToParentWindow(parentWindow);
      if (setTransient)
        window.TransientFor = parentWindow;
      window.Deletable = closeable;
      if (!Platform.IsMac)
        return;
      NSWindowStyle nsWindowStyle = NSWindowStyle.Titled;
      if (closeable)
        nsWindowStyle |= NSWindowStyle.Closable;
      if (window.GdkWindow == null)
        window.Show();
      SetNSWindowStyle.GetNSWindow(window.GdkWindow).StyleMask = nsWindowStyle;
    }

    public static void CenterToParentWindow(this Window child, Window parent)
    {
      int width1;
      int height1;
      child.GetSize(out width1, out height1);
      int width2;
      int height2;
      parent.GetSize(out width2, out height2);
      int root_x;
      int root_y;
      parent.GetPosition(out root_x, out root_y);
      int x = Math.Max(0, (width2 - width1) / 2) + root_x;
      int y = Math.Max(0, (height2 - height1) / 2) + root_y;
      child.Move(x, y);
    }

    private static NSWindow GetNSWindow(Gdk.Window window)
    {
      return new NSWindow(NativeGdkMac.GetWindowHandle(window.Handle));
    }
  }
}
