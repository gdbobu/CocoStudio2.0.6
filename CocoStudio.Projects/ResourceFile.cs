// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects
{
  [DataInclude(typeof (FntFile))]
  [DataInclude(typeof (PlistParticleFile))]
  [DataInclude(typeof (AudioFile))]
  [DataInclude(typeof (Project))]
  [DataInclude(typeof (PlistImageFile))]
  [DataItem(Name = "File")]
  [DataInclude(typeof (ImageFile))]
  [DataInclude(typeof (TmxFile))]
  public class ResourceFile : ResourceItem, IFileItem, IResourceValid
  {
    private FilePath fileName;
    protected string name;

    [ResourcePathItemProperty("Name")]
    public FilePath FileName
    {
      get
      {
        return this.fileName;
      }
      internal set
      {
        this.fileName = value;
        this.lastWriteTime = this.GetLastWriteTime((string) value);
        this.fileSize = this.GetFileSize(value);
      }
    }

    public override string Name
    {
      get
      {
        if (!string.IsNullOrEmpty(this.name))
          return this.name;
        return this.FileName.FileName;
      }
      protected set
      {
        this.FileName = this.FileName.ParentDirectory.Combine(new string[1]{ value });
        this.name = value;
      }
    }

    public bool IsValid
    {
      get
      {
        return this.OnCheckValid();
      }
    }

    public bool IsDefault { get; private set; }

    public override string FullPath
    {
      get
      {
        return (string) this.FileName.FullPath;
      }
    }

    protected ResourceFile()
    {
    }

    public ResourceFile(FilePath fileName)
    {
      if (!fileName.IsAbsolute)
        throw new ArgumentException("Must be absolute path.");
      this.FileName = fileName;
    }

    public ResourceFile(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.Default)
        this.IsDefault = true;
      this.FileName = ProjectsService.Instance.GetFullPath(resourceData);
    }

    protected virtual ResourceData CreateDefaultResourceData(FilePath filePath)
    {
      return new ResourceData(EnumResourceType.Default, Option.ConvertToMacPath((string) filePath.ToRelative((FilePath) Option.EditorDefaultResourcePath)));
    }

    public override ResourceData GetResourceData()
    {
      if (this.IsDefault)
        return this.CreateDefaultResourceData(this.FileName);
      return this.CreateResourceData(this.FileName);
    }

    protected override void OnSetLocation(FilePath newFilePath, bool isRename = true)
    {
      this.GetResourceData();
      if (!isRename)
      {
        if (!Directory.Exists((string) newFilePath.ParentDirectory))
          Directory.CreateDirectory((string) newFilePath.ParentDirectory);
        FileService.MoveFile((string) this.FileName, (string) newFilePath);
      }
      this.FileName = newFilePath;
      base.OnSetLocation(newFilePath, isRename);
    }

    protected virtual bool OnCheckValid()
    {
      if (this.IsDefault)
        return true;
      if (!File.Exists((string) this.FileName))
        return false;
      ICompositeResourceProcesser resourceProcesser = this.GetCompositeResourceProcesser();
      if (resourceProcesser != null)
      {
        List<string> matchedImages = resourceProcesser.GetMatchedImages((string) this.FileName);
        if (matchedImages != null)
        {
          foreach (string path in matchedImages)
          {
            if (!File.Exists(path))
              return false;
          }
        }
      }
      return true;
    }

    protected override void OnDelete()
    {
      try
      {
        this.FileName.Delete();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex.ToString());
      }
      base.OnDelete();
    }

    protected override void OnRefresh()
    {
      base.OnRefresh();
      if (this.IsValid)
        return;
      base.OnDelete();
    }

    protected virtual ICompositeResourceProcesser GetCompositeResourceProcesser()
    {
      return (ICompositeResourceProcesser) null;
    }
  }
}
