// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.EventAggregator
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Collections.Generic;

namespace CocoStudio.Lib.Prism
{
  public class EventAggregator : IEventAggregator
  {
    private readonly Dictionary<Type, EventBase> events = new Dictionary<Type, EventBase>();

    public static EventAggregator Instance { get; private set; }

    static EventAggregator()
    {
      EventAggregator.Instance = new EventAggregator();
    }

    private EventAggregator()
    {
    }

    public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
    {
      EventBase eventBase = (EventBase) null;
      if (this.events.TryGetValue(typeof (TEventType), out eventBase))
        return (TEventType) eventBase;
      TEventType instance = Activator.CreateInstance<TEventType>();
      this.events[typeof (TEventType)] = (EventBase) instance;
      return instance;
    }
  }
}
