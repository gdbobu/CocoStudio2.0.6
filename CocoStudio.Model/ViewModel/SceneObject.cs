// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.SceneObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class SceneObject : VisualObject
  {
    private CSScene csSceneEntity;

    internal SceneObject(CSScene entity)
    {
      this.csSceneEntity = entity;
    }

    internal override CSVisualObject GetCSVisual()
    {
      return (CSVisualObject) this.csSceneEntity;
    }

    public void AddChild(NodeObject cObject)
    {
      this.GetCSVisual().AddChild(cObject.GetCSVisual());
    }
  }
}
