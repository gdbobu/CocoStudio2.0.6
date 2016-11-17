// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.AudioFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;

namespace CocoStudio.Projects
{
  [DataItem(Name = "Audio")]
  public class AudioFile : ResourceFile
  {
    public AudioFile(FilePath fileName)
      : base(fileName)
    {
    }

    public AudioFile()
    {
    }
  }
}
