// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.CompositePresentationEvent`1
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Linq;

namespace CocoStudio.Lib.Prism
{
  public class CompositePresentationEvent<TPayload> : EventBase
  {
    private IDispatcherFacade uiDispatcher;

    private IDispatcherFacade UIDispatcher
    {
      get
      {
        if (this.uiDispatcher == null)
          this.uiDispatcher = (IDispatcherFacade) new DefaultDispatcher();
        return this.uiDispatcher;
      }
    }

    public SubscriptionToken Subscribe(Action<TPayload> action)
    {
      return this.Subscribe(action, ThreadOption.PublisherThread);
    }

    public SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption)
    {
      return this.Subscribe(action, threadOption, false);
    }

    public SubscriptionToken Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive)
    {
      return this.Subscribe(action, ThreadOption.PublisherThread, keepSubscriberReferenceAlive);
    }

    public SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption, bool keepSubscriberReferenceAlive)
    {
      return this.Subscribe(action, threadOption, keepSubscriberReferenceAlive, (Predicate<TPayload>) null);
    }

    public virtual SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption, bool keepSubscriberReferenceAlive, Predicate<TPayload> filter)
    {

        IDelegateReference actionReference = new DelegateReference(action, keepSubscriberReferenceAlive);
        IDelegateReference filterReference;
        if (filter != null)
        {
            filterReference = new DelegateReference(filter, keepSubscriberReferenceAlive);
        }
        else
        {
            filterReference = new DelegateReference(new Predicate<TPayload>((TPayload param0) => true), true);
        }
        EventSubscription<TPayload> eventSubscription;
        switch (threadOption)
        {
            case ThreadOption.PublisherThread:
                eventSubscription = new EventSubscription<TPayload>(actionReference, filterReference);
                break;
            case ThreadOption.UIThread:
                eventSubscription = new DispatcherEventSubscription<TPayload>(actionReference, filterReference, this.UIDispatcher);
                break;
            case ThreadOption.BackgroundThread:
                eventSubscription = new BackgroundEventSubscription<TPayload>(actionReference, filterReference);
                break;
            default:
                eventSubscription = new EventSubscription<TPayload>(actionReference, filterReference);
                break;
        }
        return base.InternalSubscribe(eventSubscription);
    }

    public virtual void Publish(TPayload payload)
    {
      this.InternalPublish((object) payload);
    }

    public virtual void Unsubscribe(Action<TPayload> subscriber)
    {
      lock (this.Subscriptions)
      {
        IEventSubscription local_0 = (IEventSubscription) this.Subscriptions.Cast<EventSubscription<TPayload>>().FirstOrDefault<EventSubscription<TPayload>>((Func<EventSubscription<TPayload>, bool>) (evt => evt.Action == subscriber));
        if (local_0 == null)
          return;
        this.Subscriptions.Remove(local_0);
      }
    }

    public virtual bool Contains(Action<TPayload> subscriber)
    {
      IEventSubscription eventSubscription;
      lock (this.Subscriptions)
        eventSubscription = (IEventSubscription) this.Subscriptions.Cast<EventSubscription<TPayload>>().FirstOrDefault<EventSubscription<TPayload>>((Func<EventSubscription<TPayload>, bool>) (evt => evt.Action == subscriber));
      return eventSubscription != null;
    }
  }
}
