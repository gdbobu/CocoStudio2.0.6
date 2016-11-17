// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.Cpu
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct Cpu
  {
    public readonly long User;
    public readonly long Sys;
    private readonly long NA_Nice;
    public readonly long Idle;
    private readonly long NA_Wait;
    public readonly long Total;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_cpu_get(IntPtr sigar, IntPtr cpu);

    internal static Cpu NativeGet(Hyperic.Sigar.Sigar sigar)
    {
      Type type = typeof (Cpu);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = Cpu.sigar_cpu_get(sigar.sigar.Handle, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      Cpu structure = (Cpu) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
