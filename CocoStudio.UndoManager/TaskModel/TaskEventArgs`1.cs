// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.TaskEventArgs`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager.TaskModel
{
  public class TaskEventArgs<TArgument> : EventArgs
  {
    public TArgument Argument { get; set; }

    public TaskResult TaskResult { get; set; }

    public TaskMode TaskMode { get; private set; }

    public TaskEventArgs(TArgument argument)
    {
      this.Argument = argument;
    }

    internal TaskEventArgs(TArgument argument, TaskMode taskMode)
      : this(argument)
    {
      this.TaskMode = taskMode;
    }
  }
}
