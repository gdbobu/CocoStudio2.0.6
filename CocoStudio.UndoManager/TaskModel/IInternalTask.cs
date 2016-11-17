// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.IInternalTask
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager.TaskModel
{
  internal interface IInternalTask : ITask, IDisposable
  {
    object Argument { get; }

    TaskResult PerformTask(object argument, TaskMode taskMode);
  }
}
