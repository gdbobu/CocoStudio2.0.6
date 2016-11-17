// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.DataModelExtensionNode
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;

namespace CocoStudio.Projects
{
  internal class DataModelExtensionNode : TypeExtensionNode<DataModelExtensionAttribute>
  {
    public new DataModelExtensionAttribute Data { get; private set; }

    protected override void Read(NodeElement elem)
    {
      base.Read(elem);
      object[] customAttributes = this.Type.GetCustomAttributes(typeof (DataModelExtensionAttribute), false);
      if (customAttributes.Length > 0)
        this.Data = customAttributes[0] as DataModelExtensionAttribute;
      else
        this.Data = base.Data;
    }
  }
}
