// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.CatagoryAttribute
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;

namespace CocoStudio.ToolKit
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
  public class CatagoryAttribute : Attribute
  {
    public string Catatory { get; set; }

    public int Order { get; set; }

    public int Group { get; set; }

    public CatagoryAttribute(string catagroy, int order, int group = 0)
    {
      this.Catatory = catagroy;
      this.Order = order;
      this.Group = group;
    }
  }
}
