// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Rect
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  internal class Rect : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Vec2 origin
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Rect_origin_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Rect_origin_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Size size
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Rect_size_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Size) null : new Size(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Rect_size_set(this.swigCPtr, Size.getCPtr(value));
      }
    }

    public static Rect ZERO
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Rect_ZERO_get();
        return cPtr == IntPtr.Zero ? (Rect) null : new Rect(cPtr, false);
      }
    }

    public Rect(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Rect()
      : this(CocoStudioEngineAdapterPINVOKE.new_Rect__SWIG_0(), true)
    {
    }

    public Rect(float x, float y, float width, float height)
      : this(CocoStudioEngineAdapterPINVOKE.new_Rect__SWIG_1(x, y, width, height), true)
    {
    }

    public Rect(Rect other)
      : this(CocoStudioEngineAdapterPINVOKE.new_Rect__SWIG_2(Rect.getCPtr(other)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~Rect()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Rect obj)
    {
      return obj == null ? new HandleRef((object) null, IntPtr.Zero) : obj.swigCPtr;
    }

    public virtual void Dispose()
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
                CocoStudioEngineAdapterPINVOKE.delete_Rect(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Rect(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void setRect(float x, float y, float width, float height)
    {
      CocoStudioEngineAdapterPINVOKE.Rect_setRect(this.swigCPtr, x, y, width, height);
    }

    public float getMinX()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMinX(this.swigCPtr);
    }

    public float getMidX()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMidX(this.swigCPtr);
    }

    public float getMaxX()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMaxX(this.swigCPtr);
    }

    public float getMinY()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMinY(this.swigCPtr);
    }

    public float getMidY()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMidY(this.swigCPtr);
    }

    public float getMaxY()
    {
      return CocoStudioEngineAdapterPINVOKE.Rect_getMaxY(this.swigCPtr);
    }

    public bool equals(Rect rect)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Rect_equals(this.swigCPtr, Rect.getCPtr(rect));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public bool containsPoint(Vec2 point)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Rect_containsPoint(this.swigCPtr, Vec2.getCPtr(point));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public bool intersectsRect(Rect rect)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Rect_intersectsRect(this.swigCPtr, Rect.getCPtr(rect));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public Rect unionWithRect(Rect rect)
    {
      Rect rect1 = new Rect(CocoStudioEngineAdapterPINVOKE.Rect_unionWithRect(this.swigCPtr, Rect.getCPtr(rect)), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return rect1;
    }
  }
}
