using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class ScaleEditor : BaseEditor, ITypeEditor
	{
		private ScaleNumberEditorWidget widget;

		public ScaleEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ScaleEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new ScaleNumberEditorWidget(true);
			this.widget.CanZero = false;
			this.widget.SetMenuVisble(false);
			this.widget.SetLabel(LanguageInfo.Radio_HorizontalGuides, LanguageInfo.Radio_VerticalGuides);
			this.widget.SetEntryPRoperty(false, 2, 1.0);
			this.SetControl();
			this.SetImageStatus();
			this.widget.SetLabelText("%");
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_Pointx);
			this.widget.PointY += new EventHandler<PointEvent>(this.widget_Pointy);
			this.widget.ImageStatusChanged += new EventHandler<PointEvent>(this.widget_ImageStatusChanged);
			if (this._propertyItem.IsEnable)
			{
				this.widget.Sensitive = false;
			}
			return this.widget;
		}

		private void widget_ImageStatusChanged(object sender, PointEvent e)
		{
			this._propertyItem.SetValue("UniformScale", e.IsCheck, null);
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
					this.widget.SetX((double)scaleValue.ScaleX * 100.0);
				}
				if (base.IsWhip<ScaleValue>(func2, ""))
				{
					this.widget.SetWhipY(false);
				}
				else
				{
					this.widget.SetY((double)scaleValue.ScaleY * 100.0);
				}
			}
			else
			{
				this.widget.SetValue((double)scaleValue.ScaleX * 100.0, (double)scaleValue.ScaleY * 100.0, false);
			}
		}

		private void widget_Pointy(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				float num = (float)e.PointX / 100f;
				foreach (object current in this._propertyItem.InstanceList)
				{
					ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(current, null);
					if (e.IsCheck)
					{
						scaleValue.ScaleX = scaleValue.ScaleX / scaleValue.ScaleY * num;
						this.widget.SetX((double)(scaleValue.ScaleX * 100f));
					}
					scaleValue.ScaleY = num;
					this._propertyItem.PropertyData.SetValue(current, scaleValue, null);
				}
			});
		}

		private void widget_Pointx(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				float num = (float)e.PointX / 100f;
				foreach (object current in this._propertyItem.InstanceList)
				{
					ScaleValue scaleValue = (ScaleValue)this._propertyItem.PropertyData.GetValue(current, null);
					if (e.IsCheck)
					{
						scaleValue.ScaleY = scaleValue.ScaleY / scaleValue.ScaleX * num;
						this.widget.SetY((double)(scaleValue.ScaleY * 100f));
					}
					scaleValue.ScaleX = num;
					this._propertyItem.PropertyData.SetValue(current, scaleValue, null);
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
			else if (e.PropertyName == "UniformScale")
			{
				this.SetImageStatus();
			}
		}

		public void SetImageStatus()
		{
			bool imageStatus = (bool)this._propertyItem.Instance.GetType().GetProperty("UniformScale").GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				if (base.IsWhip<bool>(null, "UniformScale"))
				{
					this.widget.SetImageStatus(false);
				}
				else
				{
					this.widget.SetImageStatus(imageStatus);
				}
			}
			else
			{
				this.widget.SetImageStatus(imageStatus);
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
