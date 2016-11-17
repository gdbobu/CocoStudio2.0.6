// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.NumberButtonImage
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Core;
using CocoStudio.Core.Events;
using Gdk;
using Gtk;
using MonoDevelop.Components;
using System;

namespace CocoStudio.ToolKit
{
  public class NumberButtonImage : EventBox
  {
    private bool isCheck = false;
    private ImageView imageWidget;

    public bool IsCheck
    {
      get
      {
        return this.isCheck;
      }
      set
      {
        this.isCheck = value;
        this.SetCurrentImage(this.isCheck);
      }
    }

    public event EventHandler<PointEvent> ImageStatusChanged;

    public NumberButtonImage()
    {
      this.Events |= EventMask.ButtonReleaseMask | EventMask.EnterNotifyMask | EventMask.LeaveNotifyMask;
      Table table = new Table(2U, 1U, false);
      this.VisibleWindow = false;
      this.imageWidget = new ImageView();
      table.Attach((Widget) this.imageWidget, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      Label label = new Label();
      label.HeightRequest = 20;
      table.Attach((Widget) label, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment.TopPadding = 4U;
      alignment.RightPadding = 10U;
      alignment.Add((Widget) table);
      alignment.ShowAll();
      this.Add((Widget) alignment);
      table.ShowAll();
      this.ShowAll();
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      if ((int) evnt.Button == 1 && new Rectangle(0, 0, this.Allocation.Width, this.Allocation.Height).Contains((int) evnt.X, (int) evnt.Y))
      {
        this.isCheck = !this.isCheck;
        this.SetCurrentImage(this.isCheck);
        if (this.ImageStatusChanged != null)
          this.ImageStatusChanged((object) this, new PointEvent(0.0, 0.0, this.isCheck));
      }
      return base.OnButtonPressEvent(evnt);
    }

    public void SetCurrentImage(bool isCheck)
    {
      this.isCheck = isCheck;
      this.imageWidget.Image = !isCheck ? ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.unLock.png") : ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.lock.png");
      Services.EventsService.GetEvent<ScaleLockedChangeEvent>().Publish(isCheck);
    }
  }
}
