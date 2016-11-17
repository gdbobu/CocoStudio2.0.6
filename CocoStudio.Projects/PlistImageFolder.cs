// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PlistImageFolder
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model;
using Modules.Communal.MultiLanguage;
using Modules.Communal.Packer;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CocoStudio.Projects
{
  [JsonObject(MemberSerialization.OptIn)]
  public class PlistImageFolder : ResourceFolder, IResourceValid
  {
    private object lockTag = new object();
    public const string PlistFileDirExtention = "_PList.Dir";
    public const string FileSuffix = ".plist";
    private FilePath imageFile;
    [ResourcePathItemProperty(Name = "PListFile")]
    public FilePath plistFileInfo;
    [JsonProperty(PropertyName = "LastPlistWriteTime")]
    [ItemProperty(Name = "LastPlistWriteTime")]
    protected DateTime lastPlistWriteTime;
    [ItemProperty(Name = "LastImageWriteTime")]
    [JsonProperty(PropertyName = "LastImageWriteTime")]
    protected DateTime lastImageWriteTime;

    public override string Name
    {
      get
      {
        return this.plistFileInfo.FileName;
      }
      protected set
      {
        throw new InvalidOperationException("Can't set Name.");
      }
    }

    public override string FullPath
    {
      get
      {
        return (string) this.plistFileInfo;
      }
    }

    internal override string PreviewImagePath
    {
      get
      {
        return (string) this.imageFile;
      }
    }

    public bool IsValid
    {
      get
      {
        if (File.Exists((string) this.imageFile))
          return File.Exists((string) this.plistFileInfo);
        return false;
      }
    }

    private PlistImageFolder()
    {
    }

    public PlistImageFolder(FilePath filePath)
      : base(filePath)
    {
      this.plistFileInfo = filePath;
      this.BaseDirectory = (FilePath) this.InitPlistDir(this.plistFileInfo);
    }

    private string InitPlistDir(FilePath fileInfo)
    {
      FilePath plistDirPath = PlistImageFolder.GetPListDirPath(this.plistFileInfo);
      DirectoryInfo directoryInfo = new DirectoryInfo((string) plistDirPath);
      if (!directoryInfo.Exists)
      {
        directoryInfo.Create();
        directoryInfo.Attributes = FileAttributes.Hidden;
      }
      return (string) plistDirPath;
    }

    private PListImageReader AnalyzePlist(FilePath fileInfo)
    {
      try
      {
        lock (this.lockTag)
        {
          PListImageReader local_0 = new PListImageReader((string) this.plistFileInfo);
          local_0.SaveAllSubImage((string) this.BaseDirectory);
          return local_0;
        }
      }
      catch (Exception ex)
      {
        LogConfig.Output.Error((object) LanguageInfo.MessageBox_Content64, ex);
        return (PListImageReader) null;
      }
    }

    private static FilePath GetPListDirPath(FilePath plistFile)
    {
      return (FilePath) Path.Combine((string) plistFile.ParentDirectory, "." + plistFile.FileNameWithoutExtension + "_PList.Dir");
    }

    protected List<PlistImageFile> CreateItems()
    {
      PListImageReader plistImageReader = this.GetPlistImageReader(this.plistFileInfo);
      if (plistImageReader == null)
        return new List<PlistImageFile>();
      string baseDirectory = (string) this.BaseDirectory;
      List<PlistImageFile> plistImageFileList = new List<PlistImageFile>();
      foreach (ImageInfo image in plistImageReader.ImageList)
      {
        string str = Path.Combine(baseDirectory, image.FileName);
        plistImageFileList.Add(new PlistImageFile((FilePath) str, image.Name, this));
      }
      return plistImageFileList;
    }

    private PListImageReader GetPlistImageReader(FilePath plistInfo)
    {
      PListImageReader plistImageReader = this.AnalyzePlist(plistInfo);
      if (plistImageReader != null)
        return plistImageReader;
      if (Directory.Exists((string) this.BaseDirectory))
        Directory.Delete((string) this.BaseDirectory, true);
      return (PListImageReader) null;
    }

    protected override void OnDelete()
    {
      this.DeleteFile(this.imageFile);
      this.DeleteFile(this.BaseDirectory);
      this.DeleteFile(this.plistFileInfo);
      base.OnDelete();
      CSCocosHelp.RemovePlistFileFromCache(this.GetResourceData().Path);
    }

    protected override void OnInitialize(IProgressMonitor monitor)
    {
      this.imageFile = (FilePath) PListImageReader.GetMatchImageFile((string) this.plistFileInfo);
      this.InitializeItems(false);
      if (Directory.Exists((string) this.BaseDirectory))
        return;
      this.ReloadSubResources();
    }

    internal void InitializeItems(bool isForce = false)
    {
      if (!isForce && !this.IsNeedRefresh())
        return;
      this.Items.Clear();
      foreach (ResourceItem resourceItem in this.CreateItems())
        this.Items.Add(resourceItem);
    }

    internal override bool IsNeedRefresh()
    {
      bool flag = false;
      DateTime lastWriteTime1 = File.GetLastWriteTime((string) this.plistFileInfo);
      if (!lastWriteTime1.Equals(this.lastPlistWriteTime))
      {
        this.lastPlistWriteTime = lastWriteTime1;
        flag = true;
      }
      if (flag || string.IsNullOrEmpty((string) this.imageFile))
        this.imageFile = (FilePath) PListImageReader.GetMatchImageFile((string) this.plistFileInfo);
      if (!string.IsNullOrEmpty((string) this.imageFile))
      {
        DateTime lastWriteTime2 = File.GetLastWriteTime((string) this.imageFile);
        if (!lastWriteTime2.Equals(this.lastImageWriteTime))
        {
          this.lastImageWriteTime = lastWriteTime2;
          flag = true;
        }
      }
      if (this.Items.Count == 0)
        flag = true;
      return flag;
    }

    private void DeleteFile(FilePath filePath)
    {
      if (!File.Exists((string) filePath))
        return;
      filePath.Delete();
    }

    protected override void OnRefresh()
    {
      bool isValid = this.IsValid;
      if (isValid)
      {
        CSCocosHelp.ReloadPlistFileToCache(this.FullPath);
        this.ReloadSubResources();
      }
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
        resourceItem.Refresh(true);
      if (isValid)
        return;
      for (int index = this.Items.Count - 1; index >= 0; --index)
        this.Items.RemoveAt(index);
    }

    public string GetPreviewFilePath()
    {
      if (!(this.imageFile != (FilePath) ((string) null)))
        return string.Empty;
      return (string) this.imageFile;
    }

    public void ReloadSubResources()
    {
      PListImageReader plistImageReader = this.GetPlistImageReader(this.plistFileInfo);
      if (plistImageReader == null)
        return;
      string baseDirectory = (string) this.BaseDirectory;
      if (!Directory.Exists((string) this.BaseDirectory))
        return;
      List<ResourceItem> resourceItemList = new List<ResourceItem>();
      foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
      {
        bool flag = false;
        foreach (ImageInfo image in plistImageReader.ImageList)
        {
          string str = Path.Combine(baseDirectory, image.FileName);
          if (resourceItem.PreviewImagePath == str)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          resourceItemList.Add(resourceItem);
      }
      foreach (ResourceItem resourceItem in resourceItemList)
      {
        resourceItem.Delete();
        this.Items.Remove(resourceItem);
      }
      List<ImageInfo> imageInfoList = new List<ImageInfo>();
      foreach (ImageInfo image in plistImageReader.ImageList)
      {
        bool flag = false;
        string str = Path.Combine(baseDirectory, image.FileName);
        foreach (ResourceItem resourceItem in (Collection<ResourceItem>) this.Items)
        {
          if (resourceItem.PreviewImagePath == str)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          imageInfoList.Add(image);
      }
      foreach (ImageInfo imageInfo in imageInfoList)
        this.Items.Add((ResourceItem) new PlistImageFile((FilePath) Path.Combine(baseDirectory, imageInfo.FileName), imageInfo.Name, this));
    }

    public override ResourceData GetResourceData()
    {
      return this.CreateResourceData(this.plistFileInfo);
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename)
    {
      string path = (string) this.BaseDirectory;
      if (newFilePath != this.plistFileInfo)
      {
        FilePath directoryName = (FilePath) Path.GetDirectoryName((string) newFilePath);
        FilePath fileName1 = (FilePath) Path.GetFileName((string) this.BaseDirectory);
        path = Path.Combine((string) directoryName, (string) fileName1);
        FilePath fileName2 = (FilePath) Path.GetFileName((string) this.imageFile);
        FilePath filePath1 = (FilePath) Path.Combine((string) directoryName, (string) fileName2);
        FilePath filePath2 = directoryName.Combine(new string[1]
        {
          this.plistFileInfo.FileName
        });
        if (!isRename)
        {
          try
          {
            if (!Directory.Exists((string) directoryName))
              Directory.CreateDirectory((string) directoryName);
            FileService.MoveFile((string) this.imageFile, (string) filePath1);
            FileService.MoveFile((string) this.plistFileInfo, (string) filePath2);
          }
          catch (Exception ex)
          {
            LogConfig.Output.Error((object) ex.Message, ex);
          }
        }
        this.plistFileInfo = filePath2;
        this.imageFile = filePath1;
      }
      base.OnSetLocation((FilePath) path, isRename);
      new DirectoryInfo(path).Attributes = FileAttributes.Hidden;
      this.Refresh(true);
    }
  }
}
