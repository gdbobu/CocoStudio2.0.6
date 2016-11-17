// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.TaskModel.Task`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager.TaskModel
{
  public sealed class Task<T> : TaskBase<T>
  {
    private readonly string descriptionForUser;

    public override string DescriptionForUser
    {
      get
      {
        return this.descriptionForUser;
      }
    }

    public new bool Repeatable
    {
      get
      {
        return base.Repeatable;
      }
      set
      {
        base.Repeatable = value;
      }
    }

    public Task(Action<TaskEventArgs<T>> execute, string descriptionForUser)
    {
      ArgumentValidator.AssertNotNull<Action<TaskEventArgs<T>>>(execute, "execute");
      ArgumentValidator.AssertNotNullOrEmpty(descriptionForUser, "descriptionForUser");
      this.descriptionForUser = descriptionForUser;
      this.Execute += (EventHandler<TaskEventArgs<T>>) ((o, args) => execute(args));
    }
  }
}
