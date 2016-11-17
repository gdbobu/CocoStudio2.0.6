// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListData
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System;

namespace Modules.Communal.PList
{
  public class PListData : PListElement<byte[]>
  {
    public override string Tag
    {
      get
      {
        return "data";
      }
    }

    public override byte TypeCode
    {
      get
      {
        return 4;
      }
    }

    public override byte[] Value { get; set; }

    public PListData()
    {
    }

    public PListData(byte[] value)
    {
      this.Value = value;
    }

    protected override void Parse(string value)
    {
      this.Value = Convert.FromBase64String(value);
    }

    protected override string ToXmlString()
    {
      return Convert.ToBase64String(this.Value);
    }

    public override void ReadBinary(PListBinaryReader reader)
    {
      this.Value = new byte[reader.CurrentElementLength];
      if (reader.BaseStream.Read(this.Value, 0, this.Value.Length) != this.Value.Length)
        throw new PListFormatException();
    }

    public override int GetPListElementLength()
    {
      return this.Value.Length;
    }

    public override void WriteBinary(PListBinaryWriter writer)
    {
      writer.BaseStream.Write(this.Value, 0, this.Value.Length);
    }
  }
}
