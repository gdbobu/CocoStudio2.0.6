// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.PairResourceHelp
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using MonoDevelop.Core;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects.Formates
{
  internal static class PairResourceHelp
  {
    public static HashSet<ResourceData> GetResourcesIncludeImage(ResourceData resourceData, List<string> imageFiles)
    {
      HashSet<ResourceData> resourceDataSet = new HashSet<ResourceData>();
      resourceDataSet.Add(resourceData);
      if (imageFiles != null)
      {
        foreach (string imageFile in imageFiles)
        {
            FilePath tmp = new FilePath(imageFile);
          FilePath relative = tmp.ToRelative(ProjectsService.Instance.CurrentSolution.ItemDirectory);
          ResourceData resourceData1 = new ResourceData(resourceData.Type, (string) relative);
          resourceDataSet.Add(resourceData1);
        }
      }
      return resourceDataSet;
    }

    public static string GetMatchedImage(string resourcePath, string fileSuffix = ".png")
    {
      return Path.ChangeExtension(resourcePath, fileSuffix);
    }
  }
}
