// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSObject
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSObject : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    protected internal CSObject()
    {
    }

    public CSObject(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    protected virtual bool IsContainOpenGLResource()
    {
      return true;
    }

    public static HandleRef getCPtr(CSObject obj)
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
            if (!this.IsContainOpenGLResource())
              throw new MethodAccessException("C++ destructor does not have public access");
            GtkInvokeHelp.BeginInvoke((Action) (() =>
            {
              this.swigCPtr = handle;
              throw new MethodAccessException("C++ destructor does not have public access");
            }));
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }
  }
}
