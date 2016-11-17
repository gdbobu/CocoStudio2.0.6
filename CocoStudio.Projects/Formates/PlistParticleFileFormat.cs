// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.PlistParticleFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Modules.Communal.Packer;
using Mono.Addins;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (ICompositeResourceProcesser))]
  [Extension(typeof (IPublishProcesser))]
  [Extension(typeof (IFileFormat))]
  internal class PlistParticleFileFormat : FileFormat, IPublishProcesser, ICompositeResourceProcesser
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is PlistParticleFile;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      try
      {
        if (!FileFormat.CheckFileSuffix(file, ".plist") || !expectedObjectType.Equals(typeof (ResourceItem)))
          return false;
        return PlistParticleReader.CheckIsParticle((string) file);
      }
      catch
      {
      }
      return false;
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new PlistParticleFile(file);
    }

    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      FilePath fullPath = ProjectsService.Instance.GetFullPath(resourceData);
      if (!this.CanReadFile(fullPath, typeof (ResourceItem)))
        return false;
      return ((ICompositeResourceProcesser) this).GetMatchedImages((string) fullPath) != null;
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      string fullPath = (string) ProjectsService.Instance.GetFullPath(resourceData);
      return PairResourceHelp.GetResourcesIncludeImage(resourceData, ((ICompositeResourceProcesser) this).GetMatchedImages(fullPath));
    }

    bool ICompositeResourceProcesser.CanProcess(string filePath)
    {
      return PlistParticleReader.CheckIsParticle(filePath);
    }

    List<string> ICompositeResourceProcesser.GetMatchedImages(string filePath)
    {
      FilePath filePath1 = (FilePath) PlistParticleReader.GetMatchImage(filePath);
      if (filePath1 == (FilePath) ((string) null))
        return (List<string>) null;
      string directoryName = Path.GetDirectoryName(filePath);
      filePath1 = filePath1.ToAbsolute((FilePath) directoryName);
      return new List<string>() { (string) filePath1 };
    }
  }
}
