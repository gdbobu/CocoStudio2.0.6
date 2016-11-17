using CocoStudio.Core;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
	[Extension(typeof(IProjectContent)), JsonObject(MemberSerialization.OptIn)]
	public class GameProjectContent : ProjectContent
	{
		private bool isLoaded;

		public Dictionary<Type, int> TypeIndex
		{
			get;
			private set;
		}

		public VisualObject RootVisualObject
		{
			get;
			private set;
		}

		public TimelineAction TimelineAction
		{
			get;
			private set;
		}

		[ItemProperty, JsonProperty]
		public GameProjectData Content
		{
			get;
			set;
		}

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
			if (!this.isLoaded)
			{
				GameProjectLoadResult gameProjectLoadResult = GameProjectLoader.LoadProject(this.Content);
				gameProjectLoadResult.RootObject.IconVisible = false;
				gameProjectLoadResult.RootObject.IsSelected = false;
				gameProjectLoadResult.RootObject.Alpha = 255;
				gameProjectLoadResult.RootObject.CColor = Color.FromArgb(255, 255, 255, 255);
				this.RootVisualObject = gameProjectLoadResult.RootObject;
				this.TimelineAction = gameProjectLoadResult.TimelineAction;
				this.TimelineAction.InitWithRootNode(this.RootVisualObject as NodeObject);
				this.TypeIndex = gameProjectLoadResult.TypeIndex;
				this.isLoaded = true;
			}
		}

		public override void Save(IProgressMonitor monitor)
		{
			if (this.isLoaded)
			{
				this.Content = GameProjectLoader.SaveProject(this.RootVisualObject as NodeObject, this.TimelineAction);
			}
		}

		public override void Initialize(IProgressMonitor monitor)
		{
		}

		public override void UnLoad(IProgressMonitor monitor)
		{
			this.isLoaded = false;
			this.RootVisualObject = null;
			this.TimelineAction = null;
			this.TypeIndex.Clear();
		}

		public override void Publish(IProgressMonitor monitor, PublishInfo info)
		{
			string text = string.Empty;
			if (Services.ProjectOperations.CurrentSelectedSolution != null)
			{
				text = Services.ProjectsService.SerializeGameProject(info, base.ProjectFile);
			}
			if (!string.IsNullOrEmpty(text))
			{
				monitor.ReportError(text, null);
			}
		}

		public override void ReloadReferencedProject(IProgressMonitor monitor)
		{
			this.FindProjectNodeToReload(this.RootVisualObject as NodeObject);
		}

		public override bool HasReferencedProject(Project project)
		{
			bool result;
			if (this.IsLoaded)
			{
				result = GameProjectContent.CheckReferenceProjectInObject(this.RootVisualObject as NodeObject, project);
			}
			else if (this.Content == null || this.Content.ObjectData == null)
			{
				result = false;
			}
			else
			{
				ResourceData resourceData = project.GetResourceData();
				result = GameProjectContent.CheckReferenceProjectInObjectData(this.Content.ObjectData, project, resourceData);
			}
			return result;
		}

		private static bool CheckReferenceProjectInObject(NodeObject parentNode, Project project)
		{
			bool result;
			if (parentNode == null)
			{
				result = false;
			}
			else
			{
				ProjectNodeObject projectNodeObject = parentNode as ProjectNodeObject;
				if (projectNodeObject != null)
				{
					ResourceFile fileData = projectNodeObject.FileData;
					if (fileData == project)
					{
						result = true;
						return result;
					}
					if (projectNodeObject.Project != null)
					{
						bool flag = projectNodeObject.Project.HasReferencedProject(project);
						if (flag)
						{
							result = true;
							return result;
						}
					}
				}
				if (parentNode.Children != null)
				{
					foreach (NodeObject current in parentNode.Children)
					{
						bool flag2 = GameProjectContent.CheckReferenceProjectInObject(current, project);
						if (flag2)
						{
							result = true;
							return result;
						}
					}
				}
				result = false;
			}
			return result;
		}

		private static bool CheckReferenceProjectInObjectData(NodeObjectData parentNode, Project project, ResourceData projectPath)
		{
			bool result;
			if (parentNode == null)
			{
				result = false;
			}
			else
			{
				ProjectNodeObjectData projectNodeObjectData = parentNode as ProjectNodeObjectData;
				if (projectNodeObjectData != null)
				{
					ResourceItemData fileData = projectNodeObjectData.FileData;
					if (projectPath.Equals(fileData))
					{
						result = true;
						return result;
					}
					if (fileData != null)
					{
						Project project2 = Services.ProjectsService.CurrentResourceGroup.FindResourceItem(fileData) as Project;
						if (project2 != null)
						{
							bool flag = project2.HasReferencedProject(project);
							if (flag)
							{
								result = true;
								return result;
							}
						}
					}
				}
				if (parentNode.Children != null)
				{
					foreach (NodeObjectData current in parentNode.Children)
					{
						bool flag2 = GameProjectContent.CheckReferenceProjectInObjectData(current, project, projectPath);
						if (flag2)
						{
							result = true;
							return result;
						}
					}
				}
				result = false;
			}
			return result;
		}

		private void FindProjectNodeToReload(NodeObject parentNode)
		{
			if (parentNode != null)
			{
				if (parentNode is ProjectNodeObject)
				{
					((ProjectNodeObject)parentNode).ReloadProject();
				}
				if (parentNode.Children != null)
				{
					foreach (NodeObject current in parentNode.Children)
					{
						this.FindProjectNodeToReload(current);
					}
				}
			}
		}

		public override HashSet<ResourceData> GetUsedResources(IProgressMonitor monitor)
		{
			return GameProjectContent.SearchResourceItemData(this.Content);
		}

		private static HashSet<ResourceData> SearchResourceItemData(GameProjectData projectData)
		{
			HashSet<ResourceData> hashSet = new HashSet<ResourceData>();
			HashSet<ResourceData> hashSet2 = GameProjectContent.ScanObjectData(projectData.ObjectData);
			if (hashSet2 != null)
			{
				hashSet.UnionWith(hashSet2);
			}
			hashSet2 = GameProjectContent.ScanAnimationData(projectData.Animation);
			if (hashSet2 != null)
			{
				hashSet.UnionWith(hashSet2);
			}
			return hashSet;
		}

		private static HashSet<ResourceData> ScanObjectData(NodeObjectData parentNodeData)
		{
			PropertyAccessorHandler[] resourceProperties = parentNodeData.GetResourceProperties();
			HashSet<ResourceData> hashSet = new HashSet<ResourceData>();
			if (resourceProperties != null)
			{
				PropertyAccessorHandler[] array = resourceProperties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyAccessorHandler propertyAccessorHandler = array[i];
					ResourceItemData resourceItemData = propertyAccessorHandler.GetValue(parentNodeData, null) as ResourceItemData;
					if (resourceItemData != null)
					{
						hashSet.Add(resourceItemData);
					}
				}
			}
			if (parentNodeData.Children != null)
			{
				foreach (NodeObjectData current in parentNodeData.Children)
				{
					hashSet.UnionWith(GameProjectContent.ScanObjectData(current));
				}
			}
			return hashSet;
		}

		private static HashSet<ResourceData> ScanAnimationData(TimelineActionData timelineActionData)
		{
			HashSet<ResourceData> result;
			if (timelineActionData == null)
			{
				result = null;
			}
			else
			{
				HashSet<ResourceData> hashSet = new HashSet<ResourceData>();
				foreach (TimelineData current in timelineActionData.Timelines)
				{
					if (current.FrameType == typeof(TextureFrame).Name)
					{
						using (List<FrameData>.Enumerator enumerator2 = current.Frames.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								TextureFrameData textureFrameData = (TextureFrameData)enumerator2.Current;
								hashSet.Add(textureFrameData.TextureFile);
							}
						}
					}
				}
				result = hashSet;
			}
			return result;
		}

		public override bool UpdateUsedResources(IProgressMonitor monitor, ChangedResourceCollection changedResourceCollection)
		{
			bool flag = GameProjectContent.UpdateResourcesInObjectData(this.Content.ObjectData, changedResourceCollection);
			bool flag2 = GameProjectContent.UpdateResourcesInAnimationData(this.Content.Animation, changedResourceCollection);
			return flag || flag2;
		}

		private static bool UpdateResourcesInObjectData(NodeObjectData parentNodeData, ChangedResourceCollection changedResourceCollection)
		{
			PropertyAccessorHandler[] resourceProperties = parentNodeData.GetResourceProperties();
			bool result;
			if (resourceProperties == null)
			{
				result = false;
			}
			else
			{
				bool flag = false;
				PropertyAccessorHandler[] array = resourceProperties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyAccessorHandler propertyAccessorHandler = array[i];
					ResourceItemData resourceItemData = propertyAccessorHandler.GetValue(parentNodeData, null) as ResourceItemData;
					if (!(resourceItemData == null))
					{
						ResourceFile resourceFile = null;
						if (changedResourceCollection.TryGetValue(resourceItemData, out resourceFile))
						{
							if (resourceFile != null)
							{
								resourceItemData.Update(resourceFile.GetResourceData());
							}
							else
							{
								propertyAccessorHandler.SetValue(parentNodeData, null, null);
							}
							if (!flag)
							{
								flag = true;
							}
						}
					}
				}
				if (parentNodeData.Children != null)
				{
					foreach (NodeObjectData current in parentNodeData.Children)
					{
						bool flag2 = GameProjectContent.UpdateResourcesInObjectData(current, changedResourceCollection);
						if (!flag && flag2)
						{
							flag = flag2;
						}
					}
				}
				result = flag;
			}
			return result;
		}

		private static bool UpdateResourcesInAnimationData(TimelineActionData timelineActionData, ChangedResourceCollection changedResourceCollection)
		{
			bool flag = false;
			foreach (TimelineData current in timelineActionData.Timelines)
			{
				if (!(current.FrameType != typeof(TextureFrame).Name))
				{
					using (List<FrameData>.Enumerator enumerator2 = current.Frames.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							TextureFrameData textureFrameData = (TextureFrameData)enumerator2.Current;
							ResourceItemData textureFile = textureFrameData.TextureFile;
							if (!(textureFile == null))
							{
								ResourceFile resourceFile = null;
								if (changedResourceCollection.TryGetValue(textureFile, out resourceFile))
								{
									if (resourceFile != null)
									{
										textureFile.Update(resourceFile.GetResourceData());
									}
									else
									{
										textureFrameData.TextureFile = null;
									}
									if (!flag)
									{
										flag = true;
									}
								}
							}
						}
					}
				}
			}
			return flag;
		}
	}
}
