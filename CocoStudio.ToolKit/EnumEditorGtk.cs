﻿// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EnumEditorGtk
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;

namespace CocoStudio.ToolKit
{
  public class EnumEditorGtk : ComboBox
  {
    private bool isPress = false;

    protected override void OnFocusGrabbed()
    {
      if (this.isPress)
        this.CanFocus = true;
      else
        this.CanFocus = false;
      base.OnFocusGrabbed();
    }

    protected override bool OnScrollEvent(EventScroll evnt)
    {
      if (!this.IsFocus)
        return false;
      return base.OnScrollEvent(evnt);
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      if ((int) evnt.Button == 1)
        this.isPress = true;
      return base.OnButtonPressEvent(evnt);
    }

    protected override bool OnFocusOutEvent(EventFocus evnt)
    {
      this.isPress = false;
      return base.OnFocusOutEvent(evnt);
    }
  }
}
