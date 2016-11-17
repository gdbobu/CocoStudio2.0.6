// Decompiled with JetBrains decompiler
// Type: Gtk.CustomExpender
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using System;

namespace Gtk
{
  public class CustomExpender : Expander
  {
    private bool isloaded = false;
    private EventBox parentEventBox;

    public string ExpandCategory { get; set; }

    public event EventHandler<ExpandEvent> ExpandChanged;

    public CustomExpender(string label)
      : base(label)
    {
      this.BorderWidth = 3U;
      this.WidgetEvent += new WidgetEventHandler(this.CustomExpender_WidgetEvent);
      this.SizeAllocated += new SizeAllocatedHandler(this.CustomExpender_SizeAllocated);
      this.ExposeEvent += new ExposeEventHandler(this.CustomExpender_ExposeEvent);
      this.Destroyed += new EventHandler(this.CustomExpender_Destroyed);
    }

    private void CustomExpender_Destroyed(object sender, EventArgs e)
    {
      this.Destroyed -= new EventHandler(this.CustomExpender_Destroyed);
      this.WidgetEvent -= new WidgetEventHandler(this.CustomExpender_WidgetEvent);
      this.SizeAllocated -= new SizeAllocatedHandler(this.CustomExpender_SizeAllocated);
      this.ExposeEvent -= new ExposeEventHandler(this.CustomExpender_ExposeEvent);
      if (this.parentEventBox == null)
        return;
      this.parentEventBox.WidgetEvent -= new WidgetEventHandler(this.Parent_WidgetEvent);
    }

    private void CustomExpender_WidgetEvent(object o, WidgetEventArgs args)
    {
      if (!(args.Event.ToString() == "Gdk.EventExpose") || (this.isloaded || this.Parent == null))
        return;
      this.parentEventBox = this.GetParentWidget<EventBox>();
      if (this.parentEventBox != null)
      {
        this.parentEventBox.WidgetEvent += new WidgetEventHandler(this.Parent_WidgetEvent);
        this.isloaded = true;
      }
    }

    [ConnectBefore]
    private void Parent_WidgetEvent(object o, WidgetEventArgs args)
    {
      if (args.Event.Type != EventType.ButtonPress || !this.IsClickTitle((EventButton) args.Event))
        return;
      this.Expanded = !this.Expanded;
      if (this.ExpandChanged != null)
        this.ExpandChanged((object) this, new ExpandEvent(this.ExpandCategory, this.Expanded));
    }

    private void CustomExpender_SizeAllocated(object o, SizeAllocatedArgs args)
    {
      if (this.Parent == null || this.Parent.Parent == null)
        return;
      this.Parent.Parent.QueueDraw();
    }

    private void CustomExpender_ExposeEvent(object o, ExposeEventArgs args)
    {
      Rectangle titleSize = this.GetTitleSize();
      if (titleSize.Width == 0)
        return;
      Gdk.GC gc = new Gdk.GC((Drawable) this.GdkWindow);
      gc.RgbFgColor = WindowStyle.WindowLineColor;
      this.Parent.Parent.GdkWindow.DrawLine(gc, titleSize.X, titleSize.Y, titleSize.X + titleSize.Width, titleSize.Y);
      this.Parent.Parent.GdkWindow.DrawLine(gc, titleSize.X, titleSize.Y + titleSize.Height, titleSize.X + titleSize.Width, titleSize.Y + titleSize.Height);
    }

    private bool IsClickTitle(EventButton evnt)
    {
      Rectangle originTitleSize = this.GetOriginTitleSize();
      return originTitleSize.Width != 0 && originTitleSize.Contains((int) evnt.XRoot, (int) evnt.YRoot);
    }

    private Rectangle GetTitleSize()
    {
      if (this.Parent == null || this.Parent.Parent == null)
        return new Rectangle();
      int width1 = this.Parent.Parent.Allocation.Width;
      int borderWidth = (int) this.BorderWidth;
      int x = 0;
      int y = this.Allocation.Y + borderWidth;
      int width2 = width1;
      int num1 = this.Allocation.Y + this.LabelWidget.Allocation.Height + borderWidth * 2;
      int num2 = this.Allocation.Y + this.LabelWidget.Allocation.Height + borderWidth * 2;
      return new Rectangle(x, y, width2, num1 - y);
    }

    private Rectangle GetOriginTitleSize()
    {
      int x = -1;
      int y1 = -1;
      int borderWidth = (int) this.BorderWidth;
      if (this.parentEventBox == null || this.GdkWindow == null || this.GdkWindow.GetOrigin(out x, out y1) <= 0)
        return new Rectangle();
      x += this.Allocation.Left;
      int y2 = y1 + (this.Allocation.Top + borderWidth);
      int width = this.parentEventBox.Allocation.Width;
      int height = this.LabelWidget.Allocation.Height + borderWidth;
      return new Rectangle(x, y2, width, height);
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      return !this.IsClickTitle(evnt) && base.OnButtonPressEvent(evnt);
    }
  }
}
