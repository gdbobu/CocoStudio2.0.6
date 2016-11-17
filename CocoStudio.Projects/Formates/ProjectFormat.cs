// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ProjectFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  internal class ProjectFormat : FileFormat
  {
    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      return FileFormat.CheckFileSuffix(file, ".csd") && (expectedObjectType.Equals(typeof (Project)) || expectedObjectType.Equals(typeof (ResourceItem)));
    }

    protected override bool OnCanWriteFile(object obj)
    {
      return obj.GetType().IsSubclassOf(typeof (Project));
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new Project(file);
    }

    protected override void OnWriteFile(FilePath file, object obj, IProgressMonitor monitor)
    {
    }
  }
}
