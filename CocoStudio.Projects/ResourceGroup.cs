// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceGroup
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CocoStudio.Projects
{
  [JsonObject(MemberSerialization.OptIn)]
  [DataInclude(typeof (ResourceItem))]
  [DataInclude(typeof (Item))]
  public class ResourceGroup : SolutionEntityItem, IInitialize
  {
    [ItemProperty("RootFolder")]
    [JsonProperty(PropertyName = "RootFolder")]
    public ResourceFolder RootFolder { get; private set; }

    private ResourceGroup()
    {
    }

    public ResourceGroup(Solution parentSolution)
    {
      this.ParentFolder = parentSolution.RootFolder;
      this.ParentSolution = parentSolution;
      this.RootFolder = new ResourceFolder(parentSolution.ItemDirectory);
    }

    protected override void OnSave(IProgressMonitor monitor)
    {
      ((IProjectFile) this.RootFolder).Save(monitor);
    }

    public void Initialize(IProgressMonitor monitor)
    {
      ((IInitialize) this.RootFolder).Initialize(monitor);
    }

    public ResourceItem FindResourceItem(string filePath)
    {
      filePath = FileService.MakePathSeparatorsNative(filePath);
      if (!Path.IsPathRooted(filePath))
        filePath = Path.Combine((string) this.RootFolder.BaseDirectory, filePath);
      return this.FindResourceItem((ResourceItem) this.RootFolder, filePath);
    }

    public ResourceItem FindResourceItem(ResourceData resourceData)
    {
      if (resourceData.Type == EnumResourceType.Normal || resourceData.Type == EnumResourceType.MarkedSubImage)
        return this.FindResourceItem(resourceData.Path);
      if (resourceData.Type == EnumResourceType.PlistSubImage)
      {
        ResourceFolder resourceItem = this.FindResourceItem(resourceData.Plist) as ResourceFolder;
        if (resourceItem != null)
          return resourceItem.Items.FirstOrDefault<ResourceItem>((Func<ResourceItem, bool>) (a => a.Name.Equals(resourceData.Path, StringComparison.OrdinalIgnoreCase)));
      }
      return (ResourceItem) null;
    }

    public ResourceItem FindResourceItem(ResourceItem parentItem, string fullPath)
    {
      if (parentItem.FullPath.Equals(fullPath, StringComparison.OrdinalIgnoreCase))
        return parentItem;
      if (parentItem is ResourceFolder)
      {
        ResourceFolder resourceFolder = parentItem as ResourceFolder;
        if (fullPath.StartsWith(resourceFolder.FullPath, StringComparison.OrdinalIgnoreCase))
        {
          foreach (ResourceItem parentItem1 in (Collection<ResourceItem>) resourceFolder.Items)
          {
            ResourceItem resourceItem = this.FindResourceItem(parentItem1, fullPath);
            if (resourceItem != null)
              return resourceItem;
          }
        }
      }
      return (ResourceItem) null;
    }

    public HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor)
    {
      return ((IProjectFile) this.RootFolder).GetUsedResources(monitor);
    }
  }
}
