// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListDate
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Modules.Communal.PList
{
  public class PListDate : PListElement<DateTime>
  {
    public override string Tag
    {
      get
      {
        return "date";
      }
    }

    public override byte TypeCode
    {
      get
      {
        return 3;
      }
    }

    public override DateTime Value { get; set; }

    public PListDate()
    {
    }

    public PListDate(DateTime value)
    {
      this.Value = value;
    }

    protected override void Parse(string value)
    {
      this.Value = DateTime.Parse(value, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    protected override string ToXmlString()
    {
      DateTime universalTime = this.Value;
      universalTime = universalTime.ToUniversalTime();
      return universalTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffffZ");
    }

    public override void ReadBinary(PListBinaryReader reader)
    {
      byte[] buffer = new byte[1 << reader.CurrentElementLength];
      if (reader.BaseStream.Read(buffer, 0, buffer.Length) != buffer.Length)
        throw new PListFormatException();
      double single;
      switch (reader.CurrentElementLength)
      {
        case 0:
          throw new PListFormatException("Date < 32Bit");
        case 1:
          throw new PListFormatException("Date < 32Bit");
        case 2:
          single = (double) BitConverter.ToSingle(((IEnumerable<byte>) buffer).Reverse<byte>().ToArray<byte>(), 0);
          break;
        case 3:
          single = BitConverter.ToDouble(((IEnumerable<byte>) buffer).Reverse<byte>().ToArray<byte>(), 0);
          break;
        default:
          throw new PListFormatException("Date > 64Bit");
      }
      this.Value = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(single);
    }

    public override int GetPListElementLength()
    {
      return 3;
    }

    public override void WriteBinary(PListBinaryWriter writer)
    {
      byte[] array = ((IEnumerable<byte>) BitConverter.GetBytes((this.Value - new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)).Reverse<byte>().ToArray<byte>();
      writer.BaseStream.Write(array, 0, array.Length);
    }
  }
}
