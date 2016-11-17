// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.IPListElement
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using Modules.Communal.PList.Internal;
using System.Xml.Serialization;

namespace Modules.Communal.PList
{
  public interface IPListElement : IXmlSerializable
  {
    string Tag { get; }

    byte TypeCode { get; }

    bool IsBinaryUnique { get; }

    int GetPListElementLength();

    int GetPListElementCount();

    void WriteBinary(PListBinaryWriter writer);

    void ReadBinary(PListBinaryReader reader);
  }
}
