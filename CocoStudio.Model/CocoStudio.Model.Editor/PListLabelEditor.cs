using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class PListLabelEditor : BaseEditor, ITypeEditor
	{
		private Label widget;

		private Table table = new Table(1u, 1u, false);

		public PListLabelEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PListLabelEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem = null)
		{
			this.widget = new Label();
			this.widget.WidthRequest = 150;
			this.table.BorderWidth = 5u;
			this.table.Attach(this.widget, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.ShowAll();
			this.SetControl();
			return this.table;
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}

		private void SetControl()
		{
			SizeValue sizeValue = (SizeValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			this.widget.Text = string.Format(" {0}{2} * {1}{2}", sizeValue.Width, sizeValue.Height, LanguageInfo.NewFile_Pixel);
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
