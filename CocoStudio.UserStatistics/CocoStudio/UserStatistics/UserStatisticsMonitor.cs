// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.UserStatisticsMonitor
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CocoStudio.UserStatistics
{
  internal class UserStatisticsMonitor
  {
    private const string StatisticUrl = "http://cs.ucenter.appget.cn/csas�";
    private const string AppID = "398332332�";
    public const string EVENT_BUG = "Bug�";
    public const string EVENT_FEATURE_USE = "FeatureUse�";
    public const string EVENT_INSTALL = "Install�";
    public const string EVENT_SESSION = "Session�";
    public Version Version;
    private JObject deviceInfo;
    private string SessionID;
    private bool networkChecked;
    private bool networkOK;
    private LocalInfo localInfo;
    private long sessionStart;
    private string installID;
    private Task netStatusTask;

    [DllImport("zlib1.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int compress(byte[] dest, ref ulong destLen, byte[] source, ulong sourceLen);

    public void Start()
    {
      this.SessionID = new Random().Next().ToString();
      this.localInfo = new LocalInfo();
      this.installID = this.Hash(this.localInfo.MACAddress);
      this.sessionStart = this.GetTimeStamp();
      this.GenDeviceInfo();
    }

    public void Stop()
    {
    }

    public void TrackSession(string actionName, string editorType, string isFromLaunch)
    {
      JObject jobject = new JObject();
      jobject.Add("action", (JToken) actionName);
      jobject.Add("editor_name", (JToken) editorType);
      jobject.Add("isStartFromLaunch", (JToken) isFromLaunch);
      long timeStamp = this.GetTimeStamp();
      this.PostStatistics(new JObject()
      {
        {
          "s",
          (JToken) this.SessionID
        },
        {
          "e",
          (JToken) "Session"
        },
        {
          "u",
          (JToken) ""
        },
        {
          "t",
          (JToken) timeStamp
        },
        {
          "p",
          (JToken) jobject
        },
        {
          "d",
          (JToken) (timeStamp - this.sessionStart)
        }
      });
    }

    public void TrackException(Exception ex)
    {
      this.PostStatistics(new JObject()
      {
        {
          "s",
          (JToken) this.SessionID
        },
        {
          "e",
          (JToken) "Bug"
        },
        {
          "d",
          (JToken) 0
        },
        {
          "t",
          (JToken) this.GetTimeStamp()
        },
        {
          "p",
          (JToken) new JObject()
          {
            {
              "stack_trace",
              (JToken) ex.StackTrace.Replace("\n", "<br>")
            },
            {
              "exception_type",
              (JToken) ex.Message
            },
            {
              "context",
              (JToken) ex.Source
            }
          }
        },
        {
          "u",
          (JToken) ""
        }
      });
    }

    public void TrackFeature(string editorType, FeatureInfo feature)
    {
      this.PostStatistics(new JObject()
      {
        {
          "s",
          (JToken) this.SessionID
        },
        {
          "e",
          (JToken) "FeatureUse"
        },
        {
          "d",
          (JToken) 0
        },
        {
          "p",
          (JToken) new JObject()
          {
            {
              "editor_name",
              (JToken) editorType
            },
            {
              "feature_name",
              (JToken) feature.FeatureName
            },
            {
              "method_name",
              (JToken) feature.MethodName
            },
            {
              "new_value",
              (JToken) feature.NewValue
            }
          }
        },
        {
          "u",
          (JToken) ""
        },
        {
          "t",
          (JToken) this.GetTimeStamp()
        }
      });
    }

    private void PostStatistics(JObject eventInfo)
    {
      if (!this.networkChecked)
      {
        this.netStatusTask = new Task(new Action(this.CheckNetwork));
        this.netStatusTask.Start();
      }
      this.netStatusTask.ContinueWith((Action<Task>) (t => this._postStatistics(eventInfo)));
    }

    private void CheckNetwork()
    {
      Ping ping = new Ping();
      new PingOptions().DontFragment = true;
      Encoding.ASCII.GetBytes(new string('z', 10));
      string host = new Uri("http://cs.ucenter.appget.cn/csas").Host;
      this.networkChecked = true;
      try
      {
        PingReply pingReply = ping.Send(IPAddress.Parse("8.8.4.4"));
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

    private void _postStatistics(JObject eventInfo)
    {
      if (!this.networkOK)
        return;
      byte[] bytes = Encoding.UTF8.GetBytes(new JObject() { { "time", (JToken) this.GetTimeStamp() }, { "device", (JToken) this.deviceInfo }, { "events", (JToken) new JArray() { (JToken) eventInfo } } }.ToString());
      byte[] numArray = new byte[bytes.Length];
      ulong length1 = (ulong) numArray.Length;
      ulong length2 = (ulong) bytes.Length;
      UserStatisticsMonitor.compress(numArray, ref length1, bytes, length2);
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("http://cs.ucenter.appget.cn/csas");
      httpWebRequest.ContentType = "multipart/form-data";
      httpWebRequest.Method = "POST";
      httpWebRequest.ContentLength = (long) numArray.Length;
      try
      {
        using (Stream requestStream = httpWebRequest.GetRequestStream())
        {
          requestStream.Write(numArray, 0, numArray.Length);
          requestStream.Close();
        }
        using (StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
          streamReader.ReadToEnd();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void GenDeviceInfo()
    {
      this.deviceInfo = new JObject();
      this.deviceInfo.Add("4", (JToken) this.installID);
      this.deviceInfo.Add("5", (JToken) this.Version.ToString());
      this.deviceInfo.Add("6", (JToken) this.localInfo.FrameVer);
      this.deviceInfo.Add("7", (JToken) this.localInfo.OSName);
      this.deviceInfo.Add("8", (JToken) this.localInfo.OSVersion);
      this.deviceInfo.Add("9", (JToken) this.localInfo.OSMemory);
      this.deviceInfo.Add("10", (JToken) this.localInfo.OSBit);
      this.deviceInfo.Add("11", (JToken) this.localInfo.CPUCoreCount);
      this.deviceInfo.Add("12", (JToken) this.localInfo.OSLan);
      this.deviceInfo.Add("13", (JToken) this.localInfo.ScreenResulotion);
      this.deviceInfo.Add("14", (JToken) this.localInfo.ScreenCount);
      this.deviceInfo.Add("15", (JToken) this.localInfo.ScreenDpi);
      this.deviceInfo.Add("16", (JToken) this.localInfo.MACAddress);
      this.deviceInfo.Add("17", (JToken) this.localInfo.isVM);
      this.deviceInfo.Add("18", (JToken) "398332332");
    }

    private long GetTimeStamp()
    {
      return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
    }

    public string Hash(string source)
    {
      using (MD5 md5 = MD5.Create())
        return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(source)));
    }
  }
}
