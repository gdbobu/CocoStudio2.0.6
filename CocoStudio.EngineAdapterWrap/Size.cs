// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Size
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  internal class Size : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public float width
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Size_width_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Size_width_set(this.swigCPtr, value);
      }
    }

    public float height
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Size_height_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Size_height_set(this.swigCPtr, value);
      }
    }

    public static Size ZERO
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Size_ZERO_get();
        return cPtr == IntPtr.Zero ? (Size) null : new Size(cPtr, false);
      }
    }

    public Size(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Size()
      : this(CocoStudioEngineAdapterPINVOKE.new_Size__SWIG_0(), true)
    {
    }

    public Size(float width, float height)
      : this(CocoStudioEngineAdapterPINVOKE.new_Size__SWIG_1(width, height), true)
    {
    }

    public Size(Size other)
      : this(CocoStudioEngineAdapterPINVOKE.new_Size__SWIG_2(Size.getCPtr(other)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public Size(Vec2 point)
      : this(CocoStudioEngineAdapterPINVOKE.new_Size__SWIG_3(Vec2.getCPtr(point)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~Size()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Size obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Size(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Size(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void setSize(float width, float height)
    {
      CocoStudioEngineAdapterPINVOKE.Size_setSize(this.swigCPtr, width, height);
    }

    public bool equals(Size target)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Size_equals(this.swigCPtr, Size.getCPtr(target));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }
  }
}
