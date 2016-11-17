// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.Recorder.BaseRecorder
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using System;

namespace CocoStudio.UndoManager.Recorder
{
  public abstract class BaseRecorder : IDisposable
  {
    private static bool isCreateDefaultRecorder = true;
    protected INotifyStateChanged objectItem;
    private bool isAutoRecord;

    public static bool IsCreateDefaultRecorder
    {
      get
      {
        return BaseRecorder.isCreateDefaultRecorder;
      }
      set
      {
        BaseRecorder.isCreateDefaultRecorder = value;
        LogConfig.Logger.Error((object) ("BaseRecorder: IsCreateDefaultRecorder: " + (object) value));
      }
    }

    public static bool IsUndoing
    {
      get
      {
        return TaskServiceSingleton.Instance.IsUndoing;
      }
    }

    [Obsolete]
    internal string TaskGroupName { get; private set; }

    public bool IsAutoRecord
    {
      get
      {
        return this.isAutoRecord;
      }
      set
      {
        this.isAutoRecord = value;
      }
    }

    internal bool NeedRecordCallback
    {
      get
      {
        return this.objectItem is IRecordableCallback;
      }
    }

    public event EventHandler<RecorderCreatedEventArgs> RecorderCreatedEvent;

    public BaseRecorder(INotifyStateChanged objectItem, string taskGroupName = null)
    {
      this.IsAutoRecord = true;
      this.objectItem = objectItem;
      this.TaskGroupName = taskGroupName;
    }

    ~BaseRecorder()
    {
      this.Dispose();
    }

    internal void Redoing(RecorderTaskEventArgs args)
    {
      if (this.objectItem == null)
        return;
      IRecordableCallback objectItem = this.objectItem as IRecordableCallback;
      if (objectItem == null)
        return;
      objectItem.Redoing(args);
    }

    internal void Redone(RecorderTaskEventArgs args)
    {
      if (this.objectItem == null)
        return;
      IRecordableCallback objectItem = this.objectItem as IRecordableCallback;
      if (objectItem == null)
        return;
      objectItem.Redone(args);
    }

    internal void Undoing(RecorderTaskEventArgs args)
    {
      if (this.objectItem == null)
        return;
      IRecordableCallback objectItem = this.objectItem as IRecordableCallback;
      if (objectItem == null)
        return;
      objectItem.Undoing(args);
    }

    internal void Undone(RecorderTaskEventArgs args)
    {
      if (this.objectItem == null)
        return;
      IRecordableCallback objectItem = this.objectItem as IRecordableCallback;
      if (objectItem == null)
        return;
      objectItem.Undone(args);
    }

    protected virtual void OnStart(bool isCreateRecorder)
    {
    }

    protected virtual void OnStop(bool isUpdateOldValues = false)
    {
    }

    public void AddRecord(UndoTask undoTask)
    {
      CompositeTaskManager.Instance.AddRecord(undoTask);
      if (this.RecorderCreatedEvent == null)
        return;
      this.RecorderCreatedEvent((object) this, new RecorderCreatedEventArgs(this.objectItem, undoTask));
    }

    public void Start(bool isCreateRecorder = true, bool isSoleRecoder = false)
    {
      if (this.IsAutoRecord)
        throw new InvalidOperationException("This recorder is already opened.");
      this.IsAutoRecord = true;
      this.objectItem.IsRaiseStateChanged = true;
      this.OnStart(isCreateRecorder);
    }

    public void Stop(bool isUpdateOldValues = false)
    {
      if (!this.IsAutoRecord)
        throw new InvalidOperationException("This recorder is not opened.");
      this.IsAutoRecord = false;
      this.objectItem.IsRaiseStateChanged = false;
      this.OnStop(isUpdateOldValues);
    }

    public virtual void Dispose()
    {
      this.objectItem = (INotifyStateChanged) null;
      GC.SuppressFinalize((object) this);
    }
  }
}
