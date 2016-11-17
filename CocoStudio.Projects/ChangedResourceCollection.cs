// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ChangedResourceCollection
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  public class ChangedResourceCollection : Dictionary<ResourceData, ResourceFile>
  {
    public ChangedResourceCollection(ResourceData oldData, ResourceItem resourceFile)
    {
      this.Add(oldData, resourceFile as ResourceFile);
    }
  }
}
