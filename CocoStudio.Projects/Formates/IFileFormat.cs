// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.IFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Projects.Formates
{
  [TypeExtensionPoint]
  public interface IFileFormat
  {
    bool CanReadFile(FilePath file, Type expectedObjectType);

    bool CanWriteFile(object obj);

    void WriteFile(FilePath file, object obj, IProgressMonitor monitor);

    object ReadFile(FilePath file, Type expectedType, IProgressMonitor monitor);
  }
}
