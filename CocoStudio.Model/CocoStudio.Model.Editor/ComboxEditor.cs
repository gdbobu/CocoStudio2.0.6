using CocoStudio.ToolKit;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class ComboxEditor : BaseEditor, ITypeEditor
	{
		private ComBoxEx combox;

		public ComboxEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ComboxEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.combox = new ComBoxEx();
			this.SetControl();
			this.combox.Changed += new EventHandler(this.combox_Changed);
			return this.combox;
		}

		private void combox_Changed(object sender, EventArgs e)
		{
		}

		private void SetControl()
		{
			List<string> list = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null) as List<string>;
			ListStore listStore = new ListStore(new Type[]
			{
				typeof(string)
			});
			foreach (string current in list)
			{
				listStore.AppendValues(new object[]
				{
					current
				});
			}
			this.combox.Model = listStore;
			CellRendererText cell = new CellRendererText();
			this.combox.PackStart(cell, true);
			this.combox.AddAttribute(cell, "text", 0);
		}

		public void EditorDispose()
		{
		}

		public void RefreshData()
		{
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}
	}
}
