using System;

namespace CocoStudio.Model.Event
{
	public class PasteObjectsChangeEventArgs
	{
		public PointF PastePosition
		{
			get;
			set;
		}

		public PasteObjectsChangeEventArgs(PointF position)
		{
			this.PastePosition = position;
		}
	}
}
