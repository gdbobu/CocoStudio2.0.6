// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.UIControlSizeEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;
using Gtk.Controls;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.ToolKit
{
  public class UIControlSizeEditorWidget : BaseEditorWidget
  {
    private Alignment labelScale = new Alignment(1f, 0.0f, 0.0f, 0.0f);
    private Alignment alighAuto = new Alignment(1f, 0.0f, 0.0f, 0.0f);
    private Label labelAuto = new Label();
    private Table tableCheck = new Table(1U, 2U, false);
    private Alignment alignment1;
    private Table table2;
    private CheckButtonEx preSizeEnabled;
    private PointEditorWidget rectSize;
    private CheckButtonEx scale9Enabled;
    private PointEditorWidget scaleOLRValue;
    private PointEditorWidget scaleTBValue;
    private Label txtSize;
    private Label scale9Lable;

    public bool Scale9Support { get; set; }

    public bool Scale9Enable { get; set; }

    public bool CustomStateOnly { get; set; }

    public bool IsNode { get; set; }

    public bool IsEnable { get; set; }

    public bool IsPanel { get; set; }

    public event EventHandler<UIControlEvent> SQuardValueChanged;

    public UIControlSizeEditorWidget()
    {
      this.alignment1 = new Alignment(0.5f, 0.5f, 1f, 1f);
      this.alignment1.Name = "alignment1";
      this.table2 = new Table(5U, 2U, false);
      this.table2.Name = "table2";
      this.table2.ColumnSpacing = 6U;
      this.preSizeEnabled = new CheckButtonEx();
      this.preSizeEnabled.CanFocus = true;
      this.preSizeEnabled.Name = "preSizeEnabled";
      this.preSizeEnabled.DrawIndicator = true;
      this.preSizeEnabled.UseUnderline = true;
      this.table2.Add((Widget) this.preSizeEnabled);
      Table.TableChild tableChild1 = (Table.TableChild) this.table2[(Widget) this.preSizeEnabled];
      tableChild1.TopAttach = 0U;
      tableChild1.BottomAttach = 1U;
      tableChild1.LeftAttach = 1U;
      tableChild1.RightAttach = 2U;
      tableChild1.XOptions = AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.rectSize = new PointEditorWidget(false);
      this.rectSize.Events = EventMask.ButtonPressMask;
      this.rectSize.Name = "rectSize";
      this.table2.Add((Widget) this.rectSize);
      Table.TableChild tableChild2 = (Table.TableChild) this.table2[(Widget) this.rectSize];
      tableChild2.TopAttach = 4U;
      tableChild2.BottomAttach = 5U;
      tableChild2.LeftAttach = 1U;
      tableChild2.RightAttach = 2U;
      tableChild2.YOptions = AttachOptions.Fill;
      this.scale9Enabled = new CheckButtonEx();
      this.scale9Enabled.CanFocus = true;
      this.scale9Enabled.Name = "scale9Enabled";
      this.scale9Enabled.DrawIndicator = true;
      this.scale9Enabled.UseUnderline = true;
      this.tableCheck.Attach((Widget) this.scale9Enabled, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.tableCheck.Attach((Widget) new Label(), 1U, 2U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
      this.tableCheck.ShowAll();
      this.table2.Add((Widget) this.tableCheck);
      Table.TableChild tableChild3 = (Table.TableChild) this.table2[(Widget) this.tableCheck];
      tableChild3.TopAttach = 1U;
      tableChild3.BottomAttach = 2U;
      tableChild3.LeftAttach = 1U;
      tableChild3.RightAttach = 2U;
      tableChild3.XOptions = AttachOptions.Fill;
      tableChild3.YOptions = AttachOptions.Fill;
      this.scaleOLRValue = new PointEditorWidget(false);
      this.scaleOLRValue.Events = EventMask.ButtonPressMask;
      this.scaleOLRValue.Name = "scaleOriginValue";
      this.table2.Add((Widget) this.scaleOLRValue);
      Table.TableChild tableChild4 = (Table.TableChild) this.table2[(Widget) this.scaleOLRValue];
      tableChild4.TopAttach = 2U;
      tableChild4.BottomAttach = 3U;
      tableChild4.LeftAttach = 1U;
      tableChild4.RightAttach = 2U;
      tableChild4.XOptions = AttachOptions.Fill;
      tableChild4.YOptions = AttachOptions.Fill;
      this.scaleTBValue = new PointEditorWidget(false);
      this.scaleTBValue.Events = EventMask.ButtonPressMask;
      this.scaleTBValue.Name = "scaleSizeValue";
      this.table2.Add((Widget) this.scaleTBValue);
      Table.TableChild tableChild5 = (Table.TableChild) this.table2[(Widget) this.scaleTBValue];
      tableChild5.TopAttach = 3U;
      tableChild5.BottomAttach = 4U;
      tableChild5.LeftAttach = 1U;
      tableChild5.RightAttach = 2U;
      tableChild5.XOptions = AttachOptions.Fill;
      tableChild5.YOptions = AttachOptions.Fill;
      this.txtSize = new Label();
      Alignment alignment = new Alignment(1f, 0.0f, 0.0f, 0.0f);
      alignment.Add((Widget) this.txtSize);
      this.txtSize.Xalign = 1f;
      this.table2.Add((Widget) alignment);
      alignment.ShowAll();
      Table.TableChild tableChild6 = (Table.TableChild) this.table2[(Widget) alignment];
      tableChild6.TopAttach = 4U;
      tableChild6.BottomAttach = 5U;
      tableChild6.XOptions = (AttachOptions) 0;
      tableChild6.YOptions = AttachOptions.Fill;
      this.alignment1.Add((Widget) this.table2);
      this.scale9Lable = new Label();
      this.labelScale.Add((Widget) this.scale9Lable);
      this.labelScale.Xalign = 1f;
      this.labelScale.ShowAll();
      this.scale9Lable.Text = LanguageInfo.Display_Sudoku;
      this.table2.Attach((Widget) this.labelScale, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.alighAuto.Add((Widget) this.labelAuto);
      this.alighAuto.Xalign = 1f;
      this.table2.Attach((Widget) this.alighAuto, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.alighAuto.ShowAll();
      this.Add((Widget) this.alignment1);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.ReadLanuageConfigFile();
      this.AfterEvent();
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
      this.txtSize.WidthRequest = 90;
      this.rectSize.SetMaxMin(int.MaxValue, 0);
      this.rectSize.SetLabel(LanguageInfo.NewFile_Width, LanguageInfo.NewFile_Height);
      this.scaleOLRValue.SetMaxMin(int.MaxValue, 0);
      this.scaleTBValue.SetMaxMin(int.MaxValue, 0);
      this.scaleOLRValue.SetLabel(LanguageInfo.TopEdge, LanguageInfo.BottomEdge);
      this.scaleTBValue.SetLabel(LanguageInfo.LeftEdge, LanguageInfo.RightEdge);
      this.scaleOLRValue.SetMenuVisble(false);
      this.scaleTBValue.SetMenuVisble(false);
      this.SetScale9(false);
    }

    public void SetScale9(bool status)
    {
      this.labelScale.Visible = this.tableCheck.Visible = this.scaleOLRValue.Visible = this.scaleTBValue.Visible = status;
    }

    public void AfterEvent()
    {
      this.preSizeEnabled.Clicked += new EventHandler(this.preSizeEnabled_Clicked);
      this.scale9Enabled.Clicked += new EventHandler(this.scale9Enabled_Clicked);
      this.rectSize.PerCentChanged += new EventHandler<UIControlEvent>(this.rectSize_PerCentChanged);
      this.rectSize.PointX += new EventHandler<PointEvent>(this.rectSize_PointX);
      this.rectSize.PointY += new EventHandler<PointEvent>(this.rectSize_PointY);
      this.scaleOLRValue.PointX += new EventHandler<PointEvent>(this.scaleOriginValue_PointX);
      this.scaleOLRValue.PointY += new EventHandler<PointEvent>(this.scaleOriginValue_PointY);
      this.scaleTBValue.PointX += new EventHandler<PointEvent>(this.scaleSizeValue_PointX);
      this.scaleTBValue.PointY += new EventHandler<PointEvent>(this.scaleSizeValue_PointY);
    }

    public void BeforEvent()
    {
      this.preSizeEnabled.Clicked -= new EventHandler(this.preSizeEnabled_Clicked);
      this.scale9Enabled.Clicked -= new EventHandler(this.scale9Enabled_Clicked);
      this.rectSize.PerCentChanged -= new EventHandler<UIControlEvent>(this.rectSize_PerCentChanged);
      this.rectSize.PointX -= new EventHandler<PointEvent>(this.rectSize_PointX);
      this.rectSize.PointY -= new EventHandler<PointEvent>(this.rectSize_PointY);
      this.scaleOLRValue.PointX -= new EventHandler<PointEvent>(this.scaleOriginValue_PointX);
      this.scaleOLRValue.PointY -= new EventHandler<PointEvent>(this.scaleOriginValue_PointY);
      this.scaleTBValue.PointX -= new EventHandler<PointEvent>(this.scaleSizeValue_PointX);
      this.scaleTBValue.PointY -= new EventHandler<PointEvent>(this.scaleSizeValue_PointY);
    }

    public void SetMenuEnable(bool status)
    {
      this.rectSize.SetMenu(status);
    }

    private void SetpreSizeEnabled(bool status)
    {
      this.rectSize.Sensitive = status;
    }

    private void SetSacle9EndbleStatus(bool status)
    {
      this.rectSize.Sensitive = this.scaleOLRValue.Sensitive = this.scaleTBValue.Sensitive = status;
      if (!this.IsPanel)
        return;
      this.rectSize.Sensitive = true;
    }

    public void SetSizeTypeMode(bool modeState, bool isPrecent, double x, double y, double px = 0.0, double py = 0.0)
    {
      this.alighAuto.Visible = this.preSizeEnabled.Visible = true;
      this.preSizeEnabled.Active = !modeState;
      this.scale9Enabled.Sensitive = false;
      this.rectSize.Sensitive = modeState;
      this.rectSize.SetXValue((double) (int) x, px, isPrecent);
      this.rectSize.SetYValue((double) (int) y, py, isPrecent);
    }

    public void SetScale9Mode(bool bPanel, bool isPrecent, double x, double y, double px = 0.0, double py = 0.0)
    {
      this.alighAuto.Visible = this.preSizeEnabled.Visible = false;
      this.preSizeEnabled.Active = false;
      this.scale9Enabled.Sensitive = true;
      this.IsPanel = bPanel;
      this.rectSize.SetXValue((double) (int) x, px, isPrecent);
      this.rectSize.SetYValue((double) (int) y, py, isPrecent);
    }

    public void SetShowOnlyMode(bool mode, bool isPrecent, double x, double y, double px = 0.0, double py = 0.0)
    {
      this.alighAuto.Visible = this.preSizeEnabled.Visible = false;
      this.preSizeEnabled.Active = false;
      this.scale9Enabled.Sensitive = false;
      this.scaleOLRValue.Sensitive = false;
      this.scaleTBValue.Sensitive = false;
      this.rectSize.Sensitive = mode;
      this.rectSize.SetXValue((double) (int) x, px, isPrecent);
      this.rectSize.SetYValue((double) (int) y, py, isPrecent);
    }

    public void SetMode(bool mode, bool isPrecent, double x, double y, double px = 0.0, double py = 0.0)
    {
      this.alighAuto.Visible = this.preSizeEnabled.Visible = mode;
      this.preSizeEnabled.Active = mode;
      this.rectSize.Sensitive = mode;
      this.scale9Enabled.Sensitive = !mode;
      this.rectSize.SetXValue((double) (int) x, px, isPrecent);
      this.rectSize.SetYValue((double) (int) y, py, isPrecent);
    }

    private void rectSize_PerCentChanged(object sender, UIControlEvent e)
    {
      if (this.SQuardValueChanged == null)
        return;
      this.SQuardValueChanged((object) null, new UIControlEvent("preSizeEnabled_Clicked", e.IsCheck, 0.0));
    }

    public void SetSquard(bool status, double x, double y, double w, double h)
    {
      this.SetScale9(true);
      this.scale9Enabled.Active = status;
      this.scaleOLRValue.SetXValue(x, 0.0, false);
      this.scaleOLRValue.SetYValue(y, 0.0, false);
      this.scaleTBValue.SetXValue(w, 0.0, false);
      this.scaleTBValue.SetYValue(h, 0.0, false);
      this.SetSacle9EndbleStatus(this.scale9Enabled.Sensitive && this.scale9Enabled.Active);
    }

    private void scaleSizeValue_PointY(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("Right", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void scaleSizeValue_PointX(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("Left", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void rectSizePre_PointY(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("rectSizePre_PointY", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void rectSizePre_PointX(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("rectSizePre_PointX", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void scaleOriginValue_PointY(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("Bottom", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void scaleOriginValue_PointX(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("Top", this.scale9Enabled.Active, e.PointX));
      }));
    }

    private void scale9Enabled_Clicked(object sender, EventArgs e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        this.SetSacle9EndbleStatus(this.scale9Enabled.Active);
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("scale9Enabled_Clicked", this.scale9Enabled.Active, 0.0));
      }));
    }

    private void preSizeEnabled_Clicked(object sender, EventArgs e)
    {
      this.rectSize.Sensitive = this.scale9Enabled.Sensitive = !this.preSizeEnabled.Active;
      if (this.SQuardValueChanged == null)
        return;
      this.SQuardValueChanged((object) null, new UIControlEvent("comboBox_modeType_Changed", this.preSizeEnabled.Active, 0.0));
    }

    private void rectSize_PointY(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("rectSize_PointY", false, e.PointX));
      }));
    }

    private void rectSize_PointX(object sender, PointEvent e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.SQuardValueChanged == null)
          return;
        this.SQuardValueChanged((object) null, new UIControlEvent("rectSize_PointX", false, e.PointX));
      }));
    }

    public override void ReadLanuageConfigFile()
    {
      this.txtSize.Text = LanguageInfo.UI_ControlLayout_txtSize;
      this.labelAuto.Text = LanguageInfo.Control_mode;
    }
  }
}
