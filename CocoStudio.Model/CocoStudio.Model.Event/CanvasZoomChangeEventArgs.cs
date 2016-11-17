using System;

namespace CocoStudio.Model.Event
{
	public class CanvasZoomChangeEventArgs
	{
		public PointF MousePoint
		{
			get;
			private set;
		}

		public float ZoomDelta
		{
			get;
			private set;
		}

		public CanvasZoomChangeEventArgs(float zoomDelta, PointF mousePoint)
		{
			this.ZoomDelta = zoomDelta;
			this.MousePoint = mousePoint;
		}

		public CanvasZoomChangeEventArgs(float zoomDelta)
		{
			this.ZoomDelta = zoomDelta;
		}
	}
}
