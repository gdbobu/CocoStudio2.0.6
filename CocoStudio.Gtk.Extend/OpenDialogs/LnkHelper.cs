// Decompiled with JetBrains decompiler
// Type: OpenDialogs.LnkHelper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenDialogs
{
  public class LnkHelper
  {
    [Flags]
    public enum SLR_FLAGS
    {
      SLR_NO_UI = 1,
      SLR_ANY_MATCH = 2,
      SLR_UPDATE = 4,
      SLR_NOUPDATE = 8,
      SLR_NOSEARCH = 16,
      SLR_NOTRACK = 32,
      SLR_NOLINKINFO = 64,
      SLR_INVOKE_MSI = 128,
    }

    [Flags]
    public enum SLGP_FLAGS
    {
      SLGP_SHORTPATH = 1,
      SLGP_UNCPRIORITY = 2,
      SLGP_RAWPATH = 4,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
      private const int MAX_PATH = 260;
      public int dwFileAttributes;
      public FILETIME ftCreationTime;
      public FILETIME ftLastAccessTime;
      public FILETIME ftLastWriteTime;
      public int nFileSizeHigh;
      public int nFileSizeLow;
      public int dwReserved0;
      public int dwReserved1;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string cFileName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
      public string cAlternateFileName;
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IShellLink
    {
      void GetPath([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszFile, int cchMaxPath, out LnkHelper.WIN32_FIND_DATA pfd, LnkHelper.SLGP_FLAGS fFlags);

      void GetIDList(out IntPtr ppidl);

      void SetIDList(IntPtr pidl);

      void GetDescription([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszName, int cchMaxName);

      void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

      void GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszDir, int cchMaxPath);

      void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

      void GetArguments([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszArgs, int cchMaxPath);

      void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

      void GetHotkey(out short pwHotkey);

      void SetHotkey(short wHotkey);

      void GetShowCmd(out int piShowCmd);

      void SetShowCmd(int iShowCmd);

      void GetIconLocation([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

      void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

      void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);

      void Resolve(IntPtr hwnd, LnkHelper.SLR_FLAGS fFlags);

      void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [Guid("00021401-0000-0000-C000-000000000046")]
    [ComImport]
    public class ShellLink
    {
    }
  }
}
