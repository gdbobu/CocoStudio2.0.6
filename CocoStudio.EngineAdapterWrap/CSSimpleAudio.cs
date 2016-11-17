// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSSimpleAudio
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSSimpleAudio : CSNode
  {
    private HandleRef swigCPtr;

    public CSSimpleAudio(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSSimpleAudio()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSSimpleAudio(), true)
    {
    }

    ~CSSimpleAudio()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSSimpleAudio obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSSimpleAudio(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSSimpleAudio(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_Init(this.swigCPtr);
    }

    public override string GetName()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_GetName(this.swigCPtr);
    }

    public override void SetName(string nameStr)
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_SetName(this.swigCPtr, nameStr);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual float GetVolume()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_GetVolume(this.swigCPtr);
    }

    public virtual void SetVolume(float volume)
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_SetVolume(this.swigCPtr, volume);
    }

    public virtual bool GetIsLoop()
    {
      return CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_GetIsLoop(this.swigCPtr);
    }

    public virtual void SetIsLoop(bool isLoop)
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_SetIsLoop(this.swigCPtr, isLoop);
    }

    public virtual void Start()
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_Start(this.swigCPtr);
    }

    public virtual void Stop()
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_Stop(this.swigCPtr);
    }

    public virtual ResourceData GetFileData()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_GetFileData(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFileData(ResourceData resourceData)
    {
      CocoStudioEngineAdapterPINVOKE.CSSimpleAudio_SetFileData(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(resourceData.Path, (CSEnumResourceType) resourceData.Type, resourceData.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
