using System;

namespace CocoStudio.Model.Event
{
	public class GuidesLockChangeEventArgs
	{
		public bool IsLock
		{
			get;
			set;
		}

		public static GuidesLockChangeEventArgs Creat(bool lockState)
		{
			return new GuidesLockChangeEventArgs
			{
				IsLock = lockState
			};
		}
	}
}
