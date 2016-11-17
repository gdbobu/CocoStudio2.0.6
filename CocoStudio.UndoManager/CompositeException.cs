// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.CompositeException
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;
using System.Collections.Generic;

namespace CocoStudio.UndoManager
{
  [Serializable]
  public class CompositeException : Exception
  {
    public IEnumerable<Exception> Exceptions { get; private set; }

    public CompositeException(string message, IEnumerable<Exception> exceptions)
      : base(message)
    {
      this.Exceptions = exceptions;
    }
  }
}
