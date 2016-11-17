// Decompiled with JetBrains decompiler
// Type: Gtk.ToggleButtonImage
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using System;

namespace Gtk
{
  public class ToggleButtonImage : EventBox
  {
    private Xwt.Drawing.Image checkedImage;
    private Xwt.Drawing.Image uncheckedImage;
    private Xwt.Drawing.Image currentImage;
    private Xwt.Drawing.Image inactiveImage;
    public CustomImageView ImageWidget;
    private bool hover;
    private bool pressed;
    private bool isChecked;
    private ToggleButton toggleButton;

    public Xwt.Drawing.Image CheckedImage
    {
      get
      {
        return this.checkedImage;
      }
      set
      {
        this.checkedImage = value;
        if (!this.IsChecked)
          return;
        this.CurrentImage = value;
      }
    }

    public Xwt.Drawing.Image UnCheckedImage
    {
      get
      {
        return this.uncheckedImage;
      }
      set
      {
        this.uncheckedImage = value;
        if (this.IsChecked)
          return;
        this.CurrentImage = value;
      }
    }

    public bool IsChecked
    {
      get
      {
        return this.isChecked;
      }
      set
      {
        if (this.isChecked == value)
          return;
        this.isChecked = value;
        this.CurrentImage = !this.isChecked ? this.UnCheckedImage : this.CheckedImage;
        if (value)
          return;
        this.ImageWidget.IsShowCustomStyle = new bool?();
        this.ImageWidget.FocusShowBackGround = false;
        this.ImageWidget.QueueDraw();
        this.QueueDraw();
      }
    }

    private Xwt.Drawing.Image CurrentImage
    {
      get
      {
        return this.currentImage;
      }
      set
      {
        this.currentImage = value;
        Xwt.Drawing.Image inactiveImage = this.inactiveImage;
        this.inactiveImage = this.currentImage != null ? this.currentImage.WithAlpha(0.8) : (Xwt.Drawing.Image) null;
        this.LoadImage();
        if (inactiveImage == null)
          return;
        inactiveImage.Dispose();
      }
    }

    public new bool Sensitive
    {
      get
      {
        return this.toggleButton.Sensitive;
      }
      set
      {
        this.toggleButton.Sensitive = value;
        this.LoadImage();
      }
    }

    public event EventHandler CheckChanged;

    public ToggleButtonImage()
    {
      this.Events |= EventMask.ButtonReleaseMask | EventMask.EnterNotifyMask | EventMask.LeaveNotifyMask;
      this.VisibleWindow = false;
      this.ImageWidget = new CustomImageView();
      this.ImageWidget.Show();
      this.toggleButton = new ToggleButton();
      this.toggleButton.Add((Widget) this.ImageWidget);
      this.Add((Widget) this.toggleButton);
      this.toggleButton.Toggled += new EventHandler(this.toggleButton_Toggled);
      this.toggleButton.EnterNotifyEvent += new EnterNotifyEventHandler(this.ImageWidget.CustomImageView_EnterNotifyEvent);
      this.toggleButton.LeaveNotifyEvent += new LeaveNotifyEventHandler(this.ImageWidget.CustomImageView_LeaveNotifyEvent);
      this.toggleButton.Toggled += new EventHandler(this.toggleButton_CustomImageViewToggled);
    }

    public ToggleButtonImage(Xwt.Drawing.Image checkedImage = null, Xwt.Drawing.Image uncheckedImage = null)
      : this()
    {
      this.CheckedImage = checkedImage;
      this.UnCheckedImage = uncheckedImage;
    }

    protected override bool OnKeyPressEvent(EventKey evnt)
    {
      if (evnt.Key == Gdk.Key.space || evnt.Key == Gdk.Key.Return || evnt.Key == Gdk.Key.KP_Enter || evnt.Key == Gdk.Key.ISO_Enter)
        return true;
      return base.OnKeyPressEvent(evnt);
    }

    [ConnectBefore]
    private void toggleButton_CustomImageViewToggled(object sender, EventArgs e)
    {
      this.ImageWidget.IsShowCustomStyle = new bool?(this.ImageWidget.FocusShowBackGround = !this.IsChecked);
    }

    private void toggleButton_Toggled(object sender, EventArgs e)
    {
      this.IsChecked = !this.IsChecked;
      if (this.CheckChanged == null)
        return;
      this.CheckChanged((object) this, EventArgs.Empty);
    }

    protected override void OnDestroyed()
    {
      if (this.inactiveImage != null)
        this.inactiveImage.Dispose();
      base.OnDestroyed();
    }

    private void LoadImage()
    {
      if (this.currentImage != null)
      {
        if (this.Sensitive)
          this.ImageWidget.Image = this.currentImage;
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
      this.pressed = this.currentImage != null;
      return base.OnButtonPressEvent(evnt);
    }

    protected override bool OnButtonReleaseEvent(EventButton evnt)
    {
      if (!this.pressed || (int) evnt.Button != 1 || !new Rectangle(0, 0, this.Allocation.Width, this.Allocation.Height).Contains((int) evnt.X, (int) evnt.Y))
        return base.OnButtonReleaseEvent(evnt);
      this.IsChecked = !this.IsChecked;
      if (this.CheckChanged != null)
        this.CheckChanged((object) this, EventArgs.Empty);
      return true;
    }

    public void SetActive(bool active)
    {
      this.toggleButton.Active = active;
    }
  }
}
