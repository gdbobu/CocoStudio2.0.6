// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.EventModel
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
  [DataContract]
  public class EventModel : BaseInfo
  {
    private int _ID;
    private string _ClassName;

    [DataMember(Name = "id")]
    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.ID));
      }
    }

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

    public EventModel()
    {
      this.BindingRecorder("TriggerUndoAndRedo");
    }
  }
}
