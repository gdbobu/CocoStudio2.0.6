// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.Recorder.DefaultRecorder
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CocoStudio.UndoManager.Recorder
{
  public class DefaultRecorder : BaseRecorder
  {
    internal static readonly object[] EmptyArray = new object[0];
    private readonly Dictionary<string, object> oldValueList = new Dictionary<string, object>();

    public DefaultRecorder(INotifyStateChanged objectItem, string taskGroupName = null)
      : base(objectItem, taskGroupName)
    {
      this.Initialize();
    }

    ~DefaultRecorder()
    {
      this.Dispose();
    }

    private void Initialize()
    {
      this.AnalyzeObject();
    }

    private void AnalyzeObject()
    {
      bool flag = false;
      foreach (PropertyInfo property in this.objectItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (property.GetCustomAttributes(typeof (UndoPropertyAttribute), true).Length > 0 && property.CanRead)
        {
          object obj = property.GetValue((object) this.objectItem, DefaultRecorder.EmptyArray);
          if (property.CanWrite)
          {
            this.oldValueList[property.Name] = obj;
            flag = true;
          }
          if (obj is INotifyCollectionChanged)
            ((INotifyCollectionChanged) obj).CollectionChanged += new NotifyCollectionChangedEventHandler(this.ObjectItem_CollectionChanged);
        }
      }
      if (!flag)
        return;
      this.objectItem.PropertyChanged += new PropertyChangedEventHandler(this.ObjectItem_PropertyChanged);
      this.objectItem.StateChanged += new EventHandler<StateChangedEventArgs>(this.ObjectItem_StateChanged);
    }

    private bool CanIgnore()
    {
      return BaseRecorder.IsUndoing || !this.IsAutoRecord;
    }

    private void ObjectItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      try
      {
        if (!this.IsAutoRecord || !this.ContainsProperty(e.PropertyName))
          return;
        this.PropertyChangedHandle(sender, e);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "ObjectItem_PropertyChanged exception.", ex);
      }
    }

    private bool ContainsProperty(string propertyName)
    {
      return this.oldValueList.ContainsKey(propertyName);
    }

    private void ObjectItem_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      try
      {
        if (this.CanIgnore())
          return;
        this.CollectionChangedHandle(sender, e);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "CollectionChangedHandle exception.", ex);
      }
    }

    private void ObjectItem_StateChanged(object sender, StateChangedEventArgs e)
    {
      try
      {
        if (this.CanIgnore() || !this.ContainsProperty(e.PropertyName))
          return;
        this.StateChangedHandle(sender, e);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "PropertyChangedHandle exception.", ex);
      }
    }

    private void PropertyChangedHandle(object sender, PropertyChangedEventArgs e)
    {
      object newValue = (object) null;
      PropertyInfo property = (PropertyInfo) null;
      if (this.IsCollectionProperty(sender, e.PropertyName, out property, out newValue))
        this.UpdateCollectionChangedRegister(e.PropertyName, newValue as INotifyCollectionChanged);
      else
        this.oldValueList[e.PropertyName] = newValue;
    }

    private void CollectionChangedHandle(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (DefaultRecorder.IsList(sender))
        this.RegisterIListChanges(sender, e);
      else if (DefaultRecorder.IsCollection(sender))
        this.RegisterICollectionChanges(sender, e);
      else
        LogConfig.Logger.Error((object) "The Class that implements INotifyCollectionChanged does not Implement ICollection<T>, IList or IList<T>");
    }

    private void StateChangedHandle(object sender, StateChangedEventArgs e)
    {
      object newValue = (object) null;
      PropertyInfo property = (PropertyInfo) null;
      if (this.IsCollectionProperty(sender, e.PropertyName, out property, out newValue))
        this.UpdateCollectionChangedRegister(e.PropertyName, newValue as INotifyCollectionChanged);
      else
        this.AddTask((UndoTask) this.CreatePropertyUndoTask(e, property, newValue));
    }

    private bool IsCollectionProperty(object sender, string propertyName, out PropertyInfo property, out object newValue)
    {
      property = sender.GetType().GetProperty(propertyName);
      newValue = property.GetValue(sender, DefaultRecorder.EmptyArray);
      return newValue is INotifyCollectionChanged;
    }

    private void UpdateCollectionChangedRegister(string propertyName, INotifyCollectionChanged newValue)
    {
      INotifyCollectionChanged oldValue = this.oldValueList[propertyName] as INotifyCollectionChanged;
      if (oldValue != null)
        oldValue.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.ObjectItem_CollectionChanged);
      if (newValue != null)
        newValue.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ObjectItem_CollectionChanged);
      this.oldValueList[propertyName] = (object) newValue;
    }

    private void RegisterICollectionChanges(object sender, NotifyCollectionChangedEventArgs e)
    {
      MethodInfo add = sender.GetType().GetMethod("Add");
      MethodInfo remove = sender.GetType().GetMethod("Remove");
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            foreach (object newItem in (IEnumerable) e.NewItems)
              add.Invoke(sender, new object[1]{ newItem });
          }), (Action<object>) (param =>
          {
            foreach (object newItem in (IEnumerable) e.NewItems)
              remove.Invoke(sender, new object[1]{ newItem });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Remove:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            foreach (object oldItem in (IEnumerable) e.OldItems)
              remove.Invoke(sender, new object[1]{ oldItem });
          }), (Action<object>) (param =>
          {
            foreach (object oldItem in (IEnumerable) e.OldItems)
              add.Invoke(sender, new object[1]{ oldItem });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Replace:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            foreach (object oldItem in (IEnumerable) e.OldItems)
              remove.Invoke(sender, new object[1]{ oldItem });
            foreach (object newItem in (IEnumerable) e.NewItems)
              add.Invoke(sender, new object[1]{ newItem });
          }), (Action<object>) (param =>
          {
            foreach (object newItem in (IEnumerable) e.NewItems)
              remove.Invoke(sender, new object[1]{ newItem });
            foreach (object oldItem in (IEnumerable) e.OldItems)
              add.Invoke(sender, new object[1]{ oldItem });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Move:
          throw new NotSupportedException("You can only Move object in IList or IList<T> not Collection<T>");
      }
    }

    private void RegisterIListChanges(object sender, NotifyCollectionChangedEventArgs e)
    {
      PropertyInfo indexer = sender.GetType().GetProperty("Item");
      MethodInfo insert = sender.GetType().GetMethod("Insert");
      MethodInfo removeAt = sender.GetType().GetMethod("RemoveAt");
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            for (int index = e.NewItems.Count - 1; index >= 0; --index)
              insert.Invoke(sender, new object[2]
              {
                (object) e.NewStartingIndex,
                e.NewItems[index]
              });
          }), (Action<object>) (param =>
          {
            for (int index = 0; index < e.NewItems.Count; ++index)
            {
              if (indexer.GetValue(sender, new object[1]{ (object) e.NewStartingIndex }) != e.NewItems[index])
                Debugger.Break();
              removeAt.Invoke(sender, new object[1]
              {
                (object) e.NewStartingIndex
              });
            }
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Remove:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            for (int index = 0; index < e.OldItems.Count; ++index)
              removeAt.Invoke(sender, new object[1]
              {
                (object) e.OldStartingIndex
              });
          }), (Action<object>) (param =>
          {
            for (int index = e.OldItems.Count - 1; index >= 0; --index)
              insert.Invoke(sender, new object[2]
              {
                (object) e.OldStartingIndex,
                e.OldItems[index]
              });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Replace:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            for (int index = e.NewItems.Count - 1; index >= 0; --index)
              indexer.SetValue(sender, e.NewItems[index], new object[1]
              {
                (object) (index + e.NewStartingIndex)
              });
          }), (Action<object>) (param =>
          {
            for (int index = 0; index < e.NewItems.Count; ++index)
              indexer.SetValue(sender, e.OldItems[index], new object[1]
              {
                (object) (index + e.NewStartingIndex)
              });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Move:
          this.AddTask((UndoTask) new CollectionUndoTask((BaseRecorder) this, (IEnumerable) e.NewItems, (IEnumerable) e.OldItems, (Action<object>) (param =>
          {
            for (int index = 0; index < e.OldItems.Count; ++index)
              removeAt.Invoke(sender, new object[1]
              {
                (object) e.OldStartingIndex
              });
            for (int index = e.NewItems.Count - 1; index >= 0; --index)
              insert.Invoke(sender, new object[2]
              {
                (object) e.NewStartingIndex,
                e.NewItems[index]
              });
          }), (Action<object>) (param =>
          {
            for (int index = 0; index < e.NewItems.Count; ++index)
              removeAt.Invoke(sender, new object[1]
              {
                (object) e.NewStartingIndex
              });
            for (int index = e.NewItems.Count - 1; index >= 0; --index)
              insert.Invoke(sender, new object[2]
              {
                (object) e.OldStartingIndex,
                e.OldItems[index]
              });
          }), (Predicate<object>) null));
          break;
        case NotifyCollectionChangedAction.Reset:
          LogConfig.Logger.Error((object) "No NotifyCollectionChangedAction.Reset");
          break;
        default:
          LogConfig.Logger.Error((object) "No default shuld exist");
          break;
      }
    }

    private static bool IsList(object sender)
    {
      if (sender is IList)
        return true;
      Queue<Type> typeQueue = new Queue<Type>((IEnumerable<Type>) sender.GetType().GetInterfaces());
      while (typeQueue.Count != 0)
      {
        Type type1 = typeQueue.Dequeue();
        foreach (Type type2 in type1.GetInterfaces())
          typeQueue.Enqueue(type2);
        if (type1.IsGenericType && typeof (IList<object>).GetGenericTypeDefinition() == type1.GetGenericTypeDefinition())
          return true;
      }
      return false;
    }

    private static bool IsCollection(object sender)
    {
      Queue<Type> typeQueue = new Queue<Type>((IEnumerable<Type>) sender.GetType().GetInterfaces());
      while (typeQueue.Count != 0)
      {
        Type type1 = typeQueue.Dequeue();
        foreach (Type type2 in type1.GetInterfaces())
          typeQueue.Enqueue(type2);
        if (type1.IsGenericType && typeof (ICollection<object>).GetGenericTypeDefinition() == type1.GetGenericTypeDefinition())
          return true;
      }
      return false;
    }

    protected PropertyUndoTask CreatePropertyUndoTask(StateChangedEventArgs e, PropertyInfo property, object currentValue)
    {
      if (e.IsProvideValue)
      {
        this.oldValueList[e.PropertyName] = e.NewValue;
        return new PropertyUndoTask(this, (object) this.objectItem, property, e.OldValue, e.NewValue);
      }
      object oldValue = this.oldValueList[e.PropertyName];
      return new PropertyUndoTask(this, (object) this.objectItem, property, oldValue, currentValue);
    }

    private void AddTask(UndoTask undoTask)
    {
      if (!TaskServiceSingleton.Instance.Enable)
        return;
      this.AddRecord(undoTask);
    }

    private bool IsValueEquals(object newValue, object oldValue)
    {
      if (newValue != null)
        return newValue.Equals(oldValue);
      return oldValue == null;
    }

    protected List<UndoTask> CollectChangedProperty(bool isCreateRecorder)
    {
      List<UndoTask> undoTaskList = new List<UndoTask>();
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      Type type = this.objectItem.GetType();
      foreach (KeyValuePair<string, object> oldValue in this.oldValueList)
      {
        PropertyInfo property = type.GetProperty(oldValue.Key);
        object newValue = property.GetValue((object) this.objectItem, DefaultRecorder.EmptyArray);
        if (!this.IsValueEquals(newValue, oldValue.Value))
        {
          if (newValue is INotifyCollectionChanged)
            this.UpdateCollectionChangedRegister(oldValue.Key, newValue as INotifyCollectionChanged);
          else if (isCreateRecorder)
            undoTaskList.Add((UndoTask) new PropertyUndoTask(this, (object) this.objectItem, property, oldValue.Value, newValue));
          dictionary.Add(oldValue.Key, newValue);
        }
      }
      foreach (KeyValuePair<string, object> keyValuePair in dictionary)
        this.oldValueList[keyValuePair.Key] = keyValuePair.Value;
      return undoTaskList;
    }

    protected override void OnStart(bool isCreateRecorder)
    {
      this.objectItem.PropertyChanged += new PropertyChangedEventHandler(this.ObjectItem_PropertyChanged);
      foreach (UndoTask undoTask in this.CollectChangedProperty(isCreateRecorder))
        this.AddRecord(undoTask);
    }

    protected override void OnStop(bool isUpdateOldValues = false)
    {
      this.objectItem.PropertyChanged -= new PropertyChangedEventHandler(this.ObjectItem_PropertyChanged);
      if (!isUpdateOldValues)
        return;
      foreach (KeyValuePair<string, object> keyValuePair in this.oldValueList.ToList<KeyValuePair<string, object>>())
      {
        object obj = this.objectItem.GetType().GetProperty(keyValuePair.Key).GetValue((object) this.objectItem, DefaultRecorder.EmptyArray);
        this.oldValueList[keyValuePair.Key] = obj;
      }
    }

    public override void Dispose()
    {
      if (this.objectItem != null)
      {
        this.objectItem.PropertyChanged -= new PropertyChangedEventHandler(this.ObjectItem_PropertyChanged);
        this.objectItem.StateChanged -= new EventHandler<StateChangedEventArgs>(this.ObjectItem_StateChanged);
        this.oldValueList.Clear();
      }
      GC.SuppressFinalize((object) this);
      base.Dispose();
    }

    public void UpdateCachedValue(string propertyName, object value)
    {
      if (!this.ContainsProperty(propertyName))
        return;
      this.oldValueList[propertyName] = value;
    }
  }
}
