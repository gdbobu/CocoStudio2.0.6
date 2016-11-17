// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.Sigar
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Hyperic.Sigar
{
    public class Sigar
    {
        internal const int OK = 0;
        internal const int SIGAR_START_ERROR = 20000;
        internal const int SIGAR_ENOTIMPL = 20001;
        public const string NULL_HWADDR = "00:00:00:00:00:00�";
        public const int IFF_UP = 1;
        public const int IFF_BROADCAST = 2;
        public const int IFF_DEBUG = 4;
        public const int IFF_LOOPBACK = 8;
        public const int IFF_POINTOPOINT = 16;
        public const int IFF_NOTRAILERS = 32;
        public const int IFF_RUNNING = 64;
        public const int IFF_NOARP = 128;
        public const int IFF_PROMISC = 256;
        public const int IFF_ALLMULTI = 512;
        public const int IFF_MULTICAST = 2048;
        internal const int FS_NAME_LEN = 64;
        internal const string LIBSIGAR = "sigar-x86-winnt.dll�";
        internal HandleRef sigar;

        public Sigar()
        {
            IntPtr zero = IntPtr.Zero;
            Hyperic.Sigar.Sigar.sigar_open(ref zero);
            this.sigar = new HandleRef((object)this, zero);
        }

        ~Sigar()
        {
            Hyperic.Sigar.Sigar.sigar_close(this.sigar.Handle);
        }

        [DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_open(ref IntPtr sigar);

        [DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_close(IntPtr sigar);

        [DllImport("sigar-x86-winnt.dll")]
        private static extern void sigar_format_size(long size, StringBuilder buffer);

        public static string FormatSize(long size)
        {
            StringBuilder buffer = new StringBuilder(56);
            Hyperic.Sigar.Sigar.sigar_format_size(size, buffer);
            return buffer.ToString();
        }

        public Who[] WhoList()
        {
            return Hyperic.Sigar.WhoList.NativeGet(this);
        }

        public Mem Mem()
        {
            return Hyperic.Sigar.Mem.NativeGet(this);
        }

        public Swap Swap()
        {
            return Hyperic.Sigar.Swap.NativeGet(this);
        }

        public SysInfo SysInfo()
        {
            return Hyperic.Sigar.SysInfo.NativeGet(this);
        }

        public Cpu Cpu()
        {
            return Hyperic.Sigar.Cpu.NativeGet(this);
        }

        public CpuInfo[] CpuInfoList()
        {
            return Hyperic.Sigar.CpuInfoList.NativeGet(this);
        }

        public FileSystem[] FileSystemList()
        {
            return Hyperic.Sigar.FileSystemList.NativeGet(this);
        }

        public FileSystemUsage FileSystemUsage(string dirname)
        {
            return Hyperic.Sigar.FileSystemUsage.NativeGet(this, dirname);
        }

        public string[] NetInterfaceList()
        {
            return Hyperic.Sigar.NetInterfaceList.NativeGet(this);
        }

        public NetInterfaceConfig NetInterfaceConfig(string name)
        {
            return Hyperic.Sigar.NetInterfaceConfig.NativeGet(this, name);
        }

        public NetInterfaceStat NetInterfaceStat(string name)
        {
            return Hyperic.Sigar.NetInterfaceStat.NativeGet(this, name);
        }

        internal static IntPtr incrementIntPtr(IntPtr ptr, int size)
        {
            return (IntPtr)((int)ptr + size);
        }

        internal static SigarException FindException(Hyperic.Sigar.Sigar sigar, int errno)
        {
            if (errno == 20001)
                return (SigarException)new SigarNotImplementedException(sigar, errno);
            return new SigarException(sigar, errno);
        }
    }
}
