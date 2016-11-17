// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.IWorkspaceObject
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Projects
{
  public interface IWorkspaceObject : IExtendedDataItem, IFoldeItem, IDisposable
  {
    string Name { get; set; }

    FilePath ItemDirectory { get; }

    FilePath BaseDirectory { get; set; }

    void Save(IProgressMonitor monitor);
  }
}
