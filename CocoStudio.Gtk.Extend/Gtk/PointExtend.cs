// Decompiled with JetBrains decompiler
// Type: Gtk.PointExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;

namespace Gtk
{
  public static class PointExtend
  {
    public static Point SubPoint(Point srcPoint, Point destPoint)
    {
      return new Point(srcPoint.X - destPoint.X, srcPoint.Y - destPoint.Y);
    }
  }
}
