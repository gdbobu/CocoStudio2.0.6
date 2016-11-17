// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.BaseInfo
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Modules.Communal.MultiLanguage;
using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
  [DataContract]
  public class BaseInfo : BaseObject, ICloneable
  {
    private string _Name;
    private EIdentify _Identify;
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

    public override string Name
    {
      get
      {
        return this._Name;
      }
      set
      {
        if (!(this._Name != value))
          return;
        this._Name = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Name));
      }
    }

    public EIdentify Identify
    {
      get
      {
        bool flag = 0 == 0;
        return this._Identify;
      }
      set
      {
        if (this._Identify == value)
          return;
        this._Identify = value;
        this.RaisePropertyChanged<EIdentify>((Expression<Func<EIdentify>>) (() => this.Identify));
      }
    }

    private EIdentify GetIdentify()
    {
      if (this is EventModel)
        return EIdentify.Event;
      if (this is ConditionMode)
        return EIdentify.Condition;
      return this is ActionModel ? EIdentify.Action : EIdentify.None;
    }

    private void SetShowName()
    {
      if (LanguageOption.CurrentLanguage != LanguageType.Chinese || string.IsNullOrWhiteSpace(this.OtherName))
        return;
      this.Name = this.OtherName;
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
