// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineEventFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineEventFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineEventFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineEventFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineEventFrame(CSTimelineEventFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineEventFrame__SWIG_0(CSTimelineEventFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineEventFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineEventFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineEventFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineEventFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineEventFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineEventFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetEvent(string arg0)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineEventFrame_SetEvent(this.swigCPtr, arg0);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetEvent()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineEventFrame_GetEvent(this.swigCPtr);
    }
  }
}
