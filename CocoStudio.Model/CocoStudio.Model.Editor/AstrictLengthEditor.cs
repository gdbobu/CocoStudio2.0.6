using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class AstrictLengthEditor : BaseEditor, ITypeEditor
	{
		private AstrictLengthEditorWidget widget;

		private AstrictLengthValue asValue;

		public AstrictLengthEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public AstrictLengthEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new AstrictLengthEditorWidget();
			this.asValue = (AstrictLengthValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this.asValue != null)
			{
				this.widget.SetControl(this.asValue.MaxLengthEnable, (double)this.asValue.MaxLengthText);
			}
			this.widget.ValueCangede += new EventHandler<BoolEvent>(this.widget_ValueCangede);
			this.widget.IsCheckChanged += new EventHandler<BoolEvent>(this.widget_IsCheckChanged);
			return this.widget;
		}

		private void widget_IsCheckChanged(object sender, BoolEvent e)
		{
			this.UpDateData(delegate
			{
				this.asValue.MaxLengthEnable = e.IsCheck;
				this._propertyItem.SetValue(this._propertyItem.Instance, this.asValue, null);
			});
		}

		private void widget_ValueCangede(object sender, BoolEvent e)
		{
			this.UpDateData(delegate
			{
				this.asValue.MaxLengthText = (int)e.Value;
				this._propertyItem.SetValue(this._propertyItem.Instance, this.asValue, null);
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
			this.widget.SetValue(delegate
			{
				this.asValue = (AstrictLengthValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				this.widget.SetControl(this.asValue.MaxLengthEnable, (double)this.asValue.MaxLengthText);
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
