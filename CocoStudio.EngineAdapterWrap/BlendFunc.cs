// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.BlendFunc
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class BlendFunc : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public uint src
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.BlendFunc_src_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.BlendFunc_src_set(this.swigCPtr, value);
      }
    }

    public uint dst
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.BlendFunc_dst_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.BlendFunc_dst_set(this.swigCPtr, value);
      }
    }

    public static BlendFunc DISABLE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.BlendFunc_DISABLE_get();
        return cPtr == IntPtr.Zero ? (BlendFunc) null : new BlendFunc(cPtr, false);
      }
    }

    public static BlendFunc ALPHA_PREMULTIPLIED
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.BlendFunc_ALPHA_PREMULTIPLIED_get();
        return cPtr == IntPtr.Zero ? (BlendFunc) null : new BlendFunc(cPtr, false);
      }
    }

    public static BlendFunc ALPHA_NON_PREMULTIPLIED
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.BlendFunc_ALPHA_NON_PREMULTIPLIED_get();
        return cPtr == IntPtr.Zero ? (BlendFunc) null : new BlendFunc(cPtr, false);
      }
    }

    public static BlendFunc ADDITIVE
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.BlendFunc_ADDITIVE_get();
        return cPtr == IntPtr.Zero ? (BlendFunc) null : new BlendFunc(cPtr, false);
      }
    }

    public BlendFunc(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public BlendFunc()
      : this(CocoStudioEngineAdapterPINVOKE.new_BlendFunc(), true)
    {
    }

    ~BlendFunc()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(BlendFunc obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_BlendFunc(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_BlendFunc(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
