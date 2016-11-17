// Decompiled with JetBrains decompiler
// Type: Gtk.HelperMethods
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Cairo;
using System;

namespace Gtk
{
  public static class HelperMethods
  {
    public static T Kill<T>(this T gc) where T : IDisposable
    {
      if ((object) gc != null)
        gc.Dispose();
      return default (T);
    }

    public static T Kill<T>(this T gc, System.Action<T> action) where T : IDisposable
    {
      if ((object) gc != null)
      {
        action(gc);
        gc.Dispose();
      }
      return default (T);
    }

    public static string GetColorString(Gdk.Color color)
    {
      return string.Format("#{0:X02}{1:X02}{2:X02}", (object) ((int) color.Red / 256), (object) ((int) color.Green / 256), (object) ((int) color.Blue / 256));
    }

    public static void DrawLine(this Context cr, Cairo.Color color, double x1, double y1, double x2, double y2)
    {
      cr.SetSourceColor(color);
      cr.MoveTo(x1, y1);
      cr.LineTo(x2, y2);
      cr.Stroke();
    }

    public static void Line(this Context cr, double x1, double y1, double x2, double y2)
    {
      cr.MoveTo(x1, y1);
      cr.LineTo(x2, y2);
    }

    public static void SharpLineX(this Context cr, double x1, double y1, double x2, double y2)
    {
      cr.MoveTo(x1 + 0.5, y1);
      cr.LineTo(x2 + 0.5, y2);
    }

    public static void SharpLineY(this Context cr, double x1, double y1, double x2, double y2)
    {
      cr.MoveTo(x1, y1 + 0.5);
      cr.LineTo(x2, y2 + 0.5);
    }

    public static void SetSourceColor(this Context cr, Cairo.Color color)
    {
      cr.SetSourceRGBA(color.R, color.G, color.B, color.A);
    }
  }
}
