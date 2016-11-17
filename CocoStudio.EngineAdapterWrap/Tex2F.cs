// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Tex2F
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Tex2F : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public float u
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Tex2F_u_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Tex2F_u_set(this.swigCPtr, value);
      }
    }

    public float v
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Tex2F_v_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Tex2F_v_set(this.swigCPtr, value);
      }
    }

    public Tex2F(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Tex2F(float _u, float _v)
      : this(CocoStudioEngineAdapterPINVOKE.new_Tex2F__SWIG_0(_u, _v), true)
    {
    }

    public Tex2F()
      : this(CocoStudioEngineAdapterPINVOKE.new_Tex2F__SWIG_1(), true)
    {
    }

    ~Tex2F()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Tex2F obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Tex2F(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Tex2F(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
