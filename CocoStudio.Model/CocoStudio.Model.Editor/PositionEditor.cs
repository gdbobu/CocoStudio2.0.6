using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class PositionEditor : BaseEditor, ITypeEditor
	{
		private NumberEditorWidget widget;

		private bool isCheck = false;

		public PositionEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PositionEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem propertyItem = null)
		{
			this.widget = new NumberEditorWidget(false, false, 30);
			this.widget.SetEntryPRoperty(false, 2, 1.0);
			this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
			this.SetControl();
			this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
			this.widget.PointY += new EventHandler<PointEvent>(this.widget_PointY);
			this.widget.PerCentChanged += new EventHandler<UIControlEvent>(this.widget_PerCentChanged);
			if (this._propertyItem.IsEnable)
			{
				this.widget.Sensitive = false;
			}
			return this.widget;
		}

		private void SetControl()
		{
			PointF pointF = (PointF)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (this._propertyItem.InstanceCount > 1)
			{
				Func<bool, bool, bool> func = (bool a, bool b) => a == b;
				bool flag = (base.IsWhip<bool>(func, "PrePositionEnabled") || this.isMultiValue != null) && (bool)this.isMultiValue;
				Func<PointF, PointF, bool> func2 = (PointF a, PointF b) => a.X == b.X;
				Func<PointF, PointF, bool> func3 = (PointF a, PointF b) => a.Y == b.Y;
				if (base.IsWhip<PointF>(func2, ""))
				{
					this.widget.SetWhipX(flag);
				}
				else
				{
					this.widget.SetX((double)pointF.X);
				}
				if (base.IsWhip<PointF>(func3, ""))
				{
					this.widget.SetWhipY(flag);
				}
				else
				{
					this.widget.SetY((double)pointF.Y);
				}
			}
			else
			{
				this.widget.SetValue(delegate
				{
					NodeObject nodeObject = this._propertyItem.Instance as NodeObject;
					this.isCheck = nodeObject.PrePositionEnabled;
					this.widget.X.SetValue((double)nodeObject.Position.X, (double)(nodeObject.PrePosition.X * 100f), nodeObject.PrePositionEnabled);
					this.widget.Y.SetValue((double)nodeObject.Position.Y, (double)(nodeObject.PrePosition.Y * 100f), nodeObject.PrePositionEnabled);
				});
			}
		}

		private void widget_PerCentChanged(object sender, UIControlEvent e)
		{
			this.UpDateData(delegate
			{
				this._propertyItem.SetValue("PrePositionEnabled", e.IsCheck, null);
				this.isCheck = e.IsCheck;
				this.SetControl();
			});
		}

		private void widget_PointY(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("PrePosition");
				for (int i = this._propertyItem.InstanceList.Count - 1; i >= 0; i--)
				{
					object obj = this._propertyItem.InstanceList[i];
					if (this.isCheck)
					{
						PointF pointF = (PointF)property.GetValue(obj, null);
						property.SetValue(obj, new PointF(pointF.X, (float)e.PointY * 0.01f), null);
					}
					else
					{
						PointF pointF = (PointF)this._propertyItem.PropertyData.GetValue(obj, null);
						this._propertyItem.PropertyData.SetValue(obj, new PointF(pointF.X, (float)e.PointY), null);
					}
				}
			});
		}

		private void widget_PointX(object sender, PointEvent e)
		{
			this.UpDateData(delegate
			{
				PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("PrePosition");
				for (int i = this._propertyItem.InstanceList.Count - 1; i >= 0; i--)
				{
					object obj = this._propertyItem.InstanceList[i];
					if (this.isCheck)
					{
						PointF pointF = (PointF)property.GetValue(obj, null);
						property.SetValue(obj, new PointF((float)e.PointX * 0.01f, pointF.Y), null);
					}
					else
					{
						PointF pointF = (PointF)this._propertyItem.PropertyData.GetValue(obj, null);
						this._propertyItem.PropertyData.SetValue(obj, new PointF((float)e.PointX, pointF.Y), null);
					}
				}
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.SetChildWidget(this.widget, e.PropertyName);
			if (e.PropertyName == "RelativePosition" || e.PropertyName == "PrePosition" || e.PropertyName == "PrePositionEnabled" || e.PropertyName == "IsTransformEnabled")
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
