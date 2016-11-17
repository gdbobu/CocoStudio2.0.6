// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.NetAddress
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  internal struct NetAddress
  {
    internal readonly uint family;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = (UnmanagedType) 0)]
    internal readonly uint[] addr;
  }
}
