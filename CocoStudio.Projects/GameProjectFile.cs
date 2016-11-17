// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.GameProjectFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;

namespace CocoStudio.Projects
{
  public class GameProjectFile : ProjectFile
  {
    public const string BinaryFileExtension = ".csb";
    public const string JsonFileExtension = ".json";

    protected GameProjectFile()
    {
    }

    public GameProjectFile(FilePath file)
      : base(file)
    {
      this.ProjectType = "GameProject";
    }

    public GameProjectFile(ProjectCreateInformation info)
      : base(info)
    {
      this.ProjectType = info.ContentType;
    }
  }
}
