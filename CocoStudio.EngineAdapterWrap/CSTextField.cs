// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTextField
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTextField : CSWidget
  {
    private HandleRef swigCPtr;

    public CSTextField(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTextField_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTextField()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTextField(), true)
    {
    }

    ~CSTextField()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTextField obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTextField(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTextField(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_Init(this.swigCPtr);
    }

    public override void SetSizeCustomEnabled(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetSizeCustomEnabled(this.swigCPtr, bEnabled);
    }

    public virtual string GetFontName()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetFontName(this.swigCPtr);
    }

    public virtual void SetFontName(string sName)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetFontName(this.swigCPtr, sName);
    }

    public virtual int GetFontSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetFontSize(this.swigCPtr);
    }

    public virtual void SetFontSize(int iSize)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetFontSize(this.swigCPtr, iSize);
    }

    public virtual string GetLabelText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetLabelText(this.swigCPtr);
    }

    public virtual void SetLabelText(string sText)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetLabelText(this.swigCPtr, sText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetPlaceHolderText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetPlaceHolderText(this.swigCPtr);
    }

    public virtual void SetPlaceHolderText(string pText)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetPlaceHolderText(this.swigCPtr, pText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual Color GetPlaceHolderTextColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSTextField_GetPlaceHolderTextColor(this.swigCPtr), true);
      return Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetPlaceHolderTextColor(Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetPlaceHolderTextColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual bool GetPassWordEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetPassWordEnabled(this.swigCPtr);
    }

    public virtual void SetPassWordEnabled(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetPassWordEnabled(this.swigCPtr, bEnabled);
    }

    public virtual string GetPasswordStyleText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetPasswordStyleText(this.swigCPtr);
    }

    public virtual void SetPasswordStyleText(string pText)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetPasswordStyleText(this.swigCPtr, pText);
    }

    public virtual bool GetLengthLimited()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetLengthLimited(this.swigCPtr);
    }

    public virtual void SetLengthLimited(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetLengthLimited(this.swigCPtr, bEnabled);
    }

    public virtual int GetMaxLength()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextField_GetMaxLength(this.swigCPtr);
    }

    public virtual void SetMaxLength(int iLength)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextField_SetMaxLength(this.swigCPtr, iLength);
    }
  }
}
