// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.UserStatisticsGoogleMonitor
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using MeasurementProtocolClient;
using MonoDevelop.Core;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CocoStudio.UserStatistics
{
  internal class UserStatisticsGoogleMonitor
  {
    private const string StatisticUrl = "http://www.google-analytics.com�";
    public Version Version;
    private bool networkChecked;
    private bool networkOK;
    private LocalInfo localInfo;
    private string installID;
    private Task netStatusTask;

    public string TRACKER_ID
    {
      get
      {
        return Platform.IsMac ? "UA-53380630-6" : "UA-53380630-2";
      }
    }

    public void Start()
    {
      this.localInfo = new LocalInfo();
      this.installID = this.Hash(this.localInfo.MACAddress);
    }

    public void Stop()
    {
    }

    public void TrackSession(string actionName, string editorType, string isFromLaunch)
    {
      EventTracker eventTracker = new EventTracker(this.TRACKER_ID, this.installID);
      eventTracker.Parameters.EventCategory = editorType;
      eventTracker.Parameters.EventAction = actionName;
      eventTracker.Parameters.ApplicationInstallID = this.installID;
      eventTracker.Parameters.ApplicationVersion = this.Version.ToString();
      eventTracker.Parameters.ApplicationName = "CocosStudio";
      eventTracker.Parameters.ApplicationID = "CocosStudio";
      eventTracker.Parameters.CustomDimensions.Add(1, this.localInfo.GetOSName());
      eventTracker.Parameters.CustomDimensions.Add(2, this.localInfo.OSVersion);
      eventTracker.Parameters.CustomDimensions.Add(3, this.localInfo.OSBit);
      eventTracker.Parameters.CustomDimensions.Add(4, this.localInfo.ScreenDpi);
      eventTracker.Parameters.CustomDimensions.Add(5, this.localInfo.ScreenResulotion);
      this.PostStatistics((Tracker) eventTracker, true);
    }

    public void TrackSessionAsyc(string actionName, string editorType, string isFromLaunch, string times)
    {
      EventTracker eventTracker = new EventTracker(this.TRACKER_ID, this.installID);
      eventTracker.Parameters.EventCategory = editorType;
      eventTracker.Parameters.EventAction = actionName;
      eventTracker.Parameters.EventValue = times;
      eventTracker.Parameters.ApplicationInstallID = this.installID;
      eventTracker.Parameters.ApplicationVersion = this.Version.ToString();
      eventTracker.Parameters.ApplicationName = "CocosStudio";
      eventTracker.Parameters.ApplicationID = "CocosStudio";
      eventTracker.Parameters.CustomDimensions.Add(1, this.localInfo.GetOSName());
      eventTracker.Parameters.CustomDimensions.Add(2, this.localInfo.OSVersion);
      eventTracker.Parameters.CustomDimensions.Add(3, this.localInfo.OSBit);
      eventTracker.Parameters.CustomDimensions.Add(4, this.localInfo.ScreenDpi);
      eventTracker.Parameters.CustomDimensions.Add(5, this.localInfo.ScreenResulotion);
      this.PostStatistics((Tracker) eventTracker, false);
    }

    public void TrackException(Exception ex)
    {
      ExceptionTracker exceptionTracker = new ExceptionTracker(this.TRACKER_ID, this.installID);
      string s = ex.Message + ex.StackTrace;
      Encoding utF8 = Encoding.UTF8;
      byte[] bytes = utF8.GetBytes(s);
      string str = utF8.GetString(bytes, 0, 145);
      exceptionTracker.Parameters.ExceptionDescription = str;
      exceptionTracker.Parameters.ApplicationInstallID = this.installID;
      exceptionTracker.Parameters.ApplicationVersion = this.Version.ToString();
      exceptionTracker.Parameters.ApplicationName = "CocosStudio";
      exceptionTracker.Parameters.ApplicationID = "CocosStudio";
      exceptionTracker.Parameters.CustomDimensions.Add(1, this.localInfo.GetOSName());
      exceptionTracker.Parameters.CustomDimensions.Add(2, this.localInfo.OSVersion);
      exceptionTracker.Parameters.CustomDimensions.Add(3, this.localInfo.OSBit);
      exceptionTracker.Parameters.CustomDimensions.Add(4, this.localInfo.ScreenDpi);
      exceptionTracker.Parameters.CustomDimensions.Add(5, this.localInfo.ScreenResulotion);
      exceptionTracker.Parameters.CustomDimensions.Add(6, ex.GetType().Name);
      this.PostStatistics((Tracker) exceptionTracker, true);
    }

    public void TrackFeature(string editorType, FeatureInfo feature)
    {
      EventTracker eventTracker = new EventTracker(this.TRACKER_ID, this.installID);
      eventTracker.Parameters.EventCategory = feature.FeatureName;
      eventTracker.Parameters.EventAction = feature.MethodName;
      eventTracker.Parameters.EventLabel = feature.NewValue;
      eventTracker.Parameters.EventValue = feature.Count.ToString();
      eventTracker.Parameters.ApplicationInstallID = this.installID;
      eventTracker.Parameters.ApplicationVersion = this.Version.ToString();
      eventTracker.Parameters.ApplicationName = "CocosStudio";
      eventTracker.Parameters.ApplicationID = "CocosStudio";
      eventTracker.Parameters.CustomDimensions.Add(1, this.localInfo.GetOSName());
      eventTracker.Parameters.CustomDimensions.Add(2, this.localInfo.OSVersion);
      eventTracker.Parameters.CustomDimensions.Add(3, this.localInfo.OSBit);
      eventTracker.Parameters.CustomDimensions.Add(4, this.localInfo.ScreenDpi);
      eventTracker.Parameters.CustomDimensions.Add(5, this.localInfo.ScreenResulotion);
      this.PostStatistics((Tracker) eventTracker, true);
    }

    private void PostStatistics(Tracker tracker, bool isAsyc = true)
    {
      try
      {
        if (isAsyc)
        {
          if (!this.networkChecked)
          {
            this.netStatusTask = new Task(new Action(this.CheckNetwork));
            this.netStatusTask.Start();
          }
          this.netStatusTask.ContinueWith((Action<Task>) (t => this._postStatistics(tracker)));
        }
        else
        {
          if (!this.networkChecked)
            this.CheckNetwork();
          this._postStatistics(tracker);
        }
      }
      catch
      {
      }
    }

    private void CheckNetwork()
    {
      Ping ping = new Ping();
      PingOptions options = new PingOptions() { DontFragment = true };
      byte[] bytes = Encoding.ASCII.GetBytes(new string('z', 10));
      string host = new Uri("http://www.google-analytics.com").Host;
      this.networkChecked = true;
      try
      {
        PingReply pingReply = ping.Send(IPAddress.Parse("220.181.111.188"), 100, bytes, options);
        if (pingReply == null)
          this.networkOK = false;
        else
          this.networkOK = pingReply.Status == IPStatus.Success;
      }
      catch (Exception ex)
      {
        this.networkOK = false;
      }
    }

    private void _postStatistics(Tracker tracker)
    {
      if (!this.networkOK)
        return;
      tracker.Send();
    }

    public string Hash(string source)
    {
      using (MD5 md5 = MD5.Create())
        return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(source)));
    }
  }
}
