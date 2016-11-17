using CocoStudio.Model.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.Interface
{
	public interface ITimeline
	{
		ObservableCollection<Frame> Frames
		{
			get;
		}
	}
}
