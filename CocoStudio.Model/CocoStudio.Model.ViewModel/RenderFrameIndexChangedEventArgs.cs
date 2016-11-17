using System;

namespace CocoStudio.Model.ViewModel
{
	public class RenderFrameIndexChangedEventArgs : EventArgs
	{
		public Frame Frame
		{
			get;
			private set;
		}

		public RenderFrameIndexChangedEventArgs()
		{
		}

		public RenderFrameIndexChangedEventArgs(Frame frame)
		{
			this.Frame = frame;
		}
	}
}
