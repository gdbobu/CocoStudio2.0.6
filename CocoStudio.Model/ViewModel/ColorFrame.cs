// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ColorFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
  public class ColorFrame : Frame
  {
    private CSTimelineColorFrame innerColorFrame;

    public virtual Color Color
    {
      get
      {
        return this.innerColorFrame.GetColor();
      }
      set
      {
        if (!(value != this.Color))
          return;
        this.innerColorFrame.SetColor(value);
      }
    }

    public virtual int Alpha
    {
      get
      {
        return this.innerColorFrame.GetAlpha();
      }
      set
      {
        if (value == this.Alpha)
          return;
        this.innerColorFrame.SetAlpha(value);
      }
    }

    public ColorFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerColorFrame = new CSTimelineColorFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.Color = node.CColor;
      this.Alpha = node.Alpha;
      base.UpdateProperty(node);
    }

    public override void Copy(Frame frame)
    {
      base.Copy(frame);
      ColorFrame colorFrame = frame as ColorFrame;
      if (colorFrame == null)
        return;
      this.Color = colorFrame.Color;
    }
  }
}
