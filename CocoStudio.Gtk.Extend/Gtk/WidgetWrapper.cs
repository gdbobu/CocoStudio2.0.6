﻿// Decompiled with JetBrains decompiler
// Type: Gtk.WidgetWrapper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

namespace Gtk
{
  public class WidgetWrapper : IWidgetWrapper
  {
    public Widget Widget { get; protected set; }

    public WidgetWrapper(Widget widget)
    {
      this.Widget = widget;
    }

    public virtual void Shown()
    {
    }
  }
}
