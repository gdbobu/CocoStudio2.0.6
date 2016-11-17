using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.ViewModel
{
	public class HandlerFrame : Frame
	{
		private int frameIndex;

		public ObservableCollection<Frame> Frames
		{
			get;
			set;
		}

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
				foreach (Frame current in this.Frames)
				{
					current.FrameIndex = value;
				}
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
				ObservableCollection<Frame> observableCollection = new ObservableCollection<Frame>(this.Frames);
				foreach (Frame current in observableCollection)
				{
					current.RenderFrameIndex = value;
				}
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
				foreach (Frame current in this.Frames)
				{
					current.Select = value;
				}
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
			for (int i = 0; i < this.Frames.Count; i++)
			{
				this.Frames[i].EmitFrameIndexChangedEvent(index);
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
		}

		public override void RemoveFromTimeline()
		{
			foreach (Frame current in this.Frames)
			{
				current.RemoveFromTimeline();
			}
		}
	}
}
