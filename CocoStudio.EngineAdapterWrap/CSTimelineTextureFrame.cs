// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineTextureFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineTextureFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineTextureFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineTextureFrame(CSTimelineTextureFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineTextureFrame__SWIG_0(CSTimelineTextureFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineTextureFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineTextureFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineTextureFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineTextureFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineTextureFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineTextureFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetTexture(string texture)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_SetTexture(this.swigCPtr, texture);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetTexture()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_GetTexture(this.swigCPtr);
    }

    public virtual void SetPlist(string plist)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_SetPlist(this.swigCPtr, plist);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetPlist()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_GetPlist(this.swigCPtr);
    }

    public virtual void SetFrameEnterCallBack(CSTimelineTextureFrame.FrameEnterCallBack callback)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineTextureFrame_SetFrameEnterCallBack(this.swigCPtr, callback);
    }

    public delegate void FrameEnterCallBack();
  }
}
