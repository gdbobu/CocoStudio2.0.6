// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.SysInfo
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct SysInfo
  {
    private const int SIGAR_MAXHOSTNAMELEN = 256;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string name;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string version;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string arch;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string machine;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string description;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string patch_level;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string vendor;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string vendor_version;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string vendor_name;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string vendor_code_name;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_sys_info_get(IntPtr sigar, IntPtr sysInfo);

    internal static SysInfo NativeGet(Hyperic.Sigar.Sigar sigar)
    {
      Type type = typeof (SysInfo);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = SysInfo.sigar_sys_info_get(sigar.sigar.Handle, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      SysInfo structure = (SysInfo) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
