using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class ZOrderFrame : IntFrame
	{
		private CSTimelineZOrderFrame innerZOrderFrame;

		public override int Value
		{
			get
			{
				return this.innerZOrderFrame.GetZOrder();
			}
			set
			{
				if (value != this.Value)
				{
					this.innerZOrderFrame.SetZOrder(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.Value = node.ZOrder;
		}

		public ZOrderFrame()
		{
			this.innerClass = (this.innerZOrderFrame = new CSTimelineZOrderFrame());
			this.BindingRecorder(null);
		}
	}
}
