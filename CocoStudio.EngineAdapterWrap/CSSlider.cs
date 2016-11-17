// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSSlider
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSSlider : CSWidget
  {
    private HandleRef swigCPtr;

    public CSSlider(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSSlider_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSSlider()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSSlider(), true)
    {
    }

    ~CSSlider()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSSlider obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSSlider(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSSlider(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_Init(this.swigCPtr);
    }

    public virtual int GetPercent()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSlider_GetPercent(this.swigCPtr);
    }

    public virtual void SetPercent(int percent)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetPercent(this.swigCPtr, percent);
    }

    public override bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSlider_GetScale9Enabled(this.swigCPtr);
    }

    public override void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public override void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual ResourceData GetGroundBarTexture()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSlider_GetGroundBarTexture(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetGroundBarTexture(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetGroundBarTexture(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetProgressBarTexture()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSlider_GetProgressBarTexture(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetProgressBarTexture(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetProgressBarTexture(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetBallNormalTexture()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSlider_GetBallNormalTexture(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetBallNormalTexture(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetBallNormalTexture(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetBallPressedTexture()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSlider_GetBallPressedTexture(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetBallPressedTexture(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetBallPressedTexture(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetBallDisabledTexture()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSlider_GetBallDisabledTexture(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetBallDisabledTexture(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSSlider_SetBallDisabledTexture(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override Gdk.Size GetWidgetAutoSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSSlider_GetWidgetAutoSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }
  }
}
