using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel
{
	public class TimelineActionManager : BaseObject
	{
		private HashSet<string> supportingFrameType = new HashSet<string>();

		private static TimelineActionManager timelineAction = null;

		public event CurrentFrameIndexChangedHandler CurrentFrameIndexChangedEvent;

		public event AnimationPlayHandler AnimationPlayEvent;

		public bool CanAutoKey
		{
			get;
			set;
		}

		public bool CanAutoCreateFirstFrame
		{
			get;
			set;
		}

		public bool CanGotoFrame
		{
			get;
			set;
		}

		public TimelineAction CurrentTimelineAction
		{
			get;
			private set;
		}

		[UndoProperty]
		public int CurrentFrameIndex
		{
			get
			{
				int result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.CurrentFrameIndex;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null && this.CanGotoFrame)
				{
					this.CanAutoKey = false;
					int currentFrameIndex = this.CurrentFrameIndex;
					if (value < 0)
					{
						value = 0;
					}
					if (this.IsPlaying)
					{
						if (this.AnimationPlayEvent != null)
						{
							this.AnimationPlayEvent(false);
						}
					}
					this.CurrentTimelineAction.CurrentFrameIndex = value;
					this.RaisePropertyChanged<int>(() => this.CurrentFrameIndex);
					if (this.CurrentFrameIndexChangedEvent != null)
					{
						this.CurrentFrameIndexChangedEvent();
					}
					this.CanAutoKey = true;
				}
			}
		}

		public int Duration
		{
			get
			{
				int result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.Duration;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.Duration = value;
				}
			}
		}

		public bool AutoKey
		{
			get
			{
				return this.CurrentTimelineAction != null && this.CurrentTimelineAction.AutoKey;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.AutoKey = value;
				}
			}
		}

		public int AutoCreateFrameDuraton
		{
			get
			{
				int result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.AutoCreateFrameDuraton;
				}
				else
				{
					result = 5;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.AutoCreateFrameDuraton = value;
				}
			}
		}

		public bool Loop
		{
			get
			{
				return this.CurrentTimelineAction == null || this.CurrentTimelineAction.Loop;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.Loop = value;
				}
			}
		}

		public float Speed
		{
			get
			{
				float result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.Speed;
				}
				else
				{
					result = 1f;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.Speed = value;
				}
			}
		}

		public bool IsPlaying
		{
			get
			{
				return this.CurrentTimelineAction != null && this.CurrentTimelineAction.IsPlaying;
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
				{
					TimelineActionManager.timelineAction = new TimelineActionManager();
				}
				return TimelineActionManager.timelineAction;
			}
		}

		public bool OnionSkinEnable
		{
			get
			{
				return this.CurrentTimelineAction != null && this.CurrentTimelineAction.OnionSkinEnable;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.OnionSkinEnable = value;
				}
			}
		}

		public int OnionPreSkinNum
		{
			get
			{
				int result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.OnionPreSkinNum;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.OnionPreSkinNum = value;
				}
			}
		}

		public int OnionSuffSkinNum
		{
			get
			{
				int result;
				if (this.CurrentTimelineAction != null)
				{
					result = this.CurrentTimelineAction.OnionSuffSkinNum;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				if (this.CurrentTimelineAction != null)
				{
					this.CurrentTimelineAction.OnionSuffSkinNum = value;
				}
			}
		}

		private TimelineActionManager()
		{
			this.CanGotoFrame = true;
			this.CanAutoCreateFirstFrame = true;
			this.InitSupportingFrameType();
			this.BindingRecorder(null);
		}

		private void InitSupportingFrameType()
		{
			this.SupportingFrameType.Add(typeof(PositionFrame).Name);
			this.SupportingFrameType.Add(typeof(ScaleFrame).Name);
			this.SupportingFrameType.Add(typeof(RotationSkewFrame).Name);
			this.SupportingFrameType.Add(typeof(ZOrderFrame).Name);
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
			if (this.CurrentTimelineAction != null)
			{
				this.CurrentTimelineAction.Clear();
			}
		}

		public void Play(bool play = true)
		{
			this.CanAutoKey = !play;
			if (this.CurrentTimelineAction != null)
			{
				this.CurrentTimelineAction.Play(play);
			}
			if (this.AnimationPlayEvent != null)
			{
				this.AnimationPlayEvent(play);
			}
		}

		public bool IsFrameOnionKey(int frameindex = -1)
		{
			return this.CurrentTimelineAction != null && this.CurrentTimelineAction.IsOnionKeyFrame(frameindex);
		}

		public void AddOnionKeyFrame(int frameIndex)
		{
			if (this.CurrentTimelineAction != null)
			{
				this.CurrentTimelineAction.AddOnionKeyFrame(frameIndex);
			}
		}

		public void RemoveOnionKeyFrame(int frameIndex)
		{
			if (this.CurrentTimelineAction != null)
			{
				this.CurrentTimelineAction.RemoveOnionKeyFrame(frameIndex);
			}
		}
	}
}
