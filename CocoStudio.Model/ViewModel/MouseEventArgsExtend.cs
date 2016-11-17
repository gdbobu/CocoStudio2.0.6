// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.MouseEventArgsExtend
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel.HitTest;
using Gtk;
using System;

namespace CocoStudio.Model.ViewModel
{
  public class MouseEventArgsExtend : EventArgs
  {
    public HitTestResult HitResult { get; private set; }

    public PointF Point { get; private set; }

    public MouseButton Button { get; private set; }

    public bool Handled { get; set; }

    public MouseEventArgsExtend(PointF point, MouseButton button, HitTestResult result)
    {
      this.Point = point;
      this.Button = button;
      this.HitResult = result;
    }
  }
}
