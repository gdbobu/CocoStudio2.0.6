// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.WhoList
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
    public struct WhoList
    {
        private readonly uint Number;

        private readonly uint size;

        private readonly System.IntPtr data;

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_who_list_get(System.IntPtr sigar, System.IntPtr cpu_infos);

        [System.Runtime.InteropServices.DllImport("sigar-x86-winnt.dll")]
        private static extern int sigar_who_list_destroy(System.IntPtr sigar, System.IntPtr cpu_infos);

        internal static Who[] NativeGet(Sigar sigar)
        {
            System.Type typeFromHandle = typeof(WhoList);
            System.IntPtr intPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(typeFromHandle));
            int num = WhoList.sigar_who_list_get(sigar.sigar.Handle, intPtr);
            if (num != 0)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
                throw Sigar.FindException(sigar, num);
            }
            WhoList whoList = (WhoList)System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeFromHandle);
            Who[] array = new Who[whoList.Number];
            System.IntPtr ptr = whoList.data;
            int num2 = System.Runtime.InteropServices.Marshal.SizeOf(array[0]);
            int num3 = 0;
            while ((long)num3 < (long)((ulong)whoList.Number))
            {
                array[num3] = (Who)System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof(Who));
                ptr = Sigar.incrementIntPtr(ptr, num2);
                num3++;
            }
            WhoList.sigar_who_list_destroy(sigar.sigar.Handle, intPtr);
            System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtr);
            return array;
        }
    }
}
