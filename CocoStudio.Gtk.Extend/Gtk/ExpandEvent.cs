// Decompiled with JetBrains decompiler
// Type: Gtk.ExpandEvent
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;

namespace Gtk
{
  public class ExpandEvent : EventArgs
  {
    public string Name { get; private set; }

    public bool Expand { get; private set; }

    public ExpandEvent(string name, bool expand)
    {
      this.Name = name;
      this.Expand = expand;
    }
  }
}
