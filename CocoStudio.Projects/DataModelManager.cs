// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.DataModelManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  public class DataModelManager
  {
    private HashSet<Type> dataModelList;
    private Dictionary<Type, Type> viewToDataCollection;
    private Dictionary<Type, Type> dataToViewCollection;

    public DataModelManager()
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.dataModelList = new HashSet<Type>();
      this.viewToDataCollection = new Dictionary<Type, Type>();
      this.dataToViewCollection = new Dictionary<Type, Type>();
      foreach (DataModelExtensionNode extensionNode in AddinManager.GetExtensionNodes<DataModelExtensionNode>(typeof (IDataModel)))
        this.RegisteDataModel(extensionNode);
      AddinManager.AddExtensionNodeHandler(typeof (IDataModel), new ExtensionNodeEventHandler(this.OnDataModelExtensionChange));
    }

    private void OnDataModelExtensionChange(object sender, ExtensionNodeEventArgs args)
    {
      this.RegisteDataModel(args.ExtensionNode as DataModelExtensionNode);
    }

    private void RegisteDataModel(DataModelExtensionNode extensionNode)
    {
      if (extensionNode == null || this.dataModelList.Contains(extensionNode.Type))
        return;
      this.dataModelList.Add(extensionNode.Type);
      if (!(extensionNode.Data.ModelType != (Type) null))
        return;
      this.viewToDataCollection.Add(extensionNode.Data.ModelType, extensionNode.Type);
      this.dataToViewCollection.Add(extensionNode.Type, extensionNode.Data.ModelType);
    }

    public HashSet<Type> GetDataModelCollection()
    {
      return this.dataModelList;
    }

    public Type GetDataModelType(Type viewModelType)
    {
      Type type;
      this.viewToDataCollection.TryGetValue(viewModelType, out type);
      return type;
    }

    public Type GetViewModelType(Type dataModelType)
    {
      Type type;
      this.dataToViewCollection.TryGetValue(dataModelType, out type);
      return type;
    }
  }
}
