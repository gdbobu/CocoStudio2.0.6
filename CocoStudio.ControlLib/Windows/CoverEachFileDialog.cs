// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.CoverEachFileDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System;

namespace CocoStudio.ControlLib.Windows
{
  public class CoverEachFileDialog : Dialog
  {
    private VBox vbox2;
    private Label label_Message;
    private CheckButton checkbutton_All;
    private Button buttonCancel;
    private Button buttonOk;

    public bool IsExportCover { get; set; }

    public bool IsChangeAll { get; set; }

    public bool IsUnCancel { get; set; }

    public event EventHandler ConfirmClickHandler;

    public CoverEachFileDialog()
    {
      this.Build();
      this.ChangeBtnPosion();
      this.buttonOk.Name = "MainButton";
      this.Init();
      this.ReadMultiLanguageConfig();
      this.buttonOk.GrabDefault();
      this.buttonCancel.Clicked += new EventHandler(this.buttonCancel_Clicked);
      this.buttonOk.Clicked += new EventHandler(this.buttonOk_Clicked);
      this.DeleteEvent += new DeleteEventHandler(this.CoverEachFileWindow_DeleteEvent);
    }

    private void ChangeBtnPosion()
    {
      if (Platform.IsMac)
        return;
      HButtonBox actionArea = this.ActionArea;
      ((Box.BoxChild) actionArea[(Widget) this.buttonOk]).Position = 0;
      ((Box.BoxChild) actionArea[(Widget) this.buttonCancel]).Position = 1;
    }

    private void Init()
    {
      this.AllowGrow = false;
      Rectangle rectangle = new Rectangle(0, 0, 500, 130);
      this.WidthRequest = rectangle.Width;
      this.HeightRequest = rectangle.Height;
      this.SetToDialogStyle((Gtk.Window) null, true, true, true);
    }

    private void CoverEachFileWindow_DeleteEvent(object o, DeleteEventArgs e)
    {
      if (this.IsUnCancel)
        return;
      this.IsExportCover = false;
      this.IsChangeAll = true;
      if (this.ConfirmClickHandler != null)
        this.ConfirmClickHandler((object) this, (EventArgs) e);
    }

    private void buttonOk_Clicked(object sender, EventArgs e)
    {
      this.IsExportCover = true;
      this.IsChangeAll = this.checkbutton_All.Active;
      this.IsUnCancel = true;
      if (this.ConfirmClickHandler != null)
        this.ConfirmClickHandler((object) this, e);
      else
        this.Destroy();
    }

    private void buttonCancel_Clicked(object sender, EventArgs e)
    {
      this.IsExportCover = false;
      this.IsChangeAll = this.checkbutton_All.Active;
      this.IsUnCancel = true;
      if (this.ConfirmClickHandler != null)
        this.ConfirmClickHandler((object) this, e);
      else
        this.Destroy();
    }

    public void RefreshMessage(string fileName, int allCount, string existInfo = "")
    {
      if (existInfo == "")
        existInfo = LanguageInfo.CoverEachIsExistFile;
      this.label_Message.Text = string.Format(existInfo, (object) fileName);
      if (allCount <= 0)
        return;
      this.checkbutton_All.Label = string.Format(LanguageInfo.CoverEachIsConflictFile, (object) allCount);
    }

    private void ReadMultiLanguageConfig()
    {
      this.Title = LanguageInfo.ResourceReplacementWindow;
      this.buttonOk.Label = LanguageInfo.Dialog_ButtonYes;
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonNo;
      this.checkbutton_All.Label = LanguageInfo.AllReplacement;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "CocoStudio.ControlLib.Windows.CoverEachFileDialog";
      this.WindowPosition = WindowPosition.CenterOnParent;
      VBox vbox = this.VBox;
      vbox.WidthRequest = 440;
      vbox.HeightRequest = 130;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.vbox2 = new VBox();
      this.vbox2.Name = "vbox2";
      this.vbox2.Spacing = 72;
      this.vbox2.BorderWidth = 10U;
      this.label_Message = new Label();
      this.label_Message.Name = "label_Message";
      this.label_Message.LabelProp = Catalog.GetString("label1");
      this.vbox2.Add((Widget) this.label_Message);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.vbox2[(Widget) this.label_Message];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.checkbutton_All = new CheckButton();
      this.checkbutton_All.CanFocus = true;
      this.checkbutton_All.Name = "checkbutton_All";
      this.checkbutton_All.Label = Catalog.GetString("全部选择");
      this.checkbutton_All.DrawIndicator = true;
      this.checkbutton_All.UseUnderline = true;
      this.vbox2.Add((Widget) this.checkbutton_All);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.vbox2[(Widget) this.checkbutton_All];
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      vbox.Add((Widget) this.vbox2);
      ((Box.BoxChild) vbox[(Widget) this.vbox2]).Position = 0;
      HButtonBox actionArea = this.ActionArea;
      actionArea.Name = "dialog1_ActionArea";
      actionArea.Spacing = 10;
      actionArea.BorderWidth = 5U;
      actionArea.LayoutStyle = ButtonBoxStyle.End;
      this.buttonCancel = new Button();
      this.buttonCancel.CanDefault = true;
      this.buttonCancel.CanFocus = true;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseStock = true;
      this.buttonCancel.UseUnderline = true;
      this.buttonCancel.Label = "gtk-cancel";
      this.AddActionWidget((Widget) this.buttonCancel, -6);
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
      buttonBoxChild1.Expand = false;
      buttonBoxChild1.Fill = false;
      this.buttonOk = new Button();
      this.buttonOk.CanDefault = true;
      this.buttonOk.CanFocus = true;
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseStock = true;
      this.buttonOk.UseUnderline = true;
      this.buttonOk.Label = "gtk-ok";
      this.AddActionWidget((Widget) this.buttonOk, -5);
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
      buttonBoxChild2.Position = 1;
      buttonBoxChild2.Expand = false;
      buttonBoxChild2.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 440;
      this.DefaultHeight = 130;
      this.Show();
    }
  }
}
