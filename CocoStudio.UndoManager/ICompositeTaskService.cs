// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.ICompositeTaskService
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager
{
  public interface ICompositeTaskService
  {
    string CurrentCompositeTaskName { get; }

    bool IsRunningCompositeTask { get; }

    void RunAsCompositeTask(string taskName, Action aciton);

    void RunAsCompositeTask(string taskName, Action<object> aciton, object parameter);

    void BeginCompositeTask(string taskName);

    void EndCompositeTask();

    void AddRecord(UndoTask task);

    void SetCurrentDocument(IEditableDocument document);
  }
}
