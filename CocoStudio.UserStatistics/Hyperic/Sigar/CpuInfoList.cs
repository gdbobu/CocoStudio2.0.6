// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.CpuInfoList
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
    internal struct CpuInfoList
    {
        private readonly uint Number;

        private readonly uint size;

        private readonly System.IntPtr data;

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_cpu_info_list_get(System.IntPtr sigar, System.IntPtr cpu_infos);

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_cpu_info_list_destroy(System.IntPtr sigar, System.IntPtr cpu_infos);

        internal static CpuInfo[] NativeGet(Sigar sigar)
        {
            System.Type typeFromHandle = typeof(CpuInfoList);
            System.IntPtr intPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(typeFromHandle));
            int num = CpuInfoList.sigar_cpu_info_list_get(sigar.sigar.Handle, intPtr);
            if (num != 0)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
                throw Sigar.FindException(sigar, num);
            }
            CpuInfoList cpuInfoList = (CpuInfoList)System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeFromHandle);
            CpuInfo[] array = new CpuInfo[cpuInfoList.Number];
            System.IntPtr ptr = cpuInfoList.data;
            int num2 = System.Runtime.InteropServices.Marshal.SizeOf(array[0]);
            int num3 = 0;
            while ((long)num3 < (long)((ulong)cpuInfoList.Number))
            {
                array[num3] = (CpuInfo)System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof(CpuInfo));
                ptr = Sigar.incrementIntPtr(ptr, num2);
                num3++;
            }
            CpuInfoList.sigar_cpu_info_list_destroy(sigar.sigar.Handle, intPtr);
            System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
            return array;
        }
    }  
}
