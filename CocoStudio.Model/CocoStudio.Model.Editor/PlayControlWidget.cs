using Gtk;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.Model.Editor
{
	public class PlayControlWidget : EventBox
	{
		private Table ContentTable;

		public event EventHandler Play;

		public event EventHandler Stop;

		public Button PlayButton
		{
			get;
			private set;
		}

		public Button StopButton
		{
			get;
			private set;
		}

		public PlayControlWidget()
		{
			this.ContentTable = new Table(1u, 2u, false);
			this.PlayButton = new Button();
			this.PlayButton.WidthRequest = 40;
			this.PlayButton.HeightRequest = 25;
			this.PlayButton.Label = LanguageInfo.Command_Play;
			this.ContentTable.ColumnSpacing = 6u;
			this.StopButton = new Button();
			this.StopButton.WidthRequest = 40;
			this.StopButton.HeightRequest = 25;
			this.StopButton.Label = LanguageInfo.Command_Stop;
			this.ContentTable.Attach(this.PlayButton, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Expand, 0u, 0u);
			this.ContentTable.Attach(this.StopButton, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Expand, 0u, 0u);
			this.PlayButton.Show();
			this.StopButton.Show();
			base.Add(this.ContentTable);
			this.ContentTable.Show();
			this.PlayButton.Clicked += new EventHandler(this.play_Clicked);
			this.StopButton.Clicked += new EventHandler(this.stop_Clicked);
			base.ShowAll();
		}

		private void stop_Clicked(object sender, EventArgs e)
		{
			if (this.Stop != null)
			{
				this.Stop(this, null);
			}
		}

		private void play_Clicked(object sender, EventArgs e)
		{
			if (this.Play != null)
			{
				this.Play(this, null);
			}
		}
	}
}
