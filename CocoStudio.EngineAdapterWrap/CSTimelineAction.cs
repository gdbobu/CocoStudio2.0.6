// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineAction
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineAction : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSTimelineAction(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineAction(CSTimelineAction csAction)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineAction__SWIG_0(CSTimelineAction.getCPtr(csAction)), true)
    {
    }

    public CSTimelineAction()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineAction__SWIG_1(), true)
    {
    }

    ~CSTimelineAction()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineAction obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineAction(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineAction(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void SetOnionSkinPreNum(int preSkinNum)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetOnionSkinPreNum(this.swigCPtr, preSkinNum);
    }

    public int GetOnionSkinPreNum()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetOnionSkinPreNum(this.swigCPtr);
    }

    public void SetOnionSkinSuffNum(int suffSkinNum)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetOnionSkinSuffNum(this.swigCPtr, suffSkinNum);
    }

    public int GetOnionSkinSuffNum()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetOnionSkinSuffNum(this.swigCPtr);
    }

    public void SetOnionSkinEnable(bool skinEnable)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetOnionSkinEnable(this.swigCPtr, skinEnable);
    }

    public bool IsOnionSkinEnable()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_IsOnionSkinEnable(this.swigCPtr);
    }

    public void AddOnionSkinKey(int frameIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_AddOnionSkinKey(this.swigCPtr, frameIndex);
    }

    public void RemoveOnionSkinKey(int frameIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_RemoveOnionSkinKey(this.swigCPtr, frameIndex);
    }

    public bool IsOnionKeyFrame(int frameIndex)
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_IsOnionKeyFrame(this.swigCPtr, frameIndex);
    }

    public virtual void GotoFrame(int startIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GotoFrame(this.swigCPtr, startIndex);
    }

    public virtual void Play(int startIndex, int endIndex, int currentFrameIndex, bool loop)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_Play(this.swigCPtr, startIndex, endIndex, currentFrameIndex, loop);
    }

    public virtual void Pause()
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_Pause(this.swigCPtr);
    }

    public virtual void Resume()
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_Resume(this.swigCPtr);
    }

    public virtual void SetTimeSpeed(float speed)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetTimeSpeed(this.swigCPtr, speed);
    }

    public virtual float GetTimeSpeed()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetTimeSpeed(this.swigCPtr);
    }

    public virtual void SetDuration(int duration)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetDuration(this.swigCPtr, duration);
    }

    public virtual int GetDuration()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetDuration(this.swigCPtr);
    }

    public virtual void SetEndFrame(int endFrame)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetEndFrame(this.swigCPtr, endFrame);
    }

    public virtual int GetEndFrame()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetEndFrame(this.swigCPtr);
    }

    public virtual void SetCurrentFrame(int frameIndex)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_SetCurrentFrame(this.swigCPtr, frameIndex);
    }

    public virtual int GetCurrentFrame()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_GetCurrentFrame(this.swigCPtr);
    }

    public virtual void AddTimeline(CSTimeline timeline)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_AddTimeline(this.swigCPtr, CSTimeline.getCPtr(timeline));
    }

    public virtual void RemoveTimeline(CSTimeline timeline)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_RemoveTimeline(this.swigCPtr, CSTimeline.getCPtr(timeline));
    }

    public virtual bool IsPlaying()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineAction_IsPlaying(this.swigCPtr);
    }

    public virtual void InitWithRootNode(CSVisualObject target)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_InitWithRootNode(this.swigCPtr, CSVisualObject.getCPtr(target));
    }

    public virtual void ActiveAction(CSVisualObject target)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineAction_ActiveAction(this.swigCPtr, CSVisualObject.getCPtr(target));
    }
  }
}
