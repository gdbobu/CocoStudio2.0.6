// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Acceleration
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class Acceleration : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public double x
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Acceleration_x_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Acceleration_x_set(this.swigCPtr, value);
      }
    }

    public double y
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Acceleration_y_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Acceleration_y_set(this.swigCPtr, value);
      }
    }

    public double z
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Acceleration_z_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Acceleration_z_set(this.swigCPtr, value);
      }
    }

    public double timestamp
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.Acceleration_timestamp_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.Acceleration_timestamp_set(this.swigCPtr, value);
      }
    }

    public Acceleration(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public Acceleration()
      : this(CocoStudioEngineAdapterPINVOKE.new_Acceleration(), true)
    {
    }

    ~Acceleration()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(Acceleration obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_Acceleration(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_Acceleration(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
