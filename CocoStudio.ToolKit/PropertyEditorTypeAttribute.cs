// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyEditorTypeAttribute
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class PropertyEditorTypeAttribute : Attribute
  {
    private bool inherits = false;
    private Type type;

    public bool Inherits
    {
      get
      {
        return this.inherits;
      }
    }

    public Type Type
    {
      get
      {
        return this.type;
      }
    }

    public PropertyEditorTypeAttribute(Type type)
    {
      this.type = type;
    }

    public PropertyEditorTypeAttribute(Type myType, bool inherits)
    {
      this.type = myType;
      this.inherits = inherits;
    }
  }
}
