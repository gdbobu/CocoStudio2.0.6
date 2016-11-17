using CocoStudio.Core;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.Model.ViewModel
{
	public static class ProjectNest
	{
		public static string CheckNest(this Project project, Project primaryProject = null)
		{
			string result;
			if (NodeType.Scene.ToString() == project.GetProjectType())
			{
				string projectType = Services.ProjectOperations.CurrentSelectedProject.GetProjectType();
				string str = "";
				if (NodeType.Scene.ToString() == projectType)
				{
					str = LanguageInfo.NewFile_Scene;
				}
				else if (NodeType.Layer.ToString() == projectType)
				{
					str = LanguageInfo.NewFile_Layer;
				}
				else if (NodeType.Node.ToString() == projectType)
				{
					str = LanguageInfo.Display_Component_Entity;
				}
				result = str + LanguageInfo.MessageBox206_NestedSenceError;
			}
			else
			{
				if (primaryProject != null)
				{
					if (project.HasReferencedProject(primaryProject))
					{
						string text = string.Format(LanguageInfo.Output_ProjectRefLoop, project.FileName.FileName);
						result = text;
						return result;
					}
				}
				result = null;
			}
			return result;
		}
	}
}
