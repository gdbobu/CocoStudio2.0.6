// Decompiled with JetBrains decompiler
// Type: Gtk.CSImageButton
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using System;

namespace Gtk
{
  public class CSImageButton : EventBox
  {
    private Xwt.Drawing.Image image;
    private Xwt.Drawing.Image inactiveImage;
    private Button button;
    private bool hasInactiveImage;
    private bool hover;
    private bool pressed;

    public CustomImageView ImageWidget { get; private set; }

    public Xwt.Drawing.Image Image
    {
      get
      {
        return this.image;
      }
      set
      {
        this.image = value;
        Xwt.Drawing.Image image = (Xwt.Drawing.Image) null;
        if (!this.hasInactiveImage)
        {
          image = this.inactiveImage;
          this.inactiveImage = this.image != null ? this.image.WithAlpha(0.5) : (Xwt.Drawing.Image) null;
        }
        this.LoadImage();
        if (image == null)
          return;
        image.Dispose();
      }
    }

    public Xwt.Drawing.Image InactiveImage
    {
      get
      {
        return this.hasInactiveImage ? this.inactiveImage : (Xwt.Drawing.Image) null;
      }
      set
      {
        if (!this.hasInactiveImage && this.inactiveImage != null)
          this.inactiveImage.Dispose();
        this.hasInactiveImage = true;
        this.inactiveImage = value;
        this.LoadImage();
      }
    }

    public new bool Sensitive
    {
      get
      {
        return this.button.Sensitive;
      }
      set
      {
        this.button.Sensitive = value;
        this.LoadImage();
      }
    }

    public event EventHandler Clicked;

    public new event ButtonPressEventHandler ButtonPressEvent;

    public new event ButtonReleaseEventHandler ButtonReleaseEvent;

    public CSImageButton()
    {
      this.Events |= EventMask.ButtonReleaseMask | EventMask.EnterNotifyMask | EventMask.LeaveNotifyMask;
      this.VisibleWindow = false;
      this.ImageWidget = new CustomImageView();
      this.ImageWidget.Show();
      this.button = new Button();
      this.Add((Widget) this.button);
      this.button.Events = EventMask.AllEventsMask;
      this.button.Clicked += new EventHandler(this.button_Clicked);
      this.button.ButtonPressEvent += new ButtonPressEventHandler(this.button_Press);
      this.button.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.button_Release);
      this.button.Add((Widget) this.ImageWidget);
      this.button.EnterNotifyEvent += new EnterNotifyEventHandler(this.ImageWidget.CustomImageView_EnterNotifyEvent);
      this.button.LeaveNotifyEvent += new LeaveNotifyEventHandler(this.ImageWidget.CustomImageView_LeaveNotifyEvent);
      this.button.ButtonPressEvent += new ButtonPressEventHandler(this.ImageWidget.CustomImageView_Press);
      this.button.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.ImageWidget.CustomImageView_Release);
    }

    public CSImageButton(int width, int height)
      : this()
    {
      this.SetSizeRequest(width, height);
    }

    protected override bool OnKeyPressEvent(EventKey evnt)
    {
      if (evnt.Key == Gdk.Key.space || evnt.Key == Gdk.Key.Return || evnt.Key == Gdk.Key.KP_Enter || evnt.Key == Gdk.Key.ISO_Enter)
        return true;
      return base.OnKeyPressEvent(evnt);
    }

    private void button_Clicked(object sender, EventArgs e)
    {
      if (this.Clicked == null)
        return;
      this.Clicked((object) this, EventArgs.Empty);
    }

    [ConnectBefore]
    private void button_Press(object o, ButtonPressEventArgs args)
    {
      if (this.ButtonPressEvent == null)
        return;
      this.ButtonPressEvent((object) this, args);
    }

    [ConnectBefore]
    private void button_Release(object o, ButtonReleaseEventArgs args)
    {
      if (this.ButtonReleaseEvent == null)
        return;
      this.ButtonReleaseEvent((object) this, args);
    }

    protected override void OnDestroyed()
    {
      if (!this.hasInactiveImage && this.inactiveImage != null)
        this.inactiveImage.Dispose();
      base.OnDestroyed();
    }

    private void LoadImage()
    {
      if (this.image != null)
      {
        if (this.Sensitive)
          this.ImageWidget.Image = this.image;
        else
          this.ImageWidget.Image = this.inactiveImage;
      }
      else
        this.ImageWidget.Image = (Xwt.Drawing.Image) null;
    }

    protected override bool OnEnterNotifyEvent(EventCrossing evnt)
    {
      this.hover = true;
      this.LoadImage();
      return base.OnEnterNotifyEvent(evnt);
    }

    protected override bool OnLeaveNotifyEvent(EventCrossing evnt)
    {
      this.hover = false;
      this.LoadImage();
      return base.OnLeaveNotifyEvent(evnt);
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      this.pressed = this.image != null;
      return base.OnButtonPressEvent(evnt);
    }

    protected override bool OnButtonReleaseEvent(EventButton evnt)
    {
      if (!this.pressed || (int) evnt.Button != 1 || !new Rectangle(0, 0, this.Allocation.Width, this.Allocation.Height).Contains((int) evnt.X, (int) evnt.Y))
        return base.OnButtonReleaseEvent(evnt);
      this.hover = false;
      this.LoadImage();
      if (this.Clicked != null)
        this.Clicked((object) this, EventArgs.Empty);
      return base.OnButtonReleaseEvent(evnt);
    }
  }
}
