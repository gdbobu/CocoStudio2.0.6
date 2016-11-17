using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Component
{
	public sealed class SelectInfo
	{
		public IEnumerable<VisualObject> SelectedObjects
		{
			get;
			set;
		}

		public IEnumerable<VisualObject> SelectedParentObjects
		{
			get;
			set;
		}

		public SelectInfo(IEnumerable<VisualObject> list1, IEnumerable<VisualObject> list2)
		{
			this.SelectedObjects = list1;
			this.SelectedParentObjects = list2;
		}
	}
}
