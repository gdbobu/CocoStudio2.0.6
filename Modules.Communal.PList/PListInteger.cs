// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListInteger
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System;
using System.Globalization;
using System.Net;

namespace Modules.Communal.PList
{
  public class PListInteger : PListElement<long>
  {
    public override string Tag
    {
      get
      {
        return "integer";
      }
    }

    public override byte TypeCode
    {
      get
      {
        return 1;
      }
    }

    public override long Value { get; set; }

    public PListInteger()
    {
    }

    public PListInteger(long value)
    {
      this.Value = value;
    }

    protected override void Parse(string value)
    {
      this.Value = long.Parse(value, (IFormatProvider) CultureInfo.InvariantCulture);
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
          this.Value = (long) buffer[0];
          break;
        case 1:
          this.Value = (long) IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 0));
          break;
        case 2:
          this.Value = (long) IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, 0));
          break;
        case 3:
          this.Value = IPAddress.NetworkToHostOrder(BitConverter.ToInt64(buffer, 0));
          break;
        default:
          throw new PListFormatException("Int > 64Bit");
      }
    }

    public override int GetPListElementLength()
    {
      if (this.Value >= 0L && this.Value <= (long) byte.MaxValue)
        return 0;
      if (this.Value >= (long) short.MinValue && this.Value <= (long) short.MaxValue)
        return 1;
      if (this.Value >= (long) int.MinValue && this.Value <= (long) int.MaxValue)
        return 2;
      return this.Value >= long.MinValue && this.Value <= long.MaxValue ? 3 : -1;
    }

    public override void WriteBinary(PListBinaryWriter writer)
    {
      int plistElementLength = this.GetPListElementLength();
      byte[] buffer = (byte[]) null;
      switch (plistElementLength)
      {
        case 0:
          buffer = new byte[1]
          {
            (byte) this.Value
          };
          break;
        case 1:
          buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) this.Value));
          break;
        case 2:
          buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int) this.Value));
          break;
        case 3:
          buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(this.Value));
          break;
      }
      writer.BaseStream.Write(buffer, 0, buffer.Length);
    }
  }
}
