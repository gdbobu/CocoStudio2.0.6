// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.Recorder.RecorderTaskEventArgs
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.TaskModel;

namespace CocoStudio.UndoManager.Recorder
{
  public class RecorderTaskEventArgs : UndoableTaskEventArgs<UndoTask>
  {
    public RecorderTaskEventArgs(UndoTask undoTask)
      : base(undoTask)
    {
    }
  }
}
