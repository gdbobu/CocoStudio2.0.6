// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineVisibleFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineVisibleFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineVisibleFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineVisibleFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineVisibleFrame(CSTimelineVisibleFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineVisibleFrame__SWIG_0(CSTimelineVisibleFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineVisibleFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineVisibleFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineVisibleFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineVisibleFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineVisibleFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineVisibleFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetVisible(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineVisibleFrame_SetVisible(this.swigCPtr, visible);
    }

    public virtual bool IsVisible()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineVisibleFrame_IsVisible(this.swigCPtr);
    }
  }
}
