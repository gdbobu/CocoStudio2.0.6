// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.DataItem
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.UndoManager;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
  [DataContract]
  public class DataItem : BaseObject
  {
    private bool IsNotify = true;
    private string _Type;
    private string _Key;
    private string _Name;
    private string _DefaultValue;
    private string _Data;
    private int _Min;
    private int _Max;
    private List<ChildItem> _Childes;
    private object _Value;
    private Guid _SID;
    private ChildItem _Selecte;
    private bool _IsShowToolTip;
    private string _OtherName;
    private string _ToolTipContent;

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

    public bool IsShowToolTip
    {
      get
      {
        return this._IsShowToolTip;
      }
      set
      {
        this._IsShowToolTip = value;
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.IsShowToolTip));
      }
    }

    public string ToolTipContent
    {
      get
      {
        return this._ToolTipContent;
      }
      set
      {
        this._ToolTipContent = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.ToolTipContent));
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
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Type));
      }
    }

    [DataMember(Name = "key")]
    public string Key
    {
      get
      {
        return this._Key;
      }
      set
      {
        this._Key = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Key));
      }
    }

    public new string Name
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

    public string DefaultValue
    {
      get
      {
        return this._DefaultValue;
      }
      set
      {
        this._DefaultValue = value;
        this.SetDefaultValue(this._DefaultValue);
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.DefaultValue));
      }
    }

    public string Data
    {
      get
      {
        return this._Data;
      }
      set
      {
        this._Data = value;
        this.RaisePropertyChanged<string>((Expression<Func<string>>) (() => this.Data));
      }
    }

    public int Min
    {
      get
      {
        return this._Min;
      }
      set
      {
        this._Min = value;
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Min));
      }
    }

    public int Max
    {
      get
      {
        return this._Max;
      }
      set
      {
        this._Max = value;
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Max));
      }
    }

    [UndoProperty]
    public List<ChildItem> Childes
    {
      get
      {
        return this._Childes;
      }
      set
      {
        this._Childes = value;
        this.RaisePropertyChanged<List<ChildItem>>((Expression<Func<List<ChildItem>>>) (() => this.Childes));
      }
    }

    [UndoProperty]
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
        if (!this.IsNotify)
          return;
        this.RaisePropertyChanged<object>((Expression<Func<object>>) (() => this.Value));
      }
    }

    public Guid SID
    {
      get
      {
        return this._SID;
      }
      set
      {
        this._SID = value;
      }
    }

    [UndoProperty]
    public ChildItem Selecte
    {
      get
      {
        return this._Selecte;
      }
      set
      {
        if (this._Selecte == value)
          return;
        this._Selecte = value;
        this.IsNotify = false;
        if (this._Selecte != null)
          this.Value = this._Selecte.SaveValue;
        this.IsNotify = true;
        this.RaisePropertyChanged<ChildItem>((Expression<Func<ChildItem>>) (() => this.Selecte));
      }
    }

    public new event PropertyChangedEventHandler PropertyChanged;

    public DataItem()
    {
      this.BindingRecorder("TriggerUndoAndRedo");
    }

    private void SetShowName()
    {
      if (LanguageOption.CurrentLanguage != LanguageType.Chinese || string.IsNullOrWhiteSpace(this.OtherName))
        return;
      this.Name = this.OtherName;
    }

    private void SetDefaultValue(string defaultValue)
    {
      if (this.Type == "IntegerUpDown")
      {
        int result = 0;
        int.TryParse(defaultValue, out result);
        this.Value = (object) result;
      }
      else if (this.Type == "DoubleUpDown")
      {
        double result = 0.0;
        double.TryParse(defaultValue, out result);
        this.Value = (object) result;
      }
      else
        this.Value = (object) defaultValue;
    }

    public override bool Equals(object obj)
    {
      DataItem dataItem = obj as DataItem;
      if (dataItem != null)
        return this.SID == dataItem.SID;
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return this.SID.GetHashCode();
    }
  }
}
