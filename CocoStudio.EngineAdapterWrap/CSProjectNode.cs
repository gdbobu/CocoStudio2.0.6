// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSProjectNode
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSProjectNode : CSNode
  {
    private HandleRef swigCPtr;

    public CSProjectNode(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSProjectNode_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSProjectNode()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSProjectNode(), true)
    {
    }

    ~CSProjectNode()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSProjectNode obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSProjectNode(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSProjectNode(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSProjectNode_Init(this.swigCPtr);
    }

    public virtual float GetWidth()
    {
      return CocoStudioEngineAdapterPINVOKE.CSProjectNode_GetWidth(this.swigCPtr);
    }

    public virtual float GetHeight()
    {
      return CocoStudioEngineAdapterPINVOKE.CSProjectNode_GetHeight(this.swigCPtr);
    }

    public virtual ResourceData GetFileData()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSProjectNode_GetFileData(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFileData(ResourceData resourceData)
    {
      CocoStudioEngineAdapterPINVOKE.CSProjectNode_SetFileData(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(resourceData.Path, (CSEnumResourceType) resourceData.Type, resourceData.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
