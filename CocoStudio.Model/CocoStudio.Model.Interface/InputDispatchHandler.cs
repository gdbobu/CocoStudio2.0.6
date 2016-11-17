using CocoStudio.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.Interface
{
	public delegate void InputDispatchHandler<T>(T args, IEnumerable<VisualObject> selectedParentObject) where T : EventArgs;
}
