// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.AnchorPointFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class AnchorPointFrame : PointFrame
  {
    private CSTimelineAnchorPointFrame innerAnchorPointFrame;

    public override float X
    {
      get
      {
        return this.innerAnchorPointFrame.GetAnchorPointX();
      }
      set
      {
        if ((double) value == (double) this.X)
          return;
        this.innerAnchorPointFrame.SetAnchorPointX(value);
      }
    }

    public override float Y
    {
      get
      {
        return this.innerAnchorPointFrame.GetAnchorPointY();
      }
      set
      {
        if ((double) value == (double) this.Y)
          return;
        this.innerAnchorPointFrame.SetAnchorPointY(value);
      }
    }

    public AnchorPointFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerAnchorPointFrame = new CSTimelineAnchorPointFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.X = node.AnchorPoint.ScaleX;
      this.Y = node.AnchorPoint.ScaleY;
      base.UpdateProperty(node);
    }
  }
}
