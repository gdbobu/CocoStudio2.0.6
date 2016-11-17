using System;

namespace CocoStudio.Model.Event
{
	public class ChangeDownloadServerEventArgs
	{
		public string projName
		{
			get;
			private set;
		}

		public int width
		{
			get;
			private set;
		}

		public int height
		{
			get;
			private set;
		}

		public string downloadPath
		{
			get;
			private set;
		}

		public ChangeDownloadServerEventArgs(string pName, int w, int h, string dPath)
		{
			this.projName = pName;
			this.width = w;
			this.height = h;
			this.downloadPath = dPath;
		}
	}
}
