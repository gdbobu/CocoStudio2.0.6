// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSLayer
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSLayer : CSNode
  {
    private HandleRef swigCPtr;

    public CSLayer(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSLayer_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSLayer()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSLayer(), true)
    {
    }

    ~CSLayer()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSLayer obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSLayer(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSLayer(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSLayer_Init(this.swigCPtr);
    }

    public virtual bool IsTouchEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSLayer_IsTouchEnabled(this.swigCPtr);
    }

    public virtual void SetTouchEnabled(bool isEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSLayer_SetTouchEnabled(this.swigCPtr, isEnabled);
    }
  }
}
