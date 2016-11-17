using CocoStudio.Core;
using CocoStudio.Core.Events;
using System;

namespace CocoStudio.Model.DataModel
{
	public class ActionTagManager
	{
		private static int tag;

		static ActionTagManager()
		{
			ActionTagManager.tag = 0;
			Services.ProjectOperations.CurrentSelectedSolutionChanged += new EventHandler<SolutionEventArgs>(ActionTagManager.HandleCurrentSelectedSolutionChanged);
		}

		private static void HandleCurrentSelectedSolutionChanged(object sender, SolutionEventArgs e)
		{
			ActionTagManager.ResetObjectActionTag();
		}

		public static int CreateObjectActionTag()
		{
			string text = Guid.NewGuid().ToString();
			return text.GetHashCode();
		}

		public static void RefreshObjectActionTag(int iTag)
		{
			if (ActionTagManager.tag < iTag)
			{
				ActionTagManager.tag = iTag;
			}
		}

		public static void ResetObjectActionTag()
		{
			ActionTagManager.tag = 0;
		}
	}
}
