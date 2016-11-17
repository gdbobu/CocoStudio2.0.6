// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListRoot
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Modules.Communal.PList
{
  [XmlRoot("plist")]
  public class PListRoot : IXmlSerializable
  {
    public PListFormat Format { get; set; }

    public IPListElement Root { get; set; }

    public static PListRoot Load(string fileName)
    {
      using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        return PListRoot.Load((Stream) fileStream);
    }

    public static PListRoot Load(Stream stream)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (PListRoot));
      byte[] numArray = new byte[8];
      stream.Read(numArray, 0, numArray.Length);
      stream.Seek(0L, SeekOrigin.Begin);
      PListRoot plistRoot;
      if (Encoding.Default.GetString(numArray) == "bplist00")
      {
        PListBinaryReader plistBinaryReader = new PListBinaryReader();
        plistRoot = new PListRoot();
        plistRoot.Format = PListFormat.Binary;
        plistRoot.Root = plistBinaryReader.Read(stream);
      }
      else
      {
        plistRoot = (PListRoot) xmlSerializer.Deserialize(stream);
        plistRoot.Format = PListFormat.Xml;
      }
      return plistRoot;
    }

    public void Save(string fileName, PListFormat format)
    {
      using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        this.Save((Stream) fileStream, format);
    }

    public void Save(string fileName)
    {
      this.Save(fileName, this.Format);
    }

    public void Save(Stream stream)
    {
      this.Save(stream, this.Format);
    }

    public void Save(Stream stream, PListFormat format)
    {
      if (format == PListFormat.Xml)
      {
        XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true, IndentChars = "\t", NewLineChars = "\n" });
        writer.WriteStartDocument();
        writer.WriteDocType("plist", "-//Apple Computer//DTD PLIST 1.0//EN", "http://www.apple.com/DTDs/PropertyList-1.0.dtd", (string) null);
        this.WriteXml(writer);
        writer.Flush();
      }
      else
        new PListBinaryWriter().Write(stream, this.Root);
    }

    public XmlSchema GetSchema()
    {
      return (XmlSchema) null;
    }

    public void ReadXml(XmlReader reader)
    {
      reader.ReadStartElement("plist");
      this.Root = PListElementFactory.Instance.Create(reader.LocalName);
      this.Root.ReadXml(reader);
      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("plist");
      writer.WriteAttributeString("version", "1.0");
      if (this.Root != null)
        this.Root.WriteXml(writer);
      writer.WriteEndElement();
    }
  }
}
