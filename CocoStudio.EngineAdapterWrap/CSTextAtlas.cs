// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSTextAtlas
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSTextAtlas : CSWidget
  {
    private HandleRef swigCPtr;

    public CSTextAtlas(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSTextAtlas()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSTextAtlas(), true)
    {
    }

    ~CSTextAtlas()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSTextAtlas obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSTextAtlas(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSTextAtlas(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSTextAtlas_Init(this.swigCPtr);
    }

    public virtual void SetStartChar(string character)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SetStartChar(this.swigCPtr, character);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual string GetStartChar()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextAtlas_GetStartChar(this.swigCPtr);
    }

    public virtual int GetCharacterWidth()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextAtlas_GetCharacterWidth(this.swigCPtr);
    }

    public virtual void SetCharacterWidth(int width)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SetCharacterWidth(this.swigCPtr, width);
    }

    public virtual int GetCharacterHeight()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextAtlas_GetCharacterHeight(this.swigCPtr);
    }

    public virtual void SetCharacterHeight(int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SetCharacterHeight(this.swigCPtr, height);
    }

    public virtual string GetText()
    {
      return CocoStudioEngineAdapterPINVOKE.CSTextAtlas_GetText(this.swigCPtr);
    }

    public virtual void SetText(string strText)
    {
      CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SetText(this.swigCPtr, strText);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ResourceData GetAtlasFile()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSTextAtlas_GetAtlasFile(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual bool SetAtlasFile(ResourceData file)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.CSTextAtlas_SetAtlasFile(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }
  }
}
