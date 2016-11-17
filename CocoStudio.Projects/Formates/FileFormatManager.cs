// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.FileFormatManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Projects.Formates
{
  internal class FileFormatManager
  {
    private List<IFileFormat> fileFormats = new List<IFileFormat>();
    private ResourceItemFormat defaultResourceFormat;

    internal List<IFileFormat> FileFormats
    {
      get
      {
        return this.fileFormats;
      }
    }

    public FileFormatManager()
    {
      this.CollectFileFormat();
      this.defaultResourceFormat = this.fileFormats.FirstOrDefault<IFileFormat>((Func<IFileFormat, bool>) (a => a is ResourceItemFormat)) as ResourceItemFormat;
    }

    private void CollectFileFormat()
    {
      this.fileFormats.AddRange((IEnumerable<IFileFormat>) AddinManager.GetExtensionObjects<IFileFormat>());
      AddinManager.AddExtensionNodeHandler(typeof (IFileFormat), new ExtensionNodeEventHandler(this.OnFileFormatExtensionChanged));
    }

    private void OnFileFormatExtensionChanged(object sender, ExtensionNodeEventArgs args)
    {
      TypeExtensionNode extension = args.ExtensionNode as TypeExtensionNode;
      if (this.fileFormats.Any<IFileFormat>((Func<IFileFormat, bool>) (a => a.GetType().Equals(extension.Type))))
        return;
      this.fileFormats.Add(Activator.CreateInstance(extension.Type) as IFileFormat);
    }

    public List<FileFormat> GetFileFormats(string fileName, Type expectedType)
    {
      List<FileFormat> fileFormatList = new List<FileFormat>();
      foreach (FileFormat fileFormat in this.fileFormats)
      {
        if (fileFormat.CanReadFile((FilePath) fileName, expectedType))
          fileFormatList.Add(fileFormat);
      }
      return fileFormatList;
    }

    internal List<FileFormat> GetFileFormatsForObject(object obj)
    {
      List<FileFormat> fileFormatList = new List<FileFormat>();
      foreach (FileFormat fileFormat in this.fileFormats)
      {
        if (fileFormat.CanWriteFile(obj))
          fileFormatList.Add(fileFormat);
      }
      return fileFormatList;
    }

    internal FileFormat GetDefaultResourceFormat()
    {
      return (FileFormat) this.defaultResourceFormat;
    }
  }
}
