// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Component.ComControlNode
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

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
    private SelectInfo selectInfo = new SelectInfo((IEnumerable<VisualObject>) new List<VisualObject>(), (IEnumerable<VisualObject>) new List<VisualObject>());
    private bool isShiftDown = false;
    private bool isMouseMoved = false;
    private bool isMouseDown = false;
    private bool isScaleLocked = false;
    private MoveDirection moveDirection = MoveDirection.NONE;
    private float lastRotation = 0.0f;
    private bool rotationChanged = false;
    private bool scaleChanged = false;
    private bool positionChanged = false;
    private PointF vector = (PointF) null;
    private bool updateLastMousePoint = true;
    private IEnumerable<VisualObject> selectedObjects;
    private IEnumerable<VisualObject> selectedParentObjects;
    private VisualObject canvasObject;
    private PointF lastMousePoint;
    private OperationType operationType;
    private ControlPointType controlPointType;

    public IEnumerable<VisualObject> SelectedObjects
    {
      get
      {
        return this.selectedObjects;
      }
      set
      {
        this.selectedObjects = value;
        this.Enabled = this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() != 0;
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
          foreach (VisualObject selectedObject in this.SelectedObjects)
            selectedObject.IsSelected = false;
        }
        if (this.SelectedObjects != null && this.SelectedObjects.Count<VisualObject>() > 0 && this.isMouseDown)
        {
          foreach (VisualObject selectedObject in this.SelectedObjects)
          {
            if (!selectedObject.Recorder.IsAutoRecord)
              selectedObject.Recorder.Start(true, false);
            else
              LogConfig.Logger.Error((object) "don't try to start a auto record object's record");
          }
        }
        if (this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() > 0)
          this.selectedObjects.ElementAt<VisualObject>(0).PropertyChanged -= new PropertyChangedEventHandler(this.ComControlNode_PropertyChanged);
        this.SelectedObjects = this.selectInfo.SelectedObjects;
        this.SelectedParentObjects = this.selectInfo.SelectedParentObjects;
        if (this.selectedObjects != null && this.selectedObjects.Count<VisualObject>() > 0)
          this.selectedObjects.ElementAt<VisualObject>(0).PropertyChanged += new PropertyChangedEventHandler(this.ComControlNode_PropertyChanged);
        if (this.SelectedObjects == null || this.SelectedObjects.Count<VisualObject>() <= 0)
          return;
        if (this.SelectedObjects.Count<VisualObject>() == 1)
          this.CSCom.SetAttachNode(this.SelectedObjects.FirstOrDefault<VisualObject>().GetCSVisual() as CSNode);
        else
          this.CSCom.SetAttachNode(new CSNode(IntPtr.Zero, true));
      }
    }

    private CSComControlNode CSCom
    {
      get
      {
        return this.GetCSVisual() as CSComControlNode;
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

    public ComControlNode(CanvasObject canvasObject)
    {
      this.canvasObject = (VisualObject) canvasObject;
      this.CSCom.SetCanvasObject(canvasObject.GetCSVisual());
      this.Visible = this.VisibleForFrame = true;
      TimelineActionManager.Instance.CurrentFrameIndexChangedEvent += new CurrentFrameIndexChangedHandler(this.OnFrameIndexChanged);
      Services.Workbench.ActiveDocumentChanged += new EventHandler(this.DocumentChanged);
      Services.EventsService.GetEvent<AlignedObjectsEvent>().Subscribe(new System.Action<AlignedObjectsArgs>(this.OnAlignedObjects));
      Services.EventsService.GetEvent<ScaleLockedChangeEvent>().Subscribe(new System.Action<bool>(this.OnScaleLockedChange));
      Services.EventsService.GetEvent<CanvasSizeChangeEvent>().Subscribe(new System.Action<CanvasSizeChangeEventArgs>(this.OnCanvasSizeChange));
    }

    private void RefreshOperation()
    {
      this.OperationFlag &= ~OperationMask.MoveFlag;
      foreach (VisualObject selectedObject in this.selectedObjects)
      {
        if (selectedObject.OperationFlag == OperationMask.NoneFlag)
        {
          ComControlNode comControlNode = this;
          int operationFlag = (int) comControlNode.OperationFlag;
          int num = 0;
          comControlNode.OperationFlag = (OperationMask) num;
          break;
        }
        if (selectedObject.IsTransformEnabled)
        {
          this.OperationFlag |= OperationMask.MoveFlag;
          break;
        }
      }
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
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSComControlNode();
    }

    private void Init()
    {
      if (this.isMouseMoved)
        return;
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

    private void InitBoundingBox()
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      float num4 = 0.0f;
      bool flag = true;
      foreach (VisualObject selectedObject in this.selectedObjects)
      {
        PointF boundingSize = selectedObject.GetBoundingSize();
        CSRect csRect = this.CSCom.RectApplyTransform(new Rectangle(0, 0, (int) boundingSize.X, (int) boundingSize.Y), selectedObject.GetCSVisual().ConvertToNodeMatrix(this.canvasObject.GetCSVisual()));
        if (flag)
        {
          num1 = csRect.MinX();
          num2 = csRect.MinY();
          num3 = csRect.MaxX();
          num4 = csRect.MaxY();
          flag = false;
        }
        else
        {
          num1 = Math.Min(num1, csRect.MinX());
          num2 = Math.Min(num2, csRect.MinY());
          num3 = Math.Max(num3, csRect.MaxX());
          num4 = Math.Max(num4, csRect.MaxY());
        }
      }
      this.InitMatrix(num1, num2, num3, num4);
    }

    private void InitMatrix(float left, float bottom, float right, float top)
    {
      this.CSCom.SetAnchorPointVisiable(true);
      this.CSCom.SetControlPointVisiable(true);
      if (this.selectedObjects.Count<VisualObject>() == 1)
      {
        VisualObject visualObject = this.selectedParentObjects.FirstOrDefault<VisualObject>();
        this.AnchorPoint = visualObject.GetBoundingAnchorPoint();
        this.Size = visualObject.GetBoundingSize();
        this.Position = visualObject.Position;
        this.Scale = visualObject.Scale;
        this.RotationSkew = visualObject.RotationSkew;
        if (!visualObject.OperationFlag.HasFlag((Enum) OperationMask.ScaleFlag) && !visualObject.OperationFlag.HasFlag((Enum) OperationMask.RotationFlag))
          this.CSCom.SetControlPointVisiable(false);
        this.CSCom.SetAnchorPointVisiable(visualObject.OperationFlag.HasFlag((Enum) OperationMask.AnchorMoveFlag));
      }
      else
      {
        this.AnchorPoint = new ScaleValue(0.5f, 0.5f, 0.1, -99999999.0, 99999999.0);
        this.Size = new PointF(right - left, top - bottom);
        this.RotationSkew = new ScaleValue(0.0f, 0.0f, 0.1, -99999999.0, 99999999.0);
        this.Scale = new ScaleValue(1f, 1f, 0.1, -99999999.0, 99999999.0);
        PointF anchorPointInPoints = this.CSCom.GetAnchorPointInPoints();
        this.Position = new PointF(left + anchorPointInPoints.X, bottom + anchorPointInPoints.Y);
      }
    }

    private void OnFrameIndexChanged()
    {
      if (this.isMouseDown || Services.TaskService.IsUndoing)
        return;
      this.Init();
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
          return;
        bool flag = true;
        foreach (VisualObject selectedObject in this.selectedObjects)
        {
          if (!selectedObjectList.Contains<VisualObject>(selectedObject))
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          if (!isUnReDone)
            return;
          this.Init();
          return;
        }
      }
      this.SelectInfo = new SelectInfo((IEnumerable<VisualObject>) selectedObjectList.ToList<VisualObject>(), (IEnumerable<VisualObject>) selectedParentObjectList.ToList<VisualObject>());
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
      if (this.selectedObjects.Count<VisualObject>() == 0 || e.PropertyName == "IsSelected")
        return;
      if (e.PropertyName == "Parent")
      {
        this.RefreshOperation();
        this.Init();
      }
      else
        this.Init();
    }

    public OperationType UpdateOperationType(PointF point)
    {
      this.operationType = (OperationType) this.CSCom.HitTest(point);
      this.controlPointType = (ControlPointType) this.CSCom.GetControlPointType();
      return this.operationType;
    }

    protected override void OnMouseDown(MouseEventArgsExtend args)
    {
      base.OnMouseDown(args);
      this.isMouseDown = true;
      this.isShiftDown = KeyboardExtend.IsModifyKeyDown(ModifierType.ShiftMask);
      this.moveDirection = MoveDirection.NONE;
      this.lastRotation = 0.0f;
      if (this.selectedObjects != null)
      {
        foreach (VisualObject selectedObject in this.SelectedObjects)
        {
          if (selectedObject.Recorder.IsAutoRecord)
            selectedObject.Recorder.Stop(true);
          else
            LogConfig.Logger.Error((object) "don't try to start a auto record object's record");
        }
      }
      this.rotationChanged = false;
      this.scaleChanged = false;
      this.positionChanged = false;
      TimelineActionManager.Instance.CanAutoCreateFirstFrame = false;
      this.lastMousePoint = args.Point;
      this.controlPointType = (ControlPointType) this.CSCom.GetControlPointType();
    }

    protected override void OnMouseMove(MouseEventArgsExtend args)
    {
      base.OnMouseMove(args);
      if (!this.OperationFlag.HasFlag((Enum) OperationMask.MoveFlag) || this.lastClickPoint == null || (this.lastMousePoint == args.Point || this.operationType == OperationType.OPERATION_NONE) || this.selectedObjects == null || this.selectedObjects.Count<VisualObject>() == 0)
        return;
      this.updateLastMousePoint = true;
      this.HandleMouseMove(args.Point);
      if (!this.updateLastMousePoint)
        return;
      this.lastMousePoint = args.Point;
    }

    protected override void OnMouseUp(MouseEventArgsExtend args)
    {
      base.OnMouseUp(args);
      TimelineActionManager.Instance.CanAutoCreateFirstFrame = true;
      if (this.selectedParentObjects != null && TimelineActionManager.Instance.AutoKey)
      {
        TimelineActionManager.Instance.CanGotoFrame = false;
        foreach (VisualObject selectedObject in this.SelectedObjects)
        {
          this.AutoCreateFirstFrame(selectedObject, typeof (PositionFrame).Name);
          this.AutoCreateFirstFrame(selectedObject, typeof (ScaleFrame).Name);
          this.AutoCreateFirstFrame(selectedObject, typeof (RotationSkewFrame).Name);
        }
        TimelineActionManager.Instance.CanGotoFrame = true;
        TimelineActionManager.Instance.CurrentTimelineAction.CurrentFrameIndex = TimelineActionManager.Instance.CurrentFrameIndex;
      }
      if (this.selectedObjects != null)
      {
        foreach (VisualObject selectedObject in this.SelectedObjects)
        {
          if (!selectedObject.Recorder.IsAutoRecord)
            selectedObject.Recorder.Start(true, false);
          else
            LogConfig.Logger.Error((object) "don't try to start a auto record object's record");
        }
      }
      this.isMouseDown = false;
      this.isMouseMoved = false;
    }

    protected override void OnKeyDown(KeyPressEventArgs e)
    {
      if (this.isMouseMoved || this.isMouseDown)
        return;
      this.vector = this.GetVectorByKey(e.Event.Key);
      if (this.vector == null)
        return;
      if (!Services.TaskService.IsRunningCompositeTask)
        Services.TaskService.BeginCompositeTask("MouseDown");
      this.lastMousePoint = new PointF(0.0f, 0.0f);
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

    protected override void OnKeyUp(KeyReleaseEventArgs e)
    {
      if (this.isMouseMoved || this.isMouseDown)
        return;
      PointF vectorByKey = this.GetVectorByKey(e.Event.Key);
      if (this.vector == null || vectorByKey == null || !this.vector.Equals((object) vectorByKey) || !Services.TaskService.IsRunningCompositeTask)
        return;
      Services.TaskService.EndCompositeTask();
    }

    private void Print(CSMatrix m)
    {
    }

    private void HandleMouseMove(PointF point)
    {
      this.isMouseMoved = true;
      List<CSMatrix> csMatrixList = new List<CSMatrix>();
      CSMatrix anchorWorldMatrix1 = this.CSCom.GetAnchorWorldMatrix();
      this.Print(anchorWorldMatrix1);
      CSMatrix csMatrix1 = this.CSCom.Mat4Inverse(anchorWorldMatrix1);
      this.Print(csMatrix1);
      for (int index = 0; index < this.selectedParentObjects.Count<VisualObject>(); ++index)
      {
        CSMatrix anchorWorldMatrix2 = this.selectedParentObjects.ElementAt<VisualObject>(index).GetCSVisual().GetAnchorWorldMatrix();
        this.Print(anchorWorldMatrix2);
        CSMatrix m = this.CSCom.Mat4Multiply(csMatrix1, anchorWorldMatrix2);
        this.Print(m);
        csMatrixList.Add(m);
      }
      if (this.operationType == OperationType.OPERATION_ANCHOR_POINT)
      {
        this.HandleAnchorPoint(point);
        if (this.SelectedObjects.Count<VisualObject>() > 1)
          return;
      }
      else if (this.operationType == OperationType.OPERATION_POSITION)
        this.HandlePosition(point);
      else if (this.operationType == OperationType.OPERATION_ROTATION)
        this.HandleRotation(point);
      else if (this.operationType == OperationType.OPERATION_SCALE)
      {
        if (!this.HandleScale(point))
        {
          this.updateLastMousePoint = false;
          return;
        }
      }
      else if (this.operationType == OperationType.OPERATION_SKEW)
        this.HandleSkew(point);
      CSMatrix anchorWorldMatrix3 = this.CSCom.GetAnchorWorldMatrix();
      this.Print(anchorWorldMatrix3);
      for (int index = 0; index < this.selectedParentObjects.Count<VisualObject>(); ++index)
      {
        VisualObject node = this.selectedParentObjects.ElementAt<VisualObject>(index);
        if ((VisualObject) (node as NodeObject).Parent == null)
        {
          VisualObject canvasObject = this.canvasObject;
        }
        CSMatrix parentWorldMatrix = node.GetCSVisual().GetParentWorldMatrix();
        this.Print(parentWorldMatrix);
        CSMatrix csMatrix2 = this.CSCom.Mat4Inverse(parentWorldMatrix);
        this.Print(csMatrix2);
        CSMatrix csMatrix3 = this.CSCom.Mat4Multiply(anchorWorldMatrix3, csMatrixList[index]);
        this.Print(csMatrix3);
        CSMatrix csMatrix4 = this.CSCom.Mat4Multiply(csMatrix2, csMatrix3);
        this.Print(csMatrix4);
        MatrixNode matrixNode = this.CSCom.Mat4ToMatrixNode(csMatrix4);
        if (!this.TestFloatEqual(node.Position.X, matrixNode.CX, 1f / 1000f) || !this.TestFloatEqual(node.Position.Y, matrixNode.CY, 1f / 1000f))
        {
          if (!this.positionChanged)
            this.positionChanged = this.NeedAutoCreateFirstFrame(node, typeof (PositionFrame).Name);
          node.Position = new PointF(matrixNode.CX, matrixNode.CY);
        }
        if (!this.TestFloatEqual(node.Scale.ScaleX, matrixNode.CScaleX, 1f / 1000f) || !this.TestFloatEqual(node.Scale.ScaleY, matrixNode.CScaleY, 1f / 1000f))
        {
          if (!this.scaleChanged)
            this.scaleChanged = this.NeedAutoCreateFirstFrame(node, typeof (ScaleFrame).Name);
          node.Scale = new ScaleValue(matrixNode.CScaleX, matrixNode.CScaleY, 0.1, -99999999.0, 99999999.0);
        }
        float v2_1 = this.SimplifyRotation(ComControlNode.CC_RADIANS_TO_DEGREES(-matrixNode.CSkewX));
        float v2_2 = this.SimplifyRotation(ComControlNode.CC_RADIANS_TO_DEGREES(-matrixNode.CSkewY));
        ScaleValue rotationSkew = node.RotationSkew;
        float num1 = this.SimplifyRotation(rotationSkew.ScaleX);
        float num2 = this.SimplifyRotation(rotationSkew.ScaleY);
        if (!this.TestFloatEqual(rotationSkew.ScaleX, v2_1, 1f / 1000f) || !this.TestFloatEqual(rotationSkew.ScaleY, v2_2, 1f / 1000f))
        {
          if (!this.rotationChanged)
            this.rotationChanged = this.NeedAutoCreateFirstFrame(node, typeof (RotationSkewFrame).Name);
          float num3 = this.SimplifyRotationDif(v2_1 - num1);
          float num4 = this.SimplifyRotationDif(v2_2 - num2);
          rotationSkew.ScaleX += num3;
          rotationSkew.ScaleY += num4;
          node.RotationSkew = rotationSkew;
        }
      }
    }

    private bool NeedAutoCreateFirstFrame(VisualObject node, string frameType)
    {
      Timeline nodeTimeline = TimelineAction.GetNodeTimeline(node as NodeObject, frameType, true);
      if (nodeTimeline == null)
        return false;
      return nodeTimeline.NeedAutoCreateFirstFrame(TimelineActionManager.Instance.CurrentFrameIndex);
    }

    private void AutoCreateFirstFrame(VisualObject node, string frameType)
    {
      Timeline nodeTimeline = TimelineAction.GetNodeTimeline(node as NodeObject, frameType, true);
      if (nodeTimeline == null)
        return;
      nodeTimeline.AutoCreateFirstFrame();
    }

    private float SimplifyRotation(float r)
    {
      r %= 360f;
      if ((double) r < 0.0)
        r += 360f;
      if ((double) r > 180.0)
        r -= 360f;
      return r;
    }

    private float SimplifyRotationDif(float r)
    {
      if ((double) r < -180.0)
        r += 360f;
      if ((double) r > 180.0)
        r -= 360f;
      return r;
    }

    private bool TestFloatEqual(float v1, float v2, float threshold = 0.001f)
    {
      return (double) Math.Abs(v1 - v2) <= (double) threshold;
    }

    private void HandleSkew(PointF point)
    {
      throw new NotImplementedException();
    }

    private void AdsorbAnchorPoint(ref float newAnchorValue, float oldAnchorValue, float dstAnchorValue, ref float positionValue, float dstPositionValue)
    {
      if (!this.TestFloatEqual(newAnchorValue, dstAnchorValue, 0.1f))
        return;
      newAnchorValue = (double) Math.Abs(dstAnchorValue - newAnchorValue) >= (double) Math.Abs(dstAnchorValue - oldAnchorValue) ? oldAnchorValue : dstAnchorValue;
      positionValue = dstPositionValue;
    }

    private void HandleAnchorPoint(PointF point)
    {
      PointF self = this.TransformToSelf(point);
      float x1;
      float x2 = x1 = self.X;
      float y1;
      float y2 = y1 = self.Y;
      float newAnchorValue1;
      float scaleX = newAnchorValue1 = self.X / this.Size.X;
      float newAnchorValue2;
      float scaleY = newAnchorValue2 = self.Y / this.Size.Y;
      this.AdsorbAnchorPoint(ref newAnchorValue1, this.AnchorPoint.ScaleX, 0.0f, ref x1, 0.0f);
      this.AdsorbAnchorPoint(ref newAnchorValue1, this.AnchorPoint.ScaleX, 0.5f, ref x1, this.Size.X / 2f);
      this.AdsorbAnchorPoint(ref newAnchorValue1, this.AnchorPoint.ScaleX, 1f, ref x1, this.Size.X);
      this.AdsorbAnchorPoint(ref newAnchorValue2, this.AnchorPoint.ScaleY, 0.0f, ref y1, 0.0f);
      this.AdsorbAnchorPoint(ref newAnchorValue2, this.AnchorPoint.ScaleY, 0.5f, ref y1, this.Size.Y / 2f);
      this.AdsorbAnchorPoint(ref newAnchorValue2, this.AnchorPoint.ScaleY, 1f, ref y1, this.Size.Y);
      bool flag1 = false;
      bool flag2 = false;
      if (((double) newAnchorValue1 == 0.0 || (double) newAnchorValue1 == 1.0) && ((double) newAnchorValue2 >= -0.100000001490116 && (double) newAnchorValue2 <= 1.10000002384186))
        flag1 = true;
      else if ((double) newAnchorValue1 == 0.5 && ((double) newAnchorValue2 >= -0.100000001490116 && (double) newAnchorValue2 <= 0.100000001490116 || (double) newAnchorValue2 >= 0.899999976158142 && (double) newAnchorValue2 <= 1.10000002384186))
        flag1 = true;
      if (flag1)
      {
        scaleX = newAnchorValue1;
        x2 = x1;
      }
      if (((double) newAnchorValue2 == 0.0 || (double) newAnchorValue2 == 1.0) && ((double) newAnchorValue1 >= -0.100000001490116 && (double) newAnchorValue1 <= 1.10000002384186))
        flag2 = true;
      else if ((double) newAnchorValue2 == 0.5 && ((double) newAnchorValue1 >= -0.100000001490116 && (double) newAnchorValue1 <= 0.100000001490116 || (double) newAnchorValue1 >= 0.899999976158142 && (double) newAnchorValue1 <= 1.10000002384186))
        flag2 = true;
      if (flag2)
      {
        scaleY = newAnchorValue2;
        y2 = y1;
      }
      ScaleValue scaleValue = new ScaleValue(scaleX, scaleY, 0.1, -99999999.0, 99999999.0);
      PointF pointF = this.CSCom.TransformPoint(new PointF(x2, y2), this.CSCom.GetMatrixWithoutReCalculate());
      this.AnchorPoint = scaleValue;
      this.Position = pointF;
      if (this.SelectedObjects.Count<VisualObject>() != 1)
        return;
      this.SelectedObjects.FirstOrDefault<VisualObject>().AnchorPoint = scaleValue;
    }

    private bool HandleScale(PointF point)
    {
      float scaleX1 = this.Scale.ScaleX;
      float scaleY = this.Scale.ScaleY;
      PointF anchorPointInPoints = this.CSCom.GetAnchorPointInPoints();
      PointF pointF = ComControlNode.PointSub(this.TransformToSelf(ComControlNode.PointSub(point, anchorPointInPoints)), this.TransformToSelf(ComControlNode.PointSub(this.lastMousePoint, anchorPointInPoints)));
      float num1 = pointF.X * scaleX1;
      float num2 = pointF.Y * scaleY;
      float num3 = -num1 / anchorPointInPoints.X;
      float num4 = num1 / (this.Size.X - anchorPointInPoints.X);
      float num5 = -num2 / anchorPointInPoints.Y;
      float num6 = num2 / (this.Size.Y - anchorPointInPoints.Y);
      float num7 = 0.0f;
      float num8 = 0.0f;
      switch (this.controlPointType)
      {
        case ControlPointType.POINT_LEFT_TOP:
          if ((double) this.AnchorPoint.ScaleX != 0.0)
            num7 = num3;
          if ((double) this.AnchorPoint.ScaleY != 1.0)
          {
            num8 = num6;
            break;
          }
          break;
        case ControlPointType.POINT_LEFT_BOTTOM:
          if ((double) this.AnchorPoint.ScaleX != 0.0)
            num7 = num3;
          if ((double) this.AnchorPoint.ScaleY != 0.0)
          {
            num8 = num5;
            break;
          }
          break;
        case ControlPointType.POINT_RIGHT_BOTTOM:
          if ((double) this.AnchorPoint.ScaleX != 1.0)
            num7 = num4;
          if ((double) this.AnchorPoint.ScaleY != 0.0)
          {
            num8 = num5;
            break;
          }
          break;
        case ControlPointType.POINT_RIGHT_TOP:
          if ((double) this.AnchorPoint.ScaleX != 1.0)
            num7 = num4;
          if ((double) this.AnchorPoint.ScaleY != 1.0)
          {
            num8 = num6;
            break;
          }
          break;
        case ControlPointType.POINT_LEFT_MIDDLE:
          if ((double) this.AnchorPoint.ScaleX != 0.0)
          {
            num7 = num3;
            break;
          }
          break;
        case ControlPointType.POINT_MIDDLE_BOTTOM:
          if ((double) this.AnchorPoint.ScaleY != 0.0)
          {
            num8 = num5;
            break;
          }
          break;
        case ControlPointType.POINT_RIGHT_MIDDLE:
          if ((double) this.AnchorPoint.ScaleX != 1.0)
          {
            num7 = num4;
            break;
          }
          break;
        case ControlPointType.POINT_MIDDLE_TOP:
          if ((double) this.AnchorPoint.ScaleY != 1.0)
          {
            num8 = num6;
            break;
          }
          break;
      }
      if ((double) Math.Abs(this.Scale.ScaleX + num7) < 0.01 || (double) Math.Abs(this.Scale.ScaleY + num8) < 0.01)
        return false;
      if (this.isShiftDown || this.isScaleLocked)
      {
        float num9 = this.Scale.ScaleY / this.Scale.ScaleX;
        float scaleX2 = this.Scale.ScaleX + num7;
        this.Scale = new ScaleValue(scaleX2, scaleX2 * num9, 0.1, -99999999.0, 99999999.0);
      }
      else
        this.Scale = new ScaleValue(this.Scale.ScaleX + num7, this.Scale.ScaleY + num8, 0.1, -99999999.0, 99999999.0);
      return true;
    }

    private void HandleRotation(PointF point)
    {
      PointF position = this.Position;
      PointF pointF1;
      PointF pointF2;
      if (this.selectedParentObjects.Count<VisualObject>() == 1)
      {
        pointF1 = this.selectedParentObjects.FirstOrDefault<VisualObject>().TransformToParent(this.lastMousePoint);
        pointF2 = this.selectedParentObjects.FirstOrDefault<VisualObject>().TransformToParent(point);
      }
      else
      {
        pointF1 = this.canvasObject.TransformToSelf(this.lastMousePoint);
        pointF2 = this.canvasObject.TransformToSelf(point);
      }
      float radians1 = ComControlNode.CC_DEGREES_TO_RADIANS(this.RotationSkew.ScaleX);
      float radians2 = ComControlNode.CC_DEGREES_TO_RADIANS(this.RotationSkew.ScaleY);
      float num1 = (float) -Math.Atan2((double) pointF1.Y - (double) position.Y, (double) pointF1.X - (double) position.X);
      float num2 = (float) -Math.Atan2((double) pointF2.Y - (double) position.Y, (double) pointF2.X - (double) position.X);
      if (this.isShiftDown)
      {
        this.lastRotation += ComControlNode.CC_RADIANS_TO_DEGREES(((double) num2 * (double) num1 < 0.0 ? -num2 : num2) - num1);
        if ((double) Math.Abs(this.lastRotation) < 15.0)
          return;
        float num3 = (double) this.RotationSkew.ScaleX + (double) this.lastRotation > 0.0 ? 15f : -15f;
        float num4 = (double) this.RotationSkew.ScaleY + (double) this.lastRotation > 0.0 ? 15f : -15f;
        this.RotationSkew = new ScaleValue();
        this.lastRotation = 0.0f;
      }
      else
      {
        float degrees = ComControlNode.CC_RADIANS_TO_DEGREES(radians2 + num2 - num1);
        this.RotationSkew = new ScaleValue(ComControlNode.CC_RADIANS_TO_DEGREES(radians1 + num2 - num1), degrees, 0.1, -99999999.0, 99999999.0);
      }
    }

    private void HandlePosition(PointF point)
    {
      if (TimelineActionManager.Instance.OnionSkinEnable && !TimelineActionManager.Instance.AutoKey)
        return;
      VisualObject visualObject = this.selectedParentObjects.FirstOrDefault<VisualObject>();
      if (visualObject == null)
        return;
      PointF parent1 = visualObject.TransformToParent(this.lastMousePoint);
      PointF parent2 = visualObject.TransformToParent(point);
      PointF position = this.Position;
      PointF pointF = new PointF(position.X + parent2.X - parent1.X, position.Y + parent2.Y - parent1.Y);
      if (this.isShiftDown)
      {
        switch (this.moveDirection)
        {
          case MoveDirection.NONE:
            this.Position = pointF;
            break;
          case MoveDirection.X:
            this.Position = new PointF(pointF.X, this.Position.Y);
            break;
          case MoveDirection.Y:
            this.Position = new PointF(this.Position.X, pointF.Y);
            break;
        }
        if (this.moveDirection != MoveDirection.NONE)
          return;
        this.moveDirection = (double) parent2.X - (double) parent1.X == 0.0 ? MoveDirection.Y : MoveDirection.X;
      }
      else
        this.Position = pointF;
    }

    private static float CC_RADIANS_TO_DEGREES(float v)
    {
      return v * 57.29578f;
    }

    private static float CC_DEGREES_TO_RADIANS(float v)
    {
      return v * ((float) Math.PI / 180f);
    }

    private static PointF PointSub(PointF p1, PointF p2)
    {
      return new PointF(p1.X - p2.X, p1.Y - p2.Y);
    }

    protected override HitTestResult HitTestCore(PointF point)
    {
      if (!this.Enabled)
        return (HitTestResult) null;
      if (!this.isMouseDown)
      {
        int num = (int) this.UpdateOperationType(point);
        if (!this.OperationFlag.HasFlag((Enum) OperationMask.MoveFlag) || this.operationType == OperationType.OPERATION_NONE && this.controlPointType == ControlPointType.POINT_NONE)
          return (HitTestResult) null;
        if ((double) this.Size.X == 0.0 || (double) this.Size.Y == 0.0 || (double) this.Scale.ScaleX == 0.0 || (double) this.Scale.ScaleY == 0.0)
          this.operationType = OperationType.OPERATION_POSITION;
      }
      CSMatrix anchorWorldMatrix = this.CSCom.GetAnchorWorldMatrix();
      PointF pointF = new PointF(anchorWorldMatrix.CX, anchorWorldMatrix.CY);
      float rotate = (float) -Math.Atan2((double) point.Y - (double) pointF.Y, (double) point.X - (double) pointF.X);
      return new HitTestResult((VisualObject) this, point, this.operationType, this.controlPointType, rotate);
    }

    public void Dispose()
    {
      TimelineActionManager.Instance.CurrentFrameIndexChangedEvent -= new CurrentFrameIndexChangedHandler(this.OnFrameIndexChanged);
      Services.Workbench.ActiveDocumentChanged -= new EventHandler(this.DocumentChanged);
    }
  }
}
