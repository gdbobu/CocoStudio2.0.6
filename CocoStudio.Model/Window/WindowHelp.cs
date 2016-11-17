// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Window.WindowHelp
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using Gtk;
using System;
using Xwt.GtkBackend;

namespace CocoStudio.Model.Window
{
  internal static class WindowHelp
  {
    private static Gdk.Window gdkWindow;

    public static CSWindow CreateCSWindow(Gdk.Window gdkWindow)
    {
      if (Platform.IsMac)
        return WindowHelp.CreateMac(gdkWindow);
      if (Platform.IsWindows)
        return WindowHelp.CreateWin32(gdkWindow);
      throw new NotImplementedException();
    }

    public static CSWindow CreateCSWindow(IntPtr windowHandle, int width, int height)
    {
      return new CSWindow(windowHandle.ToInt32(), width, height, WindowHelp.GetStartupPath());
    }

    public static void UpdateOpenGLContext(bool isShowing, CSWindow csWindow, Gdk.Window gdkWindow)
    {
      if (Platform.IsWindows)
      {
        if (!isShowing || gdkWindow == null)
          return;
        NativeGdkWin.Gdk_window_ensure_native(gdkWindow.Handle);
        IntPtr windowHandle = NativeGdkWin.GetWindowHandle(gdkWindow.Handle);
        csWindow.UpdateOpenGLContext(isShowing, windowHandle.ToInt32());
        System.GC.Collect();
      }
      else
      {
        if (!Platform.IsMac)
          throw new NotImplementedException();
        csWindow.UpdateOpenGLContext(isShowing, 0);
      }
    }

    private static CSWindow CreateMac(Gdk.Window window)
    {
      WindowHelp.gdkWindow = window;
      IntPtr windowHandle = NativeGdkMac.GetWindowHandle(WindowHelp.gdkWindow.Handle);
      IntPtr nsViewHandle = NativeGdkMac.GetNSViewHandle(WindowHelp.gdkWindow.Handle);
      int width;
      int height;
      WindowHelp.gdkWindow.GetSize(out width, out height);
      string startupPath = WindowHelp.GetStartupPath();
      return new CSWindow(windowHandle, nsViewHandle, width, height, startupPath);
    }

    private static CSWindow CreateWin32(Gdk.Window gdkWindow)
    {
      NativeGdkWin.Gdk_window_ensure_native(gdkWindow.Handle);
      IntPtr windowHandle = NativeGdkWin.GetWindowHandle(gdkWindow.Handle);
      int width;
      int height;
      gdkWindow.GetSize(out width, out height);
      return new CSWindow(windowHandle.ToInt32(), width, height, WindowHelp.GetStartupPath());
    }

    private static string GetStartupPath()
    {
      return AppDomain.CurrentDomain.BaseDirectory;
    }
  }
}
