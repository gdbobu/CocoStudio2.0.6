// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.SliderEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class SliderEditorWidget : BaseEditorWidget
  {
    private double changVaule = 1.0;
    private bool _isHscale = false;
    private Table table1;
    private SliderEditorEx hscale1;
    private UndoEntryIntEx entry;
    private Label label;

    public event EventHandler<PointEvent> ValueChanged;

    public SliderEditorWidget()
    {
      this.table1 = new Table(1U, 3U, false);
      this.table1.Name = "table1";
      this.table1.ColumnSpacing = 6U;
      this.hscale1 = new SliderEditorEx(0.0, 100.0, 1.0);
      this.hscale1.CanFocus = true;
      this.hscale1.Name = "hscale1";
      this.hscale1.Adjustment.Upper = 100.0;
      this.hscale1.Adjustment.PageIncrement = 10.0;
      this.hscale1.Adjustment.StepIncrement = 1.0;
      this.hscale1.DrawValue = false;
      this.hscale1.Digits = 0;
      this.hscale1.ValuePos = PositionType.Top;
      this.table1.Add((Widget) this.hscale1);
      ((Table.TableChild) this.table1[(Widget) this.hscale1]).YOptions = AttachOptions.Fill;
      this.entry = new UndoEntryIntEx();
      this.entry.CanFocus = true;
      this.entry.Name = "spinbutton1";
      this.entry.WidthRequest = 40;
      this.table1.Attach((Widget) this.entry, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.label = new Label();
      this.label.WidthRequest = 15;
      this.label.Text = "%";
      this.table1.Attach((Widget) this.label, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.Add((Widget) this.table1);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.entry.MaxValue = 100;
      this.entry.MinValue = 0;
      this.entry.SetEntryPRoperty(true, 1, 1.0);
      this.hscale1.WidthRequest = 20;
      this.AfterEvent();
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
    }

    public void SetValueSize(int min, int max, int step)
    {
      this.changVaule = (double) max / 100.0;
      this.hscale1.Adjustment.Upper = (double) max / this.changVaule;
      this.hscale1.Adjustment.Lower = (double) min;
      this.hscale1.Adjustment.StepIncrement = (double) step;
      this.entry.MaxValue = (int) ((double) max / this.changVaule);
      this.entry.MinValue = min;
    }

    public void SetValueAngle(int min, int max, int step)
    {
      this.changVaule = 1.0;
      this.hscale1.Adjustment.Upper = (double) max;
      this.hscale1.Adjustment.Lower = (double) min;
      this.hscale1.Adjustment.StepIncrement = (double) step;
      this.entry.MaxValue = (int) ((double) max / this.changVaule);
      this.entry.MinValue = min;
    }

    private void BeforEvent()
    {
      this.hscale1.ChangeValue -= new ChangeValueHandler(this.hscale1_ChangeValue);
      this.entry.EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.spinbutton1_EntryValueChanged);
    }

    private void spinbutton1_EntryValueChanged(object sender, EntryIntEventArgs e)
    {
      if (!this._isHscale)
        this.hscale1.Adjustment.Value = this.entry.Value;
      if (this.ValueChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new PointEvent(Math.Round(this.hscale1.Adjustment.Value * this.changVaule, 0), 0.0, false))));
    }

    private void AfterEvent()
    {
      this.hscale1.ChangeValue += new ChangeValueHandler(this.hscale1_ChangeValue);
      this.entry.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.spinbutton1_EntryValueChanged);
    }

    private void hscale1_ChangeValue(object o, ChangeValueArgs args)
    {
      this._isHscale = true;
      this.entry.Value = this.hscale1.Adjustment.Value;
      if (this.ValueChanged != null)
        this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new PointEvent(Math.Round(this.hscale1.Adjustment.Value * this.changVaule, 0), 0.0, false))));
      this._isHscale = false;
    }

    public void SetControl(int value)
    {
      this.BeforEvent();
      double num = Math.Round((double) value / this.changVaule);
      this.hscale1.Adjustment.Value = num;
      this.entry.Value = num;
      this.AfterEvent();
    }

    public void SetLabelText(string str)
    {
      this.label.Text = str;
      this.entry.SetEntryPRoperty(true, 0, 1.0);
      this.entry.MaxValue = 360;
      this.entry.MinValue = 0;
      this.entry.IsRound = true;
    }

    public override void ReadLanuageConfigFile()
    {
    }
  }
}
