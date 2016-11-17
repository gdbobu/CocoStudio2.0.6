// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.V3F_T2F_Quad
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class V3F_T2F_Quad : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public V3F_T2F bl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_bl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (V3F_T2F) null : new V3F_T2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_bl_set(this.swigCPtr, V3F_T2F.getCPtr(value));
      }
    }

    public V3F_T2F br
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_br_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (V3F_T2F) null : new V3F_T2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_br_set(this.swigCPtr, V3F_T2F.getCPtr(value));
      }
    }

    public V3F_T2F tl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_tl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (V3F_T2F) null : new V3F_T2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_tl_set(this.swigCPtr, V3F_T2F.getCPtr(value));
      }
    }

    public V3F_T2F tr
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_tr_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (V3F_T2F) null : new V3F_T2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_Quad_tr_set(this.swigCPtr, V3F_T2F.getCPtr(value));
      }
    }

    public V3F_T2F_Quad(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public V3F_T2F_Quad()
      : this(CocoStudioEngineAdapterPINVOKE.new_V3F_T2F_Quad(), true)
    {
    }

    ~V3F_T2F_Quad()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(V3F_T2F_Quad obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_V3F_T2F_Quad(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_V3F_T2F_Quad(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
