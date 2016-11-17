using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class SizePrecentEditor : BaseEditor, ITypeEditor
	{
		public SizePrecentEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public SizePrecentEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			return null;
		}

		private void SetControl()
		{
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
