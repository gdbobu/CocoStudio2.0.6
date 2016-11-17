// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CocosInfo
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using Microsoft.Win32;
using MonoDevelop.Core;
using System;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  public class CocosInfo
  {
    public const string CppVersionFileName = "cocos2d.cpp";
    public const string DefaultVersionText = "cocos2d-x";
    private const string Cocos2_folder = "cocos2dx";
    private const string Cocos3_folder = "cocos";
    private const string FileListFile = "cocos2dx_files.json";

    public string RootPath { get; private set; }

    public string VersionText { get; private set; }

    public int MainVersion { get; private set; }

    public bool EnableCpp { get; private set; }

    public bool EnableLua { get; private set; }

    public bool EnableJs { get; private set; }

    public bool IsDefault { get; private set; }

    private CocosInfo()
    {
      this.RootPath = "";
      this.VersionText = "";
      this.MainVersion = 0;
      this.EnableCpp = false;
      this.EnableLua = false;
      this.EnableJs = false;
      this.IsDefault = false;
    }

    internal static CocosInfo CreateCustomInfo(string path = "", bool isAutoCheck = false)
    {
      CocosInfo codeInfo = (CocosInfo) null;
      string defaultPath = CocosInfo.GetDefaultPath();
      if (!string.IsNullOrEmpty(defaultPath))
      {
        if ((string.IsNullOrEmpty(path) || CocosInfo.CheckIsDefault(path)) && CocosInfo.TryCreateDefaultCodeInfo(defaultPath, out codeInfo))
          return codeInfo;
      }
      else if (string.IsNullOrEmpty(path))
        return (CocosInfo) null;
      if (CocosInfo.TryCreateCodeInfoV2(path, out codeInfo) || CocosInfo.TryCreateCodeInfoV3(path, out codeInfo) || (CocosInfo.TryCreateCodeInfoV3_JS(path, out codeInfo) || CocosInfo.TryCreateCodeInfoWithoutVersion(path, out codeInfo)))
        return codeInfo;
      if (!isAutoCheck)
        return (CocosInfo) null;
      if (CocosInfo.TryCreateDefaultCodeInfo(defaultPath, out codeInfo))
        return codeInfo;
      return (CocosInfo) null;
    }

    private static string GetDefaultPath()
    {
      string str = string.Empty;
      if (Platform.IsWindows)
      {
        try
        {
          str = Path.Combine(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Cocos", "InstallDir", (object) null).ToString(), "frameworks", "cocos2d-x");
        }
        catch (Exception ex)
        {
          LogConfig.Logger.Error((object) ex);
          str = string.Empty;
        }
      }
      else if (Platform.IsMac)
        str = "/Applications/Cocos/frameworks/cocos2d-x";
      return str;
    }

    private static bool CheckIsDefault(string path)
    {
      return Path.GetFullPath(CocosInfo.GetDefaultPath().ToLower()).Equals(Path.GetFullPath(path.ToLower()));
    }

    private static bool TryCreateCodeInfoV2(string path, out CocosInfo codeInfo)
    {
      string str = Path.Combine(path, "cocos2dx", "cocos2d.cpp");
      if (File.Exists(str))
      {
        codeInfo = new CocosInfo()
        {
          RootPath = path,
          MainVersion = 2,
          EnableCpp = true,
          EnableLua = true,
          EnableJs = true,
          VersionText = CocosInfo.GetVersionText(str)
        };
        return true;
      }
      codeInfo = (CocosInfo) null;
      return false;
    }

    private static bool TryCreateCodeInfoV3(string path, out CocosInfo codeInfo)
    {
      string str = Path.Combine(path, "cocos", "cocos2d.cpp");
      if (File.Exists(str))
      {
        codeInfo = new CocosInfo()
        {
          RootPath = path,
          MainVersion = 3,
          EnableCpp = true,
          EnableLua = true,
          EnableJs = false,
          VersionText = CocosInfo.GetVersionText(str)
        };
        return true;
      }
      codeInfo = (CocosInfo) null;
      return false;
    }

    private static bool TryCreateCodeInfoV3_JS(string path, out CocosInfo codeInfo)
    {
      string str = Path.Combine(path, "frameworks", "js-bindings", "cocos2d-x", "cocos", "cocos2d.cpp");
      if (File.Exists(str))
      {
        codeInfo = new CocosInfo()
        {
          RootPath = path,
          MainVersion = 3,
          EnableCpp = false,
          EnableLua = false,
          EnableJs = true,
          VersionText = CocosInfo.GetVersionText(str)
        };
        return true;
      }
      codeInfo = (CocosInfo) null;
      return false;
    }

    private static bool TryCreateCodeInfoWithoutVersion(string path, out CocosInfo codeInfo)
    {
      if (File.Exists(Path.Combine(path, "templates", "cocos2dx_files.json")))
      {
        codeInfo = new CocosInfo()
        {
          RootPath = path,
          MainVersion = 3,
          EnableCpp = true,
          EnableLua = true,
          EnableJs = false,
          VersionText = "Cocos2d-x 3.0"
        };
        return true;
      }
      codeInfo = (CocosInfo) null;
      return false;
    }

    private static bool TryCreateDefaultCodeInfo(string path, out CocosInfo codeInfo)
    {
      try
      {
        string path1 = Path.Combine(path, "version");
        if (File.Exists(path1))
        {
          CocosInfo cocosInfo = new CocosInfo();
          cocosInfo.RootPath = path;
          cocosInfo.MainVersion = 3;
          cocosInfo.EnableCpp = true;
          cocosInfo.EnableLua = true;
          cocosInfo.EnableJs = false;
          cocosInfo.IsDefault = true;
          StreamReader streamReader = new StreamReader(path1);
          cocosInfo.VersionText = streamReader.ReadLine();
          codeInfo = cocosInfo;
          return true;
        }
        codeInfo = (CocosInfo) null;
        return false;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("获取默认引擎信息失败：\r\n" + ex.ToString()));
        codeInfo = (CocosInfo) null;
        return false;
      }
    }

    internal static string GetVersionText(string cppFilePath)
    {
      try
      {
        StreamReader streamReader = new StreamReader(cppFilePath);
        string str1 = "cocos2dVersion";
        bool flag = false;
        for (string str2 = streamReader.ReadLine(); str2 != null; str2 = streamReader.ReadLine())
        {
          if (str2.Contains(str1))
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          return (string) null;
        streamReader.ReadLine();
        string[] strArray = streamReader.ReadLine().Split('"');
        if (string.IsNullOrEmpty(strArray[1]))
          return "cocos2d-x";
        return strArray[1];
      }
      catch
      {
        return "cocos2d-x";
      }
    }
  }
}
