using System;

namespace CocoStudio.Model.Event
{
	public class RulerVisibleChangeArgs
	{
		public bool IsVisible
		{
			get;
			set;
		}

		public static RulerVisibleChangeArgs Creat(bool rulerState)
		{
			return new RulerVisibleChangeArgs
			{
				IsVisible = rulerState
			};
		}
	}
}
