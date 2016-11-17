// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ExtendResourceItemFormates.PlistImageFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Mono.Addins;
using System.Collections.Generic;

namespace CocoStudio.Projects.Formates.ExtendResourceItemFormates
{
  [Extension(typeof (IPublishProcesser))]
  internal class PlistImageFileFormat : IPublishProcesser
  {
    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      return resourceData.Type == EnumResourceType.PlistSubImage;
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      ResourceData resourceData1 = new ResourceData(EnumResourceType.Normal, resourceData.Plist);
      return ProjectsService.Instance.GetPublishProcesser(resourceData1).Process(resourceData1);
    }
  }
}
