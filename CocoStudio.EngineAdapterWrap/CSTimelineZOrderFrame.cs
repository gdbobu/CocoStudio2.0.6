// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineZOrderFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineZOrderFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineZOrderFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineZOrderFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineZOrderFrame(CSTimelineZOrderFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineZOrderFrame__SWIG_0(CSTimelineZOrderFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineZOrderFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineZOrderFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineZOrderFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineZOrderFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineZOrderFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineZOrderFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetZOrder(int zorder)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineZOrderFrame_SetZOrder(this.swigCPtr, zorder);
    }

    public virtual int GetZOrder()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineZOrderFrame_GetZOrder(this.swigCPtr);
    }
  }
}
