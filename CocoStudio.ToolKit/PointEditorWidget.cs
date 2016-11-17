// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PointEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class PointEditorWidget : NumberEditorWidget
  {
    public PointEditorWidget(bool showImage = false)
      : base(showImage, false, 30)
    {
      this.X.SetEntryPRoperty(false, 0, 1.0);
      this.Y.SetEntryPRoperty(false, 0, 1.0);
    }

    public void SetXValue(double value, double percentValue = 0.0, bool status = false)
    {
      this.X.SetValue(value, percentValue, status);
    }

    public void SetYValue(double value, double percentValue = 0.0, bool status = false)
    {
      this.Y.SetValue(value, percentValue, status);
    }

    public void SetMenu(bool status)
    {
      this.X.SetMenuEnable(status);
      this.Y.SetMenuEnable(status);
    }
  }
}
