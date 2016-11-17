// Decompiled with JetBrains decompiler
// Type: OpenDialogs.POINT
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System.Drawing;

namespace OpenDialogs
{
  public struct POINT
  {
    public int x;
    public int y;

    public POINT(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public POINT(Point point)
    {
      this.x = point.X;
      this.y = point.Y;
    }
  }
}
