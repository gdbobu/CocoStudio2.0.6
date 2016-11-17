// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.Internal.PListBinaryReader
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using System;
using System.IO;
using System.Net;

namespace Modules.Communal.PList.Internal
{
  public class PListBinaryReader
  {
    private int[] m_Offsets;

    internal Stream BaseStream { get; private set; }

    internal byte ElementIdxSize { get; private set; }

    internal byte CurrentElementTypeCode { get; private set; }

    internal int CurrentElementLength { get; private set; }

    internal PListBinaryReader()
    {
    }

    public IPListElement Read(Stream stream)
    {
      this.BaseStream = stream;
      byte[] buffer1 = new byte[32];
      this.BaseStream.Seek(-32L, SeekOrigin.End);
      if (this.BaseStream.Read(buffer1, 0, buffer1.Length) != buffer1.Length)
        throw new PListFormatException("Invalid Header Size");
      byte num = buffer1[6];
      this.ElementIdxSize = buffer1[7];
      int hostOrder1 = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer1, 12));
      int hostOrder2 = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer1, 20));
      int hostOrder3 = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer1, 28));
      byte[] buffer2 = new byte[hostOrder1 * (int) num];
      this.BaseStream.Seek((long) hostOrder3, SeekOrigin.Begin);
      if (this.BaseStream.Read(buffer2, 0, buffer2.Length) != buffer2.Length)
        throw new PListFormatException("Invalid offsetTable Size");
      this.m_Offsets = new int[hostOrder1];
      for (int index1 = 0; index1 < this.m_Offsets.Length; ++index1)
      {
        byte[] numArray = new byte[4];
        for (int index2 = 0; index2 < (int) num; ++index2)
          numArray[(int) num - 1 - index2] = buffer2[index1 * (int) num + index2];
        this.m_Offsets[index1] = BitConverter.ToInt32(numArray, 0);
      }
      return this.ReadInternal(hostOrder2);
    }

    internal IPListElement ReadInternal(int elemIdx)
    {
      this.BaseStream.Seek((long) this.m_Offsets[elemIdx], SeekOrigin.Begin);
      return this.ReadInternal();
    }

    internal IPListElement ReadInternal()
    {
      byte[] buffer = new byte[1];
      if (this.BaseStream.Read(buffer, 0, buffer.Length) != 1)
        throw new PListFormatException("Didn't read type Byte");
      int length = (int) buffer[0] & 15;
      byte typeCode = (byte) ((int) buffer[0] >> 4 & 15);
      if ((int) typeCode != 0 && length == 15)
      {
        IPListElement plistElement = this.ReadInternal();
        if (!(plistElement is PListInteger))
          throw new PListFormatException("Element Len is no Integer");
        length = (int) ((PListElement<long>) plistElement).Value;
      }
      IPListElement plistElement1 = PListElementFactory.Instance.Create(typeCode, length);
      byte currentElementTypeCode = this.CurrentElementTypeCode;
      int currentElementLength = this.CurrentElementLength;
      this.CurrentElementTypeCode = typeCode;
      this.CurrentElementLength = length;
      plistElement1.ReadBinary(this);
      this.CurrentElementTypeCode = currentElementTypeCode;
      this.CurrentElementLength = currentElementLength;
      return plistElement1;
    }
  }
}
