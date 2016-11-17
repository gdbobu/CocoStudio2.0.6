using Gdk;
using System;

namespace CocoStudio.Model.Event
{
	public class CanvasSizeChangeEventArgs
	{
		public string CanvasName
		{
			get;
			private set;
		}

		public Size NewSize
		{
			get;
			private set;
		}

		public CanvasSizeChangeEventArgs(string canvasName, Size newSize)
		{
			this.CanvasName = canvasName;
			this.NewSize = newSize;
		}
	}
}
