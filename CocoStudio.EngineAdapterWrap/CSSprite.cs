// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSSprite
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSSprite : CSNode
  {
    private HandleRef swigCPtr;

    public CSSprite(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSSprite_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSSprite()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSSprite(), true)
    {
    }

    ~CSSprite()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSSprite obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSSprite(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSSprite(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSSprite_Init(this.swigCPtr);
    }

    public virtual bool GetFlipX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSprite_GetFlipX(this.swigCPtr);
    }

    public virtual void SetFlipX(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSSprite_SetFlipX(this.swigCPtr, flip);
    }

    public virtual bool GetFlipY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSprite_GetFlipY(this.swigCPtr);
    }

    public virtual void SetFlipY(bool flip)
    {
      CocoStudioEngineAdapterPINVOKE.CSSprite_SetFlipY(this.swigCPtr, flip);
    }

    public virtual ResourceData GetFileData()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSprite_GetFileData(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFileData(ResourceData resourceData)
    {
      CocoStudioEngineAdapterPINVOKE.CSSprite_SetFileData(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(resourceData.Path, (CSEnumResourceType) resourceData.Type, resourceData.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
