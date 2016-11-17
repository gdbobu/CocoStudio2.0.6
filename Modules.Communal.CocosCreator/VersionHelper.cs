// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.VersionHelper
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using CocoStudio.Projects;
using MonoDevelop.Core;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace Modules.Communal.CocosCreator
{
  internal class VersionHelper
  {
    public static void SetDefaultSerializer(Solution sln)
    {
      PropertyBag userProperties = sln.UserProperties;
      string baseDirectory = (string) sln.BaseDirectory;
      if (!string.IsNullOrEmpty(userProperties.GetValue<string>("DefaultSerializer", string.Empty)))
        return;
      string defaultSerializerId = VersionHelper.GetDefaultSerializerID(sln);
      userProperties.SetValue<string>("DefaultSerializer", defaultSerializerId);
      sln.SaveUserProperties();
    }

    private static string GetDefaultSerializerID(Solution sln)
    {
      try
      {
        PropertyBag userProperties = sln.UserProperties;
        string empty = string.Empty;
        if (!userProperties.GetValue<bool>("publishHasCocos2dxCode", true))
          return "Serializer_FlatBuffers";
        if (userProperties.HasValue("publishCocos2dxMainVersion"))
        {
          if (userProperties.GetValue<int>("publishCocos2dxMainVersion") == 2)
            return "Serializer_Json";
        }
        else
        {
          string versionFileV2 = VersionHelper.TryGetVersionFileV2(sln);
          if (!string.IsNullOrEmpty(versionFileV2))
          {
            userProperties.SetValue<string>("publishCocos2dxVersionText", versionFileV2);
            userProperties.SetValue<int>("publishCocos2dxMainVersion", 2);
            return "Serializer_Json";
          }
        }
        if (userProperties.HasValue("publishCocos2dxCodeLanguage"))
        {
          if (userProperties.GetValue<EnumProjectLanguage>("publishCocos2dxCodeLanguage") == EnumProjectLanguage.js)
            return "Serializer_Json";
        }
        else
        {
          string versionFileV3Js = VersionHelper.TryGetVersionFileV3_js(sln);
          if (!string.IsNullOrEmpty(versionFileV3Js))
          {
            userProperties.SetValue<string>("publishCocos2dxVersionText", versionFileV3Js);
            userProperties.SetValue<int>("publishCocos2dxMainVersion", 3);
            userProperties.SetValue<EnumProjectLanguage>("publishCocos2dxCodeLanguage", EnumProjectLanguage.js);
            return "Serializer_Json";
          }
        }
        string versionText1 = userProperties.GetValue<string>("publishCocos2dxVersionText", string.Empty);
        if (!string.IsNullOrEmpty(versionText1))
          return VersionHelper.IsSupportBinary(versionText1) ? "Serializer_FlatBuffers" : "Serializer_Json";
        string versionText2 = VersionHelper.TryGetVersionFileV3_cpp(sln);
        if (string.IsNullOrEmpty(versionText2))
          versionText2 = VersionHelper.TryGetVersionFileV3_lua(sln);
        if (!string.IsNullOrEmpty(versionText2))
          return VersionHelper.IsSupportBinary(versionText2) ? "Serializer_FlatBuffers" : "Serializer_Json";
        string versionFileDefaultLua = VersionHelper.TryGetVersionFileDefault_lua(sln);
        if (string.IsNullOrEmpty(versionFileDefaultLua))
          return "Serializer_FlatBuffers";
        userProperties.SetValue<string>("publishCocos2dxVersionText", versionFileDefaultLua);
        return "Serializer_FlatBuffers";
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("获取默认发布器时出错：\r\n" + ex.ToString()));
        return "Serializer_FlatBuffers";
      }
    }

    private static string TryGetVersionFileV2(Solution sln)
    {
      string str = Path.Combine((string) sln.BaseDirectory, "cocos2dx", "cocos2d.cpp");
      if (File.Exists(str))
        return CocosInfo.GetVersionText(str);
      return string.Empty;
    }

    private static string TryGetVersionFileV3_cpp(Solution sln)
    {
      string str = Path.Combine((string) sln.BaseDirectory, "cocos2d", "cocos", "cocos2d.cpp");
      if (File.Exists(str))
        return CocosInfo.GetVersionText(str);
      return string.Empty;
    }

    private static string TryGetVersionFileV3_lua(Solution sln)
    {
      string str = Path.Combine((string) sln.BaseDirectory, "frameworks", "cocos2d-x", "cocos", "cocos2d.cpp");
      if (File.Exists(str))
        return CocosInfo.GetVersionText(str);
      return string.Empty;
    }

    private static string TryGetVersionFileV3_js(Solution sln)
    {
      string str = Path.Combine((string) sln.BaseDirectory, "frameworks", "js-bindings", "cocos2d-x", "cocos", "cocos2d.cpp");
      if (File.Exists(str))
        return CocosInfo.GetVersionText(str);
      return string.Empty;
    }

    private static string TryGetVersionFileDefault_lua(Solution sln)
    {
      string str = Path.Combine((string) sln.BaseDirectory, ".settings", "version.json");
      if (File.Exists(str))
        return VersionHelper.GetVersionTextFromJson(str);
      return string.Empty;
    }

    private static string GetVersionTextFromJson(string jsonFilePath)
    {
      try
      {
        if (!File.Exists(jsonFilePath))
          return string.Empty;
        string json = File.ReadAllText(jsonFilePath);
        if (string.IsNullOrEmpty(json))
          return string.Empty;
        return JObject.Parse(json).Value<string>((object) "engineVersion");
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) (string.Format("读取json文件{0}失败\r\n", (object) jsonFilePath) + ex.ToString()));
        return string.Empty;
      }
    }

    private static bool IsSupportBinary(string versionText)
    {
      if (string.IsNullOrEmpty(versionText) || versionText.Equals("cocos2d-x"))
        return true;
      Version version = VersionHelper.ParseVersion(versionText);
      return version == (Version) null || new Version("3.3") <= version;
    }

    private static Version ParseVersion(string versionText)
    {
      try
      {
        string[] strArray = versionText.Replace("cocos2d-x", "").Replace(" ", "").Split('.');
        if (strArray.Length <= 1)
          return (Version) null;
        int startIndex1;
        for (startIndex1 = strArray[0].Length - 1; startIndex1 >= 0; --startIndex1)
        {
          string str = strArray[0].Substring(startIndex1, 1);
          try
          {
            int int16 = (int) Convert.ToInt16(str);
          }
          catch
          {
            break;
          }
        }
        int startIndex2 = startIndex1 + 1;
        if (startIndex2 >= strArray[0].Length)
          return (Version) null;
        strArray[0] = strArray[0].Substring(startIndex2);
        string str1 = strArray[strArray.Length - 1];
        int num;
        for (num = 0; num < str1.Length; ++num)
        {
          string str2 = str1.Substring(num, 1);
          try
          {
            int int16 = (int) Convert.ToInt16(str2);
          }
          catch
          {
            break;
          }
        }
        if (num == 0)
          return (Version) null;
        string str3 = str1.Substring(0, num);
        strArray[strArray.Length - 1] = str3;
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < strArray.Length - 1; ++index)
          stringBuilder.Append(strArray[index] + ".");
        stringBuilder.Append(strArray[strArray.Length - 1]);
        return new Version(stringBuilder.ToString());
      }
      catch
      {
        return (Version) null;
      }
    }
  }
}
