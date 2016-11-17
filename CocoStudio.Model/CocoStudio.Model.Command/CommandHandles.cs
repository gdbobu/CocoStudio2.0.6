using CocoStudio.Core.Commands;
using CocoStudio.Core.ExtensionModel;
using CocoStudio.Model.ViewModel;
using Mono.Addins;
using System;

namespace CocoStudio.Model.Command
{
	[Extension(Type = typeof(ICommandHandle))]
	internal class CommandHandles : ICommandHandle
	{
		public void Initialize()
		{
			GlobalCommand.PlayCmd.Execute += new EventHandler<CommandRunArgs>(CommandHandles.PlayCmd_Execute);
		}

		private static void PlayCmd_Execute(object sender, CommandRunArgs e)
		{
			TimelineActionManager.Instance.Play(!TimelineActionManager.Instance.IsPlaying);
		}
	}
}
