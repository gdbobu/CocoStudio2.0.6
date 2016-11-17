// Decompiled with JetBrains decompiler
// Type: Gtk.FileChooserAdapter
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using MonoDevelop.Core;
using MonoMac.AppKit;
using MonoMac.Foundation;
using OpenDialogs;
using System;
using System.Windows.Forms;

namespace Gtk
{
  public class FileChooserAdapter
  {
    public static bool ISMac;
    public string Path;
    public string[] Paths;
    public string[] AllowedFileTypes;
    public bool AllowMultipleSelect;
    public string Title;
    public FileAction FileChooserAction;
    public string InitialDirectory;

    private bool IsSelectFiles { get; set; }

    public FileChooserAdapter(FileAction fileChooserAction, string title = "", bool selectMultiple = false, string initialDirectory = "")
    {
      this.Title = title;
      this.FileChooserAction = fileChooserAction;
      this.AllowMultipleSelect = selectMultiple;
      this.InitialDirectory = initialDirectory;
    }

    public bool Run(bool IsWin7Style = false)
    {
      return !Platform.IsMac ? (!Platform.IsWindows ? this.GtkOpenFile() : this.WinOpenFile(IsWin7Style)) : this.MacOpenFile();
    }

    private bool WinOpenFile(bool IsWin7Style)
    {
      switch (this.FileChooserAction)
      {
        case FileAction.Open:
          return this.WinOpenFile_OpenFile();
        case FileAction.Save:
          return this.WindowsSaveFiles();
        case FileAction.SelectFolder:
          return this.WinOpenFile_OpenFolder(IsWin7Style);
        case FileAction.SelectFiles:
          return this.WindowsOpenFiles();
        default:
          return false;
      }
    }

    private bool WindowsSaveFiles()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = this.Title;
      if (this.InitialDirectory != "")
      {
        string fileName = System.IO.Path.GetFileName(this.InitialDirectory);
        saveFileDialog.FileName = fileName;
        saveFileDialog.InitialDirectory = this.InitialDirectory;
      }
      if (this.AllowedFileTypes != null)
      {
        string[] strArray = new string[this.AllowedFileTypes.Length];
        for (int index = 0; index < this.AllowedFileTypes.Length; ++index)
          strArray[index] = "*." + this.AllowedFileTypes[index];
        string str1 = string.Join(",", strArray);
        string str2 = string.Join(";", strArray);
        saveFileDialog.Filter = string.Format("({0})|{1}", (object) str1, (object) str2);
      }
      else
        saveFileDialog.Filter = "(*.*)|*.*";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      this.Paths = saveFileDialog.FileNames;
      this.Path = saveFileDialog.FileName;
      return true;
    }

    private bool GtkOpenFile()
    {
      FileChooserDialog fileChooserDialog = new FileChooserDialog(this.Title, ApplicationCurrent.MainWindow, (Gtk.FileChooserAction) this.FileChooserAction, new object[0]);
      switch (this.FileChooserAction)
      {
        case FileAction.Open:
          fileChooserDialog.AddButton("Open", ResponseType.Ok);
          FileFilter fileFilter = new FileFilter();
          if (this.AllowedFileTypes != null)
          {
            foreach (string allowedFileType in this.AllowedFileTypes)
              fileFilter.AddPattern("*." + allowedFileType);
            break;
          }
          break;
        case FileAction.SelectFolder:
          fileChooserDialog.AddButton("Select Folder", ResponseType.Ok);
          break;
      }
      fileChooserDialog.AddButton("Cancel", ResponseType.Cancel);
      fileChooserDialog.SelectMultiple = this.AllowMultipleSelect;
      if (fileChooserDialog.Run() == -5)
      {
        this.Paths = fileChooserDialog.Filenames;
        this.Path = this.Paths[0];
        fileChooserDialog.Destroy();
        return true;
      }
      fileChooserDialog.Destroy();
      return false;
    }

    private bool WinOpenFile_OpenFile()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Multiselect = this.AllowMultipleSelect;
      openFileDialog.Title = this.Title;
      if (this.AllowedFileTypes != null)
      {
        string[] strArray = new string[this.AllowedFileTypes.Length];
        for (int index = 0; index < this.AllowedFileTypes.Length; ++index)
          strArray[index] = "*." + this.AllowedFileTypes[index];
        string str1 = string.Join(",", strArray);
        string str2 = string.Join(";", strArray);
        openFileDialog.Filter = string.Format("({0})|{1}", (object) str1, (object) str2);
      }
      else
        openFileDialog.Filter = "(*.*)|*.*";
      if (this.InitialDirectory != "")
        openFileDialog.InitialDirectory = this.InitialDirectory;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      this.Paths = openFileDialog.FileNames;
      this.Path = openFileDialog.FileName;
      return true;
    }

    private bool WinOpenFile_OpenFolder(bool IsWin7Style)
    {
      if (IsWin7Style)
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.Description = this.Title;
        folderBrowserDialog.ShowNewFolderButton = true;
        if (this.InitialDirectory != "")
          folderBrowserDialog.SelectedPath = this.InitialDirectory;
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return false;
        this.Path = folderBrowserDialog.SelectedPath;
        this.Paths = new string[1]
        {
          folderBrowserDialog.SelectedPath
        };
        return true;
      }
      OpenFloderDialog folderBrowser = new OpenFloderDialog();
      folderBrowser.OpenDialog.Title = this.Title;
      if (this.InitialDirectory != "")
        folderBrowser.SetShowText(this.InitialDirectory);
      folderBrowser.SelectedNameChanged += (EventHandler) ((s, e) =>
      {
        if (folderBrowser.Info == null)
          return;
        this.Path = folderBrowser.Info.FullName;
        this.Paths = new string[1]
        {
          folderBrowser.Info.FullName
        };
      });
      folderBrowser.ShowDialog();
      return folderBrowser.Info != null;
    }

    private bool MacOpenFile()
    {
      NSOpenPanel nsOpenPanel = new NSOpenPanel();
      nsOpenPanel.Title = this.Title;
      switch (this.FileChooserAction)
      {
        case FileAction.Open:
          nsOpenPanel.CanChooseFiles = true;
          nsOpenPanel.CanChooseDirectories = false;
          if (this.AllowedFileTypes != null)
          {
            nsOpenPanel.AllowedFileTypes = this.AllowedFileTypes;
            break;
          }
          break;
        case FileAction.Save:
          NSSavePanel savePanel = NSSavePanel.SavePanel;
          savePanel.AllowedFileTypes = this.AllowedFileTypes;
          savePanel.CanCreateDirectories = true;
          savePanel.DirectoryUrl = new NSUrl(this.InitialDirectory);
          // ISSUE: reference to a compiler-generated method
          if (savePanel.RunModal() == 1)
          {
            this.Path = savePanel.Url.Path;
            savePanel.Dispose();
            return true;
          }
          savePanel.Dispose();
          return false;
        case FileAction.SelectFolder:
          nsOpenPanel.CanChooseDirectories = true;
          nsOpenPanel.CanChooseFiles = false;
          break;
        case FileAction.SelectFiles:
          nsOpenPanel.CanChooseDirectories = true;
          nsOpenPanel.CanChooseFiles = true;
          break;
      }
      nsOpenPanel.CanCreateDirectories = false;
      nsOpenPanel.AllowsMultipleSelection = this.AllowMultipleSelect;
      nsOpenPanel.DirectoryUrl = new NSUrl(this.InitialDirectory);
      // ISSUE: reference to a compiler-generated method
      if (nsOpenPanel.RunModal() == 1)
      {
        int length = nsOpenPanel.Urls.Length;
        string[] strArray = new string[length];
        for (int index = 0; index < length; ++index)
          strArray[index] = nsOpenPanel.Urls[index].Path.ToString();
        this.Paths = strArray;
        this.Path = this.Paths[0];
        nsOpenPanel.Dispose();
        return true;
      }
      nsOpenPanel.Dispose();
      return false;
    }

    private bool WindowsOpenFiles()
    {
      OpenFilesDialog filesdialog = new OpenFilesDialog();
      filesdialog.OpenDialog.Title = this.Title;
      if (this.InitialDirectory != "")
        filesdialog.SetShowText(this.InitialDirectory);
      filesdialog.SelectedNameChanged += (EventHandler) ((s, e) =>
      {
        if (string.IsNullOrWhiteSpace(filesdialog.FolderParent))
          return;
        this.Paths = filesdialog.FilesPath.ToArray();
      });
      filesdialog.ShowDialog();
      return !string.IsNullOrWhiteSpace(filesdialog.FolderParent);
    }
  }
}
