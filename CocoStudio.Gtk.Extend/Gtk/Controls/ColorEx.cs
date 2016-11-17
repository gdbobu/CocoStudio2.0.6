// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.ColorEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Text.RegularExpressions;

namespace Gtk.Controls
{
  public class ColorEx : EventBox
  {
    private Table table;
    private Entry entry;
    public ColorEditorGtk color;
    private ColorImage imageview;

    public System.Drawing.Color Color
    {
      get
      {
        return (System.Drawing.Color) this.color.Value;
      }
      set
      {
        this.color.Value = (object) value;
        string upper = ((System.Drawing.Color) this.color.Value).Name.ToUpper();
        this.entry.Text = "#" + upper.Substring(2, upper.Length - 2);
      }
    }

    public event EventHandler<ColorExEvent> ColorChanged;

    public ColorEx()
    {
      this.table = new Table(1U, 3U, false);
      this.imageview = new ColorImage();
      this.entry = new Entry();
      this.color = new ColorEditorGtk();
      this.color.ColorSet += new EventHandler<ColorSetEventArgs>(this.color_ColorSet);
      this.imageview.ImageClick += new EventHandler(this.imageview_ImageClick);
      this.entry.FocusOutEvent += new FocusOutEventHandler(this.entry_FocusOutEvent);
      this.entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.entry_KeyReleaseEvent);
      this.color.WidthRequest = 25;
      this.color.HeightRequest = 15;
      this.entry.WidthRequest = 70;
      this.table.Attach((Widget) this.color, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.entry, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.imageview, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      this.Add((Widget) this.table);
      this.ShowAll();
    }

    private void entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Return && args.Event.Key != Gdk.Key.KP_Enter && args.Event.Key != Gdk.Key.ISO_Enter || !this.entry.IsFocus)
        return;
      this.SetColorText();
    }

    private void entry_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      this.SetColorText();
    }

    private void SetColorText()
    {
      string input = this.entry.Text.Replace("#", "");
      if (Regex.IsMatch(input, "^[0-9A-Fa-f]+$"))
      {
        string str = input.PadRight(6, '0');
        this.color.Value = (object) System.Drawing.Color.FromArgb(Convert.ToInt32(str.Substring(0, 2), 16), Convert.ToInt32(str.Substring(2, 2), 16), Convert.ToInt32(str.Substring(4, 2), 16));
        this.entry.Text = 35.ToString() + str.Substring(0, 6);
        if (this.ColorChanged == null)
          return;
        this.ColorChanged((object) this, new ColorExEvent((System.Drawing.Color) this.color.Value));
      }
      else
      {
        string upper = ((System.Drawing.Color) this.color.Value).Name.ToUpper();
        this.entry.Text = "#" + upper.Substring(2, upper.Length - 2);
      }
    }

    private void imageview_ImageClick(object sender, EventArgs e)
    {
      this.color.ColorClick();
    }

    private void color_ColorSet(object sender, EventArgs e)
    {
      this.Color = (System.Drawing.Color) this.color.Value;
      if (this.ColorChanged == null)
        return;
      this.ColorChanged((object) this, new ColorExEvent((System.Drawing.Color) this.color.Value));
    }

    public void SetColor(Gdk.Color c)
    {
      this.color.CurrentColor = c;
      string upper = ((System.Drawing.Color) this.color.Value).Name.ToUpper();
      this.entry.Text = "#" + upper.Substring(2, upper.Length - 2);
    }
  }
}
