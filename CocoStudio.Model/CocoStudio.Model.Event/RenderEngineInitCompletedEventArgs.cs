using CocoStudio.Model.ViewModel;
using System;

namespace CocoStudio.Model.Event
{
	public class RenderEngineInitCompletedEventArgs
	{
		public GameWindow GameWindow
		{
			get;
			private set;
		}

		public RenderEngineInitCompletedEventArgs(GameWindow gameWindow)
		{
			this.GameWindow = gameWindow;
		}
	}
}
