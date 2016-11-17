// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSLoadingBar
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSLoadingBar : CSWidget
  {
    private HandleRef swigCPtr;

    public CSLoadingBar(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSLoadingBar()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSLoadingBar(), true)
    {
    }

    ~CSLoadingBar()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSLoadingBar obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSLoadingBar(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSLoadingBar(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_Init(this.swigCPtr);
    }

    public virtual int GetProgressPercent()
    {
      return CocoStudioEngineAdapterPINVOKE.CSLoadingBar_GetProgressPercent(this.swigCPtr);
    }

    public virtual void SetProgressPercent(int iInfo)
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SetProgressPercent(this.swigCPtr, iInfo);
    }

    public virtual int GetProgressType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSLoadingBar_GetProgressType(this.swigCPtr);
    }

    public virtual void SetProgressType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SetProgressType(this.swigCPtr, iType);
    }

    public override bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSLoadingBar_GetScale9Enabled(this.swigCPtr);
    }

    public override void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public override void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual ResourceData GetFileData()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSLoadingBar_GetFileData(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFileData(ResourceData resourceData)
    {
      CocoStudioEngineAdapterPINVOKE.CSLoadingBar_SetFileData(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(resourceData.Path, (CSEnumResourceType) resourceData.Type, resourceData.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
