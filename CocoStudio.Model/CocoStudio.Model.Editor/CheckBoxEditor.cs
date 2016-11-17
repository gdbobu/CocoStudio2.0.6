using CocoStudio.ToolKit;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class CheckBoxEditor : BaseEditor, ITypeEditor
	{
		private Table widget;

		private RadioButton choice;

		private RadioButton unChoice;

		private bool isSetControl = false;

		public CheckBoxEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public CheckBoxEditor() : base(null)
		{
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}

		private void choice_Clicked(object sender, EventArgs e)
		{
			if (!this.isSetControl)
			{
				this.UpDateData(delegate
				{
					this._propertyItem.SetValue(this._propertyItem.Instance, this.choice.Active, null);
				});
			}
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new Table(1u, 2u, false);
			this.choice = new RadioButton(LanguageInfo.Display_NormalState);
			this.unChoice = new RadioButton(LanguageInfo.Display_Disable);
			this.widget.Attach(this.choice, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.widget.Attach(this.unChoice, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.choice.CanFocus = false;
			this.choice.DrawIndicator = true;
			this.choice.UseUnderline = true;
			this.unChoice.CanFocus = false;
			this.unChoice.DrawIndicator = true;
			this.unChoice.UseUnderline = true;
			this.SetControl();
			this.choice.Clicked += new EventHandler(this.choice_Clicked);
			this.widget.ShowAll();
			return this.widget;
		}

		public void SetControl()
		{
			this.isSetControl = true;
			object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if ((bool)value)
			{
				this.choice.Group = new SList(IntPtr.Zero);
				this.unChoice.Group = this.choice.Group;
			}
			else
			{
				this.unChoice.Group = new SList(IntPtr.Zero);
				this.choice.Group = this.unChoice.Group;
			}
			this.isSetControl = false;
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
