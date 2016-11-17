using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gdk;
using System;
using System.Collections.Specialized;

namespace CocoStudio.Model.ViewModel
{
	public abstract class Frame : ModelObject
	{
		private const int FRAME_SPACE = 16;

		protected CSTimelineFrame innerClass;

		private int renderFrameIndex = 0;

		protected bool select;

		private Rectangle rect;

		private Rectangle hitRect;

		public event Action<Frame> FrameIndexChangedEvent;

		public event Action<Frame> RenderFrameIndexChangedEvent;

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
				this.RaisePropertyChanged<int>(() => this.FrameIndex);
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
				this.RaisePropertyChanged<bool>(() => this.Tween);
			}
		}

		public CSTimelineFrame InnerClass
		{
			get
			{
				return this.innerClass;
			}
		}

		public virtual ITimeline Timeline
		{
			get;
			set;
		}

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

		public static Frame CreateFrame(string frameType, int frameIndex)
		{
			Frame frame = Frame.CreateFrame(frameType);
			frame.FrameIndex = frameIndex;
			return frame;
		}

		public static Frame CreateFrame(string frameType)
		{
			string typeName = typeof(Frame).Namespace + "." + frameType;
			return Activator.CreateInstance(Type.GetType(typeName), true) as Frame;
		}

		public static Frame CreateFrame(Frame frame)
		{
			Frame frame2 = Frame.CreateFrame((frame.Timeline as Timeline).FrameType);
			frame2.Copy(frame);
			return frame2;
		}

		public virtual void EmitFrameIndexChangedEvent(int index)
		{
			if (this.FrameIndex != index && this.FrameIndexChangedEvent != null)
			{
				this.FrameIndexChangedEvent(this);
			}
		}

		public virtual void EmitRenderFrameIndexChangedEvent(int index)
		{
			if (this.RenderFrameIndex != index && this.RenderFrameIndexChangedEvent != null)
			{
				this.RenderFrameIndexChangedEvent(this);
			}
		}

		public virtual bool HitTest(Point point)
		{
			return this.HitRect.Contains(point);
		}

		public Frame()
		{
		}

		public virtual void UpdateProperty(NodeObject node)
		{
			if (this.Timeline != null)
			{
				Frame frame = this;
				foreach (Frame current in this.Timeline.Frames)
				{
					if (current.FrameIndex > this.FrameIndex)
					{
						frame = current;
						break;
					}
				}
				this.InnerClass.OnEnter(frame.InnerClass);
			}
		}

		public virtual void RemoveFromTimeline()
		{
			if (this.Timeline != null)
			{
				this.Timeline.Frames.Remove(this);
			}
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
