// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.NetInterfaceList
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
    internal struct NetInterfaceList
    {
        private readonly uint number;

        private readonly uint size;

        private readonly System.IntPtr data;

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_net_interface_list_get(System.IntPtr sigar, System.IntPtr iflist);

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_net_interface_list_destroy(System.IntPtr sigar, System.IntPtr iflist);

        internal static string[] NativeGet(Sigar sigar)
        {
            System.Type typeFromHandle = typeof(NetInterfaceList);
            System.IntPtr intPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(typeFromHandle));
            int num = NetInterfaceList.sigar_net_interface_list_get(sigar.sigar.Handle, intPtr);
            if (num != 0)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
                throw Sigar.FindException(sigar, num);
            }
            NetInterfaceList netInterfaceList = (NetInterfaceList)System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeFromHandle);
            string[] array = new string[netInterfaceList.number];
            System.IntPtr ptr = netInterfaceList.data;
            int num2 = 0;
            while ((long)num2 < (long)((ulong)netInterfaceList.number))
            {
                System.IntPtr ptr2 = System.Runtime.InteropServices.Marshal.ReadIntPtr(ptr, num2 * System.IntPtr.Size);
                array[num2] = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr2);
                num2++;
            }
            NetInterfaceList.sigar_net_interface_list_destroy(sigar.sigar.Handle, intPtr);
            System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
            return array;
        }
    }
}
