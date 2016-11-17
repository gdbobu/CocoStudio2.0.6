// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineFrame : CSObject
  {
    private HandleRef swigCPtr;

    public CSTimelineFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineFrame(), true)
    {
    }

    ~CSTimelineFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual int GetFrameIndex()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_GetFrameIndex(this.swigCPtr);
    }

    public virtual void SetFrameIndex(int iIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_SetFrameIndex(this.swigCPtr, iIndex);
    }

    public virtual CSVisualObject GetActionObject()
    {
      IntPtr actionObject = CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_GetActionObject(this.swigCPtr);
      return actionObject == IntPtr.Zero ? (CSVisualObject) null : new CSVisualObject(actionObject, false);
    }

    public virtual void SetActionObject(CSVisualObject csObject)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_SetActionObject(this.swigCPtr, CSVisualObject.getCPtr(csObject));
    }

    public virtual void SetTween(bool tween)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_SetTween(this.swigCPtr, tween);
    }

    public virtual bool IsTween()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_IsTween(this.swigCPtr);
    }

    public virtual void OnEnter(CSTimelineFrame nextFrame)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineFrame_OnEnter(this.swigCPtr, CSTimelineFrame.getCPtr(nextFrame));
    }
  }
}
