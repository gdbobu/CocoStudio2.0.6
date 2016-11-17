// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.RotationSkewFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class RotationSkewFrame : PointFrame
  {
    private CSTimelineRotationSkewFrame innerSkewFrame;

    public override float X
    {
      get
      {
        return this.innerSkewFrame.GetSkewX();
      }
      set
      {
        if ((double) value == (double) this.X)
          return;
        this.innerSkewFrame.SetSkewX(value);
      }
    }

    public override float Y
    {
      get
      {
        return this.innerSkewFrame.GetSkewY();
      }
      set
      {
        if ((double) value == (double) this.Y)
          return;
        this.innerSkewFrame.SetSkewY(value);
      }
    }

    public RotationSkewFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerSkewFrame = new CSTimelineRotationSkewFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.X = node.RotationSkew.ScaleX;
      this.Y = node.RotationSkew.ScaleY;
      base.UpdateProperty(node);
    }
  }
}
