// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.CompositeTask`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CocoStudio.UndoManager.TaskModel
{
    public class CompositeTask<T> : TaskBase<T>
    {
        private readonly string descriptionForUser;

        private readonly Dictionary<TaskBase<T>, T> taskDictionary;

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

        public CompositeTask(IDictionary<TaskBase<T>, T> tasks, string descriptionForUser)
        {
            ArgumentValidator.AssertNotNull<string>(descriptionForUser, "descriptionForUser");
            ArgumentValidator.AssertNotNull<IDictionary<TaskBase<T>, T>>(tasks, "tasks");
            this.descriptionForUser = descriptionForUser;
            this.taskDictionary = new Dictionary<TaskBase<T>, T>(tasks);
            base.Execute += new EventHandler<TaskEventArgs<T>>(this.OnExecute);
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

        protected internal virtual void ExecuteInternal(Dictionary<TaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            if (this.Parallel)
            {
                CompositeTask<T>.ExecuteInParallel(taskDictionary, taskMode);
            }
            else
            {
                CompositeTask<T>.ExecuteInSequence(taskDictionary, taskMode);
            }
        }

        private static void ExecuteInSequence(Dictionary<TaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            foreach (KeyValuePair<TaskBase<T>, T> current in taskDictionary)
            {
                IInternalTask key = current.Key;
                key.PerformTask(current.Value, taskMode);
            }
        }

        private static void ExecuteInParallel(Dictionary<TaskBase<T>, T> taskDictionary, TaskMode taskMode)
        {
            List<TaskBase<T>> performedTasks = new List<TaskBase<T>>();
            object performedTasksLock = new object();
            List<Exception> exceptions = new List<Exception>();
            object exceptionsLock = new object();
            Dictionary<KeyValuePair<TaskBase<T>, T>, AutoResetEvent> dictionary = taskDictionary.ToDictionary((KeyValuePair<TaskBase<T>, T> x) => x, (KeyValuePair<TaskBase<T>, T> x) => new AutoResetEvent(false));
            foreach (KeyValuePair<TaskBase<T>, T> current in taskDictionary)
            {
                AutoResetEvent autoResetEvent = dictionary[current];
                IInternalTask task = current.Key;
                TaskBase<T> undoableTask = current.Key;
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
                throw new CompositeException("Unable to undo tasks", exceptions);
            }
        }
    }
}
