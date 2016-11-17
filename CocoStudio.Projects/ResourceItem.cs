// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceItem
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections;
using System.IO;

namespace CocoStudio.Projects
{
  [DataInclude(typeof (ResourceFolder))]
  [DataItem("Item")]
  [DataInclude(typeof (ResourceFile))]
  public abstract class ResourceItem : IResource, IExtendedDataItem
  {
    internal const string PathPropertyName = "Name";
    internal const string DataItemName = "Item";
    protected Hashtable hashtable;
    protected DateTime? lastWriteTime;
    protected long? fileSize;

    public virtual string Name { get; protected set; }

    public abstract string FullPath { get; }

    internal virtual string PreviewImagePath
    {
      get
      {
        return string.Empty;
      }
    }

    public virtual PreviewImageInfo PreviewImageInfo
    {
      get
      {
        return ProjectsService.Instance.PreviemImageService.GetImage(this);
      }
    }

    public string RelativePath
    {
      get
      {
        return (string) ResourceItem.GetRelativePath((FilePath) this.FullPath);
      }
    }

    public IDictionary ExtendedProperties
    {
      get
      {
        if (this.hashtable == null)
          this.hashtable = new Hashtable();
        return (IDictionary) this.hashtable;
      }
    }

    public virtual ResourceItem Parent { get; internal set; }

    public event EventHandler<EventArgs> Deleted;

    public event EventHandler<EventArgs> NameChanged;

    public abstract ResourceData GetResourceData();

    protected virtual ResourceData CreateResourceData(FilePath filePath)
    {
      return new ResourceData((string) ResourceItem.GetRelativePath(filePath));
    }

    protected static FilePath GetRelativePath(FilePath fullPath)
    {
      if (ProjectsService.Instance.CurrentSolution == null)
        return (FilePath) ((string) null);
      FilePath itemDirectory = ProjectsService.Instance.CurrentSolution.ItemDirectory;
      return (FilePath) Option.ConvertToMacPath((string) fullPath.ToRelative(itemDirectory));
    }

    protected virtual void OnNameChanged()
    {
      if (this.NameChanged == null)
        return;
      this.NameChanged((object) this, new EventArgs());
    }

    internal void Delete()
    {
      using (ResourceChangedFactory.GetSender(this, true, (ResourceData) null))
        this.OnDelete();
    }

    internal void SetLocation(FilePath newFilePath, bool isRename = true)
    {
      using (ResourceChangedFactory.GetSender(this, false, (ResourceData) null))
        this.OnSetLocation(newFilePath, isRename);
    }

    protected virtual void OnSetLocation(FilePath newFilePath, bool isRename = true)
    {
      if (this.NameChanged == null)
        return;
      this.NameChanged((object) this, new EventArgs());
    }

    protected virtual void OnDelete()
    {
      if (this.Deleted == null)
        return;
      this.Deleted((object) this, (EventArgs) null);
    }

    internal virtual bool IsNeedRefresh()
    {
      if (!File.Exists(this.FullPath))
      {
        if (!this.lastWriteTime.HasValue)
          return false;
        this.lastWriteTime = new DateTime?();
        return true;
      }
      DateTime? lastWriteTime1 = this.GetLastWriteTime(this.FullPath);
      long? fileSize1 = this.GetFileSize((FilePath) this.FullPath);
      DateTime? nullable1 = lastWriteTime1;
      DateTime? lastWriteTime2 = this.lastWriteTime;
      if ((nullable1.HasValue != lastWriteTime2.HasValue ? 1 : (!nullable1.HasValue ? 0 : (nullable1.GetValueOrDefault() != lastWriteTime2.GetValueOrDefault() ? 1 : 0))) == 0)
      {
        long? fileSize2 = this.fileSize;
        long? nullable2 = fileSize1;
        if ((fileSize2.GetValueOrDefault() != nullable2.GetValueOrDefault() ? 1 : (fileSize2.HasValue != nullable2.HasValue ? 1 : 0)) == 0)
          return false;
      }
      return true;
    }

    protected DateTime? GetLastWriteTime(string filePath)
    {
      try
      {
        if (!File.Exists(filePath) || string.IsNullOrWhiteSpace(filePath))
          return new DateTime?();
        return new DateTime?(File.GetLastWriteTime(filePath));
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex);
        return new DateTime?();
      }
    }

    protected long? GetFileSize(FilePath value)
    {
      try
      {
        if (!File.Exists((string) value))
          return new long?();
        return new long?(new FileInfo((string) value).Length);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex);
        return new long?();
      }
    }

    public void Refresh(bool isForce = false)
    {
      if (!isForce && !this.IsNeedRefresh())
        return;
      this.OnRefresh();
    }

    protected virtual void OnRefresh()
    {
      this.lastWriteTime = this.GetLastWriteTime(this.FullPath);
      this.fileSize = this.GetFileSize((FilePath) this.FullPath);
      ProjectsService.Instance.PreviemImageService.UpdateImage(this);
      this.OnNameChanged();
    }
  }
}
