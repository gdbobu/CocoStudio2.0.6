using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class AnchorPointEditor : BaseEditor, ITypeEditor
	{
		private ScaleEditorWidget widget;

		public AnchorPointEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public AnchorPointEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem)
		{
			this.widget = new ScaleEditorWidget(false);
			this.widget.SetInit(-2147483648.0, 2147483647.0, 0.1, 2u);
			this.widget.SetMenuVisble(false);
			this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
			this.widget.SetMenuLabel();
			this.SetControl();
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
			this.widget.PointY += new EventHandler<PointEvent>(this.widget_PointY);
			if (this._propertyItem.IsEnable)
			{
				this.widget.Sensitive = false;
			}
			return this.widget;
		}

		private void widget_PointY(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				foreach (object current in this._propertyItem.InstanceList)
				{
					NodeObject nodeObject = current as NodeObject;
					this._propertyItem.SetValue(this._propertyItem.Instance, new ScaleValue(nodeObject.AnchorPoint.ScaleX, (float)e.PointX, 0.1, -99999999.0, 99999999.0), null);
				}
			});
		}

		private void widget_PointX(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				foreach (object current in this._propertyItem.InstanceList)
				{
					NodeObject nodeObject = current as NodeObject;
					this._propertyItem.SetValue(this._propertyItem.Instance, new ScaleValue((float)e.PointX, nodeObject.AnchorPoint.ScaleY, 0.1, -99999999.0, 99999999.0), null);
				}
			});
		}

		private void SetControl()
		{
			ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				Func<ScaleValue, ScaleValue, bool> func = (ScaleValue a, ScaleValue b) => Math.Round((double)a.ScaleX, 2) == Math.Round((double)b.ScaleX, 2);
				Func<ScaleValue, ScaleValue, bool> func2 = (ScaleValue a, ScaleValue b) => Math.Round((double)a.ScaleY, 2) == Math.Round((double)b.ScaleY, 2);
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
				this.widget.SetValue(delegate
				{
					this.widget.SetXValue((double)scaleValue.ScaleX);
					this.widget.SetYValue((double)scaleValue.ScaleY);
				});
			}
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
