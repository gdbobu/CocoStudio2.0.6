// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSMatrix
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSMatrix : IDisposable
  {
    private HandleRef swigCPtr;
    protected bool swigCMemOwn;

    public float CX
    {
      get
      {
        return this.X();
      }
    }

    public float CY
    {
      get
      {
        return this.Y();
      }
    }

    public float CM11
    {
      get
      {
        return this.M11();
      }
    }

    public float CM12
    {
      get
      {
        return this.M12();
      }
    }

    public float CM21
    {
      get
      {
        return this.M21();
      }
    }

    public float CM22
    {
      get
      {
        return this.M22();
      }
    }

    public CSMatrix(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public CSMatrix()
      : this(CocoStudioEngineAdapterPINVOKE.new_CSMatrix(), true)
    {
    }

    ~CSMatrix()
    {
      this.Dispose();
    }

    public override bool Equals(object obj)
    {
      if (!(obj is CSMatrix))
        return false;
      CSMatrix csMatrix = (CSMatrix) obj;
      return obj != null && (double) this.CX == (double) csMatrix.CX && ((double) this.CY == (double) csMatrix.CY && (double) this.CM11 == (double) csMatrix.CM11) && ((double) this.CM12 == (double) csMatrix.CM12 && (double) this.CM21 == (double) csMatrix.CM21) && (double) this.CM22 == (double) csMatrix.CM22;
    }

    public override int GetHashCode()
    {
      float num1 = this.CX;
      int hashCode1 = num1.GetHashCode();
      num1 = this.CY;
      int hashCode2 = num1.GetHashCode();
      int num2 = hashCode1 ^ hashCode2;
      num1 = this.CM11;
      int hashCode3 = num1.GetHashCode();
      num1 = this.CM12;
      int hashCode4 = num1.GetHashCode();
      int num3 = hashCode3 ^ hashCode4;
      int num4 = num2 | num3;
      num1 = this.CM21;
      int hashCode5 = num1.GetHashCode();
      num1 = this.CM22;
      int hashCode6 = num1.GetHashCode();
      int num5 = hashCode5 ^ hashCode6;
      return num4 | num5;
    }

    public static HandleRef getCPtr(CSMatrix obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_CSMatrix(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_CSMatrix(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public float M11()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_M11(this.swigCPtr);
    }

    public float M12()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_M12(this.swigCPtr);
    }

    public float M21()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_M21(this.swigCPtr);
    }

    public float M22()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_M22(this.swigCPtr);
    }

    public float X()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_X(this.swigCPtr);
    }

    public float Y()
    {
      return CocoStudioEngineAdapterPINVOKE.CSMatrix_Y(this.swigCPtr);
    }

    public void SetM11(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetM11(this.swigCPtr, v);
    }

    public void SetM12(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetM12(this.swigCPtr, v);
    }

    public void SetM21(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetM21(this.swigCPtr, v);
    }

    public void SetM22(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetM22(this.swigCPtr, v);
    }

    public void SetX(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetX(this.swigCPtr, v);
    }

    public void SetY(float v)
    {
      CocoStudioEngineAdapterPINVOKE.CSMatrix_SetY(this.swigCPtr, v);
    }
  }
}
