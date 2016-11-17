// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.CheckBoxValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Editor
{
  public class CheckBoxValue
  {
    private bool isChecked;
    private bool isEnabled;

    public bool IsChecked
    {
      get
      {
        return this.isChecked;
      }
      set
      {
        if (this.isChecked == value)
          return;
        this.isChecked = value;
      }
    }

    public bool CanEnabled
    {
      get
      {
        return this.isEnabled;
      }
      set
      {
        if (this.isEnabled == value)
          return;
        this.isEnabled = value;
      }
    }

    public CheckBoxValue(bool isChecked, bool isEnabled)
    {
      this.IsChecked = isChecked;
      this.CanEnabled = isEnabled;
    }

    public static bool operator ==(CheckBoxValue leftValue, CheckBoxValue rightValue)
    {
      if (object.ReferenceEquals((object) leftValue, (object) null))
        return object.ReferenceEquals((object) rightValue, (object) null);
      return leftValue.Equals(rightValue);
    }

    public static bool operator !=(CheckBoxValue leftValue, CheckBoxValue rightValue)
    {
      return !(leftValue == rightValue);
    }

    public bool Equals(CheckBoxValue others)
    {
      return !(others == (CheckBoxValue) null) && (this.IsChecked == others.IsChecked && this.CanEnabled == others.CanEnabled);
    }

    public override bool Equals(object obj)
    {
      if (obj is CheckBoxValue)
        return this.Equals((CheckBoxValue) obj);
      return false;
    }

    public override int GetHashCode()
    {
      return this.IsChecked.GetHashCode() ^ this.CanEnabled.GetHashCode();
    }
  }
}
