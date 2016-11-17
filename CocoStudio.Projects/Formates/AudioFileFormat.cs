// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.AudioFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  public class AudioFileFormat : FileFormat
  {
    protected override bool OnCanWriteFile(object obj)
    {
      return obj is AudioFile;
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      return (FileFormat.CheckFileSuffix(file, ".mp3") || FileFormat.CheckFileSuffix(file, ".wav")) && (expectedObjectType.Equals(typeof (AudioFile)) || expectedObjectType.Equals(typeof (ResourceItem)));
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return (object) new AudioFile(file);
    }
  }
}
