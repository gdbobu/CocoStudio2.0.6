// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.IWorkspaceFileObject
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Projects
{
  public interface IWorkspaceFileObject : IFileItem, IWorkspaceObject, IExtendedDataItem, IFoldeItem, IDisposable
  {
    FilePath FileName { get; set; }
  }
}
