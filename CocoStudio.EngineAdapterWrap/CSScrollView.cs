// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSScrollView
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSScrollView : CSPanel
  {
    private HandleRef swigCPtr;

    public CSScrollView(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSScrollView_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSScrollView()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSScrollView__SWIG_1(), true)
    {
    }

    ~CSScrollView()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSScrollView obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSScrollView(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSScrollView(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSScrollView_Init(this.swigCPtr);
    }

    public virtual Gdk.Size GetInnerSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSScrollView_GetInnerSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }

    public virtual void SetInnerSize(Gdk.Size size)
    {
      CocoStudioEngineAdapterPINVOKE.CSScrollView_SetInnerSize(this.swigCPtr, Size.getCPtr(new Size((float) size.Width, (float) size.Height)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual int GetDirectionType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSScrollView_GetDirectionType(this.swigCPtr);
    }

    public virtual void SetDirectionType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSScrollView_SetDirectionType(this.swigCPtr, iType);
    }

    public virtual bool GetBounceEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSScrollView_GetBounceEnabled(this.swigCPtr);
    }

    public virtual void SetBounceEnabled(bool enabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSScrollView_SetBounceEnabled(this.swigCPtr, enabled);
    }

    public override void RefreshBoundingObjects()
    {
      CocoStudioEngineAdapterPINVOKE.CSScrollView_RefreshBoundingObjects(this.swigCPtr);
    }

    public virtual PointF TransformToSelfInner(PointF scenePoint)
    {
      Vec2 vec2 = new Vec2(CocoStudioEngineAdapterPINVOKE.CSScrollView_TransformToSelfInner(this.swigCPtr, Vec2.getCPtr(new Vec2(scenePoint.X, scenePoint.Y))), true);
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return new PointF(vec2.x, vec2.y);
    }
  }
}
