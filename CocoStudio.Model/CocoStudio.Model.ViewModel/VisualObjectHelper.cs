using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
	internal static class VisualObjectHelper
	{
		public static VisualObject GetChild(VisualObject rootObject, Expression<Func<VisualObject, bool>> filter)
		{
			VisualObject result;
			if (rootObject == null)
			{
				result = null;
			}
			else if (filter.Compile()(rootObject))
			{
				result = rootObject;
			}
			else
			{
				IEnumerable<VisualObject> visualChildren = rootObject.GetVisualChildren();
				if (visualChildren == null)
				{
					result = null;
				}
				else
				{
					foreach (VisualObject current in visualChildren)
					{
						VisualObject child = VisualObjectHelper.GetChild(current, filter);
						if (child != null)
						{
							result = child;
							return result;
						}
					}
					result = null;
				}
			}
			return result;
		}
	}
}
