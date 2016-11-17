// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ModelExtensionNode
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Mono.Addins;
using System;

namespace CocoStudio.Model
{
  public class ModelExtensionNode : TypeExtensionNode<ModelExtensionAttribute>, IComparable<ModelExtensionNode>
  {
    public int CompareTo(ModelExtensionNode other)
    {
      if (this.Data.IsDefault && !other.Data.IsDefault)
        return -1;
      if (!this.Data.IsDefault && other.Data.IsDefault)
        return 1;
      return this.Data.Order.CompareTo(other.Data.Order);
    }
  }
}
