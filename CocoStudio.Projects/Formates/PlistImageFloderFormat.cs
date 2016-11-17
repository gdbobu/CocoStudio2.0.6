// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.PlistImageFloderFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Modules.Communal.Packer.PlistReader;
using Mono.Addins;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  [Extension(typeof (IPublishProcesser))]
  [Extension(typeof (ICompositeResourceProcesser))]
  internal class PlistImageFloderFormat : FileFormat, IPublishProcesser, ICompositeResourceProcesser
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is PlistImageFolder;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      try
      {
        if (!FileFormat.CheckFileSuffix(file, ".plist") || !expectedObjectType.Equals(typeof (ResourceItem)))
          return false;
        return PlistImageFormatFactory.CreatePlistFormat((string) file) != null;
      }
      catch
      {
      }
      return false;
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new PlistImageFolder(file);
    }

    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.MarkedSubImage)
        return false;
      return this.CanReadFile(ProjectsService.Instance.GetFullPath(resourceData), typeof (ResourceItem));
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      FilePath fullPath = ProjectsService.Instance.GetFullPath(resourceData);
      return PairResourceHelp.GetResourcesIncludeImage(resourceData, ((ICompositeResourceProcesser) this).GetMatchedImages((string) fullPath));
    }

    bool ICompositeResourceProcesser.CanProcess(string filePath)
    {
      return this.CanReadFile((FilePath) filePath, typeof (ResourceItem));
    }

    List<string> ICompositeResourceProcesser.GetMatchedImages(string filePath)
    {
      if (PlistImageFormatFactory.CreatePlistFormat(filePath) == null)
        return (List<string>) null;
      return new List<string>() { PlistImageFormatFactory.CreatePlistFormat(filePath).GetImageFilePath(filePath) };
    }
  }
}
