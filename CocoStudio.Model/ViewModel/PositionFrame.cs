// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PositionFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class PositionFrame : PointFrame
  {
    private CSTimelinePositionFrame innerPositionFrame;

    public override float X
    {
      get
      {
        return this.innerPositionFrame.GetX();
      }
      set
      {
        if ((double) value == (double) this.X)
          return;
        this.innerPositionFrame.SetX(value);
      }
    }

    public override float Y
    {
      get
      {
        return this.innerPositionFrame.GetY();
      }
      set
      {
        if ((double) value == (double) this.Y)
          return;
        this.innerPositionFrame.SetY(value);
      }
    }

    public PositionFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerPositionFrame = new CSTimelinePositionFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.X = node.Position.X;
      this.Y = node.Position.Y;
      base.UpdateProperty(node);
    }
  }
}
