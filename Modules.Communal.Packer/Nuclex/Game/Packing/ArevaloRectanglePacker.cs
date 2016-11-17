// Decompiled with JetBrains decompiler
// Type: Nuclex.Game.Packing.ArevaloRectanglePacker
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nuclex.Game.Packing
{
    public class ArevaloRectanglePacker : RectanglePacker
    {
        private class AnchorRankComparer : IComparer<Point>
        {
            public static ArevaloRectanglePacker.AnchorRankComparer Default = new ArevaloRectanglePacker.AnchorRankComparer();

            public int Compare(Point left, Point right)
            {
                return left.X + left.Y - (right.X + right.Y);
            }
        }

        private int actualPackingAreaWidth;

        private int actualPackingAreaHeight;

        private List<Rectangle> packedRectangles;

        private List<Point> anchors;

        public ArevaloRectanglePacker(int packingAreaWidth, int packingAreaHeight)
            : base(packingAreaWidth, packingAreaHeight)
        {
            this.packedRectangles = new List<Rectangle>();
            this.anchors = new List<Point>();
            this.anchors.Add(new Point(0, 0));
            this.actualPackingAreaWidth = 1;
            this.actualPackingAreaHeight = 1;
        }

        public override bool TryPack(int rectangleWidth, int rectangleHeight, out Point placement)
        {
            int num = this.selectAnchorRecursive(rectangleWidth, rectangleHeight, this.actualPackingAreaWidth, this.actualPackingAreaHeight);
            bool result;
            if (num == -1)
            {
                placement = Point.Empty;
                result = false;
            }
            else
            {
                placement = this.anchors[num];
                this.optimizePlacement(ref placement, rectangleWidth, rectangleHeight);
                bool flag = placement.X + rectangleWidth > this.anchors[num].X && placement.Y + rectangleHeight > this.anchors[num].Y;
                if (flag)
                {
                    this.anchors.RemoveAt(num);
                }
                this.insertAnchor(new Point(placement.X + rectangleWidth, placement.Y));
                this.insertAnchor(new Point(placement.X, placement.Y + rectangleHeight));
                this.packedRectangles.Add(new Rectangle(placement.X, placement.Y, rectangleWidth, rectangleHeight));
                result = true;
            }
            return result;
        }

        private void optimizePlacement(ref Point placement, int rectangleWidth, int rectangleHeight)
        {
            Rectangle rectangle = new Rectangle(placement.X, placement.Y, rectangleWidth, rectangleHeight);
            int x = placement.X;
            while (this.isFree(ref rectangle, base.PackingAreaWidth, base.PackingAreaHeight))
            {
                x = rectangle.X;
                rectangle.X--;
            }
            rectangle.X = placement.X;
            int y = placement.Y;
            while (this.isFree(ref rectangle, base.PackingAreaWidth, base.PackingAreaHeight))
            {
                y = rectangle.Y;
                rectangle.Y--;
            }
            if (placement.X - x > placement.Y - y)
            {
                placement.X = x;
            }
            else
            {
                placement.Y = y;
            }
        }

        private int selectAnchorRecursive(int rectangleWidth, int rectangleHeight, int testedPackingAreaWidth, int testedPackingAreaHeight)
        {
            int num = this.findFirstFreeAnchor(rectangleWidth, rectangleHeight, testedPackingAreaWidth, testedPackingAreaHeight);
            int result;
            if (num != -1)
            {
                this.actualPackingAreaWidth = testedPackingAreaWidth;
                this.actualPackingAreaHeight = testedPackingAreaHeight;
                result = num;
            }
            else
            {
                bool flag = testedPackingAreaWidth < base.PackingAreaWidth;
                bool flag2 = testedPackingAreaHeight < base.PackingAreaHeight;
                bool flag3 = !flag || testedPackingAreaHeight < testedPackingAreaWidth;
                if (flag2 && flag3)
                {
                    result = this.selectAnchorRecursive(rectangleWidth, rectangleHeight, testedPackingAreaWidth, Math.Min(testedPackingAreaHeight * 2, base.PackingAreaHeight));
                }
                else if (flag)
                {
                    result = this.selectAnchorRecursive(rectangleWidth, rectangleHeight, Math.Min(testedPackingAreaWidth * 2, base.PackingAreaWidth), testedPackingAreaHeight);
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }

        private int findFirstFreeAnchor(int rectangleWidth, int rectangleHeight, int testedPackingAreaWidth, int testedPackingAreaHeight)
        {
            Rectangle rectangle = new Rectangle(0, 0, rectangleWidth, rectangleHeight);
            int result;
            for (int i = 0; i < this.anchors.Count; i++)
            {
                rectangle.X = this.anchors[i].X;
                rectangle.Y = this.anchors[i].Y;
                if (this.isFree(ref rectangle, testedPackingAreaWidth, testedPackingAreaHeight))
                {
                    result = i;
                    return result;
                }
            }
            result = -1;
            return result;
        }

        private bool isFree(ref Rectangle rectangle, int testedPackingAreaWidth, int testedPackingAreaHeight)
        {
            bool flag = rectangle.X < 0 || rectangle.Y < 0 || rectangle.Right > testedPackingAreaWidth || rectangle.Bottom > testedPackingAreaHeight;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < this.packedRectangles.Count; i++)
                {
                    if (this.packedRectangles[i].IntersectsWith(rectangle))
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }

        private void insertAnchor(Point anchor)
        {
            int num = this.anchors.BinarySearch(anchor, ArevaloRectanglePacker.AnchorRankComparer.Default);
            if (num < 0)
            {
                num = ~num;
            }
            this.anchors.Insert(num, anchor);
        }
    }

}
