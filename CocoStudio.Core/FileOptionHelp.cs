// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.FileOptionHelp
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.ControlLib;
using CocoStudio.Projects;
using CocoStudio.Projects.Formates;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CocoStudio.Core
{
  public static class FileOptionHelp
  {
    public static FilePath SulutionPath
    {
      get
      {
        return Services.ProjectOperations.CurrentSelectedSolution.BaseDirectory;
      }
    }

    private static List<string> ProcessPairResources(string filePath)
    {
      ICompositeResourceProcesser resourceProcesser = Services.ProjectsService.GetCompositeResourceProcesser(filePath);
      if (resourceProcesser != null)
        return resourceProcesser.GetMatchedImages(filePath);
      return (List<string>) null;
    }

    private static string RenameFile(string file)
    {
      string fileName = Path.GetFileName(file);
      string withoutExtension = Path.GetFileNameWithoutExtension(file);
      string extension = Path.GetExtension(fileName);
      string directoryName = Path.GetDirectoryName(file);
      int num = 1;
      do
      {
        string str = withoutExtension + (object) num;
        file = Path.Combine(directoryName, str + extension);
        ++num;
      }
      while (File.Exists(file));
      return file;
    }

    public static List<string> GetAllFilesByFolder(ResourceFolder folder)
    {
      List<string> stringList = new List<string>();
      IEnumerable<ResourceItem> resourceItems = folder.Items.Where<ResourceItem>((Func<ResourceItem, bool>) (n => n is ResourceFolder));
      IEnumerable<string> collection = folder.Items.Where<ResourceItem>((Func<ResourceItem, bool>) (n => n is ResourceFile)).Select<ResourceItem, string>((Func<ResourceItem, string>) (n => n.FullPath));
      stringList.AddRange(collection);
      foreach (ResourceItem resourceItem in resourceItems)
      {
        stringList.Add(resourceItem.FullPath);
        List<string> allFilesByFolder = FileOptionHelp.GetAllFilesByFolder((ResourceFolder) resourceItem);
        stringList.AddRange((IEnumerable<string>) allFilesByFolder);
      }
      return stringList;
    }

    private static SortedSet<FileOptionHelp.FileData> CreateFileDatas(IEnumerable<string> files)
    {
      SortedSet<FileOptionHelp.FileData> sortedSet = new SortedSet<FileOptionHelp.FileData>();
      FilePath baseDirectory = Services.ProjectOperations.CurrentResourceGroup.RootFolder.BaseDirectory;
      foreach (string file in files)
      {
        if (!baseDirectory.IsChildPathOf((FilePath) file) && !(baseDirectory == (FilePath) file))
          sortedSet.Add(new FileOptionHelp.FileData(file));
      }
      return sortedSet;
    }

    public static ImportResourceResult CopyToDic(ResourceFolder parentDic, IEnumerable<string> files, IProgressMonitor monitor, CancellationToken token, IEnumerable<string> fileTypeSuffix = null)
    {
      ImportResourceResult importResult = new ImportResourceResult();
      importResult.FileTypeSuffix = fileTypeSuffix;
      importResult.Token = token;
      List<FileOptionHelp.FileData> dealDithFiles = new List<FileOptionHelp.FileData>();
      FileOptionHelp.IsMainThread();
      int pathsFileSystemCount = FileOptionHelp.GetPathsFileSystemCount(files);
      monitor.BeginTask(LanguageInfo.Menu_File_ImportFile, pathsFileSystemCount);
      foreach (FileOptionHelp.FileData fileData in FileOptionHelp.CreateFileDatas(files))
      {
        if (!token.IsCancellationRequested)
        {
          ResourceItem resourceItem = !File.Exists((string) fileData.FilePath) || fileData.Attributes.HasFlag((Enum) FileAttributes.Hidden) ? FileOptionHelp.CopyDir(parentDic, fileData, ref importResult, dealDithFiles, monitor) : FileOptionHelp.CopyFile(parentDic, fileData, ref importResult, dealDithFiles, monitor);
          if (resourceItem != null)
          {
            importResult.ImportResources.Add(resourceItem);
            importResult.AddResourcePanelItems.Add(resourceItem);
          }
        }
        else
          break;
      }
      return importResult;
    }

    private static bool IsMainThread()
    {
      return Services.MainWindow.MainThreadId == System.Threading.Thread.CurrentThread.ManagedThreadId;
    }

    private static ResourceItem CopyFile(ResourceFolder parent, FileOptionHelp.FileData filePath, ref ImportResourceResult importResult, List<FileOptionHelp.FileData> dealDithFiles, IProgressMonitor monitor)
    {
        ResourceItem result;
        try
        {
            if (importResult.Token.IsCancellationRequested)
            {
                result = null;
            }
            else
            {
                bool flag = false;
                if (null != importResult.FileTypeSuffix)
                {
                    flag = true;
                    if (importResult.FileTypeSuffix.Contains(filePath.FilePath.Extension))
                    {
                        flag = false;
                    }
                }
                flag |= filePath.FilePath.Extension.Equals(".ccs", StringComparison.OrdinalIgnoreCase);
                if (flag)
                {
                    monitor.Step(1);
                    result = null;
                }
                else if (dealDithFiles.Contains(filePath))
                {
                    result = null;
                }
                else
                {
                    List<string> list = FileOptionHelp.ProcessPairResources(filePath.FilePath);
                    if (list != null)
                    {
                        filePath.CanRename = false;
                    }
                    FilePath filePath2 = parent.BaseDirectory.Combine(new string[]
						{
							filePath.Name
						});
                    DialogResult dialogRes = new DialogResult();
                    if (!FileOptionHelp.VerifyPath(filePath2))
                    {
                        monitor.Step(1);
                        monitor.ReportError(string.Format(LanguageInfo.MessageBox199_PathContainsChinese, filePath.FilePath), null);
                        result = null;
                    }
                    else if (filePath.FilePath.IsChildPathOf(parent.BaseDirectory))
                    {
                        if (!FileOptionHelp.VerifyPath(filePath.FilePath))
                        {
                            monitor.Step(1);
                            monitor.ReportError(string.Format(LanguageInfo.MessageBox199_PathContainsChinese, filePath.FilePath), null);
                            result = null;
                        }
                        else
                        {
                            ResourceItem resourceItem = null;
                            ResourceItem resourceItem2 = Services.ProjectOperations.AddResourceItem(parent, filePath.FilePath, monitor, out resourceItem);
                            if (resourceItem != null)
                            {
                                if (resourceItem.Parent != parent)
                                {
                                    importResult.AddResourcePanelItems.Add(resourceItem.Parent);
                                }
                                else
                                {
                                    importResult.AddResourcePanelItems.Add(resourceItem);
                                }
                            }
                            File.SetAttributes(filePath.FilePath, FileAttributes.Normal);
                            result = resourceItem2;
                        }
                    }
                    else
                    {
                        if (File.Exists(filePath2))
                        {
                            if (!importResult.DialogResult.IsChangedAll)
                            {
                                if (FileOptionHelp.IsMainThread())
                                {
                                    ImportFileDialog importFileDialog = new ImportFileDialog(Services.MainWindow, filePath.CanRename);
                                    importFileDialog.RefreshMessage(filePath.Name);
                                    dialogRes = importFileDialog.ShowRun();
                                }
                                else
                                {
                                    AutoResetEvent autoReset = new AutoResetEvent(false);
                                    GLib.Timeout.Add(0u, delegate
                                    {
                                        ImportFileDialog importFileDialog2 = new ImportFileDialog(Services.MainWindow, filePath.CanRename);
                                        importFileDialog2.RefreshMessage(filePath.Name);
                                        dialogRes = importFileDialog2.ShowRun();
                                        autoReset.Set();
                                        return false;
                                    });
                                    autoReset.WaitOne();
                                }
                                importResult.DialogResult = dialogRes;
                            }
                            switch (importResult.DialogResult.ButtonResult)
                            {
                                case EImportFileButtonResult.KeepBoth:
                                    if (filePath.CanRename)
                                    {
                                        filePath2 = FileOptionHelp.RenameFile(filePath2);
                                    }
                                    else
                                    {
                                        monitor.ReportWarning(string.Format(LanguageInfo.MessageBox200_CannotRename, filePath.FilePath));
                                    }
                                    break;
                                case EImportFileButtonResult.Skip:
                                    result = null;
                                    return result;
                            }
                        }
                        if (list != null)
                        {
                            string text = FileOptionHelp.CheckFiles(list);
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                monitor.Step(1);
                                string message = string.Format(LanguageInfo.MessageBox195_NoMatchPng, filePath.FilePath, text);
                                monitor.ReportWarning(message);
                                result = null;
                                return result;
                            }
                            foreach (FilePath current in list)
                            {
                                FilePath filePath3 = current.ToRelative(filePath.FilePath.ParentDirectory).ToAbsolute(parent.BaseDirectory);
                                string path = filePath3.ParentDirectory;
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                FileService.CopyFile(current, filePath3);
                                File.SetAttributes(filePath3, FileAttributes.Normal);
                                dealDithFiles.Add(new FileOptionHelp.FileData(current));
                            }
                        }
                        FileService.CopyFile(filePath.FilePath, filePath2);
                        File.SetAttributes(filePath2, FileAttributes.Normal);
                        ResourceItem resourceItem3 = Services.ProjectOperations.AddResourceItem(parent, filePath2, monitor);
                        if (resourceItem3 is Project && importResult.DialogResult.ButtonResult == EImportFileButtonResult.Replace)
                        {
                            ((Project)resourceItem3).Reload(monitor);
                        }
                        result = resourceItem3;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            monitor.Step(1);
            monitor.ReportError(string.Format(LanguageInfo.Output_ImportFailed, filePath.FilePath), exception);
            result = null;
        }
        return result;
    }

    private static ResourceItem CopyDir(ResourceFolder parent, FileOptionHelp.FileData dirPath, ref ImportResourceResult importResult, List<FileOptionHelp.FileData> dealDithFiles, IProgressMonitor monitor)
    {
      ResourceFolder resourceFolder = (ResourceFolder) null;
      if (importResult.Token.IsCancellationRequested)
        return (ResourceItem) resourceFolder;
      ResourceFolder parent1;
      if (dirPath.FilePath.IsChildPathOf(parent.BaseDirectory))
      {
        if (!FileOptionHelp.VerifyPath(dirPath.FilePath))
        {
          monitor.Step(1);
          monitor.ReportError(string.Format(LanguageInfo.MessageBox199_PathContainsChinese, (object) dirPath.FilePath), (Exception) null);
          return (ResourceItem) null;
        }
        ResourceItem importRoot = (ResourceItem) null;
        parent1 = Services.ProjectOperations.AddResourceItem(parent, dirPath.FilePath, monitor, out importRoot) as ResourceFolder;
        importResult.AddResourcePanelItems.Add(importRoot);
      }
      else
      {
        FilePath filePath = parent.BaseDirectory.Combine(new string[1]{ dirPath.Name });
        if (!FileOptionHelp.VerifyPath(filePath))
        {
          monitor.Step(1);
          monitor.ReportError(string.Format(LanguageInfo.MessageBox199_PathContainsChinese, (object) dirPath.FilePath), (Exception) null);
          return (ResourceItem) null;
        }
        if (!Directory.Exists((string) filePath))
          Directory.CreateDirectory((string) filePath);
        parent1 = Services.ProjectOperations.AddResourceItem(parent, filePath, monitor) as ResourceFolder;
      }
      DirectoryInfo directoryInfo1 = new DirectoryInfo((string) dirPath.FilePath);
      FileInfo[] files = directoryInfo1.GetFiles();
      DirectoryInfo[] directories = directoryInfo1.GetDirectories();
      SortedSet<FileOptionHelp.FileData> fileDatas = FileOptionHelp.CreateFileDatas(((IEnumerable<FileInfo>) files).Select<FileInfo, string>((Func<FileInfo, string>) (a => a.FullName)));
      foreach (DirectoryInfo directoryInfo2 in directories)
      {
        if (!directoryInfo2.Attributes.HasFlag((Enum) FileAttributes.Hidden))
        {
          FileOptionHelp.FileData dirPath1 = new FileOptionHelp.FileData(directoryInfo2.FullName);
          FileOptionHelp.CopyDir(parent1, dirPath1, ref importResult, dealDithFiles, monitor);
        }
      }
      foreach (FileOptionHelp.FileData filePath in fileDatas)
      {
        if (!filePath.Attributes.HasFlag((Enum) FileAttributes.Hidden))
          FileOptionHelp.CopyFile(parent1, filePath, ref importResult, dealDithFiles, monitor);
      }
      return (ResourceItem) parent1;
    }

    public static string CheckFiles(IEnumerable<string> files)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (files != null)
      {
        foreach (string file in files)
        {
          if (!File.Exists(file))
            stringBuilder.AppendLine(Environment.NewLine + file);
        }
      }
      return stringBuilder.ToString();
    }

    public static bool VerifyPath(FilePath path)
    {
        string text = path.ToRelative(FileOptionHelp.SulutionPath);
        string input = text.Replace("\\", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace(":", "");
        string resourcePathRegex = RegexModel.ResourcePathRegex;
        return Regex.IsMatch(input, resourcePathRegex);
    }

    public static int GetPathsFileSystemCount(IEnumerable<string> files)
    {
      int num = 0;
      foreach (string file in files)
      {
        if (File.Exists(file))
        {
          ++num;
        }
        else
        {
          string[] fileSystemEntries = Directory.GetFileSystemEntries(file, "*", SearchOption.AllDirectories);
          num += fileSystemEntries.Length;
        }
      }
      return num;
    }

    private class FileData : IComparable<FileOptionHelp.FileData>, IEquatable<string>, IEquatable<FileOptionHelp.FileData>
    {
      public FilePath FilePath { get; private set; }

      public string Name
      {
        get
        {
          if (FileService.IsValidPath((string) this.FilePath))
            return Path.GetFileName((string) this.FilePath);
          return string.Empty;
        }
      }

      public FileAttributes Attributes { get; private set; }

      public string Extension
      {
        get
        {
          if (FileService.IsValidPath((string) this.FilePath))
            return Path.GetExtension((string) this.FilePath);
          return string.Empty;
        }
      }

      public bool CanRename { get; set; }

      public bool CanCreateResourceItem { get; set; }

      public FileData(string filePath)
      {
        this.FilePath = (FilePath) filePath;
        this.CanRename = true;
        this.CanCreateResourceItem = true;
        this.Attributes = File.GetAttributes(filePath);
      }

      public int CompareTo(FileOptionHelp.FileData other)
      {
        string extension1 = this.FilePath.Extension;
        string extension2 = other.FilePath.Extension;
        if (this.IsImage(extension1) && !this.IsImage(extension2))
          return 1;
        if (!this.IsImage(extension1) && this.IsImage(extension2))
          return -1;
        return this.FilePath.CompareTo(other.FilePath);
      }

      private bool IsImage(string fileSuffix)
      {
        return fileSuffix.Equals(".png", StringComparison.OrdinalIgnoreCase) || object.Equals((object) ".jpg", (object) StringComparison.OrdinalIgnoreCase);
      }

      public override string ToString()
      {
        return (string) this.FilePath;
      }

      public bool Equals(string other)
      {
        return this.FilePath.Equals((object) other);
      }

      public override int GetHashCode()
      {
        return this.FilePath.GetHashCode();
      }

      public bool Equals(FileOptionHelp.FileData other)
      {
        return this.FilePath.Equals((object) other.FilePath);
      }
    }
  }
}
