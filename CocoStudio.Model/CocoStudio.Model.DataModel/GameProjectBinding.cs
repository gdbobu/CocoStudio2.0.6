using CocoStudio.Projects;
using Mono.Addins;
using System;
using System.Linq;

namespace CocoStudio.Model.DataModel
{
	[Extension(typeof(IProjectBinding))]
	internal class GameProjectBinding : ProjectBinding
	{
		protected override Project OnCreateProject(ProjectCreateInformation info)
		{
			GameProjectFile gameProjectFile = new GameProjectFile(info);
			gameProjectFile.Content = this.CreateProjectContent(info);
			return new Project(info.FileName, gameProjectFile);
		}

		protected virtual IProjectContent CreateProjectContent(ProjectCreateInformation info)
		{
			NodeType type;
			if (!Enum.TryParse<NodeType>(info.ContentType, out type))
			{
				throw new InvalidOperationException("Unsupport content type" + info.ContentType);
			}
			return new GameProjectContent(type)
			{
				Content = 
				{
					ObjectData = 
					{
						Size = new PointF(info.Width, info.Height)
					}
				}
			};
		}

		protected override bool OnCanCreateProject(string projectType)
		{
			return this.GetProjectType().Any((string a) => a.Equals(projectType));
		}

		private string[] GetProjectType()
		{
			return Enum.GetNames(typeof(NodeType));
		}
	}
}
