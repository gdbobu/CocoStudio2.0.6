// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListDict
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Modules.Communal.PList
{
  public class PListDict : Dictionary<string, IPListElement>, IPListElement, IXmlSerializable
  {
    public string Tag
    {
      get
      {
        return "dict";
      }
    }

    public byte TypeCode
    {
      get
      {
        return 13;
      }
    }

    public bool IsBinaryUnique
    {
      get
      {
        return false;
      }
    }

    public void ReadBinary(PListBinaryReader reader)
    {
      byte[] buffer1 = new byte[reader.CurrentElementLength * (int) reader.ElementIdxSize];
      byte[] buffer2 = new byte[reader.CurrentElementLength * (int) reader.ElementIdxSize];
      if (reader.BaseStream.Read(buffer1, 0, buffer1.Length) != buffer1.Length)
        throw new PListFormatException();
      if (reader.BaseStream.Read(buffer2, 0, buffer2.Length) != buffer2.Length)
        throw new PListFormatException();
      for (int index = 0; index < reader.CurrentElementLength; ++index)
      {
        IPListElement plistElement1 = reader.ReadInternal((int) reader.ElementIdxSize == 1 ? (int) buffer1[index] : (int) IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer1, 2 * index)));
        if (!(plistElement1 is PListString))
          throw new PListFormatException("Key is no String");
        IPListElement plistElement2 = reader.ReadInternal((int) reader.ElementIdxSize == 1 ? (int) buffer2[index] : (int) IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer2, 2 * index)));
        this.Add((string) ((PListElement<string>) plistElement1), plistElement2);
      }
    }

    public int GetPListElementLength()
    {
      return this.Count;
    }

    public int GetPListElementCount()
    {
      int num = 1;
      foreach (IPListElement plistElement in this.Values)
        num += plistElement.GetPListElementCount();
      return num + this.Keys.Count;
    }

    public void WriteBinary(PListBinaryWriter writer)
    {
      byte[] buffer1 = new byte[(int) writer.ElementIdxSize * this.Count];
      byte[] buffer2 = new byte[(int) writer.ElementIdxSize * this.Count];
      long position = writer.BaseStream.Position;
      writer.BaseStream.Write(buffer1, 0, buffer1.Length);
      writer.BaseStream.Write(buffer2, 0, buffer2.Length);
      KeyValuePair<string, IPListElement>[] array = this.ToArray<KeyValuePair<string, IPListElement>>();
      for (int index = 0; index < this.Count; ++index)
      {
        int idx = writer.WriteInternal(PListElementFactory.Instance.CreateKeyElement(array[index].Key));
        writer.FormatIdx(idx).CopyTo((Array) buffer1, (int) writer.ElementIdxSize * index);
      }
      for (int index = 0; index < this.Count; ++index)
      {
        int idx = writer.WriteInternal(array[index].Value);
        writer.FormatIdx(idx).CopyTo((Array) buffer2, (int) writer.ElementIdxSize * index);
      }
      writer.BaseStream.Seek(position, SeekOrigin.Begin);
      writer.BaseStream.Write(buffer1, 0, buffer1.Length);
      writer.BaseStream.Write(buffer2, 0, buffer2.Length);
      writer.BaseStream.Seek(0L, SeekOrigin.End);
    }

    public XmlSchema GetSchema()
    {
      return (XmlSchema) null;
    }

    public void ReadXml(XmlReader reader)
    {
      bool isEmptyElement = reader.IsEmptyElement;
      reader.Read();
      if (isEmptyElement)
        return;
      while (reader.NodeType != XmlNodeType.EndElement)
      {
        reader.ReadStartElement("key");
        string key = reader.ReadString();
        reader.ReadEndElement();
        IPListElement plistElement = PListElementFactory.Instance.Create(reader.LocalName);
        plistElement.ReadXml(reader);
        this.Add(key, plistElement);
        int content = (int) reader.MoveToContent();
      }
      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.Tag);
      foreach (string key in this.Keys)
      {
        writer.WriteStartElement("key");
        writer.WriteValue(key);
        writer.WriteEndElement();
        this[key].WriteXml(writer);
      }
      writer.WriteEndElement();
    }
  }
}
