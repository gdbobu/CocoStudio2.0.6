// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.DispatcherEventSubscription`1
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;

namespace CocoStudio.Lib.Prism
{
  public class DispatcherEventSubscription<TPayload> : EventSubscription<TPayload>
  {
    private readonly IDispatcherFacade dispatcher;

    public DispatcherEventSubscription(IDelegateReference actionReference, IDelegateReference filterReference, IDispatcherFacade dispatcher)
      : base(actionReference, filterReference)
    {
      this.dispatcher = dispatcher;
    }

    public override void InvokeAction(Action<TPayload> action, TPayload argument)
    {
      this.dispatcher.BeginInvoke((Delegate) action, (object) argument);
    }
  }
}
