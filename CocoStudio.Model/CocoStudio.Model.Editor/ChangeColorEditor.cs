using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class ChangeColorEditor : BaseEditor, ITypeEditor
	{
		private ChangeColorWidget widget;

		public ChangeColorEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ChangeColorEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new ChangeColorWidget();
			this.SetControl();
			this.widget.ColorChanged += new EventHandler<ColorEvent>(this.widget_ColorChanged);
			this.widget.ComBoxChanged += new EventHandler<ComBoxEvnent>(this.widget_ComBoxChanged);
			this.widget.ChangedColorChanged += new EventHandler<ColorEvent>(this.widget_ChangedColorChanged);
			this.widget.PointEventChanged += new EventHandler<PointColorEvent>(this.widget_PointEventChanged);
			return this.widget;
		}

		private void SetControl()
		{
			this.widget.SetValue(delegate
			{
				IColorValue colorValue = this._propertyItem.Instance as IColorValue;
				System.Drawing.Color singleColor = colorValue.SingleColor;
				int comboBoxIndex = colorValue.ComboBoxIndex;
				System.Drawing.Color firstColor = colorValue.FirstColor;
				System.Drawing.Color endColor = colorValue.EndColor;
				ScaleValue colorVector = colorValue.ColorVector;
				PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("ColorAngle");
				float num = (float)property.GetValue(this._propertyItem.Instance, null);
				this.widget.SetControl(this.ConvertColor(singleColor), comboBoxIndex, this.ConvertColor(firstColor), this.ConvertColor(endColor), (int)num);
				this.SetBgColor();
			});
		}

		private void SetBgColor()
		{
			PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("BackColorAlpha");
			if (property != null)
			{
				int bGAlthl = (int)property.GetValue(this._propertyItem.Instance, null);
				this.widget.SetBGAlthl(bGAlthl);
			}
		}

		private void widget_PointEventChanged(object sender, PointColorEvent e)
		{
			this.UpDateData(delegate
			{
				IColorValue colorValue = this._propertyItem.Instance as IColorValue;
				if (e.Type == 0)
				{
					this._propertyItem.SetValue("ColorAngle", (float)e.Value, null);
				}
				else
				{
					this._propertyItem.SetValue("BackColorAlpha", (int)e.Value, null);
				}
			});
		}

		private void widget_ChangedColorChanged(object sender, ColorEvent e)
		{
			this.UpDateData(delegate
			{
				if (e.Type == 0)
				{
					this._propertyItem.SetValue("FirstColor", this.ConvertColor(e.Color), null);
				}
				else
				{
					this._propertyItem.SetValue("EndColor", this.ConvertColor(e.Color), null);
				}
			});
		}

		private void widget_ComBoxChanged(object sender, ComBoxEvnent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue("ComboBoxIndex", e.SelectIndex, null);
				this.SetControl();
			});
		}

		private void widget_ColorChanged(object sender, ColorEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue("SingleColor", this.ConvertColor(e.Color), null);
			});
		}

		public System.Drawing.Color ConvertColor(Gdk.Color color)
		{
			int red = (int)(255f * (float)color.Red / 65535f);
			int green = (int)(255f * (float)color.Green / 65535f);
			int blue = (int)(255f * (float)color.Blue / 65535f);
			return System.Drawing.Color.FromArgb(255, red, green, blue);
		}

		public Gdk.Color ConvertColor(System.Drawing.Color color)
		{
			return new Gdk.Color(color.R, color.G, color.B);
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (typeof(IColorValue).GetProperty(e.PropertyName) != null || e.PropertyName == "BackColorAlpha" || e.PropertyName == "ColorAngle")
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
