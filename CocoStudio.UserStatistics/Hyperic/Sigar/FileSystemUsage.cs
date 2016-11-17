// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.FileSystemUsage
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct FileSystemUsage
  {
    public readonly long Total;
    public readonly long Free;
    public readonly long Avail;
    public readonly long Used;
    private readonly long NA_Files;
    private readonly long NA_FreeFiles;
    private readonly long DiskReads;
    private readonly long DiskWrites;
    private readonly long DiskWriteBytes;
    private readonly long DiskReadBytes;
    private readonly long DiskQueue;
    public readonly double UsePercent;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_file_system_usage_get(IntPtr sigar, string dirname, IntPtr fsusage);

    internal static FileSystemUsage NativeGet(Hyperic.Sigar.Sigar sigar, string dirname)
    {
      Type type = typeof (FileSystemUsage);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = FileSystemUsage.sigar_file_system_usage_get(sigar.sigar.Handle, dirname, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      FileSystemUsage structure = (FileSystemUsage) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
