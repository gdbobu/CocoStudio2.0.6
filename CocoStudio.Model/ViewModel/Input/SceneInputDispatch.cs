// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Input.SceneInputDispatch
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;

namespace CocoStudio.Model.ViewModel.Input
{
  internal class SceneInputDispatch : BaseInputDispatch
  {
    public SceneInputDispatch(IUndoManager undoManager, IRenderUC renderUC)
      : base(undoManager, renderUC)
    {
    }
  }
}
