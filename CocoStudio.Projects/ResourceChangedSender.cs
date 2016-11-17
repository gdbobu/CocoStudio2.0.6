// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceChangedSender
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using System;

namespace CocoStudio.Projects
{
  internal class ResourceChangedSender : IDisposable
  {
    private ResourceItem resourceFile;
    private ResourceData oldResourceData;
    private bool isDeleted;

    internal event Action<ResourceChangedSender, ResourceItem> Disposed;

    protected ResourceChangedSender()
    {
    }

    public ResourceChangedSender(ResourceItem resourceFile, bool isDeleted = false, ResourceData oldResourceData = null)
    {
      this.resourceFile = resourceFile;
      this.oldResourceData = !(oldResourceData == (ResourceData) null) ? oldResourceData : resourceFile.GetResourceData();
      this.isDeleted = isDeleted;
    }

    public virtual void Dispose()
    {
      ResourceItem resourceFile = this.resourceFile;
      if (this.isDeleted)
        resourceFile = (ResourceItem) null;
      ProjectsService.Instance.NotifyResourceFileChanged(new ChangedResourceCollection(this.oldResourceData, resourceFile));
      if (this.Disposed == null)
        return;
      this.Disposed(this, this.resourceFile);
    }
  }
}
