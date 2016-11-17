// Decompiled with JetBrains decompiler
// Type: Gtk.ImageBin
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using MonoDevelop.Components;
using Stetic;
using System.ComponentModel;

namespace Gtk
{
  [ToolboxItem(true)]
  public class ImageBin : Bin
  {
    private ImageView CurrentImage;
    private Image image_previewOccupy;

    public ImageBin()
    {
      this.Build();
      this.Remove((Widget) this.image_previewOccupy);
    }

    public void SetImageView(Xwt.Drawing.Image image)
    {
      if (this.CurrentImage != null)
        this.Remove((Widget) this.CurrentImage);
      this.CurrentImage = new ImageView(image);
      this.Add((Widget) this.CurrentImage);
    }

    public ImageView GetImageView()
    {
      return this.CurrentImage;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      BinContainer.Attach((Bin) this);
      this.Name = "Gtk.ImageBin";
      this.image_previewOccupy = new Image();
      this.image_previewOccupy.Name = "image_previewOccupy";
      this.Add((Widget) this.image_previewOccupy);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
    }
  }
}
