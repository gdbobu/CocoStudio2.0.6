// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.CancelableEventArgs`1
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

namespace CocoStudio.UndoManager
{
  public class CancelableEventArgs<TPayload>
  {
    private bool cancel;

    public bool Cancel
    {
      get
      {
        return this.cancel;
      }
      set
      {
        if (!value)
          return;
        this.cancel = true;
      }
    }

    public TPayload Payload { get; set; }

    public CancelableEventArgs(TPayload payload)
    {
      this.Payload = payload;
    }
  }
}
