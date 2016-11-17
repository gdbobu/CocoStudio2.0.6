// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.CancellableTaskServiceEventArgs
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager.TaskModel
{
  public class CancellableTaskServiceEventArgs : TaskServiceEventArgs
  {
    private bool cancelled;

    public bool Cancel
    {
      get
      {
        return this.cancelled;
      }
      set
      {
        if (this.cancelled)
          return;
        this.cancelled = value;
      }
    }

    internal object OwnerKey { get; set; }

    public CancellableTaskServiceEventArgs()
    {
    }

    public CancellableTaskServiceEventArgs(ITask task)
      : base(task)
    {
    }
  }
}
