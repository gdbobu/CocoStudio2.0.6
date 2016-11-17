// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.FntFileFormat
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
  [Extension(typeof (ICompositeResourceProcesser))]
  [Extension(typeof (IPublishProcesser))]
  [Extension(typeof (IFileFormat))]
  internal class FntFileFormat : FileFormat, IPublishProcesser, ICompositeResourceProcesser
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is FntFile;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      try
      {
        return FntFileFormat.CheckFileSuffix(file) && expectedObjectType.Equals(typeof (ResourceItem));
      }
      catch
      {
      }
      return false;
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new FntFile(file);
    }

    private static bool CheckFileSuffix(FilePath filePath)
    {
      return FileFormat.CheckFileSuffix(filePath, ".fnt");
    }

    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.PlistSubImage)
        return false;
      return FntFileFormat.CheckFileSuffix((FilePath) resourceData.Path);
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      return PairResourceHelp.GetResourcesIncludeImage(resourceData, ((ICompositeResourceProcesser) this).GetMatchedImages(resourceData.Path));
    }

    bool ICompositeResourceProcesser.CanProcess(string filePath)
    {
      return this.CanReadFile((FilePath) filePath, typeof (ResourceItem));
    }

    List<string> ICompositeResourceProcesser.GetMatchedImages(string filePath)
    {
      return new List<string>() { PairResourceHelp.GetMatchedImage(filePath, ".png") };
    }
  }
}
