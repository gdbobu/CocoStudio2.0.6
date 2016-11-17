// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.Swap
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct Swap
  {
    public readonly long Total;
    public readonly long Used;
    public readonly long Free;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_swap_get(IntPtr sigar, IntPtr swap);

    internal static Swap NativeGet(Hyperic.Sigar.Sigar sigar)
    {
      Type type = typeof (Swap);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = Swap.sigar_swap_get(sigar.sigar.Handle, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      Swap structure = (Swap) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
