// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ImageFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Mono.Addins;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IPublishProcesser))]
  [Extension(typeof (IFileFormat))]
  internal class ImageFileFormat : FileFormat, IPublishProcesser
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is ImageFile;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      return (FileFormat.CheckFileSuffix(file, ".png") || FileFormat.CheckFileSuffix(file, ".jpg") || FileFormat.CheckFileSuffix(file, ".pvr")) && (expectedObjectType.Equals(typeof (ImageFile)) || expectedObjectType.Equals(typeof (ResourceItem)));
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new ImageFile(file);
    }

    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.MarkedSubImage)
        return true;
      if (resourceData.Type != EnumResourceType.Normal || !ProjectsService.Instance.IsImageFile(resourceData))
        return false;
      ImageFile resourceItem = ProjectsService.Instance.CurrentResourceGroup.FindResourceItem(resourceData) as ImageFile;
      return resourceItem != null && resourceItem.IsPacked();
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      return (HashSet<ResourceData>) null;
    }
  }
}
