// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSListView
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSListView : CSScrollView
  {
    private HandleRef swigCPtr;

    public CSListView(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSListView_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSListView()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSListView(), true)
    {
    }

    ~CSListView()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSListView obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSListView(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSListView(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_Init(this.swigCPtr);
    }

    public virtual int GetItemSpace()
    {
      return CocoStudioEngineAdapterPINVOKE.CSListView_GetItemSpace(this.swigCPtr);
    }

    public virtual void SetItemSpace(int space)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_SetItemSpace(this.swigCPtr, space);
    }

    public virtual int GetGravityType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSListView_GetGravityType(this.swigCPtr);
    }

    public virtual void SetGravityType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_SetGravityType(this.swigCPtr, iType);
    }

    public override void InsertChild(int index, CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_InsertChild(this.swigCPtr, index, CSVisualObject.getCPtr(child));
    }

    public override void AddChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_AddChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public override void RemoveChild(CSVisualObject child)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_RemoveChild(this.swigCPtr, CSVisualObject.getCPtr(child));
    }

    public override void SetDirectionType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_SetDirectionType(this.swigCPtr, iType);
    }

    public override void RefreshBoundingObjects()
    {
      CocoStudioEngineAdapterPINVOKE.CSListView_RefreshBoundingObjects(this.swigCPtr);
    }
  }
}
