// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineInnerActionFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineInnerActionFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineInnerActionFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineInnerActionFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineInnerActionFrame(CSTimelineInnerActionFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineInnerActionFrame__SWIG_0(CSTimelineInnerActionFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineInnerActionFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineInnerActionFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineInnerActionFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineInnerActionFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineInnerActionFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineInnerActionFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetInnerActionType(int type)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineInnerActionFrame_SetInnerActionType(this.swigCPtr, type);
    }

    public virtual int GetInnerActionType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineInnerActionFrame_GetInnerActionType(this.swigCPtr);
    }

    public virtual void SetStartFrameIndex(int frameIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineInnerActionFrame_SetStartFrameIndex(this.swigCPtr, frameIndex);
    }

    public virtual int GetStartFrameIndex()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineInnerActionFrame_GetStartFrameIndex(this.swigCPtr);
    }
  }
}
