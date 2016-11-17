// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ResourceItemFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  internal class ResourceItemFormat : FileFormat
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return false;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      return false;
    }

    protected override void OnWriteFile(FilePath file, object obj, IProgressMonitor monitor)
    {
      throw new InvalidOperationException("Simple resource file can't write. Only project file can write.");
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      if (file.IsDirectory)
        return (object) new ResourceFolder(file);
      return (object) new ResourceFile(file);
    }
  }
}
