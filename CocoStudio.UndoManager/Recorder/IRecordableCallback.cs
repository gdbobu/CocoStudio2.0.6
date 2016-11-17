// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.Recorder.IRecordableCallback
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager.Recorder
{
  public interface IRecordableCallback
  {
    void Redoing(RecorderTaskEventArgs args);

    void Undoing(RecorderTaskEventArgs args);

    void Redone(RecorderTaskEventArgs args);

    void Undone(RecorderTaskEventArgs args);
  }
}
