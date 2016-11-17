// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.UndoableTaskBase`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager.TaskModel
{
  public abstract class UndoableTaskBase<T> : TaskBase<T>, IUndoableTask, ITask, IDisposable
  {
    protected event EventHandler<TaskEventArgs<T>> Undo;

    protected UndoableTaskBase()
    {
      this.Undoable = true;
    }

    private void OnUndo(TaskEventArgs<T> e)
    {
      EventHandler<TaskEventArgs<T>> undo = this.Undo;
      if (undo == null)
        return;
      undo((object) this, e);
    }

    TaskResult IUndoableTask.Undo()
    {
      TaskEventArgs<T> e = new TaskEventArgs<T>(this.Argument);
      this.OnUndo(e);
      return e.TaskResult;
    }
  }
}
