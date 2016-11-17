// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Color4F
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Color4F : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public float r
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4F_r_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4F_r_set(this.swigCPtr, value);
      }
    }

    public float g
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4F_g_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4F_g_set(this.swigCPtr, value);
      }
    }

    public float b
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4F_b_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4F_b_set(this.swigCPtr, value);
      }
    }

    public float a
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4F_a_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4F_a_set(this.swigCPtr, value);
      }
    }

    public static Color4F WHITE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_WHITE_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F YELLOW
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_YELLOW_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F BLUE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_BLUE_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F GREEN
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_GREEN_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F RED
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_RED_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F MAGENTA
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_MAGENTA_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F BLACK
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_BLACK_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F ORANGE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_ORANGE_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public static Color4F GRAY
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4F_GRAY_get();
        return cPtr == IntPtr.Zero ? (Color4F) null : new Color4F(cPtr, false);
      }
    }

    public Color4F(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Color4F()
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4F__SWIG_0(), true)
    {
    }

    public Color4F(float _r, float _g, float _b, float _a)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4F__SWIG_1(_r, _g, _b, _a), true)
    {
    }

    public Color4F(Color3B color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4F__SWIG_2(Color3B.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public Color4F(Color4B color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4F__SWIG_3(Color4B.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~Color4F()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Color4F obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Color4F(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Color4F(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public bool equals(Color4F other)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Color4F_equals(this.swigCPtr, Color4F.getCPtr(other));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }
  }
}
