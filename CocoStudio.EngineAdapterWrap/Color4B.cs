// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Color4B
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Color4B : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public byte r
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4B_r_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4B_r_set(this.swigCPtr, value);
      }
    }

    public byte g
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4B_g_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4B_g_set(this.swigCPtr, value);
      }
    }

    public byte b
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4B_b_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4B_b_set(this.swigCPtr, value);
      }
    }

    public byte a
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color4B_a_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color4B_a_set(this.swigCPtr, value);
      }
    }

    public static Color4B WHITE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_WHITE_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B YELLOW
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_YELLOW_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B BLUE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_BLUE_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B GREEN
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_GREEN_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B RED
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_RED_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B MAGENTA
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_MAGENTA_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B BLACK
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_BLACK_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B ORANGE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_ORANGE_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public static Color4B GRAY
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color4B_GRAY_get();
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
    }

    public Color4B(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Color4B()
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4B__SWIG_0(), true)
    {
    }

    public Color4B(byte _r, byte _g, byte _b, byte _a)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4B__SWIG_1(_r, _g, _b, _a), true)
    {
    }

    public Color4B(Color3B color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4B__SWIG_2(Color3B.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public Color4B(Color4F color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color4B__SWIG_3(Color4F.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~Color4B()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Color4B obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Color4B(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Color4B(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
