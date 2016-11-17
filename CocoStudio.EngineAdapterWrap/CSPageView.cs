// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSPageView
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSPageView : CSPanel
  {
    private HandleRef swigCPtr;

    public CSPageView(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSPageView_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSPageView()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSPageView(), true)
    {
    }

    ~CSPageView()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSPageView obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSPageView(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSPageView(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_Init(this.swigCPtr);
    }

    public override void AddChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_AddChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public override void RemoveChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_RemoveChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public override void InsertChild(int index, CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_InsertChild(this.swigCPtr, index, CSVisualObject.getCPtr(child));
    }

    public override void SetSize(PointF cPoint)
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_SetSize(this.swigCPtr, Vec2.getCPtr(new Vec2(cPoint.X, cPoint.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override void RefreshBoundingObjects()
    {
      CocoStudioEngineAdapterPINVOKE.CSPageView_RefreshBoundingObjects(this.swigCPtr);
    }
  }
}
