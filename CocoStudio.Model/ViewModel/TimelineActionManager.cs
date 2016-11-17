// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TimelineActionManager
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public class TimelineActionManager : BaseObject
  {
    private static TimelineActionManager timelineAction = (TimelineActionManager) null;
    private HashSet<string> supportingFrameType = new HashSet<string>();

    public bool CanAutoKey { get; set; }

    public bool CanAutoCreateFirstFrame { get; set; }

    public bool CanGotoFrame { get; set; }

    public TimelineAction CurrentTimelineAction { get; private set; }

    [UndoProperty]
    public int CurrentFrameIndex
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.CurrentFrameIndex;
        return 0;
      }
      set
      {
        if (this.CurrentTimelineAction == null || !this.CanGotoFrame)
          return;
        this.CanAutoKey = false;
        int currentFrameIndex = this.CurrentFrameIndex;
        if (value < 0)
          value = 0;
        if (this.IsPlaying && this.AnimationPlayEvent != null)
          this.AnimationPlayEvent(false);
        this.CurrentTimelineAction.CurrentFrameIndex = value;
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.CurrentFrameIndex));
        if (this.CurrentFrameIndexChangedEvent != null)
          this.CurrentFrameIndexChangedEvent();
        this.CanAutoKey = true;
      }
    }

    public int Duration
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.Duration;
        return 0;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.Duration = value;
      }
    }

    public bool AutoKey
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.AutoKey;
        return false;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.AutoKey = value;
      }
    }

    public int AutoCreateFrameDuraton
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.AutoCreateFrameDuraton;
        return 5;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.AutoCreateFrameDuraton = value;
      }
    }

    public bool Loop
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.Loop;
        return true;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.Loop = value;
      }
    }

    public float Speed
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.Speed;
        return 1f;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.Speed = value;
      }
    }

    public bool IsPlaying
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.IsPlaying;
        return false;
      }
    }

    public HashSet<string> SupportingFrameType
    {
      get
      {
        return this.supportingFrameType;
      }
    }

    public static TimelineActionManager Instance
    {
      get
      {
        if (TimelineActionManager.timelineAction == null)
          TimelineActionManager.timelineAction = new TimelineActionManager();
        return TimelineActionManager.timelineAction;
      }
    }

    public bool OnionSkinEnable
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.OnionSkinEnable;
        return false;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.OnionSkinEnable = value;
      }
    }

    public int OnionPreSkinNum
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.OnionPreSkinNum;
        return 0;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.OnionPreSkinNum = value;
      }
    }

    public int OnionSuffSkinNum
    {
      get
      {
        if (this.CurrentTimelineAction != null)
          return this.CurrentTimelineAction.OnionSuffSkinNum;
        return 0;
      }
      set
      {
        if (this.CurrentTimelineAction == null)
          return;
        this.CurrentTimelineAction.OnionSuffSkinNum = value;
      }
    }

    public event CurrentFrameIndexChangedHandler CurrentFrameIndexChangedEvent;

    public event AnimationPlayHandler AnimationPlayEvent;

    private TimelineActionManager()
    {
      this.CanGotoFrame = true;
      this.CanAutoCreateFirstFrame = true;
      this.InitSupportingFrameType();
      this.BindingRecorder((string) null);
    }

    private void InitSupportingFrameType()
    {
      this.SupportingFrameType.Add(typeof (PositionFrame).Name);
      this.SupportingFrameType.Add(typeof (ScaleFrame).Name);
      this.SupportingFrameType.Add(typeof (RotationSkewFrame).Name);
      this.SupportingFrameType.Add(typeof (ZOrderFrame).Name);
    }

    public void AddTimeline(Timeline timeline)
    {
      this.CurrentTimelineAction.AddTimeline(timeline);
    }

    public void RemoveTimeline(Timeline timeline)
    {
      this.CurrentTimelineAction.RemoveTimeline(timeline);
    }

    public void ReCalcDuration()
    {
      this.CurrentTimelineAction.ReCalcDuration();
    }

    public void InitWithRootNode(NodeObject node, TimelineAction action)
    {
      this.CurrentTimelineAction = action;
      this.CurrentTimelineAction.ActiveAction(node);
    }

    public void Clear()
    {
      if (this.CurrentTimelineAction == null)
        return;
      this.CurrentTimelineAction.Clear();
    }

    public void Play(bool play = true)
    {
      this.CanAutoKey = !play;
      if (this.CurrentTimelineAction != null)
        this.CurrentTimelineAction.Play(play);
      if (this.AnimationPlayEvent == null)
        return;
      this.AnimationPlayEvent(play);
    }

    public bool IsFrameOnionKey(int frameindex = -1)
    {
      if (this.CurrentTimelineAction != null)
        return this.CurrentTimelineAction.IsOnionKeyFrame(frameindex);
      return false;
    }

    public void AddOnionKeyFrame(int frameIndex)
    {
      if (this.CurrentTimelineAction == null)
        return;
      this.CurrentTimelineAction.AddOnionKeyFrame(frameIndex);
    }

    public void RemoveOnionKeyFrame(int frameIndex)
    {
      if (this.CurrentTimelineAction == null)
        return;
      this.CurrentTimelineAction.RemoveOnionKeyFrame(frameIndex);
    }
  }
}
