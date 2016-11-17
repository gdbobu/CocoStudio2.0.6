// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.SceneTransformHelp
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Interface;

namespace CocoStudio.Model
{
  public class SceneTransformHelp
  {
    public static IRenderUC RenderUC { get; private set; }

    public static PointF ConvertControlToScene(PointF screenPoint)
    {
      return SceneTransformHelp.RenderUC.ConvertControlToScene(screenPoint);
    }

    public static PointF ConvertSceneToControl(PointF sencePoint)
    {
      return SceneTransformHelp.RenderUC.ConvertSceneToControl(sencePoint);
    }

    public static PointF ConvertScreenToScene(PointF screenPoint)
    {
      return SceneTransformHelp.RenderUC.ConvertScreenToScene(screenPoint);
    }

    public static void SetRenderUC(IRenderUC renderUC)
    {
      SceneTransformHelp.RenderUC = renderUC;
    }
  }
}
