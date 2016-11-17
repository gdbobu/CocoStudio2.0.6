// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.IEventAggregator
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

namespace CocoStudio.Lib.Prism
{
  public interface IEventAggregator
  {
    TEventType GetEvent<TEventType>() where TEventType : EventBase, new();
  }
}
