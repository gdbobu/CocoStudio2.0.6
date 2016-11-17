// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Color3B
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Color3B : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public byte r
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color3B_r_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color3B_r_set(this.swigCPtr, value);
      }
    }

    public byte g
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color3B_g_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color3B_g_set(this.swigCPtr, value);
      }
    }

    public byte b
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Color3B_b_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Color3B_b_set(this.swigCPtr, value);
      }
    }

    public static Color3B WHITE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_WHITE_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B YELLOW
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_YELLOW_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B BLUE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_BLUE_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B GREEN
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_GREEN_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B RED
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_RED_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B MAGENTA
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_MAGENTA_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B BLACK
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_BLACK_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B ORANGE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_ORANGE_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public static Color3B GRAY
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Color3B_GRAY_get();
        return cPtr == IntPtr.Zero ? (Color3B) null : new Color3B(cPtr, false);
      }
    }

    public Color3B(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Color3B()
      : this(CocoStudioEngineAdapterPINVOKE.new_Color3B__SWIG_0(), true)
    {
    }

    public Color3B(byte _r, byte _g, byte _b)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color3B__SWIG_1(_r, _g, _b), true)
    {
    }

    public Color3B(Color4B color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color3B__SWIG_2(Color4B.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public Color3B(Color4F color)
      : this(CocoStudioEngineAdapterPINVOKE.new_Color3B__SWIG_3(Color4F.getCPtr(color)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~Color3B()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Color3B obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Color3B(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Color3B(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public bool equals(Color3B other)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.Color3B_equals(this.swigCPtr, Color3B.getCPtr(other));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }
  }
}
