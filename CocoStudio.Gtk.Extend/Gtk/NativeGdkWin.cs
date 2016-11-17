// Decompiled with JetBrains decompiler
// Type: Gtk.NativeGdkWin
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Runtime.InteropServices;

namespace Gtk
{
  public static class NativeGdkWin
  {
    private const string dllGdkName = "libgdk-win32-2.0-0.dll";

    [DllImport("libgdk-win32-2.0-0.dll", EntryPoint = "gdk_win32_window_get_impl_hwnd", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetWindowHandle(IntPtr gdkWindow);

    [DllImport("libgdk-win32-2.0-0.dll", EntryPoint = "gdk_window_ensure_native", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Gdk_window_ensure_native(IntPtr gdkWindow);
  }
}
