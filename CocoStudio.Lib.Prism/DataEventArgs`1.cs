// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.DataEventArgs`1
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;

namespace CocoStudio.Lib.Prism
{
  public class DataEventArgs<TData> : EventArgs
  {
    private readonly TData _value;

    public TData Value
    {
      get
      {
        return this._value;
      }
    }

    public DataEventArgs(TData value)
    {
      this._value = value;
    }
  }
}
