// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.TaskService
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.UndoManager.TaskModel
{
  public class TaskService : ITaskService, IInternalTaskService
  {
    private readonly Dictionary<object, TaskService.TaskCollection<IInternalTask>> repeatableDictionary = new Dictionary<object, TaskService.TaskCollection<IInternalTask>>();
    private readonly Dictionary<object, TaskService.TaskCollection<IUndoableTask>> redoableDictionary = new Dictionary<object, TaskService.TaskCollection<IUndoableTask>>();
    private readonly Dictionary<object, TaskService.TaskCollection<IUndoableTask>> undoableDictionary = new Dictionary<object, TaskService.TaskCollection<IUndoableTask>>();
    private readonly TaskService.TaskCollection<IInternalTask> globallyRepeatableTasks = new TaskService.TaskCollection<IInternalTask>();
    private readonly TaskService.TaskCollection<IUndoableTask> globallyRedoableTasks = new TaskService.TaskCollection<IUndoableTask>();
    private readonly TaskService.TaskCollection<IUndoableTask> globallyUndoableTasks = new TaskService.TaskCollection<IUndoableTask>();
    private Dictionary<object, int> taskCountMaximums = new Dictionary<object, int>();
    private long taskCountMax = long.MaxValue;
    private bool enable;

    public bool IsUndoing { get; private set; }

    public bool Enable
    {
      get
      {
        return this.enable;
      }
      set
      {
        this.enable = value;
      }
    }

    private event EventHandler<CancellableTaskServiceEventArgs> executing;

    public event EventHandler<CancellableTaskServiceEventArgs> Executing
    {
      add
      {
        this.executing += value;
      }
      remove
      {
        this.executing -= value;
      }
    }

    private event EventHandler<TaskServiceEventArgs> executed;

    public event EventHandler<TaskServiceEventArgs> Executed
    {
      add
      {
        this.executed += value;
      }
      remove
      {
        this.executed -= value;
      }
    }

    private event EventHandler<CancellableTaskServiceEventArgs> undoing;

    public event EventHandler<CancellableTaskServiceEventArgs> Undoing
    {
      add
      {
        this.undoing += value;
      }
      remove
      {
        this.undoing -= value;
      }
    }

    private event EventHandler<TaskServiceEventArgs> undone;

    public event EventHandler<TaskServiceEventArgs> Undone
    {
      add
      {
        this.undone += value;
      }
      remove
      {
        this.undone -= value;
      }
    }

    private event EventHandler<CancellableTaskServiceEventArgs> redoing;

    public event EventHandler<CancellableTaskServiceEventArgs> Redoing
    {
      add
      {
        this.redoing += value;
      }
      remove
      {
        this.redoing -= value;
      }
    }

    private event EventHandler<TaskServiceEventArgs> redone;

    public event EventHandler<TaskServiceEventArgs> Redone
    {
      add
      {
        this.redone += value;
      }
      remove
      {
        this.redone -= value;
      }
    }

    private event EventHandler<EventArgs> cleared;

    public event EventHandler<EventArgs> Cleared
    {
      add
      {
        this.cleared += value;
      }
      remove
      {
        this.cleared -= value;
      }
    }

    public TaskResult PerformTask<T>(TaskBase<T> task, T argument, object ownerKey = null)
    {
      if (!this.Enable || this.IsUndoing)
        return TaskResult.NoEnable;
      ArgumentValidator.AssertNotNull<TaskBase<T>>(task, "task");
      if (ownerKey == null)
        return this.PerformTask<T>(task, argument);
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) task);
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      this.undoableDictionary.Remove(ownerKey);
      this.redoableDictionary.Remove(ownerKey);
      TaskService.TaskCollection<IInternalTask> taskCollection;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection))
      {
        taskCollection = new TaskService.TaskCollection<IInternalTask>();
        this.repeatableDictionary[ownerKey] = taskCollection;
      }
      taskCollection.AddLast((IInternalTask) task);
      TaskResult taskResult = task.PerformTask((object) argument, TaskMode.FirstTime);
      this.TrimIfRequired(ownerKey);
      this.OnExecuted(new TaskServiceEventArgs((ITask) task));
      return taskResult;
    }

    private TaskResult PerformTask<T>(TaskBase<T> task, T argument)
    {
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) task);
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      this.globallyRedoableTasks.Clear();
      this.globallyUndoableTasks.Clear();
      this.globallyRepeatableTasks.AddLast((IInternalTask) task);
      TaskResult taskResult = task.PerformTask((object) argument, TaskMode.FirstTime);
      this.TrimIfRequired((object) null);
      this.OnExecuted(new TaskServiceEventArgs((ITask) task));
      return taskResult;
    }

    public TaskResult PerformTask<T>(UndoableTaskBase<T> task, T argument, object ownerKey = null)
    {
      if (!this.Enable || this.IsUndoing)
        return TaskResult.NoEnable;
      ArgumentValidator.AssertNotNull<UndoableTaskBase<T>>(task, "task");
      if (ownerKey == null)
        return this.PerformTask<T>(task, argument);
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) task) { OwnerKey = ownerKey };
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      this.redoableDictionary.Remove(ownerKey);
      TaskService.TaskCollection<IInternalTask> taskCollection1;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection1))
      {
        taskCollection1 = new TaskService.TaskCollection<IInternalTask>();
        this.repeatableDictionary[ownerKey] = taskCollection1;
      }
      taskCollection1.AddLast((IInternalTask) task);
      TaskService.TaskCollection<IUndoableTask> taskCollection2;
      if (!this.undoableDictionary.TryGetValue(ownerKey, out taskCollection2))
      {
        taskCollection2 = new TaskService.TaskCollection<IUndoableTask>();
        this.undoableDictionary[ownerKey] = taskCollection2;
      }
      taskCollection2.AddLast((IUndoableTask) task);
      TaskResult taskResult = task.PerformTask((object) argument, TaskMode.FirstTime);
      this.TrimIfRequired(ownerKey);
      this.OnExecuted(new TaskServiceEventArgs((ITask) task));
      return taskResult;
    }

    private TaskResult PerformTask<T>(UndoableTaskBase<T> task, T argument)
    {
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) task);
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      this.globallyRedoableTasks.Clear();
      this.globallyRepeatableTasks.AddLast((IInternalTask) task);
      this.globallyUndoableTasks.AddLast((IUndoableTask) task);
      TaskResult taskResult = task.PerformTask((object) argument, TaskMode.FirstTime);
      this.TrimIfRequired((object) null);
      this.OnExecuted(new TaskServiceEventArgs((ITask) task));
      return taskResult;
    }

    public bool CanUndo(object ownerKey = null)
    {
      if (ownerKey == null)
        return this.globallyUndoableTasks.Count > 0;
      TaskService.TaskCollection<IUndoableTask> taskCollection;
      if (this.undoableDictionary.TryGetValue(ownerKey, out taskCollection))
        return taskCollection.Count > 0;
      return false;
    }

    public TaskResult Undo(object ownerKey = null)
    {
      if (ownerKey == null)
        return this.Undo();
      TaskService.TaskCollection<IUndoableTask> taskCollection1;
      if (!this.undoableDictionary.TryGetValue(ownerKey, out taskCollection1))
        throw new InvalidOperationException("No undoable tasks for the specified owner key.");
      IUndoableTask undoableTask = taskCollection1.Pop();
      TaskService.TaskCollection<IInternalTask> taskCollection2;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection2))
        throw new InvalidOperationException("No repeatable tasks for the specified owner key.");
      taskCollection2.RemoveLast();
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) undoableTask) { OwnerKey = ownerKey };
      this.OnUndoing(e);
      if (e.Cancel)
      {
        taskCollection1.AddLast(undoableTask);
        return TaskResult.Cancelled;
      }
      TaskService.TaskCollection<IUndoableTask> taskCollection3;
      if (!this.redoableDictionary.TryGetValue(ownerKey, out taskCollection3))
      {
        taskCollection3 = new TaskService.TaskCollection<IUndoableTask>();
        this.redoableDictionary[ownerKey] = taskCollection3;
      }
      taskCollection3.AddLast(undoableTask);
      TaskResult taskResult = undoableTask.Undo();
      this.TrimIfRequired(ownerKey);
      this.OnUndone(new TaskServiceEventArgs((ITask) undoableTask));
      return taskResult;
    }

    private TaskResult Undo()
    {
      if (this.globallyRepeatableTasks.Count < 1)
        throw new InvalidOperationException("No task to undo.");
      IUndoableTask undoableTask = this.globallyUndoableTasks.Pop();
      IInternalTask internalTask = this.globallyRepeatableTasks.Pop();
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) undoableTask);
      this.OnUndoing(e);
      if (e.Cancel)
      {
        this.globallyUndoableTasks.AddLast(undoableTask);
        this.globallyRepeatableTasks.AddLast(internalTask);
        return TaskResult.Cancelled;
      }
      this.globallyRedoableTasks.AddLast(undoableTask);
      TaskResult taskResult = undoableTask.Undo();
      this.OnUndone(new TaskServiceEventArgs((ITask) undoableTask));
      return taskResult;
    }

    public TaskResult Undo(int undoCount, object ownerKey = null)
    {
      ArgumentValidator.AssertGreaterThan(undoCount, 0, "undoCount");
      if (ownerKey == null)
        return this.Undo(undoCount);
      for (int index = 0; index < undoCount; ++index)
      {
        TaskResult taskResult = this.Undo(ownerKey);
        if (taskResult != TaskResult.Completed)
          return taskResult;
      }
      return TaskResult.Completed;
    }

    private TaskResult Undo(int undoCount)
    {
      for (int index = 0; index < undoCount; ++index)
      {
        TaskResult taskResult = this.Undo();
        if (taskResult != TaskResult.Completed)
          return taskResult;
      }
      return TaskResult.Completed;
    }

    public bool CanRedo(object ownerKey = null)
    {
      if (ownerKey == null)
        return this.CanRedo();
      TaskService.TaskCollection<IUndoableTask> taskCollection;
      if (this.redoableDictionary.TryGetValue(ownerKey, out taskCollection))
        return taskCollection.Count > 0;
      return false;
    }

    private bool CanRedo()
    {
      return this.globallyRedoableTasks.Count > 0;
    }

    public TaskResult Redo(object ownerKey = null)
    {
      if (ownerKey == null)
        return this.Redo();
      TaskService.TaskCollection<IUndoableTask> taskCollection1;
      if (!this.redoableDictionary.TryGetValue(ownerKey, out taskCollection1))
        throw new InvalidOperationException("No tasks to be redone for the specified owner key.");
      IUndoableTask undoableTask = taskCollection1.Pop();
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) undoableTask);
      this.OnRedoing(e);
      if (e.Cancel)
      {
        taskCollection1.AddLast(undoableTask);
        return TaskResult.Cancelled;
      }
      IInternalTask internalTask = (IInternalTask) undoableTask;
      TaskService.TaskCollection<IInternalTask> taskCollection2;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection2))
        taskCollection2 = new TaskService.TaskCollection<IInternalTask>();
      taskCollection2.AddLast(internalTask);
      TaskService.TaskCollection<IUndoableTask> taskCollection3;
      if (!this.undoableDictionary.TryGetValue(ownerKey, out taskCollection3))
        taskCollection3 = new TaskService.TaskCollection<IUndoableTask>();
      taskCollection3.AddLast(undoableTask);
      TaskResult taskResult = internalTask.PerformTask(internalTask.Argument, TaskMode.Redo);
      this.TrimIfRequired(ownerKey);
      this.OnRedone(new TaskServiceEventArgs((ITask) undoableTask));
      return taskResult;
    }

    private TaskResult Redo()
    {
      if (this.globallyRedoableTasks.Count < 1)
        throw new InvalidOperationException("No task to redo.");
      IUndoableTask undoableTask = this.globallyRedoableTasks.Pop();
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) undoableTask);
      this.OnRedoing(e);
      if (e.Cancel)
      {
        this.globallyRedoableTasks.AddLast(undoableTask);
        return TaskResult.Cancelled;
      }
      IInternalTask internalTask = (IInternalTask) undoableTask;
      this.globallyRepeatableTasks.AddLast(internalTask);
      this.globallyUndoableTasks.AddLast(undoableTask);
      TaskResult taskResult = internalTask.PerformTask(internalTask.Argument, TaskMode.Redo);
      this.TrimIfRequired((object) null);
      this.OnRedone(new TaskServiceEventArgs((ITask) undoableTask));
      return taskResult;
    }

    public TaskResult Repeat(object ownerKey = null)
    {
      if (ownerKey == null)
        return this.Repeat();
      TaskService.TaskCollection<IInternalTask> taskCollection1;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection1))
        throw new InvalidOperationException("No tasks to be redone for the specified owner key.");
      IInternalTask internalTask = taskCollection1.Peek();
      if (!internalTask.Repeatable)
        return TaskResult.NoTask;
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) internalTask) { OwnerKey = ownerKey };
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      taskCollection1.AddLast(internalTask);
      TaskService.TaskCollection<IUndoableTask> taskCollection2;
      if (!this.undoableDictionary.TryGetValue(ownerKey, out taskCollection2))
      {
        taskCollection2 = new TaskService.TaskCollection<IUndoableTask>();
        this.undoableDictionary[ownerKey] = taskCollection2;
      }
      IUndoableTask undoableTask = internalTask as IUndoableTask;
      if (undoableTask != null)
      {
        taskCollection2.AddLast(undoableTask);
      }
      else
      {
        this.undoableDictionary[ownerKey] = (TaskService.TaskCollection<IUndoableTask>) null;
        this.redoableDictionary[ownerKey] = (TaskService.TaskCollection<IUndoableTask>) null;
      }
      TaskResult taskResult = internalTask.PerformTask(internalTask.Argument, TaskMode.Repeat);
      this.TrimIfRequired(ownerKey);
      this.OnExecuted(new TaskServiceEventArgs((ITask) internalTask));
      return taskResult;
    }

    private void TrimIfRequired(object ownerKey = null)
    {
      long num1 = this.taskCountMax;
      TaskService.TaskCollection<IUndoableTask> globallyUndoableTasks;
      TaskService.TaskCollection<IInternalTask> globallyRepeatableTasks;
      TaskService.TaskCollection<IUndoableTask> globallyRedoableTasks;
      if (ownerKey != null)
      {
        int num2;
        if (this.taskCountMaximums.TryGetValue(ownerKey, out num2))
          num1 = (long) num2;
        if (num1 == long.MaxValue)
          return;
        this.undoableDictionary.TryGetValue(ownerKey, out globallyUndoableTasks);
        this.repeatableDictionary.TryGetValue(ownerKey, out globallyRepeatableTasks);
        this.redoableDictionary.TryGetValue(ownerKey, out globallyRedoableTasks);
      }
      else
      {
        if (this.taskCountMax == long.MaxValue)
          return;
        globallyUndoableTasks = this.globallyUndoableTasks;
        globallyRepeatableTasks = this.globallyRepeatableTasks;
        globallyRedoableTasks = this.globallyRedoableTasks;
      }
      int num3 = globallyUndoableTasks != null ? globallyUndoableTasks.Count : 0;
      int num4 = globallyRepeatableTasks != null ? globallyRepeatableTasks.Count : 0;
      int num5 = globallyRedoableTasks != null ? globallyRedoableTasks.Count : 0;
      long num6 = (long) num3 - num1;
      long num7 = (long) num4 - num1;
      long num8 = (long) num5 - num1;
      for (long index = 0; index < num6; ++index)
        globallyUndoableTasks.RemoveFirst();
      for (long index = 0; index < num7; ++index)
        globallyRepeatableTasks.RemoveFirst();
      for (long index = 0; index < num8; ++index)
        globallyRedoableTasks.RemoveFirst();
    }

    private TaskResult Repeat()
    {
      IInternalTask internalTask = this.globallyRepeatableTasks.Peek();
      if (!internalTask.Repeatable)
        return TaskResult.NoTask;
      CancellableTaskServiceEventArgs e = new CancellableTaskServiceEventArgs((ITask) internalTask);
      this.OnExecuting(e);
      if (e.Cancel)
        return TaskResult.Cancelled;
      this.globallyRedoableTasks.Clear();
      this.globallyRepeatableTasks.AddLast(internalTask);
      IUndoableTask undoableTask = internalTask as IUndoableTask;
      if (undoableTask != null)
      {
        this.globallyUndoableTasks.AddLast(undoableTask);
      }
      else
      {
        this.globallyUndoableTasks.Clear();
        this.globallyRedoableTasks.Clear();
      }
      TaskResult taskResult = internalTask.PerformTask(internalTask.Argument, TaskMode.Repeat);
      this.OnExecuted(new TaskServiceEventArgs((ITask) internalTask));
      return taskResult;
    }

    public bool CanRepeat(object ownerKey = null)
    {
      TaskService.TaskCollection<IInternalTask> globallyRepeatableTasks;
      if (ownerKey == null)
        globallyRepeatableTasks = this.globallyRepeatableTasks;
      else if (!this.repeatableDictionary.TryGetValue(ownerKey, out globallyRepeatableTasks))
        return false;
      return globallyRepeatableTasks.Count > 0 && globallyRepeatableTasks.Peek().Repeatable;
    }

    public IEnumerable<ITask> GetUndoableTasks(object ownerKey = null)
    {
      if (ownerKey == null)
        return (IEnumerable<ITask>) new List<ITask>(this.globallyUndoableTasks.Cast<ITask>());
      TaskService.TaskCollection<IUndoableTask> source;
      if (!this.undoableDictionary.TryGetValue(ownerKey, out source))
        return (IEnumerable<ITask>) new List<ITask>();
      return (IEnumerable<ITask>) new List<ITask>(source.Cast<ITask>());
    }

    public IEnumerable<ITask> GetRedoableTasks(object ownerKey = null)
    {
      if (ownerKey == null)
        return (IEnumerable<ITask>) new List<ITask>(this.globallyRedoableTasks.Cast<ITask>());
      TaskService.TaskCollection<IUndoableTask> source;
      if (!this.redoableDictionary.TryGetValue(ownerKey, out source))
        return (IEnumerable<ITask>) new List<ITask>();
      return (IEnumerable<ITask>) new List<ITask>(source.Cast<ITask>());
    }

    public IEnumerable<ITask> GetRepeatableTasks(object ownerKey = null)
    {
      if (ownerKey == null)
        return (IEnumerable<ITask>) this.globallyRepeatableTasks.Where<IInternalTask>((Func<IInternalTask, bool>) (task => task.Repeatable)).Cast<ITask>().ToList<ITask>();
      TaskService.TaskCollection<IInternalTask> source;
      if (!this.repeatableDictionary.TryGetValue(ownerKey, out source))
        return (IEnumerable<ITask>) new List<ITask>();
      return (IEnumerable<ITask>) source.Where<IInternalTask>((Func<IInternalTask, bool>) (task => task.Repeatable)).Cast<ITask>().ToList<ITask>();
    }

    public void SetMaximumUndoCount(int count, object ownerKey = null)
    {
      ArgumentValidator.AssertGreaterThan(count, 0, "count");
      if (ownerKey == null)
        this.taskCountMax = (long) count;
      else
        this.taskCountMaximums[ownerKey] = count;
    }

    public void Clear(object ownerKey = null)
    {
      if (ownerKey == null)
      {
        this.globallyRepeatableTasks.Clear();
        this.globallyUndoableTasks.Clear();
        this.globallyRedoableTasks.Clear();
        this.OnCleared(EventArgs.Empty);
      }
      else
      {
        TaskService.TaskCollection<IInternalTask> taskCollection1;
        if (this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection1))
          taskCollection1.Clear();
        TaskService.TaskCollection<IUndoableTask> taskCollection2;
        if (this.undoableDictionary.TryGetValue(ownerKey, out taskCollection2))
          taskCollection2.Clear();
        TaskService.TaskCollection<IUndoableTask> taskCollection3;
        if (this.redoableDictionary.TryGetValue(ownerKey, out taskCollection3))
          taskCollection3.Clear();
        this.OnCleared(EventArgs.Empty);
      }
    }

    private void OnExecuting(CancellableTaskServiceEventArgs e)
    {
      if (this.executing == null)
        return;
      this.executing((object) this, e);
    }

    private void OnExecuted(TaskServiceEventArgs e)
    {
      if (this.executed == null)
        return;
      this.executed((object) this, e);
    }

    protected virtual void OnUndoing(CancellableTaskServiceEventArgs e)
    {
      this.IsUndoing = true;
      if (this.undoing == null)
        return;
      this.undoing((object) this, e);
    }

    protected virtual void OnUndone(TaskServiceEventArgs e)
    {
      this.IsUndoing = false;
      if (this.undone == null)
        return;
      this.undone((object) this, e);
    }

    protected virtual void OnRedoing(CancellableTaskServiceEventArgs e)
    {
      this.IsUndoing = true;
      if (this.redoing == null)
        return;
      this.redoing((object) this, e);
    }

    protected virtual void OnRedone(TaskServiceEventArgs e)
    {
      this.IsUndoing = false;
      if (this.redone == null)
        return;
      this.redone((object) this, e);
    }

    private void OnCleared(EventArgs e)
    {
      if (this.cleared == null)
        return;
      this.cleared((object) this, e);
    }

    void IInternalTaskService.NotifyTaskRepeatableChanged(IInternalTask task)
    {
    }

    internal int GetTaskCount(TaskService.TaskType taskType, object ownerKey = null)
    {
      if (taskType == TaskService.TaskType.Undoable)
      {
        if (ownerKey == null)
          return this.globallyUndoableTasks.Count;
        TaskService.TaskCollection<IUndoableTask> taskCollection;
        if (!this.undoableDictionary.TryGetValue(ownerKey, out taskCollection))
          return 0;
        return taskCollection.Count;
      }
      if (taskType == TaskService.TaskType.Repeatable)
      {
        if (ownerKey == null)
          return this.globallyRepeatableTasks.Count;
        TaskService.TaskCollection<IInternalTask> taskCollection;
        if (!this.repeatableDictionary.TryGetValue(ownerKey, out taskCollection))
          return 0;
        return taskCollection.Count;
      }
      if (taskType != TaskService.TaskType.Redoable)
        throw new InvalidOperationException("Unknown task type: " + (object) taskType);
      if (ownerKey == null)
        return this.globallyRedoableTasks.Count;
      TaskService.TaskCollection<IUndoableTask> taskCollection1;
      if (!this.redoableDictionary.TryGetValue(ownerKey, out taskCollection1))
        return 0;
      return taskCollection1.Count;
    }

    internal enum TaskType
    {
      Undoable,
      Redoable,
      Repeatable,
    }

    private class TaskCollection<T> : LinkedList<T>
    {
      public T Pop()
      {
        T obj = this.Last.Value;
        this.RemoveLast();
        return obj;
      }

      public T Peek()
      {
        LinkedListNode<T> last = this.Last;
        return last != null ? last.Value : default (T);
      }
    }
  }
}
