// Decompiled with JetBrains decompiler
// Type: Modules.Communal.PList.PListException
// Assembly: Modules.Communal.PList, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED29F11D-8EB7-4ED4-AF26-9B32144417DB
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.PList.dll

using System;
using System.Runtime.Serialization;

namespace Modules.Communal.PList
{
  [Serializable]
  public class PListException : Exception
  {
    public PListException()
    {
    }

    public PListException(string message)
      : base(message)
    {
    }

    public PListException(string message, Exception inner)
      : base(message, inner)
    {
    }

    protected PListException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
