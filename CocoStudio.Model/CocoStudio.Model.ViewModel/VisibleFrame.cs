using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class VisibleFrame : BoolFrame
	{
		private CSTimelineVisibleFrame innerVisibleFrame;

		public override bool Value
		{
			get
			{
				return this.innerVisibleFrame.IsVisible();
			}
			set
			{
				if (value != this.Value)
				{
					this.innerVisibleFrame.SetVisible(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.Value = node.VisibleForFrame;
		}

		public VisibleFrame()
		{
			this.innerClass = (this.innerVisibleFrame = new CSTimelineVisibleFrame());
			this.BindingRecorder(null);
		}
	}
}
