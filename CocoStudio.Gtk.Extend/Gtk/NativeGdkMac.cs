// Decompiled with JetBrains decompiler
// Type: Gtk.NativeGdkMac
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Runtime.InteropServices;

namespace Gtk
{
  public static class NativeGdkMac
  {
    private const string dllGdkName = "libgdk-quartz-2.0.0.dylib";

    [DllImport("libgdk-quartz-2.0.0.dylib", EntryPoint = "gdk_quartz_window_get_nswindow")]
    public static extern IntPtr GetWindowHandle(IntPtr gdkWindow);

    [DllImport("libgdk-quartz-2.0.0.dylib", EntryPoint = "gdk_quartz_window_get_nsview")]
    public static extern IntPtr GetNSViewHandle(IntPtr gdkWindow);

    [DllImport("libgdk-quartz-2.0.0.dylib", EntryPoint = "gdk_window_ensure_native")]
    public static extern bool Gdk_window_ensure_native(IntPtr gdkWindow);
  }
}
