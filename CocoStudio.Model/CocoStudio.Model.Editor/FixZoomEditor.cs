using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;
using System.Timers;

namespace CocoStudio.Model.Editor
{
	public class FixZoomEditor : BaseEditor, ITypeEditor
	{
		private Timer timer;

		private Table table;

		private Table firTable;

		private Table secTable;

		private ToggleButton top;

		private ToggleButton bottom;

		private ToggleButton left;

		private ToggleButton right;

		private ToggleButton center;

		private FixZoom animation = new FixZoom();

		public FixZoomEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public FixZoomEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.table = new Table(1u, 2u, false);
			this.firTable = new Table(3u, 3u, false);
			this.secTable = new Table(1u, 1u, false);
			this.top = new ToggleButton("top");
			this.top.Name = "top";
			this.bottom = new ToggleButton("bottom");
			this.bottom.Name = "bottom";
			this.left = new ToggleButton("left");
			this.left.Name = "left";
			this.right = new ToggleButton("right");
			this.right.Name = "right";
			this.center = new ToggleButton("center");
			this.center.Name = "center";
			this.top.WidthRequest = (this.bottom.WidthRequest = (this.left.WidthRequest = (this.right.WidthRequest = (this.center.WidthRequest = 60))));
			this.top.HeightRequest = (this.bottom.HeightRequest = (this.left.HeightRequest = (this.right.HeightRequest = (this.center.HeightRequest = 30))));
			this.top.Clicked += new EventHandler(this.button_Clicked);
			this.bottom.Clicked += new EventHandler(this.button_Clicked);
			this.left.Clicked += new EventHandler(this.button_Clicked);
			this.right.Clicked += new EventHandler(this.button_Clicked);
			this.center.Clicked += new EventHandler(this.button_Clicked);
			this.firTable.Attach(this.top, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.firTable.Attach(this.bottom, 1u, 2u, 2u, 3u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.firTable.Attach(this.left, 0u, 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.firTable.Attach(this.right, 2u, 3u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.firTable.Attach(this.center, 1u, 2u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.firTable.ShowAll();
			this.animation.WidthRequest = 92;
			this.animation.HeightRequest = 52;
			this.secTable.Attach(this.animation, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.secTable.ShowAll();
			this.table.Attach(this.firTable, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.Attach(this.secTable, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.ShowAll();
			this.timer = new Timer();
			this.timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
			this.timer.Interval = 100.0;
			this.timer.Start();
			return this.table;
		}

		private void button_Clicked(object sender, EventArgs e)
		{
			ToggleButton toggleButton = sender as ToggleButton;
			string label = toggleButton.Label;
			if (label != null)
			{
				if (!(label == "top"))
				{
					if (!(label == "bottom"))
					{
						if (!(label == "left"))
						{
							if (!(label == "right"))
							{
								if (label == "center")
								{
									this.animation.IsCenter = toggleButton.Active;
								}
							}
							else
							{
								this.animation.IsRight = toggleButton.Active;
							}
						}
						else
						{
							this.animation.IsLeft = toggleButton.Active;
						}
					}
					else
					{
						this.animation.IsBottom = toggleButton.Active;
					}
				}
				else
				{
					this.animation.IsTop = toggleButton.Active;
				}
			}
		}

		private void SetControl()
		{
		}

		private void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.animation.QueueDraw();
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.SetControl();
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}
	}
}
