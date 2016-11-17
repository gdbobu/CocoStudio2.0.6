// Decompiled with JetBrains decompiler
// Type: OpenDialogs.WindowHelper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenDialogs
{
  public class WindowHelper
  {
    private static Hashtable processWnd = new Hashtable();
    public bool haveMainWindow = false;
    public IntPtr mainWindowHandle = IntPtr.Zero;
    public int processId = 0;
    private const int SW_SHOWDEFAULT = 10;
    private const int MAX_PATH = 260;
    private const int CSIDL_COMMON_DESKTOPDIRECTORY = 25;

    public IntPtr GetMainWindowHandle(int processId)
    {
      if (!this.haveMainWindow)
      {
        this.mainWindowHandle = IntPtr.Zero;
        this.processId = processId;
        WindowHelper.EnumThreadWindowsCallback callback = new WindowHelper.EnumThreadWindowsCallback(this.EnumWindowsCallback);
        WindowHelper.EnumWindows(callback, IntPtr.Zero);
        GC.KeepAlive((object) callback);
        this.haveMainWindow = true;
      }
      return this.mainWindowHandle;
    }

    public bool EnumWindowsCallback(IntPtr handle, IntPtr extraParameter)
    {
      int processId;
      WindowHelper.GetWindowThreadProcessId(new HandleRef((object) this, handle), out processId);
      if (processId != this.processId || !this.IsMainWindow(handle))
        return true;
      this.mainWindowHandle = handle;
      return false;
    }

    public bool IsMainWindow(IntPtr handle)
    {
      return !(WindowHelper.GetWindow(new HandleRef((object) this, handle), 4) != IntPtr.Zero) && WindowHelper.IsWindowVisible(new HandleRef((object) this, handle));
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool EnumWindows(WindowHelper.EnumThreadWindowsCallback callback, IntPtr extraData);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool IsWindowVisible(HandleRef hWnd);

    public static IntPtr GetCurrentWindowHandle()
    {
      IntPtr zero = IntPtr.Zero;
      return new WindowHelper().GetMainWindowHandle(Process.GetCurrentProcess().Id);
    }

    [DllImport("user32.dll")]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hwnd);

    public static int ShowWindow(IntPtr hwnd)
    {
      WindowHelper.SetForegroundWindow(hwnd);
      return 0;
    }

    public static void ShowCurrentWindowHandle()
    {
      WindowHelper.ShowWindow(WindowHelper.GetCurrentWindowHandle());
    }

    [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
    private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

    public static string GetAllUsersDesktopFolderPath()
    {
      StringBuilder lpszPath = new StringBuilder(260);
      WindowHelper.SHGetFolderPath(IntPtr.Zero, 25, IntPtr.Zero, 0, lpszPath);
      return lpszPath.ToString();
    }

    public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

    public delegate bool WNDENUMPROC(IntPtr hwnd, uint lParam);
  }
}
