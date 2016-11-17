using CocoStudio.Lib.Prism;
using CocoStudio.Model.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.Event
{
	public class CutVisualObjectsEvent : CompositePresentationEvent<ReadOnlyCollection<VisualObject>>
	{
	}
}
