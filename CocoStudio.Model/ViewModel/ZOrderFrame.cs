// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ZOrderFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class ZOrderFrame : IntFrame
  {
    private CSTimelineZOrderFrame innerZOrderFrame;

    public override int Value
    {
      get
      {
        return this.innerZOrderFrame.GetZOrder();
      }
      set
      {
        if (value == this.Value)
          return;
        this.innerZOrderFrame.SetZOrder(value);
      }
    }

    public ZOrderFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerZOrderFrame = new CSTimelineZOrderFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.Value = node.ZOrder;
    }
  }
}
