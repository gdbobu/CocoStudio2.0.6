// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ObjectCollection`1
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.ViewModel
{
  public class ObjectCollection<T> : ObservableCollection<T> where T : class
  {
    protected ObjectCollection()
    {
    }

    public new void Add(T item)
    {
      this.OnAdd(item);
      base.Add(item);
    }

    public new void Insert(int index, T item)
    {
      this.OnInsert(index, item);
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

    protected virtual void OnInsert(int index, T item)
    {
      throw new NotImplementedException();
    }
  }
}
