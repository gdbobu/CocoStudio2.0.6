// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ComponentGrid
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;

namespace CocoStudio.ToolKit
{
  public class ComponentGrid
  {
    private PropertyGridExpand expand;

    public string ComponentType { get; set; }

    public string ComoonentNmae { get; set; }

    public Table ComponentTable { get; set; }

    public object CurrentObject { get; set; }

    public event EventHandler DeleteComponent;

    public ComponentGrid(string name = "")
    {
      this.expand = new PropertyGridExpand(new EditorManager(), (PropertyGrid) null);
      this.ComponentTable = new Table(2U, 1U, false);
      Table table = new Table(1U, 2U, false);
      Label label = new Label();
      table.Attach((Widget) label, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      label.Show();
      Button button = new Button();
      table.Attach((Widget) button, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      button.Show();
      this.ComponentTable.Attach((Widget) table, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      table.Show();
      this.expand.ExpandTable.Show();
    }
  }
}
