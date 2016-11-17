// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ModelMetaData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using System;
using System.ComponentModel;

namespace CocoStudio.Model
{
  public class ModelMetaData
  {
    private ModelExtensionNode extensionNode;

    public string DisplayName { get; private set; }

    internal bool IsDefault
    {
      get
      {
        return this.extensionNode.Data.IsDefault;
      }
    }

    public Type Type
    {
      get
      {
        return this.extensionNode.Type;
      }
    }

    internal ModelMetaData(ModelExtensionNode extensionNode)
    {
      this.extensionNode = extensionNode;
      Type type = extensionNode.Type;
      DisplayNameAttribute[] customAttributes = type.GetCustomAttributes(typeof (DisplayNameAttribute), true) as DisplayNameAttribute[];
      if (customAttributes.Length > 0)
        this.DisplayName = customAttributes[0].DisplayName;
      else
        this.DisplayName = type.Name;
    }

    public NodeObject CreateObject()
    {
      return this.extensionNode.CreateInstance() as NodeObject;
    }
  }
}
