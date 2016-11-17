// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.CompositeTask
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using System;

namespace CocoStudio.UndoManager
{
  public class CompositeTask : IDisposable
  {
    private bool isAlreadyOpen = false;

    public static CompositeTask Run(string compositeTaskName)
    {
      CompositeTask compositeTask = CompositeTask.CreateCompositeTask();
      if (!TaskServiceSingleton.Instance.IsRunningCompositeTask)
      {
        TaskServiceSingleton.Instance.BeginCompositeTask(compositeTaskName);
        compositeTask.isAlreadyOpen = true;
      }
      else
        LogConfig.Logger.Debug((object) string.Format("Already runing composite task {0}, the new task name is {1}", (object) TaskServiceSingleton.Instance.CurrentCompositeTaskName, (object) compositeTaskName));
      return compositeTask;
    }

    public void Dispose()
    {
      if (!this.isAlreadyOpen)
        return;
      TaskServiceSingleton.Instance.EndCompositeTask();
      this.isAlreadyOpen = false;
    }

    private static CompositeTask CreateCompositeTask()
    {
      return new CompositeTask();
    }
  }
}
