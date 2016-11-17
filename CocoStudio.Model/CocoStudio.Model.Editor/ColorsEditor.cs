using CocoStudio.ToolKit;
using Gtk;
using Gtk.Controls;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.Editor
{
	public class ColorsEditor : BaseEditor, ITypeEditor
	{
		private ColorEx widget;

		public ColorsEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ColorsEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new ColorEx();
			object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (value != null)
			{
				Color color = (Color)value;
				bool flag = 0 == 0;
				this.widget.Color = color;
			}
			this.widget.ColorChanged += new EventHandler<ColorExEvent>(this.widget_ColorChanged);
			return this.widget;
		}

		private void widget_ColorChanged(object sender, ColorExEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue(this._propertyItem.Instance, this.widget.Color, null);
			});
		}

		private void SetControl()
		{
			object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (value != null)
			{
				Color color = (Color)value;
				bool flag = 0 == 0;
				this.widget.Color = color;
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

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}
	}
}
