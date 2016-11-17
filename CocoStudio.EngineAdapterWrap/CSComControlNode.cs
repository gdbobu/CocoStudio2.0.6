// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSComControlNode
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using Gdk;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSComControlNode : CSNode
  {
    private HandleRef swigCPtr;

    public CSComControlNode(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSComControlNode_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSComControlNode()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSComControlNode(), true)
    {
    }

    ~CSComControlNode()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSComControlNode obj)
    {
      return obj == null ? new HandleRef((object) null, IntPtr.Zero) : obj.swigCPtr;
    }

    public override void Dispose()
    {
      lock (this)
      {
        if (this.swigCPtr.Handle != IntPtr.Zero)
        {
          if (this.swigCMemOwn)
          {
            this.swigCMemOwn = false;
            HandleRef handle = new HandleRef((object) null, this.swigCPtr.Handle);
            if (this.IsContainOpenGLResource())
              GtkInvokeHelp.BeginInvoke((Action) (() =>
              {
                this.swigCPtr = handle;
                CocoStudioEngineAdapterPINVOKE.delete_CSComControlNode(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSComControlNode(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_Init(this.swigCPtr);
    }

    public override void SetPosition(PointF position)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetPosition(this.swigCPtr, Vec2.getCPtr(new Vec2(position.X, position.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override PointF GetSize()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSComControlNode_GetSize(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public override void SetSize(PointF size)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetSize(this.swigCPtr, Vec2.getCPtr(new Vec2(size.X, size.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override int HitTest(PointF point)
    {
      int num = CocoStudioEngineAdapterPINVOKE.CSComControlNode_HitTest(this.swigCPtr, Vec2.getCPtr(new Vec2(point.X, point.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return num;
    }

    public override bool HasFileAndSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSComControlNode_HasFileAndSize(this.swigCPtr);
    }

    public virtual void SetCanvasObject(CSVisualObject canvas)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetCanvasObject(this.swigCPtr, CSVisualObject.getCPtr(canvas));
    }

    public virtual CSRect RectApplyTransform(Rectangle rect, CSMatrix mat)
    {
      CSRect csRect = new CSRect(CocoStudioEngineAdapterPINVOKE.CSComControlNode_RectApplyTransform(this.swigCPtr, Rect.getCPtr(new Rect((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height)), CSMatrix.getCPtr(mat)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return csRect;
    }

    public virtual void SetMat(CSMatrix mat)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetMat(this.swigCPtr, CSMatrix.getCPtr(mat));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual CSMatrix GetMat()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_GetMat(this.swigCPtr), true);
    }

    public virtual void SetOriginMat(CSMatrix mat)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetOriginMat(this.swigCPtr, CSMatrix.getCPtr(mat));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual CSMatrix GetOriginMat()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_GetOriginMat(this.swigCPtr), true);
    }

    public virtual void SetEnable(bool enable)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetEnable(this.swigCPtr, enable);
    }

    public virtual bool IsEnable()
    {
      return CocoStudioEngineAdapterPINVOKE.CSComControlNode_IsEnable(this.swigCPtr);
    }

    public virtual int GetControlPointType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSComControlNode_GetControlPointType(this.swigCPtr);
    }

    public virtual CSMatrix GetMatrixWithoutReCalculate()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_GetMatrixWithoutReCalculate(this.swigCPtr), true);
    }

    public virtual CSMatrix Mat4Multiply(CSMatrix pM1, CSMatrix pM2)
    {
      CSMatrix csMatrix = new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_Mat4Multiply(this.swigCPtr, CSMatrix.getCPtr(pM1), CSMatrix.getCPtr(pM2)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return csMatrix;
    }

    public virtual CSMatrix Mat4Inverse(CSMatrix pM)
    {
      CSMatrix csMatrix = new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_Mat4Inverse(this.swigCPtr, CSMatrix.getCPtr(pM)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return csMatrix;
    }

    public virtual CSMatrix Mat4Identity(CSMatrix pM)
    {
      CSMatrix csMatrix = new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSComControlNode_Mat4Identity(this.swigCPtr, CSMatrix.getCPtr(pM)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return csMatrix;
    }

    public virtual MatrixNode Mat4ToMatrixNode(CSMatrix mat)
    {
      MatrixNode matrixNode = new MatrixNode(CocoStudioEngineAdapterPINVOKE.CSComControlNode_Mat4ToMatrixNode(this.swigCPtr, CSMatrix.getCPtr(mat)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return matrixNode;
    }

    public virtual PointF TransformPoint(PointF p, CSMatrix mat)
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSComControlNode_TransformPoint(this.swigCPtr, Vec2.getCPtr(new Vec2(p.X, p.Y)), CSMatrix.getCPtr(mat)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return new PointF(vec2.x, vec2.y);
    }

    public virtual void SetAnchorPointVisiable(bool isVisiable)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetAnchorPointVisiable(this.swigCPtr, isVisiable);
    }

    public virtual void SetControlPointVisiable(bool isVisiable)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetControlPointVisiable(this.swigCPtr, isVisiable);
    }

    public virtual void SetAttachNode(CSNode node)
    {
      CocoStudioEngineAdapterPINVOKE.CSComControlNode_SetAttachNode(this.swigCPtr, CSNode.getCPtr(node));
    }
  }
}
