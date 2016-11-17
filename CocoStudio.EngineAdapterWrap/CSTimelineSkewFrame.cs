// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineSkewFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineSkewFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineSkewFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineSkewFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineSkewFrame(CSTimelineSkewFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineSkewFrame__SWIG_0(CSTimelineSkewFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineSkewFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineSkewFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineSkewFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineSkewFrame obj)
    {
      return obj == null ? new HandleRef((object) null, IntPtr.Zero) : obj.swigCPtr;
    }

    public override void Dispose()
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineSkewFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineSkewFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetSkewX(float skewx)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineSkewFrame_SetSkewX(this.swigCPtr, skewx);
    }

    public virtual float GetSkewX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineSkewFrame_GetSkewX(this.swigCPtr);
    }

    public virtual void SetSkewY(float skewy)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineSkewFrame_SetSkewY(this.swigCPtr, skewy);
    }

    public virtual float GetSkewY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineSkewFrame_GetSkewY(this.swigCPtr);
    }
  }
}
