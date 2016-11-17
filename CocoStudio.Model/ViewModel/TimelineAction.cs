// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TimelineAction
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.ViewModel
{
  public class TimelineAction
  {
    private List<Timeline> timelines = new List<Timeline>();
    private CSTimelineAction innerClass;

    [UndoProperty]
    public int CurrentFrameIndex
    {
      get
      {
        return this.innerClass.GetCurrentFrame();
      }
      set
      {
        this.innerClass.GotoFrame(value);
      }
    }

    public int Duration
    {
      get
      {
        return this.innerClass.GetDuration();
      }
      set
      {
        this.innerClass.SetDuration(value);
      }
    }

    public bool AutoKey { get; set; }

    public int AutoCreateFrameDuraton { get; set; }

    public bool Loop { get; set; }

    public float Speed
    {
      get
      {
        return this.innerClass.GetTimeSpeed();
      }
      set
      {
        this.innerClass.SetTimeSpeed(value);
      }
    }

    public bool IsPlaying
    {
      get
      {
        return this.innerClass.IsPlaying();
      }
    }

    public bool OnionSkinEnable
    {
      get
      {
        return this.innerClass.IsOnionSkinEnable();
      }
      set
      {
        this.innerClass.SetOnionSkinEnable(value);
      }
    }

    public int OnionPreSkinNum
    {
      get
      {
        return this.innerClass.GetOnionSkinPreNum();
      }
      set
      {
        this.innerClass.SetOnionSkinPreNum(value);
      }
    }

    public int OnionSuffSkinNum
    {
      get
      {
        return this.innerClass.GetOnionSkinSuffNum();
      }
      set
      {
        this.innerClass.SetOnionSkinSuffNum(value);
      }
    }

    public TimelineAction()
    {
      this.innerClass = new CSTimelineAction();
      this.Speed = 1f;
      this.AutoCreateFrameDuraton = 5;
      this.AutoKey = false;
      this.Loop = true;
    }

    public static Timeline GetNodeTimeline(NodeObject node, string FrameType, bool autoCreate = true)
    {
      Timeline timeline = (Timeline) null;
      node.Timelines.ForEach<Timeline>((Action<Timeline>) (t =>
      {
        if (!(t.FrameType == FrameType))
          return;
        timeline = t;
      }));
      if (node.Parent != null && timeline == null && autoCreate)
        timeline = Timeline.CreateTimeline(FrameType, node);
      return timeline;
    }

    public void AddTimeline(Timeline timeline)
    {
      this.innerClass.AddTimeline(timeline.InnerClass);
      this.timelines.Add(timeline);
      timeline.DurationChangedEvent += new EventHandler<TimelineDurationChangedEventArgs>(this.TimelineDurationChangedHandle);
    }

    private void TimelineDurationChangedHandle(object sender, TimelineDurationChangedEventArgs e)
    {
      this.ReCalcDuration();
    }

    public void RemoveTimeline(Timeline timeline)
    {
      this.innerClass.RemoveTimeline(timeline.InnerClass);
      this.timelines.Remove(timeline);
    }

    public void ReCalcDuration()
    {
      int num = 0;
      foreach (Timeline timeline in this.timelines)
      {
        if (timeline.Duration > num)
          num = timeline.Duration;
      }
      this.Duration = num;
    }

    public void InitWithRootNode(NodeObject node)
    {
      foreach (NodeObject child in (Collection<NodeObject>) node.Children)
        this.InitNodeItem(child);
      this.innerClass.InitWithRootNode(node.GetCSVisual());
      this.CurrentFrameIndex = 0;
    }

    public void ActiveAction(NodeObject node)
    {
      this.innerClass.ActiveAction(node.GetCSVisual());
      this.innerClass.InitWithRootNode(node.GetCSVisual());
    }

    private void InitNodeItem(NodeObject node)
    {
      TimelineAction.GetNodeTimeline(node, typeof (PositionFrame).Name, true);
      TimelineAction.GetNodeTimeline(node, typeof (ScaleFrame).Name, true);
      TimelineAction.GetNodeTimeline(node, typeof (RotationSkewFrame).Name, true);
      foreach (NodeObject child in (Collection<NodeObject>) node.Children)
        this.InitNodeItem(child);
      foreach (Timeline timeline in (Collection<Timeline>) node.Timelines)
        this.AddTimeline(timeline);
    }

    public void Clear()
    {
      foreach (Timeline timeline in new List<Timeline>((IEnumerable<Timeline>) this.timelines))
        this.RemoveTimeline(timeline);
      this.timelines.Clear();
    }

    public void Play(bool play = true)
    {
      if (play)
      {
        if (this.CurrentFrameIndex == this.Duration && !this.Loop)
          this.CurrentFrameIndex = 0;
        this.innerClass.Play(0, this.Duration, this.CurrentFrameIndex, this.Loop);
      }
      else
        this.innerClass.Pause();
    }

    public bool IsOnionKeyFrame(int frameindex = -1)
    {
      if (-1 == frameindex)
        return this.innerClass.IsOnionKeyFrame(this.CurrentFrameIndex);
      return this.innerClass.IsOnionKeyFrame(frameindex);
    }

    public void AddOnionKeyFrame(int frameIndex)
    {
      this.innerClass.AddOnionSkinKey(frameIndex);
    }

    public void RemoveOnionKeyFrame(int frameIndex)
    {
      this.innerClass.RemoveOnionSkinKey(frameIndex);
    }
  }
}
