// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.CustomPropertyModel
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CocoStudio.Model.Editor
{
  [DataContract]
  public class CustomPropertyModel : NotificationObject
  {
    private string _Name;
    private string _Type;
    private object _Value;

    [DataMember(Name = "key")]
    public string Name
    {
      get
      {
        return this._Name;
      }
      set
      {
        this._Name = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Name));
      }
    }

    public string Type
    {
      get
      {
        return this._Type;
      }
      set
      {
        this._Type = value;
        if (this.Value == null || this.Value == (object) "")
          this.SetDefuleValue(value);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Type));
      }
    }

    [DataMember(Name = "value")]
    public object Value
    {
      get
      {
        return this._Value;
      }
      set
      {
        this._Value = value;
        this.RaisePropertyChanged<object>((Expression<Func<object>>) (() => this.Value));
      }
    }

    private void SetDefuleValue(string typeString)
    {
      if (typeString == "Double")
        this.Value = (object) 0.0;
      else if (typeString == "Int")
      {
        this.Value = (object) 0;
      }
      else
      {
        if (!(typeString == "Boolean"))
          return;
        this.Value = (object) false;
      }
    }
  }
}
