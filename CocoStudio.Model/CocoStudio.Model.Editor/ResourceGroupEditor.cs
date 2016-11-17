using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class ResourceGroupEditor : BaseEditor, ITypeEditor
	{
		private Table widget = null;

		private List<ImageEventBox> imageEventBoxList;

		public ResourceGroupEditor() : base(null)
		{
		}

		public ResourceGroupEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new Table(1u, 1u, false);
			this.imageEventBoxList = new List<ImageEventBox>();
			List<string> list = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null) as List<string>;
			if (list != null)
			{
				uint num = 0u;
				Table table = new Table(2u, (uint)list.Count, false);
				table.ColumnSpacing = 6u;
				foreach (string current in list)
				{
					Label label = new Label();
					PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty(current);
					PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this._propertyItem.Instance.GetType()).Find(current, false);
					label.Text = LanguageOption.GetValueBykey(propertyDescriptor.DisplayName);
					Color color = new Color(165, 168, 176);
					label.ModifyFg(StateType.Normal, color);
					label.SetFontSize(10.0);
					table.Attach(label, num, num + 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
					ImageEventBox imageEventBox = new ImageEventBox(this._propertyItem, propertyDescriptor);
					table.Attach(imageEventBox, num, num + 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
					num += 1u;
					this.imageEventBoxList.Add(imageEventBox);
				}
				this.widget.Attach(table, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			}
			this.widget.ShowAll();
			return this.widget;
		}

		public void EditorDispose()
		{
			this.imageEventBoxList.ForEach(delegate(ImageEventBox w)
			{
				w.ImageDispose();
			});
			base.Dispose();
		}

		public void RefreshData()
		{
			this.imageEventBoxList.ForEach(delegate(ImageEventBox w)
			{
				w.Refresh();
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}
	}
}
