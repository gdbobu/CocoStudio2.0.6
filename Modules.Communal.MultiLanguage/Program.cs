// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MultiLanguage.Program
// Assembly: Modules.Communal.MultiLanguage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 71ED3653-D37E-48A4-9AB9-CFA5ACC57BF1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MultiLanguage.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Modules.Communal.MultiLanguage
{
  internal class Program
  {
    private static string xmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/";
    private static string CHSxmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/en-CHS.xml";
    private static string USxmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/en-US.xml";
    private static string JAxmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/en-JA.xml";
    private static string KOxmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/en-KO.xml";
    private static string SPxmlPath = "../../../../CocoStudioCommon/EditorCommon/LanguageResource/en-SP.xml";
    private static XElement TempXmlInfo = (XElement) null;
    public static Type TypeLanguageInfo = typeof (LanguageInfo);

    [STAThread]
    private static void Main(string[] args)
    {
      Console.WriteLine("test");
      Console.WriteLine("{0}", (object) Program.GetCurrentDirectoryPath());
      string[] files = Directory.GetFiles(Program.xmlPath);
      string empty = string.Empty;
      Program.WriteChineseXml();
      foreach (string filePath in files)
      {
        Console.WriteLine("{0}", (object) filePath);
        if (filePath.Contains("en-US.xml"))
          Program.updateLanguageXml("US", filePath);
        else if (filePath.Contains("en-JA.xml"))
          Program.updateLanguageXml("JA", filePath);
        else if (filePath.Contains("en-KO.xml"))
          Program.updateLanguageXml("KO", filePath);
        else if (filePath.Contains("en-SP.xml"))
          Program.updateLanguageXml("SP", filePath);
      }
      Console.ReadKey();
    }

    internal static void updateLanguageXml(string type, string filePath)
    {
      XElement xelement1 = new XElement((XName) type);
      XElement xelement2 = new XElement((XName) type);
      string str1 = Path.Combine(Program.xmlPath, "untranslated/");
      Directory.CreateDirectory(str1);
      string fileName = Path.Combine(str1, Path.GetFileName(filePath));
      Console.WriteLine("{0}", (object) fileName);
      FieldInfo[] fields = Program.TypeLanguageInfo.GetFields();
      Console.WriteLine("{0} is exist", (object) filePath);
      foreach (MemberInfo memberInfo in fields)
      {
        string name = memberInfo.Name;
        string str2 = Program.GetTranslateInfo(name, filePath);
        if (string.IsNullOrEmpty(str2))
          str2 = "#HereIsEmpty#";
        if (str2 == "#HereIsEmpty#")
          xelement2.Add((object) Program.CreatItem(name, str2));
        xelement1.Add((object) Program.CreatItem(name, str2));
      }
      xelement1.Save(filePath);
      xelement2.Save(fileName);
    }

    internal static string GetTranslateInfo(string key, string filePath)
    {
      if (!File.Exists(filePath))
        return string.Empty;
      Program.TempXmlInfo = (XElement) null;
      TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filePath, FileMode.Open));
      string end = textReader.ReadToEnd();
      textReader.Close();
      Program.TempXmlInfo = XElement.Parse(end);
      foreach (XElement descendant in Program.TempXmlInfo.Descendants((XName) "Item"))
      {
        if (descendant.Attribute((XName) "Key").Value == key)
          return descendant.Attribute((XName) "Value").Value;
      }
      return string.Empty;
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

    internal static void WriteChineseXml()
    {
      string chSxmlPath = Program.CHSxmlPath;
      XElement xelement = new XElement((XName) "CH");
      foreach (MemberInfo field in Program.TypeLanguageInfo.GetFields())
      {
        string name = field.Name;
        string valueBykey = Program.GetValueBykey(name);
        xelement.Add((object) Program.CreatItem(name, valueBykey));
      }
      xelement.Save(chSxmlPath);
    }

    public static string GetValueBykey(string key)
    {
      if (key == null)
        return string.Empty;
      FieldInfo field = Program.TypeLanguageInfo.GetField(key);
      if (field != (FieldInfo) null)
        return field.GetValue((object) key).ToString();
      return key;
    }

    private static string GetCurrentDirectoryPath()
    {
      return Directory.GetParent(typeof (Program).Assembly.Location).FullName;
    }
  }
}
