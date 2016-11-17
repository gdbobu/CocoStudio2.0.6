// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.TabLabel
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;

namespace CocoStudio.ToolKit
{
  public class TabLabel : EventBox
  {
    public int Tag { get; set; }

    public event EventHandler Click;

    public TabLabel(string str = "")
    {
      Label label = new Label();
      label.Text = str;
      this.HeightRequest = 20;
      this.Add((Widget) label);
      this.ShowAll();
      this.ButtonPressEvent += new ButtonPressEventHandler(this.TabLabel_ButtonPressEvent);
    }

    private void TabLabel_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      if (this.Click == null)
        return;
      Box parent = this.Parent.Parent as Box;
      if (parent != null)
      {
        foreach (Widget child1 in parent.Children)
        {
          Alignment alignment = child1 as Alignment;
          if (alignment != null)
          {
            TabLabel child2 = alignment.Children[0] as TabLabel;
            if (child2.Tag == this.Tag)
            {
              alignment.BottomPadding = 0U;
              child2.ModifyBg(StateType.Normal, WindowStyle.WindowPanelColor);
            }
            else
            {
              alignment.BottomPadding = 1U;
              child2.ModifyBg(StateType.Normal, WindowStyle.WindowColor3B);
            }
          }
        }
      }
      this.Click((object) this, new EventArgs());
    }
  }
}
