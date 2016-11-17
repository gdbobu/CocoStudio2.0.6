// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.SolutionFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  internal class SolutionFormat : FileFormat
  {
    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      return expectedObjectType.Equals(typeof (Solution)) && FileFormat.CheckFileSuffix(file, ".ccs");
    }

    protected override XmlDataSerializer CreateSerializer(FilePath file)
    {
      XmlDataSerializer serializer = base.CreateSerializer(file);
      DataContext dataContext = serializer.SerializationContext.Serializer.DataContext;
      foreach (Type resourceType in FileFormat.ResourceTypeManager.ResourceTypeList)
        dataContext.IncludeType(resourceType);
      string str = (string) file.ParentDirectory.Combine(new string[1]{ "CocosStudio".ToLower() }).Combine(new string[1]{ "TempAppendFileName.Folder" });
      serializer.SerializationContext.BaseFile = str;
      return serializer;
    }

    protected override bool OnCanWriteFile(object obj)
    {
      return obj.GetType().Equals(typeof (Solution));
    }
  }
}
