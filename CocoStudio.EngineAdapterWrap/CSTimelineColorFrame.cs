// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTimelineColorFrame
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTimelineColorFrame : CSTimelineFrame
  {
    private HandleRef swigCPtr;

    public CSTimelineColorFrame(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTimelineColorFrame_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTimelineColorFrame(CSTimelineColorFrame csFrame)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineColorFrame__SWIG_0(CSTimelineColorFrame.getCPtr(csFrame)), true)
    {
    }

    public CSTimelineColorFrame()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTimelineColorFrame__SWIG_1(), true)
    {
    }

    ~CSTimelineColorFrame()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTimelineColorFrame obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTimelineColorFrame(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTimelineColorFrame(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public virtual void SetAlpha(int alpha)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineColorFrame_SetAlpha(this.swigCPtr, alpha);
    }

    public virtual int GetAlpha()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTimelineColorFrame_GetAlpha(this.swigCPtr);
    }

    public virtual void SetColor(Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSTimelineColorFrame_SetColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual Color GetColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSTimelineColorFrame_GetColor(this.swigCPtr), true);
      return Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }
  }
}
