// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.SigarException
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Runtime.InteropServices;

namespace Hyperic.Sigar
{
  public class SigarException : Exception
  {
    private Hyperic.Sigar.Sigar sigar;
    private int errno;

    public override string Message
    {
      get
      {
        return SigarException.sigar_strerror(this.sigar.sigar.Handle, this.errno);
      }
    }

    public SigarException(Hyperic.Sigar.Sigar sigar, int errno)
    {
      this.sigar = sigar;
      this.errno = errno;
    }

    [DllImport("sigar-x86-winnt.dll")]
    private static extern string sigar_strerror(IntPtr sigar, int errno);
  }
}
