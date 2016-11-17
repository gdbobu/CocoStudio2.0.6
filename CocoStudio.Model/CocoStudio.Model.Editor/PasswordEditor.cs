using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class PasswordEditor : BaseEditor, ITypeEditor
	{
		private PasswordEditorWidget widget;

		private PasswordValue passWordValue;

		public PasswordEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PasswordEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item)
		{
			this.widget = new PasswordEditorWidget();
			this.passWordValue = (PasswordValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this.passWordValue != null)
			{
				this.widget.SetControl(this.passWordValue.PasswordEnable, this.passWordValue.PasswordStyleText);
			}
			this.widget.TextCangede += new EventHandler<BoolEvent>(this.widget_TextCangede);
			this.widget.IsCheckChanged += new EventHandler<BoolEvent>(this.widget_IsCheckChanged);
			return this.widget;
		}

		private void widget_IsCheckChanged(object sender, BoolEvent e)
		{
			this.UpDateData(delegate
			{
				this.passWordValue.PasswordEnable = e.IsCheck;
				this._propertyItem.SetValue(this._propertyItem.Instance, this.passWordValue, null);
			});
		}

		private void widget_TextCangede(object sender, BoolEvent e)
		{
			if (!string.IsNullOrEmpty(e.Text))
			{
				this.passWordValue.PasswordStyleText = e.Text;
				this.UpDateData(delegate
				{
					this._propertyItem.SetValue(this._propertyItem.Instance, this.passWordValue, null);
				});
			}
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}

		public void SetControl()
		{
			this.widget.SetValue(delegate
			{
				this.passWordValue = (PasswordValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				if (this.passWordValue != null)
				{
					this.widget.SetControl(this.passWordValue.PasswordEnable, this.passWordValue.PasswordStyleText);
				}
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
