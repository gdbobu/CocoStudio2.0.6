using System;

namespace CocoStudio.Model.ViewModel
{
	public abstract class IntFrame : Frame
	{
		public virtual int Value
		{
			get;
			set;
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			IntFrame intFrame = frame as IntFrame;
			if (intFrame != null)
			{
				this.Value = intFrame.Value;
			}
		}
	}
}
