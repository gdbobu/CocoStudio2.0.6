// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectBinding
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using System;

namespace CocoStudio.Projects
{
  public abstract class ProjectBinding : IProjectBinding
  {
    public Project CreateProject(ProjectCreateInformation info)
    {
      try
      {
        return this.OnCreateProject(info);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Create project failed.", ex);
        return (Project) null;
      }
    }

    protected virtual Project OnCreateProject(ProjectCreateInformation info)
    {
      throw new NotImplementedException();
    }

    public bool CanCreateProject(string projectType)
    {
      return this.OnCanCreateProject(projectType);
    }

    protected virtual bool OnCanCreateProject(string projectType)
    {
      throw new NotImplementedException();
    }
  }
}
