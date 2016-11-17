using Gdk;
using System;

namespace CocoStudio.Model.ViewModel.Input
{
	public class MouseWheelEventArgs
	{
		public int Delta
		{
			get;
			private set;
		}

		public Point Point
		{
			get;
			private set;
		}

		public MouseWheelEventArgs(Point point, int delta)
		{
			this.Point = point;
			this.Delta = delta;
		}
	}
}
