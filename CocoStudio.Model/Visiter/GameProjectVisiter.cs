// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Visiter.GameProjectVisiter
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.DataModel;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.Visiter
{
  public static class GameProjectVisiter
  {
    public static GameProjectFile GetProjectFile(this Project project)
    {
      if (project != null)
        return project.ProjectItem as GameProjectFile;
      return (GameProjectFile) null;
    }

    public static GameProjectContent GetProjectContent(this Project project)
    {
      GameProjectFile projectFile = project.GetProjectFile();
      if (projectFile != null)
        return projectFile.Content as GameProjectContent;
      return (GameProjectContent) null;
    }

    public static NodeObjectData GetRootNodeData(this Project project)
    {
      return project.GetProjectContent().Content.ObjectData;
    }

    public static NodeObject GetRootNode(this Project project)
    {
      GameProjectContent projectContent = project.GetProjectContent();
      if (projectContent != null)
        return projectContent.RootVisualObject as NodeObject;
      return (NodeObject) null;
    }

    public static TimelineAction GetCurrentTimelineAction(this Project project)
    {
      GameProjectContent projectContent = project.GetProjectContent();
      if (projectContent != null)
        return projectContent.TimelineAction;
      return (TimelineAction) null;
    }

    public static bool IsGameProject(this Project project)
    {
      return project.GetProjectFile() != null;
    }

    public static string GetProjectType(this Project project)
    {
      GameProjectFile projectFile = project.GetProjectFile();
      if (projectFile != null)
        return projectFile.ProjectType;
      return string.Empty;
    }

    public static int GetTypeIndex(this Project project, Type objectType)
    {
      GameProjectContent projectContent = project.GetProjectContent();
      if (projectContent == null)
        return 0;
      if (projectContent.TypeIndex.ContainsKey(objectType))
      {
        Dictionary<Type, int> typeIndex;
        Type index;
        (typeIndex = projectContent.TypeIndex)[index = objectType] = typeIndex[index] + 1;
      }
      else
        projectContent.TypeIndex.Add(objectType, 1);
      return projectContent.TypeIndex[objectType];
    }
  }
}
