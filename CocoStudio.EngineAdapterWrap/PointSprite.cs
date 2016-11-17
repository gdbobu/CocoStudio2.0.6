// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.PointSprite
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class PointSprite : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public Vec2 pos
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.PointSprite_pos_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Vec2) null : new Vec2(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.PointSprite_pos_set(this.swigCPtr, Vec2.getCPtr(value));
      }
    }

    public Color4B color
    {
      get
      {
        IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.PointSprite_color_get(this.swigCPtr);
        return cPtr == IntPtr.Zero ? (Color4B) null : new Color4B(cPtr, false);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.PointSprite_color_set(this.swigCPtr, Color4B.getCPtr(value));
      }
    }

    public float size
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.PointSprite_size_get(this.swigCPtr);
      }
      set
      {
        CocoStudioEngineAdapterPINVOKE.PointSprite_size_set(this.swigCPtr, value);
      }
    }

    public PointSprite(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public PointSprite()
      : this(CocoStudioEngineAdapterPINVOKE.new_PointSprite(), true)
    {
    }

    ~PointSprite()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(PointSprite obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_PointSprite(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_PointSprite(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
