// Decompiled with JetBrains decompiler
// Type: Nuclex.Game.Packing.CygonRectanglePacker
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System.Collections.Generic;
using System.Drawing;

namespace Nuclex.Game.Packing
{
  public class CygonRectanglePacker : RectanglePacker
  {
    private List<Point> heightSlices;

    public CygonRectanglePacker(int packingAreaWidth, int packingAreaHeight)
      : base(packingAreaWidth, packingAreaHeight)
    {
      this.heightSlices = new List<Point>();
      this.heightSlices.Add(new Point(0, 0));
    }

    public override bool TryPack(int rectangleWidth, int rectangleHeight, out Point placement)
    {
      if (rectangleWidth > this.PackingAreaWidth || rectangleHeight > this.PackingAreaHeight)
      {
        placement = Point.Empty;
        return false;
      }
      bool bestPlacement = this.tryFindBestPlacement(rectangleWidth, rectangleHeight, out placement);
      if (bestPlacement)
        this.integrateRectangle(placement.X, rectangleWidth, placement.Y + rectangleHeight);
      return bestPlacement;
    }

    private bool tryFindBestPlacement(int rectangleWidth, int rectangleHeight, out Point placement)
    {
      int index1 = -1;
      int y1 = 0;
      int num1 = this.PackingAreaHeight;
      int index2 = 0;
      int index3 = this.heightSlices.BinarySearch(new Point(rectangleWidth, 0), (IComparer<Point>) CygonRectanglePacker.SliceStartComparer.Default);
      if (index3 < 0)
        index3 = ~index3;
      while (index3 <= this.heightSlices.Count)
      {
        int y2 = this.heightSlices[index2].Y;
        for (int index4 = index2 + 1; index4 < index3; ++index4)
        {
          if (this.heightSlices[index4].Y > y2)
            y2 = this.heightSlices[index4].Y;
        }
        if (y2 + rectangleHeight <= this.PackingAreaHeight)
        {
          int num2 = y2;
          if (num2 < num1)
          {
            index1 = index2;
            y1 = y2;
            num1 = num2;
          }
        }
        ++index2;
        if (index2 < this.heightSlices.Count)
        {
          int num2 = this.heightSlices[index2].X + rectangleWidth;
          while (index3 <= this.heightSlices.Count && (index3 != this.heightSlices.Count ? this.heightSlices[index3].X : this.PackingAreaWidth) <= num2)
            ++index3;
          if (index3 > this.heightSlices.Count)
            break;
        }
        else
          break;
      }
      if (index1 == -1)
      {
        placement = Point.Empty;
        return false;
      }
      placement = new Point(this.heightSlices[index1].X, y1);
      return true;
    }

    private void integrateRectangle(int left, int width, int bottom)
    {
      int index1 = this.heightSlices.BinarySearch(new Point(left, 0), (IComparer<Point>) CygonRectanglePacker.SliceStartComparer.Default);
      int y1 = this.heightSlices[index1].Y;
      this.heightSlices[index1] = new Point(left, bottom);
      int x = left + width;
      int index2 = index1 + 1;
      if (index2 >= this.heightSlices.Count)
      {
        if (x >= this.PackingAreaWidth)
          return;
        this.heightSlices.Add(new Point(x, y1));
      }
      else
      {
        int num1 = this.heightSlices.BinarySearch(index2, this.heightSlices.Count - index2, new Point(x, 0), (IComparer<Point>) CygonRectanglePacker.SliceStartComparer.Default);
        if (num1 > 0)
        {
          this.heightSlices.RemoveRange(index2, num1 - index2);
        }
        else
        {
          int num2 = ~num1;
          int y2 = num2 != index2 ? this.heightSlices[num2 - 1].Y : y1;
          this.heightSlices.RemoveRange(index2, num2 - index2);
          if (x < this.PackingAreaWidth)
            this.heightSlices.Insert(index2, new Point(x, y2));
        }
      }
    }

    private class SliceStartComparer : IComparer<Point>
    {
      public static CygonRectanglePacker.SliceStartComparer Default = new CygonRectanglePacker.SliceStartComparer();

      public int Compare(Point left, Point right)
      {
        return left.X - right.X;
      }
    }
  }
}
