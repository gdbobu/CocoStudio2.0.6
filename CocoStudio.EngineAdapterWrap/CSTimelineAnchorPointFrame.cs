// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineAnchorPointFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineAnchorPointFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineAnchorPointFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineAnchorPointFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineAnchorPointFrame(CSTimelineAnchorPointFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineAnchorPointFrame__SWIG_0(CSTimelineAnchorPointFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineAnchorPointFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineAnchorPointFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineAnchorPointFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineAnchorPointFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineAnchorPointFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineAnchorPointFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetAnchorPointX(float x)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAnchorPointFrame_SetAnchorPointX(this.swigCPtr, x);
    }

    public virtual float GetAnchorPointX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAnchorPointFrame_GetAnchorPointX(this.swigCPtr);
    }

    public virtual void SetAnchorPointY(float y)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAnchorPointFrame_SetAnchorPointY(this.swigCPtr, y);
    }

    public virtual float GetAnchorPointY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAnchorPointFrame_GetAnchorPointY(this.swigCPtr);
    }
  }
}
