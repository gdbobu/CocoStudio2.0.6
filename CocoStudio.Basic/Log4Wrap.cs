// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.Log4Wrap
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CocoStudio.Basic
{
  internal class Log4Wrap
  {
    private static ILog logger = (ILog) null;
    private static string configPath = string.Empty;
    private static string logfilename = string.Empty;
    private const string LOG_FOLDER = "logs";
    private const string LOG_CONFIG_FOLDER = "log4net_config";
    private const string LOGGER_NAME = "CKLog";
    private const string MaxSizeRollBackups = "10";
    private const string MaxFileSize = "500KB";

    public static ILog Logger
    {
      get
      {
        return Log4Wrap.logger;
      }
    }

    public static string ConfigPath
    {
      get
      {
        return Log4Wrap.configPath;
      }
    }

    private static void Init(string configFolder)
    {
      try
      {
        string withoutExtension = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
        string str1 = Path.Combine(configFolder, "log4net_config");
        string str2 = Path.Combine(configFolder, "logs");
        Log4Wrap.logfilename = withoutExtension + "_" + DateTime.Now.ToString("o") + ".log";
        Log4Wrap.logfilename = Log4Wrap.logfilename.Replace(":", ".");
        Log4Wrap.logfilename = Path.Combine(str2, Log4Wrap.logfilename);
        if (!Directory.Exists(str1))
          Directory.CreateDirectory(str1);
        if (!Directory.Exists(str2))
          Directory.CreateDirectory(str2);
        Log4Wrap.configPath = Path.Combine(str1, withoutExtension + ".xml");
        if (!File.Exists(Log4Wrap.configPath))
        {
          Log4Wrap.CreateDefaultConfigFile(Log4Wrap.configPath);
        }
        else
        {
          XElement xelement = XElement.Load(Log4Wrap.configPath);
          xelement.Descendants((XName) "appender").First<XElement>((Func<XElement, bool>) (n => n.Attribute((XName) "name").Value == "RollingFileAppender")).Element((XName) "file").Attribute((XName) "value").Value = Log4Wrap.logfilename;
          xelement.Save(Log4Wrap.configPath);
        }
        XmlConfigurator.ConfigureAndWatch(new FileInfo(Log4Wrap.configPath));
        Log4Wrap.logger = LogManager.GetLogger("CKLog");
      }
      catch (Exception )
      {
      }
    }

    internal static void SetLocation(string configFolder)
    {
      Log4Wrap.Init(configFolder);
    }

    private static void CreateDefaultConfigFile(string filename)
    {
      string empty = string.Empty;
      string str = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<configuration>\r\n    <configSections>\r\n        <section name=\"log4net\" type=\"log4net.Config.Log4NetConfigurationSectionHandler,log4net-net-1.2\" />\r\n    </configSections>\r\n\r\n    <log4net>\r\n        <logger name=\"CKLog\">\r\n            <level value=\"INFO\" />\r\n            <appender-ref ref=\"RollingFileAppender\" />\r\n            <appender-ref ref=\"ConsoleAppender\" />\r\n        </logger>\r\n\r\n        <appender name=\"ConsoleAppender\"  type=\"log4net.Appender.ConsoleAppender\" >\r\n            <layout type=\"log4net.Layout.PatternLayout\">\r\n                <param name=\"ConversionPattern\"  value=\"%date [%-5level] [Thrd:%thread] %l - %message%newline\"/>\r\n            </layout>\r\n        </appender>\r\n\r\n        <appender name=\"RollingFileAppender\" type=\"log4net.Appender.RollingFileAppender\">\r\n            <file value=\"" + Log4Wrap.logfilename + "\" />\r\n            <appendToFile value=\"true\" />\r\n            <rollingStyle value=\"Size\" />\r\n            <maxSizeRollBackups value=\"10\" />\r\n            <maximumFileSize value=\"500KB\" />\r\n            <staticLogFileName value=\"true\" />\r\n            <layout type=\"log4net.Layout.PatternLayout\">\r\n                <conversionPattern value=\"%date [%-5level] [Thrd:%thread] %l - %message%newline\" />\r\n            </layout>\r\n        </appender>\r\n    </log4net>\r\n</configuration>";
      try
      {
        StreamWriter text = File.CreateText(filename);
        text.Write(str);
        text.Close();
        text.Dispose();
      }
      catch (Exception ex)
      {
        string message = ex.Message;
      }
    }
  }
}
