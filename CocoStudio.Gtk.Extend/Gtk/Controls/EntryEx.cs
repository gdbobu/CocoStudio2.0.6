// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.EntryEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using System;

namespace Gtk.Controls
{
  public class EntryEx : Entry
  {
    private Gtk.Action VertifyAction;

    public bool IsSelectAll { get; set; }

    public event EventHandler EntryValueCommitChanged;

    public EntryEx()
    {
      this.IsSelectAll = true;
    }

    protected override bool OnKeyReleaseEvent(EventKey evnt)
    {
      if ((evnt.Key == Gdk.Key.Return || evnt.Key == Gdk.Key.KP_Enter || evnt.Key == Gdk.Key.ISO_Enter) && this.IsFocus)
      {
        if (this.EntryValueCommitChanged != null)
          this.EntryValueCommitChanged((object) this, new EventArgs());
        if (this.IsSelectAll)
          this.SelectRegion(0, this.Text.Length);
      }
      return base.OnKeyReleaseEvent(evnt);
    }

    protected override bool OnFocusOutEvent(EventFocus evnt)
    {
      if (this.EntryValueCommitChanged != null)
        this.EntryValueCommitChanged((object) this, new EventArgs());
      this.SelectRegion(0, 0);
      return base.OnFocusOutEvent(evnt);
    }
  }
}
