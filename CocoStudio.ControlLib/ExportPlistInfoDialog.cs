// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.ExportPlistInfoDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using Stetic;
using System;

namespace CocoStudio.ControlLib
{
  public class ExportPlistInfoDialog : Dialog
  {
    private string exportpath;
    private HBox hbox_path;
    private Label label_Path;
    private Entry entry_Path;
    private Button button_Browse;
    private Button buttonOk;
    private Button buttonCancel;

    public bool IsOk { get; set; }

    public string ExportPath
    {
      get
      {
        return this.exportpath;
      }
      set
      {
        this.exportpath = this.entry_Path.Text = value;
      }
    }

    public ExportPlistInfoDialog(string exportPath)
    {
      this.Build();
      this.buttonOk.Name = "MainButton";
      this.Init(exportPath);
    }

    private void Init(string exportPath)
    {
      this.AllowGrow = false;
      this.SetSizeRequest(510, 100);
      this.SetToDialogStyle((Window) null, true, true, true);
      this.button_Browse.SetSizeRequest(70, 24);
      this.button_Browse.Clicked += new EventHandler(this.button_Browse_Clicked);
      this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
      this.buttonOk.Clicked += new EventHandler(this.buttonOk_Clicked);
      this.buttonCancel.Clicked += new EventHandler(this.buttonCancel_Clicked);
      this.ExportPath = exportPath;
      this.entry_Path.ActivatesDefault = true;
      this.buttonOk.GrabDefault();
    }

    private void buttonOk_Clicked(object sender, EventArgs e)
    {
      this.IsOk = true;
      this.Destroy();
    }

    private void buttonCancel_Clicked(object sender, EventArgs e)
    {
      this.IsOk = false;
      this.Destroy();
    }

    private void button_Browse_Clicked(object sender, EventArgs e)
    {
      string folder = FileChooserDialogModel.GetBrowseDialogPath("导出路径", false, "", false).Folder;
      if (!string.IsNullOrEmpty(folder))
        this.ExportPath = folder;
      this.buttonOk.GrabFocus();
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "CocoStudio.ControlLib.ExportPlistInfoDialog";
      this.WindowPosition = WindowPosition.CenterOnParent;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.hbox_path = new HBox();
      this.hbox_path.Name = "hbox_path";
      this.hbox_path.Spacing = 6;
      this.hbox_path.BorderWidth = 8U;
      this.label_Path = new Label();
      this.label_Path.Name = "label_Path";
      this.label_Path.LabelProp = Catalog.GetString("导出路径");
      this.hbox_path.Add((Widget) this.label_Path);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox_path[(Widget) this.label_Path];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      boxChild1.Padding = 5U;
      this.entry_Path = new Entry();
      this.entry_Path.WidthRequest = 370;
      this.entry_Path.CanFocus = true;
      this.entry_Path.Name = "entry_Path";
      this.entry_Path.IsEditable = true;
      this.entry_Path.InvisibleChar = '●';
      this.hbox_path.Add((Widget) this.entry_Path);
      ((Box.BoxChild) this.hbox_path[(Widget) this.entry_Path]).Position = 1;
      this.button_Browse = new Button();
      this.button_Browse.CanFocus = true;
      this.button_Browse.Name = "button_Browse";
      this.button_Browse.UseUnderline = true;
      this.button_Browse.Label = Catalog.GetString("   浏览   ");
      this.hbox_path.Add((Widget) this.button_Browse);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox_path[(Widget) this.button_Browse];
      boxChild2.Position = 2;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      vbox.Add((Widget) this.hbox_path);
      Box.BoxChild boxChild3 = (Box.BoxChild) vbox[(Widget) this.hbox_path];
      boxChild3.Position = 0;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      HButtonBox actionArea = this.ActionArea;
      actionArea.Name = "dialog1_ActionArea";
      actionArea.Spacing = 10;
      actionArea.BorderWidth = 5U;
      actionArea.LayoutStyle = ButtonBoxStyle.End;
      this.buttonOk = new Button();
      this.buttonOk.CanDefault = true;
      this.buttonOk.CanFocus = true;
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseStock = true;
      this.buttonOk.UseUnderline = true;
      this.buttonOk.Label = "gtk-ok";
      this.AddActionWidget((Widget) this.buttonOk, -5);
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
      buttonBoxChild1.Expand = false;
      buttonBoxChild1.Fill = false;
      this.buttonCancel = new Button();
      this.buttonCancel.CanFocus = true;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseStock = true;
      this.buttonCancel.UseUnderline = true;
      this.buttonCancel.Label = "gtk-cancel";
      this.AddActionWidget((Widget) this.buttonCancel, -6);
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
      buttonBoxChild2.Position = 1;
      buttonBoxChild2.Expand = false;
      buttonBoxChild2.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 517;
      this.DefaultHeight = 96;
      this.Show();
    }
  }
}
