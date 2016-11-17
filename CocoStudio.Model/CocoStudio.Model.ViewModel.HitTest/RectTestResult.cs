using Gdk;
using System;

namespace CocoStudio.Model.ViewModel.HitTest
{
	public class RectTestResult : BaseTestResult
	{
		public Rectangle HitRect
		{
			get;
			private set;
		}

		public RectTestResult(Rectangle hitRect, bool isContinueTest) : this(null, hitRect, isContinueTest)
		{
		}

		public RectTestResult(VisualObject hitVisual, Rectangle hitRect) : this(hitVisual, hitRect, hitVisual != null && hitVisual.Visible)
		{
		}

		public RectTestResult(VisualObject hitVisual, Rectangle hitRect, bool isContinueTest) : base(hitVisual, isContinueTest)
		{
		}
	}
}
