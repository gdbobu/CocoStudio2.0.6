// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.FileOpenInfo
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using MonoDevelop.Core;

namespace CocoStudio.Core.View
{
  public class FileOpenInfo
  {
    public Project Project { get; set; }

    public IViewContentExtend NewContent { get; set; }

    public FilePath FileName { get; set; }

    public bool BringToFront { get; set; }

    public IViewDisplayBuilder DisplayBuilder { get; set; }

    public FileOpenInfo(FilePath file, Project project, bool bringToFront)
    {
      this.FileName = file;
      this.Project = project;
      this.BringToFront = bringToFront;
    }
  }
}
