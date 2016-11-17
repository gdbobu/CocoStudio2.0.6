// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocoaChina.User
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using Jisons;
using System.Text;
using System.Web;

namespace Modules.Communal.CocoaChina
{
  public class User
  {
    private string timeStamp;
    private string errorMsg;

    public string UserName { get; set; }

    public string PassWord { get; set; }

    public string TimeStamp
    {
      get
      {
        return this.timeStamp;
      }
    }

    public string Email { get; set; }

    public string ErrorMsg
    {
      get
      {
        return this.errorMsg;
      }
      set
      {
        this.errorMsg = value;
      }
    }

    public string LoginSign
    {
      get
      {
        return ("da6234c991159283c88b81ef29a3febe" + ("fromcocostudiopassword" + this.PassWord.EncryptMD5().ToLower() + "timestamp" + this.timeStamp + "username" + this.UserName.GetCocoaUrlEncode()) + "da6234c991159283c88b81ef29a3febe").EncryptMD5().ToUpper();
      }
    }

    public string RegisterSign
    {
      get
      {
        return ("da6234c991159283c88b81ef29a3febe" + ("email" + this.Email + "fromcocostudiopassword" + this.PassWord.EncryptMD5().ToLower() + "timestamp" + this.timeStamp + "username" + HttpUtility.UrlEncode(this.UserName, Encoding.UTF8).ToUpper()) + "da6234c991159283c88b81ef29a3febe").EncryptMD5().ToUpper();
      }
    }

    public string RedirectSign
    {
      get
      {
        string userName = this.UserName;
        this.PassWord.EncryptMD5().ToLower();
        return ("da6234c991159283c88b81ef29a3febe" + ("client_id10redirect_url" + "http://open.cocoachina.com/".GetCocoaUrlEncode()) + "da6234c991159283c88b81ef29a3febe").EncryptMD5().ToUpper();
      }
    }

    public string LoginData
    {
      get
      {
        this.timeStamp = CocoaChinaKey.UniversalTime;
        return "username=" + this.UserName.GetCocoaUrlEncode() + "&password=" + this.PassWord.EncryptMD5().ToLower() + "&from=cocostudio&timestamp=" + this.TimeStamp + "&sign=" + this.LoginSign;
      }
    }

    public string CocosLoginData
    {
      get
      {
        return "app_key=f2fb1076691c445a46b25e1fcc9e95f2&grant_type=password&password=" + this.PassWord + "&username=" + this.UserName + "&sign=" + this.CocosLoginSign;
      }
    }

    public string CocosLoginSign
    {
      get
      {
        return ("app_key=f2fb1076691c445a46b25e1fcc9e95f2&grant_type=password&password=" + this.PassWord + "&username=" + this.UserName + "3f579e7429443a3ec0a9062e27766c72").EncryptMD5().ToLower();
      }
    }

    public string RegisterData
    {
      get
      {
        this.timeStamp = CocoaChinaKey.UniversalTime;
        return "username=" + this.UserName.GetCocoaUrlEncode() + "&password=" + this.PassWord.EncryptMD5().ToLower() + "&email=" + this.Email + "&from=cocostudio&timestamp=" + this.TimeStamp + "&sign=" + this.RegisterSign;
      }
    }

    public string RedirectData
    {
      get
      {
        return "user_name=" + this.UserName + "&password=" + this.PassWord.EncryptMD5().ToLower() + "&client_id=10&redirect_url=" + "http://open.cocoachina.com/".GetCocoaUrlEncode() + "&sign=" + this.RedirectSign;
      }
    }
  }
}
