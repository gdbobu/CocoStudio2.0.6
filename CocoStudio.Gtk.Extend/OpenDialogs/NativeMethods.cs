// Decompiled with JetBrains decompiler
// Type: OpenDialogs.NativeMethods
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenDialogs
{
  public static class NativeMethods
  {
    public const int HWND_TOP = 0;
    public const int SW_SHOW = 5;
    public const int SW_HIDE = 0;

    [DllImport("user32.dll")]
    public static extern int CloseWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern int EnableWindow(IntPtr hwnd, int fEnable);

    [DllImport("user32.dll")]
    public static extern int SetWindowText(IntPtr hwnd, string lpString);

    [DllImport("user32.dll")]
    public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);

    [DllImport("kernel32.dll")]
    public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern int VirtualAllocEx(int hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("User32.Dll")]
    public static extern int GetDlgCtrlID(IntPtr hWndCtl);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int MapWindowPoints(IntPtr hWnd, IntPtr hWndTo, ref POINT pt, int cPoints);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowInfo(IntPtr hwnd, out WINDOWINFO pwi);

    [DllImport("User32.Dll")]
    public static extern void GetWindowText(IntPtr hWnd, StringBuilder param, int length);

    [DllImport("User32.Dll")]
    public static extern void GetClassName(IntPtr hWnd, StringBuilder param, int length);

    [DllImport("user32.Dll")]
    public static extern bool EnumChildWindows(IntPtr hWndParent, NativeMethods.EnumWindowsCallBack lpEnumFunc, int lParam);

    [DllImport("user32.Dll")]
    public static extern bool EnumWindows(NativeMethods.EnumWindowsCallBack lpEnumFunc, int lParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern bool ReleaseCapture();

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SetCapture(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr ChildWindowFromPointEx(IntPtr hParent, POINT pt, ChildFromPointFlags flags);

    [DllImport("user32.dll", EntryPoint = "FindWindowExA", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll")]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder param);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, char[] chars);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr BeginDeferWindowPos(int nNumWindows);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr DeferWindowPos(IntPtr hWinPosInfo, IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rect);

    [DllImport("user32.dll")]
    public static extern bool GetClientRect(IntPtr hwnd, ref RECT rect);

    public delegate bool EnumWindowsCallBack(IntPtr hWnd, int lParam);
  }
}
