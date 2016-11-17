// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSCheckBox
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSCheckBox : CSWidget
  {
    private HandleRef swigCPtr;

    public CSCheckBox(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSCheckBox_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSCheckBox()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSCheckBox(), true)
    {
    }

    ~CSCheckBox()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSCheckBox obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSCheckBox(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSCheckBox(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_Init(this.swigCPtr);
    }

    public virtual bool GetChecked()
    {
      return CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetChecked(this.swigCPtr);
    }

    public virtual void SetChecked(bool bChecked)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetChecked(this.swigCPtr, bChecked);
    }

    public virtual ResourceData GetNormalGroundFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetNormalGroundFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetNormalGroudFile(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetNormalGroudFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetPressedGroundFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetPressedGroundFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetPressedGroudFile(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetPressedGroudFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetDisabledGroundFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetDisabledGroundFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetDisabledGroudFile(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetDisabledGroudFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetNormalNodeFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetNormalNodeFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetNormalNodeFile(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetNormalNodeFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetDisabledNodeFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSCheckBox_GetDisabledNodeFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetDisabledNodeFile(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSCheckBox_SetDisabledNodeFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
