// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ChildItem
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Modules.Communal.MultiLanguage;
using System;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public class ChildItem : NotificationObject
  {
    private string _Name;
    private int _ID;
    private object _SaveValue;
    private string _OtherName;

    public string OtherName
    {
      get
      {
        return this._OtherName;
      }
      set
      {
        if (!(this._Name != value))
          return;
        this._OtherName = value;
        this.SetShowName();
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.OtherName));
      }
    }

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

    public object SaveValue
    {
      get
      {
        return this._SaveValue;
      }
      set
      {
        this._SaveValue = value;
        this.RaisePropertyChanged<object>((Expression<Func<object>>) (() => this.SaveValue));
      }
    }

    private void SetShowName()
    {
      if (LanguageOption.CurrentLanguage != LanguageType.Chinese || string.IsNullOrWhiteSpace(this.OtherName))
        return;
      this.Name = this.OtherName;
    }
  }
}
