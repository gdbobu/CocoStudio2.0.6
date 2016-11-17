using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class FilpEditor : BaseEditor, ITypeEditor
	{
		private FilpEditorWidget widget;

		public FilpEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public FilpEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item)
		{
			this.widget = new FilpEditorWidget();
			this.SetControl();
			this.widget.BtnVClick += new EventHandler<BtnEvent>(this.widget_BtnVClick);
			this.widget.BtnSClick += new EventHandler<BtnEvent>(this.widget_BtnSClick);
			return this.widget;
		}

		private void widget_BtnSClick(object sender, BtnEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue("FlipX", e.IsCheck, null);
			});
		}

		private void widget_BtnVClick(object sender, BtnEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue("FlipY", e.IsCheck, null);
			});
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
			bool s = (bool)this._propertyItem.Instance.GetType().GetProperty("FlipX").GetValue(this._propertyItem.Instance, null);
			bool v = (bool)this._propertyItem.Instance.GetType().GetProperty("FlipY").GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				if (base.IsWhip<bool>(null, "FlipX"))
				{
					s = false;
				}
				if (base.IsWhip<bool>(null, "FlipY"))
				{
					v = false;
				}
			}
			this.widget.SetControl(v, s);
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
