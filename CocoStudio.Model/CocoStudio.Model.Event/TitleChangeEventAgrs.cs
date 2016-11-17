using System;

namespace CocoStudio.Model.Event
{
	public class TitleChangeEventAgrs
	{
		public string WindowTitle
		{
			get;
			set;
		}

		public object Progect
		{
			get;
			set;
		}

		public static TitleChangeEventAgrs Creat(string windowTitle, object progect = null)
		{
			return new TitleChangeEventAgrs
			{
				WindowTitle = windowTitle,
				Progect = progect
			};
		}
	}
}
