// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ImageEx
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class ImageEx : RadioButtonImage
  {
    public new void Init(string imageUnCheck, string imageCheck, int tag)
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
  }
}
