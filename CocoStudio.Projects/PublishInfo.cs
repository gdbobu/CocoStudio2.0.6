// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PublishInfo
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

namespace CocoStudio.Projects
{
  public class PublishInfo
  {
    public virtual string PublishDirectory { get; set; }

    public string SourceFilePath { get; set; }

    public string DestinationFilePath { get; set; }

    public PublishInfo()
    {
    }

    public PublishInfo(string publishDirectory)
    {
      this.PublishDirectory = publishDirectory;
    }
  }
}
