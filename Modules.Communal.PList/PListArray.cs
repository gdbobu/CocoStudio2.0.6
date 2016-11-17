// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListArray
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Modules.Communal.PList
{
  public class PListArray : List<IPListElement>, IPListElement, IXmlSerializable
  {
    public string Tag
    {
      get
      {
        return "array";
      }
    }

    public byte TypeCode
    {
      get
      {
        return 10;
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
      byte[] buffer = new byte[reader.CurrentElementLength * (int) reader.ElementIdxSize];
      if (reader.BaseStream.Read(buffer, 0, buffer.Length) != buffer.Length)
        throw new PListFormatException();
      for (int index = 0; index < reader.CurrentElementLength; ++index)
        this.Add(reader.ReadInternal((int) reader.ElementIdxSize == 1 ? (int) buffer[index] : (int) IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 2 * index))));
    }

    public int GetPListElementLength()
    {
      return this.Count;
    }

    public int GetPListElementCount()
    {
      int num = 1;
      foreach (IPListElement plistElement in (List<IPListElement>) this)
        num += plistElement.GetPListElementCount();
      return num;
    }

    public void WriteBinary(PListBinaryWriter writer)
    {
      byte[] buffer = new byte[(int) writer.ElementIdxSize * this.Count];
      long position = writer.BaseStream.Position;
      writer.BaseStream.Write(buffer, 0, buffer.Length);
      for (int index = 0; index < this.Count; ++index)
      {
        int idx = writer.WriteInternal(this[index]);
        writer.FormatIdx(idx).CopyTo((Array) buffer, (int) writer.ElementIdxSize * index);
      }
      writer.BaseStream.Seek(position, SeekOrigin.Begin);
      writer.BaseStream.Write(buffer, 0, buffer.Length);
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
        IPListElement plistElement = PListElementFactory.Instance.Create(reader.LocalName);
        plistElement.ReadXml(reader);
        this.Add(plistElement);
        int content = (int) reader.MoveToContent();
      }
      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.Tag);
      for (int index = 0; index < this.Count; ++index)
        this[index].WriteXml(writer);
      writer.WriteEndElement();
    }
  }
}
