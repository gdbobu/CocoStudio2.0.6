// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.IProjectFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using MonoDevelop.Core;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  public interface IProjectFile : IInitialize
  {
    bool IsLoaded { get; }

    void Load(IProgressMonitor monitor);

    void Save(IProgressMonitor monitor);

    void UnLoad(IProgressMonitor monitor);

    HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor);

    bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourceCollection);
  }
}
