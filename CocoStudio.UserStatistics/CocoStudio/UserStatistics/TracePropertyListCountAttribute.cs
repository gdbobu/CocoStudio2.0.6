// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.TracePropertyListCountAttribute
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using System;
using System.Collections;

namespace CocoStudio.UserStatistics
{
  [HasInheritedAttribute(new long[] {})]
  [Serializable]
  public class TracePropertyListCountAttribute : TracePropertyCallAttribute
  {
    public TracePropertyListCountAttribute(ViewRegions region, string feature)
      : base(region, feature)
    {
    }

    [HasInheritedAttribute(new long[] {2905153545490672916})]
    [LocationInterceptionAdviceOptimization(LocationInterceptionAdviceOptimizations.IgnoreGetLocation | LocationInterceptionAdviceOptimizations.IgnoreGetLocationFullName)]
    public override void OnSetValue(LocationInterceptionArgs args)
    {
      base.OnSetValue(args);
      IList list = args.Value as IList;
      int num = 0;
      if (list != null)
        num = list.Count;
      EventCache.Instance.AddFunctionCall(new FeatureInfo(this.region, this.featureName, args.LocationName, (object) num));
    }
  }
}
