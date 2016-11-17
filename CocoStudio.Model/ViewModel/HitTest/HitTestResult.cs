// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.HitTest.HitTestResult
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;

namespace CocoStudio.Model.ViewModel.HitTest
{
  public class HitTestResult : BaseTestResult, IComparable
  {
    public OperationType OperationType { get; set; }

    public ControlPointType ControlPointType { get; set; }

    public PointF HitPoint { get; private set; }

    public float Rotate { get; private set; }

    public HitTestResult(PointF hitPoint, bool isContinueTest)
      : this((VisualObject) null, hitPoint, OperationType.OPERATION_NONE, ControlPointType.POINT_NONE, isContinueTest)
    {
    }

    public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType)
      : this(hitVisual, hitPoint, operationType, controlPointType, hitVisual != null && hitVisual.Visible)
    {
    }

    public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType, float rotate)
      : this(hitVisual, hitPoint, operationType, controlPointType, hitVisual != null && hitVisual.Visible)
    {
      this.Rotate = rotate;
    }

    public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType, bool isContinueTest)
      : base(hitVisual, isContinueTest)
    {
      this.HitPoint = hitPoint;
      this.OperationType = operationType;
      this.ControlPointType = controlPointType;
    }
  }
}
