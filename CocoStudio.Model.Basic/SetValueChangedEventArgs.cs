// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.SetValueChangedEventArgs
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

using System;

namespace CocoStudio.Model
{
  public class SetValueChangedEventArgs : EventArgs
  {
    public object Value { get; set; }

    public string MethodName { get; private set; }

    public SetValueChangedEventArgs(string methodName, object value)
    {
      this.MethodName = methodName;
      this.Value = value;
    }
  }
}
