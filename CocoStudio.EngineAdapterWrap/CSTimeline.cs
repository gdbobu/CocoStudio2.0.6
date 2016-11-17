// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimeline
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimeline : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSTimeline(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimeline()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimeline(), true)
    {
    }

    ~CSTimeline()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimeline obj)
    {
      return obj == null ? new HandleRef((object) null, IntPtr.Zero) : obj.swigCPtr;
    }

    public virtual void Dispose()
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimeline(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimeline(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public virtual void SetActionObject(CSVisualObject visualNodeHandle)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_SetActionObject(this.swigCPtr, CSVisualObject.getCPtr(visualNodeHandle));
    }

    public virtual CSVisualObject GetActionObject()
    {
      IntPtr actionObject = CocoStudioEngineAdapterPINVOKE.CSTimeline_GetActionObject(this.swigCPtr);
      return actionObject == IntPtr.Zero ? (CSVisualObject) null : new CSVisualObject(actionObject, false);
    }

    public virtual void SetActionTag(int tag)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_SetActionTag(this.swigCPtr, tag);
    }

    public virtual int GetActionTag()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimeline_GetActionTag(this.swigCPtr);
    }

    public virtual void GotoFrame(int frameIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_GotoFrame(this.swigCPtr, frameIndex);
    }

    public virtual void InsertFrame(int index, CSTimelineFrame frame)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_InsertFrame(this.swigCPtr, index, CSTimelineFrame.getCPtr(frame));
    }

    public virtual void RemoveFrame(CSTimelineFrame frame)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_RemoveFrame(this.swigCPtr, CSTimelineFrame.getCPtr(frame));
    }

    public virtual void ClearSearchState()
    {
      CocoStudioEngineAdapterPINVOKE.CSTimeline_ClearSearchState(this.swigCPtr);
    }
  }
}
