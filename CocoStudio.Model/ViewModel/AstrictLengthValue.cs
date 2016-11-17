// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.AstrictLengthValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.ViewModel
{
  public class AstrictLengthValue
  {
    private bool maxLengthEnable;
    private int maxLengthText;

    public bool MaxLengthEnable
    {
      get
      {
        return this.maxLengthEnable;
      }
      set
      {
        if (this.maxLengthEnable == value)
          return;
        this.maxLengthEnable = value;
      }
    }

    public int MaxLengthText
    {
      get
      {
        return this.maxLengthText;
      }
      set
      {
        if (this.maxLengthText == value)
          return;
        this.maxLengthText = value;
      }
    }

    public AstrictLengthValue(bool maxLengthEnable, int maxLengthText)
    {
      this.MaxLengthEnable = maxLengthEnable;
      this.MaxLengthText = maxLengthText;
    }

    public static bool operator ==(AstrictLengthValue leftValue, AstrictLengthValue rightValue)
    {
      if (object.ReferenceEquals((object) leftValue, (object) null))
        return object.ReferenceEquals((object) rightValue, (object) null);
      return leftValue.Equals(rightValue);
    }

    public static bool operator !=(AstrictLengthValue leftValue, AstrictLengthValue rightValue)
    {
      return !(leftValue == rightValue);
    }

    public bool Equals(AstrictLengthValue others)
    {
      return !(others == (AstrictLengthValue) null) && (this.MaxLengthEnable == others.MaxLengthEnable && this.MaxLengthText == others.MaxLengthText);
    }

    public override bool Equals(object obj)
    {
      if (obj is AstrictLengthValue)
        return this.Equals((AstrictLengthValue) obj);
      return false;
    }

    public override int GetHashCode()
    {
      return this.MaxLengthEnable.GetHashCode() ^ this.MaxLengthText.GetHashCode();
    }
  }
}
