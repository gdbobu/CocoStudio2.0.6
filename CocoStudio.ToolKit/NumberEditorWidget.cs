// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.NumberEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class NumberEditorWidget : BaseEditorWidget, INumberEntry
  {
    private bool isRotation = false;
    private bool canZero = true;
    private bool labelVisible = true;
    private Table PointTable;
    public EntryNumWidget X;
    public EntryNumWidget Y;
    protected NumberButtonImage PointImage;
    private Label PointLabel;

    public bool ShowImage { get; set; }

    public bool CanZero
    {
      get
      {
        return this.canZero;
      }
      set
      {
        this.canZero = value;
        this.X.SetCanZero(this.canZero);
        this.Y.SetCanZero(this.canZero);
      }
    }

    public event EventHandler<PointEvent> PointX;

    public event EventHandler<PointEvent> PointY;

    public event EventHandler<UIControlEvent> PerCentChanged;

    public NumberEditorWidget(bool showImage = false, bool isAve = false, int width = 30)
    {
      this.ShowImage = showImage;
      this.isRotation = isAve;
      this.PointTable = new Table(1U, 3U, false);
      this.X = new EntryNumWidget();
      this.Y = new EntryNumWidget();
      if (isAve)
      {
        this.X.EntryValueChanged += new EventHandler(this.X_EntryValueChanged);
        this.PointTable.Attach((Widget) this.X, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Expand | AttachOptions.Fill, 0U, 0U);
        Label label = new Label();
        label.WidthRequest = this.X.WidthRequest;
        this.PointTable.Attach((Widget) label, 2U, 3U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Expand | AttachOptions.Fill, 0U, 0U);
      }
      else
      {
        this.X.EntryValueChanged += new EventHandler(this.X_EntryValueChanged);
        this.Y.EntryValueChanged += new EventHandler(this.Y_EntryValueChanged);
        this.X.SelectMenuChanged += new EventHandler(this.SelectMenuChanged);
        this.Y.SelectMenuChanged += new EventHandler(this.SelectMenuChanged);
        this.PointTable.Attach((Widget) this.X, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Expand | AttachOptions.Fill, 0U, 0U);
        this.PointTable.Attach((Widget) this.Y, 2U, 3U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Expand | AttachOptions.Fill, 0U, 0U);
      }
      if (this.ShowImage)
      {
        this.PointImage = new NumberButtonImage();
        this.PointImage.WidthRequest = 30;
        this.PointImage.SetCurrentImage(false);
        this.PointTable.Attach((Widget) this.PointImage, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      else
      {
        this.PointLabel = new Label();
        this.PointLabel.WidthRequest = width;
        this.PointTable.Attach((Widget) this.PointLabel, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Shrink, 0U, 0U);
      }
      this.Add((Widget) this.PointTable);
      this.ShowAll();
      if (!isAve)
        return;
      this.X.SetLabelVisible(false);
      this.labelVisible = false;
    }

    private void Y_EntryValueChanged(object sender, EventArgs e)
    {
      if (this.PointY == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.PointY((object) null, new PointEvent(this.Y.Value, this.Y.Value, this.PointImage != null && this.PointImage.IsCheck))));
    }

    private void X_EntryValueChanged(object sender, EventArgs e)
    {
      if (this.PointX == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.PointX((object) null, new PointEvent(this.X.Value, this.X.Value, this.PointImage != null && this.PointImage.IsCheck))));
    }

    private void SelectMenuChanged(object sender, EventArgs e)
    {
      if (!this.isRotation)
      {
        this.X.SetSelectType((sender as EntryNumWidget).IsSelectPercent);
        this.Y.SetSelectType((sender as EntryNumWidget).IsSelectPercent);
      }
      if (this.PerCentChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.PerCentChanged((object) null, new UIControlEvent("", this.Y.IsSelectPercent, 0.0))));
    }

    public void SetMenuVisble(bool isVisible)
    {
      this.X.MenuVisible = this.Y.MenuVisible = isVisible;
    }

    public void SetValue(double x, double y, bool status = false)
    {
      this.X.IsSelectPercent = this.Y.IsSelectPercent = status;
      this.X.SetValue(x, 0.0, false);
      this.Y.SetValue(y, 0.0, false);
    }

    public void SetX(double x)
    {
      this.X.SetValue(x, 0.0, false);
    }

    public void SetY(double y)
    {
      this.Y.SetValue(y, 0.0, false);
    }

    public void SetEntryPRoperty(bool isInteger, int integerNum, double scrollNum)
    {
      this.X.SetEntryPRoperty(isInteger, integerNum, scrollNum);
      this.Y.SetEntryPRoperty(isInteger, integerNum, scrollNum);
    }

    public void SetLabel(string x = "X轴", string y = "Y轴")
    {
      this.X.SetLabel(x);
      this.Y.SetLabel(y);
    }

    public void SetMenuLabel()
    {
      this.X.SetMenuLabel();
      this.Y.SetMenuLabel();
      this.labelVisible = false;
    }

    public void SetMaxMin(int max, int min)
    {
      this.X.SetMaxMin(max, min);
      this.Y.SetMaxMin(max, min);
    }

    public void SetLabelText(string str = "%")
    {
      this.X.SetLabelText(str);
      this.Y.SetLabelText(str);
    }

    public void SetWhipX(bool isPrecent = false)
    {
      this.X.SetWhip(isPrecent, true);
    }

    public void SetWhipY(bool isPrecent = false)
    {
      this.Y.SetWhip(isPrecent, true);
    }

    public override void ReadLanuageConfigFile()
    {
    }

    public bool GetMenuVisble()
    {
      return this.labelVisible;
    }
  }
}
