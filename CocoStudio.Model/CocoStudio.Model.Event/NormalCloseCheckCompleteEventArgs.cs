using System;

namespace CocoStudio.Model.Event
{
	public class NormalCloseCheckCompleteEventArgs
	{
		public bool IsNormalClose
		{
			get;
			private set;
		}

		public bool IsUseBackup
		{
			get;
			private set;
		}

		public string SelectedBackupDir
		{
			get;
			private set;
		}

		public NormalCloseCheckCompleteEventArgs()
		{
			this.IsNormalClose = true;
		}

		public NormalCloseCheckCompleteEventArgs(bool isNormalClose)
		{
			this.IsNormalClose = isNormalClose;
		}

		public NormalCloseCheckCompleteEventArgs(bool isNormalClose, bool isUseBackup, string selectedBackupDir) : this(isNormalClose)
		{
			this.IsUseBackup = isUseBackup;
			this.SelectedBackupDir = selectedBackupDir;
		}
	}
}
