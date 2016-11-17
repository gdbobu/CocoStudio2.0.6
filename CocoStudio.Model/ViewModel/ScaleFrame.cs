// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ScaleFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class ScaleFrame : PointFrame
  {
    private CSTimelineScaleFrame innerScaleFrame;

    public override float X
    {
      get
      {
        return this.innerScaleFrame.GetScaleX();
      }
      set
      {
        if ((double) value == (double) this.X)
          return;
        this.innerScaleFrame.SetScaleX(value);
      }
    }

    public override float Y
    {
      get
      {
        return this.innerScaleFrame.GetScaleY();
      }
      set
      {
        if ((double) value == (double) this.Y)
          return;
        this.innerScaleFrame.SetScaleY(value);
      }
    }

    public ScaleFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerScaleFrame = new CSTimelineScaleFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.X = node.Scale.ScaleX;
      this.Y = node.Scale.ScaleY;
      base.UpdateProperty(node);
    }
  }
}
