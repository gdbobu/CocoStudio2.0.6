using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class UIControlSizeEditor : BaseEditor, ITypeEditor
	{
		private UIControlSizeEditorWidget widget = null;

		private IScale9 scale9 = null;

		private ISizeType sizeTypeObject = null;

		public UIControlSizeEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public UIControlSizeEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new UIControlSizeEditorWidget();
			this.scale9 = (this._propertyItem.Instance as IScale9);
			this.sizeTypeObject = (this._propertyItem.Instance as ISizeType);
			this.SetControl();
			this.widget.SQuardValueChanged += new EventHandler<UIControlEvent>(this.widget_SQuardValueChanged);
			return this.widget;
		}

		private void SetControl()
		{
			NodeObject data = this._propertyItem.Instance as NodeObject;
			bool isPrecent = data.PreSizeEnable;
			if (this._propertyItem.IsEnable)
			{
				this.widget.SetMenuEnable(!this._propertyItem.IsEnable);
				isPrecent = false;
			}
			this.widget.SetValue(delegate
			{
				if (this.sizeTypeObject != null)
				{
					this.widget.SetSizeTypeMode(this.sizeTypeObject.IsCustomSize, isPrecent, (double)data.Size.X, (double)data.Size.Y, (double)(data.PreSize.X * 100f), (double)(data.PreSize.Y * 100f));
				}
				else if (this.scale9 != null)
				{
					this.widget.SetScale9Mode(data is PanelObject, isPrecent, (double)data.Size.X, (double)data.Size.Y, (double)(data.PreSize.X * 100f), (double)(data.PreSize.Y * 100f));
					this.widget.SetSquard(this.scale9.Scale9Enable, (double)this.scale9.TopEage, (double)this.scale9.BottomEage, (double)this.scale9.LeftEage, (double)this.scale9.RightEage);
				}
				else
				{
					this.widget.SetShowOnlyMode(data is TextFieldObject, isPrecent, (double)data.Size.X, (double)data.Size.Y, (double)(data.PreSize.X * 100f), (double)(data.PreSize.Y * 100f));
				}
			});
		}

		private void widget_SQuardValueChanged(object sender, UIControlEvent e)
		{
			this.UpDateData(delegate
			{
				NodeObject nodeObject = this._propertyItem.Instance as NodeObject;
				string name = e.Name;
				switch (name)
				{
				case "comboBox_modeType_Changed":
					if (this.sizeTypeObject != null)
					{
						this.sizeTypeObject.IsCustomSize = !e.IsCheck;
						this.SetControl();
					}
					break;
				case "preSizeEnabled_Clicked":
					nodeObject.PreSizeEnable = e.IsCheck;
					this.SetControl();
					break;
				case "rectSize_PointX":
					if (nodeObject.PreSizeEnable)
					{
						PointF preSize = nodeObject.PreSize;
						preSize.X = (float)e.UIValue / 100f;
						nodeObject.PreSize = preSize;
					}
					else
					{
						nodeObject.Size = new PointF((float)((int)e.UIValue), nodeObject.Size.Y);
					}
					break;
				case "rectSize_PointY":
					if (nodeObject.PreSizeEnable)
					{
						PointF preSize2 = nodeObject.PreSize;
						preSize2.Y = (float)e.UIValue / 100f;
						nodeObject.PreSize = preSize2;
					}
					else
					{
						nodeObject.Size = new PointF(nodeObject.Size.X, (float)((int)e.UIValue));
					}
					break;
				case "scale9Enabled_Clicked":
					if (this.scale9 != null)
					{
						this.scale9.Scale9Enable = e.IsCheck;
						this.SetControl();
					}
					break;
				case "Left":
					if (this.scale9 != null)
					{
						this.scale9.LeftEage = (int)e.UIValue;
					}
					break;
				case "Right":
					if (this.scale9 != null)
					{
						this.scale9.RightEage = (int)e.UIValue;
					}
					break;
				case "Bottom":
					if (this.scale9 != null)
					{
						this.scale9.BottomEage = (int)e.UIValue;
					}
					break;
				case "Top":
					if (this.scale9 != null)
					{
						this.scale9.TopEage = (int)e.UIValue;
					}
					break;
				}
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			switch (propertyName)
			{
			case "PreSizeEnable":
			case "PreSize":
			case "Size":
			case "Scale9Enable":
			case "LeftEage":
			case "RightEage":
			case "BottomEage":
			case "TopEage":
			case "IsCustomSize":
				this.SetControl();
				break;
			case "IsTransformEnabled":
			{
				ITransform transform = this._propertyItem.Instance as ITransform;
				if (transform != null)
				{
					this.widget.SetMenuEnable(transform.IsTransformEnabled);
				}
				this._propertyItem.IsEnable = !transform.IsTransformEnabled;
				this.SetControl();
				break;
			}
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
