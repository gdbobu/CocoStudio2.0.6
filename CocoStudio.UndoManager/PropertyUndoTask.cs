// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.PropertyUndoTask
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using CocoStudio.UndoManager.Recorder;
using System;
using System.Reflection;

namespace CocoStudio.UndoManager
{
  public class PropertyUndoTask : UndoTask
  {
    private object objectItem;
    private PropertyInfo prop;

    public object NewValue { get; set; }

    public object OldValue { get; set; }

    public string PropertyName
    {
      get
      {
        return this.prop.Name;
      }
    }

    public override string DescriptionForUser
    {
      get
      {
        return "PropertyUndoTask";
      }
    }

    public object ObjectItem
    {
      get
      {
        return this.objectItem;
      }
    }

    public PropertyUndoTask(DefaultRecorder recorder, object sender, PropertyInfo prop, object oldValue, object newValue)
      : base((BaseRecorder) recorder)
    {
      this.objectItem = sender;
      this.prop = prop;
      this.OldValue = oldValue;
      this.NewValue = newValue;
      this.execute = new Action<object>(this.Redoing);
      this.unExecute = new Action<object>(this.Undoing);
    }

    ~PropertyUndoTask()
    {
      this.Dispose();
    }

    private void Undoing(object temp)
    {
      this.SetPropertyValue(this.OldValue);
    }

    private void Redoing(object temp)
    {
      this.SetPropertyValue(this.NewValue);
    }

    private void SetPropertyValue(object value)
    {
      this.prop.SetValue(this.objectItem, value, DefaultRecorder.EmptyArray);
    }

    public override void Dispose()
    {
      this.objectItem = (object) null;
      this.prop = (PropertyInfo) null;
      this.NewValue = (object) null;
      this.OldValue = (object) null;
      GC.SuppressFinalize((object) this);
      base.Dispose();
    }
  }
}
