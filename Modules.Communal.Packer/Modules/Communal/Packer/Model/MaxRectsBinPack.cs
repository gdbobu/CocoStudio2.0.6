// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.Model.MaxRectsBinPack
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System;
using System.Collections.Generic;

namespace Modules.Communal.Packer.Model
{
  public class MaxRectsBinPack
  {
    public int binWidth = 0;
    public int binHeight = 0;
    public List<CustomRectangle> usedRectangles = new List<CustomRectangle>();
    public List<CustomRectangle> freeRectangles = new List<CustomRectangle>();
    public bool allowRotations;

    public int RightEdge { get; private set; }

    public int BottomEdge { get; private set; }

    public MaxRectsBinPack(int width, int height, bool rotations = true)
    {
      this.Init(width, height, rotations);
    }

    public void Init(int width, int height, bool rotations = true)
    {
      this.binWidth = width;
      this.binHeight = height;
      this.BottomEdge = this.RightEdge = 0;
      this.allowRotations = rotations;
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      customRectangle.X = 0;
      customRectangle.Y = 0;
      customRectangle.Width = width;
      customRectangle.Height = height;
      this.usedRectangles.Clear();
      this.freeRectangles.Clear();
      this.freeRectangles.Add(customRectangle);
    }

    public CustomRectangle Insert(int width, int height, MaxRectsBinPack.FreeRectChoiceHeuristic method)
    {
      CustomRectangle usedNode = new CustomRectangle((object) null);
      int num1 = 0;
      int num2 = 0;
      switch (method)
      {
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestShortSideFit:
          usedNode = this.FindPositionForNewNodeBestShortSideFit(width, height, ref num1, ref num2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestLongSideFit:
          usedNode = this.FindPositionForNewNodeBestLongSideFit(width, height, ref num2, ref num1);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestAreaFit:
          usedNode = this.FindPositionForNewNodeBestAreaFit(width, height, ref num1, ref num2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBottomLeftRule:
          usedNode = this.FindPositionForNewNodeBottomLeft(width, height, ref num1, ref num2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectContactPointRule:
          usedNode = this.FindPositionForNewNodeContactPoint(width, height, ref num1);
          break;
      }
      if (usedNode.Height == 0)
        return usedNode;
      int count = this.freeRectangles.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.SplitFreeNode(this.freeRectangles[index], ref usedNode))
        {
          this.freeRectangles.RemoveAt(index);
          --index;
          --count;
        }
      }
      this.PruneFreeList();
      this.usedRectangles.Add(usedNode);
      this.CaculateEdge(usedNode);
      return usedNode;
    }

    public void Insert(List<CustomRectangle> rects, List<CustomRectangle> dst, MaxRectsBinPack.FreeRectChoiceHeuristic method)
    {
      dst.Clear();
      while (rects.Count > 0)
      {
        int num1 = int.MaxValue;
        int num2 = int.MaxValue;
        int index1 = -1;
        CustomRectangle customRectangle1 = new CustomRectangle((object) null);
        for (int index2 = 0; index2 < rects.Count; ++index2)
        {
          int score1 = 0;
          int score2 = 0;
          CustomRectangle customRectangle2 = this.ScoreRect(rects[index2].Width, rects[index2].Height, method, ref score1, ref score2);
          if (score1 < num1 || score1 == num1 && score2 < num2)
          {
            num1 = score1;
            num2 = score2;
            customRectangle1 = customRectangle2;
            customRectangle1.UserData = rects[index2].UserData;
            customRectangle1.Rotated = customRectangle2.Rotated;
            index1 = index2;
          }
        }
        if (index1 == -1)
          break;
        this.PlaceRect(customRectangle1);
        this.CaculateEdge(customRectangle1);
        rects.RemoveAt(index1);
      }
    }

    private void PlaceRect(CustomRectangle node)
    {
      int count = this.freeRectangles.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.SplitFreeNode(this.freeRectangles[index], ref node))
        {
          this.freeRectangles.RemoveAt(index);
          --index;
          --count;
        }
      }
      this.PruneFreeList();
      this.usedRectangles.Add(node);
    }

    private CustomRectangle ScoreRect(int width, int height, MaxRectsBinPack.FreeRectChoiceHeuristic method, ref int score1, ref int score2)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      score1 = int.MaxValue;
      score2 = int.MaxValue;
      switch (method)
      {
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestShortSideFit:
          customRectangle = this.FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestLongSideFit:
          customRectangle = this.FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestAreaFit:
          customRectangle = this.FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectBottomLeftRule:
          customRectangle = this.FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2);
          break;
        case MaxRectsBinPack.FreeRectChoiceHeuristic.RectContactPointRule:
          customRectangle = this.FindPositionForNewNodeContactPoint(width, height, ref score1);
          score1 = -score1;
          break;
      }
      if (customRectangle.Height == 0)
      {
        score1 = int.MaxValue;
        score2 = int.MaxValue;
      }
      return customRectangle;
    }

    public float Occupancy()
    {
      ulong num = 0;
      for (int index = 0; index < this.usedRectangles.Count; ++index)
        num += (ulong) (uint) (this.usedRectangles[index].Width * this.usedRectangles[index].Height);
      return (float) num / (float) (this.binWidth * this.binHeight);
    }

    private CustomRectangle FindPositionForNewNodeBottomLeft(int width, int height, ref int bestY, ref int bestX)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      bestY = int.MaxValue;
      for (int index = 0; index < this.freeRectangles.Count; ++index)
      {
        if (this.freeRectangles[index].Width >= width && this.freeRectangles[index].Height >= height)
        {
          int num = this.freeRectangles[index].Y + height;
          if (num < bestY || num == bestY && this.freeRectangles[index].X < bestX)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = width;
            customRectangle.Height = height;
            bestY = num;
            bestX = this.freeRectangles[index].X;
          }
        }
        if (this.allowRotations && this.freeRectangles[index].Width >= height && this.freeRectangles[index].Height >= width)
        {
          int num = this.freeRectangles[index].Y + width;
          if (num < bestY || num == bestY && this.freeRectangles[index].X < bestX)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = height;
            customRectangle.Height = width;
            bestY = num;
            bestX = this.freeRectangles[index].X;
          }
        }
      }
      return customRectangle;
    }

    private CustomRectangle FindPositionForNewNodeBestShortSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      bestShortSideFit = int.MaxValue;
      for (int index = 0; index < this.freeRectangles.Count; ++index)
      {
        if (this.freeRectangles[index].Width >= width && this.freeRectangles[index].Height >= height)
        {
          int val1 = Math.Abs(this.freeRectangles[index].Width - width);
          int val2 = Math.Abs(this.freeRectangles[index].Height - height);
          int num1 = Math.Min(val1, val2);
          int num2 = Math.Max(val1, val2);
          if (num1 < bestShortSideFit || num1 == bestShortSideFit && num2 < bestLongSideFit)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = width;
            customRectangle.Height = height;
            bestShortSideFit = num1;
            bestLongSideFit = num2;
          }
        }
        if (this.allowRotations && this.freeRectangles[index].Width >= height && this.freeRectangles[index].Height >= width)
        {
          int val1 = Math.Abs(this.freeRectangles[index].Width - height);
          int val2 = Math.Abs(this.freeRectangles[index].Height - width);
          int num1 = Math.Min(val1, val2);
          int num2 = Math.Max(val1, val2);
          if (num1 < bestShortSideFit || num1 == bestShortSideFit && num2 < bestLongSideFit)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = height;
            customRectangle.Height = width;
            bestShortSideFit = num1;
            bestLongSideFit = num2;
          }
        }
      }
      return customRectangle;
    }

    private CustomRectangle FindPositionForNewNodeBestLongSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      bestLongSideFit = int.MaxValue;
      for (int index = 0; index < this.freeRectangles.Count; ++index)
      {
        if (this.freeRectangles[index].Width >= width && this.freeRectangles[index].Height >= height)
        {
          int val1 = Math.Abs(this.freeRectangles[index].Width - width);
          int val2 = Math.Abs(this.freeRectangles[index].Height - height);
          int num1 = Math.Min(val1, val2);
          int num2 = Math.Max(val1, val2);
          if (num2 < bestLongSideFit || num2 == bestLongSideFit && num1 < bestShortSideFit)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = width;
            customRectangle.Height = height;
            bestShortSideFit = num1;
            bestLongSideFit = num2;
          }
        }
        if (this.allowRotations && this.freeRectangles[index].Width >= height && this.freeRectangles[index].Height >= width)
        {
          int val1 = Math.Abs(this.freeRectangles[index].Width - height);
          int val2 = Math.Abs(this.freeRectangles[index].Height - width);
          int num1 = Math.Min(val1, val2);
          int num2 = Math.Max(val1, val2);
          if (num2 < bestLongSideFit || num2 == bestLongSideFit && num1 < bestShortSideFit)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = height;
            customRectangle.Height = width;
            bestShortSideFit = num1;
            bestLongSideFit = num2;
          }
        }
      }
      return customRectangle;
    }

    private CustomRectangle FindPositionForNewNodeBestAreaFit(int width, int height, ref int bestAreaFit, ref int bestShortSideFit)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      bestAreaFit = int.MaxValue;
      for (int index = 0; index < this.freeRectangles.Count; ++index)
      {
        int num1 = this.freeRectangles[index].Width * this.freeRectangles[index].Height - width * height;
        if (this.freeRectangles[index].Width >= width && this.freeRectangles[index].Height >= height)
        {
          int num2 = Math.Min(Math.Abs(this.freeRectangles[index].Width - width), Math.Abs(this.freeRectangles[index].Height - height));
          if (num1 < bestAreaFit || num1 == bestAreaFit && num2 < bestShortSideFit)
          {
            customRectangle.Rotated = false;
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = width;
            customRectangle.Height = height;
            bestShortSideFit = num2;
            bestAreaFit = num1;
          }
        }
        if (this.allowRotations && this.freeRectangles[index].Width >= height && this.freeRectangles[index].Height >= width)
        {
          int num2 = Math.Min(Math.Abs(this.freeRectangles[index].Width - height), Math.Abs(this.freeRectangles[index].Height - width));
          if (num1 < bestAreaFit || num1 == bestAreaFit && num2 < bestShortSideFit)
          {
            customRectangle.Rotated = true;
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = height;
            customRectangle.Height = width;
            bestShortSideFit = num2;
            bestAreaFit = num1;
          }
        }
      }
      return customRectangle;
    }

    private int CommonIntervalLength(int i1start, int i1end, int i2start, int i2end)
    {
      if (i1end < i2start || i2end < i1start)
        return 0;
      return Math.Min(i1end, i2end) - Math.Max(i1start, i2start);
    }

    private int ContactPointScoreNode(int x, int y, int width, int height)
    {
      int num = 0;
      if (x == 0 || x + width == this.binWidth)
        num += height;
      if (y == 0 || y + height == this.binHeight)
        num += width;
      for (int index = 0; index < this.usedRectangles.Count; ++index)
      {
        if (this.usedRectangles[index].X == x + width || this.usedRectangles[index].X + this.usedRectangles[index].Width == x)
          num += this.CommonIntervalLength(this.usedRectangles[index].Y, this.usedRectangles[index].Y + this.usedRectangles[index].Height, y, y + height);
        if (this.usedRectangles[index].Y == y + height || this.usedRectangles[index].Y + this.usedRectangles[index].Height == y)
          num += this.CommonIntervalLength(this.usedRectangles[index].X, this.usedRectangles[index].X + this.usedRectangles[index].Width, x, x + width);
      }
      return num;
    }

    private CustomRectangle FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore)
    {
      CustomRectangle customRectangle = new CustomRectangle((object) null);
      bestContactScore = -1;
      for (int index = 0; index < this.freeRectangles.Count; ++index)
      {
        if (this.freeRectangles[index].Width >= width && this.freeRectangles[index].Height >= height)
        {
          int num = this.ContactPointScoreNode(this.freeRectangles[index].X, this.freeRectangles[index].Y, width, height);
          if (num > bestContactScore)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = width;
            customRectangle.Height = height;
            bestContactScore = num;
          }
        }
        if (this.allowRotations && this.freeRectangles[index].Width >= height && this.freeRectangles[index].Height >= width)
        {
          int num = this.ContactPointScoreNode(this.freeRectangles[index].X, this.freeRectangles[index].Y, height, width);
          if (num > bestContactScore)
          {
            customRectangle.X = this.freeRectangles[index].X;
            customRectangle.Y = this.freeRectangles[index].Y;
            customRectangle.Width = height;
            customRectangle.Height = width;
            bestContactScore = num;
          }
        }
      }
      return customRectangle;
    }

    private bool SplitFreeNode(CustomRectangle freeNode, ref CustomRectangle usedNode)
    {
      if (usedNode.X >= freeNode.X + freeNode.Width || usedNode.X + usedNode.Width <= freeNode.X || usedNode.Y >= freeNode.Y + freeNode.Height || usedNode.Y + usedNode.Height <= freeNode.Y)
        return false;
      if (usedNode.X < freeNode.X + freeNode.Width && usedNode.X + usedNode.Width > freeNode.X)
      {
        if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Y + freeNode.Height)
        {
          CustomRectangle customRectangle = freeNode.Copy();
          customRectangle.Height = usedNode.Y - customRectangle.Y;
          this.freeRectangles.Add(customRectangle);
        }
        if (usedNode.Y + usedNode.Height < freeNode.Y + freeNode.Height)
        {
          CustomRectangle customRectangle = freeNode.Copy();
          customRectangle.Y = usedNode.Y + usedNode.Height;
          customRectangle.Height = freeNode.Y + freeNode.Height - (usedNode.Y + usedNode.Height);
          this.freeRectangles.Add(customRectangle);
        }
      }
      if (usedNode.Y < freeNode.Y + freeNode.Height && usedNode.Y + usedNode.Height > freeNode.Y)
      {
        if (usedNode.X > freeNode.X && usedNode.X < freeNode.X + freeNode.Width)
        {
          CustomRectangle customRectangle = freeNode.Copy();
          customRectangle.Width = usedNode.X - customRectangle.X;
          this.freeRectangles.Add(customRectangle);
        }
        if (usedNode.X + usedNode.Width < freeNode.X + freeNode.Width)
        {
          CustomRectangle customRectangle = freeNode.Copy();
          customRectangle.X = usedNode.X + usedNode.Width;
          customRectangle.Width = freeNode.X + freeNode.Width - (usedNode.X + usedNode.Width);
          this.freeRectangles.Add(customRectangle);
        }
      }
      return true;
    }

    private void PruneFreeList()
    {
      for (int index1 = 0; index1 < this.freeRectangles.Count; ++index1)
      {
        for (int index2 = index1 + 1; index2 < this.freeRectangles.Count; ++index2)
        {
          if (this.IsContainedIn(this.freeRectangles[index1], this.freeRectangles[index2]))
          {
            this.freeRectangles.RemoveAt(index1);
            --index1;
            break;
          }
          if (this.IsContainedIn(this.freeRectangles[index2], this.freeRectangles[index1]))
          {
            this.freeRectangles.RemoveAt(index2);
            --index2;
          }
        }
      }
    }

    private bool IsContainedIn(CustomRectangle a, CustomRectangle b)
    {
      return a.X >= b.X && a.Y >= b.Y && a.X + a.Width <= b.X + b.Width && a.Y + a.Height <= b.Y + b.Height;
    }

    private void CaculateEdge(CustomRectangle latestnode)
    {
      if (latestnode.Right > this.RightEdge)
        this.RightEdge = latestnode.Right;
      if (latestnode.Bottom <= this.BottomEdge)
        return;
      this.BottomEdge = latestnode.Bottom;
    }

    public enum FreeRectChoiceHeuristic
    {
      RectBestShortSideFit,
      RectBestLongSideFit,
      RectBestAreaFit,
      RectBottomLeftRule,
      RectContactPointRule,
    }
  }
}
