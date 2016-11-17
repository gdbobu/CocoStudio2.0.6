// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.EventBase
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Lib.Prism
{
  public abstract class EventBase
  {
    private readonly List<IEventSubscription> _subscriptions = new List<IEventSubscription>();

    protected ICollection<IEventSubscription> Subscriptions
    {
      get
      {
        return (ICollection<IEventSubscription>) this._subscriptions;
      }
    }

    protected virtual SubscriptionToken InternalSubscribe(IEventSubscription eventSubscription)
    {
      if (eventSubscription == null)
        throw new ArgumentNullException("eventSubscription");
      eventSubscription.SubscriptionToken = new SubscriptionToken(new Action<SubscriptionToken>(this.Unsubscribe));
      lock (this.Subscriptions)
        this.Subscriptions.Add(eventSubscription);
      return eventSubscription.SubscriptionToken;
    }

    protected virtual void InternalPublish(params object[] arguments)
    {
      foreach (Action<object[]> andReturnStrategy in this.PruneAndReturnStrategies())
        andReturnStrategy(arguments);
    }

    public virtual void Unsubscribe(SubscriptionToken token)
    {
      lock (this.Subscriptions)
      {
        IEventSubscription local_0 = this.Subscriptions.FirstOrDefault<IEventSubscription>((Func<IEventSubscription, bool>) (evt => evt.SubscriptionToken == token));
        if (local_0 == null)
          return;
        this.Subscriptions.Remove(local_0);
      }
    }

    public virtual bool Contains(SubscriptionToken token)
    {
      lock (this.Subscriptions)
        return this.Subscriptions.FirstOrDefault<IEventSubscription>((Func<IEventSubscription, bool>) (evt => evt.SubscriptionToken == token)) != null;
    }

    private List<Action<object[]>> PruneAndReturnStrategies()
    {
      List<Action<object[]>> actionList = new List<Action<object[]>>();
      lock (this.Subscriptions)
      {
        for (int local_1 = this.Subscriptions.Count - 1; local_1 >= 0; --local_1)
        {
          Action<object[]> local_2 = this._subscriptions[local_1].GetExecutionStrategy();
          if (local_2 == null)
            this._subscriptions.RemoveAt(local_1);
          else
            actionList.Add(local_2);
        }
      }
      return actionList;
    }
  }
}
