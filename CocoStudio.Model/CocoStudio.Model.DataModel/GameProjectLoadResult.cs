using CocoStudio.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
	public class GameProjectLoadResult
	{
		public NodeObject RootObject
		{
			get;
			set;
		}

		public TimelineAction TimelineAction
		{
			get;
			set;
		}

		public Dictionary<Type, int> TypeIndex
		{
			get;
			set;
		}

		public GameProjectLoadResult()
		{
			this.TypeIndex = new Dictionary<Type, int>();
		}
	}
}
