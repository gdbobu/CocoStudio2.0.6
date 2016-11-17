// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.Internal.PListElement`1
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Modules.Communal.PList.Internal
{
  public abstract class PListElement<T> : IPListElement, IXmlSerializable, IEquatable<IPListElement>
  {
    public abstract string Tag { get; }

    public abstract byte TypeCode { get; }

    public virtual bool IsBinaryUnique
    {
      get
      {
        return true;
      }
    }

    public abstract T Value { get; set; }

    public static implicit operator T(PListElement<T> element)
    {
      return element.Value;
    }

    public virtual XmlSchema GetSchema()
    {
      return (XmlSchema) null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      reader.ReadStartElement();
      this.Parse(reader.ReadString());
      reader.ReadEndElement();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement(this.Tag);
      writer.WriteValue(this.ToXmlString());
      writer.WriteEndElement();
    }

    protected abstract void Parse(string value);

    protected abstract string ToXmlString();

    public override string ToString()
    {
      return string.Format("{0}: {1}", (object) this.Tag, (object) this.Value);
    }

    public virtual int GetPListElementCount()
    {
      return 1;
    }

    public abstract int GetPListElementLength();

    public abstract void ReadBinary(PListBinaryReader reader);

    public abstract void WriteBinary(PListBinaryWriter writer);

    public bool Equals(IPListElement other)
    {
      return other is PListElement<T> && this.Value.Equals((object) ((PListElement<T>) other).Value);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is IPListElement))
        return false;
      return this.Equals((IPListElement) obj);
    }

    public override int GetHashCode()
    {
      return this.Value.GetHashCode();
    }
  }
}
