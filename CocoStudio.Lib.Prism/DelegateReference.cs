// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.DelegateReference
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;
using System.Reflection;

namespace CocoStudio.Lib.Prism
{
  public class DelegateReference : IDelegateReference
  {
    private readonly Delegate _delegate;
    private readonly WeakReference _weakReference;
    private readonly MethodInfo _method;
    private readonly Type _delegateType;

    public Delegate Target
    {
      get
      {
        if ((object) this._delegate != null)
          return this._delegate;
        return this.TryGetDelegate();
      }
    }

    public DelegateReference(Delegate @delegate, bool keepReferenceAlive)
    {
      if ((object) @delegate == null)
        throw new ArgumentNullException("delegate");
      if (keepReferenceAlive)
      {
        this._delegate = @delegate;
      }
      else
      {
        this._weakReference = new WeakReference(@delegate.Target);
        this._method = @delegate.Method;
        this._delegateType = @delegate.GetType();
      }
    }

    private Delegate TryGetDelegate()
    {
      if (this._method.IsStatic)
        return Delegate.CreateDelegate(this._delegateType, (object) null, this._method);
      object target = this._weakReference.Target;
      if (target != null)
        return Delegate.CreateDelegate(this._delegateType, target, this._method);
      return (Delegate) null;
    }
  }
}
