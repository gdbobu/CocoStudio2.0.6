// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.EasingData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using Gdk;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel
{
  public class EasingData
  {
    private TweenType tweenType = TweenType.Custom;
    private List<Point> proportionPoints;

    public TweenType TweenType
    {
      get
      {
        return this.tweenType;
      }
      set
      {
        this.tweenType = value;
      }
    }

    public List<Point> ProportionPoints
    {
      get
      {
        return this.proportionPoints;
      }
      set
      {
        this.proportionPoints = value;
      }
    }

    public EasingData(TweenType tweentype)
    {
      this.tweenType = tweentype;
      this.ProportionPoints = new List<Point>();
    }

    public EasingData(TweenType tweentype, params Point[] points)
      : this(tweentype)
    {
      this.ProportionPoints.AddRange((IEnumerable<Point>) points);
    }

    public static implicit operator CSVectorFloat(EasingData easingparma)
    {
      CSVectorFloat retParma = new CSVectorFloat();
      if (easingparma != null && easingparma.ProportionPoints != null)
      {
        if (easingparma.TweenType == TweenType.Custom)
          easingparma.ProportionPoints.ForEach((Action<Point>) (point => retParma.AddRange(new CSVectorFloat()
          {
            (float) point.X,
            (float) point.Y
          })));
        else
          easingparma.ProportionPoints.ForEach((Action<Point>) (point => retParma.AddRange(new CSVectorFloat()
          {
            (float) point.X
          })));
      }
      return retParma;
    }

    public static implicit operator List<float>(EasingData easingparma)
    {
      List<float> retParma = new List<float>();
      if (easingparma != null && easingparma.ProportionPoints != null)
      {
        if (easingparma.TweenType == TweenType.Custom)
          easingparma.ProportionPoints.ForEach((Action<Point>) (point => retParma.AddRange((IEnumerable<float>) new CSVectorFloat()
          {
            (float) point.X,
            (float) point.Y
          })));
        else
          easingparma.ProportionPoints.ForEach((Action<Point>) (point => retParma.AddRange((IEnumerable<float>) new CSVectorFloat()
          {
            (float) point.X
          })));
      }
      return retParma;
    }

    public static EasingData CreatEasingData(TweenType tweenType, CSVectorFloat easingparma)
    {
      EasingData easingData = new EasingData(tweenType);
      if (easingparma != null)
      {
        if (tweenType == TweenType.Custom)
        {
          int count = easingparma.Count;
          if (count == 8)
          {
            int index = 0;
            while (index < count)
            {
              easingData.ProportionPoints.Add(new Point((int) easingparma[index], (int) easingparma[index + 1]));
              index += 2;
            }
          }
        }
        else
        {
          int count = easingparma.Count;
          for (int index = 0; index < count; ++index)
            easingData.ProportionPoints.Add(new Point((int) easingparma[index], 0));
        }
      }
      return easingData;
    }

    public static EasingData CreatEasingData(TweenType tweenType, List<float> easingparma)
    {
      EasingData easingData = new EasingData(tweenType);
      if (easingparma != null)
      {
        if (tweenType == TweenType.Custom)
        {
          int count = easingparma.Count;
          if (count == 8)
          {
            int index = 0;
            while (index < count)
            {
              easingData.ProportionPoints.Add(new Point((int) easingparma[index], (int) easingparma[index + 1]));
              index += 2;
            }
          }
        }
        else
        {
          int count = easingparma.Count;
          for (int index = 0; index < count; ++index)
            easingData.ProportionPoints.Add(new Point((int) easingparma[index], 0));
        }
      }
      return easingData;
    }

    public override int GetHashCode()
    {
      if (this.ProportionPoints == null || this.ProportionPoints.Count != 4)
        return this.ProportionPoints.GetHashCode();
      Point proportionPoint = this.ProportionPoints[0];
      int hashCode1 = proportionPoint.GetHashCode();
      proportionPoint = this.ProportionPoints[1];
      int hashCode2 = proportionPoint.GetHashCode();
      int num1 = hashCode1 ^ hashCode2;
      proportionPoint = this.ProportionPoints[2];
      int hashCode3 = proportionPoint.GetHashCode();
      int num2 = num1 ^ hashCode3;
      proportionPoint = this.ProportionPoints[3];
      int hashCode4 = proportionPoint.GetHashCode();
      return num2 ^ hashCode4;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is EasingData)
      {
        EasingData easingData = obj as EasingData;
        if (easingData != null && easingData.ProportionPoints != null && (easingData.ProportionPoints.Count == 4 && this.ProportionPoints != null) && this.ProportionPoints.Count == 4)
          return this.ProportionPoints[0].Equals((object) easingData.ProportionPoints[0]) && this.ProportionPoints[1].Equals((object) easingData.ProportionPoints[1]) && this.ProportionPoints[2].Equals((object) easingData.ProportionPoints[2]) && this.ProportionPoints[3].Equals((object) easingData.ProportionPoints[3]);
      }
      return flag;
    }
  }
}
