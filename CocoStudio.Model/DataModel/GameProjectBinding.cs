// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameProjectBinding
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using Mono.Addins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Model.DataModel
{
  [Extension(typeof (IProjectBinding))]
  internal class GameProjectBinding : ProjectBinding
  {
    protected override Project OnCreateProject(ProjectCreateInformation info)
    {
      GameProjectFile gameProjectFile = new GameProjectFile(info);
      gameProjectFile.Content = this.CreateProjectContent(info);
      return new Project(info.FileName, (ProjectItem) gameProjectFile);
    }

    protected virtual IProjectContent CreateProjectContent(ProjectCreateInformation info)
    {
      NodeType result;
      if (!Enum.TryParse<NodeType>(info.ContentType, out result))
        throw new InvalidOperationException("Unsupport content type" + info.ContentType);
      GameProjectContent gameProjectContent = new GameProjectContent(result);
      gameProjectContent.Content.ObjectData.Size = new PointF(info.Width, info.Height);
      return (IProjectContent) gameProjectContent;
    }

    protected override bool OnCanCreateProject(string projectType)
    {
      return ((IEnumerable<string>) this.GetProjectType()).Any<string>((Func<string, bool>) (a => a.Equals(projectType)));
    }

    private string[] GetProjectType()
    {
      return Enum.GetNames(typeof (NodeType));
    }
  }
}
