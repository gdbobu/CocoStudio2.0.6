// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.ColorExEvent
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Drawing;

namespace Gtk.Controls
{
  public class ColorExEvent : EventArgs
  {
    public Color Color { get; set; }

    public ColorExEvent(Color color)
    {
      this.Color = color;
    }
  }
}
