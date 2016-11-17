// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSText
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSText : CSWidget
  {
    private HandleRef swigCPtr;

    public CSText(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSText_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSText()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSText(), true)
    {
    }

    ~CSText()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSText obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSText(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSText(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSText_Init(this.swigCPtr);
    }

    public override void SetSizeCustomEnabled(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetSizeCustomEnabled(this.swigCPtr, bEnabled);
    }

    public virtual bool GetFlipX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetFlipX(this.swigCPtr);
    }

    public virtual void SetFlipX(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetFlipX(this.swigCPtr, flip);
    }

    public virtual bool GetFlipY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetFlipY(this.swigCPtr);
    }

    public virtual void SetFlipY(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetFlipY(this.swigCPtr, flip);
    }

    public virtual string GetFontName()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetFontName(this.swigCPtr);
    }

    public virtual void SetFontName(string sName)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetFontName(this.swigCPtr, sName);
    }

    public virtual int GetFontSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetFontSize(this.swigCPtr);
    }

    public virtual void SetFontSize(int iSize)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetFontSize(this.swigCPtr, iSize);
    }

    public virtual string GetLabelText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetLabelText(this.swigCPtr);
    }

    public virtual void SetLabelText(string sText)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetLabelText(this.swigCPtr, sText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual int GetHorizontalAlignmentType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetHorizontalAlignmentType(this.swigCPtr);
    }

    public virtual void SetHorizontalAlignmentType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetHorizontalAlignmentType(this.swigCPtr, iType);
    }

    public virtual int GetVerticalAlignmentType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetVerticalAlignmentType(this.swigCPtr);
    }

    public virtual void SetVerticalAlignmentType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetVerticalAlignmentType(this.swigCPtr, iType);
    }

    public virtual bool GetTouchScaleChangeEanbleState()
    {
      return CocoStudioEngineAdapterPINVOKE.CSText_GetTouchScaleChangeEanbleState(this.swigCPtr);
    }

    public virtual void SetTouchScaleChangeEanbleState(bool bState)
    {
      CocoStudioEngineAdapterPINVOKE.CSText_SetTouchScaleChangeEanbleState(this.swigCPtr, bState);
    }
  }
}
