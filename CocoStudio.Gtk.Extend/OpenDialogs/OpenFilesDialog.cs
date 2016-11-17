// Decompiled with JetBrains decompiler
// Type: OpenDialogs.OpenFilesDialog
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CustomControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenDialogs
{
  public class OpenFilesDialog : OpenFileDialogEx
  {
    public string FolderParent = string.Empty;
    public List<string> FilesPath = new List<string>();
    private List<string> fileConvert = new List<string>();
    private bool cando = false;
    private IContainer components = (IContainer) null;

    public override string Lable_SelectTexg
    {
      get
      {
        return "选择文件";
      }
    }

    public OpenFilesDialog()
    {
      this.InitializeComponent();
      this.OpenDialog.Multiselect = true;
      this.OpenDialog.Filter = "All Files|*.*";
      this.FilesSelected += new OpenFileDialogEx.FilesChangedHandler(this.OpenFilesDialog_FilesSelected);
      this.FileNameChanged += new OpenFileDialogEx.FileNameChangedHandler(this.OpenFilesDialog_FileNameChanged);
      this.FolderNameChanged += new OpenFileDialogEx.FileNameChangedHandler(this.OpenFilesDialog_FolderNameChanged);
      this.OpenDialog.FileOk += new CancelEventHandler(this.OpenDialog_FileOk);
    }

    private void OpenDialog_FileOk(object sender, CancelEventArgs e)
    {
      this.OnClosingDialog();
      this.OnSelectedNameChanged();
    }

    private void OpenFilesDialog_FolderNameChanged(OpenFileDialogEx sender, string filePath)
    {
      this.cando = true;
      this.fileConvert.Clear();
    }

    private void OpenFilesDialog_FileNameChanged(OpenFileDialogEx sender, string filePath)
    {
      this.cando = true;
      this.fileConvert.Clear();
      if (string.IsNullOrWhiteSpace(filePath))
        return;
      if (filePath.IsFileOrDirectory())
      {
        this.FolderParent = string.Empty;
        this.fileConvert.Add(filePath);
      }
      else
      {
        int count = filePath.LastIndexOf("\\");
        if (count != -1 && count <= filePath.Length)
        {
          string[] strArray = new string(filePath.Skip<char>(count).ToArray<char>()).Split(new string[3]{ "\\", "/", "\"" }, StringSplitOptions.RemoveEmptyEntries);
          if (strArray != null && ((IEnumerable<string>) strArray).Count<string>() > 0)
          {
            string str = ((IEnumerable<string>) strArray).FirstOrDefault<string>((Func<string, bool>) (i => !string.IsNullOrWhiteSpace(i)));
            int num = filePath.IndexOf(str);
            this.FolderParent = num != -1 ? new string(filePath.Take<char>(num - 1).ToArray<char>()) : string.Empty;
            ((IEnumerable<string>) strArray).ToList<string>().ForEach((Action<string>) (i =>
            {
              if (string.IsNullOrWhiteSpace(i))
                return;
              this.fileConvert.Add(i);
            }));
          }
        }
      }
    }

    private void OpenFilesDialog_FilesSelected(OpenFileDialogEx sender, IntPtr handle)
    {
      if (!this.cando)
        return;
      StringBuilder stringBuilder = new StringBuilder(256);
      NativeMethods.SendMessage(NativeMethods.GetParent(handle), 1126, 256, stringBuilder);
      if (!string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        this.FolderParent = stringBuilder.ToString();
      this.FilesPath.Clear();
      List<string> stringList = new List<string>();
      this.textBox1.Text = string.Empty;
      IntPtr listView32Handle = NativeMethods.GetParent(handle).GetSysListView32Handle();
      if (!(listView32Handle != IntPtr.Zero))
        return;
      List<string> slectedItemsText = listView32Handle.GetSlectedItemsText(0);
      if (slectedItemsText != null && slectedItemsText.Count > 0)
      {
        if (slectedItemsText.Count > 1)
        {
          List<string> list = slectedItemsText.OrderBy<string, string>((Func<string, string>) (i => i)).ToList<string>();
          if (this.fileConvert.Count > 0)
            this.fileConvert = this.fileConvert.OrderBy<string, string>((Func<string, string>) (i => i)).ToList<string>();
          int index1 = 0;
          int count = list.Count;
          for (int index2 = 0; index2 < count; ++index2)
          {
            string str1 = ((IEnumerable<string>) list[index2].Split(new string[1]{ "\0" }, StringSplitOptions.RemoveEmptyEntries)).FirstOrDefault<string>();
            if (!Directory.Exists(Path.Combine(this.FolderParent, str1)))
            {
              string folderParent = this.FolderParent;
              string str2 = string.Empty;
              if (!string.IsNullOrWhiteSpace(this.FolderParent))
              {
                string str3 = Path.Combine(this.FolderParent, str1);
                try
                {
                  FileInfo fileInfo = new FileInfo(str3);
                  if (fileInfo != null && string.IsNullOrWhiteSpace(fileInfo.Extension))
                    str3 += ".lnk";
                  if (fileInfo != null && !fileInfo.Exists && this.fileConvert.Count > index1 && !Directory.Exists(this.fileConvert[index1]))
                    str3 = this.fileConvert[index1];
                  str2 = this.CheckFile(str1, str3, ref folderParent);
                }
                catch
                {
                }
              }
              else if (this.fileConvert.Count > index1)
                str2 = this.CheckFile(str1, this.fileConvert[index1], ref folderParent);
              if (!string.IsNullOrWhiteSpace(str2))
              {
                stringList.Add("\"" + str2 + "\"");
                ++index1;
              }
            }
            else
            {
              string str2 = Path.Combine(this.FolderParent, str1);
              if (!this.FilesPath.Contains(str2))
              {
                this.FilesPath.Add(str2);
                stringList.Add("\"" + str1 + "\"");
              }
            }
          }
          string str = string.Join(" ", stringList.ToArray());
          if (stringList.Count == 1)
            str = str.Replace("\"", "");
          this.textBox1.Text = str;
        }
        else if (this.fileConvert.Count == 1)
          this.textBox1.Text = this.CheckFile(slectedItemsText[0], this.fileConvert[0], ref this.FolderParent);
      }
    }

    private string CheckFile(string selettext, string converttext, ref string floderparent)
    {
      string path2 = ((IEnumerable<string>) selettext.Split(new string[1]{ "\0" }, StringSplitOptions.RemoveEmptyEntries)).FirstOrDefault<string>();
      bool flag = false;
      string str = converttext;
      FileInfo fileInfo1 = new FileInfo(str);
      if (fileInfo1.Extension.ToLower() == ".lnk")
      {
        if (!fileInfo1.Exists)
          fileInfo1 = new FileInfo(Path.Combine(WindowHelper.GetAllUsersDesktopFolderPath(), path2 + ".lnk"));
        if (fileInfo1.Exists)
        {
          flag = true;
          str = fileInfo1.FullName.GetLnkRealtivePath();
        }
      }
      if (string.IsNullOrWhiteSpace(floderparent))
      {
        if (str.IsFileOrDirectory())
        {
          DirectoryInfo directoryInfo = new FileInfo(str).Directory ?? new DirectoryInfo(str);
          if (directoryInfo != null && directoryInfo.Exists)
          {
            floderparent = directoryInfo.FullName;
            this.FilesPath.Add(Path.Combine(floderparent, str));
            return path2;
          }
        }
      }
      else
      {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        if (floderparent.Equals(folderPath))
        {
          if (flag)
          {
            FileInfo fileInfo2 = new FileInfo(str);
            if (fileInfo2 != null && fileInfo2.Exists)
            {
              this.FilesPath.Add(str);
              return fileInfo2.Name;
            }
          }
          else if (Path.Combine(floderparent, path2).IsFileOrDirectory() && str.IsFileOrDirectory())
          {
            this.FilesPath.Add(Path.Combine(floderparent, str));
            return path2;
          }
        }
        else if (str.IsFileOrDirectory())
        {
          this.FilesPath.Add(Path.Combine(floderparent, str));
          return path2;
        }
      }
      return string.Empty;
    }

    public override void OnSelectedNameChanged()
    {
      if (this.FilesPath.Count > 0)
      {
        List<string> filesPath = new List<string>();
        this.FilesPath.ForEach((Action<string>) (i => filesPath.Add(i.Replace("\"", ""))));
        this.FilesPath = filesPath;
      }
      base.OnSelectedNameChanged();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.AutoScaleMode = AutoScaleMode.Font;
    }
  }
}
