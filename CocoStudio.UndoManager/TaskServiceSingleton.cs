// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskServiceSingleton
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.TaskModel;

namespace CocoStudio.UndoManager
{
  public class TaskServiceSingleton : TaskService, IUndoManager, ITaskService
  {
    private static TaskServiceSingleton instance;

    public static IUndoManager Instance
    {
      get
      {
        if (TaskServiceSingleton.instance == null)
          TaskServiceSingleton.instance = new TaskServiceSingleton();
        return (IUndoManager) TaskServiceSingleton.instance;
      }
    }

    public bool IsRunningCompositeTask
    {
      get
      {
        return CompositeTaskManager.Instance.IsRunningCompositeTask;
      }
    }

    public string CurrentCompositeTaskName
    {
      get
      {
        return CompositeTaskManager.Instance.CurrentCompositeTaskName;
      }
    }

    private TaskServiceSingleton()
    {
    }

    public void BeginCompositeTask(string taskName)
    {
      CompositeTaskManager.Instance.BeginCompositeTask(taskName);
    }

    public void EndCompositeTask()
    {
      CompositeTaskManager.Instance.EndCompositeTask();
    }

    public void SetCurrentDocument(IEditableDocument document)
    {
      CompositeTaskManager.Instance.SetCurrentDocument(document);
    }

    protected override void OnRedone(TaskServiceEventArgs e)
    {
      base.OnRedone(e);
      (CompositeTaskManager.Instance as CompositeTaskManager).OnRedone(e);
    }

    protected override void OnUndone(TaskServiceEventArgs e)
    {
      base.OnUndone(e);
      (CompositeTaskManager.Instance as CompositeTaskManager).OnUndone(e);
    }
  }
}
