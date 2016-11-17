// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.FilpValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Editor
{
  public class FilpValue
  {
    private bool filpX;
    private bool filpY;

    public bool FlipX
    {
      get
      {
        return this.filpX;
      }
      set
      {
        this.filpX = value;
      }
    }

    public bool FlipY
    {
      get
      {
        return this.filpY;
      }
      set
      {
        this.filpY = value;
      }
    }

    public FilpValue(bool filpX, bool filpY)
    {
      this.FlipX = filpX;
      this.FlipY = filpY;
    }

    public static bool operator ==(FilpValue leftValue, FilpValue rightValue)
    {
      if (object.ReferenceEquals((object) leftValue, (object) null))
        return object.ReferenceEquals((object) rightValue, (object) null);
      return leftValue.Equals(rightValue);
    }

    public static bool operator !=(FilpValue leftValue, FilpValue rightValue)
    {
      return !(leftValue == rightValue);
    }

    public bool Equals(FilpValue others)
    {
      return !(others == (FilpValue) null) && (this.FlipX == others.FlipX && this.FlipY == others.FlipY);
    }

    public override bool Equals(object obj)
    {
      if (obj is FilpValue)
        return this.Equals((FilpValue) obj);
      return false;
    }

    public override int GetHashCode()
    {
      return this.FlipX.GetHashCode() ^ this.FlipY.GetHashCode();
    }
  }
}
