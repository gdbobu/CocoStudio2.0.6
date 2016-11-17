// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Plugins.DllAPIWrap
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.Model.Plugins
{
  internal static class DllAPIWrap
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetDllDirectory(string lpPathName);

    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr LoadLibrary(string lpFileName);
  }
}
