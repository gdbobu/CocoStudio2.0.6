// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Frame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gdk;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public abstract class Frame : ModelObject
  {
    private int renderFrameIndex = 0;
    private const int FRAME_SPACE = 16;
    protected CSTimelineFrame innerClass;
    protected bool select;
    private Rectangle rect;
    private Rectangle hitRect;

    [UndoProperty]
    public virtual int FrameIndex
    {
      get
      {
        return this.innerClass.GetFrameIndex();
      }
      set
      {
        int frameIndex = this.FrameIndex;
        this.RenderFrameIndex = value;
        this.innerClass.SetFrameIndex(value);
        this.EmitRenderFrameIndexChangedEvent(frameIndex);
        this.EmitFrameIndexChangedEvent(frameIndex);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.FrameIndex));
      }
    }

    [UndoProperty]
    public virtual bool Tween
    {
      get
      {
        return this.innerClass.IsTween();
      }
      set
      {
        this.innerClass.SetTween(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.Tween));
      }
    }

    public CSTimelineFrame InnerClass
    {
      get
      {
        return this.innerClass;
      }
    }

    public virtual ITimeline Timeline { get; set; }

    public virtual int RenderFrameIndex
    {
      get
      {
        return this.renderFrameIndex;
      }
      set
      {
        this.renderFrameIndex = value;
      }
    }

    public virtual bool Select
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

    public Rectangle Rect
    {
      get
      {
        return this.rect;
      }
      set
      {
        this.rect = value;
        this.hitRect = this.rect;
        this.hitRect.X = this.hitRect.X + this.hitRect.Width / 2 - 8;
        this.hitRect.Width = 16;
      }
    }

    public Rectangle HitRect
    {
      get
      {
        return this.hitRect;
      }
    }

    public event Action<Frame> FrameIndexChangedEvent;

    public event Action<Frame> RenderFrameIndexChangedEvent;

    public static Frame CreateFrame(string frameType, int frameIndex)
    {
      Frame frame = Frame.CreateFrame(frameType);
      frame.FrameIndex = frameIndex;
      return frame;
    }

    public static Frame CreateFrame(string frameType)
    {
      return Activator.CreateInstance(Type.GetType(typeof (Frame).Namespace + "." + frameType), true) as Frame;
    }

    public static Frame CreateFrame(Frame frame)
    {
      Frame frame1 = Frame.CreateFrame((frame.Timeline as CocoStudio.Model.ViewModel.Timeline).FrameType);
      frame1.Copy(frame);
      return frame1;
    }

    public virtual void EmitFrameIndexChangedEvent(int index)
    {
      if (this.FrameIndex == index || this.FrameIndexChangedEvent == null)
        return;
      this.FrameIndexChangedEvent(this);
    }

    public virtual void EmitRenderFrameIndexChangedEvent(int index)
    {
      if (this.RenderFrameIndex == index || this.RenderFrameIndexChangedEvent == null)
        return;
      this.RenderFrameIndexChangedEvent(this);
    }

    public virtual bool HitTest(Point point)
    {
      return this.HitRect.Contains(point);
    }

    public virtual void UpdateProperty(NodeObject node)
    {
      if (this.Timeline == null)
        return;
      Frame frame1 = this;
      foreach (Frame frame2 in (Collection<Frame>) this.Timeline.Frames)
      {
        if (frame2.FrameIndex > this.FrameIndex)
        {
          frame1 = frame2;
          break;
        }
      }
      this.InnerClass.OnEnter(frame1.InnerClass);
    }

    public virtual void RemoveFromTimeline()
    {
      if (this.Timeline == null)
        return;
      this.Timeline.Frames.Remove(this);
    }

    public virtual void Copy(Frame frame)
    {
      this.FrameIndex = frame.FrameIndex;
      this.Tween = frame.Tween;
      this.Timeline = frame.Timeline;
    }

    internal virtual void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
    {
    }
  }
}
