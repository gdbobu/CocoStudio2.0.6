// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.TracePropertyCallAttribute
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using System;

namespace CocoStudio.UserStatistics
{
  [HasInheritedAttribute(new long[] {})]
  [Serializable]
  public class TracePropertyCallAttribute : LocationInterceptionAspect
  {
    protected ViewRegions region;
    protected string featureName;

    public TracePropertyCallAttribute(ViewRegions region, string feature)
    {
      this.region = region;
      this.featureName = feature;
    }

    [HasInheritedAttribute(new long[] {2905153545490672916})]
    [LocationInterceptionAdviceOptimization(LocationInterceptionAdviceOptimizations.IgnoreGetLocation | LocationInterceptionAdviceOptimizations.IgnoreGetLocationFullName)]
    public override void OnSetValue(LocationInterceptionArgs args)
    {
      base.OnSetValue(args);
      EventCache.Instance.AddFunctionCall(new FeatureInfo(this.region, this.featureName, args.LocationName, args.Value));
    }
  }
}
