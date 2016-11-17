// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Model.LoginInfo
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using CocoStudio.Basic;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CocoStudio.ControlLib.Model
{
  public class LoginInfo
  {
    private static string ExprotConfigFolder = Path.Combine(Option.UserCustomerConfigFolder, "LoginInfo");
    private string LoginInfoConfigPath = Path.Combine(LoginInfo.ExprotConfigFolder, "LoginInfo.config");
    private bool isRememberPassWord;
    private string userName;
    private string userPassword;
    private bool autoLogin;

    public bool IsRememberPassWord
    {
      get
      {
        return this.isRememberPassWord;
      }
      set
      {
        this.isRememberPassWord = value;
      }
    }

    public string UserName
    {
      get
      {
        return this.userName;
      }
      set
      {
        this.userName = value;
      }
    }

    public string UserPassword
    {
      get
      {
        return this.userPassword;
      }
      set
      {
        this.userPassword = value;
      }
    }

    public bool IsAutoLogin
    {
      get
      {
        return this.autoLogin;
      }
      set
      {
        this.autoLogin = value;
      }
    }

    public LoginInfo()
    {
      this.ConfigInit();
    }

    private void ConfigInit()
    {
      if (File.Exists(this.LoginInfoConfigPath))
      {
        try
        {
          XmlNode node = XmlAnalysis.GetNode((XmlNode) XmlAnalysis.ReaderXmlFile(this.LoginInfoConfigPath), "LoginInfoConfig");
          this.IsRememberPassWord = Convert.ToBoolean(XmlAnalysis.GetNode(node, "IsRememberPassWord").InnerText);
          this.UserName = XmlAnalysis.GetNode(node, "UserName").InnerText;
          string innerText = XmlAnalysis.GetNode(node, "UserPassword").InnerText;
          this.IsAutoLogin = Convert.ToBoolean(XmlAnalysis.GetNode(node, "IsAutoLogin").InnerText);
          this.UserPassword = LoginEncrypt.Decrypt(innerText, "E99F9354-BC29-48A2-9839-F3D0DD83CCE5", Encoding.Default);
        }
        catch (Exception )
        {
          this.Init();
          File.Delete(this.LoginInfoConfigPath);
        }
      }
      else
        this.Init();
    }

    private void Init()
    {
      this.IsRememberPassWord = true;
      this.IsAutoLogin = true;
      this.UserName = string.Empty;
      this.UserPassword = string.Empty;
    }

    public void SaveXmlExprotConfiguration()
    {
      try
      {
        if (!Directory.Exists(LoginInfo.ExprotConfigFolder))
          Directory.CreateDirectory(LoginInfo.ExprotConfigFolder);
        new DirectoryInfo(LoginInfo.ExprotConfigFolder).Attributes = FileAttributes.Hidden;
        if (File.Exists(this.LoginInfoConfigPath))
          File.Delete(this.LoginInfoConfigPath);
        new XDocument(new object[1]
        {
          (object) new XElement((XName) "LoginInfoConfig", new object[4]
          {
            (object) new XElement((XName) "UserName", (object) this.UserName),
            (object) new XElement((XName) "UserPassword", (object) LoginEncrypt.Encrypt(this.UserPassword, "E99F9354-BC29-48A2-9839-F3D0DD83CCE5")),
            (object) new XElement((XName) "IsRememberPassWord", (object) this.IsRememberPassWord),
            (object) new XElement((XName) "IsAutoLogin", (object) this.IsAutoLogin)
          })
        }).Save(this.LoginInfoConfigPath);
      }
      catch (Exception )
      {
      }
    }
  }
}
