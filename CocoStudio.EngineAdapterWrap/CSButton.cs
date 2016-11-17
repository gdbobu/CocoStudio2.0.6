// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSButton
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSButton : CSWidget
  {
    private HandleRef swigCPtr;

    public CSButton(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSButton_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSButton()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSButton(), true)
    {
    }

    ~CSButton()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSButton obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSButton(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSButton(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_Init(this.swigCPtr);
    }

    public override void SetSizeCustomEnabled(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetSizeCustomEnabled(this.swigCPtr, bEnabled);
    }

    public virtual bool GetFlipX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetFlipX(this.swigCPtr);
    }

    public virtual void SetFlipX(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetFlipX(this.swigCPtr, flip);
    }

    public virtual bool GetFlipY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetFlipY(this.swigCPtr);
    }

    public virtual void SetFlipY(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetFlipY(this.swigCPtr, flip);
    }

    public override bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetScale9Enabled(this.swigCPtr);
    }

    public override void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public override void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual string GetText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetText(this.swigCPtr);
    }

    public virtual void SetText(string sText)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetText(this.swigCPtr, sText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetFontName()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetFontName(this.swigCPtr);
    }

    public virtual void SetFontName(string sName)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetFontName(this.swigCPtr, sName);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual int GetFontSize()
    {
      return CocoStudioEngineAdapterPINVOKE.CSButton_GetFontSize(this.swigCPtr);
    }

    public virtual void SetFontSize(int sSize)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetFontSize(this.swigCPtr, sSize);
    }

    public virtual System.Drawing.Color GetTextColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSButton_GetTextColor(this.swigCPtr), true);
      return System.Drawing.Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetTextColor(System.Drawing.Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetTextColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetNormalFilePath()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSButton_GetNormalFilePath(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetNormalFilePath(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetNormalFilePath(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetPressedFilePath()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSButton_GetPressedFilePath(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetPressedFilePath(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetPressedFilePath(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetDisabledFilePath()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSButton_GetDisabledFilePath(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetDisabledFilePath(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSButton_SetDisabledFilePath(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override Gdk.Size GetWidgetAutoSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSButton_GetWidgetAutoSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }
  }
}
