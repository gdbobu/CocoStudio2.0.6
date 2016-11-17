// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSRect
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSRect : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSRect(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSRect()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSRect(), true)
    {
    }

    ~CSRect()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSRect obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSRect(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSRect(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public float MinX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSRect_MinX(this.swigCPtr);
    }

    public float MinY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSRect_MinY(this.swigCPtr);
    }

    public float MaxX()
    {
      return CocoStudioEngineAdapterPINVOKE.CSRect_MaxX(this.swigCPtr);
    }

    public float MaxY()
    {
      return CocoStudioEngineAdapterPINVOKE.CSRect_MaxY(this.swigCPtr);
    }
  }
}
