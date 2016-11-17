// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.TraceMethodCallAttribute
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using System;
using System.Reflection;

namespace CocoStudio.UserStatistics
{
  [Serializable]
  public sealed class TraceMethodCallAttribute : OnMethodBoundaryAspect
  {
    private ViewRegions region;
    private string featureName;
    protected string OperationName;
    protected string LabelName;

    public TraceMethodCallAttribute(string functionName, string operationName = null, string labelName = null)
    {
      this.region = ViewRegions.None;
      this.featureName = functionName;
      this.OperationName = operationName;
      this.LabelName = labelName;
    }

    [MethodExecutionAdviceOptimization(MethodExecutionAdviceOptimizations.IgnoreMethodExecutionTag | MethodExecutionAdviceOptimizations.IgnoreSetFlowBehavior | MethodExecutionAdviceOptimizations.IgnoreGetArguments | MethodExecutionAdviceOptimizations.IgnoreSetArguments | MethodExecutionAdviceOptimizations.IgnoreGetInstance | MethodExecutionAdviceOptimizations.IgnoreSetInstance | MethodExecutionAdviceOptimizations.IgnoreGetException | MethodExecutionAdviceOptimizations.IgnoreSetReturnValue | MethodExecutionAdviceOptimizations.IgnoreGetYieldValue | MethodExecutionAdviceOptimizations.IgnoreSetYieldValue | MethodExecutionAdviceOptimizations.IgnoreGetDeclarationIdentifier)]
    public override void OnExit(MethodExecutionArgs args)
    {
      base.OnExit(args);
      EventCache.Instance.AddFunctionCall(new FeatureInfo(this.region, this.OperationName != null || !(args.Method != (MethodBase) null) ? this.OperationName : args.Method.Name, this.featureName, this.LabelName != null || args.ReturnValue == null ? (object) this.LabelName : (object) args.ReturnValue.ToString()));
    }
  }
}
