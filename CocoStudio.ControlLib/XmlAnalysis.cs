// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.XmlAnalysis
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gtk;
using System;
using System.IO;
using System.Xml;

namespace CocoStudio.ControlLib
{
  public class XmlAnalysis
  {
    private static FileStream file;
    private static StreamReader reader;

    public static XmlNode GetNode(XmlNode node, string name)
    {
      if (node != null && node.HasChildNodes)
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          if (childNode.Name == name)
            return childNode;
        }
      }
      return (XmlNode) null;
    }

    public static string GetAttribute(XmlNode node, string name)
    {
      if (node != null && node.Attributes != null)
      {
        foreach (XmlAttribute attribute in (XmlNamedNodeMap) node.Attributes)
        {
          if (attribute.Name == name)
            return attribute.Value;
        }
      }
      return "";
    }

    public static XmlDocument ReaderXmlFile(string path)
    {
      XmlDocument xmlDocument = new XmlDocument();
      try
      {
        if (File.Exists(path))
        {
          XmlAnalysis.file = new FileStream(path, FileMode.Open);
          XmlAnalysis.reader = new StreamReader((Stream) XmlAnalysis.file);
          xmlDocument.Load((TextReader) XmlAnalysis.reader);
          XmlAnalysis.reader.Close();
          XmlAnalysis.file.Close();
        }
        else
          MessageBox.Show("文件不存在", (Window) null, (string) null, MessageBoxImage.Info);
      }
      catch (Exception ex)
      {
        MessageBox.Show("解析xml文件发生异常:" + ex.Message, (Window) null, (string) null, MessageBoxImage.Info);
      }
      return xmlDocument;
    }
  }
}
