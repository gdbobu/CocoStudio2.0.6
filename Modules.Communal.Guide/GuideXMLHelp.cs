// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Guide.GuideXMLHelp
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

using CocoStudio.Basic;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Modules.Communal.Guide
{
  public class GuideXMLHelp
  {
    private static string CurrentVersion = Option.EditorVersion.ToString(4);
    private static string EditorType = Option.CurrentEditorIDE.ToString();
    private static bool IsMac = Platform.IsMac;
    private static string GuideXmlPath = Path.Combine(Option.SamplesFolder, "Samples", "Guide");
    private static string GuideConfigPath;
    public static string FilePath;
    private static string SampleInfoPath;
    private static string MacSourceConfigPath;

    static GuideXMLHelp()
    {
      if (GuideXMLHelp.IsMac)
      {
        GuideXMLHelp.GuideConfigPath = Path.Combine(Option.UserCustomerConfigFolder, "GuideConfig.config");
        GuideXMLHelp.MacSourceConfigPath = Path.Combine(GuideXMLHelp.GuideXmlPath, "GuideConfig.config");
      }
      else
      {
        GuideXMLHelp.GuideConfigPath = Path.Combine(GuideXMLHelp.GuideXmlPath, "GuideConfig.config");
        GuideXMLHelp.MacSourceConfigPath = "";
      }
      GuideXMLHelp.FilePath = Path.Combine(GuideXMLHelp.GuideXmlPath, GuideXMLHelp.CurrentVersion, GuideXMLHelp.EditorType);
      GuideXMLHelp.SampleInfoPath = Path.Combine(GuideXMLHelp.FilePath, "SampleInfo.XML");
    }

    public static bool? GetGuideConfig()
    {
      if (GuideXMLHelp.IsMac)
      {
        if (!File.Exists(GuideXMLHelp.GuideConfigPath))
        {
          if (File.Exists(GuideXMLHelp.MacSourceConfigPath))
            File.Copy(GuideXMLHelp.MacSourceConfigPath, GuideXMLHelp.GuideConfigPath);
        }
        else
        {
          bool flag = false;
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.Load(GuideXMLHelp.GuideConfigPath);
          XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("Version");
          if (xmlNode != null && xmlNode.InnerText.Equals(GuideXMLHelp.CurrentVersion))
            flag = true;
          if (!flag)
          {
            File.Delete(GuideXMLHelp.GuideConfigPath);
            if (File.Exists(GuideXMLHelp.MacSourceConfigPath))
              File.Copy(GuideXMLHelp.MacSourceConfigPath, GuideXMLHelp.GuideConfigPath);
          }
        }
      }
      if (!File.Exists(GuideXMLHelp.GuideConfigPath) || !File.Exists(GuideXMLHelp.SampleInfoPath))
        return new bool?(false);
      XmlDocument xmlDocument1 = new XmlDocument();
      xmlDocument1.Load(GuideXMLHelp.GuideConfigPath);
      XmlElement documentElement = xmlDocument1.DocumentElement;
      if (documentElement.SelectSingleNode(GuideXMLHelp.EditorType) == null)
        return new bool?(false);
      if (documentElement.SelectSingleNode(GuideXMLHelp.EditorType).InnerText == "True")
        return new bool?(true);
      return new bool?(false);
    }

    public static void SaveGuideConfig(bool? isDisplay)
    {
      if (!File.Exists(GuideXMLHelp.GuideConfigPath))
        new XDocument(new object[1]
        {
          (object) new XElement((XName) "GuideDisplayConfig", new object[3]
          {
            (object) new XElement((XName) "Ui", (object) "False"),
            (object) new XElement((XName) "Animation", (object) "False"),
            (object) new XElement((XName) "Scene", (object) "False")
          })
        }).Save(GuideXMLHelp.GuideConfigPath);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(GuideXMLHelp.GuideConfigPath);
      foreach (XmlElement childNode in xmlDocument.SelectSingleNode("GuideDisplayConfig").ChildNodes)
      {
        if (string.Compare(childNode.Name, Option.CurrentEditorIDE.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
        {
          childNode.InnerText = isDisplay.ToString();
          break;
        }
      }
      xmlDocument.Save(GuideXMLHelp.GuideConfigPath);
    }

    public static List<ImageItemModel.Item> GetImagePathList()
    {
      try
      {
        string str = Path.Combine(GuideXMLHelp.FilePath, "SampleInfo.xml");
        if (File.Exists(str))
        {
          ImageItemModel.Editor editor = Helper_XML.XMLAction<ImageItemModel.Editor>.ReadData(str);
          if (LanguageOption.CurrentLanguage == LanguageType.Chinese)
            return editor.Chinese.part;
          return editor.English.part;
        }
      }
      catch (Exception ex)
      {
      }
      return (List<ImageItemModel.Item>) null;
    }

    public static Xwt.Drawing.Image GainImage(string imageName)
    {
      string str = Path.Combine(GuideXMLHelp.FilePath, imageName);
      try
      {
        if (File.Exists(str))
          return ImageIcon.GetIconFromFile(str);
      }
      catch
      {
        return (Xwt.Drawing.Image) null;
      }
      return (Xwt.Drawing.Image) null;
    }
  }
}
