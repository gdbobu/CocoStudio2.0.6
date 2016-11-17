using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class EntryComBoxEditor : BaseEditor, ITypeEditor
	{
		private EntryComBoxEditorWidget widget;

		private SizeValue sizeValue;

		public EntryComBoxEditor() : base(null)
		{
		}

		public EntryComBoxEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new EntryComBoxEditorWidget();
			this.sizeValue = (SizeValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			this.SetControl();
			this.widget.Init();
			if (this._propertyItem.ValueRangeDescriptor != null)
			{
				this.widget.SetMaxMin(this._propertyItem.ValueRangeDescriptor.MaxValue, this._propertyItem.ValueRangeDescriptor.MinValue);
			}
			this.widget.ValueChanged += new EventHandler<EntryComboxEvent>(this.widget_ValueChanged);
			return this.widget;
		}

		private void widget_ValueChanged(object sender, EntryComboxEvent e)
		{
			this.UpDateData(delegate
			{
				this.sizeValue = (SizeValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				if (e.Type == 0)
				{
					this.sizeValue.Width = e.EntryValue;
				}
				else
				{
					this.sizeValue.Height = e.EntryValue;
				}
				this._propertyItem.SetValue(this._propertyItem.Instance, this.sizeValue, null);
			});
		}

		private void SetControl()
		{
			this.widget.SetValue(delegate
			{
				this.sizeValue = (SizeValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				this.widget.SetControl(this.sizeValue.Width, this.sizeValue.Height);
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

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}
	}
}
