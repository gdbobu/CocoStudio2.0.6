// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.Mem
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct Mem
  {
    public readonly long Ram;
    public readonly long Total;
    public readonly long Used;
    public readonly long Free;
    public readonly long Shared;
    public readonly long ActualFree;
    public readonly long ActualUsed;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_mem_get(IntPtr sigar, IntPtr mem);

    internal static Mem NativeGet(Hyperic.Sigar.Sigar sigar)
    {
      Type type = typeof (Mem);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = Mem.sigar_mem_get(sigar.sigar.Handle, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      Mem structure = (Mem) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
