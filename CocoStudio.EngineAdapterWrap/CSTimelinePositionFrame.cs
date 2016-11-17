// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelinePositionFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelinePositionFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelinePositionFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelinePositionFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelinePositionFrame(CSTimelinePositionFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelinePositionFrame__SWIG_0(CSTimelinePositionFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelinePositionFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelinePositionFrame__SWIG_1(), true)
    {
    }

    ~CSTimelinePositionFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelinePositionFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelinePositionFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelinePositionFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetX(float x)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelinePositionFrame_SetX(this.swigCPtr, x);
    }

    public virtual float GetX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelinePositionFrame_GetX(this.swigCPtr);
    }

    public virtual void SetY(float y)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelinePositionFrame_SetY(this.swigCPtr, y);
    }

    public virtual float GetY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelinePositionFrame_GetY(this.swigCPtr);
    }
  }
}
