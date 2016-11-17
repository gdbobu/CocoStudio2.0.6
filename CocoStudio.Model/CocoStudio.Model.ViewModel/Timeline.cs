using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using System;
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

		public event EventHandler<RenderFrameIndexChangedEventArgs> RenderFrameIndexChangedEvent;

		public event EventHandler<TimelineDurationChangedEventArgs> DurationChangedEvent;

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

		public int Duration
		{
			get;
			private set;
		}

		public static Timeline CreateTimeline(string name, NodeObject node)
		{
			Timeline timeline = new Timeline(node);
			timeline.FrameType = name;
			node.Timelines.Add(timeline);
			return timeline;
		}

		public Timeline(NodeObject node)
		{
			this.innerClass = new CSTimeline();
			this.Node = node;
			this.frames = new ObservableCollection<Frame>();
			this.Frames.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnFrameCollectionChanged);
			this.orderedFrames = new List<Frame>();
			this.BindingRecorder(null);
		}

		private HandlerFrame GetNodeHandlerFrameAtIndex(int index)
		{
			HandlerFrame result = null;
			foreach (Frame current in this.Node.Frames)
			{
				if (current.FrameIndex == index)
				{
					result = (current as HandlerFrame);
					break;
				}
			}
			return result;
		}

		private HandlerFrame AddHandlerFrameAtIndex(int index, Frame frame)
		{
			HandlerFrame handlerFrame = this.GetNodeHandlerFrameAtIndex(index);
			if (handlerFrame == null)
			{
				handlerFrame = new HandlerFrame();
				handlerFrame.FrameIndex = index;
				this.Node.Frames.Add(handlerFrame);
			}
			handlerFrame.Frames.Add(frame);
			return handlerFrame;
		}

		private HandlerFrame RemoveHandlerFrame(Frame frame)
		{
			ObservableCollection<Frame> observableCollection = this.Node.Frames;
			HandlerFrame handlerFrame = null;
			foreach (Frame current in observableCollection)
			{
				handlerFrame = (current as HandlerFrame);
				if (handlerFrame.Frames.Contains(frame))
				{
					break;
				}
			}
			if (handlerFrame != null)
			{
				handlerFrame.Frames.Remove(frame);
			}
			return handlerFrame;
		}

		private void UpdateDuration()
		{
			int num = 0;
			Frame frame = this.OrderedFrames.LastOrDefault<Frame>();
			if (frame != null)
			{
				num = frame.FrameIndex;
			}
			if (num != this.Duration)
			{
				this.Duration = num;
				this.RaiseDurationChangedEvent();
			}
		}

		private void RaiseDurationChangedEvent()
		{
			if (this.DurationChangedEvent != null)
			{
				this.DurationChangedEvent(this, new TimelineDurationChangedEventArgs());
			}
		}

		public void Update()
		{
			this.UpdateDuration();
			this.InnerClass.ClearSearchState();
			if (!Services.TaskService.IsUndoing)
			{
				TimelineActionManager.Instance.CurrentFrameIndex = TimelineActionManager.Instance.CurrentFrameIndex;
			}
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
			int index = 0;
			if (this.OrderedFrames.Count != 0 && frameIndex >= this.OrderedFrames[0].FrameIndex)
			{
				for (int i = this.OrderedFrames.Count - 1; i >= 0; i--)
				{
					if (frameIndex > this.OrderedFrames[i].FrameIndex)
					{
						index = i + 1;
						break;
					}
					if (frameIndex == this.OrderedFrames[i].FrameIndex)
					{
						index = i;
						this.Frames.Remove(this.OrderedFrames[i]);
						break;
					}
				}
			}
			this.innerClass.InsertFrame(index, frame.InnerClass);
			this.OrderedFrames.Insert(index, frame);
			this.AddHandlerFrameAtIndex(frame.RenderFrameIndex, frame);
			this.Update();
		}

		public Frame GetTimelineFrameAtIndex(int frameIndex, bool autoCreate = true)
		{
			Frame frame = null;
			this.Frames.ForEach(delegate(Frame f)
			{
				if (f.FrameIndex == frameIndex)
				{
					frame = f;
				}
			});
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
			HandlerFrame handlerFrame = this.RemoveHandlerFrame(frame);
			HandlerFrame handlerFrame2 = this.AddHandlerFrameAtIndex(frame.RenderFrameIndex, frame);
			this.RaiseRenderFrameIndexChangedEvent(frame);
		}

		private void RaiseRenderFrameIndexChangedEvent(Frame frame)
		{
			if (this.RenderFrameIndexChangedEvent != null)
			{
				this.RenderFrameIndexChangedEvent(this, new RenderFrameIndexChangedEventArgs(frame));
			}
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
				foreach (object current in e.NewItems)
				{
					Frame frame = current as Frame;
					frame.Timeline = this;
					frame.InnerClass.SetActionObject(this.node.GetCSVisual());
					this.AddFrameAndSort(frame);
					frame.AncestorObjectChanged(this, e.Action);
					frame.RenderFrameIndexChangedEvent += new Action<Frame>(this.OnRenderFrameIndexChanged);
					frame.FrameIndexChangedEvent += new Action<Frame>(this.OnFrameIndexChangedEvent);
				}
			}
			if (e.OldItems != null)
			{
				foreach (object current in e.OldItems)
				{
					Frame frame = current as Frame;
					frame.Timeline = null;
					this.RemoveFrame(frame);
					frame.AncestorObjectChanged(this, e.Action);
					frame.RenderFrameIndexChangedEvent -= new Action<Frame>(this.OnRenderFrameIndexChanged);
					frame.FrameIndexChangedEvent -= new Action<Frame>(this.OnFrameIndexChangedEvent);
				}
			}
		}

		internal void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
		{
			foreach (Frame current in this.Frames)
			{
				current.AncestorObjectChanged(sourceObj, action);
			}
		}
	}
}
