using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class SliderEditor : BaseEditor, ITypeEditor
	{
		private SliderEditorWidget widget;

		public SliderEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public SliderEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item)
		{
			this.widget = new SliderEditorWidget();
			if (this._propertyItem.ValueRangeDescriptor != null)
			{
				this.widget.SetValueSize(this._propertyItem.ValueRangeDescriptor.MinValue, this._propertyItem.ValueRangeDescriptor.MaxValue, (int)this._propertyItem.ValueRangeDescriptor.Step);
			}
			this.SetControl();
			this.widget.ValueChanged += new EventHandler<PointEvent>(this.widget_ValueChanged);
			return this.widget;
		}

		private void widget_ValueChanged(object sender, PointEvent e)
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

		private void SetControl()
		{
			int data = (int)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (base.IsWhip<int>(null, ""))
			{
				data = 255;
			}
			this.widget.SetValue(delegate
			{
				this.widget.SetControl(data);
			});
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
