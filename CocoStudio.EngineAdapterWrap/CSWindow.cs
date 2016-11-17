// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSWindow
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSWindow : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public CSWindow(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSWindow(int windowHandle, int width, int heigth, string localPath)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSWindow__SWIG_0(windowHandle, width, heigth, localPath), true)
    {
    }

    public CSWindow(IntPtr windowHandle, IntPtr nsview, int width, int height, string localpath)
      : this(CocoStudioEngineAdapterPINVOKE.new_CSWindow__SWIG_1(windowHandle, nsview, width, height, localpath), true)
    {
    }

    ~CSWindow()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSWindow obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSWindow(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSWindow(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void Draw(int writeableBitmapPointer)
    {
      CocoStudioEngineAdapterPINVOKE.CSWindow_Draw(this.swigCPtr, writeableBitmapPointer);
    }

    public void SetViewRect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSWindow_SetViewRect(this.swigCPtr, x, y, width, height);
    }

    public void Close()
    {
      CocoStudioEngineAdapterPINVOKE.CSWindow_Close(this.swigCPtr);
    }

    public CSCanvas GetCanvas()
    {
      IntPtr canvas = CocoStudioEngineAdapterPINVOKE.CSWindow_GetCanvas(this.swigCPtr);
      return canvas == IntPtr.Zero ? (CSCanvas) null : new CSCanvas(canvas, false);
    }

    public CSScene GetScene()
    {
      IntPtr scene = CocoStudioEngineAdapterPINVOKE.CSWindow_GetScene(this.swigCPtr);
      return scene == IntPtr.Zero ? (CSScene) null : new CSScene(scene, false);
    }

    public void UpdateOpenGLContext(bool isShowing, int windowHandle)
    {
      CocoStudioEngineAdapterPINVOKE.CSWindow_UpdateOpenGLContext(this.swigCPtr, isShowing, windowHandle);
    }
  }
}
