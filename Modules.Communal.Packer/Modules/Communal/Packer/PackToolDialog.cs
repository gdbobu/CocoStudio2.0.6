// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PackToolDialog
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.ControlLib.Windows;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Modules.Communal.Packer
{
    public class PackToolDialog : Dialog
    {
        private List<string> fileList;

        private List<string> canNotPackFileList;

        private List<string> allCanvasFileList;

        private List<string> allCanvasNotPackFileList;

        private string projectName;

        private bool bCreateFromSceneEditor;

        private string exportFileName = string.Empty;

        private List<string> imageFileList = new List<string>();

        private PackToolViewModel viewModel;

        private BackgroundWorker worker;

        private PackerHelper packerHelper;

        private CoverPromptDialog coverPrompt;

        private VBox vbox_root;

        private HBox hbox_path;

        private Label label_Path;

        private Entry entry_Path;

        private Button button_Browse;

        private HBox hbox_main;

        private VBox vbox_left;

        private Frame frame_Resource;

        private Alignment GtkAlignment_Resource;

        private VBox vbox_Resource;

        private RadioButton radiobutton_UseSmallImage;

        private RadioButton radiobutton_AllSmallImage;

        private RadioButton radiobutton_UseBigImage;

        private RadioButton radiobutton_AllBigImage;

        private Label GtkLabel_Resource;

        private Frame frame_Canvas;

        private Alignment GtkAlignment_Canvas;

        private VBox vbox_Canvas;

        private RadioButton radiobutton_CurrentCanvas;

        private RadioButton radiobutton_AllCanvas;

        private Label GtkLabel_Canvas;

        private Frame frame_Picture;

        private Alignment GtkAlignment_Picture;

        private Table table_Picture;

        private ComboBox combobox_Format;

        private ComboBox combobox_Sort;

        private HBox hbox_checkBox;

        private CheckButton checkbutton_Formatting;

        private CheckButton checkbutton_Crop;

        private CheckButton checkbutton_Binary;

        private Label label_Gap;

        private Label label_MaxHeight;

        private Label label_MaxWidth;

        private Label label_Zoom;

        private Label label1_Format;

        private Label label1_Sort;

        private SpinButton spinbutton_Gap;

        private SpinButton spinbutton_MaxHeight;

        private SpinButton spinbutton_MaxWidth;

        private SpinButton spinbutton_Zoom;

        private Label GtkLabel_Picture;

        private ProgressBar progressbar;

        private Button buttonCancel;

        private Button buttonOk;

        public string FinalFilePath
        {
            get;
            set;
        }

        public string FilePath
        {
            get
            {
                return this.entry_Path.Text;
            }
            set
            {
                this.entry_Path.Text = value;
            }
        }

        public bool IsCheckAllCanvas
        {
            get;
            set;
        }

        public bool IsCheckBigImage
        {
            get;
            set;
        }

        private string ResourcesPath
        {
            get;
            set;
        }

        private bool IsFilePathToConfig
        {
            get;
            set;
        }

        public bool IsFormat
        {
            get
            {
                return this.checkbutton_Formatting.Active;
            }
        }

        public bool IsExportBinary
        {
            get
            {
                return this.checkbutton_Binary.Active;
            }
        }

        public bool IsCheckConfirm
        {
            get;
            set;
        }

        public PackToolDialog()
        {
            this.Build();
            this.ChangeBtnPosion();
            this.viewModel = new PackToolViewModel();
            base.AllowGrow = false;
            this.Init();
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
            this.SetToDialogStyle(null, true, true, true);
            this.InitWorker();
            this.InitEvent();
            this.InitDefualtValue();
            this.ReadMultiLanguageConfig();
            this.packerHelper = new PackerHelper();
            this.packerHelper.ProgressChangeEvent += delegate(int a)
            {
                this.worker.ReportProgress(a);
            };
        }

        private void InitWorker()
        {
            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
        }

        private void InitEvent()
        {
            this.button_Browse.Clicked += new EventHandler(this.OnButtonBrowseClicked);
            this.buttonOk.Clicked += new EventHandler(this.OnbuttonOkClicked);
            this.buttonCancel.Clicked += new EventHandler(this.OnButtonCancelClicked);
            this.radiobutton_AllCanvas.Clicked += new EventHandler(this.radio_Canvas_Checked);
            this.radiobutton_CurrentCanvas.Clicked += new EventHandler(this.radio_Canvas_Checked);
            this.radiobutton_UseSmallImage.Clicked += new EventHandler(this.radio_Resoures_Checked);
            this.radiobutton_UseBigImage.Clicked += new EventHandler(this.radio_Resoures_Checked);
            this.radiobutton_AllSmallImage.Clicked += new EventHandler(this.radio_Resoures_Checked);
            this.radiobutton_AllBigImage.Clicked += new EventHandler(this.radio_Resoures_Checked);
            base.KeyReleaseEvent += new KeyReleaseEventHandler(this.NewProjectWindow_KeyReleaseEvent);
        }

        private void InitDefualtValue()
        {
            this.spinbutton_MaxWidth.Value = (double)this.viewModel.MaxSourceWidth;
            this.spinbutton_MaxHeight.Value = (double)this.viewModel.MaxSourceHeight;
            this.spinbutton_Gap.Value = (double)this.viewModel.PaddingPixel;
            this.spinbutton_Zoom.Value = (double)this.viewModel.ResourceScale;
            this.combobox_Format.Active = (int)this.viewModel.ImageForm;
            this.combobox_Sort.Active = (int)this.viewModel.SortForm;
            this.checkbutton_Crop.Active = this.viewModel.Cilp;
            this.checkbutton_Formatting.Active = this.viewModel.FormatExport;
            this.entry_Path.Text = this.viewModel.ExportJsonPath;
            if (this.viewModel.ExprotCanvas == 1)
            {
                this.radiobutton_CurrentCanvas.Active = true;
                this.IsCheckAllCanvas = false;
            }
            else
            {
                this.radiobutton_AllCanvas.Active = true;
                this.IsCheckAllCanvas = false;
            }
            switch (this.viewModel.ExprotResouces)
            {
                case 1:
                    this.radiobutton_UseSmallImage.Active = true;
                    this.IsCheckBigImage = false;
                    break;
                case 2:
                    this.radiobutton_UseBigImage.Active = true;
                    this.IsCheckBigImage = true;
                    break;
                case 3:
                    this.radiobutton_AllSmallImage.Active = true;
                    this.IsCheckBigImage = false;
                    break;
                case 4:
                    this.radiobutton_AllBigImage.Active = true;
                    this.IsCheckBigImage = true;
                    break;
            }
        }

        private void ReadMultiLanguageConfig()
        {
            base.Title = LanguageInfo.Display_ExportProject;
            this.label_MaxWidth.Text = LanguageInfo.textBlock1;
            this.label_MaxHeight.Text = LanguageInfo.textBlock2;
            this.label_Gap.Text = LanguageInfo.Display_PicturePadding;
            this.label1_Sort.Text = LanguageInfo.Display_SortAlgorithm;
            this.label1_Format.Text = LanguageInfo.textBlock7;
            this.label_Zoom.Text = LanguageInfo.textBlock_ResourceDataScale;
            string text = LanguageInfo.Dialog_Browser;
            if (text.Length < 5)
            {
                text = "   " + text + "   ";
            }
            this.button_Browse.Label = text;
            this.checkbutton_Crop.Label = LanguageInfo.Display_ClipName;
            this.checkbutton_Formatting.Label = LanguageInfo.formatExport;
            this.label_Path.Text = LanguageInfo.Dialog_ProjectPath;
            this.GtkLabel_Canvas.Text = LanguageInfo.GroupBox_ExportCanvas;
            this.GtkLabel_Resource.Text = LanguageInfo.GroupBox_ExportResource;
            this.GtkLabel_Picture.Text = LanguageInfo.GroupBox_ExportImage;
            this.radiobutton_CurrentCanvas.Label = LanguageInfo.radio_CurrentCanvas;
            this.radiobutton_AllCanvas.Label = LanguageInfo.radio_AllCanvas;
            this.radiobutton_UseSmallImage.Label = LanguageInfo.radioSmallImage;
            this.radiobutton_UseBigImage.Label = LanguageInfo.radioBigImage;
            this.radiobutton_AllSmallImage.Label = LanguageInfo.radioAllSmallImage;
            this.radiobutton_AllBigImage.Label = LanguageInfo.radioAllBigImage;
            this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
            this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
            this.checkbutton_Binary.Label = LanguageInfo.Packer_Binary;
        }

        private void SaveViewValue()
        {
            this.viewModel.MaxSourceWidth = (int)this.spinbutton_MaxWidth.Value;
            this.viewModel.MaxSourceHeight = (int)this.spinbutton_MaxHeight.Value;
            this.viewModel.PaddingPixel = (int)this.spinbutton_Gap.Value;
            this.viewModel.ResourceScale = (float)this.spinbutton_Zoom.Value;
            this.viewModel.ImageForm = (ImageFileFormat)this.combobox_Format.Active;
            this.viewModel.SortForm = (SortFormat)this.combobox_Sort.Active;
            this.viewModel.Cilp = this.checkbutton_Crop.Active;
            this.viewModel.FormatExport = this.checkbutton_Formatting.Active;
            this.viewModel.ISExportBinaryJson = this.checkbutton_Binary.Active;
            this.viewModel.ExportJsonPath = this.entry_Path.Text;
        }

        private bool StartPack()
        {
            ImageFileFormat active = (ImageFileFormat)this.combobox_Format.Active;
            bool active2 = this.checkbutton_Crop.Active;
            this.packerHelper.resourcePathStr = this.ResourcesPath;
            List<string> list = new List<string>();
            List<string> notPackDefaultFileList = new List<string>();
            if (!this.IsCheckAllCanvas)
            {
                list = this.fileList;
                notPackDefaultFileList = this.canNotPackFileList;
            }
            else
            {
                list = this.allCanvasFileList;
                notPackDefaultFileList = this.allCanvasNotPackFileList;
            }
            bool result;
            if (this.radiobutton_UseBigImage.Active)
            {
                this.packerHelper.InitWithData((int)this.spinbutton_Gap.Value, (int)this.spinbutton_MaxWidth.Value, (int)this.spinbutton_MaxHeight.Value, this.combobox_Format.Active);
                this.packerHelper.PackerCanNotBatchImage(notPackDefaultFileList, this.FilePath, this.ResourcesPath);
                result = this.packerHelper.PackerWithList(list, this.FilePath, this.projectName, active2, active, this.ResourcesPath, PackToolViewModel.Instance.ResourceScale, true);
            }
            else if (this.radiobutton_UseSmallImage.Active)
            {
                this.packerHelper.PackerCanNotBatchImage(notPackDefaultFileList, this.FilePath, this.ResourcesPath);
                result = this.packerHelper.PackerSmallImage(list, this.FilePath, this.ResourcesPath, true);
            }
            else if (this.radiobutton_AllBigImage.Active)
            {
                this.packerHelper.InitWithData((int)this.spinbutton_Gap.Value, (int)this.spinbutton_MaxWidth.Value, (int)this.spinbutton_MaxHeight.Value, this.combobox_Format.Active);
                List<string> list2 = this.packerHelper.ParseDirectory(this.ResourcesPath);
                this.packerHelper.PackerCanNotBatchImage(notPackDefaultFileList, this.FilePath, this.ResourcesPath);
                this.ResourceFliter(list2);
                result = this.packerHelper.PackerWithList(list2, this.FilePath, this.projectName, active2, active, this.ResourcesPath, PackToolViewModel.Instance.ResourceScale, true);
            }
            else
            {
                result = this.packerHelper.PackerAllImage(list, notPackDefaultFileList, this.FilePath, this.ResourcesPath, true);
            }
            return result;
        }

        private void ExportProject()
        {
            string empty = string.Empty;
            bool flag = false;
            try
            {
                flag = this.StartPack();
            }
            catch (Exception)
            {
            }
            string info;
            if (!this.packerHelper.IsNoFileCollider)
            {
                info = LanguageInfo.MessageBox_Content158;
                this.IsCheckConfirm = true;
                this.imageFileList = this.packerHelper.saveImageList;
            }
            else if (flag)
            {
                info = LanguageInfo.MessageBox_Content59;
                this.IsCheckConfirm = true;
                this.imageFileList = this.packerHelper.saveImageList;
                this.viewModel.SaveXmlExprotConfiguration();
            }
            else
            {
                info = LanguageInfo.MessageBox_Content60;
                this.imageFileList = (List<string>)null;
            }
            MessageBox.Show(info, (Gtk.Window)null, (string)null, MessageBoxImage.Info);
            this.FinalFilePath = this.FilePath;
        }

        private void ResourceFliter(List<string> allFileList)
        {
            if (this.canNotPackFileList != null && this.canNotPackFileList.Count > 0)
            {
                foreach (string current in this.canNotPackFileList)
                {
                    if (allFileList.Contains(current))
                    {
                        allFileList.Remove(current);
                    }
                }
            }
            for (int i = allFileList.Count - 1; i >= 0; i--)
            {
                if (System.IO.Path.GetExtension(allFileList[i]).ToLower() == ".plist")
                {
                    this.packerHelper.CopyPlistAndBigImage(allFileList[i], this.FilePath);
                    string item = this.packerHelper.ConvertToMacPath(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(allFileList[i]), System.IO.Path.GetFileNameWithoutExtension(allFileList[i]) + ".png"));
                    allFileList.Remove(allFileList[i]);
                    if (allFileList.Contains(item))
                    {
                        allFileList.Remove(item);
                    }
                }
            }
            if (this.allCanvasFileList != null && this.allCanvasFileList.Count > 0)
            {
                foreach (string current2 in this.allCanvasFileList)
                {
                    if (System.IO.Path.IsPathRooted(current2))
                    {
                        allFileList.Add(current2);
                    }
                }
            }
        }

        private bool IsPathMatch(string FilePath)
        {
            return FilePath.Contains("*") || FilePath.Contains("?") || FilePath.Contains("<") || FilePath.Contains(">") || FilePath.Contains("|") || string.IsNullOrEmpty(FilePath);
        }

        public List<string> GetSaveImageList()
        {
            return this.imageFileList;
        }

        public void AllInitData(List<string> allFileList, List<string> allCanNotPackFileList)
        {
            this.allCanvasFileList = allFileList;
            this.allCanvasNotPackFileList = allCanNotPackFileList;
        }

        public void InitData(List<string> _fileNameList, List<string> _notPackFileList, string _fullPath, string _projectName, string _currentCanvasName, bool isCreatedBySceneEditor = false)
        {
            this.fileList = _fileNameList;
            this.canNotPackFileList = _notPackFileList;
            this.ResourcesPath = _fullPath;
            this.projectName = System.IO.Path.GetFileNameWithoutExtension(_projectName);
            this.bCreateFromSceneEditor = isCreatedBySceneEditor;
            if (_currentCanvasName != null)
            {
                this.exportFileName = System.IO.Path.GetFileNameWithoutExtension(_currentCanvasName);
                string text = this.radiobutton_AllCanvas.Active ? this.projectName : this.exportFileName;
                if (isCreatedBySceneEditor)
                {
                    this.FilePath = System.IO.Path.Combine(_fullPath, "publish");
                }
                else
                {
                    string directoryName = System.IO.Path.GetDirectoryName(_fullPath);
                    if (!this.IsFilePathToConfig)
                    {
                        this.FilePath = System.IO.Path.Combine(directoryName, "Export", text);
                    }
                    else
                    {
                        this.FilePath = System.IO.Path.Combine(this.FilePath, text);
                    }
                }
            }
        }

        public void InitData(List<string> _fileNameList, string _fullPath, string _projectName, bool isCreatedBySceneEditor = false)
        {
            this.fileList = _fileNameList;
            this.canNotPackFileList = new List<string>();
            this.projectName = (this.exportFileName = System.IO.Path.GetFileNameWithoutExtension(_projectName));
            this.ResourcesPath = _fullPath;
            this.bCreateFromSceneEditor = isCreatedBySceneEditor;
            if (isCreatedBySceneEditor)
            {
                this.FilePath = System.IO.Path.Combine(_fullPath, "publish");
            }
            else
            {
                string directoryName = System.IO.Path.GetDirectoryName(_fullPath);
                if (!this.IsFilePathToConfig)
                {
                    this.FilePath = System.IO.Path.Combine(directoryName, "Export", _projectName);
                }
                else
                {
                    this.FilePath = System.IO.Path.Combine(this.FilePath, this.projectName);
                }
            }
        }

        private void NewProjectWindow_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            if (args.Event.Key == Gdk.Key.Return || args.Event.Key == Gdk.Key.KP_Enter || args.Event.Key == Gdk.Key.ISO_Enter)
            {
                this.OnbuttonOkClicked(o, null);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.StartPack();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressbar.Fraction = (double)e.ProgressPercentage * 0.01;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressbar.Fraction = 1.0;
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Destroy();
        }

        private void OnbuttonOkClicked(object sender, EventArgs e)
        {
            if (this.IsPathMatch(this.FilePath))
            {
                MessageBox.Show("导出路径为空或者是非法路径,请重新设置路径", null, null, MessageBoxImage.Info);
            }
            else
            {
                this.SaveViewValue();
                if (this.bCreateFromSceneEditor)
                {
                    this.ExportProject();
                }
                else if (Directory.Exists(this.FilePath) && System.IO.Path.GetDirectoryName(this.FilePath) != null)
                {
                    bool flag = this.CoveringJudgment();
                    if (flag)
                    {
                        return;
                    }
                }
                else
                {
                    this.ExportProject();
                }
                this.Destroy();
            }
        }

        private void OnButtonBrowseClicked(object sender, EventArgs e)
        {
            string folder = FileChooserDialogModel.GetBrowseDialogPath("导出路径", false, "", false).Folder;
            if (!string.IsNullOrEmpty(folder))
            {
                if (folder != System.IO.Path.GetDirectoryName(this.FilePath))
                {
                    PackToolViewModel.Instance.ExprotPath = folder;
                }
                if (this.radiobutton_AllCanvas.Active)
                {
                    this.FilePath = System.IO.Path.Combine(folder, this.projectName);
                }
                else
                {
                    this.FilePath = System.IO.Path.Combine(folder, this.exportFileName);
                }
            }
        }

        private bool CoveringJudgment()
        {
            this.coverPrompt = new CoverPromptDialog(this.FilePath);
            this.coverPrompt.ConfirmClickHandler += new EventHandler(this.coverPrompt_ConfirmClickHandler);
            this.coverPrompt.Run();
            this.coverPrompt.Destroy();
            return this.coverPrompt.IsCanceled;
        }

        private void coverPrompt_ConfirmClickHandler(object sender, EventArgs e)
        {
            this.FilePath = sender.ToString();
            this.coverPrompt.Destroy();
            this.ExportProject();
        }

        private void radio_Canvas_Checked(object sender, EventArgs e)
        {
            string name = (sender as RadioButton).Name;
            this.viewModel.ExprotCanvas = ((name == "radiobutton_CurrentCanvas") ? 1 : 2);
            this.IsCheckAllCanvas = (this.viewModel.ExprotCanvas != 1);
        }

        private void radio_Resoures_Checked(object sender, EventArgs e)
        {
            string name = (sender as RadioButton).Name;
            int exprotResouces = 1;
            string text = name;
            if (text != null)
            {
                if (!(text == "radiobutton_UseSmallImage"))
                {
                    if (!(text == "radiobutton_UseBigImage"))
                    {
                        if (!(text == "radiobutton_AllSmallImage"))
                        {
                            if (text == "radiobutton_AllBigImage")
                            {
                                this.SetControlsEnable(true);
                                this.IsCheckBigImage = true;
                                exprotResouces = 4;
                            }
                        }
                        else
                        {
                            this.SetControlsEnable(false);
                            this.IsCheckBigImage = false;
                            exprotResouces = 3;
                        }
                    }
                    else
                    {
                        this.SetControlsEnable(true);
                        this.IsCheckBigImage = true;
                        exprotResouces = 2;
                    }
                }
                else
                {
                    this.SetControlsEnable(false);
                    this.IsCheckBigImage = false;
                    exprotResouces = 1;
                }
            }
            this.viewModel.ExprotResouces = exprotResouces;
        }

        private void SetControlsEnable(bool value)
        {
            this.spinbutton_MaxWidth.Sensitive = value;
            this.spinbutton_MaxHeight.Sensitive = value;
            this.spinbutton_Gap.Sensitive = value;
            this.spinbutton_Zoom.Sensitive = value;
            this.combobox_Format.Sensitive = value;
            this.combobox_Sort.Sensitive = value;
            this.checkbutton_Crop.Sensitive = value;
        }

        protected virtual void Build()
        {
            Gui.Initialize(this);
            base.Name = "Modules.Communal.Packer.PackToolDialog";
            base.WindowPosition = WindowPosition.CenterOnParent;
            VBox vBox = base.VBox;
            vBox.Name = "dialog1_VBox";
            vBox.BorderWidth = 2u;
            this.vbox_root = new VBox();
            this.vbox_root.Name = "vbox_root";
            this.vbox_root.Spacing = 6;
            this.vbox_root.BorderWidth = 5u;
            this.hbox_path = new HBox();
            this.hbox_path.Name = "hbox_path";
            this.hbox_path.Spacing = 6;
            this.label_Path = new Label();
            this.label_Path.Name = "label_Path";
            this.label_Path.LabelProp = Catalog.GetString("项目路径");
            this.hbox_path.Add(this.label_Path);
            Box.BoxChild boxChild = (Box.BoxChild)this.hbox_path[this.label_Path];
            boxChild.Position = 0;
            boxChild.Expand = false;
            boxChild.Fill = false;
            boxChild.Padding = 5u;
            this.entry_Path = new Entry();
            this.entry_Path.WidthRequest = 370;
            this.entry_Path.CanFocus = true;
            this.entry_Path.Name = "entry_Path";
            this.entry_Path.IsEditable = true;
            this.entry_Path.InvisibleChar = '●';
            this.hbox_path.Add(this.entry_Path);
            Box.BoxChild boxChild2 = (Box.BoxChild)this.hbox_path[this.entry_Path];
            boxChild2.Position = 1;
            this.button_Browse = new Button();
            this.button_Browse.CanFocus = true;
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.UseUnderline = true;
            this.button_Browse.Label = Catalog.GetString("   浏览   ");
            this.hbox_path.Add(this.button_Browse);
            Box.BoxChild boxChild3 = (Box.BoxChild)this.hbox_path[this.button_Browse];
            boxChild3.Position = 2;
            boxChild3.Expand = false;
            boxChild3.Fill = false;
            this.vbox_root.Add(this.hbox_path);
            Box.BoxChild boxChild4 = (Box.BoxChild)this.vbox_root[this.hbox_path];
            boxChild4.Position = 0;
            boxChild4.Expand = false;
            boxChild4.Fill = false;
            this.hbox_main = new HBox();
            this.hbox_main.Name = "hbox_main";
            this.hbox_main.Spacing = 6;
            this.vbox_left = new VBox();
            this.vbox_left.Name = "vbox_left";
            this.vbox_left.Spacing = 12;
            this.frame_Resource = new Frame();
            this.frame_Resource.Name = "frame_Resource";
            this.frame_Resource.ShadowType = ShadowType.EtchedOut;
            this.frame_Resource.LabelXalign = 0.05f;
            this.GtkAlignment_Resource = new Alignment(0f, 0f, 1f, 1f);
            this.GtkAlignment_Resource.Name = "GtkAlignment_Resource";
            this.GtkAlignment_Resource.LeftPadding = 12u;
            this.GtkAlignment_Resource.BorderWidth = 8u;
            this.vbox_Resource = new VBox();
            this.vbox_Resource.Name = "vbox_Resource";
            this.vbox_Resource.Spacing = 10;
            this.radiobutton_UseSmallImage = new RadioButton(Catalog.GetString("导出使用小图"));
            this.radiobutton_UseSmallImage.CanFocus = true;
            this.radiobutton_UseSmallImage.Name = "radiobutton_UseSmallImage";
            this.radiobutton_UseSmallImage.DrawIndicator = true;
            this.radiobutton_UseSmallImage.UseUnderline = true;
            this.radiobutton_UseSmallImage.Group = new SList(IntPtr.Zero);
            this.vbox_Resource.Add(this.radiobutton_UseSmallImage);
            Box.BoxChild boxChild5 = (Box.BoxChild)this.vbox_Resource[this.radiobutton_UseSmallImage];
            boxChild5.Position = 0;
            boxChild5.Expand = false;
            boxChild5.Fill = false;
            this.radiobutton_AllSmallImage = new RadioButton(Catalog.GetString("导出全部小图"));
            this.radiobutton_AllSmallImage.CanFocus = true;
            this.radiobutton_AllSmallImage.Name = "radiobutton_AllSmallImage";
            this.radiobutton_AllSmallImage.DrawIndicator = true;
            this.radiobutton_AllSmallImage.UseUnderline = true;
            this.radiobutton_AllSmallImage.Group = this.radiobutton_UseSmallImage.Group;
            this.vbox_Resource.Add(this.radiobutton_AllSmallImage);
            Box.BoxChild boxChild6 = (Box.BoxChild)this.vbox_Resource[this.radiobutton_AllSmallImage];
            boxChild6.Position = 1;
            boxChild6.Expand = false;
            boxChild6.Fill = false;
            this.radiobutton_UseBigImage = new RadioButton(Catalog.GetString("导出使用大图"));
            this.radiobutton_UseBigImage.CanFocus = true;
            this.radiobutton_UseBigImage.Name = "radiobutton_UseBigImage";
            this.radiobutton_UseBigImage.DrawIndicator = true;
            this.radiobutton_UseBigImage.UseUnderline = true;
            this.radiobutton_UseBigImage.Group = this.radiobutton_UseSmallImage.Group;
            this.vbox_Resource.Add(this.radiobutton_UseBigImage);
            Box.BoxChild boxChild7 = (Box.BoxChild)this.vbox_Resource[this.radiobutton_UseBigImage];
            boxChild7.Position = 2;
            boxChild7.Expand = false;
            boxChild7.Fill = false;
            this.radiobutton_AllBigImage = new RadioButton(Catalog.GetString("导出全部大图"));
            this.radiobutton_AllBigImage.CanFocus = true;
            this.radiobutton_AllBigImage.Name = "radiobutton_AllBigImage";
            this.radiobutton_AllBigImage.DrawIndicator = true;
            this.radiobutton_AllBigImage.UseUnderline = true;
            this.radiobutton_AllBigImage.Group = this.radiobutton_UseSmallImage.Group;
            this.vbox_Resource.Add(this.radiobutton_AllBigImage);
            Box.BoxChild boxChild8 = (Box.BoxChild)this.vbox_Resource[this.radiobutton_AllBigImage];
            boxChild8.Position = 3;
            boxChild8.Expand = false;
            boxChild8.Fill = false;
            this.GtkAlignment_Resource.Add(this.vbox_Resource);
            this.frame_Resource.Add(this.GtkAlignment_Resource);
            this.GtkLabel_Resource = new Label();
            this.GtkLabel_Resource.Name = "GtkLabel_Resource";
            this.GtkLabel_Resource.LabelProp = Catalog.GetString("<b>导出资源</b>");
            this.GtkLabel_Resource.UseMarkup = true;
            this.frame_Resource.LabelWidget = this.GtkLabel_Resource;
            this.vbox_left.Add(this.frame_Resource);
            Box.BoxChild boxChild9 = (Box.BoxChild)this.vbox_left[this.frame_Resource];
            boxChild9.Position = 0;
            this.frame_Canvas = new Frame();
            this.frame_Canvas.Name = "frame_Canvas";
            this.frame_Canvas.ShadowType = ShadowType.EtchedOut;
            this.frame_Canvas.LabelXalign = 0.05f;
            this.GtkAlignment_Canvas = new Alignment(0f, 0f, 1f, 1f);
            this.GtkAlignment_Canvas.Name = "GtkAlignment_Canvas";
            this.GtkAlignment_Canvas.LeftPadding = 12u;
            this.GtkAlignment_Canvas.BorderWidth = 8u;
            this.vbox_Canvas = new VBox();
            this.vbox_Canvas.Name = "vbox_Canvas";
            this.vbox_Canvas.Spacing = 10;
            this.radiobutton_CurrentCanvas = new RadioButton(Catalog.GetString("导出当前画布"));
            this.radiobutton_CurrentCanvas.CanFocus = true;
            this.radiobutton_CurrentCanvas.Name = "radiobutton_CurrentCanvas";
            this.radiobutton_CurrentCanvas.DrawIndicator = true;
            this.radiobutton_CurrentCanvas.UseUnderline = true;
            this.radiobutton_CurrentCanvas.Group = new SList(IntPtr.Zero);
            this.vbox_Canvas.Add(this.radiobutton_CurrentCanvas);
            Box.BoxChild boxChild10 = (Box.BoxChild)this.vbox_Canvas[this.radiobutton_CurrentCanvas];
            boxChild10.Position = 0;
            boxChild10.Expand = false;
            boxChild10.Fill = false;
            this.radiobutton_AllCanvas = new RadioButton(Catalog.GetString("导出全部画布"));
            this.radiobutton_AllCanvas.CanFocus = true;
            this.radiobutton_AllCanvas.Name = "radiobutton_AllCanvas";
            this.radiobutton_AllCanvas.DrawIndicator = true;
            this.radiobutton_AllCanvas.UseUnderline = true;
            this.radiobutton_AllCanvas.Group = this.radiobutton_CurrentCanvas.Group;
            this.vbox_Canvas.Add(this.radiobutton_AllCanvas);
            Box.BoxChild boxChild11 = (Box.BoxChild)this.vbox_Canvas[this.radiobutton_AllCanvas];
            boxChild11.Position = 1;
            boxChild11.Expand = false;
            boxChild11.Fill = false;
            this.GtkAlignment_Canvas.Add(this.vbox_Canvas);
            this.frame_Canvas.Add(this.GtkAlignment_Canvas);
            this.GtkLabel_Canvas = new Label();
            this.GtkLabel_Canvas.Name = "GtkLabel_Canvas";
            this.GtkLabel_Canvas.LabelProp = Catalog.GetString("<b>导出画布</b>");
            this.GtkLabel_Canvas.UseMarkup = true;
            this.frame_Canvas.LabelWidget = this.GtkLabel_Canvas;
            this.vbox_left.Add(this.frame_Canvas);
            Box.BoxChild boxChild12 = (Box.BoxChild)this.vbox_left[this.frame_Canvas];
            boxChild12.Position = 1;
            this.hbox_main.Add(this.vbox_left);
            Box.BoxChild boxChild13 = (Box.BoxChild)this.hbox_main[this.vbox_left];
            boxChild13.Position = 0;
            this.frame_Picture = new Frame();
            this.frame_Picture.Name = "frame_Picture";
            this.frame_Picture.ShadowType = ShadowType.EtchedOut;
            this.frame_Picture.LabelXalign = 0.05f;
            this.GtkAlignment_Picture = new Alignment(0f, 0f, 1f, 1f);
            this.GtkAlignment_Picture.Name = "GtkAlignment_Picture";
            this.GtkAlignment_Picture.LeftPadding = 12u;
            this.GtkAlignment_Picture.BorderWidth = 8u;
            this.table_Picture = new Table(7u, 2u, false);
            this.table_Picture.Name = "table_Picture";
            this.table_Picture.RowSpacing = 6u;
            this.table_Picture.ColumnSpacing = 6u;
            this.combobox_Format = ComboBox.NewText();
            this.combobox_Format.AppendText(Catalog.GetString("Png\r"));
            this.combobox_Format.AppendText(Catalog.GetString("Jpeg"));
            this.combobox_Format.Sensitive = false;
            this.combobox_Format.Name = "combobox_Format";
            this.table_Picture.Add(this.combobox_Format);
            Table.TableChild tableChild = (Table.TableChild)this.table_Picture[this.combobox_Format];
            tableChild.TopAttach = 4u;
            tableChild.BottomAttach = 5u;
            tableChild.LeftAttach = 1u;
            tableChild.RightAttach = 2u;
            tableChild.XOptions = AttachOptions.Fill;
            tableChild.YOptions = AttachOptions.Fill;
            this.combobox_Sort = ComboBox.NewText();
            this.combobox_Sort.AppendText(Catalog.GetString("Sample\r"));
            this.combobox_Sort.AppendText(Catalog.GetString("Normal\r"));
            this.combobox_Sort.AppendText(Catalog.GetString("Intelligent"));
            this.combobox_Sort.Sensitive = false;
            this.combobox_Sort.Name = "combobox_Sort";
            this.table_Picture.Add(this.combobox_Sort);
            Table.TableChild tableChild2 = (Table.TableChild)this.table_Picture[this.combobox_Sort];
            tableChild2.TopAttach = 5u;
            tableChild2.BottomAttach = 6u;
            tableChild2.LeftAttach = 1u;
            tableChild2.RightAttach = 2u;
            tableChild2.XOptions = AttachOptions.Fill;
            tableChild2.YOptions = AttachOptions.Fill;
            this.hbox_checkBox = new HBox();
            this.hbox_checkBox.Name = "hbox_checkBox";
            this.hbox_checkBox.Spacing = 6;
            this.checkbutton_Formatting = new CheckButton();
            this.checkbutton_Formatting.CanFocus = true;
            this.checkbutton_Formatting.Name = "checkbutton_Formatting";
            this.checkbutton_Formatting.Label = Catalog.GetString("格式化输出");
            this.checkbutton_Formatting.DrawIndicator = true;
            this.checkbutton_Formatting.UseUnderline = true;
            this.hbox_checkBox.Add(this.checkbutton_Formatting);
            Box.BoxChild boxChild14 = (Box.BoxChild)this.hbox_checkBox[this.checkbutton_Formatting];
            boxChild14.Position = 0;
            this.checkbutton_Crop = new CheckButton();
            this.checkbutton_Crop.Sensitive = false;
            this.checkbutton_Crop.CanFocus = true;
            this.checkbutton_Crop.Name = "checkbutton_Crop";
            this.checkbutton_Crop.Label = Catalog.GetString("裁切");
            this.checkbutton_Crop.DrawIndicator = true;
            this.checkbutton_Crop.UseUnderline = true;
            this.hbox_checkBox.Add(this.checkbutton_Crop);
            Box.BoxChild boxChild15 = (Box.BoxChild)this.hbox_checkBox[this.checkbutton_Crop];
            boxChild15.Position = 1;
            boxChild15.Padding = 10u;
            this.checkbutton_Binary = new CheckButton();
            this.checkbutton_Binary.Sensitive = false;
            this.checkbutton_Binary.CanFocus = true;
            this.checkbutton_Binary.Name = "checkbutton_Binary";
            this.checkbutton_Binary.Label = Catalog.GetString("二进制");
            this.checkbutton_Binary.DrawIndicator = true;
            this.checkbutton_Binary.UseUnderline = true;
            this.hbox_checkBox.Add(this.checkbutton_Binary);
            Box.BoxChild boxChild16 = (Box.BoxChild)this.hbox_checkBox[this.checkbutton_Binary];
            boxChild16.Position = 2;
            boxChild16.Expand = false;
            this.table_Picture.Add(this.hbox_checkBox);
            Table.TableChild tableChild3 = (Table.TableChild)this.table_Picture[this.hbox_checkBox];
            tableChild3.TopAttach = 6u;
            tableChild3.BottomAttach = 7u;
            tableChild3.RightAttach = 2u;
            tableChild3.XOptions = AttachOptions.Fill;
            tableChild3.YOptions = AttachOptions.Fill;
            this.label_Gap = new Label();
            this.label_Gap.Name = "label_Gap";
            this.label_Gap.Xalign = 1f;
            this.label_Gap.LabelProp = Catalog.GetString("碎图裂隙");
            this.table_Picture.Add(this.label_Gap);
            Table.TableChild tableChild4 = (Table.TableChild)this.table_Picture[this.label_Gap];
            tableChild4.TopAttach = 2u;
            tableChild4.BottomAttach = 3u;
            tableChild4.XOptions = AttachOptions.Fill;
            tableChild4.YOptions = AttachOptions.Fill;
            this.label_MaxHeight = new Label();
            this.label_MaxHeight.Name = "label_MaxHeight";
            this.label_MaxHeight.Xalign = 1f;
            this.label_MaxHeight.LabelProp = Catalog.GetString("图片最大高度");
            this.table_Picture.Add(this.label_MaxHeight);
            Table.TableChild tableChild5 = (Table.TableChild)this.table_Picture[this.label_MaxHeight];
            tableChild5.TopAttach = 1u;
            tableChild5.BottomAttach = 2u;
            tableChild5.XOptions = AttachOptions.Fill;
            tableChild5.YOptions = AttachOptions.Fill;
            this.label_MaxWidth = new Label();
            this.label_MaxWidth.Name = "label_MaxWidth";
            this.label_MaxWidth.Xalign = 1f;
            this.label_MaxWidth.LabelProp = Catalog.GetString("图片最大宽度");
            this.table_Picture.Add(this.label_MaxWidth);
            Table.TableChild tableChild6 = (Table.TableChild)this.table_Picture[this.label_MaxWidth];
            tableChild6.XOptions = AttachOptions.Fill;
            tableChild6.YOptions = AttachOptions.Fill;
            this.label_Zoom = new Label();
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Xalign = 1f;
            this.label_Zoom.LabelProp = Catalog.GetString("数据缩放");
            this.table_Picture.Add(this.label_Zoom);
            Table.TableChild tableChild7 = (Table.TableChild)this.table_Picture[this.label_Zoom];
            tableChild7.TopAttach = 3u;
            tableChild7.BottomAttach = 4u;
            tableChild7.XOptions = AttachOptions.Fill;
            tableChild7.YOptions = AttachOptions.Fill;
            this.label1_Format = new Label();
            this.label1_Format.Name = "label1_Format";
            this.label1_Format.Xalign = 1f;
            this.label1_Format.LabelProp = Catalog.GetString("导出格式");
            this.table_Picture.Add(this.label1_Format);
            Table.TableChild tableChild8 = (Table.TableChild)this.table_Picture[this.label1_Format];
            tableChild8.TopAttach = 4u;
            tableChild8.BottomAttach = 5u;
            tableChild8.XOptions = AttachOptions.Fill;
            tableChild8.YOptions = AttachOptions.Fill;
            this.label1_Sort = new Label();
            this.label1_Sort.Name = "label1_Sort";
            this.label1_Sort.Xalign = 1f;
            this.label1_Sort.LabelProp = Catalog.GetString("样式排序");
            this.table_Picture.Add(this.label1_Sort);
            Table.TableChild tableChild9 = (Table.TableChild)this.table_Picture[this.label1_Sort];
            tableChild9.TopAttach = 5u;
            tableChild9.BottomAttach = 6u;
            tableChild9.XOptions = AttachOptions.Fill;
            tableChild9.YOptions = AttachOptions.Fill;
            this.spinbutton_Gap = new SpinButton(0.1, 1.0, 0.1);
            this.spinbutton_Gap.Sensitive = false;
            this.spinbutton_Gap.CanFocus = true;
            this.spinbutton_Gap.Name = "spinbutton_Gap";
            this.spinbutton_Gap.Adjustment.PageIncrement = 10.0;
            this.spinbutton_Gap.ClimbRate = 1.0;
            this.spinbutton_Gap.Numeric = true;
            this.spinbutton_Gap.Value = 0.1;
            this.table_Picture.Add(this.spinbutton_Gap);
            Table.TableChild tableChild10 = (Table.TableChild)this.table_Picture[this.spinbutton_Gap];
            tableChild10.TopAttach = 2u;
            tableChild10.BottomAttach = 3u;
            tableChild10.LeftAttach = 1u;
            tableChild10.RightAttach = 2u;
            tableChild10.XOptions = AttachOptions.Fill;
            tableChild10.YOptions = AttachOptions.Fill;
            this.spinbutton_MaxHeight = new SpinButton(0.0, 1000000.0, 1.0);
            this.spinbutton_MaxHeight.Sensitive = false;
            this.spinbutton_MaxHeight.CanFocus = true;
            this.spinbutton_MaxHeight.Name = "spinbutton_MaxHeight";
            this.spinbutton_MaxHeight.Adjustment.PageIncrement = 10.0;
            this.spinbutton_MaxHeight.ClimbRate = 1.0;
            this.spinbutton_MaxHeight.Numeric = true;
            this.table_Picture.Add(this.spinbutton_MaxHeight);
            Table.TableChild tableChild11 = (Table.TableChild)this.table_Picture[this.spinbutton_MaxHeight];
            tableChild11.TopAttach = 1u;
            tableChild11.BottomAttach = 2u;
            tableChild11.LeftAttach = 1u;
            tableChild11.RightAttach = 2u;
            tableChild11.XOptions = AttachOptions.Fill;
            tableChild11.YOptions = AttachOptions.Fill;
            this.spinbutton_MaxWidth = new SpinButton(0.0, 1000000.0, 1.0);
            this.spinbutton_MaxWidth.Sensitive = false;
            this.spinbutton_MaxWidth.CanFocus = true;
            this.spinbutton_MaxWidth.Name = "spinbutton_MaxWidth";
            this.spinbutton_MaxWidth.Adjustment.PageIncrement = 10.0;
            this.spinbutton_MaxWidth.ClimbRate = 1.0;
            this.spinbutton_MaxWidth.Numeric = true;
            this.table_Picture.Add(this.spinbutton_MaxWidth);
            Table.TableChild tableChild12 = (Table.TableChild)this.table_Picture[this.spinbutton_MaxWidth];
            tableChild12.LeftAttach = 1u;
            tableChild12.RightAttach = 2u;
            tableChild12.YOptions = AttachOptions.Fill;
            this.spinbutton_Zoom = new SpinButton(0.1, 1.0, 0.1);
            this.spinbutton_Zoom.Sensitive = false;
            this.spinbutton_Zoom.CanFocus = true;
            this.spinbutton_Zoom.Name = "spinbutton_Zoom";
            this.spinbutton_Zoom.Adjustment.PageIncrement = 10.0;
            this.spinbutton_Zoom.ClimbRate = 1.0;
            this.spinbutton_Zoom.Numeric = true;
            this.spinbutton_Zoom.Value = 0.1;
            this.table_Picture.Add(this.spinbutton_Zoom);
            Table.TableChild tableChild13 = (Table.TableChild)this.table_Picture[this.spinbutton_Zoom];
            tableChild13.TopAttach = 3u;
            tableChild13.BottomAttach = 4u;
            tableChild13.LeftAttach = 1u;
            tableChild13.RightAttach = 2u;
            tableChild13.XOptions = AttachOptions.Fill;
            tableChild13.YOptions = AttachOptions.Fill;
            this.GtkAlignment_Picture.Add(this.table_Picture);
            this.frame_Picture.Add(this.GtkAlignment_Picture);
            this.GtkLabel_Picture = new Label();
            this.GtkLabel_Picture.Name = "GtkLabel_Picture";
            this.GtkLabel_Picture.LabelProp = Catalog.GetString("<b>导出图片</b>");
            this.GtkLabel_Picture.UseMarkup = true;
            this.frame_Picture.LabelWidget = this.GtkLabel_Picture;
            this.hbox_main.Add(this.frame_Picture);
            Box.BoxChild boxChild17 = (Box.BoxChild)this.hbox_main[this.frame_Picture];
            boxChild17.Position = 1;
            this.vbox_root.Add(this.hbox_main);
            Box.BoxChild boxChild18 = (Box.BoxChild)this.vbox_root[this.hbox_main];
            boxChild18.Position = 1;
            boxChild18.Expand = false;
            boxChild18.Fill = false;
            this.progressbar = new ProgressBar();
            this.progressbar.Name = "progressbar";
            this.vbox_root.Add(this.progressbar);
            Box.BoxChild boxChild19 = (Box.BoxChild)this.vbox_root[this.progressbar];
            boxChild19.Position = 2;
            boxChild19.Expand = false;
            boxChild19.Fill = false;
            vBox.Add(this.vbox_root);
            Box.BoxChild boxChild20 = (Box.BoxChild)vBox[this.vbox_root];
            boxChild20.Position = 0;
            boxChild20.Expand = false;
            boxChild20.Fill = false;
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
            actionArea.Add(this.buttonOk);
            ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild)actionArea[this.buttonOk];
            buttonBoxChild2.Position = 1;
            buttonBoxChild2.Expand = false;
            buttonBoxChild2.Fill = false;
            if (base.Child != null)
            {
                base.Child.ShowAll();
            }
            base.DefaultWidth = 520;
            base.DefaultHeight = 405;
            base.Show();
        }
    }
}
