// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.ColorImage
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using MonoDevelop.Components;
using System;

namespace Gtk.Controls
{
  public class ColorImage : EventBox
  {
    private ImageView imageWidget;

    public event EventHandler ImageClick;

    public ColorImage()
    {
      this.imageWidget = new ImageView();
      this.imageWidget.WidthRequest = 15;
      this.imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.Arrow.png");
      this.Add((Widget) this.imageWidget);
      this.ShowAll();
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      if ((int) evnt.Button != 1)
        return base.OnButtonPressEvent(evnt);
      this.IsFocus = true;
      if (this.ImageClick != null)
        this.ImageClick((object) this, new EventArgs());
      return true;
    }
  }
}
