// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.IEditableDocument
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager
{
  public interface IEditableDocument
  {
    bool IsDirty { get; set; }

    string Name { get; }
  }
}
