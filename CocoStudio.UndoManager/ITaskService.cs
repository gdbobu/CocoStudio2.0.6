// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.ITaskService
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.TaskModel;
using System;
using System.Collections.Generic;

namespace CocoStudio.UndoManager
{
  public interface ITaskService
  {
    bool Enable { get; set; }

    bool IsUndoing { get; }

    event EventHandler<TaskServiceEventArgs> Undone;

    event EventHandler<TaskServiceEventArgs> Redone;

    TaskResult PerformTask<T>(TaskBase<T> task, T argument, object contextKey = null);

    TaskResult PerformTask<T>(UndoableTaskBase<T> task, T argument, object ownerKey = null);

    bool CanUndo(object ownerKey = null);

    TaskResult Undo(object ownerKey = null);

    TaskResult Undo(int undoCount, object ownerKey = null);

    bool CanRedo(object ownerKey = null);

    TaskResult Redo(object ownerKey = null);

    TaskResult Repeat(object ownerKey = null);

    bool CanRepeat(object ownerKey = null);

    IEnumerable<ITask> GetUndoableTasks(object ownerKey = null);

    IEnumerable<ITask> GetRedoableTasks(object ownerKey = null);

    IEnumerable<ITask> GetRepeatableTasks(object ownerKey = null);

    void Clear(object ownerKey = null);

    void SetMaximumUndoCount(int count, object ownerKey = null);
  }
}
