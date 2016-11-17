// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.CompositeTaskManager
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using CocoStudio.UndoManager.Recorder;
using CocoStudio.UndoManager.TaskModel;
using CocoStudio.UndoManager.TaskModel.UndoableTask;
using System;
using System.Collections.Generic;

namespace CocoStudio.UndoManager
{
  internal class CompositeTaskManager : ICompositeTaskService
  {
    private const int maxTaskCount = 100;
    private IUndoManager taskService;
    private List<UndoableTaskBase<object>> taskList;
    private IEditableDocument currentDocument;
    private BaseRecorder currentSoleRecorder;
    private static CompositeTaskManager instance;

    public string CurrentCompositeTaskName { get; private set; }

    public bool IsRunningCompositeTask { get; private set; }

    public static ICompositeTaskService Instance
    {
      get
      {
        if (CompositeTaskManager.instance == null)
          CompositeTaskManager.instance = new CompositeTaskManager();
        return (ICompositeTaskService) CompositeTaskManager.instance;
      }
    }

    private CompositeTaskManager()
    {
      this.taskList = new List<UndoableTaskBase<object>>();
      this.taskService = TaskServiceSingleton.Instance;
    }

    private void PushCompositeTask(string taskName, List<UndoableTaskBase<object>> tasks)
    {
      if (tasks.Count <= 0)
        LogConfig.Logger.Debug((object) "There is no tasks in the composite task.");
      else
        this.PerformTask((UndoableTaskBase<object>) new SequentiallyCompositeUndoableTask<object>(tasks, taskName));
    }

    private void PerformTask(UndoableTaskBase<object> task)
    {
      this.CheckCurrentDocument();
      int num = (int) this.taskService.PerformTask<object>(task, (object) null, (object) this.currentDocument);
      this.currentDocument.IsDirty = true;
    }

    private void CheckSubTask(UndoTask task)
    {
      this.CheckTaskGroupName(task, this.taskList.Count);
    }

    private void CheckTaskGroupName(UndoTask task, int listCount)
    {
      if (!string.IsNullOrEmpty(task.TaskGroupName))
        throw new ArgumentException("Not support task group name now.");
    }

    private void AddSubTask(UndoTask task)
    {
      this.taskList.Add((UndoableTaskBase<object>) task);
    }

    private bool CheckCurrentDocument()
    {
      if (this.currentDocument == null)
      {
        string message = "Must open Document can have undo action.";
        LogConfig.Logger.Error((object) message);
        throw new InvalidOperationException(message);
      }
      return true;
    }

    internal void OnRedone(TaskServiceEventArgs e)
    {
      this.CheckCurrentDocument();
      this.currentDocument.IsDirty = true;
    }

    internal void OnUndone(TaskServiceEventArgs e)
    {
      this.CheckCurrentDocument();
      this.currentDocument.IsDirty = true;
    }

    public void AddRecord(UndoTask task)
    {
      if (!this.taskService.Enable)
        return;
      if (this.IsRunningCompositeTask)
      {
        this.CheckSubTask(task);
        this.AddSubTask(task);
      }
      else
      {
        if (!string.IsNullOrEmpty(task.TaskGroupName))
          throw new ArgumentException("Not support task group name now.");
        this.PerformTask((UndoableTaskBase<object>) task);
      }
    }

    public void RunAsCompositeTask(string taskName, Action aciton)
    {
      this.BeginCompositeTask(taskName);
      aciton();
      this.EndCompositeTask();
    }

    public void RunAsCompositeTask(string taskName, Action<object> aciton, object parameter)
    {
      this.RunAsCompositeTask(taskName, (Action) (() => aciton(parameter)));
    }

    public void BeginCompositeTask(string taskName)
    {
      if (this.IsRunningCompositeTask)
      {
        LogConfig.Logger.Error((object) "Begin composite task twice.One composite task is running.");
      }
      else
      {
        this.IsRunningCompositeTask = true;
        this.CurrentCompositeTaskName = taskName;
      }
    }

    public void EndCompositeTask()
    {
      if (!this.IsRunningCompositeTask)
      {
        LogConfig.Logger.Error((object) "Not running composite task. Cann't end composite task");
      }
      else
      {
        this.PushCompositeTask(this.CurrentCompositeTaskName, this.taskList);
        this.taskList.Clear();
        this.IsRunningCompositeTask = false;
      }
    }

    public void BeginSoleRecorder(BaseRecorder soleRecorder)
    {
      if (this.currentSoleRecorder != null)
        throw new InvalidOperationException("Can only ome recorder begin sole mode.");
      this.currentSoleRecorder = soleRecorder;
    }

    public void EndSoleRecorder()
    {
      if (this.currentSoleRecorder == null)
        throw new InvalidOperationException("Should call BeginSoleRecorder before call this function.");
      this.currentSoleRecorder = (BaseRecorder) null;
    }

    public void SetCurrentDocument(IEditableDocument document)
    {
      this.currentDocument = document;
      this.taskService.SetMaximumUndoCount(100, (object) document);
    }
  }
}
