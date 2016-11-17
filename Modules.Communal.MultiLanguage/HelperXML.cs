// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MultiLanguage.HelperXML
// Assembly: Modules.Communal.MultiLanguage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 71ED3653-D37E-48A4-9AB9-CFA5ACC57BF1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MultiLanguage.dll

using System;
using System.IO;
using System.Xml.Serialization;

namespace Modules.Communal.MultiLanguage
{
  public static class HelperXML
  {
    public static string FileDirectory = string.Empty;

    public static void SaveXml(string filePath, object obj)
    {
      HelperXML.SaveXml(filePath, obj, obj.GetType());
    }

    public static void SaveXml(string filePath, object obj, Type type)
    {
      using (StreamWriter streamWriter = new StreamWriter(filePath))
      {
        new XmlSerializer(type).Serialize((TextWriter) streamWriter, obj);
        streamWriter.Close();
      }
    }

    public static object LoadXml(string filePath, Type type)
    {
      if (!File.Exists(filePath))
        return (object) null;
      using (StreamReader streamReader = new StreamReader(filePath))
      {
        object obj = new XmlSerializer(type).Deserialize((TextReader) streamReader);
        streamReader.Close();
        return obj;
      }
    }

    public static object LoadXml(Stream stream, Type type)
    {
      if (stream == null || stream.Length == 0L)
        return (object) null;
      return new XmlSerializer(type).Deserialize(stream);
    }

    public static class XMLAction<T> where T : class
    {
      public static T ReadData(string FullPath)
      {
        return HelperXML.LoadXml(FullPath, typeof (T)) as T;
      }

      public static T ReadData(Stream stream)
      {
        return HelperXML.LoadXml(stream, typeof (T)) as T;
      }

      public static string WriteData(T obj, string fullpath)
      {
        try
        {
          HelperXML.SaveXml(fullpath, (object) obj);
          return (string) null;
        }
        catch (Exception ex)
        {
          return ex.Message;
        }
      }
    }
  }
}
