// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.NotificationObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
  public abstract class NotificationObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(PropertyInfo propertyInfo)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyInfo.Name));
    }

    private void RaisePropertyChanged(params string[] propertyNames)
    {
      if (propertyNames == null)
        throw new ArgumentNullException("propertyNames");
      foreach (string propertyName in propertyNames)
        this.RaisePropertyChanged(new string[1]{ propertyName });
    }

    protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
    {
      this.RaisePropertyChanged(PropertySupport.ExtractPropertyInfo<T>(propertyExpression));
    }
  }
}
