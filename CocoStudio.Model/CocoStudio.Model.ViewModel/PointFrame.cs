using System;

namespace CocoStudio.Model.ViewModel
{
	public abstract class PointFrame : Frame
	{
		public virtual float X
		{
			get;
			set;
		}

		public virtual float Y
		{
			get;
			set;
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			PointFrame pointFrame = frame as PointFrame;
			if (pointFrame != null)
			{
				this.X = pointFrame.X;
				this.Y = pointFrame.Y;
			}
		}
	}
}
