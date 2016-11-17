// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.ComBoxEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using System.ComponentModel;

namespace Gtk.Controls
{
  [ToolboxItem(true)]
  public class ComBoxEx : ComboBox
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
