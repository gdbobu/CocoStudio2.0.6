using System;

namespace CocoStudio.Model.ViewModel.HitTest
{
	public class HitTestResult : BaseTestResult, IComparable
	{
		public OperationType OperationType
		{
			get;
			set;
		}

		public ControlPointType ControlPointType
		{
			get;
			set;
		}

		public PointF HitPoint
		{
			get;
			private set;
		}

		public float Rotate
		{
			get;
			private set;
		}

		public HitTestResult(PointF hitPoint, bool isContinueTest) : this(null, hitPoint, OperationType.OPERATION_NONE, ControlPointType.POINT_NONE, isContinueTest)
		{
		}

		public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType) : this(hitVisual, hitPoint, operationType, controlPointType, hitVisual != null && hitVisual.Visible)
		{
		}

		public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType, float rotate) : this(hitVisual, hitPoint, operationType, controlPointType, hitVisual != null && hitVisual.Visible)
		{
			this.Rotate = rotate;
		}

		public HitTestResult(VisualObject hitVisual, PointF hitPoint, OperationType operationType, ControlPointType controlPointType, bool isContinueTest) : base(hitVisual, isContinueTest)
		{
			this.HitPoint = hitPoint;
			this.OperationType = operationType;
			this.ControlPointType = controlPointType;
		}
	}
}
