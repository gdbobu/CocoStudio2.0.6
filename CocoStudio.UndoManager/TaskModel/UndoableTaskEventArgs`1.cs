// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.UndoableTaskEventArgs`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager.TaskModel
{
  public class UndoableTaskEventArgs<TArgument> : TaskEventArgs<TArgument>
  {
    private bool enabled = true;

    public bool Enabled
    {
      get
      {
        return this.enabled;
      }
      set
      {
        this.enabled = value;
      }
    }

    public UndoableTaskEventArgs(TArgument argument)
      : base(argument)
    {
    }

    internal UndoableTaskEventArgs(TArgument argument, TaskMode taskMode)
      : base(argument, taskMode)
    {
    }
  }
}
