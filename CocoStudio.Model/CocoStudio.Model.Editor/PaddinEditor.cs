using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class PaddinEditor : BaseEditor, ITypeEditor
	{
		private NumberEditorWidget widget;

		public PaddinEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PaddinEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem = null)
		{
			this.widget = new NumberEditorWidget(false, true, 30);
			this.widget.SetMaxMin(200, 0);
			this.widget.SetEntryPRoperty(false, 2, 1.0);
			this.widget.SetMaxMin(200, 0);
			this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
			this.SetControl();
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
			return this.widget;
		}

		private void SetControl()
		{
			this.widget.SetValue(delegate
			{
				object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				this.widget.X.SetPositionValue(Convert.ToDouble(value));
			});
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
