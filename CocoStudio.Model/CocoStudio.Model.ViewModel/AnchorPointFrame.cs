using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class AnchorPointFrame : PointFrame
	{
		private CSTimelineAnchorPointFrame innerAnchorPointFrame;

		public override float X
		{
			get
			{
				return this.innerAnchorPointFrame.GetAnchorPointX();
			}
			set
			{
				if (value != this.X)
				{
					this.innerAnchorPointFrame.SetAnchorPointX(value);
				}
			}
		}

		public override float Y
		{
			get
			{
				return this.innerAnchorPointFrame.GetAnchorPointY();
			}
			set
			{
				if (value != this.Y)
				{
					this.innerAnchorPointFrame.SetAnchorPointY(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.X = node.AnchorPoint.ScaleX;
			this.Y = node.AnchorPoint.ScaleY;
			base.UpdateProperty(node);
		}

		public AnchorPointFrame()
		{
			this.innerClass = (this.innerAnchorPointFrame = new CSTimelineAnchorPointFrame());
			this.BindingRecorder(null);
		}
	}
}
