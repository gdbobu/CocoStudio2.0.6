// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.BaseObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Editor;
using CocoStudio.UndoManager;
using CocoStudio.UndoManager.Recorder;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
  public abstract class BaseObject : NotificationObject, INotifyStateChanged, INotifyPropertyChanged
  {
    protected string name;

    [Browsable(false)]
    public bool IsRaiseStateChanged { get; set; }

    [Browsable(false)]
    public BaseRecorder Recorder { get; protected set; }

    [System.ComponentModel.DisplayName("Display_Name")]
    [Category("Group_Routine")]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (NameEditor), typeof (NameEditor))]
    public virtual string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Name));
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.DisplayName));
      }
    }

    [Browsable(false)]
    public virtual string DisplayName
    {
      get
      {
        if (!string.IsNullOrEmpty(this.Name))
          return this.Name;
        return "[Node]";
      }
    }

    public event EventHandler<StateChangedEventArgs> StateChanged;

    public BaseObject()
    {
      this.IsRaiseStateChanged = true;
    }

    public BaseObject(string name)
      : this()
    {
      this.name = name;
    }

    protected void RaisePropertyChanged(PropertyInfo propertyInfo, bool isNotifyStateChanged)
    {
      if (isNotifyStateChanged)
        this.RaiseStateChanged(propertyInfo.Name);
      this.RaisePropertyChanged(propertyInfo);
    }

    protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
    {
      this.RaisePropertyChanged<T>(propertyExpression, this.IsRaiseStateChanged);
    }

    protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, bool isNotifyStateChanged)
    {
      this.RaisePropertyChanged(PropertySupport.ExtractPropertyInfo<T>(propertyExpression), isNotifyStateChanged);
    }

    private void RaiseStateChanged(StateChangedEventArgs args)
    {
      if (this.StateChanged == null)
        return;
      this.StateChanged((object) this, args);
    }

    private void RaiseStateChanged(string propertyName)
    {
      this.RaiseStateChanged(new StateChangedEventArgs(propertyName));
    }

    public virtual void BindingRecorder(string taskGroupName = null)
    {
      if (this.Recorder != null || !BaseRecorder.IsCreateDefaultRecorder)
        return;
      this.Recorder = (BaseRecorder) new DefaultRecorder((INotifyStateChanged) this, taskGroupName);
    }
  }
}
