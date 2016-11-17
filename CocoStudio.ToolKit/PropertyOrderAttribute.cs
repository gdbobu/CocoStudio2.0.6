// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyOrderAttribute
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public sealed class PropertyOrderAttribute : Attribute
  {
    public int Order { get; set; }

    public PropertyOrderAttribute(int order)
    {
      this.Order = order;
    }
  }
}
