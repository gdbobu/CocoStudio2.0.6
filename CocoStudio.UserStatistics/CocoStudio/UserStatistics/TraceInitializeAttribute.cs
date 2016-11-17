// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.TraceInitializeAttribute
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using System;

namespace CocoStudio.UserStatistics
{
  [Serializable]
  public sealed class TraceInitializeAttribute : OnMethodBoundaryAspect
  {
    [MethodExecutionAdviceOptimization(MethodExecutionAdviceOptimizations.IgnoreAllEventArgsMembers)]
    public override void OnExit(MethodExecutionArgs args)
    {
      base.OnExit(args);
    }
  }
}
