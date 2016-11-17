using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model
{
	public class LabelTooltipEditor : BaseEditor, ITypeEditor
	{
		private Table table;

		private Label label;

		public LabelTooltipEditor() : base(null)
		{
		}

		public LabelTooltipEditor(PropertyItem properItem) : base(properItem)
		{
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.table = new Table(1u, 2u, false);
			this.label = new Label();
			this.label.Text = LanguageOption.GetValueBykey(this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null).ToString());
			this.label.ModifyFg(StateType.Normal, WindowStyle.LableToolTipColor);
			this.label.SetFontSize(10.0);
			this.label.Wrap = true;
			this.table.Attach(this.label, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.Attach(new Label(), 1u, 2u, 0u, 1u, AttachOptions.Expand, AttachOptions.Fill, 0u, 0u);
			this.table.ShowAll();
			return this.table;
		}

		public void EditorDispose()
		{
		}

		public void RefreshData()
		{
		}
	}
}
