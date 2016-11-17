// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.SerializersHelper
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Modules.Communal.MutualEditor
{
  internal static class SerializersHelper
  {
    public static MemoryStream SerializeBinary(this object request)
    {
      MemoryStream memoryStream = new MemoryStream();
      new BinaryFormatter().Serialize((Stream) memoryStream, request);
      return memoryStream;
    }

    public static T DeSerializeBinary<T>(this MemoryStream memStream) where T : class
    {
      return memStream.DeSerializeBinary() as T;
    }

    public static object DeSerializeBinary(this MemoryStream memStream)
    {
      try
      {
        memStream.Position = 0L;
        object obj = new BinaryFormatter().Deserialize((Stream) memStream);
        memStream.Close();
        return obj;
      }
      catch
      {
      }
      return (object) null;
    }
  }
}
