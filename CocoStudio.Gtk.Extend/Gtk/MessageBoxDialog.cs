// Decompiled with JetBrains decompiler
// Type: Gtk.MessageBoxDialog
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;

namespace Gtk
{
  public class MessageBoxDialog : Dialog
  {
    private VBox vbox_main;
    private VBox vbox_top;
    private Alignment alignment_label;
    private Label labelInfo;
    private VBox vbox_bottom;
    private Button buttonCancel;
    private Button buttonNo;
    private Button buttonYes;

    public MessageBoxDialog()
    {
      this.Build();
    }

    public MessageBoxDialog(Window parentWindow, string info, ButtonText btnTxt)
    {
      this.Build();
      this.ChangeBtnPosion();
      this.buttonYes.Name = "MainButton";
      this.Init(parentWindow, info);
      if (btnTxt == null)
        return;
      this.buttonYes.Label = btnTxt.OKText;
      this.buttonNo.Label = btnTxt.NoText;
      this.buttonCancel.Label = btnTxt.CancelText;
    }

    private void ChangeBtnPosion()
    {
      HButtonBox actionArea = this.ActionArea;
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonYes];
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
      ButtonBox.ButtonBoxChild buttonBoxChild3 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonNo];
      if (Platform.IsWindows)
      {
        buttonBoxChild1.Position = 0;
        buttonBoxChild3.Position = 1;
        buttonBoxChild2.Position = 2;
      }
      else
      {
        if (!Platform.IsMac)
          return;
        buttonBoxChild3.Position = 0;
        buttonBoxChild2.Position = 1;
        buttonBoxChild1.Position = 2;
      }
    }

    private void Init(Window parentWindow, string info)
    {
      this.labelInfo.Text = info;
      this.AllowGrow = false;
      this.SetToDialogStyle(parentWindow, true, true, true);
      this.InitMultiLanuage();
    }

    private void InitMultiLanuage()
    {
      this.buttonYes.Label = LanguageInfo.Dialog_ButtonYes;
      this.buttonNo.Label = LanguageInfo.Dialog_ButtonNo;
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonReturn;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "Gtk.MessageBoxDialog";
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.Resizable = false;
      this.AllowGrow = false;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.vbox_main = new VBox();
      this.vbox_main.Name = "vbox_main";
      this.vbox_main.Spacing = 6;
      this.vbox_main.BorderWidth = 15U;
      this.vbox_top = new VBox();
      this.vbox_top.Name = "vbox_top";
      this.vbox_top.Spacing = 6;
      this.vbox_main.Add((Widget) this.vbox_top);
      ((Box.BoxChild) this.vbox_main[(Widget) this.vbox_top]).Position = 0;
      this.alignment_label = new Alignment(0.5f, 0.5f, 1f, 1f);
      this.alignment_label.Name = "alignment_label";
      this.alignment_label.TopPadding = 18U;
      this.alignment_label.BottomPadding = 18U;
      this.labelInfo = new Label();
      this.labelInfo.Name = "labelInfo";
      this.labelInfo.LabelProp = Catalog.GetString("label1");
      this.labelInfo.Wrap = true;
      this.alignment_label.Add((Widget) this.labelInfo);
      this.vbox_main.Add((Widget) this.alignment_label);
      Box.BoxChild boxChild = (Box.BoxChild) this.vbox_main[(Widget) this.alignment_label];
      boxChild.Position = 1;
      boxChild.Expand = false;
      boxChild.Fill = false;
      this.vbox_bottom = new VBox();
      this.vbox_bottom.Name = "vbox_bottom";
      this.vbox_bottom.Spacing = 6;
      this.vbox_main.Add((Widget) this.vbox_bottom);
      ((Box.BoxChild) this.vbox_main[(Widget) this.vbox_bottom]).Position = 2;
      vbox.Add((Widget) this.vbox_main);
      ((Box.BoxChild) vbox[(Widget) this.vbox_main]).Position = 0;
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
      this.buttonNo = new Button();
      this.buttonNo.CanFocus = true;
      this.buttonNo.Name = "buttonNo";
      this.buttonNo.UseStock = true;
      this.buttonNo.UseUnderline = true;
      this.buttonNo.Label = "gtk-no";
      this.AddActionWidget((Widget) this.buttonNo, -9);
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonNo];
      buttonBoxChild2.Position = 1;
      buttonBoxChild2.Expand = false;
      buttonBoxChild2.Fill = false;
      this.buttonYes = new Button();
      this.buttonYes.CanDefault = true;
      this.buttonYes.CanFocus = true;
      this.buttonYes.Name = "buttonYes";
      this.buttonYes.UseStock = true;
      this.buttonYes.UseUnderline = true;
      this.buttonYes.Label = "gtk-yes";
      this.AddActionWidget((Widget) this.buttonYes, -8);
      ButtonBox.ButtonBoxChild buttonBoxChild3 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonYes];
      buttonBoxChild3.Position = 2;
      buttonBoxChild3.Expand = false;
      buttonBoxChild3.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 244;
      this.DefaultHeight = 160;
      this.Show();
    }
  }
}
