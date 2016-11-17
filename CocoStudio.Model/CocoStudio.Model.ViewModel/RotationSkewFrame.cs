using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class RotationSkewFrame : PointFrame
	{
		private CSTimelineRotationSkewFrame innerSkewFrame;

		public override float X
		{
			get
			{
				return this.innerSkewFrame.GetSkewX();
			}
			set
			{
				if (value != this.X)
				{
					this.innerSkewFrame.SetSkewX(value);
				}
			}
		}

		public override float Y
		{
			get
			{
				return this.innerSkewFrame.GetSkewY();
			}
			set
			{
				if (value != this.Y)
				{
					this.innerSkewFrame.SetSkewY(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.X = node.RotationSkew.ScaleX;
			this.Y = node.RotationSkew.ScaleY;
			base.UpdateProperty(node);
		}

		public RotationSkewFrame()
		{
			this.innerClass = (this.innerSkewFrame = new CSTimelineRotationSkewFrame());
			this.BindingRecorder(null);
		}
	}
}
