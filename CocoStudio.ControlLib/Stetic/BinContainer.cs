// Decompiled with JetBrains decompiler
// Type: Stetic.BinContainer
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

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
