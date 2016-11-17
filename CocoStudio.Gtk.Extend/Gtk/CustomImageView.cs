// Decompiled with JetBrains decompiler
// Type: Gtk.CustomImageView
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using MonoDevelop.Components;

namespace Gtk
{
  public class CustomImageView : ImageView
  {
    private Gdk.Color backGroundColor = new Gdk.Color((byte) 66, (byte) 65, (byte) 71);
    public Gdk.Color FocusBorderColor = new Gdk.Color((byte) 7, (byte) 114, (byte) 244);
    public Gdk.Color FocusBackGroundColor = new Gdk.Color((byte) 50, (byte) 50, (byte) 54);
    public Gdk.Color ClickBackGroundColor = new Gdk.Color((byte) 7, (byte) 90, (byte) 192);
    public bool FocusShowBackGround = false;
    private bool isloaded = false;

    public Gdk.Color BackGroundColor
    {
      get
      {
        return this.backGroundColor;
      }
      set
      {
        this.backGroundColor = value;
        this.Parent.ModifyBg(StateType.Normal, value);
        this.Parent.ModifyBg(StateType.Insensitive, value);
      }
    }

    public bool? IsShowCustomStyle { get; set; }

    public CustomImageView()
    {
      this.WidgetEvent += new WidgetEventHandler(this.CustomImageView_WidgetEvent);
    }

    public CustomImageView(Xwt.Drawing.Image image)
      : base(image)
    {
      this.WidgetEvent += new WidgetEventHandler(this.CustomImageView_WidgetEvent);
    }

    private void CustomImageView_WidgetEvent(object o, WidgetEventArgs args)
    {
      if (!(args.Event.ToString() == "Gdk.EventConfigure") || this.isloaded)
        return;
      this.isloaded = true;
      this.QueueDraw();
      this.Parent.ModifyBg(StateType.Normal, this.BackGroundColor);
      this.Parent.ModifyBg(StateType.Insensitive, this.BackGroundColor);
    }

    [ConnectBefore]
    public void CustomImageView_Press(object o, ButtonPressEventArgs args)
    {
      this.IsShowCustomStyle = new bool?(true);
    }

    [ConnectBefore]
    public void CustomImageView_Release(object o, ButtonReleaseEventArgs args)
    {
      this.IsShowCustomStyle = new bool?(false);
    }

    [ConnectBefore]
    public void CustomImageView_EnterNotifyEvent(object o, EnterNotifyEventArgs args)
    {
      this.IsShowCustomStyle = new bool?(false);
    }

    [ConnectBefore]
    public void CustomImageView_LeaveNotifyEvent(object o, LeaveNotifyEventArgs args)
    {
      this.IsShowCustomStyle = new bool?();
    }

    protected override bool OnExposeEvent(EventExpose evnt)
    {
      if (this.Image == null)
        return true;
      int x1 = this.Parent.Allocation.X;
      int y1 = this.Parent.Allocation.Y;
      int num1 = this.Parent.Allocation.X + this.Parent.Allocation.Width - 1;
      int y2 = this.Parent.Allocation.Y;
      int num2 = this.Parent.Allocation.X + this.Parent.Allocation.Width - 1;
      int num3 = this.Parent.Allocation.Y + this.Parent.Allocation.Height - 1;
      int x2 = this.Parent.Allocation.X;
      int num4 = this.Parent.Allocation.Y + this.Parent.Allocation.Height - 1;
      bool flag = false;
      if (this.FocusShowBackGround)
        flag = true;
      else if (this.IsShowCustomStyle.HasValue)
      {
        if (this.IsShowCustomStyle.Value)
        {
          flag = true;
        }
        else
        {
          this.Parent.GdkWindow.DrawRectangle(new GC((Drawable) this.Parent.GdkWindow)
          {
            RgbFgColor = this.FocusBackGroundColor
          }, true, new Rectangle(x1, y1, this.Parent.Allocation.Width, this.Parent.Allocation.Height));
          GC gc = new GC((Drawable) this.Parent.GdkWindow);
          gc.RgbFgColor = this.FocusBorderColor;
          this.Parent.GdkWindow.DrawLine(gc, x1, y1, num1, y2);
          this.Parent.GdkWindow.DrawLine(gc, num1, y2, num2, num3);
          this.Parent.GdkWindow.DrawLine(gc, num2, num3, x2, num4);
          this.Parent.GdkWindow.DrawLine(gc, x2, num4, x1, y1);
        }
      }
      else
        this.Parent.GdkWindow.DrawRectangle(new GC((Drawable) this.Parent.GdkWindow)
        {
          RgbFgColor = this.BackGroundColor
        }, true, new Rectangle(x1, y1, this.Parent.Allocation.Width, this.Parent.Allocation.Height));
      if (flag)
        this.Parent.GdkWindow.DrawRectangle(new GC((Drawable) this.Parent.GdkWindow)
        {
          RgbFgColor = this.ClickBackGroundColor
        }, true, new Rectangle(x1, y1, this.Parent.Allocation.Width, this.Parent.Allocation.Height));
      return base.OnExposeEvent(evnt);
    }
  }
}
