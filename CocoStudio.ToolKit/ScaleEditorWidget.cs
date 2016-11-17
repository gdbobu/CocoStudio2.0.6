// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ScaleEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class ScaleEditorWidget : NumberEditorWidget
  {
    public bool IsEnable { get; set; }

    public ScaleEditorWidget(bool showImage = false)
      : base(showImage, false, 30)
    {
      this.X.SetEntryPRoperty(false, 2, 0.1);
      this.Y.SetEntryPRoperty(false, 2, 0.1);
    }

    public void SetInit(double minNum, double maxNum, double step = 0.01, uint digit = 2)
    {
    }

    public void SetXValue(double value)
    {
      this.X.SetValue(value, 0.0, false);
    }

    public void SetYValue(double value)
    {
      this.Y.SetValue(value, 0.0, false);
    }
  }
}
