// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSWidget
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSWidget : CSNode
  {
    private HandleRef swigCPtr;

    public CSWidget(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSWidget_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSWidget()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSWidget__SWIG_1(), true)
    {
    }

    ~CSWidget()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSWidget obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSWidget(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSWidget(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_Init(this.swigCPtr);
    }

    public virtual bool GetSizeCustomEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSWidget_GetSizeCustomEnabled(this.swigCPtr);
    }

    public virtual void SetSizeCustomEnabled(bool bEnabled)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_SetSizeCustomEnabled(this.swigCPtr, bEnabled);
    }

    public virtual Gdk.Size GetWidgetAutoSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSWidget_GetWidgetAutoSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }

    public virtual bool GetTouchEnabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSWidget_GetTouchEnabled(this.swigCPtr);
    }

    public virtual void SetTouchEnabled(bool select)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_SetTouchEnabled(this.swigCPtr, select);
    }

    public virtual bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSWidget_GetScale9Enabled(this.swigCPtr);
    }

    public virtual void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public virtual void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual void CloneWidgetCustomProperty(CSWidget cWidget)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_CloneWidgetCustomProperty(this.swigCPtr, CSWidget.getCPtr(cWidget));
    }

    public virtual void ChangeState(bool isNormal)
    {
      CocoStudioEngineAdapterPINVOKE.CSWidget_ChangeState(this.swigCPtr, isNormal);
    }
  }
}
