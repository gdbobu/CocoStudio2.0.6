// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.WeakDelegatesManager
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Lib.Prism
{
  internal class WeakDelegatesManager
  {
    private readonly List<DelegateReference> listeners = new List<DelegateReference>();

    public void AddListener(Delegate listener)
    {
      this.listeners.Add(new DelegateReference(listener, false));
    }

    public void RemoveListener(Delegate listener)
    {
      this.listeners.RemoveAll((Predicate<DelegateReference>) (reference =>
      {
        Delegate target = reference.Target;
        return listener.Equals((object) target) || (object) target == null;
      }));
    }

    public void Raise(params object[] args)
    {
      this.listeners.RemoveAll((Predicate<DelegateReference>) (listener => (object) listener.Target == null));
      foreach (Delegate @delegate in this.listeners.ToList<DelegateReference>().Select<DelegateReference, Delegate>((Func<DelegateReference, Delegate>) (listener => listener.Target)).Where<Delegate>((Func<Delegate, bool>) (listener => (object) listener != null)))
        @delegate.DynamicInvoke(args);
    }
  }
}
