// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ScaleNumberEditorWidget
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using System;

namespace CocoStudio.Model.Editor
{
  public class ScaleNumberEditorWidget : NumberEditorWidget
  {
    public event EventHandler<PointEvent> ImageStatusChanged;

    public ScaleNumberEditorWidget(bool showImage = false)
      : base(showImage, false, 30)
    {
      this.PointImage.ImageStatusChanged += new EventHandler<PointEvent>(this.PointImage_ImageStatusChanged);
    }

    private void PointImage_ImageStatusChanged(object sender, PointEvent e)
    {
      if (this.ImageStatusChanged == null)
        return;
      this.ImageStatusChanged(sender, e);
    }

    public void SetImageStatus(bool status)
    {
      this.PointImage.SetCurrentImage(status);
    }
  }
}
