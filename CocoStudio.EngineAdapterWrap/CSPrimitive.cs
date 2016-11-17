// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSPrimitive
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSPrimitive : CSNode
  {
    private HandleRef swigCPtr;

    public CSPrimitive(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSPrimitive_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSPrimitive()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSPrimitive(), true)
    {
    }

    ~CSPrimitive()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSPrimitive obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSPrimitive(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSPrimitive(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSPrimitive_Init(this.swigCPtr);
    }

    public void AddASBox(string boxName, float width, float height, float centerX, float centerY)
    {
      CocoStudioEngineAdapterPINVOKE.CSPrimitive_AddASBox(this.swigCPtr, boxName, width, height, centerX, centerY);
    }

    public void ResetBoxSize(string boxName, float width, float height, float centerX, float centerY)
    {
      CocoStudioEngineAdapterPINVOKE.CSPrimitive_ResetBoxSize(this.swigCPtr, boxName, width, height, centerX, centerY);
    }
  }
}
