// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Input.MouseWheelEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Gdk;

namespace CocoStudio.Model.ViewModel.Input
{
  public class MouseWheelEventArgs
  {
    public int Delta { get; private set; }

    public Point Point { get; private set; }

    public MouseWheelEventArgs(Point point, int delta)
    {
      this.Point = point;
      this.Delta = delta;
    }
  }
}
