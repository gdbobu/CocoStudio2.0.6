// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.GuidesLockChangeEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Event
{
  public class GuidesLockChangeEventArgs
  {
    public bool IsLock { get; set; }

    public static GuidesLockChangeEventArgs Creat(bool lockState)
    {
      return new GuidesLockChangeEventArgs()
      {
        IsLock = lockState
      };
    }
  }
}
