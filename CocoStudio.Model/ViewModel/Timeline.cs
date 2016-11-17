// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Timeline
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace CocoStudio.Model.ViewModel
{
  public class Timeline : BaseObject, ITimeline
  {
    private CSTimeline innerClass;
    private string frameType;
    private NodeObject node;
    private ObservableCollection<Frame> frames;
    private List<Frame> orderedFrames;

    public CSTimeline InnerClass
    {
      get
      {
        return this.innerClass;
      }
    }

    public string FrameType
    {
      get
      {
        return this.frameType;
      }
      set
      {
        this.frameType = value;
      }
    }

    public NodeObject Node
    {
      get
      {
        return this.node;
      }
      private set
      {
        this.node = value;
        this.innerClass.SetActionObject(this.node.GetCSVisual());
        this.innerClass.SetActionTag(this.node.ActionTag);
      }
    }

    [UndoProperty]
    public ObservableCollection<Frame> Frames
    {
      get
      {
        return this.frames;
      }
    }

    public List<Frame> OrderedFrames
    {
      get
      {
        return this.orderedFrames;
      }
    }

    public int Duration { get; private set; }

    public event EventHandler<RenderFrameIndexChangedEventArgs> RenderFrameIndexChangedEvent;

    public event EventHandler<TimelineDurationChangedEventArgs> DurationChangedEvent;

    public Timeline(NodeObject node)
    {
      this.innerClass = new CSTimeline();
      this.Node = node;
      this.frames = new ObservableCollection<Frame>();
      this.Frames.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnFrameCollectionChanged);
      this.orderedFrames = new List<Frame>();
      this.BindingRecorder((string) null);
    }

    public static Timeline CreateTimeline(string name, NodeObject node)
    {
      Timeline timeline = new Timeline(node);
      timeline.FrameType = name;
      node.Timelines.Add(timeline);
      return timeline;
    }

    private HandlerFrame GetNodeHandlerFrameAtIndex(int index)
    {
      HandlerFrame handlerFrame = (HandlerFrame) null;
      foreach (Frame frame in (Collection<Frame>) this.Node.Frames)
      {
        if (frame.FrameIndex == index)
        {
          handlerFrame = frame as HandlerFrame;
          break;
        }
      }
      return handlerFrame;
    }

    private HandlerFrame AddHandlerFrameAtIndex(int index, Frame frame)
    {
      HandlerFrame handlerFrame = this.GetNodeHandlerFrameAtIndex(index);
      if (handlerFrame == null)
      {
        handlerFrame = new HandlerFrame();
        handlerFrame.FrameIndex = index;
        this.Node.Frames.Add((Frame) handlerFrame);
      }
      handlerFrame.Frames.Add(frame);
      return handlerFrame;
    }

    private HandlerFrame RemoveHandlerFrame(Frame frame)
    {
      ObservableCollection<Frame> frames = this.Node.Frames;
      HandlerFrame handlerFrame = (HandlerFrame) null;
      foreach (Frame frame1 in (Collection<Frame>) frames)
      {
        handlerFrame = frame1 as HandlerFrame;
        if (handlerFrame.Frames.Contains(frame))
          break;
      }
      if (handlerFrame != null)
        handlerFrame.Frames.Remove(frame);
      return handlerFrame;
    }

    private void UpdateDuration()
    {
      int num = 0;
      Frame frame = this.OrderedFrames.LastOrDefault<Frame>();
      if (frame != null)
        num = frame.FrameIndex;
      if (num == this.Duration)
        return;
      this.Duration = num;
      this.RaiseDurationChangedEvent();
    }

    private void RaiseDurationChangedEvent()
    {
      if (this.DurationChangedEvent == null)
        return;
      this.DurationChangedEvent((object) this, new TimelineDurationChangedEventArgs());
    }

    public void Update()
    {
      this.UpdateDuration();
      this.InnerClass.ClearSearchState();
      if (Services.TaskService.IsUndoing)
        return;
      TimelineActionManager.Instance.CurrentFrameIndex = TimelineActionManager.Instance.CurrentFrameIndex;
    }

    protected void RemoveFrame(Frame frame)
    {
      this.OrderedFrames.Remove(frame);
      this.innerClass.RemoveFrame(frame.InnerClass);
      this.RemoveHandlerFrame(frame);
      this.Update();
    }

    protected void AddFrameAndSort(Frame frame)
    {
      int frameIndex = frame.FrameIndex;
      int index1 = 0;
      if (this.OrderedFrames.Count != 0 && frameIndex >= this.OrderedFrames[0].FrameIndex)
      {
        for (int index2 = this.OrderedFrames.Count - 1; index2 >= 0; --index2)
        {
          if (frameIndex > this.OrderedFrames[index2].FrameIndex)
          {
            index1 = index2 + 1;
            break;
          }
          if (frameIndex == this.OrderedFrames[index2].FrameIndex)
          {
            index1 = index2;
            this.Frames.Remove(this.OrderedFrames[index2]);
            break;
          }
        }
      }
      this.innerClass.InsertFrame(index1, frame.InnerClass);
      this.OrderedFrames.Insert(index1, frame);
      this.AddHandlerFrameAtIndex(frame.RenderFrameIndex, frame);
      this.Update();
    }

    public Frame GetTimelineFrameAtIndex(int frameIndex, bool autoCreate = true)
    {
      Frame frame = (Frame) null;
      this.Frames.ForEach<Frame>((Action<Frame>) (f =>
      {
        if (f.FrameIndex != frameIndex)
          return;
        frame = f;
      }));
      if (frame == null && autoCreate)
      {
        frame = Frame.CreateFrame(this.FrameType, frameIndex);
        frame.UpdateProperty(this.node);
        this.Frames.Add(frame);
      }
      return frame;
    }

    public bool NeedAutoCreateFirstFrame(int frameIndex)
    {
      return false;
    }

    public void AutoCreateFirstFrame()
    {
    }

    private void OnRenderFrameIndexChanged(Frame frame)
    {
      this.RemoveHandlerFrame(frame);
      this.AddHandlerFrameAtIndex(frame.RenderFrameIndex, frame);
      this.RaiseRenderFrameIndexChangedEvent(frame);
    }

    private void RaiseRenderFrameIndexChangedEvent(Frame frame)
    {
      if (this.RenderFrameIndexChangedEvent == null)
        return;
      this.RenderFrameIndexChangedEvent((object) this, new RenderFrameIndexChangedEventArgs(frame));
    }

    private void OnFrameIndexChangedEvent(Frame frame)
    {
      this.RemoveFrame(frame);
      this.AddFrameAndSort(frame);
    }

    private void OnFrameCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.NewItems != null)
      {
        foreach (object newItem in (IEnumerable) e.NewItems)
        {
          Frame frame = newItem as Frame;
          frame.Timeline = (ITimeline) this;
          frame.InnerClass.SetActionObject(this.node.GetCSVisual());
          this.AddFrameAndSort(frame);
          frame.AncestorObjectChanged((BaseObject) this, e.Action);
          frame.RenderFrameIndexChangedEvent += new Action<Frame>(this.OnRenderFrameIndexChanged);
          frame.FrameIndexChangedEvent += new Action<Frame>(this.OnFrameIndexChangedEvent);
        }
      }
      if (e.OldItems == null)
        return;
      foreach (object oldItem in (IEnumerable) e.OldItems)
      {
        Frame frame = oldItem as Frame;
        frame.Timeline = (ITimeline) null;
        this.RemoveFrame(frame);
        frame.AncestorObjectChanged((BaseObject) this, e.Action);
        frame.RenderFrameIndexChangedEvent -= new Action<Frame>(this.OnRenderFrameIndexChanged);
        frame.FrameIndexChangedEvent -= new Action<Frame>(this.OnFrameIndexChangedEvent);
      }
    }

    internal void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
    {
      foreach (Frame frame in (Collection<Frame>) this.Frames)
        frame.AncestorObjectChanged(sourceObj, action);
    }
  }
}
