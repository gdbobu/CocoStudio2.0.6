// Decompiled with JetBrains decompiler
// Type: OpenDialogs.SysListView32Helper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenDialogs
{
  public static class SysListView32Helper
  {
    private const int LVIF_TEXT = 1;

    public static bool IsRowSelected(this IntPtr handle, int rowindex)
    {
      return NativeMethods.SendMessage(handle, 4140, rowindex, 2) == 2;
    }

    public static List<int> GetSelectedRowsIndex(this IntPtr handle)
    {
      List<int> intList = new List<int>();
      int num = NativeMethods.SendMessage(handle, 4100, 0, 0);
      if (num > 0)
      {
        for (int rowindex = 0; rowindex < num; ++rowindex)
        {
          if (handle.IsRowSelected(rowindex))
            intList.Add(rowindex);
        }
      }
      return intList;
    }

    public static int GetItemCount(this IntPtr handle)
    {
      return NativeMethods.SendMessage(handle, 4100, 0, 0);
    }

    public static List<string> GetItemsText(this IntPtr handle, List<int> rowIndex, int column)
    {
      List<string> stringList = new List<string>();
      if (rowIndex != null)
      {
        int lpdwProcessId = 0;
        NativeMethods.GetWindowThreadProcessId(handle, ref lpdwProcessId);
        if (lpdwProcessId != 0)
        {
          int hProcess = NativeMethods.OpenProcess(56, false, lpdwProcessId);
          int num = NativeMethods.VirtualAllocEx(hProcess, IntPtr.Zero, 4096U, 12288U, 4U);
          int itemCount = handle.GetItemCount();
          if (itemCount > 0 && rowIndex.Count <= itemCount)
          {
            foreach (int wParam in rowIndex)
            {
              byte[] bytes = new byte[256];
              SysListView32Helper.LVITEM[] lvitemArray = new SysListView32Helper.LVITEM[1];
              lvitemArray[0].mask = 1;
              lvitemArray[0].iItem = wParam;
              lvitemArray[0].iSubItem = column;
              lvitemArray[0].cchTextMax = bytes.Length;
              lvitemArray[0].pszText = (IntPtr) (num + Marshal.SizeOf(typeof (SysListView32Helper.LVITEM)));
              uint vNumberOfBytesRead = 0;
              NativeMethods.WriteProcessMemory(hProcess, num, Marshal.UnsafeAddrOfPinnedArrayElement((Array) lvitemArray, 0), Marshal.SizeOf(typeof (SysListView32Helper.LVITEM)), ref vNumberOfBytesRead);
              NativeMethods.SendMessage(handle, 4171, wParam, num);
              NativeMethods.ReadProcessMemory(hProcess, num + Marshal.SizeOf(typeof (SysListView32Helper.LVITEM)), Marshal.UnsafeAddrOfPinnedArrayElement((Array) bytes, 0), bytes.Length, ref vNumberOfBytesRead);
              stringList.Add(Encoding.Unicode.GetString(bytes, 0, (int) vNumberOfBytesRead));
            }
          }
        }
      }
      return stringList;
    }

    public static List<string> GetSlectedItemsText(this IntPtr handle, int column = 0)
    {
      List<string> stringList = new List<string>();
      if (handle != IntPtr.Zero)
      {
        List<int> selectedRowsIndex = handle.GetSelectedRowsIndex();
        if (selectedRowsIndex.Count > 0)
          stringList.AddRange((IEnumerable<string>) handle.GetItemsText(selectedRowsIndex, column));
      }
      return stringList;
    }

    public static unsafe IntPtr GetSysListView32Handle(this IntPtr mainWindowHandle)
    {
      return NativeMethods.FindWindowEx(NativeMethods.FindWindowEx(mainWindowHandle, IntPtr.Zero, "SHELLDLL_DefView", ""), (IntPtr) ((void*) null), "SysListView32", (string) null);
    }

    private enum PROCESS
    {
      PROCESS_VM_OPERATION = 8,
      PROCESS_VM_READ = 16,
      PROCESS_VM_WRITE = 32,
    }

    private enum SysListView32
    {
      LVIS_SELECTED = 2,
      LVM_FIRST = 4096,
      LVM_GETITEMCOUNT = 4100,
      LVM_GETHEADER = 4127,
      LVM_GETITEMSTATE = 4140,
      LVM_GETITEMW = 4171,
      HDM_GETITEMCOUNT = 4608,
    }

    private enum MEM
    {
      MEM_COMMIT = 4096,
      MEM_RESERVE = 8192,
      MEM_RELEASE = 32768,
    }

    private enum PAGE
    {
      PAGE_READWRITE = 4,
    }

    private struct LVITEM
    {
      public int mask;
      public int iItem;
      public int iSubItem;
      public int state;
      public int stateMask;
      public IntPtr pszText;
      public int cchTextMax;
    }
  }
}
