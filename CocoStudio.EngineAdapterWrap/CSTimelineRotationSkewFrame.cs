// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineRotationSkewFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineRotationSkewFrame : CSTimelineSkewFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineRotationSkewFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineRotationSkewFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineRotationSkewFrame(CSTimelineRotationSkewFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineRotationSkewFrame__SWIG_0(CSTimelineRotationSkewFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineRotationSkewFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineRotationSkewFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineRotationSkewFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineRotationSkewFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineRotationSkewFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineRotationSkewFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }
  }
}
