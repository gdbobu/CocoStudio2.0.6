// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TimelineUndoManager
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.UndoManager;
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
        this.undoManager.EndCompositeTask();
      this.undoManager.BeginCompositeTask("TimelineTask");
    }

    public void EndCompositeTask()
    {
      if (!this.undoManager.IsRunningCompositeTask)
        return;
      this.undoManager.EndCompositeTask();
    }
  }
}
