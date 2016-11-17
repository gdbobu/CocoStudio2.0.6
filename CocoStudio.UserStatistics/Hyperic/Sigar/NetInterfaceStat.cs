// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.NetInterfaceStat
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct NetInterfaceStat
  {
    public readonly long RxPackets;
    public readonly long RxBytes;
    public readonly long RxErrors;
    public readonly long RxDropped;
    public readonly long RxOverruns;
    public readonly long RxFrame;
    public readonly long TxPackets;
    public readonly long TxBytes;
    public readonly long TxErrors;
    public readonly long TxDropped;
    public readonly long TxOverruns;
    public readonly long TxCollisions;
    public readonly long TxCarrier;

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_net_interface_stat_get(IntPtr sigar, string name, IntPtr ifstat);

    internal static NetInterfaceStat NativeGet(Hyperic.Sigar.Sigar sigar, string name)
    {
      Type type = typeof (NetInterfaceStat);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = NetInterfaceStat.sigar_net_interface_stat_get(sigar.sigar.Handle, name, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      NetInterfaceStat structure = (NetInterfaceStat) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }
  }
}
