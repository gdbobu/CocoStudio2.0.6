using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class PListEditor : BaseEditor, ITypeEditor
	{
		private Button widget;

		private Table table = new Table(1u, 1u, false);

		public PListEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PListEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem = null)
		{
			this.widget = new Button();
			this.widget.WidthRequest = 130;
			this.widget.Label = LanguageInfo.Command_ExportMergeImage;
			this.table.Attach(this.widget, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.ShowAll();
			this.widget.Clicked += new EventHandler(this.widget_Clicked);
			return this.table;
		}

		private void widget_Clicked(object sender, EventArgs e)
		{
			this._propertyItem.SetValue(this._propertyItem.Instance, "", null);
		}

		private void SetControl()
		{
		}

		private void widget_PointX(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue(this._propertyItem.Instance, (int)e.PointX, null);
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.SetControl();
		}
	}
}
