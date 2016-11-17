// Decompiled with JetBrains decompiler
// Type: Jisons.EventButtonHelper
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using System;

namespace Jisons
{
  public static class EventButtonHelper
  {
    private static uint? firstClickTime = new uint?();
    private static double x = -1.0;
    private static double y = -1.0;

    public static bool IsDoubleClick(this EventButton eventbutton, uint buttontype = 1)
    {
      bool flag = false;
      if ((int) eventbutton.Button == (int) buttontype)
      {
        if (!EventButtonHelper.firstClickTime.HasValue)
        {
          EventButtonHelper.firstClickTime = new uint?(eventbutton.Time);
          EventButtonHelper.x = eventbutton.X;
          EventButtonHelper.y = eventbutton.Y;
        }
        else
        {
          uint time = eventbutton.Time;
          uint num = time;
          uint? firstClickTime = EventButtonHelper.firstClickTime;
          uint? nullable = firstClickTime.HasValue ? new uint?(num - firstClickTime.GetValueOrDefault()) : new uint?();
          if ((nullable.GetValueOrDefault() >= 1000U ? 0 : (nullable.HasValue ? 1 : 0)) != 0 && Math.Abs(eventbutton.X - EventButtonHelper.x) < 0.3 && Math.Abs(eventbutton.Y - EventButtonHelper.y) < 0.3)
          {
            flag = true;
            EventButtonHelper.firstClickTime = new uint?();
          }
          else
          {
            EventButtonHelper.firstClickTime = new uint?(time);
            EventButtonHelper.x = eventbutton.X;
            EventButtonHelper.y = eventbutton.Y;
          }
        }
      }
      else
        EventButtonHelper.firstClickTime = new uint?();
      return flag;
    }
  }
}
