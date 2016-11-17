// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Quad2
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Quad2 : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Vec2 tl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad2_tl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad2_tl_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Vec2 tr
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad2_tr_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad2_tr_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Vec2 bl
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad2_bl_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad2_bl_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Vec2 br
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.Quad2_br_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Quad2_br_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Quad2(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Quad2()
      : this(CocoStudioEngineAdapterPINVOKE.new_Quad2(), true)
    {
    }

    ~Quad2()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Quad2 obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Quad2(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Quad2(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
