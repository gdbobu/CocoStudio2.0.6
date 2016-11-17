// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskServiceLock
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using System;

namespace CocoStudio.UndoManager
{
  public class TaskServiceLock : IDisposable
  {
    private bool isEnable = true;

    private TaskServiceLock()
    {
    }

    public static TaskServiceLock Lock()
    {
      TaskServiceLock taskServiceLock = new TaskServiceLock();
      if (TaskServiceSingleton.Instance.Enable)
        taskServiceLock.isEnable = TaskServiceSingleton.Instance.Enable = false;
      else
        LogConfig.Logger.Error((object) string.Format("Task service already closed."));
      return taskServiceLock;
    }

    public void Dispose()
    {
      if (this.isEnable)
        return;
      this.isEnable = TaskServiceSingleton.Instance.Enable = true;
    }
  }
}
