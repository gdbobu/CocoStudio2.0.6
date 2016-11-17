using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Model.ExtensionModel
{
	[Extension(typeof(IGameProjectSerializer))]
	internal class ProtobufSerializer : IGameProjectSerializer
	{
		private const string displayName = "Protocol Buffers";

		public string ID
		{
			get
			{
				return "Serializer_ProtocolBuffers";
			}
		}

		public string Label
		{
			get
			{
				return "Protocol Buffers";
			}
		}

		public string Serialize(PublishInfo info, IProjectFile projFile)
		{
			FilePath filePath = info.DestinationFilePath;
			string sourceFilePath = info.SourceFilePath;
			string des = filePath.ChangeExtension(".csb");
			string res = Services.ProjectOperations.CurrentSelectedSolution.ItemDirectory;
			return CSCocosHelp.ConvertToBinProto(des, sourceFilePath, res);
		}
	}
}
