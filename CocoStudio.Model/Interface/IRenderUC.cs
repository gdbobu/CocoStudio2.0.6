// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Interface.IRenderUC
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;

namespace CocoStudio.Model.Interface
{
  public interface IRenderUC
  {
    VisualObject RootVisualObject { get; set; }

    GameWindow GameWindow { get; }

    IInputDispatch InputDispatch { get; }

    bool ShowAnimationModeTip { get; set; }

    CanvasObject GetCanvasGameObject();

    SceneObject GetSceneGameObject();

    PointF ConvertControlToScene(PointF screenPoint);

    PointF ConvertSceneToControl(PointF scenePoint);

    PointF ConvertScreenToScene(PointF screenPoint);

    VisualObject GetHitVisualObject(PointF scenePoint);

    void MoveCanvasToCenter();
  }
}
