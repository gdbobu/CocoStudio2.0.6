// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.T2F_Quad
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class T2F_Quad : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Tex2F bl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.T2F_Quad_bl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Tex2F) null : new Tex2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.T2F_Quad_bl_set(this.swigCPtr, Tex2F.getCPtr(value));
      }
    }

    public Tex2F br
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.T2F_Quad_br_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Tex2F) null : new Tex2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.T2F_Quad_br_set(this.swigCPtr, Tex2F.getCPtr(value));
      }
    }

    public Tex2F tl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.T2F_Quad_tl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Tex2F) null : new Tex2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.T2F_Quad_tl_set(this.swigCPtr, Tex2F.getCPtr(value));
      }
    }

    public Tex2F tr
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.T2F_Quad_tr_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Tex2F) null : new Tex2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.T2F_Quad_tr_set(this.swigCPtr, Tex2F.getCPtr(value));
      }
    }

    public T2F_Quad(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public T2F_Quad()
      : this(CocoStudioEngineAdapterPINVOKE.new_T2F_Quad(), true)
    {
    }

    ~T2F_Quad()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(T2F_Quad obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_T2F_Quad(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_T2F_Quad(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
