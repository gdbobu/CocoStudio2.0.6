// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Guide.Helper_XML
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

using System;
using System.IO;
using System.Xml.Serialization;

namespace Modules.Communal.Guide
{
  public static class Helper_XML
  {
    public static string FileDirectory = string.Empty;

    public static void SaveXml(string filePath, object obj)
    {
      Helper_XML.SaveXml(filePath, obj, obj.GetType());
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
        return Helper_XML.LoadXml(FullPath, typeof (T)) as T;
      }

      public static T ReadData(Stream stream)
      {
        return Helper_XML.LoadXml(stream, typeof (T)) as T;
      }

      public static string WriteData(T obj, string fullpath)
      {
        try
        {
          Helper_XML.SaveXml(fullpath, (object) obj);
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
