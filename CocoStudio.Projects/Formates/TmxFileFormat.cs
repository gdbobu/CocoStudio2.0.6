// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.TmxFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model;
using Mono.Addins;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (ICompositeResourceProcesser))]
  [Extension(typeof (IFileFormat))]
  [Extension(typeof (IPublishProcesser))]
  public class TmxFileFormat : FileFormat, IPublishProcesser, ICompositeResourceProcesser
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is TmxFile;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      try
      {
        return this.CheckFileSuffix((string) file, ".tmx") && expectedObjectType.Equals(typeof (ResourceItem));
      }
      catch
      {
      }
      return false;
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new TmxFile(file);
    }

    bool IPublishProcesser.CanProcess(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.PlistSubImage)
        return false;
      return this.CheckFileSuffix(resourceData.Path, ".tmx");
    }

    HashSet<ResourceData> IPublishProcesser.Process(ResourceData resourceData)
    {
      HashSet<ResourceData> resourceDataSet = new HashSet<ResourceData>();
      resourceDataSet.Add(resourceData);
      CSVectorString tmxMapImageArray = CSCocosHelp.GetTmxMapImageArray((string) ProjectsService.Instance.GetFullPath(resourceData));
      string directoryName = Path.GetDirectoryName(resourceData.Path);
      foreach (string path2 in tmxMapImageArray)
      {
        string path = Path.Combine(directoryName, path2);
        ResourceData resourceData1 = new ResourceData(resourceData.Type, path);
        resourceDataSet.Add(resourceData1);
      }
      return resourceDataSet;
    }

    private bool CheckFileSuffix(string path, string FileSuffix)
    {
      return Path.GetExtension(path).Equals(FileSuffix, StringComparison.OrdinalIgnoreCase);
    }

    bool ICompositeResourceProcesser.CanProcess(string filePath)
    {
      return this.CanReadFile((FilePath) filePath, typeof (ResourceItem));
    }

    List<string> ICompositeResourceProcesser.GetMatchedImages(string filePath)
    {
        CSVectorString tmxMapImageArray = CSCocosHelp.GetTmxMapImageArray(filePath);
        string directoryName = Path.GetDirectoryName(filePath);
        List<string> list = new List<string>();
        if (tmxMapImageArray == null)
        {
            return null;
        }
        foreach (FilePath current in tmxMapImageArray)
        {
            string item = current.ToAbsolute(directoryName);
            list.Add(item);
        }
        return list;
    }
  }
}
