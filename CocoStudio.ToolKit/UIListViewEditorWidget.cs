// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.UIListViewEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.ToolKit
{
  public class UIListViewEditorWidget : BaseEditorWidget
  {
    private int _hor = 0;
    private int _ver = 0;
    private Table table;
    private ComBoxEx directionCombox;
    private Label directionText;
    private ComBoxEx horizontalCombox;
    private Label horizontalText;
    private ComBoxEx verticalCombox;
    private Label verticalText;
    private Label lbHor;
    private Label lbVer;
    private Label lbBottom;

    public event EventHandler<ListViewEvent> ValueChanged;

    public UIListViewEditorWidget()
    {
      this.table = new Table(6U, 3U, false);
      this.lbHor = new Label();
      this.lbVer = new Label();
      this.lbBottom = new Label();
      this.lbHor.HeightRequest = 10;
      this.lbVer.HeightRequest = 10;
      this.lbBottom.HeightRequest = 10;
      this.directionText = new Label();
      this.directionText.Xalign = 1f;
      this.table.Attach((Widget) this.directionText, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.directionCombox = new ComBoxEx();
      this.table.Attach((Widget) this.directionCombox, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.directionText.Show();
      this.directionCombox.Show();
      this.table.Attach((Widget) this.lbHor, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Shrink, 0U, 0U);
      this.horizontalText = new Label();
      this.horizontalText.Xalign = 1f;
      this.table.Attach((Widget) this.horizontalText, 0U, 1U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.horizontalCombox = new ComBoxEx();
      this.table.Attach((Widget) this.horizontalCombox, 1U, 2U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.lbVer, 0U, 1U, 3U, 4U, AttachOptions.Fill, AttachOptions.Shrink, 0U, 0U);
      this.verticalText = new Label();
      this.verticalText.Xalign = 1f;
      this.table.Attach((Widget) this.verticalText, 0U, 1U, 4U, 5U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.verticalCombox = new ComBoxEx();
      this.table.Attach((Widget) this.verticalCombox, 1U, 2U, 4U, 5U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.lbBottom, 0U, 1U, 5U, 6U, AttachOptions.Fill, AttachOptions.Shrink, 0U, 0U);
      this.horizontalText.WidthRequest = this.verticalText.WidthRequest = 90;
      this.table.RowSpacing = 0U;
      this.table.ColumnSpacing = 12U;
      this.table.ShowAll();
      this.Add((Widget) this.table);
      this.ShowAll();
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
      this.AfterEvent();
      this.ReadLanuageConfigFile();
    }

    private void directionCombox_Changed(object sender, EventArgs e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.ValueChanged == null)
          return;
        this.SetContentType(this.directionCombox.Active);
        this.ValueChanged((object) null, new ListViewEvent(0, this.directionCombox.Active));
      }));
    }

    private void verticalCombox_Changed(object sender, EventArgs e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.ValueChanged != null)
          this.ValueChanged((object) null, new ListViewEvent(2, this.verticalCombox.Active));
        this._ver = this.verticalCombox.Active;
      }));
    }

    private void horizontalCombox_Changed(object sender, EventArgs e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (this.ValueChanged != null)
          this.ValueChanged((object) null, new ListViewEvent(1, this.horizontalCombox.Active));
        this._hor = this.horizontalCombox.Active;
      }));
    }

    public void SetControl(int direct, int hor, int ver)
    {
      this.directionCombox.Active = direct;
      this._hor = hor;
      this._ver = ver - 3;
      this.SetContentType(direct);
    }

    private void SetContentType(int direct)
    {
      if (direct == 0)
      {
        this.lbHor.Visible = this.horizontalText.Visible = this.horizontalCombox.Visible = true;
        this.lbVer.Visible = this.verticalText.Visible = this.verticalCombox.Visible = false;
        this.horizontalCombox.Active = this._hor;
      }
      else if (direct == 1)
      {
        this.lbHor.Visible = this.horizontalText.Visible = this.horizontalCombox.Visible = false;
        this.lbVer.Visible = this.verticalText.Visible = this.verticalCombox.Visible = true;
        this.verticalCombox.Active = this._ver;
      }
      else
      {
        this.lbHor.Visible = this.horizontalText.Visible = this.horizontalCombox.Visible = false;
        this.lbVer.Visible = this.verticalText.Visible = this.verticalCombox.Visible = false;
      }
    }

    public void BeforEvent()
    {
      this.directionCombox.Changed -= new EventHandler(this.directionCombox_Changed);
      this.horizontalCombox.Changed -= new EventHandler(this.horizontalCombox_Changed);
      this.verticalCombox.Changed -= new EventHandler(this.verticalCombox_Changed);
    }

    public void AfterEvent()
    {
      this.directionCombox.Changed += new EventHandler(this.directionCombox_Changed);
      this.horizontalCombox.Changed += new EventHandler(this.horizontalCombox_Changed);
      this.verticalCombox.Changed += new EventHandler(this.verticalCombox_Changed);
    }

    public void Init(string[] fir, string[] sec, string[] thi)
    {
      ListStore listStore1 = new ListStore(new Type[1]{ typeof (string) });
      foreach (string key in fir)
        listStore1.AppendValues(new object[1]
        {
          (object) LanguageOption.GetValueBykey(key)
        });
      this.directionCombox.Model = (TreeModel) listStore1;
      CellRendererText cellRendererText = new CellRendererText();
      this.directionCombox.PackStart((CellRenderer) cellRendererText, true);
      this.directionCombox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      this.directionCombox.Active = 0;
      ListStore listStore2 = new ListStore(new Type[1]{ typeof (string) });
      foreach (string key in sec)
        listStore2.AppendValues(new object[1]
        {
          (object) LanguageOption.GetValueBykey(key)
        });
      this.horizontalCombox.Model = (TreeModel) listStore2;
      this.horizontalCombox.PackStart((CellRenderer) cellRendererText, true);
      this.horizontalCombox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      this.horizontalCombox.Active = sec.Length - 1;
      ListStore listStore3 = new ListStore(new Type[1]{ typeof (string) });
      foreach (string key in thi)
        listStore3.AppendValues(new object[1]
        {
          (object) LanguageOption.GetValueBykey(key)
        });
      this.verticalCombox.Model = (TreeModel) listStore3;
      this.verticalCombox.PackStart((CellRenderer) cellRendererText, true);
      this.verticalCombox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      this.verticalCombox.Active = thi.Length - 1;
    }

    public override void ReadLanuageConfigFile()
    {
      this.directionText.Text = LanguageInfo.Description_ScrollDirection;
      this.horizontalText.Text = LanguageInfo.UIListVIew_ChildAlignment;
      this.verticalText.Text = LanguageInfo.UIListVIew_ChildAlignment;
    }
  }
}
