using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class ScaleFrame : PointFrame
	{
		private CSTimelineScaleFrame innerScaleFrame;

		public override float X
		{
			get
			{
				return this.innerScaleFrame.GetScaleX();
			}
			set
			{
				if (value != this.X)
				{
					this.innerScaleFrame.SetScaleX(value);
				}
			}
		}

		public override float Y
		{
			get
			{
				return this.innerScaleFrame.GetScaleY();
			}
			set
			{
				if (value != this.Y)
				{
					this.innerScaleFrame.SetScaleY(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.X = node.Scale.ScaleX;
			this.Y = node.Scale.ScaleY;
			base.UpdateProperty(node);
		}

		public ScaleFrame()
		{
			this.innerClass = (this.innerScaleFrame = new CSTimelineScaleFrame());
			this.BindingRecorder(null);
		}
	}
}
