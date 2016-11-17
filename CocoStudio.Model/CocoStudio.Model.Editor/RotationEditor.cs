using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class RotationEditor : BaseEditor, ITypeEditor
	{
		private NumberEditorWidget widget;

		public RotationEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public RotationEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem = null)
		{
			this.widget = new NumberEditorWidget(false, true, (LanguageOption.CurrentLanguage == LanguageType.Chinese) ? 105 : 89);
			this.widget.SetEntryPRoperty(false, 2, 1.0);
			this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
			this.SetControl();
			this.widget.SetLabelText((LanguageOption.CurrentLanguage == LanguageType.Chinese) ? "度" : "°");
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
			if (this._propertyItem.IsEnable)
			{
				this.widget.Sensitive = false;
			}
			return this.widget;
		}

		private void SetControl()
		{
			object data = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				if (base.IsWhip<float>(null, ""))
				{
					this.widget.SetWhipX(false);
				}
				else
				{
					this.widget.SetX(Convert.ToDouble(this.isMultiValue));
				}
			}
			else
			{
				this.widget.SetValue(delegate
				{
					this.widget.X.SetPositionValue(Convert.ToDouble(data));
				});
			}
		}

		private void widget_PointX(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue(this._propertyItem.Instance, Convert.ToSingle(e.PointX), null);
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.SetChildWidget(this.widget, e.PropertyName);
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
