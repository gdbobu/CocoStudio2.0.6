// Decompiled with JetBrains decompiler
// Type: Gtk.RadioButtonImage
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using MonoDevelop.Components;
using System.ComponentModel;

namespace Gtk
{
  [ToolboxItem(true)]
  public class RadioButtonImage : EventBox
  {
    protected Xwt.Drawing.Image checkedImage;
    protected Xwt.Drawing.Image uncheckedImage;
    protected ImageView imageWidget;

    public int Tag { get; set; }

    public string ImageCheck { get; set; }

    public string ImageUnCheck { get; set; }

    public bool Status { get; set; }

    public RadioButtonImage()
    {
      this.imageWidget = new ImageView();
      this.Add((Widget) this.imageWidget);
      this.imageWidget.Show();
    }

    public virtual void Init(string imageUnCheck, string imageCheck, int tag)
    {
      this.ImageCheck = imageCheck;
      this.ImageUnCheck = imageUnCheck;
      this.Tag = tag;
      this.checkedImage = ImageIcon.GetIcon(imageCheck);
      this.uncheckedImage = ImageIcon.GetIcon(imageUnCheck);
      this.imageWidget.Image = this.uncheckedImage;
      this.imageWidget.WidthRequest = 24;
      this.imageWidget.HeightRequest = 24;
      this.imageWidget.Show();
    }

    public void RefreshCheck()
    {
      if (this.Parent != null)
      {
        Container parent = this.Parent as Container;
        if (parent != null)
        {
          foreach (Widget child in parent.Children)
          {
            if (child is RadioButtonImage)
              (child as RadioButtonImage).SetControl();
          }
          this.imageWidget.Image = this.checkedImage;
        }
      }
      this.imageWidget.Image = this.checkedImage;
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      if (this.Parent != null)
      {
        Container parent = this.Parent as Container;
        if (parent != null)
        {
          foreach (Widget child in parent.Children)
          {
            if (child is RadioButtonImage)
              (child as RadioButtonImage).SetControl();
          }
          this.imageWidget.Image = this.checkedImage;
        }
      }
      return base.OnButtonPressEvent(evnt);
    }

    private void SetControl()
    {
      this.imageWidget.Image = this.uncheckedImage;
    }
  }
}
