// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.UserConfig
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using Xwt.GtkBackend;

namespace CocoStudio.Basic
{
  public class UserConfig : INotifyPropertyChanged
  {
    private const string userConfigFileName = "User.config";
    private bool isShowDeprecatedControl;

    public string LocalIP { get; set; }

    public bool IsUseMouseWheel { get; set; }

    public bool IsSelectDefaultRule { get; set; }

    public bool IsShowDeprecatedControl
    {
      get
      {
        return this.isShowDeprecatedControl;
      }
      set
      {
        this.isShowDeprecatedControl = value;
        this.RaisePropertyChanged("IsShowDeprecatedControl");
      }
    }

    public string PublishProjectName { get; set; }

    public string PublishProjectPath { get; set; }

    public EnumProjectLanguage PublishLanguage { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    private UserConfig()
    {
      this.SetDefaultValue();
    }

    internal UserConfig(string filePath)
    {
      this.ReadFile(filePath);
    }

    private void RaisePropertyChanged(string name)
    {
      if (name == null)
        throw new ArgumentNullException("propertyNames");
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
    }

    private void SetDefaultValue()
    {
      this.LocalIP = (string) null;
      if (Platform.IsMac)
      {
        this.IsUseMouseWheel = false;
      }
      else
      {
        if (!Platform.IsWindows)
          return;
        this.IsUseMouseWheel = true;
      }
    }

    private static string GetFilePath()
    {
      return Option.GetUserConfigFileByName("User.config");
    }

    internal static UserConfig Create()
    {
      string filePath = UserConfig.GetFilePath();
      if (File.Exists(filePath))
        return new UserConfig(filePath);
      UserConfig userConfig = new UserConfig();
      userConfig.Save();
      return userConfig;
    }

    public void Save()
    {
      try
      {
        new XElement((XName) "Configuration", new object[5]
        {
          (object) new XElement((XName) "RenderMode", (object) "Default"),
          (object) new XElement((XName) "LocalIP", (object) this.LocalIP),
          (object) new XElement((XName) "IsUseMouseWheel", (object) this.IsUseMouseWheel.ToString()),
          (object) new XElement((XName) "IsSelectDefaultRule", (object) this.IsSelectDefaultRule),
          (object) new XElement((XName) "IsShowDeprecatedControl", (object) this.IsShowDeprecatedControl)
        }).Save(UserConfig.GetFilePath());
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex);
      }
    }

    private void ReadFile(string filePath)
    {
      try
      {
        XElement xelement1 = XElement.Load(filePath);
        XElement xelement2 = xelement1.Element((XName) "LocalIP");
        if (xelement2 != null)
          this.LocalIP = xelement2.Value;
        this.IsUseMouseWheel = (bool) xelement1.Element((XName) "IsUseMouseWheel");
        this.IsSelectDefaultRule = (bool) xelement1.Element((XName) "IsSelectDefaultRule");
        this.IsShowDeprecatedControl = (bool) xelement1.Element((XName) "IsShowDeprecatedControl");
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex);
        this.SetDefaultValue();
        this.Save();
      }
    }
  }
}
