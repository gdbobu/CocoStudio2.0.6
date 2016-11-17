using CocoStudio.Core;
using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel
{
	public class TimelineUndoManager
	{
		private HashSet<BaseObject> undoObjects = new HashSet<BaseObject>();

		private IUndoManager undoManager;

		private static TimelineUndoManager timelineUndoManager;

		public static TimelineUndoManager Instance
		{
			get
			{
				if (TimelineUndoManager.timelineUndoManager == null)
				{
					TimelineUndoManager.timelineUndoManager = new TimelineUndoManager();
					TimelineUndoManager.timelineUndoManager.undoManager = Services.TaskService;
				}
				return TimelineUndoManager.timelineUndoManager;
			}
		}

		public void Clear()
		{
			this.undoObjects.Clear();
		}

		public void RegisterUndoObject(BaseObject o)
		{
			this.undoObjects.Add(o);
		}

		public void UnRegisterUndoObject(BaseObject o)
		{
			this.undoObjects.Remove(o);
		}

		public void BeginCompositeTask()
		{
			if (this.undoManager.IsRunningCompositeTask)
			{
				this.undoManager.EndCompositeTask();
			}
			this.undoManager.BeginCompositeTask("TimelineTask");
		}

		public void EndCompositeTask()
		{
			if (this.undoManager.IsRunningCompositeTask)
			{
				this.undoManager.EndCompositeTask();
			}
		}
	}
}
