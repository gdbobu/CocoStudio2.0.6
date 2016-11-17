// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.HandlerFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.ViewModel
{
  public class HandlerFrame : Frame
  {
    private int frameIndex;

    public ObservableCollection<Frame> Frames { get; set; }

    public override bool Tween
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    public override int FrameIndex
    {
      get
      {
        return this.frameIndex;
      }
      set
      {
        this.RenderFrameIndex = value;
        this.frameIndex = value;
        foreach (Frame frame in (Collection<Frame>) this.Frames)
          frame.FrameIndex = value;
      }
    }

    public override int RenderFrameIndex
    {
      get
      {
        return base.RenderFrameIndex;
      }
      set
      {
        base.RenderFrameIndex = value;
        foreach (Frame frame in (Collection<Frame>) new ObservableCollection<Frame>((IEnumerable<Frame>) this.Frames))
          frame.RenderFrameIndex = value;
      }
    }

    public override bool Select
    {
      get
      {
        return base.Select;
      }
      set
      {
        base.Select = value;
        foreach (Frame frame in (Collection<Frame>) this.Frames)
          frame.Select = value;
      }
    }

    public bool SelectSelf
    {
      get
      {
        return this.select;
      }
      set
      {
        this.select = value;
      }
    }

    public HandlerFrame()
    {
      this.Frames = new ObservableCollection<Frame>();
    }

    public override void EmitFrameIndexChangedEvent(int index)
    {
      for (int index1 = 0; index1 < this.Frames.Count; ++index1)
        this.Frames[index1].EmitFrameIndexChangedEvent(index);
    }

    public override void UpdateProperty(NodeObject node)
    {
    }

    public override void RemoveFromTimeline()
    {
      foreach (Frame frame in (Collection<Frame>) this.Frames)
        frame.RemoveFromTimeline();
    }
  }
}
