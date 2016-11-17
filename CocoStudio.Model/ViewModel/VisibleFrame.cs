// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.VisibleFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class VisibleFrame : BoolFrame
  {
    private CSTimelineVisibleFrame innerVisibleFrame;

    public override bool Value
    {
      get
      {
        return this.innerVisibleFrame.IsVisible();
      }
      set
      {
        if (value == this.Value)
          return;
        this.innerVisibleFrame.SetVisible(value);
      }
    }

    public VisibleFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerVisibleFrame = new CSTimelineVisibleFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.Value = node.VisibleForFrame;
    }
  }
}
