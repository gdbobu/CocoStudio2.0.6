using System;

namespace CocoStudio.Model.ViewModel
{
	public abstract class StringFrame : Frame
	{
		public virtual string Value
		{
			get;
			set;
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			StringFrame stringFrame = frame as StringFrame;
			if (stringFrame != null)
			{
				this.Value = stringFrame.Value;
			}
		}
	}
}
