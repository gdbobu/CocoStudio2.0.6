// Decompiled with JetBrains decompiler
// Type: Gdk.PixbufHelper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System.IO;

namespace Gdk
{
  public static class PixbufHelper
  {
    public static Pixbuf Load(string filePath)
    {
      if (!File.Exists(filePath))
        return (Pixbuf) null;
      using (FileStream fileStream = File.Open(filePath, FileMode.Open))
        return new Pixbuf((Stream) fileStream);
    }
  }
}
