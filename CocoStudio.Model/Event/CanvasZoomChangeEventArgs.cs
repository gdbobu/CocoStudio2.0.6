// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.CanvasZoomChangeEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Event
{
  public class CanvasZoomChangeEventArgs
  {
    public PointF MousePoint { get; private set; }

    public float ZoomDelta { get; private set; }

    public CanvasZoomChangeEventArgs(float zoomDelta, PointF mousePoint)
    {
      this.ZoomDelta = zoomDelta;
      this.MousePoint = mousePoint;
    }

    public CanvasZoomChangeEventArgs(float zoomDelta)
    {
      this.ZoomDelta = zoomDelta;
    }
  }
}
