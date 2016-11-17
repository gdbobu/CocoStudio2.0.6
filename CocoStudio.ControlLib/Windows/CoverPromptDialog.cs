// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.CoverPromptDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gdk;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System;
using System.IO;

namespace CocoStudio.ControlLib.Windows
{
    public class CoverPromptDialog : Dialog
    {
        public string newExportFolderName = string.Empty;

        public string oldExportFolderName = string.Empty;

        public int order = 1;

        public string oldFolderPath = string.Empty;

        public string newFolderPath = string.Empty;

        public bool IsCanceled = false;

        private VBox vbox2;

        private Label label_Prompt;

        private RadioButton radiobutton_CoverFolder;

        private RadioButton radiobutton_ChangeFolder;

        private Button buttonCancel;

        private Button buttonOk;

        public event EventHandler ConfirmClickHandler;

        public CoverPromptDialog(string folderPath = "")
        {
            this.Build();
            this.ChangeBtnPosion();
            this.buttonOk.Name = "MainButton";
            this.readLanuageConfigFile();
            this.InitEvent();
            this.Init();
            this.oldFolderPath = folderPath;
            this.radiobutton_CoverFolder.Active = true;
            this.oldExportFolderName = System.IO.Path.GetFileNameWithoutExtension(folderPath);
            this.label_Prompt.Text = string.Format(LanguageInfo.TextBlock_Prompt_Text, this.oldExportFolderName);
            this.ChengeExportFolderName();
            this.radiobutton_ChangeFolder.Label = string.Format(LanguageInfo.RadioButton_ChangeFolder_Content, this.newExportFolderName);
            this.radiobutton_ChangeFolder.UseUnderline = false;
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
            Rectangle rectangle = new Rectangle(0, 0, 500, 140);
            base.WidthRequest = rectangle.Width;
            base.HeightRequest = rectangle.Height;
            this.SetToDialogStyle(null, true, true, true);
            this.buttonOk.GrabDefault();
        }

        private void InitEvent()
        {
            this.buttonCancel.Clicked += new EventHandler(this.button_Cancel_Click);
            this.buttonOk.Clicked += new EventHandler(this.button_OK_Click);
        }

        private void ChengeExportFolderName()
        {
            string text = string.Format("{0}_{1}", this.oldExportFolderName, this.order);
            string directoryName = System.IO.Path.GetDirectoryName(this.oldFolderPath);
            string newExportFolderPath = System.IO.Path.Combine(directoryName, text);
            this.FileExistJudge(newExportFolderPath, text);
        }

        private void FileExistJudge(string newExportFolderPath, string newfolderName)
        {
            if (Directory.Exists(newExportFolderPath))
            {
                this.order++;
                this.ChengeExportFolderName();
            }
            else
            {
                this.newExportFolderName = newfolderName;
                this.newFolderPath = newExportFolderPath;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.ConfirmClickHandler != null)
            {
                if (this.radiobutton_ChangeFolder.Active)
                {
                    this.ConfirmClickHandler(this.newFolderPath, e);
                }
                else
                {
                    this.ConfirmClickHandler(this.oldFolderPath, e);
                }
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.IsCanceled = true;
            this.Destroy();
        }

        public void readLanuageConfigFile()
        {
            this.radiobutton_CoverFolder.Label = LanguageInfo.RadioButton_CoverFolder_Content;
            this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
            this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
        }

        protected virtual void Build()
        {
            Gui.Initialize(this);
            base.HeightRequest = 140;
            base.Name = "CocoStudio.ControlLib.Windows.CoverPromptDialog";
            base.WindowPosition = WindowPosition.CenterOnParent;
            VBox vBox = base.VBox;
            vBox.Name = "dialog1_VBox";
            vBox.BorderWidth = 2u;
            this.vbox2 = new VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = 5u;
            this.label_Prompt = new Label();
            this.label_Prompt.HeightRequest = 20;
            this.label_Prompt.Name = "label_Prompt";
            this.label_Prompt.LabelProp = Catalog.GetString("导出目录下存在A文件夹");
            this.vbox2.Add(this.label_Prompt);
            Box.BoxChild boxChild = (Box.BoxChild)this.vbox2[this.label_Prompt];
            boxChild.Position = 0;
            boxChild.Expand = false;
            boxChild.Fill = false;
            this.radiobutton_CoverFolder = new RadioButton(Catalog.GetString("覆盖文件夹，警告：覆盖可能导致导出资源赘余！"));
            this.radiobutton_CoverFolder.CanFocus = true;
            this.radiobutton_CoverFolder.Name = "radiobutton_CoverFolder";
            this.radiobutton_CoverFolder.DrawIndicator = true;
            this.radiobutton_CoverFolder.UseUnderline = true;
            this.radiobutton_CoverFolder.Group = new SList(IntPtr.Zero);
            this.vbox2.Add(this.radiobutton_CoverFolder);
            Box.BoxChild boxChild2 = (Box.BoxChild)this.vbox2[this.radiobutton_CoverFolder];
            boxChild2.Position = 1;
            boxChild2.Expand = false;
            boxChild2.Fill = false;
            this.radiobutton_ChangeFolder = new RadioButton(Catalog.GetString("_将导出文件夹名称：A_1 修改为A_1"));
            this.radiobutton_ChangeFolder.CanFocus = true;
            this.radiobutton_ChangeFolder.Name = "radiobutton_ChangeFolder";
            this.radiobutton_ChangeFolder.DrawIndicator = true;
            this.radiobutton_ChangeFolder.UseUnderline = true;
            this.radiobutton_ChangeFolder.Group = this.radiobutton_CoverFolder.Group;
            this.vbox2.Add(this.radiobutton_ChangeFolder);
            Box.BoxChild boxChild3 = (Box.BoxChild)this.vbox2[this.radiobutton_ChangeFolder];
            boxChild3.Position = 2;
            boxChild3.Expand = false;
            boxChild3.Fill = false;
            vBox.Add(this.vbox2);
            Box.BoxChild boxChild4 = (Box.BoxChild)vBox[this.vbox2];
            boxChild4.Position = 0;
            boxChild4.Expand = false;
            boxChild4.Fill = false;
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
            base.DefaultWidth = 500;
            base.DefaultHeight = 140;
            base.Show();
        }
    }
}
