using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class SkewEditor : BaseEditor, ITypeEditor
	{
		private NumberEditorWidget widget;

		public SkewEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public SkewEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new NumberEditorWidget(false, false, 30);
			this.widget.SetMenuVisble(false);
			this.widget.SetLabel(LanguageInfo.Radio_HorizontalGuides, LanguageInfo.Radio_VerticalGuides);
			this.widget.SetEntryPRoperty(false, 2, 1.0);
			this.SetControl();
			this.widget.SetLabelText((LanguageOption.CurrentLanguage == LanguageType.Chinese) ? "度" : "°");
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_Pointx);
			this.widget.PointY += new EventHandler<PointEvent>(this.widget_Pointy);
			if (this._propertyItem.IsEnable)
			{
				this.widget.Sensitive = false;
			}
			return this.widget;
		}

		private void ScaleEditor_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}

		private void SetControl()
		{
			ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				Func<ScaleValue, ScaleValue, bool> func = (ScaleValue a, ScaleValue b) => a.ScaleX == b.ScaleX;
				Func<ScaleValue, ScaleValue, bool> func2 = (ScaleValue a, ScaleValue b) => a.ScaleY == b.ScaleY;
				if (base.IsWhip<ScaleValue>(func, ""))
				{
					this.widget.SetWhipX(false);
				}
				else
				{
					this.widget.SetX((double)scaleValue.ScaleX);
				}
				if (base.IsWhip<ScaleValue>(func2, ""))
				{
					this.widget.SetWhipY(false);
				}
				else
				{
					this.widget.SetY((double)scaleValue.ScaleY);
				}
			}
			else
			{
				this.widget.SetValue((double)scaleValue.ScaleX, (double)scaleValue.ScaleY, false);
			}
		}

		private void widget_Pointy(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				foreach (object current in this._propertyItem.InstanceList)
				{
					ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(current, null);
					scaleValue.ScaleY = (float)e.PointX;
					if (e.IsCheck)
					{
						scaleValue.ScaleX = (float)e.PointX;
					}
					this._propertyItem.PropertyData.SetValue(current, scaleValue, null);
				}
			});
		}

		private void widget_Pointx(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				foreach (object current in this._propertyItem.InstanceList)
				{
					ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(current, null);
					scaleValue.ScaleX = (float)e.PointX;
					if (e.IsCheck)
					{
						scaleValue.ScaleY = (float)e.PointX;
					}
					this._propertyItem.SetValue(this._propertyItem.Instance, scaleValue, null);
				}
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
