// Decompiled with JetBrains decompiler
// Type: Hyperic.Sigar.SigarNotImplementedException
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

namespace Hyperic.Sigar
{
  public class SigarNotImplementedException : SigarException
  {
    public SigarNotImplementedException(Hyperic.Sigar.Sigar sigar, int errno)
      : base(sigar, errno)
    {
    }
  }
}
