// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ImageCombox
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Components;
using System;

namespace CocoStudio.ToolKit
{
  public class ImageCombox : EventBox
  {
    private bool isCanClick = true;
    private Menu _contentMenu = new Menu();
    private ImageView imageWidget;

    public bool IsSelectPercent { get; set; }

    public event EventHandler MenuChanged;

    public ImageCombox()
    {
      this.imageWidget = new ImageView();
      this.imageWidget.WidthRequest = 10;
      this.imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.Arrow.png");
      this.Add((Widget) this.imageWidget);
      CheckMenuItem checkMenuItem1 = new CheckMenuItem(string.Format("%{0}", (object) LanguageInfo.Property_ParentPercentage));
      checkMenuItem1.ButtonPressEvent += new ButtonPressEventHandler(this.item1_ButtonPressEvent);
      CheckMenuItem checkMenuItem2 = new CheckMenuItem(LanguageInfo.NewFile_Pixel);
      checkMenuItem2.ButtonPressEvent += new ButtonPressEventHandler(this.item2_ButtonPressEvent);
      this._contentMenu.Add((Widget) checkMenuItem1);
      this._contentMenu.Add((Widget) checkMenuItem2);
      this.ShowAll();
    }

    private void item2_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      this.IsSelectPercent = false;
      (this._contentMenu.Children[0] as CheckMenuItem).Active = false;
      (this._contentMenu.Children[1] as CheckMenuItem).Active = true;
      if (this.MenuChanged == null)
        return;
      this.MenuChanged((object) this, new EventArgs());
    }

    private void item1_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      this.IsSelectPercent = true;
      (this._contentMenu.Children[1] as CheckMenuItem).Active = false;
      (this._contentMenu.Children[0] as CheckMenuItem).Active = true;
      if (this.MenuChanged == null)
        return;
      this.MenuChanged((object) this, new EventArgs());
    }

    protected override bool OnButtonReleaseEvent(EventButton evnt)
    {
      if ((int) evnt.Button != 1 || !this.isCanClick)
        return base.OnButtonReleaseEvent(evnt);
      this.IsFocus = true;
      this._contentMenu.Popup();
      this._contentMenu.ShowAll();
      if (this.IsSelectPercent)
      {
        (this._contentMenu.Children[0] as CheckMenuItem).Active = true;
        (this._contentMenu.Children[1] as CheckMenuItem).Active = false;
      }
      else
      {
        (this._contentMenu.Children[1] as CheckMenuItem).Active = true;
        (this._contentMenu.Children[0] as CheckMenuItem).Active = false;
      }
      this._contentMenu.Popup();
      this._contentMenu.ShowAll();
      return true;
    }
  }
}
