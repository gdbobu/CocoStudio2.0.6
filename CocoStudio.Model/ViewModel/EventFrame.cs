// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.EventFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;

namespace CocoStudio.Model.ViewModel
{
  public class EventFrame : StringFrame
  {
    private CSTimelineEventFrame innerEventFrame;

    public override string Value
    {
      get
      {
        return this.innerEventFrame.GetEvent();
      }
      set
      {
        if (!(value != this.Value))
          return;
        this.innerEventFrame.SetEvent(value);
      }
    }

    public EventFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerEventFrame = new CSTimelineEventFrame());
      this.BindingRecorder((string) null);
    }

    public override void UpdateProperty(NodeObject node)
    {
      this.Value = node.FrameEvent;
    }
  }
}
