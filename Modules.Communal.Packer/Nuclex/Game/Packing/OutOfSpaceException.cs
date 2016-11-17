// Decompiled with JetBrains decompiler
// Type: Nuclex.Game.Packing.OutOfSpaceException
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System;
using System.Runtime.Serialization;

namespace Nuclex.Game.Packing
{
  [Serializable]
  public class OutOfSpaceException : Exception
  {
    public OutOfSpaceException()
    {
    }

    public OutOfSpaceException(string message)
      : base(message)
    {
    }

    public OutOfSpaceException(string message, Exception inner)
      : base(message, inner)
    {
    }

    protected OutOfSpaceException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
