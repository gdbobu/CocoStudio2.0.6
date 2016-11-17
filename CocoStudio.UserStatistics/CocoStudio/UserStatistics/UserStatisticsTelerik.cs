// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.UserStatisticsTelerik
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using CocoStudio.Basic;
using EQATEC.Analytics.Monitor;
using GLib;
using System;

namespace CocoStudio.UserStatistics
{
  internal class UserStatisticsTelerik : BaseUserStatistics
  {
    private const string projectKey = "72aa4ef2c6214b289e0ae1b011481220�";
    private IAnalyticsMonitor monitor;

    protected override void OnInit()
    {
      IAnalyticsMonitorSettings settings = AnalyticsMonitorFactory.CreateSettings("72aa4ef2c6214b289e0ae1b011481220");
      settings.Version = this.EditorInfo.Version;
      this.monitor = AnalyticsMonitorFactory.CreateMonitor(settings);
      this.monitor.Start();
      EventCache.Instance.FeatureInfoUsed += new System.Action<FeatureInfo>(this.EventCache_FeatureInfoUsed);
      this.SendStartWay();
      this.InitUnhandledException();
    }

    private void InitUnhandledException()
    {
      ExceptionManager.UnhandledException += new UnhandledExceptionHandler(this.HandleUnhandledException);
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(this.HandleDomainUnhandledException);
    }

    private void HandleDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      this.HandledException(e.ExceptionObject as Exception);
    }

    private void HandleUnhandledException(UnhandledExceptionArgs args)
    {
      this.HandledException(args.ExceptionObject as Exception);
    }

    private void HandledException(Exception ex)
    {
      LogConfig.Logger.Error((object) "Unhandled exception.", ex);
      this.monitor.TrackException(ex);
      Environment.Exit(-1);
    }

    private void EventCache_FeatureInfoUsed(FeatureInfo e)
    {
      this.monitor.TrackFeature(e.ToString(this.EditorInfo.Type));
    }

    protected override void OnExit()
    {
      base.OnExit();
      this.monitor.TrackFeature(this.EditorInfo.Type + " Stop");
      this.monitor.Stop();
    }

    private void SendStartWay()
    {
      this.monitor.TrackFeatureValue("Start By Launch", (long) this.ConvertBoolToInt(this.IsStartFromLaunch()));
      this.monitor.TrackFeature(this.EditorInfo.Type + " Start");
    }

    private int ConvertBoolToInt(bool param)
    {
      return param ? 0 : 1;
    }
  }
}
