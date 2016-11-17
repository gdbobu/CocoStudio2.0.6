// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.UserStatisitcsCS
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;

namespace CocoStudio.UserStatistics
{
  public class UserStatisitcsCS : BaseUserStatistics
  {
    private UserStatisticsMonitor monitor;

    protected override void OnInit()
    {
      this.monitor = new UserStatisticsMonitor();
      this.monitor.Version = this.EditorInfo.Version;
      this.monitor.Start();
      EventCache.Instance.FeatureInfoUsed += new Action<FeatureInfo>(this.EventCache_FeatureInfoUsed);
      this.SendStartWay();
    }

    public override void UnHandledException(Exception ex)
    {
      this.monitor.TrackException(ex);
      base.UnHandledException(ex);
    }

    private void EventCache_FeatureInfoUsed(FeatureInfo e)
    {
      if (!e.IsAutoSend)
        return;
      this.monitor.TrackFeature(this.EditorInfo.Type, e);
    }

    protected override void OnExit()
    {
      base.OnExit();
      this.monitor.TrackSession("stop", this.EditorInfo.Type, this.ConvertBoolToInt(this.IsStartFromLaunch()).ToString());
      this.monitor.Stop();
    }

    public override void ExitAll()
    {
      foreach (FeatureInfo feature in EventCache.Instance.FeatureList)
      {
        if (!feature.IsAutoSend)
          this.monitor.TrackFeature(this.EditorInfo.Type, feature);
      }
      this.OnExit();
    }

    private void SendStartWay()
    {
      this.monitor.TrackSession("start", this.EditorInfo.Type, this.ConvertBoolToInt(this.IsStartFromLaunch()).ToString());
    }

    private int ConvertBoolToInt(bool param)
    {
      return param ? 1 : 0;
    }
  }
}
