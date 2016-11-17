// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PasswordValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.ViewModel
{
  public class PasswordValue
  {
    private bool passwordEnable;
    private string passwordStyleText;

    public bool PasswordEnable
    {
      get
      {
        return this.passwordEnable;
      }
      set
      {
        if (this.passwordEnable == value)
          return;
        this.passwordEnable = value;
      }
    }

    public string PasswordStyleText
    {
      get
      {
        return this.passwordStyleText;
      }
      set
      {
        if (this.passwordStyleText == value)
          return;
        this.passwordStyleText = value;
      }
    }

    public PasswordValue(bool passwordEnable, string passwordStyleText)
    {
      this.PasswordEnable = passwordEnable;
      this.PasswordStyleText = passwordStyleText;
    }

    public static bool operator ==(PasswordValue leftValue, PasswordValue rightValue)
    {
      if (object.ReferenceEquals((object) leftValue, (object) null))
        return object.ReferenceEquals((object) rightValue, (object) null);
      return leftValue.Equals(rightValue);
    }

    public static bool operator !=(PasswordValue leftValue, PasswordValue rightValue)
    {
      return !(leftValue == rightValue);
    }

    public bool Equals(PasswordValue others)
    {
      return !(others == (PasswordValue) null) && (this.PasswordEnable == others.PasswordEnable && this.PasswordStyleText == others.PasswordStyleText);
    }

    public override bool Equals(object obj)
    {
      if (obj is PasswordValue)
        return this.Equals((PasswordValue) obj);
      return false;
    }

    public override int GetHashCode()
    {
      return this.PasswordEnable.GetHashCode() ^ this.PasswordStyleText.GetHashCode();
    }
  }
}
