// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ModelExtensionAttribute
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Mono.Addins;
using System;

namespace CocoStudio.Model
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public sealed class ModelExtensionAttribute : CustomExtensionAttribute
  {
    [NodeAttribute]
    public int Order { get; private set; }

    [NodeAttribute]
    public bool IsDefault { get; private set; }

    public ModelExtensionAttribute()
    {
    }

    public ModelExtensionAttribute([NodeAttribute("Order")] int order)
      : this(false, order)
    {
    }

    internal ModelExtensionAttribute([NodeAttribute("IsDefault")] bool isDefault, [NodeAttribute("Order")] int order)
    {
      this.Order = order;
      this.IsDefault = isDefault;
    }
  }
}
