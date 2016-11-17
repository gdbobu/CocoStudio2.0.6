// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MultiLanguage.LanguageOption
// Assembly: Modules.Communal.MultiLanguage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 71ED3653-D37E-48A4-9AB9-CFA5ACC57BF1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MultiLanguage.dll

using CocoStudio.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Modules.Communal.MultiLanguage
{
  public static class LanguageOption
  {
    public static Type TypeLanguageInfo = typeof (LanguageInfo);
    public static string CustomerConfigPath = string.Empty;
    private static XElement TempXmlInfo = (XElement) null;
    private static string PreFilePath = "";
    private const string languageConfigFileName = "LanguageDefaultConfig.xml";

    public static LanguageType CurrentLanguage { get; private set; }

    static LanguageOption()
    {
      LanguageOption.CustomerConfigPath = Option.UserCustomerConfigFolder;
      LanguageOption.Init();
    }

    private static void Init()
    {
      LanguageOption.CurrentLanguage = LanguageOption.ReadLanguageConfiguration();
    }

    private static XElement LoadDefaultLanguageConfig(string filePath)
    {
      try
      {
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
          XElement xelement = XElement.Load((Stream) fileStream);
          foreach (XElement descendant in xelement.Descendants((XName) "Item"))
          {
            LanguageOption.CurrentLanguage = LanguageType.English;
            switch (descendant.Attribute((XName) "Default").Value)
            {
              case "en-CHS":
                LanguageOption.CurrentLanguage = LanguageType.Chinese;
                break;
              case "en-KO":
                LanguageOption.CurrentLanguage = LanguageType.Korean;
                break;
              case "en-JA":
                LanguageOption.CurrentLanguage = LanguageType.Japanese;
                break;
              case "en-SP":
                LanguageOption.CurrentLanguage = LanguageType.Spanish;
                break;
            }
          }
          return xelement;
        }
      }
      catch
      {
        LogConfig.Output.Error((object) "Failed to read multilanguage info.");
        return (XElement) null;
      }
    }

    private static string GetCurrentDirectoryPath()
    {
      return Directory.GetParent(typeof (LanguageOption).Assembly.Location).FullName;
    }

    private static XElement CreatItem(string key, string value)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      dictionary.Clear();
      dictionary.Add(key, value);
      XElement xelement = new XElement((XName) "Item");
      xelement.SetAttributeValue((XName) "Key", (object) key);
      xelement.SetAttributeValue((XName) "Value", (object) value);
      return xelement;
    }

    private static LanguageType ReadLanguageConfiguration()
    {
      LanguageType currentType = !CultureInfo.CurrentCulture.ToString().Equals("zh-CN") ? LanguageType.English : LanguageType.Chinese;
      string str = "";
      string configFileByName = Option.GetUserConfigFileByName("LanguageDefaultConfig.xml");
      if (File.Exists(configFileByName))
      {
        try
        {
          using (FileStream fileStream = File.Open(configFileByName, FileMode.Open, FileAccess.Read))
          {
            foreach (XElement descendant in XElement.Load((Stream) fileStream).Descendants((XName) "Item"))
              str = descendant.Attribute((XName) "Default").Value;
            switch (str)
            {
              case "en-KO":
                return LanguageType.Korean;
              case "en-JA":
                return LanguageType.Japanese;
              case "en-SP":
                return LanguageType.Spanish;
              case "en-CHS":
                return LanguageType.Chinese;
              default:
                return LanguageType.English;
            }
          }
        }
        catch (Exception ex)
        {
          LogConfig.Logger.Error((object) "Read language config file failed.", ex);
          LanguageOption.SetDefaultLanguageConfig(currentType);
        }
      }
      else
        LanguageOption.SetDefaultLanguageConfig(currentType);
      return currentType;
    }

    public static string GetValueBykey(string key)
    {
      if (key == null)
        return string.Empty;
      FieldInfo field = LanguageOption.TypeLanguageInfo.GetField(key);
      if (field != (FieldInfo) null)
        return field.GetValue((object) key).ToString();
      return key;
    }

    public static void SetDefaultLanguageConfig(LanguageType currentType)
    {
      try
      {
        XElement xelement1 = new XElement((XName) "Item");
        XElement xelement2 = new XElement((XName) "Item");
        string str;
        switch (currentType)
        {
          case LanguageType.Chinese:
            str = "en-CHS";
            break;
          case LanguageType.Korean:
            str = "en-KO";
            break;
          case LanguageType.Japanese:
            str = "en-JA";
            break;
          case LanguageType.Spanish:
            str = "en-SP";
            break;
          default:
            str = "en-US";
            break;
        }
        xelement2.SetAttributeValue((XName) "Default", (object) str);
        xelement1.Add((object) xelement2);
        string configFileByName = Option.GetUserConfigFileByName("LanguageDefaultConfig.xml");
        if (!Directory.Exists(LanguageOption.CustomerConfigPath))
          Directory.CreateDirectory(LanguageOption.CustomerConfigPath);
        xelement1.Save(configFileByName);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Save language config failed.", ex);
      }
    }

    internal static string GetLanguagePath(LanguageType currentType)
    {
      string currentDirectoryPath = LanguageOption.GetCurrentDirectoryPath();
      switch (LanguageOption.CurrentLanguage)
      {
        case LanguageType.Chinese:
          return Path.Combine(currentDirectoryPath, "LanguageResource/en-CHS.xml");
        case LanguageType.Korean:
          return Path.Combine(currentDirectoryPath, "LanguageResource/en-KO.xml");
        case LanguageType.Japanese:
          return Path.Combine(currentDirectoryPath, "LanguageResource/en-JA.xml");
        case LanguageType.Spanish:
          return Path.Combine(currentDirectoryPath, "LanguageResource/en-SP.xml");
        default:
          return Path.Combine(currentDirectoryPath, "LanguageResource/en-US.xml");
      }
    }

    internal static string GetMacTempLanguagePath(LanguageType currentType)
    {
      switch (LanguageOption.CurrentLanguage)
      {
        case LanguageType.Chinese:
          return Path.Combine(Option.UserCustomerConfigFolder, "LanguageResource/en-CHS.xml");
        case LanguageType.Korean:
          return Path.Combine(Option.UserCustomerConfigFolder, "LanguageResource/en-KO.xml");
        case LanguageType.Japanese:
          return Path.Combine(Option.UserCustomerConfigFolder, "LanguageResource/en-JA.xml");
        case LanguageType.Spanish:
          return Path.Combine(Option.UserCustomerConfigFolder, "LanguageResource/en-SP.xml");
        default:
          return Path.Combine(Option.UserCustomerConfigFolder, "LanguageResource/en-US.xml");
      }
    }

    internal static string GetTranslateInfo(string key, string filePath)
    {
      if (!File.Exists(filePath))
        return string.Empty;
      if (LanguageOption.PreFilePath != filePath)
      {
        LanguageOption.PreFilePath = filePath;
        LanguageOption.TempXmlInfo = (XElement) null;
      }
      if (LanguageOption.TempXmlInfo == null)
      {
        TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filePath, FileMode.Open, FileAccess.Read));
        string end = textReader.ReadToEnd();
        textReader.Close();
        LanguageOption.TempXmlInfo = XElement.Parse(end);
      }
      foreach (XElement descendant in LanguageOption.TempXmlInfo.Descendants((XName) "Item"))
      {
        if (descendant.Attribute((XName) "Key").Value == key)
          return descendant.Attribute((XName) "Value").Value;
      }
      return string.Empty;
    }

    internal static void WriteChineseXml()
    {
      string str = Path.Combine(LanguageOption.GetCurrentDirectoryPath(), "LanguageResource/en-CHS.xml");
      Directory.CreateDirectory(Path.Combine(LanguageOption.GetCurrentDirectoryPath(), "LanguageResource"));
      File.Delete(str);
      using (File.Create(str))
        ;
      XElement xelement = new XElement((XName) "CH");
      foreach (MemberInfo field in LanguageOption.TypeLanguageInfo.GetFields())
      {
        string name = field.Name;
        string valueBykey = LanguageOption.GetValueBykey(name);
        xelement.Add((object) LanguageOption.CreatItem(name, valueBykey));
      }
      xelement.Save(str);
    }

    internal static void WriteLanguageXml(LanguageType type)
    {
      string languagePath = LanguageOption.GetLanguagePath(type);
      Directory.CreateDirectory(Path.Combine(LanguageOption.GetCurrentDirectoryPath(), "LanguageResource"));
      XElement xelement = new XElement((XName) "US");
      switch (type)
      {
        case LanguageType.Chinese:
          xelement = new XElement((XName) "CHS");
          break;
        case LanguageType.Korean:
          xelement = new XElement((XName) "KO");
          break;
        case LanguageType.Japanese:
          xelement = new XElement((XName) "JA");
          break;
        case LanguageType.Spanish:
          xelement = new XElement((XName) "SP");
          break;
      }
      FieldInfo[] fields = LanguageOption.TypeLanguageInfo.GetFields();
      if (File.Exists(languagePath))
      {
        foreach (MemberInfo memberInfo in fields)
        {
          string name = memberInfo.Name;
          string translateInfo = LanguageOption.GetTranslateInfo(name, languagePath);
          xelement.Add((object) LanguageOption.CreatItem(name, translateInfo));
          if (string.IsNullOrEmpty(translateInfo))
            xelement.Add((object) new XElement((XName) "GoTo"));
        }
        xelement.Save(languagePath);
      }
      else
      {
        File.Delete(languagePath);
        using (File.Create(languagePath))
          ;
        foreach (MemberInfo memberInfo in fields)
        {
          string name = memberInfo.Name;
          string translateInfo = LanguageOption.GetTranslateInfo(name, languagePath);
          xelement.Add((object) LanguageOption.CreatItem(name, translateInfo));
        }
        xelement.Save(languagePath);
      }
    }
  }
}
