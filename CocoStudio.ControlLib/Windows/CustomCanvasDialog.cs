// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.CustomCanvasDialog
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
    public class CustomCanvasDialog : Dialog
    {
        public Size canvasSize = new Size(1, 1);

        private EntryIntEx spinbutton_Width = new EntryIntEx
        {
            MinValue = 0,
            MaxValue = 100000,
            WidthRequest = 70,
            CanFocus = true,
            IsInteger = true
        };

        private EntryIntEx spinbuttonHeight = new EntryIntEx
        {
            MinValue = 0,
            MaxValue = 100000,
            WidthRequest = 70,
            CanFocus = true,
            IsInteger = true
        };

        private Alignment alignment1;

        private HBox hbox_root;

        private HBox hbox2;

        private Label label_Width;

        private HBox hbox3;

        private Label label_Height;

        private Button buttonCancel;

        private Button buttonOk;

        public bool IsOK
        {
            get;
            set;
        }

        public CustomCanvasDialog(int defaultWidth = 340, int defaultHeight = 140)
        {
            this.Build();
            this.ChangeBtnPosion();
            this.buttonOk.Name = "MainButton";
            this.readLanuageConfigFile();
            this.Init();
            this.spinbutton_Width.Value = (double)defaultWidth;
            this.spinbuttonHeight.Value = (double)defaultHeight;
            this.buttonOk.Clicked += new EventHandler(this.buttonOk_Clicked);
            this.buttonCancel.Clicked += new EventHandler(this.buttonCancel_Clicked);
            base.DeleteEvent += new DeleteEventHandler(this.CustomCanvasWindow_DeleteEvent);
            base.ShowAll();
        }

        private void ChangeBtnPosion()
        {
            if (!Platform.IsMac)
            {
                HButtonBox actionArea = base.ActionArea;
                ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild)actionArea[this.buttonOk];
                ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild)actionArea[this.buttonCancel];
                buttonBoxChild.Position = 0;
                buttonBoxChild2.Position = 1;
            }
        }

        private void Init()
        {
            base.AllowGrow = false;
            Rectangle rectangle = new Rectangle(0, 0, 340, 120);
            base.WidthRequest = rectangle.Width;
            base.HeightRequest = rectangle.Height;
            this.SetToDialogStyle(null, true, true, true);
            this.buttonOk.GrabDefault();
            this.hbox2.Add(this.spinbutton_Width);
            ((Box.BoxChild)this.hbox2[this.spinbutton_Width]).Position = 1;
            this.hbox3.Add(this.spinbuttonHeight);
            ((Box.BoxChild)this.hbox3[this.spinbuttonHeight]).Position = 1;
        }

        private void CustomCanvasWindow_DeleteEvent(object o, DeleteEventArgs args)
        {
            this.IsOK = false;
            this.Destroy();
        }

        private void buttonCancel_Clicked(object sender, EventArgs e)
        {
            this.IsOK = false;
            this.Destroy();
        }

        private void buttonOk_Clicked(object sender, EventArgs e)
        {
            this.IsOK = true;
            this.canvasSize = new Size((int)this.spinbutton_Width.Value, (int)this.spinbuttonHeight.Value);
            this.Destroy();
        }

        public void readLanuageConfigFile()
        {
            base.Title = LanguageInfo.ScreeSize_Dialog_WindowTitle;
            this.label_Height.Text = LanguageInfo.ScreeSize_Dialog_Height;
            this.label_Width.Text = LanguageInfo.ScreeSize_Dialog_Width;
            this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
            this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
        }

        protected virtual void Build()
        {
            Gui.Initialize(this);
            base.Name = "CocoStudio.ControlLib.Windows.CustomCanvasDialog";
            base.WindowPosition = WindowPosition.CenterOnParent;
            VBox vBox = base.VBox;
            vBox.Name = "dialog1_VBox";
            vBox.BorderWidth = 2u;
            this.alignment1 = new Alignment(0.5f, 0.5f, 1f, 1f);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = 15u;
            this.hbox_root = new HBox();
            this.hbox_root.Name = "hbox_root";
            this.hbox_root.Spacing = 40;
            this.hbox_root.BorderWidth = 10u;
            this.hbox2 = new HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            this.label_Width = new Label();
            this.label_Width.Name = "label_Width";
            this.label_Width.LabelProp = Catalog.GetString("宽:");
            this.hbox2.Add(this.label_Width);
            Box.BoxChild boxChild = (Box.BoxChild)this.hbox2[this.label_Width];
            boxChild.Position = 0;
            boxChild.Expand = false;
            boxChild.Fill = false;
            this.hbox_root.Add(this.hbox2);
            Box.BoxChild boxChild2 = (Box.BoxChild)this.hbox_root[this.hbox2];
            boxChild2.Position = 0;
            this.hbox3 = new HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            this.label_Height = new Label();
            this.label_Height.Name = "label_Height";
            this.label_Height.LabelProp = Catalog.GetString("高:");
            this.hbox3.Add(this.label_Height);
            Box.BoxChild boxChild3 = (Box.BoxChild)this.hbox3[this.label_Height];
            boxChild3.Position = 0;
            boxChild3.Expand = false;
            boxChild3.Fill = false;
            this.hbox_root.Add(this.hbox3);
            Box.BoxChild boxChild4 = (Box.BoxChild)this.hbox_root[this.hbox3];
            boxChild4.Position = 1;
            this.alignment1.Add(this.hbox_root);
            vBox.Add(this.alignment1);
            Box.BoxChild boxChild5 = (Box.BoxChild)vBox[this.alignment1];
            boxChild5.Position = 0;
            boxChild5.Expand = false;
            boxChild5.Fill = false;
            HButtonBox actionArea = base.ActionArea;
            actionArea.Name = "dialog1_ActionArea";
            actionArea.Spacing = 10;
            actionArea.BorderWidth = 5u;
            actionArea.LayoutStyle = ButtonBoxStyle.End;
            this.buttonCancel = new Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            base.AddActionWidget(this.buttonCancel, -6);
            ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild)actionArea[this.buttonCancel];
            buttonBoxChild.Expand = false;
            buttonBoxChild.Fill = false;
            this.buttonOk = new Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            base.AddActionWidget(this.buttonOk, -5);
            ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild)actionArea[this.buttonOk];
            buttonBoxChild2.Position = 1;
            buttonBoxChild2.Expand = false;
            buttonBoxChild2.Fill = false;
            if (base.Child != null)
            {
                base.Child.ShowAll();
            }
            base.DefaultWidth = 340;
            base.DefaultHeight = 140;
            base.Show();
        }
    }

}