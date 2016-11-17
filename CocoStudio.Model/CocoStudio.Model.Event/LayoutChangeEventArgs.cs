using System;

namespace CocoStudio.Model.Event
{
	public class LayoutChangeEventArgs
	{
		public EnumLayoutChangeSource Source
		{
			get;
			private set;
		}

		public LayoutChangeEventArgs(EnumLayoutChangeSource source)
		{
			this.Source = source;
		}
	}
}
