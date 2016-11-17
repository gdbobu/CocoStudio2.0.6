using System;

namespace CocoStudio.Model.Event
{
	public class ShareHttpIPEventArgs
	{
		public string HttpServerIP
		{
			get;
			private set;
		}

		public ShareHttpIPEventArgs(string hIP)
		{
			this.HttpServerIP = hIP;
		}
	}
}
