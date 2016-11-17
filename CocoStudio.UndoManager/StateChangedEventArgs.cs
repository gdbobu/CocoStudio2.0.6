// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.StateChangedEventArgs
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager
{
  public class StateChangedEventArgs : EventArgs
  {
    public string PropertyName { get; private set; }

    public object OldValue { get; private set; }

    public object NewValue { get; private set; }

    public bool IsProvideValue { get; private set; }

    public StateChangedEventArgs(string propertyName)
    {
      this.PropertyName = propertyName;
    }

    public StateChangedEventArgs(string propertyName, object oldValue, object newValue)
    {
      this.PropertyName = propertyName;
      this.OldValue = oldValue;
      this.NewValue = newValue;
      this.IsProvideValue = true;
    }
  }
}
