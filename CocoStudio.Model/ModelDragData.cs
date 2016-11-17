// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ModelDragData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;

namespace CocoStudio.Model
{
  [Serializable]
  public class ModelDragData
  {
    public ModelMetaData MetaData { get; private set; }

    public ModelDragData(ModelMetaData MetaData)
    {
      this.MetaData = MetaData;
    }
  }
}
