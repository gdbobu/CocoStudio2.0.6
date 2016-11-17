// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ColorValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
  public struct ColorValue
  {
    private int comboBoxIndex;
    private Color singleColor;
    private Color firstColor;
    private Color endColor;
    private float vectorX;
    private float vectorY;

    public int ComboBoxIndex
    {
      get
      {
        return this.comboBoxIndex;
      }
      set
      {
        if (this.comboBoxIndex == value)
          return;
        this.comboBoxIndex = value;
      }
    }

    public Color SingleColor
    {
      get
      {
        return this.singleColor;
      }
      set
      {
        if (this.singleColor == value)
          return;
        this.singleColor = value;
      }
    }

    public Color FirstColor
    {
      get
      {
        return this.firstColor;
      }
      set
      {
        if (this.firstColor == value)
          return;
        this.firstColor = value;
      }
    }

    public Color EndColor
    {
      get
      {
        return this.endColor;
      }
      set
      {
        if (this.endColor == value)
          return;
        this.endColor = value;
      }
    }

    public float VectorX
    {
      get
      {
        return this.vectorX;
      }
      set
      {
        if ((double) this.vectorX == (double) value)
          return;
        this.vectorX = value;
      }
    }

    public float VectorY
    {
      get
      {
        return this.vectorY;
      }
      set
      {
        if ((double) this.vectorY == (double) value)
          return;
        this.vectorY = value;
      }
    }

    public ColorValue(int comboBoxIndex, Color singleColor, Color firstColor, Color endColor, float VectorX, float VectorY)
    {
      this = new ColorValue();
      this.ComboBoxIndex = comboBoxIndex;
      this.SingleColor = singleColor;
      this.FirstColor = firstColor;
      this.EndColor = endColor;
      this.VectorX = VectorX;
      this.VectorY = VectorY;
    }

    public ColorValue(Color singleColor)
    {
      this = new ColorValue();
      this.SingleColor = singleColor;
    }

    public ColorValue(Color firstColor, Color endColor)
    {
      this = new ColorValue();
      this.FirstColor = firstColor;
      this.EndColor = endColor;
    }

    public bool Equal(ColorValue vColor)
    {
      return this.ComboBoxIndex == vColor.ComboBoxIndex && this.SingleColor == vColor.SingleColor && (this.FirstColor == vColor.FirstColor && this.EndColor == vColor.EndColor) && (double) this.VectorX == (double) vColor.VectorX && (double) this.VectorY == (double) vColor.VectorY;
    }
  }
}
