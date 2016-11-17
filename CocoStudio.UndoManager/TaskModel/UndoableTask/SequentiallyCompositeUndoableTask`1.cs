// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.UndoableTask.SequentiallyCompositeUndoableTask`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.UndoManager.TaskModel.UndoableTask
{
  public class SequentiallyCompositeUndoableTask<T> : UndoableTaskBase<T>
  {
    private List<UndoableTaskBase<T>> taskList;
    private string descriptionForUser;

    public IEnumerable<UndoableTaskBase<T>> TaskList
    {
      get
      {
        return (IEnumerable<UndoableTaskBase<T>>) this.taskList;
      }
    }

    public override string DescriptionForUser
    {
      get
      {
        return this.descriptionForUser;
      }
    }

    public SequentiallyCompositeUndoableTask(List<UndoableTaskBase<T>> taskList, string descriptionForUser)
    {
      ArgumentValidator.AssertNotNull<List<UndoableTaskBase<T>>>(taskList, "tasks");
      this.descriptionForUser = descriptionForUser;
      this.taskList = taskList.ToList<UndoableTaskBase<T>>();
      this.Execute += new EventHandler<TaskEventArgs<T>>(this.OnExecute);
      this.Undo += new EventHandler<TaskEventArgs<T>>(this.OnUndo);
    }

    ~SequentiallyCompositeUndoableTask()
    {
      this.Dispose();
    }

    private void OnExecute(object sender, TaskEventArgs<T> e)
    {
      this.ExecuteInternal(this.taskList, e.TaskMode);
    }

    protected internal virtual void ExecuteInternal(List<UndoableTaskBase<T>> taskList, TaskMode taskMode)
    {
      List<UndoableTaskBase<T>> source = new List<UndoableTaskBase<T>>();
      foreach (UndoableTaskBase<T> task in taskList)
      {
        try
        {
          int num = (int) task.PerformTask((object) null, taskMode);
          source.Add(task);
        }
        catch (Exception )
        {
          SequentiallyCompositeUndoableTask<T>.SafelyUndoTasks(source.Cast<IUndoableTask>());
          throw;
        }
      }
    }

    private static void SafelyUndoTasks(IEnumerable<IUndoableTask> undoableTasks)
    {
      try
      {
        foreach (IUndoableTask undoableTask in undoableTasks)
        {
          try
          {
            int num = (int) undoableTask.Undo();
          }
          catch (Exception ex)
          {
            LogConfig.Logger.Error((object) "SafelyUndoTasks failed", ex);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }

    private void OnUndo(object sender, TaskEventArgs<T> e)
    {
      for (int index = this.taskList.Count - 1; index >= 0; --index)
      {
        int num = (int) ((IUndoableTask) this.taskList[index]).Undo();
      }
    }

    public override void Dispose()
    {
      for (int index = this.taskList.Count - 1; index >= 0; --index)
        this.taskList[index].Dispose();
      GC.SuppressFinalize((object) this);
      base.Dispose();
    }
  }
}
