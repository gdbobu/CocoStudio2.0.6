// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.NetInterfaceConfig
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Hyperic.Sigar
{
  public struct NetInterfaceConfig
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public readonly string Name;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string Type;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string Description;
    private readonly NetAddress hwaddr;
    private readonly NetAddress address;
    private readonly NetAddress destination;
    private readonly NetAddress broadcast;
    private readonly NetAddress netmask;
    public readonly long Flags;
    public readonly long Mtu;
    public readonly long Metric;

    public string Hwaddr
    {
      get
      {
        return this.inet_ntoa(this.hwaddr);
      }
    }

    public string Address
    {
      get
      {
        return this.inet_ntoa(this.address);
      }
    }

    public string Destination
    {
      get
      {
        return this.inet_ntoa(this.destination);
      }
    }

    public string Broadcast
    {
      get
      {
        return this.inet_ntoa(this.broadcast);
      }
    }

    public string Netmask
    {
      get
      {
        return this.inet_ntoa(this.netmask);
      }
    }

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_net_interface_config_get(IntPtr sigar, string name, IntPtr ifconfig);

    internal static NetInterfaceConfig NativeGet(Hyperic.Sigar.Sigar sigar, string name)
    {
      System.Type type = typeof (NetInterfaceConfig);
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(type));
      int errno = NetInterfaceConfig.sigar_net_interface_config_get(sigar.sigar.Handle, name, num);
      if (errno != 0)
      {
        Marshal.FreeHGlobal(num);
        throw Hyperic.Sigar.Sigar.FindException(sigar, errno);
      }
      NetInterfaceConfig structure = (NetInterfaceConfig) Marshal.PtrToStructure(num, type);
      Marshal.FreeHGlobal(num);
      return structure;
    }

    [DllImport("sigar-x86-winnt.dll")]
    private static extern int sigar_net_address_to_string(IntPtr sigar, IntPtr address, StringBuilder addr_str);

    private string inet_ntoa(NetAddress address)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf((object) address));
      StringBuilder addr_str = new StringBuilder();
      addr_str.Capacity = 46;
      Marshal.StructureToPtr((object) address, num, true);
      NetInterfaceConfig.sigar_net_address_to_string(IntPtr.Zero, num, addr_str);
      return addr_str.ToString();
    }

    public string FlagsString()
    {
      long flags = this.Flags;
      string str = "";
      if (flags == 0L)
        str += "[NO FLAGS] ";
      if ((flags & 1L) > 0L)
        str += "UP ";
      if ((flags & 2L) > 0L)
        str += "BROADCAST ";
      if ((flags & 4L) > 0L)
        str += "DEBUG ";
      if ((flags & 8L) > 0L)
        str += "LOOPBACK ";
      if ((flags & 16L) > 0L)
        str += "POINTOPOINT ";
      if ((flags & 32L) > 0L)
        str += "NOTRAILERS ";
      if ((flags & 64L) > 0L)
        str += "RUNNING ";
      if ((flags & 128L) > 0L)
        str += "NOARP ";
      if ((flags & 256L) > 0L)
        str += "PROMISC ";
      if ((flags & 512L) > 0L)
        str += "ALLMULTI ";
      if ((flags & 2048L) > 0L)
        str += "MULTICAST ";
      return str;
    }
  }
}
