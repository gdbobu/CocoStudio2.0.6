// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.CompositeUndoableTask`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CocoStudio.UndoManager.TaskModel
{
    public class CompositeUndoableTask<T> : UndoableTaskBase<T>
    {
        private readonly string descriptionForUser;

        private readonly Dictionary<UndoableTaskBase<T>, T> taskDictionary;

        public override string DescriptionForUser
        {
            get
            {
                return this.descriptionForUser;
            }
        }

        public bool Parallel
        {
            get;
            set;
        }

        public CompositeUndoableTask(IDictionary<UndoableTaskBase<T>, T> tasks, string descriptionForUser)
        {
            ArgumentValidator.AssertNotNull<string>(descriptionForUser, "descriptionForUser");
            ArgumentValidator.AssertNotNull<IDictionary<UndoableTaskBase<T>, T>>(tasks, "tasks");
            this.descriptionForUser = descriptionForUser;
            this.taskDictionary = new Dictionary<UndoableTaskBase<T>, T>(tasks);
            base.Execute += new EventHandler<TaskEventArgs<T>>(this.OnExecute);
            base.Undo += new EventHandler<TaskEventArgs<T>>(this.OnUndo);
            bool repeatable = this.taskDictionary.Keys.Count > 0;
            foreach (IInternalTask current in tasks.Keys)
            {
                if (!current.Repeatable)
                {
                    repeatable = false;
                }
            }
            base.Repeatable = repeatable;
        }

        private void OnExecute(object sender, TaskEventArgs<T> e)
        {
            this.ExecuteInternal(this.taskDictionary, e.TaskMode);
        }

        protected internal virtual void ExecuteInternal(Dictionary<UndoableTaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            if (this.Parallel)
            {
                CompositeUndoableTask<T>.ExecuteInParallel(taskDictionary, taskMode);
            }
            else
            {
                CompositeUndoableTask<T>.ExecuteSequentially(taskDictionary, taskMode);
            }
        }

        private static void ExecuteSequentially(Dictionary<UndoableTaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            List<UndoableTaskBase<T>> list = new List<UndoableTaskBase<T>>();
            foreach (KeyValuePair<UndoableTaskBase<T>, T> current in taskDictionary)
            {
                IInternalTask key = current.Key;
                try
                {
                    key.PerformTask(current.Value, taskMode);
                    list.Add(current.Key);
                }
                catch (Exception)
                {
                    CompositeUndoableTask<T>.SafelyUndoTasks(list.Cast<IUndoableTask>());
                    throw;
                }
            }
        }

        private static void SafelyUndoTasks(IEnumerable<IUndoableTask> undoableTasks)
        {
            try
            {
                foreach (IUndoableTask current in undoableTasks)
                {
                    try
                    {
                        current.Undo();
                    }
                    catch (Exception value)
                    {
                        Console.WriteLine(value);
                    }
                }
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
            }
        }

        private void OnUndo(object sender, TaskEventArgs<T> e)
        {
            this.UndoInternal(this.taskDictionary);
        }

        protected internal virtual void UndoInternal(Dictionary<UndoableTaskBase<T>, T> taskDictionary)
        {
            if (this.Parallel)
            {
                CompositeUndoableTask<T>.UndoInParallel(taskDictionary);
            }
            else
            {
                CompositeUndoableTask<T>.UndoSequentially(taskDictionary);
            }
        }

        private static void UndoSequentially(Dictionary<UndoableTaskBase<T>, T> taskDictionary)
        {
            foreach (KeyValuePair<UndoableTaskBase<T>, T> current in taskDictionary)
            {
                IUndoableTask key = current.Key;
                key.Undo();
            }
        }

        private static void ExecuteInParallel(Dictionary<UndoableTaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            List<UndoableTaskBase<T>> performedTasks = new List<UndoableTaskBase<T>>();
            object performedTasksLock = new object();
            List<Exception> exceptions = new List<Exception>();
            object exceptionsLock = new object();
            Dictionary<KeyValuePair<UndoableTaskBase<T>, T>, AutoResetEvent> dictionary = taskDictionary.ToDictionary((KeyValuePair<UndoableTaskBase<T>, T> x) => x, (KeyValuePair<UndoableTaskBase<T>, T> x) => new AutoResetEvent(false));
            foreach (KeyValuePair<UndoableTaskBase<T>, T> current in taskDictionary)
            {
                AutoResetEvent autoResetEvent = dictionary[current];
                IInternalTask task = current.Key;
                UndoableTaskBase<T> undoableTask = current.Key;
                T arg = current.Value;
                ThreadPool.QueueUserWorkItem(delegate(object param0)
                {
                    try
                    {
                        task.PerformTask(arg, taskMode);
                        lock (performedTasksLock)
                        {
                            performedTasks.Add(undoableTask);
                        }
                    }
                    catch (Exception item)
                    {
                        lock (exceptionsLock)
                        {
                            exceptions.Add(item);
                        }
                    }
                    autoResetEvent.Set();
                });
            }
            foreach (AutoResetEvent current2 in dictionary.Values)
            {
                current2.WaitOne();
            }
            if (exceptions.Count > 0)
            {
                CompositeUndoableTask<T>.SafelyUndoTasks(performedTasks.Cast<IUndoableTask>());
                throw new CompositeException("Unable to undo tasks", exceptions);
            }
        }

        private static void UndoInParallel(Dictionary<UndoableTaskBase<T>, T> taskDictionary)
        {
            List<UndoableTaskBase<T>> performedTasks = new List<UndoableTaskBase<T>>();
            object performedTasksLock = new object();
            List<Exception> exceptions = new List<Exception>();
            object exceptionsLock = new object();
            Dictionary<KeyValuePair<UndoableTaskBase<T>, T>, AutoResetEvent> dictionary = taskDictionary.ToDictionary((KeyValuePair<UndoableTaskBase<T>, T> x) => x, (KeyValuePair<UndoableTaskBase<T>, T> x) => new AutoResetEvent(false));
            foreach (KeyValuePair<UndoableTaskBase<T>, T> current in taskDictionary)
            {
                AutoResetEvent autoResetEvent = dictionary[current];
                UndoableTaskBase<T> undoableTask = current.Key;
                ThreadPool.QueueUserWorkItem(delegate(object param0)
                {
                    try
                    {
                        ((IUndoableTask)undoableTask).Undo();
                        lock (performedTasksLock)
                        {
                            performedTasks.Add(undoableTask);
                        }
                    }
                    catch (Exception item)
                    {
                        lock (exceptionsLock)
                        {
                            exceptions.Add(item);
                        }
                    }
                    autoResetEvent.Set();
                });
            }
            foreach (AutoResetEvent current2 in dictionary.Values)
            {
                current2.WaitOne();
            }
            if (exceptions.Count > 0)
            {
                CompositeUndoableTask<T>.SafelyUndoTasks(performedTasks.Cast<IUndoableTask>());
                throw new CompositeException("Unable to undo tasks", exceptions);
            }
        }
    }  
}
