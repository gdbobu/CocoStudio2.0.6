// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.NewFileDialog
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
using System.Text.RegularExpressions;

namespace CocoStudio.ControlLib
{
    public class NewFileDialog : Gtk.Dialog
    {
        private FileTypeItem selectedItem;

        private FileDialogResult result;

        private new Gdk.Size DefaultSize;

        private Color DisableFontColor = new Color(129, 129, 141);

        private Color NomalFontColor = new Color(244, 244, 243);

        private EntryIntEx entryWidth = new EntryIntEx
        {
            MinValue = 0,
            MaxValue = 4096,
            WidthRequest = 60,
            CanFocus = true,
            IsInteger = true
        };

        private EntryIntEx entryHeight = new EntryIntEx
        {
            MinValue = 0,
            MaxValue = 4096,
            WidthRequest = 60,
            CanFocus = true,
            IsInteger = true
        };

        private EFileType CurrentType;

        private string parentDir;

        private Gtk.Table tab_Root;

        private Entry entry_FileName;

        private Gtk.HBox hb_FileType;

        private Gtk.Label lab_FileDescribe;

        private Gtk.Label lab_FileDescribeContent;

        private Gtk.Label lab_FileName;

        private Gtk.Label lab_FileSize;

        private Gtk.Label lab_FileType;

        private Gtk.Table table_widthHeight;

        private Gtk.Alignment alignment_widthPx;

        private Gtk.Label label2;

        private EventBox evtbx_height;

        private EventBox evtbx_width;

        private Gtk.Label label1;

        private Gtk.Label label3;

        private Gtk.Label label4;

        private Gtk.Button buttonCancel;

        private Gtk.Button btnNew;

        public NewFileDialog(Gtk.Window parentWindow, string parentDir, Gdk.Size size)
        {
            this.DefaultSize = size;
            this.parentDir = parentDir;
            this.Build();
            this.btnNew.Name = "MainButton";
            this.btnNew.GrabDefault();
            this.entry_FileName.ActivatesDefault = true;
            this.SetToDialogStyle(parentWindow, true, true, true);
            this.InitiaFileType();
            this.InitiaEvent();
            this.InitShow();
            this.InitPlatform();
            this.InitLanguages();
        }

        private void InitLanguages()
        {
            base.Title = LanguageInfo.NewFile_Title;
            this.btnNew.Label = LanguageInfo.Dialog_ButtonNew;
            this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
            this.lab_FileName.LabelProp = LanguageInfo.NewFile_FileName;
            this.lab_FileType.LabelProp = LanguageInfo.Display_ProgressType;
            this.lab_FileDescribe.LabelProp = LanguageInfo.NewFile_FileDescription;
            this.lab_FileSize.LabelProp = LanguageInfo.NewFile_FileSize;
            this.label2.LabelProp = (this.label4.LabelProp = LanguageInfo.NewFile_Pixel);
            this.label1.LabelProp = LanguageInfo.NewFile_Width;
            this.label3.LabelProp = LanguageInfo.NewFile_Height;
            this.lab_FileDescribeContent.LabelProp = LanguageInfo.NewFile_SceneDes;
        }

        private void InitiaFileType()
        {
            this.SetWigetPropeties(new FileTypeInfo(ImageIcon.GetIcon("CocoStudio.ControlLib.Resource.sence.png"), "Scene", EFileType.Scene, ".csd", LanguageInfo.NewFile_Scene)
            {
                Description = LanguageInfo.NewFile_SceneDes
            }, 0, null);
            this.SetWigetPropeties(new FileTypeInfo(ImageIcon.GetIcon("CocoStudio.ControlLib.Resource.layer.png"), "Layer", EFileType.Layer, ".csd", LanguageInfo.NewFile_Layer)
            {
                Description = LanguageInfo.NewFile_LayerDes
            }, 1, null);
            this.SetWigetPropeties(new FileTypeInfo(ImageIcon.GetIcon("CocoStudio.ControlLib.Resource.node.png"), "Node", EFileType.Node, ".csd", LanguageInfo.Display_Component_Entity)
            {
                Description = LanguageInfo.NewFile_NodeDes
            }, 2, null);
            this.SetWigetPropeties(new FileTypeInfo(ImageIcon.GetIcon("CocoStudio.ControlLib.Resource.plist.png"), "Plist", EFileType.Plist, ".csi", LanguageInfo.NewFile_Plist)
            {
                Description = LanguageInfo.NewFile_PlistDes
            }, 3, null);
            base.ShowAll();
        }

        private void InitiaEvent()
        {
            base.DeleteEvent += new DeleteEventHandler(this.NewFileDialog_DeleteEvent);
            this.btnNew.Clicked += new EventHandler(this.btnNew_Clicked);
            this.buttonCancel.Clicked += new EventHandler(this.buttonCancel_Clicked);
            this.entryHeight.Changed += new EventHandler(this.entry_Changed);
            this.entryWidth.Changed += new EventHandler(this.entry_Changed);
            this.entry_FileName.Changed += new EventHandler(this.entry_Changed);
        }

        private void InitPlatform()
        {
            ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild)base.ActionArea[this.btnNew];
            ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild)base.ActionArea[this.buttonCancel];
            if (Platform.IsMac)
            {
                buttonBoxChild2.Position = 0;
                buttonBoxChild.Position = 1;
            }
            else
            {
                buttonBoxChild2.Position = 1;
                buttonBoxChild.Position = 0;
            }
            if (base.Child != null)
            {
                base.Child.ShowAll();
            }
            base.Show();
        }

        private void SetWigetPropeties(FileTypeInfo item, int cloum, FileTypeItem fileItem = null)
        {
            fileItem = (fileItem ?? new FileTypeItem());
            if (cloum == 0)
            {
                this.selectedItem = fileItem;
                this.SetSelceted(item);
                fileItem.Selected();
            }
            else
            {
                fileItem.UnSelected();
            }
            fileItem.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.fileItem_ButtonReleaseEvent);
            fileItem.InitiaView(item);
            this.hb_FileType.Add(fileItem);
            Gtk.Box.BoxChild boxChild = (Gtk.Box.BoxChild)this.hb_FileType[fileItem];
            boxChild.Position = cloum;
            boxChild.Expand = false;
            boxChild.Fill = false;
        }

        private void InitShow()
        {
            this.evtbx_width.Add(this.entryWidth);
            this.evtbx_height.Add(this.entryHeight);
            base.ExposeEvent += new ExposeEventHandler(this.NewFileDialog_ExposeEvent);
            this.lab_FileDescribeContent.ModifyFg(StateType.Normal, this.DisableFontColor);
            this.entry_FileName.MaxLength = 50;
        }

        private void NewFileDialog_ExposeEvent(object o, ExposeEventArgs args)
        {
            int left = this.lab_FileSize.Allocation.Left;
            int num = this.btnNew.Allocation.Top - 8;
            int num2 = (this.btnNew.Allocation.Right < this.buttonCancel.Allocation.Right) ? this.buttonCancel.Allocation.Right : this.btnNew.Allocation.Right;
            int y2_ = num;
            int x1_ = left;
            int num3 = num + 1;
            int x2_ = num2;
            int y2_2 = num3;
            Gdk.GC gC = new Gdk.GC(base.GdkWindow);
            gC.RgbFgColor = new Color(49, 51, 51);
            base.GdkWindow.DrawLine(gC, left, num, num2, y2_);
            gC.RgbFgColor = new Color(85, 86, 90);
            base.GdkWindow.DrawLine(gC, x1_, num3, x2_, y2_2);
        }

        public FileDialogResult ShowDialog()
        {
            base.Run();
            FileDialogResult fileDialogResult;
            if (this.result == null)
            {
                fileDialogResult = null;
            }
            else
            {
                while (!this.result.IsSuccessful)
                {
                    base.Run();
                }
                fileDialogResult = this.result;
            }
            return fileDialogResult;
        }

        private void entry_Changed(object sender, EventArgs e)
        {
            this.btnNew.Sensitive = (!string.IsNullOrWhiteSpace(this.entry_FileName.Text) && (this.CurrentType == EFileType.Plist || (!string.IsNullOrWhiteSpace(this.entryWidth.Text) && !string.IsNullOrWhiteSpace(this.entryHeight.Text))));
        }

        private void btnNew_Clicked(object sender, EventArgs e)
        {
            this.result = new FileDialogResult();
            FileTypeInfo fileTypeInfo = this.selectedItem.FileTypeInfo;
            double value = this.entryHeight.Value;
            double value2 = this.entryWidth.Value;
            Xwt.Size size = new Xwt.Size(value2, value);
            if (RegexModel.IsHasSystemReserveName(this.entry_FileName.Text))
            {
                MessageBox.Show(LanguageInfo.MessageBox215_WindowsNameLimit, this, null, MessageBoxImage.Info);
                this.entry_FileName.SelectRegion(0, this.entry_FileName.Text.Length);
                this.entry_FileName.HasFocus = true;
                this.result.IsSuccessful = false;
            }
            else
            {
                string text = this.entry_FileName.Text + fileTypeInfo.Extension;
                if (!Regex.IsMatch(text, "^[A-Za-z0-9,._-]+$") || Regex.IsMatch(text, "[\\*\\\\/:?<>|\"]"))
                {
                    MessageBox.Show(LanguageInfo.MessageBox216_FileNameLimit, this, null, MessageBoxImage.Info);
                    this.entry_FileName.SelectRegion(0, this.entry_FileName.Text.Length);
                    this.entry_FileName.HasFocus = true;
                    this.result.IsSuccessful = false;
                }
                else if (!FileService.IsValidFileName(text))
                {
                    string info = LanguageInfo.NewFile_WrongName.Replace("<", "&lt;").Replace(">", "&gt;");
                    MessageBox.Show(info, this, null, MessageBoxImage.Info);
                    this.entry_FileName.SelectRegion(0, this.entry_FileName.Text.Length);
                    this.entry_FileName.HasFocus = true;
                    this.result.IsSuccessful = false;
                }
                else
                {
                    string value3 = text.Substring(0, text.Length - fileTypeInfo.Extension.Length);
                    if (string.IsNullOrWhiteSpace(value3))
                    {
                        MessageBox.Show(LanguageInfo.MessageBox_Content110, this, null, MessageBoxImage.Info);
                        this.entry_FileName.HasFocus = true;
                        this.result.IsSuccessful = false;
                    }
                    else
                    {
                        this.result.FileName = text;
                        this.result.Size = size;
                        this.result.FileType = this.selectedItem.FileTypeInfo.FileType;
                        string path = System.IO.Path.Combine(this.parentDir, this.result.FileName);
                        if (File.Exists(path))
                        {
                            MessageBox.Show(LanguageInfo.NewFile_SameName, this, null, MessageBoxImage.Info);
                            this.entry_FileName.SelectRegion(0, this.entry_FileName.Text.Length);
                            this.entry_FileName.HasFocus = true;
                            this.result.IsSuccessful = false;
                        }
                        else
                        {
                            this.Destroy();
                            this.Dispose();
                        }
                    }
                }
            }
        }

        private void buttonCancel_Clicked(object sender, EventArgs e)
        {
            this.result = null;
            this.Destroy();
            this.Dispose();
        }

        public string GetNewFileName(string oldName, string parentDir, string extension)
        {
            string path = System.IO.Path.Combine(parentDir, oldName + extension);
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(oldName);
            int num = 1;
            while (File.Exists(path))
            {
                string path2 = fileNameWithoutExtension + num + extension;
                path = System.IO.Path.Combine(parentDir, path2);
                num++;
            }
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }

        public void SetSelceted(FileTypeInfo info)
        {
            string newFileName = this.GetNewFileName(info.Name, this.parentDir, info.Extension);
            this.entry_FileName.Text = newFileName;
            int length = newFileName.Length;
            this.entry_FileName.SelectRegion(0, length);
            this.entry_FileName.HasFocus = true;
            this.JudgeView(info.FileType);
        }

        private void fileItem_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
        {
            FileTypeItem fileTypeItem = o as FileTypeItem;
            if (fileTypeItem != null && !fileTypeItem.Equals(this.selectedItem))
            {
                if (this.selectedItem != null)
                {
                    this.selectedItem.UnSelected();
                }
                fileTypeItem.Selected();
                this.selectedItem = fileTypeItem;
                this.SetSelceted(this.selectedItem.FileTypeInfo);
                this.lab_FileDescribeContent.LabelProp = this.selectedItem.FileTypeInfo.Description;
            }
        }

        [ConnectBefore]
        private void NewFileDialog_DeleteEvent(object o, DeleteEventArgs args)
        {
            this.result = null;
            this.Destroy();
            this.Dispose();
        }

        private void JudgeView(EFileType filetype)
        {
            this.CurrentType = filetype;
            switch (filetype)
            {
                case EFileType.Scene:
                    this.entryWidth.MaxValue = 2147483647;
                    this.entryHeight.MaxValue = 2147483647;
                    this.SetSensitive(this.DefaultSize.Width, this.DefaultSize.Height, false);
                    break;
                case EFileType.Layer:
                    this.entryWidth.MaxValue = 4096;
                    this.entryHeight.MaxValue = 4096;
                    this.SetSensitive(this.DefaultSize.Width, this.DefaultSize.Height, true);
                    break;
                case EFileType.Node:
                    this.SetSensitive(0, 0, false);
                    break;
                case EFileType.Plist:
                    this.SetSensitive(-1, -1, false);
                    break;
            }
        }

        private void SetSensitive(int w, int h, bool canset = true)
        {
            this.label2.ModifyFg(StateType.Normal, canset ? this.NomalFontColor : this.DisableFontColor);
            this.label4.ModifyFg(StateType.Normal, canset ? this.NomalFontColor : this.DisableFontColor);
            this.label1.ModifyFg(StateType.Normal, canset ? this.NomalFontColor : this.DisableFontColor);
            this.label3.ModifyFg(StateType.Normal, canset ? this.NomalFontColor : this.DisableFontColor);
            if (w != -1)
            {
                this.entryWidth.Value = (double)w;
            }
            else
            {
                this.entryWidth.Text = string.Empty;
            }
            if (h != -1)
            {
                this.entryHeight.Value = (double)h;
            }
            else
            {
                this.entryHeight.Text = string.Empty;
            }
            this.entryWidth.Sensitive = canset;
            this.entryHeight.Sensitive = canset;
        }

        protected virtual void Build()
        {
            Gui.Initialize(this);
            base.Name = "CocoStudio.ControlLib.NewFileDialog";
            base.Title = Catalog.GetString("新建文件");
            base.WindowPosition = WindowPosition.CenterOnParent;
            base.Resizable = false;
            base.DefaultWidth = 450;
            base.DefaultHeight = 240;
            Gtk.VBox vBox = base.VBox;
            vBox.Name = "dialog1_VBox";
            vBox.BorderWidth = 2u;
            this.tab_Root = new Gtk.Table(4u, 2u, false);
            this.tab_Root.Name = "tab_Root";
            this.tab_Root.RowSpacing = 12u;
            this.tab_Root.ColumnSpacing = 18u;
            this.tab_Root.BorderWidth = 15u;
            this.entry_FileName = new Entry();
            this.entry_FileName.WidthRequest = 330;
            this.entry_FileName.CanFocus = true;
            this.entry_FileName.Name = "entry_FileName";
            this.entry_FileName.IsEditable = true;
            this.entry_FileName.InvisibleChar = '●';
            this.tab_Root.Add(this.entry_FileName);
            Gtk.Table.TableChild tableChild = (Gtk.Table.TableChild)this.tab_Root[this.entry_FileName];
            tableChild.LeftAttach = 1u;
            tableChild.RightAttach = 2u;
            tableChild.XOptions = Gtk.AttachOptions.Fill;
            tableChild.YOptions = Gtk.AttachOptions.Fill;
            this.hb_FileType = new Gtk.HBox();
            this.hb_FileType.HeightRequest = 80;
            this.hb_FileType.Name = "hb_FileType";
            this.hb_FileType.Spacing = 6;
            this.tab_Root.Add(this.hb_FileType);
            Gtk.Table.TableChild tableChild2 = (Gtk.Table.TableChild)this.tab_Root[this.hb_FileType];
            tableChild2.TopAttach = 1u;
            tableChild2.BottomAttach = 2u;
            tableChild2.LeftAttach = 1u;
            tableChild2.RightAttach = 2u;
            tableChild2.XOptions = Gtk.AttachOptions.Fill;
            tableChild2.YOptions = Gtk.AttachOptions.Fill;
            this.lab_FileDescribe = new Gtk.Label();
            this.lab_FileDescribe.Name = "lab_FileDescribe";
            this.lab_FileDescribe.Xalign = 1f;
            this.lab_FileDescribe.Yalign = 0f;
            this.lab_FileDescribe.LabelProp = Catalog.GetString("描述");
            this.tab_Root.Add(this.lab_FileDescribe);
            Gtk.Table.TableChild tableChild3 = (Gtk.Table.TableChild)this.tab_Root[this.lab_FileDescribe];
            tableChild3.TopAttach = 2u;
            tableChild3.BottomAttach = 3u;
            tableChild3.XOptions = Gtk.AttachOptions.Fill;
            tableChild3.YOptions = Gtk.AttachOptions.Fill;
            this.lab_FileDescribeContent = new Gtk.Label();
            this.lab_FileDescribeContent.WidthRequest = 330;
            this.lab_FileDescribeContent.HeightRequest = 60;
            this.lab_FileDescribeContent.Name = "lab_FileDescribeContent";
            this.lab_FileDescribeContent.Xalign = 0f;
            this.lab_FileDescribeContent.Yalign = 0f;
            this.lab_FileDescribeContent.LabelProp = Catalog.GetString("描述文件");
            this.lab_FileDescribeContent.Wrap = true;
            this.tab_Root.Add(this.lab_FileDescribeContent);
            Gtk.Table.TableChild tableChild4 = (Gtk.Table.TableChild)this.tab_Root[this.lab_FileDescribeContent];
            tableChild4.TopAttach = 2u;
            tableChild4.BottomAttach = 3u;
            tableChild4.LeftAttach = 1u;
            tableChild4.RightAttach = 2u;
            tableChild4.YOptions = Gtk.AttachOptions.Fill;
            this.lab_FileName = new Gtk.Label();
            this.lab_FileName.Name = "lab_FileName";
            this.lab_FileName.Xalign = 1f;
            this.lab_FileName.LabelProp = Catalog.GetString("文件名称");
            this.tab_Root.Add(this.lab_FileName);
            Gtk.Table.TableChild tableChild5 = (Gtk.Table.TableChild)this.tab_Root[this.lab_FileName];
            tableChild5.XOptions = Gtk.AttachOptions.Fill;
            tableChild5.YOptions = Gtk.AttachOptions.Fill;
            this.lab_FileSize = new Gtk.Label();
            this.lab_FileSize.Name = "lab_FileSize";
            this.lab_FileSize.Xalign = 1f;
            this.lab_FileSize.Yalign = 0.1f;
            this.lab_FileSize.LabelProp = Catalog.GetString("大小");
            this.tab_Root.Add(this.lab_FileSize);
            Gtk.Table.TableChild tableChild6 = (Gtk.Table.TableChild)this.tab_Root[this.lab_FileSize];
            tableChild6.TopAttach = 3u;
            tableChild6.BottomAttach = 4u;
            tableChild6.XOptions = Gtk.AttachOptions.Fill;
            tableChild6.YOptions = Gtk.AttachOptions.Fill;
            this.lab_FileType = new Gtk.Label();
            this.lab_FileType.Name = "lab_FileType";
            this.lab_FileType.Xalign = 1f;
            this.lab_FileType.Yalign = 0.3f;
            this.lab_FileType.LabelProp = Catalog.GetString("类型");
            this.tab_Root.Add(this.lab_FileType);
            Gtk.Table.TableChild tableChild7 = (Gtk.Table.TableChild)this.tab_Root[this.lab_FileType];
            tableChild7.TopAttach = 1u;
            tableChild7.BottomAttach = 2u;
            tableChild7.XOptions = Gtk.AttachOptions.Fill;
            tableChild7.YOptions = Gtk.AttachOptions.Fill;
            this.table_widthHeight = new Gtk.Table(2u, 4u, false);
            this.table_widthHeight.Name = "table_widthHeight";
            this.table_widthHeight.RowSpacing = 6u;
            this.table_widthHeight.ColumnSpacing = 6u;
            this.alignment_widthPx = new Gtk.Alignment(0.5f, 0.5f, 1f, 1f);
            this.alignment_widthPx.Name = "alignment_widthPx";
            this.alignment_widthPx.RightPadding = 25u;
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Catalog.GetString("px");
            this.alignment_widthPx.Add(this.label2);
            this.table_widthHeight.Add(this.alignment_widthPx);
            Gtk.Table.TableChild tableChild8 = (Gtk.Table.TableChild)this.table_widthHeight[this.alignment_widthPx];
            tableChild8.LeftAttach = 1u;
            tableChild8.RightAttach = 2u;
            tableChild8.XOptions = Gtk.AttachOptions.Fill;
            tableChild8.YOptions = Gtk.AttachOptions.Fill;
            this.evtbx_height = new EventBox();
            this.evtbx_height.WidthRequest = 100;
            this.evtbx_height.Name = "evtbx_height";
            this.table_widthHeight.Add(this.evtbx_height);
            Gtk.Table.TableChild tableChild9 = (Gtk.Table.TableChild)this.table_widthHeight[this.evtbx_height];
            tableChild9.LeftAttach = 2u;
            tableChild9.RightAttach = 3u;
            tableChild9.XOptions = Gtk.AttachOptions.Fill;
            tableChild9.YOptions = Gtk.AttachOptions.Fill;
            this.evtbx_width = new EventBox();
            this.evtbx_width.WidthRequest = 100;
            this.evtbx_width.Name = "evtbx_width";
            this.table_widthHeight.Add(this.evtbx_width);
            Gtk.Table.TableChild tableChild10 = (Gtk.Table.TableChild)this.table_widthHeight[this.evtbx_width];
            tableChild10.XOptions = Gtk.AttachOptions.Fill;
            tableChild10.YOptions = Gtk.AttachOptions.Fill;
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Catalog.GetString("宽");
            this.table_widthHeight.Add(this.label1);
            Gtk.Table.TableChild tableChild11 = (Gtk.Table.TableChild)this.table_widthHeight[this.label1];
            tableChild11.TopAttach = 1u;
            tableChild11.BottomAttach = 2u;
            tableChild11.XOptions = Gtk.AttachOptions.Fill;
            tableChild11.YOptions = Gtk.AttachOptions.Fill;
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Catalog.GetString("高");
            this.table_widthHeight.Add(this.label3);
            Gtk.Table.TableChild tableChild12 = (Gtk.Table.TableChild)this.table_widthHeight[this.label3];
            tableChild12.TopAttach = 1u;
            tableChild12.BottomAttach = 2u;
            tableChild12.LeftAttach = 2u;
            tableChild12.RightAttach = 3u;
            tableChild12.XOptions = Gtk.AttachOptions.Fill;
            tableChild12.YOptions = Gtk.AttachOptions.Fill;
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Catalog.GetString("px");
            this.table_widthHeight.Add(this.label4);
            Gtk.Table.TableChild tableChild13 = (Gtk.Table.TableChild)this.table_widthHeight[this.label4];
            tableChild13.LeftAttach = 3u;
            tableChild13.RightAttach = 4u;
            tableChild13.XOptions = Gtk.AttachOptions.Fill;
            tableChild13.YOptions = Gtk.AttachOptions.Fill;
            this.tab_Root.Add(this.table_widthHeight);
            Gtk.Table.TableChild tableChild14 = (Gtk.Table.TableChild)this.tab_Root[this.table_widthHeight];
            tableChild14.TopAttach = 3u;
            tableChild14.BottomAttach = 4u;
            tableChild14.LeftAttach = 1u;
            tableChild14.RightAttach = 2u;
            tableChild14.XOptions = Gtk.AttachOptions.Fill;
            tableChild14.YOptions = Gtk.AttachOptions.Fill;
            vBox.Add(this.tab_Root);
            Gtk.Box.BoxChild boxChild = (Gtk.Box.BoxChild)vBox[this.tab_Root];
            boxChild.Position = 0;
            boxChild.Expand = false;
            boxChild.Fill = false;
            HButtonBox actionArea = base.ActionArea;
            actionArea.Name = "dialog1_ActionArea";
            actionArea.Spacing = 10;
            actionArea.BorderWidth = 5u;
            actionArea.LayoutStyle = ButtonBoxStyle.End;
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = Catalog.GetString("取消");
            base.AddActionWidget(this.buttonCancel, -6);
            ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild)actionArea[this.buttonCancel];
            buttonBoxChild.Expand = false;
            buttonBoxChild.Fill = false;
            this.btnNew = new Gtk.Button();
            this.btnNew.CanDefault = true;
            this.btnNew.CanFocus = true;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseUnderline = true;
            this.btnNew.Label = Catalog.GetString("新建");
            base.AddActionWidget(this.btnNew, -5);
            ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild)actionArea[this.btnNew];
            buttonBoxChild2.Position = 1;
            buttonBoxChild2.Expand = false;
            buttonBoxChild2.Fill = false;
            if (base.Child != null)
            {
                base.Child.ShowAll();
            }
            base.Show();
        }
    }
}