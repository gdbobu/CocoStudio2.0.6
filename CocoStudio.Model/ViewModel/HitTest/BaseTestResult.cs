// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.HitTest.BaseTestResult
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;

namespace CocoStudio.Model.ViewModel.HitTest
{
  public abstract class BaseTestResult : IComparable
  {
    public VisualObject HitVisual { get; private set; }

    public bool IsContinueTest { get; private set; }

    public BaseTestResult(VisualObject hitVisual, bool isContinueTest)
    {
      this.HitVisual = hitVisual;
      this.IsContinueTest = isContinueTest;
    }

    public int CompareTo(object obj)
    {
      if (obj == null || !(obj is BaseTestResult))
        return 1;
      BaseTestResult baseTestResult = obj as BaseTestResult;
      if (baseTestResult.HitVisual == null)
        return 1;
      if (this.HitVisual == null)
        return -1;
      return this.HitVisual.CompareTo((object) baseTestResult.HitVisual);
    }
  }
}
