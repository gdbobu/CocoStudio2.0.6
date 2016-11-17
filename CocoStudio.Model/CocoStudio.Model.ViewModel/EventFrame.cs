using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class EventFrame : StringFrame
	{
		private CSTimelineEventFrame innerEventFrame;

		public override string Value
		{
			get
			{
				return this.innerEventFrame.GetEvent();
			}
			set
			{
				if (value != this.Value)
				{
					this.innerEventFrame.SetEvent(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.Value = node.FrameEvent;
		}

		public EventFrame()
		{
			this.innerClass = (this.innerEventFrame = new CSTimelineEventFrame());
			this.BindingRecorder(null);
		}
	}
}
