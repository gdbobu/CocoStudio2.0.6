// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ContentLabel
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;

namespace CocoStudio.ToolKit
{
  public class ContentLabel : VBox
  {
    private Table _table;
    private Label _label;

    public ContentLabel(int width = 90)
    {
      this._table = new Table(1U, 1U, true);
      this._label = new Label();
      Alignment alignment = new Alignment(1f, 0.0f, 0.0f, 0.0f);
      alignment.TopPadding = 4U;
      alignment.Add((Widget) this._label);
      alignment.WidthRequest = width;
      this._table.Attach((Widget) alignment, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.Add((Widget) this._table);
      this._table.ShowAll();
    }

    public void SetLabelText(string str)
    {
      this._label.LabelProp = str;
    }
  }
}
