// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.Option
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Xwt.GtkBackend;

namespace CocoStudio.Basic
{
  public static class Option
  {
    public static string HelpLink = "manual.cocostudio.org";
    private const string sourceFileName = "Install.config";
    public const string softwareName = "CocosStudio";
    public const string softwareName2 = "CocosStudio2";
    public const string softwareFullName = "Cocos Studio";
    private const string defaultProjectDirName = "Projects";
    private const string defaultPluginDirName = "Addins";
    public const string helpLinkConfig = "HelpLink.config";
    public const string mainSceneName = "MainScene.csd";
    public const string cocos = "Cocos";
    public const string LockFolder = "LockTemp";
    public const string LastSolutionFolder = "LastSolutionTemp";
    public const string AutoUpdateFolder = "AutoUpdate";
    public const string SampleFolder = "Samples";
    public const string LauncherResFolder = "LauncherResource";
    public const string CocosStudioExeName = "CocosStudio.exe";
    public const string LauncherExeName = "Cocos.exe";
    public const string MainVersion = "2.0";
    public const string AddinNamespace = "CocoStudio";

    public static string AssemblyPath { get; private set; }

    public static string EditorDefaultResourcePath { get; private set; }

    public static string UserCustomerConfigFolder { get; private set; }

    public static string SamplesFolder { get; private set; }

    public static string SamplesRootFolder { get; private set; }

    public static EnumEditorIDE CurrentEditorIDE { get; private set; }

    public static UserConfig UserConfig { get; private set; }

    public static string DefaultProjectsDir { get; private set; }

    public static bool IsStartWithOpenProject
    {
      get
      {
        return Option.CheckIsStartWithOpenProject();
      }
    }

    public static string AddinLocationFolder { get; private set; }

    public static Version EditorVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version;
      }
    }

    public static string AddinConfigFolder { get; private set; }

    public static string MyDocumentsFolder { get; private set; }

    public static bool IsXP
    {
      get
      {
        return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 1;
      }
    }

    static Option()
    {
      try
      {
        Option.Init();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    private static void Init()
    {
      Option.AssemblyPath = AppDomain.CurrentDomain.BaseDirectory;
      Option.EditorDefaultResourcePath = Path.Combine(Option.AssemblyPath, "EditorDefaultRes");
      Option.UserCustomerConfigFolder = Path.Combine(Option.GetConfigFolderLocation(), "Cocos", "CocosStudio2");
      Log4Wrap.SetLocation(Option.UserCustomerConfigFolder);
      Option.SamplesRootFolder = Option.GetSamplesFolderLocation();
      Option.SamplesFolder = Path.Combine(Option.SamplesRootFolder, "Cocos", "CocosStudio2");
      Option.DefaultProjectsDir = Path.Combine(Option.UserCustomerConfigFolder, "Projects");
      Option.AddinLocationFolder = Path.Combine(Option.UserCustomerConfigFolder, "Addins");
      Option.AddinConfigFolder = Path.Combine(Option.UserCustomerConfigFolder, "AddinConfig");
      Option.MyDocumentsFolder = Option.GetMyDocumentsFolder();
      Option.CheckResourceDir();
      Option.CheckUserConfigDir();
      Option.CheckDefaultPojectsDir();
      Option.CheckPluginDir();
      Option.UserConfig = UserConfig.Create();
      Option.HelpLink = Option.GetHelpLink();
    }

    private static void CheckUserConfigDir()
    {
      Option.CheckDirToCreat(Option.UserCustomerConfigFolder);
    }

    private static void CheckDefaultPojectsDir()
    {
      Option.CheckDirToCreat(Option.DefaultProjectsDir);
    }

    private static void CheckResourceDir()
    {
      Option.CheckDirToCreat(Option.EditorDefaultResourcePath);
    }

    private static void CheckPluginDir()
    {
      Option.CheckDirToCreat(Option.AddinLocationFolder);
    }

    private static bool CheckIsStartWithOpenProject()
    {
      string[] commandLineArgs = Environment.GetCommandLineArgs();
      return commandLineArgs.Length > 1 && !string.IsNullOrEmpty(commandLineArgs[1]) && File.Exists(commandLineArgs[1].Trim());
    }

    private static string GetConfigFolderLocation()
    {
      if (Platform.IsMac)
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library", "Application Support");
      return Option.GetConfigFolderOnWindows();
    }

    private static string GetSamplesFolderLocation()
    {
      if (!Platform.IsMac)
        return Option.GetConfigFolderOnWindows();
      Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      return Path.Combine("/Library", "Application Support");
    }

    private static string GetConfigFolderOnWindows()
    {
      try
      {
        object obj = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\ChuKong\\CocoStudio\\AppSourceKey", "AppSourceFolder", (object) null);
        if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
        {
          string path = obj.ToString();
          if (path.Substring(path.Length - 1, 1) == ":")
            path += "\\";
          if (Directory.Exists(path))
            return path;
        }
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Read install.config failed.", ex);
      }
      return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }

    public static string GetMyDocumentsFolder()
    {
      if (Platform.IsMac)
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents");
      return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }

    public static string GetEditorResourceFullPath(string fileName)
    {
      return Path.Combine(Option.EditorDefaultResourcePath, fileName);
    }

    public static string GetAssemblyFullPath(string fileName)
    {
      return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
    }

    public static void SetCurrentIDE(EnumEditorIDE editorIDE)
    {
      Option.CurrentEditorIDE = editorIDE;
    }

    public static void CheckDirToCreat(string dirPath)
    {
      if (Directory.Exists(dirPath))
        return;
      try
      {
        Directory.CreateDirectory(dirPath);
      }
      catch (Exception ex)
      {
        LogConfig.Output.Error((object) "创建配置目录失败", ex);
      }
    }

    public static string GetUserConfigFileByName(string fileName)
    {
      return Path.Combine(Option.UserCustomerConfigFolder, fileName);
    }

    public static string GetSamplePathByName(string fileName)
    {
      return Path.Combine(Option.SamplesFolder, fileName);
    }

    public static void SetFileAttributeCanRead(string filePath)
    {
      if (!File.Exists(filePath))
        return;
      FileInfo fileInfo = new FileInfo(filePath);
      if (fileInfo.Attributes.ToString().IndexOf("ReadOnly") != -1)
        fileInfo.Attributes = FileAttributes.Normal;
    }

    public static string ConvertToMacPath(string filePath)
    {
      return filePath.Replace('\\', '/');
    }

    public static string GetHelpLink()
    {
      string str = "manual.cocostudio.org";
      string configFileByName = Option.GetUserConfigFileByName("HelpLink.config");
      if (File.Exists(configFileByName))
      {
        try
        {
          XElement xelement = XElement.Load(configFileByName).Element((XName) "HelpLink");
          if (xelement != null)
            str = xelement.Value;
        }
        catch (Exception ex)
        {
          LogConfig.Logger.Error((object) ex);
        }
      }
      return str;
    }
  }
}
