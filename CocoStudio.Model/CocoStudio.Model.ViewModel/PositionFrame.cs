using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class PositionFrame : PointFrame
	{
		private CSTimelinePositionFrame innerPositionFrame;

		public override float X
		{
			get
			{
				return this.innerPositionFrame.GetX();
			}
			set
			{
				if (value != this.X)
				{
					this.innerPositionFrame.SetX(value);
				}
			}
		}

		public override float Y
		{
			get
			{
				return this.innerPositionFrame.GetY();
			}
			set
			{
				if (value != this.Y)
				{
					this.innerPositionFrame.SetY(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.X = node.Position.X;
			this.Y = node.Position.Y;
			base.UpdateProperty(node);
		}

		public PositionFrame()
		{
			this.innerClass = (this.innerPositionFrame = new CSTimelinePositionFrame());
			this.BindingRecorder(null);
		}
	}
}
