using System;

namespace CocoStudio.Model.ViewModel
{
	public abstract class BoolFrame : Frame
	{
		public virtual bool Value
		{
			get;
			set;
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			BoolFrame boolFrame = frame as BoolFrame;
			if (boolFrame != null)
			{
				this.Value = boolFrame.Value;
			}
		}
	}
}
