// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.V3F_T2F
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class V3F_T2F : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Vec3 vertices
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_vertices_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec3) null : new Vec3(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_vertices_set(this.swigCPtr, Vec3.getCPtr(value));
      }
    }

    public Tex2F texCoords
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.V3F_T2F_texCoords_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Tex2F) null : new Tex2F(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.V3F_T2F_texCoords_set(this.swigCPtr, Tex2F.getCPtr(value));
      }
    }

    public V3F_T2F(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public V3F_T2F()
      : this(CocoStudioEngineAdapterPINVOKE.new_V3F_T2F(), true)
    {
    }

    ~V3F_T2F()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(V3F_T2F obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_V3F_T2F(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_V3F_T2F(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
