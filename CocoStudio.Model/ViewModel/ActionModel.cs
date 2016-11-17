// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ActionModel
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.UndoManager;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
  [DataContract]
  public class ActionModel : BaseInfo
  {
    private ObservableCollection<DataItem> _DataItems;
    private string _ClassName;

    [DataMember(Name = "classname")]
    public string ClassName
    {
      get
      {
        return this._ClassName;
      }
      set
      {
        this._ClassName = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.ClassName));
      }
    }

    [DataMember(Name = "dataitems")]
    [UndoProperty]
    public ObservableCollection<DataItem> DataItems
    {
      get
      {
        return this._DataItems;
      }
      set
      {
        this._DataItems = value;
        this.RaisePropertyChanged<ObservableCollection<DataItem>>((Expression<Func<ObservableCollection<DataItem>>>) (() => this.DataItems));
      }
    }

    public ActionModel()
    {
      this.BindingRecorder("TriggerUndoAndRedo");
    }
  }
}
