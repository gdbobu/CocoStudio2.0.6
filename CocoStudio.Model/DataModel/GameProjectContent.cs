// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameProjectContent
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
  [Extension(typeof (IProjectContent))]
  [JsonObject(MemberSerialization.OptIn)]
  public class GameProjectContent : ProjectContent
  {
    private bool isLoaded;

    public Dictionary<Type, int> TypeIndex { get; private set; }

    public VisualObject RootVisualObject { get; private set; }

    public TimelineAction TimelineAction { get; private set; }

    [ItemProperty]
    [JsonProperty]
    public GameProjectData Content { get; set; }

    public override bool IsLoaded
    {
      get
      {
        return this.isLoaded;
      }
    }

    public GameProjectContent()
    {
      this.TypeIndex = new Dictionary<Type, int>();
      this.Content = new GameProjectData();
    }

    public GameProjectContent(NodeType type)
    {
      this.TypeIndex = new Dictionary<Type, int>();
      this.Content = new GameProjectData(type);
    }

    public override void Load(IProgressMonitor monitor)
    {
      if (this.isLoaded)
        return;
      GameProjectLoadResult projectLoadResult = GameProjectLoader.LoadProject(this.Content);
      projectLoadResult.RootObject.IconVisible = false;
      projectLoadResult.RootObject.IsSelected = false;
      projectLoadResult.RootObject.Alpha = (int) byte.MaxValue;
      projectLoadResult.RootObject.CColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.RootVisualObject = (VisualObject) projectLoadResult.RootObject;
      this.TimelineAction = projectLoadResult.TimelineAction;
      this.TimelineAction.InitWithRootNode(this.RootVisualObject as NodeObject);
      this.TypeIndex = projectLoadResult.TypeIndex;
      this.isLoaded = true;
    }

    public override void Save(IProgressMonitor monitor)
    {
      if (!this.isLoaded)
        return;
      this.Content = GameProjectLoader.SaveProject(this.RootVisualObject as NodeObject, this.TimelineAction);
    }

    public override void Initialize(IProgressMonitor monitor)
    {
    }

    public override void UnLoad(IProgressMonitor monitor)
    {
      this.isLoaded = false;
      this.RootVisualObject = (VisualObject) null;
      this.TimelineAction = (TimelineAction) null;
      this.TypeIndex.Clear();
    }

    public override void Publish(IProgressMonitor monitor, PublishInfo info)
    {
      string message = string.Empty;
      if (Services.ProjectOperations.CurrentSelectedSolution != null)
        message = Services.ProjectsService.SerializeGameProject(info, this.ProjectFile);
      if (string.IsNullOrEmpty(message))
        return;
      monitor.ReportError(message, (Exception) null);
    }

    public override void ReloadReferencedProject(IProgressMonitor monitor)
    {
      this.FindProjectNodeToReload(this.RootVisualObject as NodeObject);
    }

    public override bool HasReferencedProject(Project project)
    {
      if (this.IsLoaded)
        return GameProjectContent.CheckReferenceProjectInObject(this.RootVisualObject as NodeObject, project);
      if (this.Content == null || this.Content.ObjectData == null)
        return false;
      ResourceData resourceData = project.GetResourceData();
      return GameProjectContent.CheckReferenceProjectInObjectData(this.Content.ObjectData, project, resourceData);
    }

    private static bool CheckReferenceProjectInObject(NodeObject parentNode, Project project)
    {
      if (parentNode == null)
        return false;
      ProjectNodeObject projectNodeObject = parentNode as ProjectNodeObject;
      if (projectNodeObject != null && (projectNodeObject.FileData == project || projectNodeObject.Project != null && projectNodeObject.Project.HasReferencedProject(project)))
        return true;
      if (parentNode.Children != null)
      {
        foreach (NodeObject child in (Collection<NodeObject>) parentNode.Children)
        {
          if (GameProjectContent.CheckReferenceProjectInObject(child, project))
            return true;
        }
      }
      return false;
    }

    private static bool CheckReferenceProjectInObjectData(NodeObjectData parentNode, Project project, ResourceData projectPath)
    {
      if (parentNode == null)
        return false;
      ProjectNodeObjectData projectNodeObjectData = parentNode as ProjectNodeObjectData;
      if (projectNodeObjectData != null)
      {
        ResourceItemData fileData = projectNodeObjectData.FileData;
        if (projectPath.Equals((ResourceData) fileData))
          return true;
        if ((ResourceData) fileData != (ResourceData) null)
        {
          Project resourceItem = Services.ProjectsService.CurrentResourceGroup.FindResourceItem((ResourceData) fileData) as Project;
          if (resourceItem != null && resourceItem.HasReferencedProject(project))
            return true;
        }
      }
      if (parentNode.Children != null)
      {
        foreach (NodeObjectData child in parentNode.Children)
        {
          if (GameProjectContent.CheckReferenceProjectInObjectData(child, project, projectPath))
            return true;
        }
      }
      return false;
    }

    private void FindProjectNodeToReload(NodeObject parentNode)
    {
      if (parentNode == null)
        return;
      if (parentNode is ProjectNodeObject)
        ((ProjectNodeObject) parentNode).ReloadProject();
      if (parentNode.Children == null)
        return;
      foreach (NodeObject child in (Collection<NodeObject>) parentNode.Children)
        this.FindProjectNodeToReload(child);
    }

    public override HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor)
    {
      return GameProjectContent.SearchResourceItemData(this.Content);
    }

    private static HashSet<ResourceData> SearchResourceItemData(GameProjectData projectData)
    {
      HashSet<ResourceData> resourceDataSet1 = new HashSet<ResourceData>();
      HashSet<ResourceData> resourceDataSet2 = GameProjectContent.ScanObjectData(projectData.ObjectData);
      if (resourceDataSet2 != null)
        resourceDataSet1.UnionWith((IEnumerable<ResourceData>) resourceDataSet2);
      HashSet<ResourceData> resourceDataSet3 = GameProjectContent.ScanAnimationData(projectData.Animation);
      if (resourceDataSet3 != null)
        resourceDataSet1.UnionWith((IEnumerable<ResourceData>) resourceDataSet3);
      return resourceDataSet1;
    }

    private static HashSet<ResourceData> ScanObjectData(NodeObjectData parentNodeData)
    {
      PropertyAccessorHandler[] resourceProperties = parentNodeData.GetResourceProperties();
      HashSet<ResourceData> resourceDataSet = new HashSet<ResourceData>();
      if (resourceProperties != null)
      {
        foreach (PropertyAccessorHandler propertyAccessorHandler in resourceProperties)
        {
          ResourceItemData resourceItemData = propertyAccessorHandler.GetValue((object) parentNodeData, (object[]) null) as ResourceItemData;
          if ((ResourceData) resourceItemData != (ResourceData) null)
            resourceDataSet.Add((ResourceData) resourceItemData);
        }
      }
      if (parentNodeData.Children != null)
      {
        foreach (NodeObjectData child in parentNodeData.Children)
          resourceDataSet.UnionWith((IEnumerable<ResourceData>) GameProjectContent.ScanObjectData(child));
      }
      return resourceDataSet;
    }

    private static HashSet<ResourceData> ScanAnimationData(TimelineActionData timelineActionData)
    {
      if (timelineActionData == null)
        return (HashSet<ResourceData>) null;
      HashSet<ResourceData> resourceDataSet = new HashSet<ResourceData>();
      foreach (TimelineData timeline in timelineActionData.Timelines)
      {
        if (timeline.FrameType == typeof (TextureFrame).Name)
        {
          foreach (TextureFrameData frame in timeline.Frames)
            resourceDataSet.Add((ResourceData) frame.TextureFile);
        }
      }
      return resourceDataSet;
    }

    public override bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourceCollection)
    {
      return GameProjectContent.UpdateResourcesInObjectData(this.Content.ObjectData, changedResourceCollection) || GameProjectContent.UpdateResourcesInAnimationData(this.Content.Animation, changedResourceCollection);
    }

    private static bool UpdateResourcesInObjectData(NodeObjectData parentNodeData, ChangedResourceCollection changedResourceCollection)
    {
      PropertyAccessorHandler[] resourceProperties = parentNodeData.GetResourceProperties();
      if (resourceProperties == null)
        return false;
      bool flag1 = false;
      foreach (PropertyAccessorHandler propertyAccessorHandler in resourceProperties)
      {
        ResourceItemData resourceItemData = propertyAccessorHandler.GetValue((object) parentNodeData, (object[]) null) as ResourceItemData;
        if (!((ResourceData) resourceItemData == (ResourceData) null))
        {
          ResourceFile resourceFile = (ResourceFile) null;
          if (changedResourceCollection.TryGetValue((ResourceData) resourceItemData, out resourceFile))
          {
            if (resourceFile != null)
              resourceItemData.Update(resourceFile.GetResourceData());
            else
              propertyAccessorHandler.SetValue((object) parentNodeData, (object) null, (object[]) null);
            if (!flag1)
              flag1 = true;
          }
        }
      }
      if (parentNodeData.Children != null)
      {
        foreach (NodeObjectData child in parentNodeData.Children)
        {
          bool flag2 = GameProjectContent.UpdateResourcesInObjectData(child, changedResourceCollection);
          if (!flag1 && flag2)
            flag1 = flag2;
        }
      }
      return flag1;
    }

    private static bool UpdateResourcesInAnimationData(TimelineActionData timelineActionData, ChangedResourceCollection changedResourceCollection)
    {
      bool flag = false;
      foreach (TimelineData timeline in timelineActionData.Timelines)
      {
        if (!(timeline.FrameType != typeof (TextureFrame).Name))
        {
          foreach (TextureFrameData frame in timeline.Frames)
          {
            ResourceItemData textureFile = frame.TextureFile;
            if (!((ResourceData) textureFile == (ResourceData) null))
            {
              ResourceFile resourceFile = (ResourceFile) null;
              if (changedResourceCollection.TryGetValue((ResourceData) textureFile, out resourceFile))
              {
                if (resourceFile != null)
                  textureFile.Update(resourceFile.GetResourceData());
                else
                  frame.TextureFile = (ResourceItemData) null;
                if (!flag)
                  flag = true;
              }
            }
          }
        }
      }
      return flag;
    }
  }
}
