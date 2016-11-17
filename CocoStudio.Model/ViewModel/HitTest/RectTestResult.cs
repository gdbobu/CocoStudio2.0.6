// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.HitTest.RectTestResult
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Gdk;

namespace CocoStudio.Model.ViewModel.HitTest
{
  public class RectTestResult : BaseTestResult
  {
    public Rectangle HitRect { get; private set; }

    public RectTestResult(Rectangle hitRect, bool isContinueTest)
      : this((VisualObject) null, hitRect, isContinueTest)
    {
    }

    public RectTestResult(VisualObject hitVisual, Rectangle hitRect)
      : this(hitVisual, hitRect, hitVisual != null && hitVisual.Visible)
    {
    }

    public RectTestResult(VisualObject hitVisual, Rectangle hitRect, bool isContinueTest)
      : base(hitVisual, isContinueTest)
    {
    }
  }
}
