using CocoStudio.EngineAdapterWrap;
using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel
{
	public class TimelineAction
	{
		private CSTimelineAction innerClass;

		private List<Timeline> timelines = new List<Timeline>();

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

		public bool AutoKey
		{
			get;
			set;
		}

		public int AutoCreateFrameDuraton
		{
			get;
			set;
		}

		public bool Loop
		{
			get;
			set;
		}

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
			Timeline timeline = null;
			node.Timelines.ForEach(delegate(Timeline t)
			{
				if (t.FrameType == FrameType)
				{
					timeline = t;
				}
			});
			if (node.Parent != null && timeline == null && autoCreate)
			{
				timeline = Timeline.CreateTimeline(FrameType, node);
			}
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
			foreach (Timeline current in this.timelines)
			{
				if (current.Duration > num)
				{
					num = current.Duration;
				}
			}
			this.Duration = num;
		}

		public void InitWithRootNode(NodeObject node)
		{
			foreach (NodeObject current in node.Children)
			{
				this.InitNodeItem(current);
			}
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
			TimelineAction.GetNodeTimeline(node, typeof(PositionFrame).Name, true);
			TimelineAction.GetNodeTimeline(node, typeof(ScaleFrame).Name, true);
			TimelineAction.GetNodeTimeline(node, typeof(RotationSkewFrame).Name, true);
			foreach (NodeObject current in node.Children)
			{
				this.InitNodeItem(current);
			}
			foreach (Timeline current2 in node.Timelines)
			{
				this.AddTimeline(current2);
			}
		}

		public void Clear()
		{
			List<Timeline> list = new List<Timeline>(this.timelines);
			foreach (Timeline current in list)
			{
				this.RemoveTimeline(current);
			}
			this.timelines.Clear();
		}

		public void Play(bool play = true)
		{
			if (play)
			{
				if (this.CurrentFrameIndex == this.Duration && !this.Loop)
				{
					this.CurrentFrameIndex = 0;
				}
				this.innerClass.Play(0, this.Duration, this.CurrentFrameIndex, this.Loop);
			}
			else
			{
				this.innerClass.Pause();
			}
		}

		public bool IsOnionKeyFrame(int frameindex = -1)
		{
			bool result;
			if (-1 == frameindex)
			{
				result = this.innerClass.IsOnionKeyFrame(this.CurrentFrameIndex);
			}
			else
			{
				result = this.innerClass.IsOnionKeyFrame(frameindex);
			}
			return result;
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
