// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSPanel
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSPanel : CSWidget
  {
    private HandleRef swigCPtr;

    public CSPanel(IntPtr cPtr, bool cMemoryOwn)
      : base(CocoStudioEngineAdapterPINVOKE.CSPanel_SWIGUpcast(cPtr), cMemoryOwn)
    {
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSPanel()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSPanel__SWIG_1(), true)
    {
    }

    ~CSPanel()
    {
      this.Dispose();
    }

    public static HandleRef getCPtr(CSPanel obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSPanel(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSPanel(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        System.GC.SuppressFinalize((object) this);
        base.Dispose();
      }
    }

    public override void Init()
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_Init(this.swigCPtr);
    }

    public virtual bool GetClipAble()
    {
      return CocoStudioEngineAdapterPINVOKE.CSPanel_GetClipAble(this.swigCPtr);
    }

    public virtual void SetClipAble(bool bclip)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetClipAble(this.swigCPtr, bclip);
    }

    public virtual int GetGroundAlpha()
    {
      return CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundAlpha(this.swigCPtr);
    }

    public virtual void SetGroundAlpha(int alpha)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundAlpha(this.swigCPtr, alpha);
    }

    public virtual int GetGroundColorType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundColorType(this.swigCPtr);
    }

    public virtual void SetGroundColorType(int iType)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundColorType(this.swigCPtr, iType);
    }

    public virtual System.Drawing.Color GetGroundSingleColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundSingleColor(this.swigCPtr), true);
      return System.Drawing.Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetGroundSingleColor(System.Drawing.Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundSingleColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual System.Drawing.Color GetGroundLineStartColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundLineStartColor(this.swigCPtr), true);
      return System.Drawing.Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetGroundLineStartColor(System.Drawing.Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundLineStartColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual System.Drawing.Color GetGroundLineEndColor()
    {
      Color3B color3B = new Color3B(CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundLineEndColor(this.swigCPtr), true);
      return System.Drawing.Color.FromArgb((int) color3B.r, (int) color3B.g, (int) color3B.b);
    }

    public virtual void SetGroundLineEndColor(System.Drawing.Color color)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundLineEndColor(this.swigCPtr, Color3B.getCPtr(new Color3B(color.R, color.G, color.B)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual ScaleValue GetGroundColorVector()
    {
      CSScale csScale = new CSScale(CocoStudioEngineAdapterPINVOKE.CSPanel_GetGroundColorVector(this.swigCPtr), false);
      return new ScaleValue(csScale.GetScaleX(), csScale.GetScaleY(), 0.1, -99999999.0, 99999999.0);
    }

    public virtual void SetGroundColorVector(ScaleValue cVector)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetGroundColorVector(this.swigCPtr, CSScale.getCPtr(new CSScale(cVector.ScaleX, cVector.ScaleY)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public override bool GetScale9Enabled()
    {
      return CocoStudioEngineAdapterPINVOKE.CSPanel_GetScale9Enabled(this.swigCPtr);
    }

    public override void SetScale9Enabled(bool bEnaled)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetScale9Enabled(this.swigCPtr, bEnaled);
    }

    public override void SetScale9Rect(int x, int y, int width, int height)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetScale9Rect(this.swigCPtr, x, y, width, height);
    }

    public virtual ResourceData GetFilePath()
    {
      CSResourceData csResourceData = new CSResourceData(CocoStudioEngineAdapterPINVOKE.CSPanel_GetFilePath(this.swigCPtr), true);
      return new ResourceData((EnumResourceType) csResourceData.GetResourceType(), csResourceData.GetPath(), csResourceData.GetPlistFile());
    }

    public virtual void SetFilePath(ResourceData file)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetFilePath(this.swigCPtr, CSResourceData.getCPtr(new CSResourceData(file.Path, (CSEnumResourceType) file.Type, file.Plist)));
      if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
        throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
    }

    public virtual int GetContainerLayoutType()
    {
      return CocoStudioEngineAdapterPINVOKE.CSPanel_GetContainerLayoutType(this.swigCPtr);
    }

    public virtual void SetContainerLayoutType(int itype)
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_SetContainerLayoutType(this.swigCPtr, itype);
    }

    public virtual void RemoveBackGroundFile()
    {
      CocoStudioEngineAdapterPINVOKE.CSPanel_RemoveBackGroundFile(this.swigCPtr);
    }

    public override Gdk.Size GetWidgetAutoSize()
    {
      Size size = new Size(CocoStudioEngineAdapterPINVOKE.CSPanel_GetWidgetAutoSize(this.swigCPtr), true);
      if ((double) size.width < 0.0 || (double) size.height < 0.0)
      {
        size.width = 0.0f;
        size.height = 0.0f;
      }
      return new Gdk.Size((int) size.width, (int) size.height);
    }
  }
}
