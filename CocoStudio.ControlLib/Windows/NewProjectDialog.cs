// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.NewProjectDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using CocoStudio.ControlLib.Event;
using CocoStudio.ControlLib.Model;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Components;
using MonoDevelop.Core;
using Stetic;
using System;
using System.IO;

namespace CocoStudio.ControlLib.Windows
{
    public class NewProjectDialog : Dialog
    {
        private EventBox evtbx_border;

        private Table table1;

        private Entry entry_Name;

        private HBox hbox3;

        private Entry entry_Path;

        private Button button_Browse;

        private Label label_Name;

        private Label label_Path;

        private HBox hbox_cancelOKBox;

        private Button buttonCancel;

        private Button buttonOk;

        public event EventHandler<NewProjectEventArgs> NewProjectEvent;

        public string FilePath
        {
            get;
            set;
        }

        public bool IsConfirm
        {
            get;
            set;
        }

        private string ProjectText
        {
            get;
            set;
        }

        public bool IsClose
        {
            get;
            set;
        }

        public NewProjectDialog(Gtk.Window parentWindow, string title = "NewProject")
        {
            this.Build();
            this.SetToDialogStyle(parentWindow, true, true, true);
            this.buttonOk.Name = "MainButton";
            this.Init();
            this.InitEvent();
            this.ReadLanuageConfigFile();
            base.Title = title;
        }

        public NewProjectDialog(Gtk.Window parentWindow, string title, bool canEditProjectName)
            : this(parentWindow, title)
        {
            this.entry_Path.HasFocus = true;
            this.entry_Name.IsEditable = canEditProjectName;
            this.entry_Name.CanFocus = false;
        }

        private void ChangeBtnPosion()
        {
            if (!Platform.IsMac)
            {
                Box.BoxChild boxChild = (Box.BoxChild)this.hbox_cancelOKBox[this.buttonOk];
                Box.BoxChild boxChild2 = (Box.BoxChild)this.hbox_cancelOKBox[this.buttonCancel];
                boxChild.Position = 0;
                boxChild2.Position = 1;
            }
        }

        private void Init()
        {
            base.AllowGrow = false;
            Rectangle rectangle;
            if (LanguageOption.CurrentLanguage == LanguageType.Spanish)
            {
                rectangle = new Rectangle(0, 0, 500, 130);
            }
            else
            {
                rectangle = new Rectangle(0, 0, 450, 130);
            }
            base.WidthRequest = rectangle.Width;
            base.HeightRequest = rectangle.Height;
            this.entry_Path.IsEditable = false;
            this.evtbx_border.ModifyBg(StateType.Normal, LabelStyleSetting.RootBG);
            this.ChangeBtnPosion();
            this.buttonOk.GrabDefault();
            this.entry_Path.ActivatesDefault = true;
            this.entry_Name.ActivatesDefault = true;
        }

        private void InitEvent()
        {
            base.WidgetEvent += new WidgetEventHandler(this.NewProjectWindow_WidgetEvent);
            this.button_Browse.Clicked += new EventHandler(this.OnButtonBrowseClicked);
            this.buttonOk.Clicked += new EventHandler(this.OnbuttonOkClicked);
            this.buttonCancel.Clicked += new EventHandler(this.OnButtonCancelClicked);
            this.entry_Name.Changed += new EventHandler(this.entry_Name_Changed);
        }

        private void ReadLanuageConfigFile()
        {
            this.label_Name.Text = LanguageInfo.Dialog_ProjectName;
            this.label_Path.Text = LanguageInfo.Dialog_ProjectPath;
            string text = LanguageInfo.Dialog_Browser;
            if (text.Length < 5)
            {
                text = "   " + text + "   ";
            }
            this.button_Browse.Label = text;
            this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
            this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
        }

        private void NewProjectWindow_WidgetEvent(object o, WidgetEventArgs args)
        {
            if (args.Event.Type == EventType.Delete)
            {
                this.IsClose = true;
            }
        }

        protected override void OnRealized()
        {
            base.ModifyBase(StateType.Normal, new Color(255, 0, 0));
            base.OnRealized();
        }

        public void SetWindowsDefaultValue(string projectName, string projectPath)
        {
            this.entry_Name.Text = projectName;
            this.entry_Path.Text = projectPath;
        }

        public void SetLabelText(string name, string path)
        {
            this.label_Name.Text = name;
            this.label_Path.Text = path;
        }

        public void SetEnable(bool bProjPathEnable = true)
        {
            this.entry_Path.Sensitive = bProjPathEnable;
            this.button_Browse.Sensitive = bProjPathEnable;
        }

        protected void OnButtonBrowseClicked(object sender, EventArgs e)
        {
            SelectFolderDialog selectFolderDialog = new SelectFolderDialog();
            selectFolderDialog.TransientFor = this;
            selectFolderDialog.Title = LanguageInfo.Dialog_ProjectPath;
            selectFolderDialog.Action = FileChooserAction.CreateFolder;
            selectFolderDialog.SelectMultiple = false;
            string text = null;
            if (selectFolderDialog.Run())
            {
                text = selectFolderDialog.SelectedFile;
            }
            if (!string.IsNullOrEmpty(text))
            {
                this.entry_Path.Text = text;
            }
        }

        private void OnbuttonOkClicked(object sender, EventArgs e)
        {
            if (this.CheckParam() && this.NewProjectEvent != null)
            {
                this.IsConfirm = true;
                this.FilePath = this.entry_Path.Text;
                this.ProjectText = this.entry_Name.Text;
                this.Destroy();
                NewProjectEventArgs newProjectEventArgs = new NewProjectEventArgs(this.ProjectText, this.FilePath);
                if (this.NewProjectEvent != null)
                {
                    this.NewProjectEvent(this, newProjectEventArgs);
                }
                if (!newProjectEventArgs.IsCanceled)
                {
                    ApplicationCurrent.MainWindow.Title = this.ProjectText;
                }
            }
        }

        private bool CheckParam()
        {
            bool result;
            try
            {
                string path = System.IO.Path.Combine(this.entry_Path.Text, this.entry_Name.Text);
                if (Directory.Exists(path))
                {
                    MessageBox.Show(LanguageInfo.MessageBox_Content42, this, null, MessageBoxImage.Info);
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch
            {
                MessageBox.Show(LanguageInfo.MessageBox_Content144, this, null, MessageBoxImage.Info);
                result = false;
            }
            return result;
        }

        private void entry_Name_Changed(object sender, EventArgs e)
        {
            this.buttonOk.Sensitive = ProjectViewModel.IsMatchToName(this.entry_Name.Text);
        }

        protected void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Destroy();
        }

        protected virtual void Build()
        {
            Gui.Initialize(this);
            base.Name = "CocoStudio.ControlLib.Windows.NewProjectDialog";
            base.WindowPosition = WindowPosition.CenterOnParent;
            VBox vBox = base.VBox;
            vBox.Name = "dialog1_VBox";
            vBox.BorderWidth = 2u;
            this.evtbx_border = new EventBox();
            this.evtbx_border.Name = "evtbx_border";
            this.evtbx_border.BorderWidth = 12u;
            this.table1 = new Table(2u, 2u, false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = 6u;
            this.table1.ColumnSpacing = 6u;
            this.entry_Name = new Entry();
            this.entry_Name.CanFocus = true;
            this.entry_Name.Name = "entry_Name";
            this.entry_Name.IsEditable = true;
            this.entry_Name.InvisibleChar = '●';
            this.table1.Add(this.entry_Name);
            Table.TableChild tableChild = (Table.TableChild)this.table1[this.entry_Name];
            tableChild.LeftAttach = 1u;
            tableChild.RightAttach = 2u;
            tableChild.YOptions = AttachOptions.Fill;
            this.hbox3 = new HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            this.entry_Path = new Entry();
            this.entry_Path.CanFocus = true;
            this.entry_Path.Name = "entry_Path";
            this.entry_Path.IsEditable = true;
            this.entry_Path.InvisibleChar = '●';
            this.hbox3.Add(this.entry_Path);
            Box.BoxChild boxChild = (Box.BoxChild)this.hbox3[this.entry_Path];
            boxChild.Position = 0;
            this.button_Browse = new Button();
            this.button_Browse.CanFocus = true;
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.UseUnderline = true;
            this.button_Browse.Label = Catalog.GetString("浏览");
            this.hbox3.Add(this.button_Browse);
            Box.BoxChild boxChild2 = (Box.BoxChild)this.hbox3[this.button_Browse];
            boxChild2.Position = 1;
            boxChild2.Expand = false;
            boxChild2.Fill = false;
            this.table1.Add(this.hbox3);
            Table.TableChild tableChild2 = (Table.TableChild)this.table1[this.hbox3];
            tableChild2.TopAttach = 1u;
            tableChild2.BottomAttach = 2u;
            tableChild2.LeftAttach = 1u;
            tableChild2.RightAttach = 2u;
            tableChild2.YOptions = AttachOptions.Fill;
            this.label_Name = new Label();
            this.label_Name.Name = "label_Name";
            this.label_Name.Xalign = 1f;
            this.label_Name.LabelProp = Catalog.GetString("项目名称");
            this.table1.Add(this.label_Name);
            Table.TableChild tableChild3 = (Table.TableChild)this.table1[this.label_Name];
            tableChild3.XOptions = AttachOptions.Fill;
            tableChild3.YOptions = AttachOptions.Fill;
            this.label_Path = new Label();
            this.label_Path.Name = "label_Path";
            this.label_Path.Xalign = 1f;
            this.label_Path.LabelProp = Catalog.GetString("项目路径");
            this.table1.Add(this.label_Path);
            Table.TableChild tableChild4 = (Table.TableChild)this.table1[this.label_Path];
            tableChild4.TopAttach = 1u;
            tableChild4.BottomAttach = 2u;
            tableChild4.XOptions = AttachOptions.Fill;
            tableChild4.YOptions = AttachOptions.Fill;
            this.evtbx_border.Add(this.table1);
            vBox.Add(this.evtbx_border);
            Box.BoxChild boxChild3 = (Box.BoxChild)vBox[this.evtbx_border];
            boxChild3.Position = 0;
            boxChild3.Expand = false;
            boxChild3.Fill = false;
            HButtonBox actionArea = base.ActionArea;
            actionArea.Name = "dialog1_ActionArea";
            actionArea.Spacing = 10;
            actionArea.BorderWidth = 5u;
            actionArea.LayoutStyle = ButtonBoxStyle.End;
            this.hbox_cancelOKBox = new HBox();
            this.hbox_cancelOKBox.Name = "hbox_cancelOKBox";
            this.hbox_cancelOKBox.Spacing = 6;
            this.buttonCancel = new Button();
            this.buttonCancel.WidthRequest = 80;
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.hbox_cancelOKBox.Add(this.buttonCancel);
            Box.BoxChild boxChild4 = (Box.BoxChild)this.hbox_cancelOKBox[this.buttonCancel];
            boxChild4.Position = 0;
            boxChild4.Expand = false;
            boxChild4.Fill = false;
            this.buttonOk = new Button();
            this.buttonOk.WidthRequest = 80;
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.hbox_cancelOKBox.Add(this.buttonOk);
            Box.BoxChild boxChild5 = (Box.BoxChild)this.hbox_cancelOKBox[this.buttonOk];
            boxChild5.Position = 1;
            boxChild5.Expand = false;
            boxChild5.Fill = false;
            actionArea.Add(this.hbox_cancelOKBox);
            ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild)actionArea[this.hbox_cancelOKBox];
            buttonBoxChild.Expand = false;
            buttonBoxChild.Fill = false;
            if (base.Child != null)
            {
                base.Child.ShowAll();
            }
            base.DefaultWidth = 363;
            base.DefaultHeight = 134;
            base.Show();
        }
    }
}
