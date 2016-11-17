// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSResourceData
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSResourceData : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSResourceData(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSResourceData()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSResourceData__SWIG_0(), true)
    {
    }

    public CSResourceData(string path)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSResourceData__SWIG_1(path), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public CSResourceData(string path, CSEnumResourceType type)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSResourceData__SWIG_2(path, (int) type), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public CSResourceData(string path, CSEnumResourceType type, string plist)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSResourceData__SWIG_3(path, (int) type, plist), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public CSResourceData(CSResourceData other)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSResourceData__SWIG_4(CSResourceData.getCPtr(other)), true)
    {
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    ~CSResourceData()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSResourceData obj)
    {
      return obj == null ? new HandleRef((object) null, IntPtr.Zero) : obj.swigCPtr;
    }

    public virtual void Dispose()
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
                CocoStudioEngineAdapterPINVOKE.delete_CSResourceData(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSResourceData(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public CSEnumResourceType GetResourceType()
    {
      return (CSEnumResourceType) CocoStudioEngineAdapterPINVOKE.CSResourceData_GetResourceType(this.swigCPtr);
    }

    public string GetPath()
    {
      return CocoStudioEngineAdapterPINVOKE.CSResourceData_GetPath(this.swigCPtr);
    }

    public string GetPathC()
    {
      return CocoStudioEngineAdapterPINVOKE.CSResourceData_GetPathC(this.swigCPtr);
    }

    public string GetPlistFile()
    {
      return CocoStudioEngineAdapterPINVOKE.CSResourceData_GetPlistFile(this.swigCPtr);
    }

    public bool EndsWith(string suffix)
    {
      return CocoStudioEngineAdapterPINVOKE.CSResourceData_EndsWith(this.swigCPtr, suffix);
    }

    public bool Equals(ResourceData other)
    {
      bool flag = CocoStudioEngineAdapterPINVOKE.CSResourceData_Equals(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(other.Path, (CSEnumResourceType) other.Type, other.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return flag;
    }

    public bool IsEmpty()
    {
      return CocoStudioEngineAdapterPINVOKE.CSResourceData_IsEmpty(this.swigCPtr);
    }
  }
}
