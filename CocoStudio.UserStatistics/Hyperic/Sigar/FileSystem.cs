// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.FileSystem
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public struct FileSystem
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string DirName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string DevName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string TypeName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public readonly string SysTypeName;
    public readonly int Type;
    public readonly uint Flags;
  }
}
