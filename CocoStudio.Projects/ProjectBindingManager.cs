// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectBindingManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using Mono.Addins;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  internal class ProjectBindingManager
  {
    public List<IProjectBinding> ProjectBindings { get; protected set; }

    public ProjectBindingManager()
    {
      this.ProjectBindings = new List<IProjectBinding>();
      this.CreateBindingList();
    }

    private void CreateBindingList()
    {
      try
      {
        this.ProjectBindings.AddRange((IEnumerable<IProjectBinding>) AddinManager.GetExtensionObjects<IProjectBinding>());
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Create project binding list failed.", ex);
      }
    }
  }
}
