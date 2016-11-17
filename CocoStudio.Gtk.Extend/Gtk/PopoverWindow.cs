// Decompiled with JetBrains decompiler
// Type: Gtk.PopoverWindow
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Cairo;
using Gdk;
using System;
using Xwt;

namespace Gtk
{
  public class PopoverWindow : Window
  {
    private const int arrowPadding = 10;
    private const int radius = 6;
    private bool supportAlpha;
    private Popover.Position arrowPosition;
    protected Alignment alignment;
    private WidgetSpacing margin;

    public Popover.Position ArrowPosition
    {
      get
      {
        return this.arrowPosition;
      }
    }

    public PopoverWindow(Popover.Position orientation)
      : base(WindowType.Popup)
    {
      this.AppPaintable = true;
      this.Decorated = false;
      this.SkipPagerHint = true;
      this.SkipTaskbarHint = true;
      this.TypeHint = WindowTypeHint.PopupMenu;
      this.AddEvents(16384);
      this.DefaultHeight = 20;
      this.arrowPosition = orientation;
      this.FocusOutEvent += new FocusOutEventHandler(this.HandleFocusOutEvent);
      this.OnScreenChanged((Gdk.Screen) null);
    }

    public void ReleaseInnerWidget()
    {
      this.alignment.Remove(this.alignment.Child);
    }

    private void HandleFocusOutEvent(object o, FocusOutEventArgs args)
    {
      this.HideAll();
    }

    public void SetPadding(WidgetSpacing spacing)
    {
      this.margin = spacing;
      this.alignment.LeftPadding = 6U + (uint) spacing.Left;
      this.alignment.RightPadding = 6U + (uint) spacing.Right;
      if (this.arrowPosition == Popover.Position.Top)
      {
        this.alignment.TopPadding = 16U + (uint) spacing.Top;
        this.alignment.BottomPadding = 6U + (uint) spacing.Bottom;
      }
      else
      {
        this.alignment.BottomPadding = 16U + (uint) spacing.Bottom;
        this.alignment.TopPadding = 6U + (uint) spacing.Top;
      }
    }

    protected override void OnScreenChanged(Gdk.Screen previous_screen)
    {
      Colormap colormap = this.Screen.RgbaColormap;
      if (colormap == null)
      {
        colormap = this.Screen.RgbColormap;
        this.supportAlpha = false;
      }
      else
        this.supportAlpha = true;
      this.Colormap = colormap;
      base.OnScreenChanged(previous_screen);
    }

    protected override bool OnExposeEvent(EventExpose evnt)
    {
      base.OnExposeEvent(evnt);
      return false;
    }

    private void DrawTriangle(Context ctx)
    {
      double dx = 20.0 / Math.Sqrt(3.0) / 2.0;
      int num = this.arrowPosition == Popover.Position.Top ? -1 : 1;
      ctx.RelMoveTo(-dx, 0.0);
      ctx.RelLineTo(dx, (double) (num * 10));
      ctx.RelLineTo(dx, (double) (num * -10));
    }

    private void RoundRectangle(Context ctx, Xwt.Rectangle rect, double radius)
    {
      double num = Math.PI / 180.0;
      double x = rect.X;
      double y = rect.Y;
      double height = rect.Height;
      double width = rect.Width;
      ctx.NewSubPath();
      ctx.Arc(x + width - radius, y + radius, radius, -90.0 * num, 0.0 * num);
      ctx.Arc(x + width - radius, y + height - radius, radius, 0.0 * num, 90.0 * num);
      ctx.Arc(x + radius, y + height - radius, radius, 90.0 * num, 180.0 * num);
      ctx.Arc(x + radius, y + radius, radius, 180.0 * num, 270.0 * num);
      ctx.ClosePath();
    }

    private Xwt.Rectangle RecalibrateChildRectangle(Xwt.Rectangle bounds)
    {
      switch (this.arrowPosition)
      {
        case Popover.Position.Top:
          return new Xwt.Rectangle(bounds.X, bounds.Y + 10.0, bounds.Width, bounds.Height - 10.0);
        case Popover.Position.Bottom:
          return new Xwt.Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height - 10.0);
        default:
          return bounds;
      }
    }

    public Xwt.Point ConvertToScreenCoordinates(Widget widget, Xwt.Point widgetCoordinates)
    {
      if (widget.ParentWindow == null)
        return new Xwt.Point(0.0, 0.0);
      int x;
      int y;
      widget.ParentWindow.GetOrigin(out x, out y);
      Gdk.Rectangle allocation = widget.Allocation;
      int num1 = x + allocation.X;
      int num2 = y + allocation.Y;
      return new Xwt.Point((double) num1 + widgetCoordinates.X, (double) num2 + widgetCoordinates.Y);
    }

    public void Show(Widget reference)
    {
      Gdk.Window parentWindow = reference.ParentWindow;
      Xwt.Rectangle rectangle1 = new Xwt.Rectangle(this.ConvertToScreenCoordinates(reference, new Xwt.Point(0.0, 0.0)), new Xwt.Size((double) reference.Allocation.Width, (double) reference.Allocation.Height));
      Xwt.Rectangle rectangle2 = new Xwt.Rectangle(Xwt.Point.Zero, rectangle1.Size);
      rectangle2 = rectangle2.Offset(rectangle1.Location);
      Xwt.Point position = rectangle2.Location;
      this.ShowAll();
      int width;
      int height;
      this.GetSize(out width, out height);
      this.Move((int) (position.X + this.margin.Left), (int) (position.Y + this.margin.Top));
      this.SizeAllocated += (SizeAllocatedHandler) ((o, args) => this.Move((int) position.X, (int) position.Y));
    }
  }
}
