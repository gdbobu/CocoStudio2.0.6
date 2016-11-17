using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CocoStudio.Model.Event
{
	public class CreateSerialFrameEventArgs
	{
		public ReadOnlyCollection<ResourceItem> SerialResources
		{
			get;
			private set;
		}

		public VisualObject ObjectSerialOn
		{
			get;
			private set;
		}

		public int StartFrameIndex
		{
			get;
			private set;
		}

		public CreateSerialFrameEventArgs(VisualObject objectSerialOn, IEnumerable<ResourceItem> serialResources)
		{
			this.StartFrameIndex = 0;
			this.ObjectSerialOn = objectSerialOn;
			this.SerialResources = serialResources.ToList<ResourceItem>().AsReadOnly();
		}

		public CreateSerialFrameEventArgs(VisualObject objectSerialOn, IEnumerable<ResourceItem> serialResources, int startFrameIndex)
		{
			this.StartFrameIndex = startFrameIndex;
			this.ObjectSerialOn = objectSerialOn;
			this.SerialResources = serialResources.ToList<ResourceItem>().AsReadOnly();
		}
	}
}
