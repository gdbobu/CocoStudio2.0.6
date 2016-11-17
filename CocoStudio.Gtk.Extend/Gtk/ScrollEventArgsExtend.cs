// Decompiled with JetBrains decompiler
// Type: Gtk.ScrollEventArgsExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;

namespace Gtk
{
  public static class ScrollEventArgsExtend
  {
    public static int GetDelta(this ScrollEventArgs args)
    {
      int num1 = 1;
      int num2 = 1;
      switch (args.Event.Direction)
      {
        case ScrollDirection.Up:
          num2 = 1;
          break;
        case ScrollDirection.Down:
          num2 = -1;
          break;
        case ScrollDirection.Left:
          num2 = 1;
          break;
        case ScrollDirection.Right:
          num2 = -1;
          break;
      }
      return num1 * num2;
    }
  }
}
