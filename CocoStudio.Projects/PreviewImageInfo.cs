// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PreviewImageInfo
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Xwt;
using Xwt.Drawing;

namespace CocoStudio.Projects
{
  public class PreviewImageInfo
  {
    public Size Size { get; internal set; }

    public Image Image { get; internal set; }

    public PreviewImageInfo(Size size, Image image)
    {
      this.Size = size;
      this.Image = image;
    }

    public PreviewImageInfo()
    {
    }
  }
}
