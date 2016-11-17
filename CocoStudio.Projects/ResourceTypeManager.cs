// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceTypeManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  internal class ResourceTypeManager
  {
    public List<Type> ResourceTypeList { get; private set; }

    public ResourceTypeManager()
    {
      this.ResourceTypeList = new List<Type>();
      this.CollectResourceType();
    }

    private void CollectResourceType()
    {
      foreach (TypeExtensionNode extensionNode in AddinManager.GetExtensionNodes(typeof (IResource)))
        this.ResourceTypeList.Add(extensionNode.Type);
    }
  }
}
