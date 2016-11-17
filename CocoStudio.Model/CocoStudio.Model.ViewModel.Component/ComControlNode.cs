using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Core.Events;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Event;
using CocoStudio.Model.ViewModel.HitTest;
using Gdk;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.Model.ViewModel.Component
{
	public class ComControlNode : NodeObject, IDisposable
	{
		private IEnumerable<VisualObject> selectedObjects;

		private IEnumerable<VisualObject> selectedParentObjects;

		private SelectInfo selectInfo = new SelectInfo(new List<VisualObject>(), new List<VisualObject>());

		private VisualObject canvasObject;

		private PointF lastMousePoint;

		private bool isShiftDown = false;

		private bool isMouseMoved = false;

		private bool isMouseDown = false;

		private bool isScaleLocked = false;

		private MoveDirection moveDirection = MoveDirection.NONE;

		private float lastRotation = 0f;

		private OperationType operationType;

		private ControlPointType controlPointType;

		private bool rotationChanged = false;

		private bool scaleChanged = false;

		private bool positionChanged = false;

		private PointF vector = null;

		private bool updateLastMousePoint = true;

		public IEnumerable<VisualObject> SelectedObjects
		{
			get
			{
				return this.selectedObjects;
			}
			set
			{
				this.selectedObjects = value;
				if (this.selectedObjects == null || this.selectedObjects.Count<VisualObject>() == 0)
				{
					this.Enabled = false;
				}
				else
				{
					this.Enabled = true;
				}
				this.RefreshOperation();
			}
		}

		public IEnumerable<VisualObject> SelectedParentObjects
		{
			get
			{
				return this.selectedParentObjects;
			}
			set
			{
				this.selectedParentObjects = value;
			}
		}

		public SelectInfo SelectInfo
		{
			get
			{
				return this.selectInfo;
			}
			set
			{
				this.selectInfo = value;
				if (Services.TaskService.IsUndoing && this.SelectedObjects != null)
				{
					foreach (VisualObject current in this.SelectedObjects)
					{
						current.IsSelected = false;
					}
				}
				if (this.SelectedObjects != null && this.SelectedObjects.Count<VisualObject>() > 0 && this.isMouseDown)
				{
					foreach (VisualObject current2 in this.SelectedObjects)
					{
						if (!current2.Recorder.IsAutoRecord)
						{
							current2.Recorder.Start(true, false);
						}
						else
						{
							LogConfig.Logger.Error("don't try to start a auto record object's record");
						}
					}
				}
				if (this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() > 0)
				{
					this.selectedObjects.ElementAt(0).PropertyChanged -= new PropertyChangedEventHandler(this.ComControlNode_PropertyChanged);
				}
				this.SelectedObjects = this.selectInfo.SelectedObjects;
				this.SelectedParentObjects = this.selectInfo.SelectedParentObjects;
				if (this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() > 0)
				{
					this.selectedObjects.ElementAt(0).PropertyChanged += new PropertyChangedEventHandler(this.ComControlNode_PropertyChanged);
				}
				if (this.SelectedObjects != null && this.SelectedObjects.Count<VisualObject>() > 0)
				{
					if (this.SelectedObjects.Count<VisualObject>() == 1)
					{
						this.CSCom.SetAttachNode(this.SelectedObjects.FirstOrDefault<VisualObject>().GetCSVisual() as CSNode);
					}
					else
					{
						this.CSCom.SetAttachNode(new CSNode(IntPtr.Zero, true));
					}
				}
			}
		}

		private CSComControlNode CSCom
		{
			get
			{
				return base.GetCSVisual() as CSComControlNode;
			}
		}

		public bool Enabled
		{
			get
			{
				return this.CSCom.IsEnable();
			}
			private set
			{
				this.CSCom.SetEnable(value);
			}
		}

		public CSMatrix OriginMat
		{
			get
			{
				return this.CSCom.GetOriginMat();
			}
			set
			{
				this.CSCom.SetOriginMat(value);
			}
		}

		public override PointF PrePosition
		{
			get
			{
				return base.PrePosition;
			}
			set
			{
			}
		}

		internal OperationType OperationType
		{
			get
			{
				return this.operationType;
			}
		}

		private void RefreshOperation()
		{
			this.OperationFlag &= ~OperationMask.MoveFlag;
			foreach (VisualObject current in this.selectedObjects)
			{
				if (current.OperationFlag == OperationMask.NoneFlag)
				{
					OperationMask arg_40_0 = this.OperationFlag;
					this.OperationFlag = OperationMask.NoneFlag;
					break;
				}
				if (current.IsTransformEnabled)
				{
					this.OperationFlag |= OperationMask.MoveFlag;
					break;
				}
			}
		}

		public ComControlNode(CanvasObject canvasObject)
		{
			this.canvasObject = canvasObject;
			this.CSCom.SetCanvasObject(canvasObject.GetCSVisual());
			this.Visible = (this.VisibleForFrame = true);
			TimelineActionManager.Instance.CurrentFrameIndexChangedEvent += new CurrentFrameIndexChangedHandler(this.OnFrameIndexChanged);
			Services.Workbench.ActiveDocumentChanged += new EventHandler(this.DocumentChanged);
			Services.EventsService.GetEvent<AlignedObjectsEvent>().Subscribe(new Action<AlignedObjectsArgs>(this.OnAlignedObjects));
			Services.EventsService.GetEvent<ScaleLockedChangeEvent>().Subscribe(new Action<bool>(this.OnScaleLockedChange));
			Services.EventsService.GetEvent<CanvasSizeChangeEvent>().Subscribe(new Action<CanvasSizeChangeEventArgs>(this.OnCanvasSizeChange));
		}

		private void OnScaleLockedChange(bool locked)
		{
			this.isScaleLocked = locked;
		}

		private void OnCanvasSizeChange(CanvasSizeChangeEventArgs obj)
		{
			this.Init();
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSComControlNode();
			}
		}

		private void Init()
		{
			if (!this.isMouseMoved)
			{
				this.CSCom.Init();
				if (this.SelectedObjects == null || this.SelectedObjects.Count<VisualObject>() <= 0 || this.SelectedParentObjects.Count<VisualObject>() <= 0)
				{
					this.Enabled = false;
				}
				else
				{
					this.Enabled = true;
					this.InitBoundingBox();
				}
			}
		}

		private void InitBoundingBox()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			bool flag = true;
			foreach (VisualObject current in this.selectedObjects)
			{
				VisualObject visualObject = current;
				PointF boundingSize = visualObject.GetBoundingSize();
				Rectangle rect = new Rectangle(0, 0, (int)boundingSize.X, (int)boundingSize.Y);
				CSRect cSRect = this.CSCom.RectApplyTransform(rect, visualObject.GetCSVisual().ConvertToNodeMatrix(this.canvasObject.GetCSVisual()));
				if (flag)
				{
					num = cSRect.MinX();
					num2 = cSRect.MinY();
					num3 = cSRect.MaxX();
					num4 = cSRect.MaxY();
					flag = false;
				}
				else
				{
					num = Math.Min(num, cSRect.MinX());
					num2 = Math.Min(num2, cSRect.MinY());
					num3 = Math.Max(num3, cSRect.MaxX());
					num4 = Math.Max(num4, cSRect.MaxY());
				}
			}
			this.InitMatrix(num, num2, num3, num4);
		}

		private void InitMatrix(float left, float bottom, float right, float top)
		{
			this.CSCom.SetAnchorPointVisiable(true);
			this.CSCom.SetControlPointVisiable(true);
			if (this.selectedObjects.Count<VisualObject>() == 1)
			{
				VisualObject visualObject = this.selectedParentObjects.FirstOrDefault<VisualObject>();
				this.AnchorPoint = visualObject.GetBoundingAnchorPoint();
				PointF boundingSize = visualObject.GetBoundingSize();
				this.Size = boundingSize;
				this.Position = visualObject.Position;
				this.Scale = visualObject.Scale;
				this.RotationSkew = visualObject.RotationSkew;
				if (!visualObject.OperationFlag.HasFlag(OperationMask.ScaleFlag) && !visualObject.OperationFlag.HasFlag(OperationMask.RotationFlag))
				{
					this.CSCom.SetControlPointVisiable(false);
				}
				this.CSCom.SetAnchorPointVisiable(visualObject.OperationFlag.HasFlag(OperationMask.AnchorMoveFlag));
			}
			else
			{
				this.AnchorPoint = new ScaleValue(0.5f, 0.5f, 0.1, -99999999.0, 99999999.0);
				this.Size = new PointF(right - left, top - bottom);
				this.RotationSkew = new ScaleValue(0f, 0f, 0.1, -99999999.0, 99999999.0);
				this.Scale = new ScaleValue(1f, 1f, 0.1, -99999999.0, 99999999.0);
				PointF anchorPointInPoints = this.CSCom.GetAnchorPointInPoints();
				this.Position = new PointF(left + anchorPointInPoints.X, bottom + anchorPointInPoints.Y);
			}
		}

		private void OnFrameIndexChanged()
		{
			if (!this.isMouseDown && !Services.TaskService.IsUndoing)
			{
				this.Init();
			}
		}

		private void DocumentChanged(object sender, EventArgs e)
		{
			this.Enabled = false;
		}

		public void SelectedObjectsChanged(IEnumerable<VisualObject> selectedObjectList, IEnumerable<VisualObject> selectedParentObjectList, bool isUnReDone = false)
		{
			if (this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() == selectedObjectList.Count<VisualObject>())
			{
				if (this.selectedObjects.Count<VisualObject>() == 0)
				{
					return;
				}
				bool flag = true;
				foreach (VisualObject current in this.selectedObjects)
				{
					if (!selectedObjectList.Contains(current))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					if (isUnReDone)
					{
						this.Init();
					}
					return;
				}
			}
			this.SelectInfo = new SelectInfo(selectedObjectList.ToList<VisualObject>(), selectedParentObjectList.ToList<VisualObject>());
			this.isScaleLocked = false;
			this.Init();
			this.operationType = OperationType.OPERATION_POSITION;
		}

		private void OnAlignedObjects(AlignedObjectsArgs obj)
		{
			this.Init();
		}

		private void ComControlNode_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (this.selectedObjects.Count<VisualObject>() != 0 && !(e.PropertyName == "IsSelected"))
			{
				if (e.PropertyName == "Parent")
				{
					this.RefreshOperation();
					this.Init();
				}
				else
				{
					this.Init();
				}
			}
		}

		public OperationType UpdateOperationType(PointF point)
		{
			this.operationType = (OperationType)this.CSCom.HitTest(point);
			this.controlPointType = (ControlPointType)this.CSCom.GetControlPointType();
			return this.operationType;
		}

		protected override void OnMouseDown(MouseEventArgsExtend args)
		{
			base.OnMouseDown(args);
			this.isMouseDown = true;
			this.isShiftDown = KeyboardExtend.IsModifyKeyDown(ModifierType.ShiftMask);
			this.moveDirection = MoveDirection.NONE;
			this.lastRotation = 0f;
			if (this.selectedObjects != null)
			{
				foreach (VisualObject current in this.SelectedObjects)
				{
					if (current.Recorder.IsAutoRecord)
					{
						current.Recorder.Stop(true);
					}
					else
					{
						LogConfig.Logger.Error("don't try to start a auto record object's record");
					}
				}
			}
			this.rotationChanged = false;
			this.scaleChanged = false;
			this.positionChanged = false;
			TimelineActionManager.Instance.CanAutoCreateFirstFrame = false;
			this.lastMousePoint = args.Point;
			this.controlPointType = (ControlPointType)this.CSCom.GetControlPointType();
		}

		protected override void OnMouseMove(MouseEventArgsExtend args)
		{
			base.OnMouseMove(args);
			if (this.OperationFlag.HasFlag(OperationMask.MoveFlag) && base.lastClickPoint != null && this.lastMousePoint != args.Point && this.operationType != OperationType.OPERATION_NONE && this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() != 0)
			{
				this.updateLastMousePoint = true;
				this.HandleMouseMove(args.Point);
				if (this.updateLastMousePoint)
				{
					this.lastMousePoint = args.Point;
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgsExtend args)
		{
			base.OnMouseUp(args);
			TimelineActionManager.Instance.CanAutoCreateFirstFrame = true;
			if (this.selectedParentObjects != null && TimelineActionManager.Instance.AutoKey)
			{
				TimelineActionManager.Instance.CanGotoFrame = false;
				foreach (VisualObject current in this.SelectedObjects)
				{
					this.AutoCreateFirstFrame(current, typeof(PositionFrame).Name);
					this.AutoCreateFirstFrame(current, typeof(ScaleFrame).Name);
					this.AutoCreateFirstFrame(current, typeof(RotationSkewFrame).Name);
				}
				TimelineActionManager.Instance.CanGotoFrame = true;
				TimelineActionManager.Instance.CurrentTimelineAction.CurrentFrameIndex = TimelineActionManager.Instance.CurrentFrameIndex;
			}
			if (this.selectedObjects != null)
			{
				foreach (VisualObject current in this.SelectedObjects)
				{
					if (!current.Recorder.IsAutoRecord)
					{
						current.Recorder.Start(true, false);
					}
					else
					{
						LogConfig.Logger.Error("don't try to start a auto record object's record");
					}
				}
			}
			this.isMouseDown = false;
			this.isMouseMoved = false;
		}

		protected override void OnKeyDown(KeyPressEventArgs e)
		{
			if (!this.isMouseMoved && !this.isMouseDown)
			{
				this.vector = base.GetVectorByKey(e.Event.Key);
				if (this.vector != null)
				{
					if (!Services.TaskService.IsRunningCompositeTask)
					{
						Services.TaskService.BeginCompositeTask("MouseDown");
					}
					this.lastMousePoint = new PointF(0f, 0f);
					OperationType operationType = this.operationType;
					this.operationType = OperationType.OPERATION_POSITION;
					if (KeyboardExtend.IsModifyKeyDown(ModifierType.ShiftMask))
					{
						this.vector.X *= 10f;
						this.vector.Y *= 10f;
					}
					this.vector.X *= this.canvasObject.Scale.ScaleX;
					this.vector.Y *= this.canvasObject.Scale.ScaleY;
					this.HandleMouseMove(this.vector);
					this.isMouseMoved = false;
					this.operationType = operationType;
				}
			}
		}

		protected override void OnKeyUp(KeyReleaseEventArgs e)
		{
			if (!this.isMouseMoved && !this.isMouseDown)
			{
				PointF vectorByKey = base.GetVectorByKey(e.Event.Key);
				if (this.vector != null && vectorByKey != null && this.vector.Equals(vectorByKey))
				{
					if (Services.TaskService.IsRunningCompositeTask)
					{
						Services.TaskService.EndCompositeTask();
					}
				}
			}
		}

		private void Print(CSMatrix m)
		{
		}

		private void HandleMouseMove(PointF point)
		{
			this.isMouseMoved = true;
			List<CSMatrix> list = new List<CSMatrix>();
			CSMatrix anchorWorldMatrix = this.CSCom.GetAnchorWorldMatrix();
			this.Print(anchorWorldMatrix);
			CSMatrix cSMatrix = this.CSCom.Mat4Inverse(anchorWorldMatrix);
			this.Print(cSMatrix);
			for (int i = 0; i < this.selectedParentObjects.Count<VisualObject>(); i++)
			{
				VisualObject visualObject = this.selectedParentObjects.ElementAt(i);
				CSMatrix anchorWorldMatrix2 = visualObject.GetCSVisual().GetAnchorWorldMatrix();
				this.Print(anchorWorldMatrix2);
				CSMatrix cSMatrix2 = this.CSCom.Mat4Multiply(cSMatrix, anchorWorldMatrix2);
				this.Print(cSMatrix2);
				list.Add(cSMatrix2);
			}
			if (this.operationType == OperationType.OPERATION_ANCHOR_POINT)
			{
				this.HandleAnchorPoint(point);
				if (this.SelectedObjects.Count<VisualObject>() > 1)
				{
					return;
				}
			}
			else if (this.operationType == OperationType.OPERATION_POSITION)
			{
				this.HandlePosition(point);
			}
			else if (this.operationType == OperationType.OPERATION_ROTATION)
			{
				this.HandleRotation(point);
			}
			else if (this.operationType == OperationType.OPERATION_SCALE)
			{
				if (!this.HandleScale(point))
				{
					this.updateLastMousePoint = false;
					return;
				}
			}
			else if (this.operationType == OperationType.OPERATION_SKEW)
			{
				this.HandleSkew(point);
			}
			CSMatrix anchorWorldMatrix3 = this.CSCom.GetAnchorWorldMatrix();
			this.Print(anchorWorldMatrix3);
			for (int i = 0; i < this.selectedParentObjects.Count<VisualObject>(); i++)
			{
				VisualObject visualObject = this.selectedParentObjects.ElementAt(i);
				VisualObject parent = (visualObject as NodeObject).Parent;
				if (parent == null)
				{
					parent = this.canvasObject;
				}
				CSMatrix cSMatrix3 = visualObject.GetCSVisual().GetParentWorldMatrix();
				this.Print(cSMatrix3);
				cSMatrix3 = this.CSCom.Mat4Inverse(cSMatrix3);
				this.Print(cSMatrix3);
				CSMatrix cSMatrix4 = this.CSCom.Mat4Multiply(anchorWorldMatrix3, list[i]);
				this.Print(cSMatrix4);
				CSMatrix cSMatrix2 = this.CSCom.Mat4Multiply(cSMatrix3, cSMatrix4);
				this.Print(cSMatrix2);
				MatrixNode matrixNode = this.CSCom.Mat4ToMatrixNode(cSMatrix2);
				if (!this.TestFloatEqual(visualObject.Position.X, matrixNode.CX, 0.001f) || !this.TestFloatEqual(visualObject.Position.Y, matrixNode.CY, 0.001f))
				{
					if (!this.positionChanged)
					{
						this.positionChanged = this.NeedAutoCreateFirstFrame(visualObject, typeof(PositionFrame).Name);
					}
					visualObject.Position = new PointF(matrixNode.CX, matrixNode.CY);
				}
				if (!this.TestFloatEqual(visualObject.Scale.ScaleX, matrixNode.CScaleX, 0.001f) || !this.TestFloatEqual(visualObject.Scale.ScaleY, matrixNode.CScaleY, 0.001f))
				{
					if (!this.scaleChanged)
					{
						this.scaleChanged = this.NeedAutoCreateFirstFrame(visualObject, typeof(ScaleFrame).Name);
					}
					visualObject.Scale = new ScaleValue(matrixNode.CScaleX, matrixNode.CScaleY, 0.1, -99999999.0, 99999999.0);
				}
				float num = this.SimplifyRotation(ComControlNode.CC_RADIANS_TO_DEGREES(-matrixNode.CSkewX));
				float num2 = this.SimplifyRotation(ComControlNode.CC_RADIANS_TO_DEGREES(-matrixNode.CSkewY));
				ScaleValue rotationSkew = visualObject.RotationSkew;
				float num3 = this.SimplifyRotation(rotationSkew.ScaleX);
				float num4 = this.SimplifyRotation(rotationSkew.ScaleY);
				if (!this.TestFloatEqual(rotationSkew.ScaleX, num, 0.001f) || !this.TestFloatEqual(rotationSkew.ScaleY, num2, 0.001f))
				{
					if (!this.rotationChanged)
					{
						this.rotationChanged = this.NeedAutoCreateFirstFrame(visualObject, typeof(RotationSkewFrame).Name);
					}
					float num5 = this.SimplifyRotationDif(num - num3);
					float num6 = this.SimplifyRotationDif(num2 - num4);
					rotationSkew.ScaleX += num5;
					rotationSkew.ScaleY += num6;
					visualObject.RotationSkew = rotationSkew;
				}
			}
		}

		private bool NeedAutoCreateFirstFrame(VisualObject node, string frameType)
		{
			Timeline nodeTimeline = TimelineAction.GetNodeTimeline(node as NodeObject, frameType, true);
			return nodeTimeline != null && nodeTimeline.NeedAutoCreateFirstFrame(TimelineActionManager.Instance.CurrentFrameIndex);
		}

		private void AutoCreateFirstFrame(VisualObject node, string frameType)
		{
			Timeline nodeTimeline = TimelineAction.GetNodeTimeline(node as NodeObject, frameType, true);
			if (nodeTimeline != null)
			{
				nodeTimeline.AutoCreateFirstFrame();
			}
		}

		private float SimplifyRotation(float r)
		{
			r %= 360f;
			if (r < 0f)
			{
				r += 360f;
			}
			if (r > 180f)
			{
				r -= 360f;
			}
			return r;
		}

		private float SimplifyRotationDif(float r)
		{
			if (r < -180f)
			{
				r += 360f;
			}
			if (r > 180f)
			{
				r -= 360f;
			}
			return r;
		}

		private bool TestFloatEqual(float v1, float v2, float threshold = 0.001f)
		{
			return Math.Abs(v1 - v2) <= threshold;
		}

		private void HandleSkew(PointF point)
		{
			throw new NotImplementedException();
		}

		private void AdsorbAnchorPoint(ref float newAnchorValue, float oldAnchorValue, float dstAnchorValue, ref float positionValue, float dstPositionValue)
		{
			if (this.TestFloatEqual(newAnchorValue, dstAnchorValue, 0.1f))
			{
				if (Math.Abs(dstAnchorValue - newAnchorValue) < Math.Abs(dstAnchorValue - oldAnchorValue))
				{
					newAnchorValue = dstAnchorValue;
				}
				else
				{
					newAnchorValue = oldAnchorValue;
				}
				positionValue = dstPositionValue;
			}
		}

		private void HandleAnchorPoint(PointF point)
		{
			PointF pointF = this.TransformToSelf(point);
			float x;
			float num = x = pointF.X;
			float y;
			float num2 = y = pointF.Y;
			float scaleX;
			float num3 = scaleX = pointF.X / this.Size.X;
			float scaleY;
			float num4 = scaleY = pointF.Y / this.Size.Y;
			this.AdsorbAnchorPoint(ref num3, this.AnchorPoint.ScaleX, 0f, ref num, 0f);
			this.AdsorbAnchorPoint(ref num3, this.AnchorPoint.ScaleX, 0.5f, ref num, this.Size.X / 2f);
			this.AdsorbAnchorPoint(ref num3, this.AnchorPoint.ScaleX, 1f, ref num, this.Size.X);
			this.AdsorbAnchorPoint(ref num4, this.AnchorPoint.ScaleY, 0f, ref num2, 0f);
			this.AdsorbAnchorPoint(ref num4, this.AnchorPoint.ScaleY, 0.5f, ref num2, this.Size.Y / 2f);
			this.AdsorbAnchorPoint(ref num4, this.AnchorPoint.ScaleY, 1f, ref num2, this.Size.Y);
			bool flag = false;
			bool flag2 = false;
			if ((num3 == 0f || num3 == 1f) && num4 >= -0.1f && num4 <= 1.1f)
			{
				flag = true;
			}
			else if (num3 == 0.5f && ((num4 >= -0.1f && num4 <= 0.1f) || (num4 >= 0.9f && num4 <= 1.1f)))
			{
				flag = true;
			}
			if (flag)
			{
				scaleX = num3;
				x = num;
			}
			if ((num4 == 0f || num4 == 1f) && num3 >= -0.1f && num3 <= 1.1f)
			{
				flag2 = true;
			}
			else if (num4 == 0.5f && ((num3 >= -0.1f && num3 <= 0.1f) || (num3 >= 0.9f && num3 <= 1.1f)))
			{
				flag2 = true;
			}
			if (flag2)
			{
				scaleY = num4;
				y = num2;
			}
			ScaleValue anchorPoint = new ScaleValue(scaleX, scaleY, 0.1, -99999999.0, 99999999.0);
			pointF = new PointF(x, y);
			pointF = this.CSCom.TransformPoint(pointF, this.CSCom.GetMatrixWithoutReCalculate());
			this.AnchorPoint = anchorPoint;
			this.Position = pointF;
			if (this.SelectedObjects.Count<VisualObject>() == 1)
			{
				this.SelectedObjects.FirstOrDefault<VisualObject>().AnchorPoint = anchorPoint;
			}
		}

		private bool HandleScale(PointF point)
		{
			float scaleX = this.Scale.ScaleX;
			float scaleY = this.Scale.ScaleY;
			PointF anchorPointInPoints = this.CSCom.GetAnchorPointInPoints();
			PointF p = this.TransformToSelf(ComControlNode.PointSub(point, anchorPointInPoints));
			PointF p2 = this.TransformToSelf(ComControlNode.PointSub(this.lastMousePoint, anchorPointInPoints));
			PointF pointF = ComControlNode.PointSub(p, p2);
			float num = pointF.X * scaleX;
			float num2 = pointF.Y * scaleY;
			float num3 = -num / anchorPointInPoints.X;
			float num4 = num / (this.Size.X - anchorPointInPoints.X);
			float num5 = -num2 / anchorPointInPoints.Y;
			float num6 = num2 / (this.Size.Y - anchorPointInPoints.Y);
			float num7 = 0f;
			float num8 = 0f;
			switch (this.controlPointType)
			{
			case ControlPointType.POINT_LEFT_TOP:
				if (this.AnchorPoint.ScaleX != 0f)
				{
					num7 = num3;
				}
				if (this.AnchorPoint.ScaleY != 1f)
				{
					num8 = num6;
				}
				break;
			case ControlPointType.POINT_LEFT_BOTTOM:
				if (this.AnchorPoint.ScaleX != 0f)
				{
					num7 = num3;
				}
				if (this.AnchorPoint.ScaleY != 0f)
				{
					num8 = num5;
				}
				break;
			case ControlPointType.POINT_RIGHT_BOTTOM:
				if (this.AnchorPoint.ScaleX != 1f)
				{
					num7 = num4;
				}
				if (this.AnchorPoint.ScaleY != 0f)
				{
					num8 = num5;
				}
				break;
			case ControlPointType.POINT_RIGHT_TOP:
				if (this.AnchorPoint.ScaleX != 1f)
				{
					num7 = num4;
				}
				if (this.AnchorPoint.ScaleY != 1f)
				{
					num8 = num6;
				}
				break;
			case ControlPointType.POINT_LEFT_MIDDLE:
				if (this.AnchorPoint.ScaleX != 0f)
				{
					num7 = num3;
				}
				break;
			case ControlPointType.POINT_MIDDLE_BOTTOM:
				if (this.AnchorPoint.ScaleY != 0f)
				{
					num8 = num5;
				}
				break;
			case ControlPointType.POINT_RIGHT_MIDDLE:
				if (this.AnchorPoint.ScaleX != 1f)
				{
					num7 = num4;
				}
				break;
			case ControlPointType.POINT_MIDDLE_TOP:
				if (this.AnchorPoint.ScaleY != 1f)
				{
					num8 = num6;
				}
				break;
			}
			bool result;
			if ((double)Math.Abs(this.Scale.ScaleX + num7) < 0.01)
			{
				result = false;
			}
			else if ((double)Math.Abs(this.Scale.ScaleY + num8) < 0.01)
			{
				result = false;
			}
			else
			{
				if (this.isShiftDown || this.isScaleLocked)
				{
					float num9 = this.Scale.ScaleY / this.Scale.ScaleX;
					float num10 = this.Scale.ScaleX + num7;
					this.Scale = new ScaleValue(num10, num10 * num9, 0.1, -99999999.0, 99999999.0);
				}
				else
				{
					this.Scale = new ScaleValue(this.Scale.ScaleX + num7, this.Scale.ScaleY + num8, 0.1, -99999999.0, 99999999.0);
				}
				result = true;
			}
			return result;
		}

		private void HandleRotation(PointF point)
		{
			PointF position = this.Position;
			PointF pointF;
			PointF pointF2;
			if (this.selectedParentObjects.Count<VisualObject>() == 1)
			{
				pointF = this.selectedParentObjects.FirstOrDefault<VisualObject>().TransformToParent(this.lastMousePoint);
				pointF2 = this.selectedParentObjects.FirstOrDefault<VisualObject>().TransformToParent(point);
			}
			else
			{
				pointF = this.canvasObject.TransformToSelf(this.lastMousePoint);
				pointF2 = this.canvasObject.TransformToSelf(point);
			}
			float num = ComControlNode.CC_DEGREES_TO_RADIANS(this.RotationSkew.ScaleX);
			float num2 = ComControlNode.CC_DEGREES_TO_RADIANS(this.RotationSkew.ScaleY);
			float num3 = (float)(-(float)Math.Atan2((double)(pointF.Y - position.Y), (double)(pointF.X - position.X)));
			float num4 = (float)(-(float)Math.Atan2((double)(pointF2.Y - position.Y), (double)(pointF2.X - position.X)));
			if (this.isShiftDown)
			{
				num4 = ((num4 * num3 < 0f) ? (-num4) : num4);
				float num5 = ComControlNode.CC_RADIANS_TO_DEGREES(num4 - num3);
				this.lastRotation += num5;
				if (Math.Abs(this.lastRotation) >= 15f)
				{
					float num6 = (float)((this.RotationSkew.ScaleX + this.lastRotation > 0f) ? 15 : -15);
					float num7 = (float)((this.RotationSkew.ScaleY + this.lastRotation > 0f) ? 15 : -15);
					this.RotationSkew = new ScaleValue();
					this.lastRotation = 0f;
				}
			}
			else
			{
				num2 = ComControlNode.CC_RADIANS_TO_DEGREES(num2 + num4 - num3);
				num = ComControlNode.CC_RADIANS_TO_DEGREES(num + num4 - num3);
				this.RotationSkew = new ScaleValue(num, num2, 0.1, -99999999.0, 99999999.0);
			}
		}

		private void HandlePosition(PointF point)
		{
			if (!TimelineActionManager.Instance.OnionSkinEnable || TimelineActionManager.Instance.AutoKey)
			{
				VisualObject visualObject = this.selectedParentObjects.FirstOrDefault<VisualObject>();
				if (visualObject != null)
				{
					PointF pointF = visualObject.TransformToParent(this.lastMousePoint);
					PointF pointF2 = visualObject.TransformToParent(point);
					PointF position = this.Position;
					PointF pointF3 = new PointF(position.X + pointF2.X - pointF.X, position.Y + pointF2.Y - pointF.Y);
					if (this.isShiftDown)
					{
						switch (this.moveDirection)
						{
						case MoveDirection.NONE:
							this.Position = pointF3;
							break;
						case MoveDirection.X:
							this.Position = new PointF(pointF3.X, this.Position.Y);
							break;
						case MoveDirection.Y:
							this.Position = new PointF(this.Position.X, pointF3.Y);
							break;
						}
						if (this.moveDirection == MoveDirection.NONE)
						{
							if (pointF2.X - pointF.X != 0f)
							{
								this.moveDirection = MoveDirection.X;
							}
							else
							{
								this.moveDirection = MoveDirection.Y;
							}
						}
					}
					else
					{
						this.Position = pointF3;
					}
				}
			}
		}

		private static float CC_RADIANS_TO_DEGREES(float v)
		{
			return v * 57.29578f;
		}

		private static float CC_DEGREES_TO_RADIANS(float v)
		{
			return v * 0.0174532924f;
		}

		private static PointF PointSub(PointF p1, PointF p2)
		{
			return new PointF(p1.X - p2.X, p1.Y - p2.Y);
		}

		protected override HitTestResult HitTestCore(PointF point)
		{
			HitTestResult result;
			if (!this.Enabled)
			{
				result = null;
			}
			else
			{
				if (!this.isMouseDown)
				{
					this.UpdateOperationType(point);
					if (!this.OperationFlag.HasFlag(OperationMask.MoveFlag) || (this.operationType == OperationType.OPERATION_NONE && this.controlPointType == ControlPointType.POINT_NONE))
					{
						result = null;
						return result;
					}
					if (this.Size.X == 0f || this.Size.Y == 0f || this.Scale.ScaleX == 0f || this.Scale.ScaleY == 0f)
					{
						this.operationType = OperationType.OPERATION_POSITION;
					}
				}
				CSMatrix anchorWorldMatrix = this.CSCom.GetAnchorWorldMatrix();
				PointF pointF = new PointF(anchorWorldMatrix.CX, anchorWorldMatrix.CY);
				float rotate = (float)(-(float)Math.Atan2((double)(point.Y - pointF.Y), (double)(point.X - pointF.X)));
				result = new HitTestResult(this, point, this.operationType, this.controlPointType, rotate);
			}
			return result;
		}

		public void Dispose()
		{
			TimelineActionManager.Instance.CurrentFrameIndexChangedEvent -= new CurrentFrameIndexChangedHandler(this.OnFrameIndexChanged);
			Services.Workbench.ActiveDocumentChanged -= new EventHandler(this.DocumentChanged);
		}
	}
}
