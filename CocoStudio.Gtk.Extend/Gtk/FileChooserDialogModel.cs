// Decompiled with JetBrains decompiler
// Type: Gtk.FileChooserDialogModel
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

namespace Gtk
{
  public class FileChooserDialogModel
  {
    public static SelectFolderDialogResult GetBrowseDialogPath(string title = "Select Folder", bool selectMultiple = false, string initialDirectory = "", bool IsWin7Style = false)
    {
      SelectFolderDialogResult folderDialogResult = new SelectFolderDialogResult();
      FileChooserAdapter fileChooserAdapter = new FileChooserAdapter(FileAction.SelectFolder, title, selectMultiple, initialDirectory);
      if (!fileChooserAdapter.Run(IsWin7Style))
        return folderDialogResult;
      folderDialogResult.Folder = fileChooserAdapter.Path;
      folderDialogResult.Folders = fileChooserAdapter.Paths;
      return folderDialogResult;
    }

    public static SelectFileDialogResult GetOpenFilePath(string[] fileTypes = null, string title = "Open File", bool selectMultiple = false, string initialDirectory = "")
    {
      SelectFileDialogResult fileDialogResult = new SelectFileDialogResult();
      if (fileTypes != null)
      {
        for (int index = 0; index < fileTypes.Length; ++index)
          fileTypes[index] = fileTypes[index].Replace("*.", "");
      }
      FileChooserAdapter fileChooserAdapter = new FileChooserAdapter(FileAction.Open, title, selectMultiple, initialDirectory);
      fileChooserAdapter.AllowedFileTypes = fileTypes;
      if (!fileChooserAdapter.Run(false))
        return fileDialogResult;
      fileDialogResult.FileName = fileChooserAdapter.Path;
      fileDialogResult.FileNames = fileChooserAdapter.Paths;
      return fileDialogResult;
    }

    public static SelectFileDialogResult GetOpenFilesPath(string[] fileTypes = null, string title = "Select Files", bool selectMultiple = false, string initialDirectory = "")
    {
      SelectFileDialogResult fileDialogResult = new SelectFileDialogResult();
      if (fileTypes != null)
      {
        for (int index = 0; index < fileTypes.Length; ++index)
          fileTypes[index] = fileTypes[index].Replace("*.", "");
      }
      FileChooserAdapter fileChooserAdapter = new FileChooserAdapter(FileAction.SelectFiles, title, selectMultiple, initialDirectory);
      fileChooserAdapter.AllowedFileTypes = fileTypes;
      if (!fileChooserAdapter.Run(false))
        return fileDialogResult;
      fileDialogResult.FileName = fileChooserAdapter.Path;
      fileDialogResult.FileNames = fileChooserAdapter.Paths;
      return fileDialogResult;
    }

    public static SelectFileDialogResult GetSaveFilesPath(string[] fileTypes = null, string title = "Save Files", bool selectMultiple = false, string initialDirectory = "")
    {
      SelectFileDialogResult fileDialogResult = new SelectFileDialogResult();
      if (fileTypes != null)
      {
        for (int index = 0; index < fileTypes.Length; ++index)
          fileTypes[index] = fileTypes[index].Replace("*.", "");
      }
      FileChooserAdapter fileChooserAdapter = new FileChooserAdapter(FileAction.Save, title, selectMultiple, initialDirectory);
      fileChooserAdapter.AllowedFileTypes = fileTypes;
      if (!fileChooserAdapter.Run(false))
        return fileDialogResult;
      fileDialogResult.FileName = fileChooserAdapter.Path;
      fileDialogResult.FileNames = fileChooserAdapter.Paths;
      return fileDialogResult;
    }
  }
}
