// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSNode
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using Gdk;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSNode : CSVisualObject
  {
    private HandleRef swigCPtr;

    public CSNode(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSNode_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSNode()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSNode__SWIG_1(), true)
    {
    }

    ~CSNode()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSNode obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSNode(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSNode(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_Init(this.swigCPtr);
    }

    public virtual bool IsPrePositionEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_IsPrePositionEnabled(this.swigCPtr);
    }

    public virtual void SetPrePositionEnabled(bool enable)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPrePositionEnabled(this.swigCPtr, enable);
    }

    public virtual int GetPositionType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_GetPositionType(this.swigCPtr);
    }

    public virtual void SetPositionType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPositionType(this.swigCPtr, iType);
    }

    public virtual PointF GetPrePosition()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSNode_GetPrePosition(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public virtual void SetPrePosition(PointF cPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPrePosition(this.swigCPtr, Vec2.getCPtr(new Vec2(cPoint.X, cPoint.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual bool IsPreSizeEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_IsPreSizeEnabled(this.swigCPtr);
    }

    public virtual void SetPreSizeEnabled(bool enable)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPreSizeEnabled(this.swigCPtr, enable);
    }

    public virtual PointF GetPreSize()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSNode_GetPreSize(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public virtual void SetPreSize(PointF cSize)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPreSize(this.swigCPtr, Vec2.getCPtr(new Vec2(cSize.X, cSize.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual bool GetCascadeColorEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_GetCascadeColorEnabled(this.swigCPtr);
    }

    public virtual void SetCascadeColorEnabled(bool enable)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetCascadeColorEnabled(this.swigCPtr, enable);
    }

    public virtual bool GetCascadeOpacityEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_GetCascadeOpacityEnabled(this.swigCPtr);
    }

    public virtual void SetCascadeOpacityEnabled(bool enable)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetCascadeOpacityEnabled(this.swigCPtr, enable);
    }

    public virtual bool GetIconVisible()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_GetIconVisible(this.swigCPtr);
    }

    public virtual void SetIconVisible(bool visiable)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetIconVisible(this.swigCPtr, visiable);
    }

    public virtual void RefreshBoundingObjects()
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_RefreshBoundingObjects(this.swigCPtr);
    }

    public virtual bool HasFileAndSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSNode_HasFileAndSize(this.swigCPtr);
    }

    public virtual void RefreshLayout()
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_RefreshLayout(this.swigCPtr);
    }

    public virtual CSNode.ObjectState GetObjectState()
    {
      return (CSNode.ObjectState) CocoStudioEngineAdapterPINVOKE.CSNode_GetObjectState(this.swigCPtr);
    }

    public virtual void SetObjectState(CSNode.ObjectState boxState)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetObjectState(this.swigCPtr, (int) boxState);
    }

    public override void SetPosition(PointF position)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetPosition(this.swigCPtr, Vec2.getCPtr(new Vec2(position.X, position.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override void SetScale(ScaleValue scale)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetScale(this.swigCPtr, CSScale.getCPtr(new CSScale(scale.ScaleX, scale.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override void SetAnchorPoint(ScaleValue anchorPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetAnchorPoint(this.swigCPtr, CSScale.getCPtr(new CSScale(anchorPoint.ScaleX, anchorPoint.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override PointF GetRelativePosition()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSNode_GetRelativePosition(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public override void SetRelativePosition(PointF cPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetRelativePosition(this.swigCPtr, Vec2.getCPtr(new Vec2(cPoint.X, cPoint.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override void SetSize(PointF cPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetSize(this.swigCPtr, Vec2.getCPtr(new Vec2(cPoint.X, cPoint.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override PointF GetBoundingAnchorPoint()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSNode_GetBoundingAnchorPoint(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public override PointF GetBoundingSize()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSNode_GetBoundingSize(this.swigCPtr), true);
      return new PointF(vec2.x, vec2.y);
    }

    public override int HitTest(PointF point)
    {
      int num = CocoStudioEngineAdapterPINVOKE.CSNode_HitTest(this.swigCPtr, Vec2.getCPtr(new Vec2(point.X, point.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return num;
    }

    public override bool RectTest(Rectangle rect)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.CSNode_RectTest(this.swigCPtr, Rect.getCPtr(new Rect((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public override CSMatrix GetWorldMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSNode_GetWorldMatrix(this.swigCPtr), true);
    }

    public override CSMatrix GetAnchorWorldMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSNode_GetAnchorWorldMatrix(this.swigCPtr), true);
    }

    public override void SetAutoSize(bool bAuto)
    {
      CocoStudioEngineAdapterPINVOKE.CSNode_SetAutoSize(this.swigCPtr, bAuto);
    }

    public enum ObjectState
    {
      Default,
      DragOver,
      Seleted,
    }
  }
}
