// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EntryNumWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class EntryNumWidget : EventBox
  {
    private Label imageMenuNoVisible = new Label();
    private string pxText = string.Empty;
    private bool IsMenuLabelVisible = true;
    private bool _status = true;
    private Table table1;
    private UndoEntryIntEx entryNum;
    private ImageCombox imageMenu;
    private Label labTxt;
    private Label lbName;

    public double PxValue { get; set; }

    public double PercentValue { get; set; }

    public bool MenuVisible
    {
      set
      {
        this.imageMenuNoVisible.Visible = true;
        this.imageMenu.Visible = false;
      }
    }

    public bool IsSelectPercent
    {
      get
      {
        return this.imageMenu.IsSelectPercent;
      }
      set
      {
        this.imageMenu.IsSelectPercent = value;
      }
    }

    public double Value
    {
      get
      {
        return this.entryNum.Value;
      }
    }

    public event EventHandler SelectMenuChanged;

    public event EventHandler EntryValueChanged;

    public EntryNumWidget()
    {
      this.table1 = new Table(2U, 3U, false);
      this.table1.Name = "table1";
      this.table1.ColumnSpacing = 6U;
      this.entryNum = new UndoEntryIntEx();
      this.entryNum.WidthRequest = 10;
      this.entryNum.CanFocus = true;
      this.entryNum.Name = "entryNum";
      this.entryNum.IsEditable = true;
      this.entryNum.InvisibleChar = '●';
      this.table1.Add((Widget) this.entryNum);
      Table.TableChild tableChild1 = (Table.TableChild) this.table1[(Widget) this.entryNum];
      tableChild1.XOptions = AttachOptions.Expand | AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.imageMenu = new ImageCombox();
      this.imageMenu.Name = "imageMenu";
      this.table1.Add((Widget) this.imageMenu);
      Table.TableChild tableChild2 = (Table.TableChild) this.table1[(Widget) this.imageMenu];
      tableChild2.LeftAttach = 2U;
      tableChild2.RightAttach = 3U;
      tableChild2.XOptions = AttachOptions.Fill;
      tableChild2.YOptions = AttachOptions.Fill;
      this.labTxt = new Label();
      this.labTxt.Name = "labTxt";
      this.table1.Add((Widget) this.labTxt);
      Table.TableChild tableChild3 = (Table.TableChild) this.table1[(Widget) this.labTxt];
      tableChild3.LeftAttach = 1U;
      tableChild3.RightAttach = 2U;
      tableChild3.XOptions = AttachOptions.Fill;
      tableChild3.YOptions = AttachOptions.Fill;
      this.lbName = new Label();
      this.lbName.Name = "lbName";
      this.table1.Add((Widget) this.lbName);
      Table.TableChild tableChild4 = (Table.TableChild) this.table1[(Widget) this.lbName];
      tableChild4.TopAttach = 1U;
      tableChild4.BottomAttach = 2U;
      tableChild4.XOptions = AttachOptions.Fill;
      tableChild4.YOptions = AttachOptions.Fill;
      this.Add((Widget) this.table1);
      if (this.Child != null)
        this.Child.ShowAll();
      this.imageMenuNoVisible = new Label();
      this.imageMenuNoVisible.WidthRequest = 10;
      this.table1.Attach((Widget) this.imageMenuNoVisible, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.imageMenuNoVisible.Visible = false;
      this.labTxt.WidthRequest = 30;
      this.table1.RowSpacing = 4U;
      Color color = new Color((byte) 165, (byte) 168, (byte) 176);
      this.labTxt.ModifyFg(StateType.Normal, color);
      this.lbName.ModifyFg(StateType.Normal, color);
      this.lbName.SetFontSize(10.0);
      this.labTxt.Text = LanguageInfo.NewFile_Pixel;
      this.imageMenu.MenuChanged += new EventHandler(this.imageMenu_MenuChanged);
      this.entryNum.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.entryNum_EntryValueChanged);
    }

    public void SetLabelText(string str = "%")
    {
      this.labTxt.Text = str;
      this.pxText = str;
    }

    private void entryNum_EntryValueChanged(object sender, EntryIntEventArgs e)
    {
      if (this.EntryValueChanged == null)
        return;
      this.EntryValueChanged((object) this, (EventArgs) new PointEvent(e.Value, 0.0, false));
    }

    private void imageMenu_MenuChanged(object sender, EventArgs e)
    {
      this.entryNum.EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.entryNum_EntryValueChanged);
      this.SetLabel(this.imageMenu.IsSelectPercent);
      this.entryNum.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.entryNum_EntryValueChanged);
      if (this.SelectMenuChanged == null)
        return;
      this.SelectMenuChanged((object) this, new EventArgs());
    }

    public void SetLabel(string str)
    {
      this.lbName.Text = str;
    }

    public void SetSelectType(bool type)
    {
      this.imageMenu.IsSelectPercent = type;
      this.entryNum.EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.entryNum_EntryValueChanged);
      this.SetLabel(this.imageMenu.IsSelectPercent);
      this.entryNum.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.entryNum_EntryValueChanged);
    }

    private void SetLabel(bool status)
    {
      if (!this._status)
        return;
      this.IsSelectPercent = status;
      if (status)
      {
        if (this.IsMenuLabelVisible)
          this.labTxt.Text = "%";
        this.entryNum.Value = this.PercentValue;
      }
      else
      {
        if (this.IsMenuLabelVisible)
          this.labTxt.Text = string.IsNullOrEmpty(this.pxText) ? LanguageInfo.NewFile_Pixel : this.pxText;
        this.entryNum.Value = this.PxValue;
      }
    }

    public void SetEntryPRoperty(bool isInteger, int integerNum, double scrollNum)
    {
      this.entryNum.SetEntryPRoperty(isInteger, integerNum, scrollNum);
    }

    public void SetValue(double pxValue, double percentValue = 0.0, bool status = false)
    {
      this.PxValue = pxValue;
      this.PercentValue = percentValue;
      this.entryNum.Value = pxValue;
      this.SetLabel(status);
    }

    public void SetPositionValue(double value)
    {
      this.entryNum.Value = value;
    }

    public void SetMaxMin(int max, int min)
    {
      this.entryNum.MaxValue = max;
      this.entryNum.MinValue = min;
    }

    public void SetMenuLabel()
    {
      this.labTxt.Text = "";
      this.IsMenuLabelVisible = false;
    }

    public void SetLabelVisible(bool status = false)
    {
      this._status = status;
      this.lbName.Visible = status;
      this.imageMenu.Visible = status;
      this.table1.RowSpacing = 0U;
    }

    public void SetMenuEnable(bool status)
    {
      this.imageMenuNoVisible.Visible = !status;
      this.imageMenu.Visible = status;
      if (!status)
        return;
      this.imageMenu.Show();
    }

    public void SetCanZero(bool value)
    {
      this.entryNum.CanZero = value;
    }

    public void SetWhip(bool status = false, bool allowWhip = true)
    {
      this.entryNum.AllowWhip = allowWhip;
      this.entryNum.IsFouceChanged = true;
      this.SetLabel(status);
      this.entryNum.Text = "-";
      this.entryNum.AllowWhip = false;
    }
  }
}
