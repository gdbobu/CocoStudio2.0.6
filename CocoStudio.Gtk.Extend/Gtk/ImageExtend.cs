// Decompiled with JetBrains decompiler
// Type: Gtk.ImageExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using Xwt;
using Xwt.Drawing;
using Xwt.GtkBackend;

namespace Gtk
{
  public static class ImageExtend
  {
    public static Pixbuf GetPixbuf(this Xwt.Drawing.Image image)
    {
      return ((GtkImage) Toolkit.GetBackend((object) image.ToBitmap(ImageIcon.ScaleFactor, ImageFormat.ARGB32))).Frames[0].Pixbuf;
    }
  }
}
