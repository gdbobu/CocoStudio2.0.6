using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Model.ExtensionModel
{
	[Extension(typeof(IGameProjectSerializer))]
	internal class FlatbufSerializer : IGameProjectSerializer
	{
		private const string displayName = "Flat Buffers";

		public string ID
		{
			get
			{
				return "Serializer_FlatBuffers";
			}
		}

		public string Label
		{
			get
			{
				return "Flat Buffers";
			}
		}

		public string Serialize(PublishInfo info, IProjectFile projFile)
		{
			FilePath filePath = info.DestinationFilePath;
			string sourceFilePath = info.SourceFilePath;
			string des = filePath.ChangeExtension(".csb");
			string res = Services.ProjectOperations.CurrentSelectedSolution.ItemDirectory;
			return CSCocosHelp.ConvertToBinByFlat(des, sourceFilePath, res);
		}
	}
}
