// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.Who
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct Who
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public readonly string User;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public readonly string Device;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public readonly string Host;
    public readonly long Time;
  }
}
