// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.BackgroundEventSubscription`1
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Threading;

namespace CocoStudio.Lib.Prism
{
  public class BackgroundEventSubscription<TPayload> : EventSubscription<TPayload>
  {
    public BackgroundEventSubscription(IDelegateReference actionReference, IDelegateReference filterReference)
      : base(actionReference, filterReference)
    {
    }

    public override void InvokeAction(Action<TPayload> action, TPayload argument)
    {
      ThreadPool.QueueUserWorkItem((WaitCallback) (o => action(argument)));
    }
  }
}
