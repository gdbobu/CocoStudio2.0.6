using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class ResourceImageEditor : BaseEditor, ITypeEditor
	{
		private Table widget;

		private ImageEventBox imageEventBox;

		public ResourceImageEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ResourceImageEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item)
		{
			this.widget = new Table(2u, 1u, false);
			this.imageEventBox = new ImageEventBox(this._propertyItem, this._propertyItem.PropertyDescriptor);
			this.widget.Attach(this.imageEventBox, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.widget.ShowAll();
			Label label = new Label();
			Color color = new Color(165, 168, 176);
			label.ModifyFg(StateType.Normal, color);
			this.widget.RowSpacing = 6u;
			label.Text = LanguageOption.GetValueBykey(this._propertyItem.DiaplayName);
			label.SetFontSize(10.0);
			this.widget.Attach(label, 0u, 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			label.Show();
			return this.widget;
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				if (this.imageEventBox != null)
				{
					this.imageEventBox.Refresh();
				}
			}
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.imageEventBox.Refresh();
		}
	}
}
