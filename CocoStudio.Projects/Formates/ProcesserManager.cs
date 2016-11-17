// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ProcesserManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using Mono.Addins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Projects.Formates
{
  internal class ProcesserManager
  {
    private List<IPublishProcesser> publishProcessers;
    private List<ICompositeResourceProcesser> pairProcessers;

    public ProcesserManager()
    {
      this.publishProcessers = this.CollectProcesser<IPublishProcesser>();
      this.pairProcessers = this.CollectProcesser<ICompositeResourceProcesser>();
    }

    private List<T> CollectProcesser<T>()
    {
      return new List<T>((IEnumerable<T>) AddinManager.GetExtensionObjects<T>());
    }

    internal IPublishProcesser GetPublishProcesser(ResourceData resourceData)
    {
      return this.publishProcessers.FirstOrDefault<IPublishProcesser>((Func<IPublishProcesser, bool>) (a => a.CanProcess(resourceData)));
    }

    internal ICompositeResourceProcesser GetPairResourceProcesser(string filePath)
    {
      return this.pairProcessers.FirstOrDefault<ICompositeResourceProcesser>((Func<ICompositeResourceProcesser, bool>) (a => a.CanProcess(filePath)));
    }
  }
}
