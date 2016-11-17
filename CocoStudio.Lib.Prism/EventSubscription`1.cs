// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.EventSubscription`1
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Globalization;

namespace CocoStudio.Lib.Prism
{
  public class EventSubscription<TPayload> : IEventSubscription
  {
    private readonly IDelegateReference _actionReference;
    private readonly IDelegateReference _filterReference;

    public System.Action<TPayload> Action
    {
      get
      {
        return (System.Action<TPayload>) this._actionReference.Target;
      }
    }

    public Predicate<TPayload> Filter
    {
      get
      {
        return (Predicate<TPayload>) this._filterReference.Target;
      }
    }

    public SubscriptionToken SubscriptionToken { get; set; }

    public EventSubscription(IDelegateReference actionReference, IDelegateReference filterReference)
    {
      if (actionReference == null)
        throw new ArgumentNullException("actionReference");
      if (!(actionReference.Target is System.Action<TPayload>))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "The Target of the IDelegateReference should be of type {0}.", new object[1]{ (object) typeof (System.Action<TPayload>).FullName }), "actionReference");
      if (filterReference == null)
        throw new ArgumentNullException("filterReference");
      if (!(filterReference.Target is Predicate<TPayload>))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "The Target of the IDelegateReference should be of type {0}.", new object[1]{ (object) typeof (Predicate<TPayload>).FullName }), "filterReference");
      this._actionReference = actionReference;
      this._filterReference = filterReference;
    }

    public virtual System.Action<object[]> GetExecutionStrategy()
    {
      System.Action<TPayload> action = this.Action;
      Predicate<TPayload> filter = this.Filter;
      if (action != null && filter != null)
        return (System.Action<object[]>) (arguments =>
        {
          TPayload payload = default (TPayload);
          if (arguments != null && arguments.Length > 0 && arguments[0] != null)
            payload = (TPayload) arguments[0];
          if (!filter(payload))
            return;
          this.InvokeAction(action, payload);
        });
      return (System.Action<object[]>) null;
    }

    public virtual void InvokeAction(System.Action<TPayload> action, TPayload argument)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      action(argument);
    }
  }
}
