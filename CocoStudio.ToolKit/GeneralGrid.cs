// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.GeneralGrid
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CocoStudio.ToolKit
{
  public class GeneralGrid : EventBox
  {
    private ArrayList propertyTabs = new ArrayList();
    private Box contentBox;

    public Box ContentBox
    {
      get
      {
        return this.contentBox;
      }
    }

    public event EventHandler<TabEventArgs> TabChanged;

    public GeneralGrid()
    {
    }

    public GeneralGrid(List<string> title, int type = 0, int selectTab = 0)
    {
      if (title == null)
        return;
      this.contentBox = type != 0 ? (Box) new VBox() : (Box) new HBox();
      for (int tag = 0; tag < title.Count; ++tag)
        this.AddPropertyTab(this.contentBox, new TabLabel(title[tag]), tag, selectTab);
      Table table = new Table(1U, 1U, false);
      table.BorderWidth = 1U;
      TabLabel tabLabel = new TabLabel("");
      tabLabel.ModifyBg(StateType.Normal, WindowStyle.WindowColor3B);
      table.Attach((Widget) tabLabel, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      table.ShowAll();
      this.contentBox.PackStart((Widget) table, true, true, 0U);
      ((Box.BoxChild) this.contentBox[(Widget) table]).Position = 2;
      this.contentBox.ShowAll();
      this.Add((Widget) this.contentBox);
      this.ShowAll();
      this.ModifyBg(StateType.Normal, WindowStyle.WindowLineColor);
    }

    private void AddPropertyTab(Box box, TabLabel tab, int tag = 0, int selectTab = 0)
    {
      Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment.LeftPadding = tag != 0 ? 1U : 0U;
      if (selectTab == tag)
      {
        alignment.BottomPadding = 0U;
        tab.ModifyBg(StateType.Normal, WindowStyle.WindowPanelColor);
      }
      else
      {
        alignment.BottomPadding = 1U;
        tab.ModifyBg(StateType.Normal, WindowStyle.WindowColor3B);
      }
      alignment.TopPadding = 1U;
      tab.WidthRequest = 76;
      tab.Tag = tag;
      alignment.Add((Widget) tab);
      alignment.ShowAll();
      box.PackStart((Widget) alignment, false, false, 0U);
      ((Box.BoxChild) box[(Widget) tab]).Position = this.propertyTabs.Count;
      alignment.Show();
      tab.Click += new EventHandler(this.tab_Click);
    }

    private void tab_Click(object sender, EventArgs e)
    {
      if (this.TabChanged == null)
        return;
      this.TabChanged((object) this, new TabEventArgs((sender as TabLabel).Tag));
    }
  }
}
