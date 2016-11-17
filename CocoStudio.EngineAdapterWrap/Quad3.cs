// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Quad3
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Quad3 : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Vec3 bl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad3_bl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec3) null : new Vec3(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad3_bl_set(this.swigCPtr, Vec3.getCPtr(value));
      }
    }

    public Vec3 br
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad3_br_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec3) null : new Vec3(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad3_br_set(this.swigCPtr, Vec3.getCPtr(value));
      }
    }

    public Vec3 tl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad3_tl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec3) null : new Vec3(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad3_tl_set(this.swigCPtr, Vec3.getCPtr(value));
      }
    }

    public Vec3 tr
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad3_tr_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec3) null : new Vec3(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad3_tr_set(this.swigCPtr, Vec3.getCPtr(value));
      }
    }

    public Quad3(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Quad3()
      : this(CocoStudioEngineAdapterPINVOKE.new_Quad3(), true)
    {
    }

    ~Quad3()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Quad3 obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Quad3(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Quad3(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
