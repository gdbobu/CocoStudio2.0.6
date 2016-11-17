// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.EventCache
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;
using System.Collections.Generic;

namespace CocoStudio.UserStatistics
{
  public class EventCache
  {
    public List<FeatureInfo> FeatureList { get; private set; }

    public static EventCache Instance { get; private set; }

    public event Action<FeatureInfo> FeatureInfoUsed = param0 => {};

    static EventCache()
    {
      EventCache.Instance = new EventCache();
    }

    private EventCache()
    {
      this.FeatureList = new List<FeatureInfo>();
    }

    public void AddFunctionCall(FeatureInfo featureInfo)
    {
      foreach (FeatureInfo feature in this.FeatureList)
      {
        if (feature.MethodName.Equals(featureInfo.MethodName))
        {
          ++feature.Count;
          this.FeatureInfoUsed(featureInfo);
          return;
        }
      }
      this.FeatureList.Add(featureInfo);
      this.FeatureInfoUsed(featureInfo);
    }
  }
}
