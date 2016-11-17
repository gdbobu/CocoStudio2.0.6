using System;

namespace CocoStudio.Model.Event
{
	public class OutputInfoEventArgs
	{
		public string Info
		{
			get;
			private set;
		}

		public OutputInfoEventArgs(string info)
		{
			this.Info = info;
		}
	}
}
