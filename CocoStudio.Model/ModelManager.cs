// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ModelManager
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using Mono.Addins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Model
{
  public class ModelManager
  {
    public IEnumerable<ModelMetaData> ModelCollection { get; private set; }

    public static ModelManager Instance { get; private set; }

    static ModelManager()
    {
      ModelManager.Instance = new ModelManager();
    }

    private ModelManager()
    {
      this.LoadModelType();
    }

    private void LoadModelType()
    {
      try
      {
        List<ModelExtensionNode> list = AddinManager.GetExtensionNodes<ModelExtensionNode>(typeof (IModel)).ToList<ModelExtensionNode>();
        list.Sort();
        List<ModelMetaData> modelMetaDataList = new List<ModelMetaData>();
        foreach (ModelExtensionNode extensionNode in list)
        {
          if (extensionNode.Type.IsSubclassOf(typeof (NodeObject)))
          {
            ModelMetaData modelMetaData = new ModelMetaData(extensionNode);
            modelMetaDataList.Add(modelMetaData);
          }
        }
        this.ModelCollection = (IEnumerable<ModelMetaData>) modelMetaDataList;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Load model type failed.", ex);
      }
    }
  }
}
