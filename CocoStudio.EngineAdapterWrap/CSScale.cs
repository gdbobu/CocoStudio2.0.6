// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSScale
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSScale : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSScale(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSScale()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSScale__SWIG_0(), true)
    {
    }

    public CSScale(ScaleValue scale)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSScale__SWIG_1(CSScale.getCPtr(new CSScale(scale.ScaleX, scale.ScaleY))), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public CSScale(float scaleX, float scaleY)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSScale__SWIG_2(scaleX, scaleY), true)
    {
    }

    ~CSScale()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSScale obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSScale(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSScale(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void SetScale(float scaleX, float scaleY)
    {
      CocoStudioEngineAdapterPINVOKE.CSScale_SetScale(this.swigCPtr, scaleX, scaleY);
    }

    public void SetScaleX(float scaleX)
    {
      CocoStudioEngineAdapterPINVOKE.CSScale_SetScaleX(this.swigCPtr, scaleX);
    }

    public float GetScaleX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSScale_GetScaleX(this.swigCPtr);
    }

    public void SetScaleY(float scaleY)
    {
      CocoStudioEngineAdapterPINVOKE.CSScale_SetScaleY(this.swigCPtr, scaleY);
    }

    public float GetScaleY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSScale_GetScaleY(this.swigCPtr);
    }
  }
}
