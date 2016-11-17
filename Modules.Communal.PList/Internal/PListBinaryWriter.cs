// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.Internal.PListBinaryWriter
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Modules.Communal.PList.Internal
{
  public class PListBinaryWriter
  {
    private static readonly byte[] s_PListHeader = new byte[8]{ (byte) 98, (byte) 112, (byte) 108, (byte) 105, (byte) 115, (byte) 116, (byte) 48, (byte) 48 };
    private Dictionary<byte, Dictionary<IPListElement, int>> m_UniqueElements = new Dictionary<byte, Dictionary<IPListElement, int>>();

    internal Stream BaseStream { get; private set; }

    internal byte ElementIdxSize { get; private set; }

    internal List<int> Offsets { get; private set; }

    internal PListBinaryWriter()
    {
    }

    public void Write(Stream stream, IPListElement element)
    {
      this.BaseStream = stream;
      this.Offsets = new List<int>();
      this.BaseStream.Write(PListBinaryWriter.s_PListHeader, 0, PListBinaryWriter.s_PListHeader.Length);
      int plistElementCount = element.GetPListElementCount();
      this.ElementIdxSize = plistElementCount > (int) byte.MaxValue ? (plistElementCount > (int) short.MaxValue ? (byte) 4 : (byte) 2) : (byte) 1;
      int host = this.WriteInternal(element);
      int count = this.Offsets.Count;
      int position = (int) this.BaseStream.Position;
      byte num = position > (int) byte.MaxValue ? (position > (int) short.MaxValue ? (byte) 4 : (byte) 2) : (byte) 1;
      for (int index = 0; index < this.Offsets.Count; ++index)
      {
        byte[] buffer = (byte[]) null;
        switch (num)
        {
          case 1:
            buffer = new byte[1]
            {
              (byte) this.Offsets[index]
            };
            break;
          case 2:
            buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) this.Offsets[index]));
            break;
          case 4:
            buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(this.Offsets[index]));
            break;
        }
        this.BaseStream.Write(buffer, 0, buffer.Length);
      }
      byte[] buffer1 = new byte[32];
      buffer1[6] = num;
      buffer1[7] = this.ElementIdxSize;
      BitConverter.GetBytes(IPAddress.HostToNetworkOrder(count)).CopyTo((Array) buffer1, 12);
      BitConverter.GetBytes(IPAddress.HostToNetworkOrder(host)).CopyTo((Array) buffer1, 20);
      BitConverter.GetBytes(IPAddress.HostToNetworkOrder(position)).CopyTo((Array) buffer1, 28);
      this.BaseStream.Write(buffer1, 0, buffer1.Length);
    }

    internal byte[] FormatIdx(int idx)
    {
      byte[] numArray;
      switch (this.ElementIdxSize)
      {
        case 1:
          numArray = new byte[1]{ (byte) idx };
          break;
        case 2:
          numArray = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) idx));
          break;
        case 4:
          numArray = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(idx));
          break;
        default:
          throw new PListFormatException("Invalid ElementIdxSize");
      }
      return numArray;
    }

    internal int WriteInternal(IPListElement element)
    {
      int count = this.Offsets.Count;
      if (element.IsBinaryUnique && element is IEquatable<IPListElement>)
      {
        if (!this.m_UniqueElements.ContainsKey(element.TypeCode))
          this.m_UniqueElements.Add(element.TypeCode, new Dictionary<IPListElement, int>());
        if (!this.m_UniqueElements[element.TypeCode].ContainsKey(element))
        {
          this.m_UniqueElements[element.TypeCode][element] = count;
        }
        else
        {
          if (!(element is PListBool))
            return this.m_UniqueElements[element.TypeCode][element];
          count = this.m_UniqueElements[element.TypeCode][element];
        }
      }
      this.Offsets.Add((int) this.BaseStream.Position);
      int plistElementLength = element.GetPListElementLength();
      this.BaseStream.WriteByte((byte) ((int) element.TypeCode << 4 | (plistElementLength < 15 ? plistElementLength : 15)));
      if (plistElementLength >= 15)
      {
        IPListElement lengthElement = PListElementFactory.Instance.CreateLengthElement(plistElementLength);
        this.BaseStream.WriteByte((byte) ((int) lengthElement.TypeCode << 4 | lengthElement.GetPListElementLength()));
        lengthElement.WriteBinary(this);
      }
      element.WriteBinary(this);
      return count;
    }
  }
}
