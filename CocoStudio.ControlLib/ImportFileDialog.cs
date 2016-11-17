// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.ImportFileDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using Stetic;
using System;

namespace CocoStudio.ControlLib
{
  public class ImportFileDialog : Dialog
  {
    private DialogResult result;
    private Alignment alignment1;
    private Label labDescribe;
    private CheckButton ckbIsChangeAll;
    private HBox hbox4;
    private Button btnKeepBoth;
    private Button btnReplace;
    private Button btnSkip;

    public ImportFileDialog(bool keepBothBtnVisible = true)
    {
      this.Build();
      this.btnKeepBoth.Name = "MainButton";
      this.result = new DialogResult();
      this.RegistEvent();
      this.btnKeepBoth.Visible = keepBothBtnVisible;
      this.SetMultiLanguageInfo();
    }

    public ImportFileDialog(Window parentWindow, bool keepBothBtnVisible = true)
      : this(keepBothBtnVisible)
    {
      this.SetToDialogStyle(parentWindow, true, true, true);
    }

    private void RegistEvent()
    {
      this.btnKeepBoth.Clicked += new EventHandler(this.btnKeepBoth_Clicked);
      this.btnReplace.Clicked += new EventHandler(this.btnReplace_Clicked);
      this.btnSkip.Clicked += new EventHandler(this.btnSkip_Clicked);
      this.DeleteEvent += new DeleteEventHandler(this.ImprotFileDialog_DeleteEvent);
    }

    private void SetMultiLanguageInfo()
    {
      this.Title = LanguageInfo.Menu_File_ImportFile;
      this.ckbIsChangeAll.Label = LanguageInfo.Dialog_Button_ApplyToAll;
      this.btnKeepBoth.Label = LanguageInfo.Dialog_Button_SaveBoth;
      this.btnReplace.Label = LanguageInfo.MessageBox_Content_Replace;
      this.btnSkip.Label = LanguageInfo.Dialog_Button_Skip;
    }

    [ConnectBefore]
    private void ImprotFileDialog_DeleteEvent(object o, DeleteEventArgs args)
    {
      this.SetResult(EImportFileButtonResult.Skip);
    }

    private void btnSkip_Clicked(object sender, EventArgs e)
    {
      this.SetResult(EImportFileButtonResult.Skip);
    }

    private void btnReplace_Clicked(object sender, EventArgs e)
    {
      this.SetResult(EImportFileButtonResult.Replace);
    }

    private void btnKeepBoth_Clicked(object sender, EventArgs e)
    {
      this.SetResult(EImportFileButtonResult.KeepBoth);
    }

    private void SetResult(EImportFileButtonResult btnResult)
    {
      this.result.ButtonResult = btnResult;
      this.Destroy();
      this.Dispose();
    }

    public DialogResult ShowRun()
    {
      this.Run();
      this.result.IsChangedAll = this.ckbIsChangeAll.Active;
      return this.result;
    }

    public void RefreshMessage(string fileName)
    {
      this.labDescribe.Text = string.Format(LanguageInfo.MessageBox218_FileAlreadyExists, (object) fileName);
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.WidthRequest = 400;
      this.HeightRequest = 100;
      this.Name = "ImprotFileDialog.Dialog";
      this.Title = Catalog.GetString("导入文件");
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.Resizable = false;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.alignment1 = new Alignment(0.5f, 0.5f, 1f, 1f);
      this.alignment1.Name = "alignment1";
      this.alignment1.LeftPadding = 8U;
      this.labDescribe = new Label();
      this.labDescribe.WidthRequest = 392;
      this.labDescribe.HeightRequest = 50;
      this.labDescribe.LineWrap = true;
      this.labDescribe.Name = "labDescribe";
      this.labDescribe.LabelProp = Catalog.GetString("文件已经存在,请选择");
      this.alignment1.Add((Widget) this.labDescribe);
      vbox.Add((Widget) this.alignment1);
      ((Box.BoxChild) vbox[(Widget) this.alignment1]).Position = 0;
      HButtonBox actionArea = this.ActionArea;
      actionArea.Name = "dialog1_ActionArea";
      actionArea.Spacing = 10;
      actionArea.BorderWidth = 5U;
      actionArea.LayoutStyle = ButtonBoxStyle.Edge;
      this.ckbIsChangeAll = new CheckButton();
      this.ckbIsChangeAll.CanFocus = true;
      this.ckbIsChangeAll.Name = "ckbIsChangeAll";
      this.ckbIsChangeAll.Label = Catalog.GetString("全部应用");
      this.ckbIsChangeAll.DrawIndicator = true;
      this.ckbIsChangeAll.UseUnderline = true;
      actionArea.Add((Widget) this.ckbIsChangeAll);
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.ckbIsChangeAll];
      buttonBoxChild1.Expand = false;
      buttonBoxChild1.Fill = false;
      this.hbox4 = new HBox();
      this.hbox4.Name = "hbox4";
      this.hbox4.Spacing = 6;
      this.btnKeepBoth = new Button();
      this.btnKeepBoth.WidthRequest = 65;
      this.btnKeepBoth.CanFocus = true;
      this.btnKeepBoth.Name = "btnKeepBoth";
      this.btnKeepBoth.UseUnderline = true;
      this.btnKeepBoth.Label = Catalog.GetString("保留两者");
      this.hbox4.Add((Widget) this.btnKeepBoth);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox4[(Widget) this.btnKeepBoth];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.btnReplace = new Button();
      this.btnReplace.WidthRequest = 65;
      this.btnReplace.CanDefault = true;
      this.btnReplace.CanFocus = true;
      this.btnReplace.Name = "btnReplace";
      this.btnReplace.UseUnderline = true;
      this.btnReplace.Label = Catalog.GetString("替换");
      this.hbox4.Add((Widget) this.btnReplace);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox4[(Widget) this.btnReplace];
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.btnSkip = new Button();
      this.btnSkip.WidthRequest = 65;
      this.btnSkip.CanDefault = true;
      this.btnSkip.CanFocus = true;
      this.btnSkip.Name = "btnSkip";
      this.btnSkip.UseUnderline = true;
      this.btnSkip.Label = Catalog.GetString("跳过");
      this.hbox4.Add((Widget) this.btnSkip);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.hbox4[(Widget) this.btnSkip];
      boxChild3.Position = 2;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      actionArea.Add((Widget) this.hbox4);
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.hbox4];
      buttonBoxChild2.Position = 1;
      buttonBoxChild2.Expand = false;
      buttonBoxChild2.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 454;
      this.DefaultHeight = 126;
      this.Show();
    }
  }
}
