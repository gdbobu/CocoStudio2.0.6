// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Events.ProjectCreatedEventArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Projects;
using System;

namespace CocoStudio.Core.Events
{
  public class ProjectCreatedEventArgs : EventArgs
  {
    public Project Project { get; private set; }

    public ProjectCreatedEventArgs(Project project)
    {
      this.Project = project;
    }
  }
}
