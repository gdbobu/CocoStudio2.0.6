// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocoaChina.Login
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using Jisons;
using Modules.Communal.MultiLanguage;
using Newtonsoft.Json.Linq;
using System;

namespace Modules.Communal.CocoaChina
{
  public class Login
  {
    private const string LoginUrl = "http://open.cocos.org/api/user_login";
    private const string CocosLoginUrl = "https://passport.cocos.com/oauth/token/?";

    public User User { get; private set; }

    public event EventHandler<CocoaUserArgs> OnResived;

    public static User LoginCocoaChina(string name, string password)
    {
      User user = new User() { UserName = name, PassWord = password };
      string responseOfString = "http://open.cocos.org/api/user_login".GetResponseOfString("post", user.LoginData);
      user.ErrorMsg = Login.JudgeLoginMsg(responseOfString);
      return user;
    }

    public static User LoginCocos(string name, string password)
    {
      User user = new User() { UserName = name, PassWord = password };
      string responseOfString = ("https://passport.cocos.com/oauth/token/?" + user.CocosLoginData).GetResponseOfString("get", "");
      user.ErrorMsg = Login.CocosLoginMsg(responseOfString);
      return user;
    }

    private static string CocosLoginMsg(string retStr)
    {
      try
      {
        if (!string.IsNullOrWhiteSpace(retStr))
        {
          if (retStr.Contains("access_token"))
            return string.Empty;
          if (retStr.Contains("error"))
          {
            JToken jtoken = JObject.Parse(retStr).GetValue("error_description");
            if (jtoken != null)
              return jtoken.ToString();
          }
        }
      }
      catch (Exception )
      {
        return LanguageInfo.NetworkAnomalies;
      }
      return LanguageInfo.NetworkAnomalies;
    }

    internal static string JudgeLoginMsg(string retStr)
    {
      if (!string.IsNullOrWhiteSpace(retStr) && retStr.Contains("status"))
      {
        if (retStr.Contains("error"))
          return LanguageInfo.LoginFailed;
        if (retStr.Contains("success"))
          return string.Empty;
      }
      return LanguageInfo.NetworkAnomalies;
    }

    protected void Resived(User user)
    {
      if (this.OnResived == null)
        return;
      this.OnResived((object) this, new CocoaUserArgs()
      {
        User = user
      });
    }

    public void SyncLoginCocoaChina(string name, string password)
    {
      this.User = new User()
      {
        UserName = name,
        PassWord = password
      };
      HttpSync httpSync = new HttpSync();
      httpSync.OnResived += new EventHandler<HttpSync.HttpSyncArgs>(this.http_OnResived);
      httpSync.GetSyncResponseOfString("http://open.cocos.org/api/user_login", "post", this.User.LoginData);
    }

    public void SyncLoginCocos(string name, string password)
    {
      this.User = new User()
      {
        UserName = name,
        PassWord = password
      };
      HttpSync httpSync = new HttpSync();
      httpSync.OnResived += new EventHandler<HttpSync.HttpSyncArgs>(this.http_OnResived);
      httpSync.GetSyncResponseOfString("https://passport.cocos.com/oauth/token/?" + this.User.CocosLoginData, "get", "");
    }

    private void http_OnResived(object sender, HttpSync.HttpSyncArgs e)
    {
      HttpSync httpSync = sender as HttpSync;
      if (httpSync != null)
        httpSync.OnResived -= new EventHandler<HttpSync.HttpSyncArgs>(this.http_OnResived);
      this.User.ErrorMsg = Login.CocosLoginMsg(e.Message);
      this.Resived(this.User);
    }
  }
}
