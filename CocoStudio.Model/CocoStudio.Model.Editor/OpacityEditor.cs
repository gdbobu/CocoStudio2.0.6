using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	internal class OpacityEditor : BaseEditor, ITypeEditor
	{
		private Table widget;

		private RadioButton choice;

		private RadioButton unChoice;

		public OpacityEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public OpacityEditor() : base(null)
		{
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}

		private void choice_Clicked(object sender, EventArgs e)
		{
			this.choice.Clicked -= new EventHandler(this.choice_Clicked);
			this.unChoice.Clicked -= new EventHandler(this.choice_Clicked);
			this.choice.Inconsistent = false;
			this.unChoice.Inconsistent = false;
			(sender as RadioButton).Inconsistent = true;
			this.choice.Clicked += new EventHandler(this.choice_Clicked);
			this.unChoice.Clicked += new EventHandler(this.choice_Clicked);
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new Table(1u, 2u, false);
			this.choice = new RadioButton("");
			this.unChoice = new RadioButton("");
			this.widget.Attach(this.choice, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.widget.Attach(this.unChoice, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.choice.Clicked += new EventHandler(this.choice_Clicked);
			this.unChoice.Clicked += new EventHandler(this.choice_Clicked);
			this.widget.ShowAll();
			return this.widget;
		}

		public void EditorDispose()
		{
		}

		public void RefreshData()
		{
		}
	}
}
