// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ITransform
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

namespace CocoStudio.Model
{
  public interface ITransform
  {
    bool IsTransformEnabled { get; set; }

    PointF Position { get; set; }

    PointF RelativePosition { get; set; }

    ScaleValue Scale { get; set; }

    bool UniformScale { get; set; }

    float Rotation { get; set; }

    ScaleValue RotationSkew { get; set; }

    ScaleValue AnchorPoint { get; set; }

    PointF Size { get; set; }
  }
}
