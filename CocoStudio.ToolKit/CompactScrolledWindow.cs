// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.CompactScrolledWindow
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class CompactScrolledWindow : ScrolledWindow
  {
    private const string styleName = "CocoStudio.ToolKit.PropertyGrid.CompactScrolledWindow";
    private bool showBorderLine;

    public bool ShowBorderLine
    {
      get
      {
        return this.showBorderLine;
      }
      set
      {
        if (this.showBorderLine == value)
          return;
        this.showBorderLine = value;
        this.QueueResize();
      }
    }

    protected override void OnSizeRequested(ref Requisition requisition)
    {
      base.OnSizeRequested(ref requisition);
      if (!this.showBorderLine)
        return;
      requisition.Height += this.HScrollbar.Visible ? 1 : 2;
      requisition.Width += this.VScrollbar.Visible ? 1 : 2;
    }

    protected override void OnSizeAllocated(Rectangle allocation)
    {
      if (this.showBorderLine)
      {
        ++allocation.X;
        ++allocation.Y;
        allocation.Height -= this.HScrollbar.Visible ? 1 : 2;
        allocation.Width -= this.VScrollbar.Visible ? 1 : 2;
      }
      base.OnSizeAllocated(allocation);
      if (!this.showBorderLine)
        return;
      bool visible1 = this.HScrollbar.Visible;
      bool visible2 = this.VScrollbar.Visible;
      Rectangle allocation1;
      if (visible1)
      {
        allocation1 = this.HScrollbar.Allocation;
        --allocation1.X;
        allocation1.Width += visible2 ? 1 : 2;
        this.HScrollbar.SizeAllocate(allocation1);
      }
      if (visible2)
      {
        allocation1 = this.VScrollbar.Allocation;
        --allocation1.Y;
        allocation1.Height += visible1 ? 1 : 2;
        this.VScrollbar.SizeAllocate(allocation1);
      }
    }

    protected override bool OnExposeEvent(EventExpose evnt)
    {
      bool flag = base.OnExposeEvent(evnt);
      if (!this.showBorderLine)
        return flag;
      bool visible1 = this.HScrollbar.Visible;
      bool visible2 = this.VScrollbar.Visible;
      Rectangle allocation = this.Allocation;
      int borderWidth = (int) this.BorderWidth;
      allocation.X += borderWidth - 1;
      allocation.Y += borderWidth - 1;
      allocation.Width -= borderWidth + borderWidth - 2;
      allocation.Height -= borderWidth + borderWidth - 2;
      if (visible1)
        allocation.Height -= this.HScrollbar.Allocation.Height / 2;
      if (visible2)
        allocation.Width -= this.VScrollbar.Allocation.Width / 2;
      double num = 1.0 / 2.0;
      return flag;
    }
  }
}
