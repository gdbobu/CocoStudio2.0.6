// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.TmxFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CocoStudio.Projects
{
  public class TmxFile : ResourceFile
  {
    public const string FileSuffix = ".tmx";
    private static ICompositeResourceProcesser pairResourceProcesser;
    private List<string> imageFiles;

    internal override string PreviewImagePath
    {
      get
      {
        if (this.imageFiles != null)
          return this.imageFiles.FirstOrDefault<string>();
        return (string) null;
      }
    }

    private TmxFile()
    {
    }

    public TmxFile(FilePath filePath)
      : base(filePath)
    {
      this.imageFiles = this.GetImageFiles();
    }

    public TmxFile(ResourceData resourceData)
      : base(resourceData)
    {
    }

    private List<string> GetImageFiles()
    {
      ICompositeResourceProcesser resourceProcesser = ProjectsService.Instance.GetCompositeResourceProcesser(this.FullPath);
      if (resourceProcesser != null)
        return resourceProcesser.GetMatchedImages(this.FullPath);
      return (List<string>) null;
    }

    protected override void OnDelete()
    {
      if (this.imageFiles != null)
      {
        foreach (string path in this.imageFiles.AsReadOnly())
        {
          if (File.Exists(path))
            File.Delete(path);
        }
      }
      this.FileName.Delete();
      base.OnDelete();
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename)
    {
      if (this.imageFiles != null)
      {
        try
        {
          foreach (string imageFile in this.imageFiles)
          {
            Path.GetFileName(imageFile);
            FilePath filePath = (FilePath) imageFile;
            FilePath absolute = filePath.ToRelative(this.FileName.ParentDirectory).ToAbsolute(newFilePath.ParentDirectory);
            string parentDirectory = (string) absolute.ParentDirectory;
            if (!Directory.Exists(parentDirectory))
              Directory.CreateDirectory(parentDirectory);
            if (File.Exists((string) filePath))
            {
              if (File.Exists((string) absolute))
                absolute.Delete();
              FileService.MoveFile(imageFile, (string) absolute);
            }
          }
        }
        catch (Exception ex)
        {
          LogConfig.Output.Error((object) ex.Message, ex);
        }
      }
      base.OnSetLocation(newFilePath, isRename);
      this.imageFiles = this.GetImageFiles();
    }

    protected override ICompositeResourceProcesser GetCompositeResourceProcesser()
    {
      if (TmxFile.pairResourceProcesser == null)
        TmxFile.pairResourceProcesser = ProjectsService.Instance.GetCompositeResourceProcesser((string) this.FileName);
      return TmxFile.pairResourceProcesser;
    }

    protected override bool OnCheckValid()
    {
      bool flag = base.OnCheckValid();
      if (flag)
      {
        this.imageFiles = this.GetImageFiles();
        if (!this.CheckFilesExists((IEnumerable<string>) this.imageFiles))
          flag = false;
      }
      return flag;
    }

    private bool CheckFilesExists(IEnumerable<string> files)
    {
      if (files == null)
        return false;
      foreach (string file in files)
      {
        if (!File.Exists(file))
          return false;
      }
      return true;
    }
  }
}
