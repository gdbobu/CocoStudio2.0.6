// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.IUndoManager
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager
{
  public interface IUndoManager : ITaskService
  {
    string CurrentCompositeTaskName { get; }

    bool IsRunningCompositeTask { get; }

    void BeginCompositeTask(string taskName);

    void EndCompositeTask();

    void SetCurrentDocument(IEditableDocument document);
  }
}
