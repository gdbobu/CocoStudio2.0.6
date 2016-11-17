// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.TaskBase`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager.TaskModel
{
  public abstract class TaskBase<T> : IInternalTask, ITask, IDisposable
  {
    private bool repeatable;

    public bool Undoable { get; protected internal set; }

    internal T Argument { get; private set; }

    object IInternalTask.Argument
    {
      get
      {
        return (object) this.Argument;
      }
    }

    public abstract string DescriptionForUser { get; }

    public bool Repeatable
    {
      get
      {
        return this.repeatable;
      }
      protected set
      {
        if (this.repeatable == value)
          return;
        this.repeatable = value;
        if (this.TaskService != null)
          this.TaskService.NotifyTaskRepeatableChanged((IInternalTask) this);
      }
    }

    internal IInternalTaskService TaskService { get; set; }

    private event EventHandler<TaskEventArgs<T>> execute;

    protected event EventHandler<TaskEventArgs<T>> Execute
    {
      add
      {
        this.execute += value;
      }
      remove
      {
        this.execute -= value;
      }
    }

    private void OnExecute(TaskEventArgs<T> e)
    {
      if (this.execute == null)
        return;
      this.execute((object) this, e);
    }

    TaskResult IInternalTask.PerformTask(object argument, TaskMode taskMode)
    {
      this.Argument = (T) argument;
      TaskEventArgs<T> e = new TaskEventArgs<T>(this.Argument, taskMode);
      this.OnExecute(e);
      return e.TaskResult;
    }

    internal TaskResult PerformTask(object argument, TaskMode taskMode)
    {
      return ((IInternalTask) this).PerformTask(argument, taskMode);
    }

    internal TaskResult Repeat()
    {
      TaskEventArgs<T> e = new TaskEventArgs<T>(this.Argument, TaskMode.Repeat);
      this.OnExecute(e);
      return e.TaskResult;
    }

    public virtual void Dispose()
    {
    }
  }
}
