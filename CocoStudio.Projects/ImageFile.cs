// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ImageFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Collections;
using MonoDevelop.Core.Serialization;
using System;
using System.IO;
using System.Linq;

namespace CocoStudio.Projects
{
  [DataItem(Name = "Image")]
  public class ImageFile : ResourceFile
  {
    private Set<Project> packedprojects;

    public Set<Project> Packedprojects
    {
      get
      {
        if (this.packedprojects == null)
          this.packedprojects = new Set<Project>();
        return this.packedprojects;
      }
    }

    internal override string PreviewImagePath
    {
      get
      {
        return this.FullPath;
      }
    }

    public event EventHandler<EventArgs> PackedChanged;

    private ImageFile()
    {
    }

    public ImageFile(FilePath fileName)
      : base(fileName)
    {
    }

    public ImageFile(ResourceData resourceData)
      : base(resourceData)
    {
    }

    public bool IsPacked()
    {
      return this.Packedprojects.Count > 0;
    }

    public bool HasPackedTo(Project project)
    {
      return this.Packedprojects.Contains(project);
    }

    public void UnPackFrom(Project project)
    {
      if (project == null || !this.Packedprojects.Contains(project))
        return;
      using (ResourceChangedFactory.GetSender((ResourceItem) this, false, (ResourceData) null))
      {
        this.Packedprojects.Remove(project);
        this.OnPackedChanged();
      }
    }

    public void PackTo(Project project)
    {
      if (project == null || this.Packedprojects.Contains(project))
        return;
      using (ResourceChangedFactory.GetSender((ResourceItem) this, false, (ResourceData) null))
      {
        this.Packedprojects.Add(project);
        this.OnPackedChanged();
      }
    }

    private void OnPackedChanged()
    {
      if (this.PackedChanged == null)
        return;
      this.PackedChanged((object) this, (EventArgs) null);
    }

    protected override ResourceData CreateResourceData(FilePath filePath)
    {
      string projectFilePath = (string) null;
      if (this.packedprojects != null && this.Packedprojects.Count != 0)
        projectFilePath = (string) this.Packedprojects.First<Project>().FileName;
      return this.CreateResourceData(filePath, projectFilePath);
    }

    private ResourceData CreateResourceData(FilePath filePath, string projectFilePath)
    {
      if (projectFilePath != null)
        return new ResourceData(EnumResourceType.MarkedSubImage, (string) ResourceItem.GetRelativePath(filePath), (string) (FilePath) Path.ChangeExtension((string) ResourceItem.GetRelativePath((FilePath) projectFilePath), ".plist"));
      return base.CreateResourceData(filePath);
    }

    protected override void OnRefresh()
    {
      CSCocosHelp.ReloadPngFileToCache(this.FullPath);
      base.OnRefresh();
    }

    protected override void OnDelete()
    {
      base.OnDelete();
      if (this.packedprojects != null)
        this.packedprojects = (Set<Project>) null;
      CSCocosHelp.RemovePngFileFromCache(this.GetResourceData().Path);
    }

    public void PackedProjectNameChanged(Project project, string oldProjectFilePath)
    {
      using (ResourceChangedFactory.GetSender((ResourceItem) this, false, this.CreateResourceData((FilePath) this.FullPath, oldProjectFilePath)))
        ;
    }
  }
}
