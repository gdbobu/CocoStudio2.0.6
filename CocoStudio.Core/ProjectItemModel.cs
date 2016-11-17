// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ProjectItemModel
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System.IO;

namespace CocoStudio.Core
{
  public class ProjectItemModel
  {
    public string Name { get; private set; }

    public string LocalPath { get; private set; }

    public ProjectItemModel(string localPath)
    {
      this.LocalPath = localPath;
      this.Name = Path.GetFileNameWithoutExtension(localPath);
    }
  }
}
