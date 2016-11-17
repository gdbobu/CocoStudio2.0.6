// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.MatrixNode
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using System;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  public class MatrixNode : IDisposable
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

    public float CScaleX
    {
      get
      {
        return this.ScaleX();
      }
    }

    public float CScaleY
    {
      get
      {
        return this.ScaleY();
      }
    }

    public float CSkewX
    {
      get
      {
        return this.SkewX();
      }
    }

    public float CSkewY
    {
      get
      {
        return this.SkewY();
      }
    }

    public MatrixNode(IntPtr cPtr, bool cMemoryOwn)
    {
      this.swigCMemOwn = cMemoryOwn;
      this.swigCPtr = new HandleRef((object) this, cPtr);
    }

    public MatrixNode()
      : this(CocoStudioEngineAdapterPINVOKE.new_MatrixNode(), true)
    {
    }

    ~MatrixNode()
    {
      this.Dispose();
    }

    public override bool Equals(object obj)
    {
      if (!(obj is MatrixNode))
        return false;
      MatrixNode matrixNode = (MatrixNode) obj;
      return obj != null && (double) this.CX == (double) matrixNode.CX && ((double) this.CY == (double) matrixNode.CY && (double) this.CScaleX == (double) matrixNode.CScaleX) && ((double) this.CScaleY == (double) matrixNode.CScaleY && (double) this.CSkewX == (double) matrixNode.CSkewX) && (double) this.CSkewY == (double) matrixNode.CSkewY;
    }

    public override int GetHashCode()
    {
      float num1 = this.CX;
      int hashCode1 = num1.GetHashCode();
      num1 = this.CY;
      int hashCode2 = num1.GetHashCode();
      int num2 = hashCode1 ^ hashCode2;
      num1 = this.CScaleX;
      int hashCode3 = num1.GetHashCode();
      num1 = this.CScaleY;
      int hashCode4 = num1.GetHashCode();
      int num3 = hashCode3 ^ hashCode4;
      int num4 = num2 | num3;
      num1 = this.CSkewX;
      int hashCode5 = num1.GetHashCode();
      num1 = this.CSkewY;
      int hashCode6 = num1.GetHashCode();
      int num5 = hashCode5 ^ hashCode6;
      return num4 | num5;
    }

    public static HandleRef getCPtr(MatrixNode obj)
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
                CocoStudioEngineAdapterPINVOKE.delete_MatrixNode(this.swigCPtr);
              }));
            else
              CocoStudioEngineAdapterPINVOKE.delete_MatrixNode(this.swigCPtr);
          }
          this.swigCPtr = new HandleRef((object) null, IntPtr.Zero);
        }
        GC.SuppressFinalize((object) this);
      }
    }

    public void init(CSVisualObject node)
    {
      CocoStudioEngineAdapterPINVOKE.MatrixNode_init(this.swigCPtr, CSVisualObject.getCPtr(node));
    }

    public void print()
    {
      CocoStudioEngineAdapterPINVOKE.MatrixNode_print(this.swigCPtr);
    }

    public float X()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_X(this.swigCPtr);
    }

    public float Y()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_Y(this.swigCPtr);
    }

    public float ScaleX()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_ScaleX(this.swigCPtr);
    }

    public float ScaleY()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_ScaleY(this.swigCPtr);
    }

    public float SkewX()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_SkewX(this.swigCPtr);
    }

    public float SkewY()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_SkewY(this.swigCPtr);
    }

    public float AnchorPointX()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_AnchorPointX(this.swigCPtr);
    }

    public float AnchorPointY()
    {
      return CocoStudioEngineAdapterPINVOKE.MatrixNode_AnchorPointY(this.swigCPtr);
    }
  }
}
