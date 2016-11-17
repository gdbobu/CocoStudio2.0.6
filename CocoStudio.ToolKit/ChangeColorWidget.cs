// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.ChangeColorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;
using Gtk.Controls;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class ChangeColorWidget : BaseEditorWidget
  {
    private Table table;
    private Label comboxLabel;
    private ComBoxEx comboBox_colorType;
    private ColorEx singleColorEditor;
    private Label SingleColorSet;
    private Label StartColorSet;
    private ColorEx firstColorEditor;
    private ColorEx endColorEditor;
    private Label EndColorSet;
    private Label directLabel;
    private SliderEditorWidget directSlider;
    private Label bgLabel;
    private SliderEditorWidget bgSlider;

    public event EventHandler<ColorEvent> ColorChanged;

    public event EventHandler<ComBoxEvnent> ComBoxChanged;

    public event EventHandler<ColorEvent> ChangedColorChanged;

    public event EventHandler<PointColorEvent> PointEventChanged;

    public ChangeColorWidget()
    {
      this.table = new Table(6U, 3U, false);
      this.table.Name = "table1";
      this.table.ColumnSpacing = 6U;
      this.comboxLabel = new Label();
      this.comboxLabel.Xalign = 1f;
      this.table.Attach((Widget) this.comboxLabel, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.comboBox_colorType = new ComBoxEx();
      this.table.Attach((Widget) this.comboBox_colorType, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      Label label = new Label();
      label.WidthRequest = 70;
      this.table.Attach((Widget) label, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      label.Show();
      this.SingleColorSet = new Label();
      this.SingleColorSet.Xalign = 1f;
      this.table.Attach((Widget) this.SingleColorSet, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.singleColorEditor = new ColorEx();
      this.table.Attach((Widget) this.singleColorEditor, 1U, 2U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.StartColorSet = new Label();
      this.StartColorSet.Xalign = 1f;
      this.table.Attach((Widget) this.StartColorSet, 0U, 1U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firstColorEditor = new ColorEx();
      this.table.Attach((Widget) this.firstColorEditor, 1U, 2U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.EndColorSet = new Label();
      this.EndColorSet.Xalign = 1f;
      this.table.Attach((Widget) this.EndColorSet, 0U, 1U, 3U, 4U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.endColorEditor = new ColorEx();
      this.table.Attach((Widget) this.endColorEditor, 1U, 2U, 3U, 4U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.directLabel = new Label();
      this.directLabel.Text = LanguageInfo.Changed_Direction;
      this.directLabel.Xalign = 1f;
      this.table.Attach((Widget) this.directLabel, 0U, 1U, 5U, 6U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.directSlider = new SliderEditorWidget();
      this.table.Attach((Widget) this.directSlider, 1U, 3U, 5U, 6U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.directSlider.SetLabelText(LanguageOption.CurrentLanguage == LanguageType.Chinese ? "度" : "°");
      this.bgLabel = new Label();
      this.bgLabel.Text = LanguageInfo.Background_color_transparency;
      this.bgLabel.Xalign = 1f;
      this.table.Attach((Widget) this.bgLabel, 0U, 1U, 4U, 5U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.bgSlider = new SliderEditorWidget();
      this.table.Attach((Widget) this.bgSlider, 1U, 3U, 4U, 5U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.Add((Widget) this.table);
      this.table.RowSpacing = 2U;
      if (this.Child != null)
        this.Child.ShowAll();
      this.Add((Widget) this.table);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.bgSlider.SetValueSize(0, (int) byte.MaxValue, 1);
      this.directSlider.SetValueAngle(0, 360, 1);
      this.ReadLanuageConfigFile();
      this.comboxLabel.WidthRequest = 90;
      this.ControlVisible();
      this.singleColorEditor.Visible = this.SingleColorSet.Visible = true;
      this.AfterEvent();
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
    }

    private void ControlVisible()
    {
      this.bgLabel.Visible = this.bgSlider.Visible = false;
      this.directLabel.Visible = this.directSlider.Visible = false;
      this.endColorEditor.Visible = this.EndColorSet.Visible = false;
      this.StartColorSet.Visible = this.firstColorEditor.Visible = false;
      this.singleColorEditor.Visible = this.SingleColorSet.Visible = false;
    }

    public void BeforEvent()
    {
      this.comboBox_colorType.Changed -= new EventHandler(this.comboBox_colorType_Changed);
      this.singleColorEditor.ColorChanged -= new EventHandler<ColorExEvent>(this.singleColorEditor_ColorSet);
      this.firstColorEditor.ColorChanged -= new EventHandler<ColorExEvent>(this.firstColorEditor_ColorSet);
      this.endColorEditor.ColorChanged -= new EventHandler<ColorExEvent>(this.endColorEditor_ColorSet);
      this.directSlider.ValueChanged -= new EventHandler<PointEvent>(this.slider_ValueChanged);
      this.bgSlider.ValueChanged -= new EventHandler<PointEvent>(this.bgSlider_ValueChanged);
    }

    private void bgSlider_ValueChanged(object sender, PointEvent e)
    {
      if (this.PointEventChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.PointEventChanged((object) null, new PointColorEvent(e.PointX, 1))));
    }

    private void slider_ValueChanged(object sender, PointEvent e)
    {
      if (this.PointEventChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.PointEventChanged((object) null, new PointColorEvent(e.PointX, 0))));
    }

    public void AfterEvent()
    {
      this.comboBox_colorType.Changed += new EventHandler(this.comboBox_colorType_Changed);
      this.singleColorEditor.ColorChanged += new EventHandler<ColorExEvent>(this.singleColorEditor_ColorSet);
      this.firstColorEditor.ColorChanged += new EventHandler<ColorExEvent>(this.firstColorEditor_ColorSet);
      this.endColorEditor.ColorChanged += new EventHandler<ColorExEvent>(this.endColorEditor_ColorSet);
      this.directSlider.ValueChanged += new EventHandler<PointEvent>(this.slider_ValueChanged);
      this.bgSlider.ValueChanged += new EventHandler<PointEvent>(this.bgSlider_ValueChanged);
    }

    private void endColorEditor_ColorSet(object sender, EventArgs e)
    {
      if (this.ChangedColorChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ChangedColorChanged((object) null, new ColorEvent(this.endColorEditor.color.CurrentColor, 1))));
    }

    private void firstColorEditor_ColorSet(object sender, EventArgs e)
    {
      if (this.ChangedColorChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ChangedColorChanged((object) null, new ColorEvent(this.firstColorEditor.color.CurrentColor, 0))));
    }

    private void singleColorEditor_ColorSet(object sender, EventArgs e)
    {
      if (this.ColorChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ColorChanged((object) null, new ColorEvent(this.singleColorEditor.color.CurrentColor, 0))));
    }

    private void comboBox_colorType_Changed(object sender, EventArgs e)
    {
      this.ComBoxChange();
      if (this.ComBoxChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ComBoxChanged((object) null, new ComBoxEvnent(this.comboBox_colorType.Active))));
    }

    public void SetControl(Color color, int index, Color firColor, Color endColor, int angle)
    {
      this.comboBox_colorType.Active = index;
      this.singleColorEditor.SetColor(color);
      this.ComBoxChange();
      this.firstColorEditor.SetColor(firColor);
      this.endColorEditor.SetColor(endColor);
      this.directSlider.SetControl(angle);
    }

    public void SetBGAlthl(int bg)
    {
      this.bgSlider.SetControl(bg);
    }

    private void ComBoxChange()
    {
      this.ControlVisible();
      if (this.comboBox_colorType.Active == 1)
      {
        this.singleColorEditor.Visible = this.SingleColorSet.Visible = true;
        this.bgLabel.Visible = this.bgSlider.Visible = true;
      }
      else
      {
        if (this.comboBox_colorType.Active != 2)
          return;
        this.bgLabel.Visible = this.bgSlider.Visible = true;
        this.directLabel.Visible = this.directSlider.Visible = true;
        this.endColorEditor.Visible = this.EndColorSet.Visible = true;
        this.StartColorSet.Visible = this.firstColorEditor.Visible = true;
      }
    }

    public override void ReadLanuageConfigFile()
    {
      this.comboxLabel.Text = LanguageInfo.Fill_color;
      this.SingleColorSet.Text = LanguageInfo.Single_color_set;
      this.StartColorSet.Text = LanguageInfo.Start_color_set;
      this.EndColorSet.Text = LanguageInfo.End_color_set;
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      listStore.AppendValues(new object[1]
      {
        (object) LanguageInfo.color_none
      });
      listStore.AppendValues(new object[1]
      {
        (object) LanguageInfo.color_solid
      });
      listStore.AppendValues(new object[1]
      {
        (object) LanguageInfo.color_gradient
      });
      this.comboBox_colorType.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      this.comboBox_colorType.PackStart((CellRenderer) cellRendererText, true);
      this.comboBox_colorType.AddAttribute((CellRenderer) cellRendererText, "text", 0);
    }
  }
}
