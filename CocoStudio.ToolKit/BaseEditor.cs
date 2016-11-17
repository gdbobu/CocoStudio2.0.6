// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.BaseEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Model;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.ToolKit
{
  public abstract class BaseEditor
  {
    protected PropertyItem _propertyItem;
    protected object isMultiValue;

    public BaseEditor(PropertyItem propertyItem)
    {
      if (propertyItem == null)
        return;
      this._propertyItem = propertyItem;
      if (propertyItem.Instance is INotifyPropertyChanged)
        (propertyItem.Instance as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandle);
    }

    private void PropertyChangedHandle(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged(sender, e);
    }

    protected abstract void OnPropertyChanged(object sender, PropertyChangedEventArgs e);

    protected virtual void UpDateData(System.Action action = null)
    {
      this.editorWidget_BeforeValueChanged();
      if (action != null && this._propertyItem != null)
      {
        if (TaskServiceSingleton.Instance.IsRunningCompositeTask)
        {
          action();
        }
        else
        {
          using (CompositeTask.Run("Property Row"))
            action();
        }
      }
      this.editorWidget_AfterValueChanged();
    }

    private void editorWidget_BeforeValueChanged()
    {
      if (this._propertyItem == null)
        return;
      (this._propertyItem.Instance as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(this.PropertyChangedHandle);
    }

    private void editorWidget_AfterValueChanged()
    {
      if (this._propertyItem == null)
        return;
      (this._propertyItem.Instance as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandle);
    }

    protected void Dispose()
    {
      if (this._propertyItem == null)
        return;
      this.editorWidget_BeforeValueChanged();
    }

    protected bool IsWhip<T>(Func<T, T, bool> Func = null, string propertyName = "")
    {
      if (this._propertyItem.InstanceList == null || this._propertyItem.InstanceList.Count == 1)
        return false;
      object instance = this._propertyItem.InstanceList[0];
      PropertyInfo propertyInfo = !string.IsNullOrEmpty(propertyName) ? instance.GetType().GetProperty(propertyName) : this._propertyItem.PropertyData;
      T obj1 = (T) propertyInfo.GetValue(instance, (object[]) null);
      this.isMultiValue = (object) obj1;
      for (int index = 0; index < this._propertyItem.InstanceList.Count; ++index)
      {
        if (!string.IsNullOrEmpty(propertyName))
          propertyInfo = this._propertyItem.InstanceList[index].GetType().GetProperty(propertyName);
        T obj2 = (T) propertyInfo.GetValue(this._propertyItem.InstanceList[index], (object[]) null);
        if (Func != null)
        {
          if (!Func(obj1, obj2))
            return true;
        }
        else if (!obj1.Equals((object) obj2))
          return true;
      }
      return false;
    }

    protected void SetChildWidget(Widget widget, string propertyName)
    {
      if (!(propertyName == "IsTransformEnabled"))
        return;
      ITransform instance = this._propertyItem.Instance as ITransform;
      if (instance != null)
        widget.Sensitive = instance.IsTransformEnabled;
    }
  }
}
