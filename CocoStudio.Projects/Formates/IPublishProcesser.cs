// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.IPublishProcesser
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Mono.Addins;
using System.Collections.Generic;

namespace CocoStudio.Projects.Formates
{
  [TypeExtensionPoint]
  public interface IPublishProcesser
  {
    bool CanProcess(ResourceData resourceData);

    HashSet<ResourceData> Process(ResourceData resourceData);
  }
}
