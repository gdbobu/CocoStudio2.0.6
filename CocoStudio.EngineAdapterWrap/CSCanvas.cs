// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSCanvas
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSCanvas : CSVisualObject
  {
    private HandleRef swigCPtr;

    public CSCanvas(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSCanvas_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSCanvas()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSCanvas(), true)
    {
    }

    ~CSCanvas()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSCanvas obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSCanvas(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSCanvas(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void SetVisible(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetVisible(this.swigCPtr, visible);
    }

    public override void SetPosition(PointF position)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetPosition(this.swigCPtr, Vec2.getCPtr(new Vec2(position.X, position.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override void SetScale(ScaleValue scale)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetScale(this.swigCPtr, CSScale.getCPtr(new CSScale(scale.ScaleX, scale.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override int HitTest(PointF point)
    {
      int num = CocoStudioEngineAdapterPINVOKE.CSCanvas_HitTest(this.swigCPtr, Vec2.getCPtr(new Vec2(point.X, point.Y)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
      return num;
    }

    public void SetCanvasSize(Gdk.Size size)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetCanvasSize(this.swigCPtr, Size.getCPtr(new Size((float) size.Width, (float) size.Height)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public Gdk.Size GetCanvasSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSCanvas_GetCanvasSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }

    public virtual void ResetCanvas()
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_ResetCanvas(this.swigCPtr);
    }

    public void SetLayerColorVisible(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetLayerColorVisible(this.swigCPtr, visible);
    }

    public void SetCenterLineVisible(bool visible)
    {
      CocoStudioEngineAdapterPINVOKE.CSCanvas_SetCenterLineVisible(this.swigCPtr, visible);
    }
  }
}
