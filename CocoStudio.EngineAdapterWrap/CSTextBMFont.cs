// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTextBMFont
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTextBMFont : CSWidget
  {
    private HandleRef swigCPtr;

    public CSTextBMFont(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTextBMFont_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTextBMFont()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTextBMFont(), true)
    {
    }

    ~CSTextBMFont()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTextBMFont obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTextBMFont(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTextBMFont(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSTextBMFont_Init(this.swigCPtr);
    }

    public virtual string GetText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextBMFont_GetText(this.swigCPtr);
    }

    public virtual void SetText(string sText)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextBMFont_SetText(this.swigCPtr, sText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetFntFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSTextBMFont_GetFntFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFntFile(ResourceData fileName)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextBMFont_SetFntFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(fileName.Path, (CSEnumResourceType) fileName.Type, fileName.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }
  }
}
