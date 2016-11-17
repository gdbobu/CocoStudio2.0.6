// Decompiled with JetBrains decompiler
// Type: Nuclex.Game.Packing.SimpleRectanglePacker
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System.Drawing;

namespace Nuclex.Game.Packing
{
  public class SimpleRectanglePacker : RectanglePacker
  {
    private int currentLine;
    private int lineHeight;
    private int column;

    public SimpleRectanglePacker(int packingAreaWidth, int packingAreaHeight)
      : base(packingAreaWidth, packingAreaHeight)
    {
    }

    public override bool TryPack(int rectangleWidth, int rectangleHeight, out Point placement)
    {
      if (rectangleWidth > this.PackingAreaWidth || rectangleHeight > this.PackingAreaHeight)
      {
        placement = Point.Empty;
        return false;
      }
      if (this.column + rectangleWidth > this.PackingAreaWidth)
      {
        this.currentLine += this.lineHeight;
        this.lineHeight = 0;
        this.column = 0;
      }
      if (this.currentLine + rectangleHeight > this.PackingAreaHeight)
      {
        placement = Point.Empty;
        return false;
      }
      placement = new Point(this.column, this.currentLine);
      this.column += rectangleWidth;
      if (rectangleHeight > this.lineHeight)
        this.lineHeight = rectangleHeight;
      return true;
    }
  }
}
