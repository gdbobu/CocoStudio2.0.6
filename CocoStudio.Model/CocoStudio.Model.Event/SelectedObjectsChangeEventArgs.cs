using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.Event
{
	public class SelectedObjectsChangeEventArgs
	{
		public ReadOnlyCollection<object> SelectedObject
		{
			get;
			private set;
		}

		public bool Handled
		{
			get;
			set;
		}

		public SelectedObjectsChangeEventArgs(ReadOnlyCollection<object> selectedObject)
		{
			this.SelectedObject = selectedObject;
		}
	}
}
