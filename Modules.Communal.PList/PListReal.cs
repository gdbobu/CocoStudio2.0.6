// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListReal
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
  public class PListReal : PListElement<double>
  {
    public override string Tag
    {
      get
      {
        return "real";
      }
    }

    public override byte TypeCode
    {
      get
      {
        return 2;
      }
    }

    public override double Value { get; set; }

    public PListReal()
    {
    }

    public PListReal(double value)
    {
      this.Value = value;
    }

    protected override void Parse(string value)
    {
      this.Value = double.Parse(value, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    protected override string ToXmlString()
    {
      return this.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }

    public override void ReadBinary(PListBinaryReader reader)
    {
      byte[] buffer = new byte[1 << reader.CurrentElementLength];
      if (reader.BaseStream.Read(buffer, 0, buffer.Length) != buffer.Length)
        throw new PListFormatException();
      switch (reader.CurrentElementLength)
      {
        case 0:
          throw new PListFormatException("Real < 32Bit");
        case 1:
          throw new PListFormatException("Real < 32Bit");
        case 2:
          this.Value = (double) BitConverter.ToSingle(((IEnumerable<byte>) buffer).Reverse<byte>().ToArray<byte>(), 0);
          break;
        case 3:
          this.Value = BitConverter.ToDouble(((IEnumerable<byte>) buffer).Reverse<byte>().ToArray<byte>(), 0);
          break;
        default:
          throw new PListFormatException("Real > 64Bit");
      }
    }

    public override int GetPListElementLength()
    {
      return 3;
    }

    public override void WriteBinary(PListBinaryWriter writer)
    {
      byte[] array = ((IEnumerable<byte>) BitConverter.GetBytes(this.Value)).Reverse<byte>().ToArray<byte>();
      writer.BaseStream.Write(array, 0, array.Length);
    }
  }
}
