// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.SubscriptionToken
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using System;

namespace CocoStudio.Lib.Prism
{
  public class SubscriptionToken : IEquatable<SubscriptionToken>, IDisposable
  {
    private readonly Guid _token;
    private Action<SubscriptionToken> _unsubscribeAction;

    public SubscriptionToken(Action<SubscriptionToken> unsubscribeAction)
    {
      this._unsubscribeAction = unsubscribeAction;
      this._token = Guid.NewGuid();
    }

    public bool Equals(SubscriptionToken other)
    {
      if (other == null)
        return false;
      return object.Equals((object) this._token, (object) other._token);
    }

    public override bool Equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      return this.Equals(obj as SubscriptionToken);
    }

    public override int GetHashCode()
    {
      return this._token.GetHashCode();
    }

    public virtual void Dispose()
    {
      if (this._unsubscribeAction != null)
      {
        this._unsubscribeAction(this);
        this._unsubscribeAction = (Action<SubscriptionToken>) null;
      }
      GC.SuppressFinalize((object) this);
    }
  }
}
