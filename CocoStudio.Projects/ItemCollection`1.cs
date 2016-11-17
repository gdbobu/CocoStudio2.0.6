// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ItemCollection`1
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Projects
{
  public class ItemCollection<T> : ObservableCollection<T> where T : class
  {
    protected ItemCollection()
    {
    }

    public new void Add(T item)
    {
      this.OnAdd(item);
      base.Add(item);
    }

    public new void Insert(int index, T item)
    {
      this.OnAdd(item);
      base.Insert(index, item);
    }

    public void Remove(T item)
    {
      this.OnRemove(item);
      base.Remove(item);
    }

    public new void RemoveAt(int index)
    {
      T obj = this[index];
      base.RemoveAt(index);
      this.OnRemove(obj);
    }

    public new void Clear()
    {
      foreach (T obj in (Collection<T>) this)
        this.OnRemove(obj);
      base.Clear();
    }

    protected virtual void OnRemove(T item)
    {
      throw new NotImplementedException();
    }

    protected virtual void OnAdd(T item)
    {
      throw new NotImplementedException();
    }
  }
}
