// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSCocosHelp
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSCocosHelp : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSCocosHelp(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSCocosHelp()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSCocosHelp(), true)
    {
    }

    ~CSCocosHelp()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSCocosHelp obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSCocosHelp(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSCocosHelp(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public static void ClearResurceCache()
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_ClearResurceCache();
    }

    public static void LoadPListFileToCache(string filePath)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_LoadPListFileToCache(filePath);
    }

    public static void ReloadPngFileToCache(string filePath)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_ReloadPngFileToCache(filePath);
    }

    public static void ReloadPlistFileToCache(string filePath)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_ReloadPlistFileToCache(filePath);
    }

    public static void RemovePngFileFromCache(string filePath)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_RemovePngFileFromCache(filePath);
    }

    public static void RemovePlistFileFromCache(string filePath)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_RemovePlistFileFromCache(filePath);
    }

    public static CSVectorString GetTmxMapImageArray(string filePath)
    {
      IntPtr tmxMapImageArray = CocoStudioEngineAdapterPINVOKE.CSCocosHelp_GetTmxMapImageArray(filePath);
      return tmxMapImageArray == IntPtr.Zero ? (CSVectorString) null : new CSVectorString(tmxMapImageArray, false);
    }

    public static string ConvertToBinProto(string des, string src, string res)
    {
      return CocoStudioEngineAdapterPINVOKE.CSCocosHelp_ConvertToBinProto(des, src, res);
    }

    public static string ConvertToBinByFlat(string des, string src, string res)
    {
      return CocoStudioEngineAdapterPINVOKE.CSCocosHelp_ConvertToBinByFlat(des, src, res);
    }

    public static void RefreshLayoutSystemState(bool state)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_RefreshLayoutSystemState(state);
    }

    public static void SetResourcePath(string resourceDir)
    {
      CocoStudioEngineAdapterPINVOKE.CSCocosHelp_SetResourcePath(resourceDir);
    }
  }
}
