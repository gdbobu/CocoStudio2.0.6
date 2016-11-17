// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Events.AddResourcesArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using System;
using System.Collections.Generic;

namespace CocoStudio.Core.Events
{
  public class AddResourcesArgs : EventArgs
  {
    public ResourceFolder Parent { get; private set; }

    public bool IsExpand { get; private set; }

    public IEnumerable<ResourceItem> AddItems { get; private set; }

    public AddResourcesArgs(ResourceFolder parent, IEnumerable<ResourceItem> addItems, bool isExpand = true)
    {
      this.Parent = parent;
      this.AddItems = addItems;
      this.IsExpand = isExpand;
    }

    public AddResourcesArgs(ResourceFolder parent, ResourceItem addItem, bool isExpand = true)
    {
      this.Parent = parent;
      this.AddItems = (IEnumerable<ResourceItem>) new List<ResourceItem>()
      {
        addItem
      };
      this.IsExpand = isExpand;
    }
  }
}
