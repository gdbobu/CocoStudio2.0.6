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
			GameProjectFile result;
			if (project != null)
			{
				result = (project.ProjectItem as GameProjectFile);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static GameProjectContent GetProjectContent(this Project project)
		{
			GameProjectFile projectFile = project.GetProjectFile();
			GameProjectContent result;
			if (projectFile != null)
			{
				result = (projectFile.Content as GameProjectContent);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static NodeObjectData GetRootNodeData(this Project project)
		{
			return project.GetProjectContent().Content.ObjectData;
		}

		public static NodeObject GetRootNode(this Project project)
		{
			GameProjectContent projectContent = project.GetProjectContent();
			NodeObject result;
			if (projectContent != null)
			{
				result = (projectContent.RootVisualObject as NodeObject);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static TimelineAction GetCurrentTimelineAction(this Project project)
		{
			GameProjectContent projectContent = project.GetProjectContent();
			TimelineAction result;
			if (projectContent != null)
			{
				result = projectContent.TimelineAction;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static bool IsGameProject(this Project project)
		{
			return project.GetProjectFile() != null;
		}

		public static string GetProjectType(this Project project)
		{
			GameProjectFile projectFile = project.GetProjectFile();
			string result;
			if (projectFile != null)
			{
				result = projectFile.ProjectType;
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public static int GetTypeIndex(this Project project, Type objectType)
		{
			GameProjectContent projectContent = project.GetProjectContent();
			int result;
			if (projectContent != null)
			{
				if (projectContent.TypeIndex.ContainsKey(objectType))
				{
					Dictionary<Type, int> typeIndex;
					(typeIndex = projectContent.TypeIndex)[objectType] = typeIndex[objectType] + 1;
				}
				else
				{
					projectContent.TypeIndex.Add(objectType, 1);
				}
				result = projectContent.TypeIndex[objectType];
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
