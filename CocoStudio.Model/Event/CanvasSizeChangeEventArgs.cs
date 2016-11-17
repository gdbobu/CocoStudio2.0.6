// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.CanvasSizeChangeEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Gdk;

namespace CocoStudio.Model.Event
{
  public class CanvasSizeChangeEventArgs
  {
    public string CanvasName { get; private set; }

    public Size NewSize { get; private set; }

    public CanvasSizeChangeEventArgs(string canvasName, Size newSize)
    {
      this.CanvasName = canvasName;
      this.NewSize = newSize;
    }
  }
}
