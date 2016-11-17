// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.FusePropertyChangeAttribute
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public abstract class FusePropertyChangeAttribute : Attribute
  {
    public Func<object, object, object, bool> CanFuse
    {
      get
      {
        return new Func<object, object, object, bool>(this.FuseFunction);
      }
    }

    protected abstract bool FuseFunction(object originalValue, object firstChange, object seccondChange);
  }
}
