// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.HelpDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using CocoStudio.Basic;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using Stetic;

namespace CocoStudio.ControlLib.Windows
{
  public class HelpDialog : Dialog
  {
    private HBox hbox1;
    private Gtk.Image imageIcon;
    private VBox vbox2;
    private Label labelCocoStudio;
    private Label labelVersion;
    private Label labelCopyright;
    private Label labelAccredit;
    private Button buttonOk;

    public HelpDialog()
    {
      this.Build();
      this.buttonOk.Name = "MainButton";
      this.LanguageConfig();
      this.Init();
      this.SetToDialogStyle((Gtk.Window) null, true, true, true);
    }

    private void Init()
    {
      this.AllowGrow = false;
      Rectangle rectangle = new Rectangle(0, 0, 520, 200);
      this.WidthRequest = rectangle.Width;
      this.HeightRequest = rectangle.Height;
      this.labelCocoStudio.Text = "Cocos Studio";
      this.labelVersion.Text = string.Format("{0} {1}{2}", (object) LanguageInfo.Helper_Version, (object) "v", (object) Option.EditorVersion.ToString(3));
      this.labelCopyright.Text = "Copyright © Chukong Aipu 2014";
      this.labelAccredit.Text = string.Format("{0} {1}", (object) LanguageInfo.Helper_Authorize, (object) "Beijing Chukong Aipu Technology Co.,Ltd");
      this.buttonOk.GrabDefault();
    }

    public void LanguageConfig()
    {
      this.Title = LanguageInfo.Helper_About;
      this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.WidthRequest = 500;
      this.HeightRequest = 200;
      this.Name = "CocoStudio.ControlLib.Windows.HelpDialog";
      this.WindowPosition = WindowPosition.CenterOnParent;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.hbox1 = new HBox();
      this.hbox1.Name = "hbox1";
      this.hbox1.Spacing = 40;
      this.hbox1.BorderWidth = 20U;
      this.imageIcon = new Gtk.Image();
      this.imageIcon.WidthRequest = 136;
      this.imageIcon.HeightRequest = 143;
      this.imageIcon.Name = "imageIcon";
      this.imageIcon.Pixbuf = Pixbuf.LoadFromResource("CocoStudio.ControlLib.Resource.CocoStudio_Logo.png");
      this.hbox1.Add((Widget) this.imageIcon);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox1[(Widget) this.imageIcon];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.vbox2 = new VBox();
      this.vbox2.Name = "vbox2";
      this.vbox2.Spacing = 6;
      this.labelCocoStudio = new Label();
      this.labelCocoStudio.Name = "labelCocoStudio";
      this.labelCocoStudio.LabelProp = Catalog.GetString("Cocos Studio");
      this.vbox2.Add((Widget) this.labelCocoStudio);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.vbox2[(Widget) this.labelCocoStudio];
      boxChild2.Position = 0;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.labelVersion = new Label();
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Xalign = 0.0f;
      this.labelVersion.LabelProp = Catalog.GetString("版本 1.0.0.0 Alpha");
      this.vbox2.Add((Widget) this.labelVersion);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.vbox2[(Widget) this.labelVersion];
      boxChild3.Position = 1;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      this.labelCopyright = new Label();
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Xalign = 0.0f;
      this.labelCopyright.LabelProp = Catalog.GetString("Copyright © Chukong Aipu 2014");
      this.vbox2.Add((Widget) this.labelCopyright);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.vbox2[(Widget) this.labelCopyright];
      boxChild4.Position = 2;
      boxChild4.Expand = false;
      boxChild4.Fill = false;
      this.labelAccredit = new Label();
      this.labelAccredit.Name = "labelAccredit";
      this.labelAccredit.Xalign = 0.0f;
      this.labelAccredit.LabelProp = Catalog.GetString("授权 Beijing Chukong Aipu Technology Co.,Ltd");
      this.vbox2.Add((Widget) this.labelAccredit);
      Box.BoxChild boxChild5 = (Box.BoxChild) this.vbox2[(Widget) this.labelAccredit];
      boxChild5.Position = 3;
      boxChild5.Expand = false;
      boxChild5.Fill = false;
      this.hbox1.Add((Widget) this.vbox2);
      Box.BoxChild boxChild6 = (Box.BoxChild) this.hbox1[(Widget) this.vbox2];
      boxChild6.Position = 1;
      boxChild6.Expand = false;
      boxChild6.Fill = false;
      vbox.Add((Widget) this.hbox1);
      Box.BoxChild boxChild7 = (Box.BoxChild) vbox[(Widget) this.hbox1];
      boxChild7.Position = 0;
      boxChild7.Expand = false;
      boxChild7.Fill = false;
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
      ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
      buttonBoxChild.Expand = false;
      buttonBoxChild.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 500;
      this.DefaultHeight = 200;
      this.Show();
    }
  }
}
