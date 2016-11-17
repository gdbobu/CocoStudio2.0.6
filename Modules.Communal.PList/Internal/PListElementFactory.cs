// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.Internal.PListElementFactory
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using System;
using System.Collections.Generic;

namespace Modules.Communal.PList.Internal
{
  internal class PListElementFactory
  {
    private Dictionary<string, Type> m_PListElementTags = new Dictionary<string, Type>();
    private Dictionary<byte, Type> m_PListElementTypeCodes = new Dictionary<byte, Type>();
    private static PListElementFactory s_Instance;

    public static PListElementFactory Instance
    {
      get
      {
        if (PListElementFactory.s_Instance == null)
          PListElementFactory.s_Instance = new PListElementFactory();
        return PListElementFactory.s_Instance;
      }
    }

    private PListElementFactory()
    {
      this.Register<PListDict>(new PListDict());
      this.Register<PListInteger>(new PListInteger());
      this.Register<PListReal>(new PListReal());
      this.Register<PListString>(new PListString());
      this.Register<PListArray>(new PListArray());
      this.Register<PListData>(new PListData());
      this.Register<PListDate>(new PListDate());
      this.Register<PListString>("string", (byte) 5, new PListString());
      this.Register<PListString>("ustring", (byte) 6, new PListString());
      this.Register<PListBool>("true", (byte) 0, new PListBool());
      this.Register<PListBool>("false", (byte) 0, new PListBool());
    }

    private void Register<T>(T element) where T : IPListElement, new()
    {
      if (!this.m_PListElementTags.ContainsKey(element.Tag))
        this.m_PListElementTags.Add(element.Tag, element.GetType());
      if (this.m_PListElementTypeCodes.ContainsKey(element.TypeCode))
        return;
      this.m_PListElementTypeCodes.Add(element.TypeCode, element.GetType());
    }

    private void Register<T>(string tag, byte typeCode, T element) where T : IPListElement, new()
    {
      if (!this.m_PListElementTags.ContainsKey(tag))
        this.m_PListElementTags.Add(tag, element.GetType());
      if (this.m_PListElementTypeCodes.ContainsKey(typeCode))
        return;
      this.m_PListElementTypeCodes.Add(typeCode, element.GetType());
    }

    public IPListElement Create(byte typeCode, int length)
    {
      if ((int) typeCode == 0 && length == 0)
        return (IPListElement) new PListNull();
      if ((int) typeCode == 0 && length == 15)
        return (IPListElement) new PListFill();
      if (this.m_PListElementTypeCodes.ContainsKey(typeCode))
        return (IPListElement) Activator.CreateInstance(this.m_PListElementTypeCodes[typeCode]);
      throw new PListFormatException(string.Format("Unknown PList - TypeCode ({0})", (object) typeCode));
    }

    public IPListElement Create(string tag)
    {
      if (this.m_PListElementTags.ContainsKey(tag))
        return (IPListElement) Activator.CreateInstance(this.m_PListElementTags[tag]);
      throw new PListFormatException(string.Format("Unknown PList - Tag ({0})", (object) tag));
    }

    public IPListElement CreateLengthElement(int length)
    {
      return (IPListElement) new PListInteger((long) length);
    }

    public IPListElement CreateKeyElement(string key)
    {
      return (IPListElement) new PListString(key);
    }
  }
}
