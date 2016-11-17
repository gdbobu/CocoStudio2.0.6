// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.UndoTask
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.Recorder;
using CocoStudio.UndoManager.TaskModel;
using System;

namespace CocoStudio.UndoManager
{
  public class UndoTask : UndoableTaskBase<object>
  {
    protected Predicate<object> canExecute;
    protected Action<object> execute;
    protected Action<object> unExecute;

    public override string DescriptionForUser
    {
      get
      {
        return "UndoTask";
      }
    }

    public string TaskGroupName { get; private set; }

    internal BaseRecorder Recorder { get; private set; }

    public UndoTask(BaseRecorder recorder)
    {
      if (recorder != null && recorder.NeedRecordCallback)
        this.Recorder = recorder;
      this.TaskGroupName = recorder.TaskGroupName;
      this.Init();
    }

    public UndoTask(BaseRecorder recorder, Action<object> execute, Action<object> unExecute = null, Predicate<object> canExecute = null)
      : this(recorder)
    {
      this.execute = execute;
      this.canExecute = canExecute;
      this.unExecute = unExecute;
    }

    ~UndoTask()
    {
      this.Dispose();
    }

    private void Init()
    {
      this.Repeatable = false;
      this.RegisterEventHandle();
    }

    private void RegisterEventHandle()
    {
      this.Execute += new EventHandler<TaskEventArgs<object>>(this.OnExecute);
      this.Undo += new EventHandler<TaskEventArgs<object>>(this.OnUndo);
    }

    private void OnExecute(object sender, TaskEventArgs<object> e)
    {
      if (e.TaskMode != TaskMode.Redo)
        return;
      if (this.Recorder != null)
      {
        RecorderTaskEventArgs args = new RecorderTaskEventArgs(this);
        this.Recorder.Redoing(args);
        if (args.Enabled)
          this.execute((object) null);
        this.Recorder.Redone(args);
      }
      else
        this.execute((object) null);
    }

    private void OnUndo(object sender, TaskEventArgs<object> e)
    {
      if (this.Recorder != null)
      {
        RecorderTaskEventArgs args = new RecorderTaskEventArgs(this);
        this.Recorder.Undoing(args);
        if (args.Enabled)
          this.unExecute((object) null);
        this.Recorder.Undone(args);
      }
      else
        this.unExecute((object) null);
    }

    public override void Dispose()
    {
      this.canExecute = (Predicate<object>) null;
      this.execute = (Action<object>) null;
      this.unExecute = (Action<object>) null;
      this.Recorder = (BaseRecorder) null;
      GC.SuppressFinalize((object) this);
      base.Dispose();
    }
  }
}
