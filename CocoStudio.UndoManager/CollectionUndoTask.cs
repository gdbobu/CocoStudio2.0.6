// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.CollectionUndoTask
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.Recorder;
using System;
using System.Collections;

namespace CocoStudio.UndoManager
{
  public class CollectionUndoTask : UndoTask
  {
    public IEnumerable NewItems { get; private set; }

    public IEnumerable OldItems { get; private set; }

    public CollectionUndoTask(BaseRecorder recorder, IEnumerable newItems, IEnumerable oldItems, Action<object> execute, Action<object> unExecute = null, Predicate<object> canExecute = null)
      : base(recorder, execute, unExecute, canExecute)
    {
      this.NewItems = newItems;
      this.OldItems = oldItems;
    }

    public override void Dispose()
    {
      base.Dispose();
      this.DisposeItems(this.NewItems);
      this.NewItems = (IEnumerable) null;
      this.DisposeItems(this.OldItems);
      this.OldItems = (IEnumerable) null;
    }

    private void DisposeItems(IEnumerable items)
    {
      if (items == null)
        return;
      foreach (object obj in items)
      {
        IDisposable disposable = obj as IDisposable;
        if (disposable != null)
          disposable.Dispose();
      }
    }
  }
}
