using CocoStudio.EngineAdapterWrap;
using System;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	public class ColorFrame : Frame
	{
		private CSTimelineColorFrame innerColorFrame;

		public virtual Color Color
		{
			get
			{
				return this.innerColorFrame.GetColor();
			}
			set
			{
				if (value != this.Color)
				{
					this.innerColorFrame.SetColor(value);
				}
			}
		}

		public virtual int Alpha
		{
			get
			{
				return this.innerColorFrame.GetAlpha();
			}
			set
			{
				if (value != this.Alpha)
				{
					this.innerColorFrame.SetAlpha(value);
				}
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			this.Color = node.CColor;
			this.Alpha = node.Alpha;
			base.UpdateProperty(node);
		}

		public ColorFrame()
		{
			this.innerClass = (this.innerColorFrame = new CSTimelineColorFrame());
			this.BindingRecorder(null);
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			ColorFrame colorFrame = frame as ColorFrame;
			if (colorFrame != null)
			{
				this.Color = colorFrame.Color;
			}
		}
	}
}
