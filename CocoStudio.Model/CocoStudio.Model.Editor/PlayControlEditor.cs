using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class PlayControlEditor : BaseEditor, ITypeEditor
	{
		private PlayControlWidget widget;

		private IPlayControl proxyCom;

		public PlayControlEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PlayControlEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.proxyCom = (this._propertyItem.Instance as IPlayControl);
			this.widget = new PlayControlWidget();
			this.widget.Play += new EventHandler(this.widget_Play);
			this.widget.Stop += new EventHandler(this.widget_Stop);
			this.ControlView(this.proxyCom.HasData());
			return this.widget;
		}

		private void widget_Stop(object sender, EventArgs e)
		{
			if (this.proxyCom != null)
			{
				this.proxyCom.Stop();
			}
		}

		private void widget_Play(object sender, EventArgs e)
		{
			if (this.proxyCom != null)
			{
				this.proxyCom.Start();
			}
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "FileData" && this.proxyCom != null)
			{
				this.ControlView(this.proxyCom.HasData());
			}
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
		}

		private void ControlView(bool canedit = true)
		{
			this.widget.PlayButton.Sensitive = canedit;
			this.widget.StopButton.Sensitive = canedit;
		}
	}
}
