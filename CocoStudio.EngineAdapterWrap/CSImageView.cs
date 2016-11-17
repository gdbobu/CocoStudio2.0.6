// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSImageView
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSImageView : CSWidget
  {
    private HandleRef swigCPtr;

    public CSImageView(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSImageView_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSImageView()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSImageView(), true)
    {
    }

    ~CSImageView()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSImageView obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSImageView(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSImageView(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_Init(this.swigCPtr);
    }

    public virtual bool GetFlipX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSImageView_GetFlipX(this.swigCPtr);
    }

    public virtual void SetFlipX(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_SetFlipX(this.swigCPtr, flip);
    }

    public virtual bool GetFlipY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSImageView_GetFlipY(this.swigCPtr);
    }

    public virtual void SetFlipY(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_SetFlipY(this.swigCPtr, flip);
    }

    public override bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSImageView_GetScale9Enabled(this.swigCPtr);
    }

    public override void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public override void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual ResourceData GetFileData()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSImageView_GetFileData(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFileData(ResourceData resourceData)
    {
      CocoStudioEngineAdapterPINVOKE.CSImageView_SetFileData(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(resourceData.Path, (CSEnumResourceType) resourceData.Type, resourceData.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
