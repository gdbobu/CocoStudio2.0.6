// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PlistParticleFile
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

namespace CocoStudio.Projects
{
  public class PlistParticleFile : ResourceFile
  {
    private static ICompositeResourceProcesser pairResourceProcesser;

    public List<string> imgeFiles
    {
      get
      {
        ICompositeResourceProcesser resourceProcesser = ProjectsService.Instance.GetCompositeResourceProcesser(this.FullPath);
        if (resourceProcesser != null)
          return resourceProcesser.GetMatchedImages(this.FullPath);
        return (List<string>) null;
      }
    }

    internal override string PreviewImagePath
    {
      get
      {
        return (string) null;
      }
    }

    private PlistParticleFile()
    {
    }

    public PlistParticleFile(FilePath filePath)
      : base(filePath)
    {
    }

    public PlistParticleFile(ResourceData resourceData)
      : base(resourceData)
    {
    }

    protected override void OnDelete()
    {
      if (this.imgeFiles != null)
      {
        foreach (string imgeFile in this.imgeFiles)
        {
          if (File.Exists(imgeFile))
            File.Delete(imgeFile);
        }
      }
      this.FileName.Delete();
      base.OnDelete();
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename)
    {
      string directoryName = Path.GetDirectoryName((string) newFilePath);
      if (this.imgeFiles != null)
      {
        try
        {
          foreach (string imgeFile in this.imgeFiles)
          {
            string fileName = Path.GetFileName(imgeFile);
            string dstFile = Path.Combine(directoryName, fileName);
            FileService.MoveFile(imgeFile, dstFile);
          }
        }
        catch (Exception ex)
        {
          LogConfig.Output.Error((object) ex.Message, ex);
        }
      }
      base.OnSetLocation(newFilePath, isRename);
    }

    protected override ICompositeResourceProcesser GetCompositeResourceProcesser()
    {
      if (PlistParticleFile.pairResourceProcesser == null)
        PlistParticleFile.pairResourceProcesser = ProjectsService.Instance.GetCompositeResourceProcesser((string) this.FileName);
      return PlistParticleFile.pairResourceProcesser;
    }
  }
}
