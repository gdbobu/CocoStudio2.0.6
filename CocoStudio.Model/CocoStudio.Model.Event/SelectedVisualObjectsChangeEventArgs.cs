using CocoStudio.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CocoStudio.Model.Event
{
	public class SelectedVisualObjectsChangeEventArgs
	{
		public ReadOnlyCollection<VisualObject> SelectedObject
		{
			get;
			private set;
		}

		public ReadOnlyCollection<VisualObject> SelectedParentObject
		{
			get;
			private set;
		}

		public string SourceName
		{
			get;
			set;
		}

		public bool Handled
		{
			get;
			set;
		}

		public bool IsDoInNow
		{
			get;
			set;
		}

		public SelectedVisualObjectsChangeEventArgs(IEnumerable<VisualObject> selectedObject, IEnumerable<VisualObject> selectedParentObject, bool isdoinnow = false)
		{
			this.SelectedObject = selectedObject.ToList<VisualObject>().AsReadOnly();
			this.SelectedParentObject = selectedParentObject.ToList<VisualObject>().AsReadOnly();
			this.IsDoInNow = isdoinnow;
		}
	}
}
