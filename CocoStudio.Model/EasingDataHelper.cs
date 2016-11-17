using CocoStudio.Model.ViewModel;
using Gdk;
using System;
using System.Collections.Generic;

public static class EasingDataHelper
{
	public static EasingData GetExceptNullValue(this EasingData data)
	{
		EasingData easingData = new EasingData(data.TweenType);
		if (data != null)
		{
			if (data.ProportionPoints.Count == 0)
			{
				easingData.ProportionPoints.AddRange(new List<Point>
				{
					new Point(0, 0),
					new Point(0, 0),
					new Point(1, 1),
					new Point(1, 1)
				});
			}
		}
		return easingData;
	}
}
