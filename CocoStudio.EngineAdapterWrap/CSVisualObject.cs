// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVisualObject
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSVisualObject : CSObject
  {
    private HandleRef swigCPtr;

    protected internal CSVisualObject()
    {
    }

    public CSVisualObject(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSVisualObject_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public static HandleRef getCPtr(CSVisualObject obj)
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
            if (!this.IsContainOpenGLResource())
              throw new MethodAccessException("C++ destructor does not have public access");
            GtkInvokeHelp.BeginInvoke((Action) (() =>
            {
              this.swigCPtr = handle;
              throw new MethodAccessException("C++ destructor does not have public access");
            }));
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual string GetName()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetName(this.swigCPtr);
    }

    public virtual void SetName(string nameStr)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetName(this.swigCPtr, nameStr);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual CocoStudio.Model.PointF GetRelativePosition()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetRelativePosition(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual void SetRelativePosition(CocoStudio.Model.PointF cPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetRelativePosition(this.swigCPtr, Vec2.getCPtr(new Vec2(cPoint.X, cPoint.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual CocoStudio.Model.PointF GetPosition()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetPosition(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual void SetPosition(CocoStudio.Model.PointF position)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetPosition(this.swigCPtr, Vec2.getCPtr(new Vec2(position.X, position.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ScaleValue GetAnchorPoint()
    {
      CSScale csScale = new CSScale(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetAnchorPoint(this.swigCPtr), false);
      return new ScaleValue(csScale.GetScaleX(), csScale.GetScaleY(), 0.1, -99999999.0, 99999999.0);
    }

    public virtual void SetAnchorPoint(ScaleValue anchorPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetAnchorPoint(this.swigCPtr, CSScale.getCPtr(new CSScale(anchorPoint.ScaleX, anchorPoint.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ScaleValue GetScale()
    {
      CSScale csScale = new CSScale(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetScale(this.swigCPtr), false);
      return new ScaleValue(csScale.GetScaleX(), csScale.GetScaleY(), 0.1, -99999999.0, 99999999.0);
    }

    public virtual void SetScale(ScaleValue scale)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetScale(this.swigCPtr, CSScale.getCPtr(new CSScale(scale.ScaleX, scale.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual bool GetVisible()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetVisible(this.swigCPtr);
    }

    public virtual void SetVisible(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetVisible(this.swigCPtr, visible);
    }

    public virtual bool GetVisibleForFrame()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetVisibleForFrame(this.swigCPtr);
    }

    public virtual void SetVisibleForFrame(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetVisibleForFrame(this.swigCPtr, visible);
    }

    public virtual string GetFrameEvent()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetFrameEvent(this.swigCPtr);
    }

    public virtual void SetFrameEvent(string frameEvent)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetFrameEvent(this.swigCPtr, frameEvent);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual float GetRotation()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetRotation(this.swigCPtr);
    }

    public virtual void SetRotation(float rotation)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetRotation(this.swigCPtr, rotation);
    }

    public virtual float GetRotationSkewX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetRotationSkewX(this.swigCPtr);
    }

    public virtual void SetRotationSkewX(float rotationSkewX)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetRotationSkewX(this.swigCPtr, rotationSkewX);
    }

    public virtual float GetRotationSkewY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetRotationSkewY(this.swigCPtr);
    }

    public virtual void SetRotationSkewY(float rotationSkewY)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetRotationSkewY(this.swigCPtr, rotationSkewY);
    }

    public virtual int GetZOrder()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetZOrder(this.swigCPtr);
    }

    public virtual void SetZOrder(int zOrder)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetZOrder(this.swigCPtr, zOrder);
    }

    public virtual int GetOrderOfArrival()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetOrderOfArrival(this.swigCPtr);
    }

    public virtual int GetTag()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetTag(this.swigCPtr);
    }

    public virtual void SetTag(int tag)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetTag(this.swigCPtr, tag);
    }

    public virtual System.Drawing.Color GetColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetColor(this.swigCPtr), true);
      return System.Drawing.Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetColor(System.Drawing.Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual int GetAlpha()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetAlpha(this.swigCPtr);
    }

    public virtual void SetAlpha(int alpha)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetAlpha(this.swigCPtr, alpha);
    }

    public virtual bool IsAutoSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSVisualObject_IsAutoSize(this.swigCPtr);
    }

    public virtual void SetAutoSize(bool bAuto)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetAutoSize(this.swigCPtr, bAuto);
    }

    public virtual CocoStudio.Model.PointF GetSize()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetSize(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual void SetSize(CocoStudio.Model.PointF cSize)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_SetSize(this.swigCPtr, Vec2.getCPtr(new Vec2(cSize.X, cSize.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual CocoStudio.Model.PointF GetBoundingAnchorPoint()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetBoundingAnchorPoint(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual CocoStudio.Model.PointF GetBoundingSize()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetBoundingSize(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual void AddChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_AddChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public virtual void InsertChild(int index, CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_InsertChild(this.swigCPtr, index, CSVisualObject.getCPtr(child));
    }

    public virtual void RemoveChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSVisualObject_RemoveChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public virtual int HitTest(CocoStudio.Model.PointF point)
    {
      int num = CocoStudioEngineAdapterPINVOKE.CSVisualObject_HitTest(this.swigCPtr, Vec2.getCPtr(new Vec2(point.X, point.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return num;
    }

    public virtual bool RectTest(Gdk.Rectangle rect)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.CSVisualObject_RectTest(this.swigCPtr, Rect.getCPtr(new Rect((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public virtual CocoStudio.Model.PointF TransformToSelf(CocoStudio.Model.PointF scenePoint)
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_TransformToSelf(this.swigCPtr, Vec2.getCPtr(new Vec2(scenePoint.X, scenePoint.Y))), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual CocoStudio.Model.PointF TransformToScene(CocoStudio.Model.PointF selfPoint)
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_TransformToScene(this.swigCPtr, Vec2.getCPtr(new Vec2(selfPoint.X, selfPoint.Y))), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual CocoStudio.Model.PointF TransformToParent(CocoStudio.Model.PointF selfPoint)
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_TransformToParent(this.swigCPtr, Vec2.getCPtr(new Vec2(selfPoint.X, selfPoint.Y))), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }

    public virtual CSMatrix GetMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix GetWorldMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetWorldMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix GetAnchorMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetAnchorMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix GetAnchorWorldMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetAnchorWorldMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix GetParentMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetParentMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix GetParentWorldMatrix()
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetParentWorldMatrix(this.swigCPtr), true);
    }

    public virtual CSMatrix ConvertToNodeMatrix(CSVisualObject dst)
    {
      return new CSMatrix(CocoStudioEngineAdapterPINVOKE.CSVisualObject_ConvertToNodeMatrix(this.swigCPtr, CSVisualObject.getCPtr(dst)), true);
    }

    public virtual CocoStudio.Model.PointF GetAnchorPointInPoints()
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSVisualObject_GetAnchorPointInPoints(this.swigCPtr), true);
      return new CocoStudio.Model.PointF(vec2.x, vec2.y);
    }
  }
}
