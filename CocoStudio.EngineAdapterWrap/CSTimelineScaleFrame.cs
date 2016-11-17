// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineScaleFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineScaleFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineScaleFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineScaleFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineScaleFrame(CSTimelineScaleFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineScaleFrame__SWIG_0(CSTimelineScaleFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineScaleFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineScaleFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineScaleFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineScaleFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineScaleFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineScaleFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetScaleX(float scaleX)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineScaleFrame_SetScaleX(this.swigCPtr, scaleX);
    }

    public virtual float GetScaleX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineScaleFrame_GetScaleX(this.swigCPtr);
    }

    public virtual void SetScaleY(float scaleY)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineScaleFrame_SetScaleY(this.swigCPtr, scaleY);
    }

    public virtual float GetScaleY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineScaleFrame_GetScaleY(this.swigCPtr);
    }
  }
}
