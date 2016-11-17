// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineRotationFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineRotationFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineRotationFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineRotationFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineRotationFrame(CSTimelineRotationFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineRotationFrame__SWIG_0(CSTimelineRotationFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineRotationFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineRotationFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineRotationFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineRotationFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineRotationFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineRotationFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetRotation(float fRotation)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineRotationFrame_SetRotation(this.swigCPtr, fRotation);
    }

    public virtual bool GetRotation()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineRotationFrame_GetRotation(this.swigCPtr);
    }
  }
}
