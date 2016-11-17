// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListFill
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Modules.Communal.PList
{
  public class PListFill : IPListElement, IXmlSerializable
  {
    public string Tag
    {
      get
      {
        return "fill";
      }
    }

    public byte TypeCode
    {
      get
      {
        return 0;
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
      if (reader.CurrentElementLength != 15)
        throw new PListFormatException();
    }

    public int GetPListElementLength()
    {
      return 15;
    }

    public int GetPListElementCount()
    {
      return 1;
    }

    public void WriteBinary(PListBinaryWriter writer)
    {
    }

    public XmlSchema GetSchema()
    {
      return (XmlSchema) null;
    }

    public void ReadXml(XmlReader reader)
    {
      reader.ReadStartElement(this.Tag);
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.Tag);
      writer.WriteEndElement();
    }
  }
}
