// Decompiled with JetBrains decompiler
// Type: Stetic.BinContainer
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gtk;
using System;

namespace Stetic
{
  internal class BinContainer
  {
    private Widget child;
    private UIManager uimanager;

    public static BinContainer Attach(Bin bin)
    {
      BinContainer binContainer = new BinContainer();
      bin.SizeRequested += new SizeRequestedHandler(binContainer.OnSizeRequested);
      bin.SizeAllocated += new SizeAllocatedHandler(binContainer.OnSizeAllocated);
      bin.Added += new AddedHandler(binContainer.OnAdded);
      return binContainer;
    }

    private void OnSizeRequested(object sender, SizeRequestedArgs args)
    {
      if (this.child == null)
        return;
      args.Requisition = this.child.SizeRequest();
    }

    private void OnSizeAllocated(object sender, SizeAllocatedArgs args)
    {
      if (this.child == null)
        return;
      this.child.Allocation = args.Allocation;
    }

    private void OnAdded(object sender, AddedArgs args)
    {
      this.child = args.Widget;
    }

    public void SetUiManager(UIManager uim)
    {
      this.uimanager = uim;
      this.child.Realized += new EventHandler(this.OnRealized);
    }

    private void OnRealized(object sender, EventArgs args)
    {
      if (this.uimanager == null)
        return;
      Widget toplevel = this.child.Toplevel;
      if (toplevel != null && typeof (Window).IsInstanceOfType((object) toplevel))
      {
        ((Window) toplevel).AddAccelGroup(this.uimanager.AccelGroup);
        this.uimanager = (UIManager) null;
      }
    }
  }
}
