using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class NameEditor : BaseEditor, ITypeEditor
	{
		private Entry widget;

		public string oldStr;

		private bool isKeyPress = false;

		public NameEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public NameEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new DefaultEditorGtk();
			if (this._propertyItem.InstanceCount > 1)
			{
				this.widget.Sensitive = false;
			}
			else
			{
				this.SetControl();
				this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
				this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
			}
			return this.widget;
		}

		private void widget_FocusOutEvent(object o, FocusOutEventArgs args)
		{
			if (!this.isKeyPress)
			{
				this.UpDateData(delegate
				{
					if (string.IsNullOrEmpty(this.widget.Text.Trim()))
					{
						this.widget.Text = this.oldStr;
					}
					else
					{
						this.SetWidgetValue();
					}
				});
			}
		}

		private void widget_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
		{
			if (args.Event.Key == Gdk.Key.Return && this.widget.IsFocus)
			{
				if (string.IsNullOrEmpty(this.widget.Text.Trim()))
				{
					this.widget.Text = this.oldStr;
				}
				else
				{
					this.isKeyPress = true;
					this.UpDateData(delegate
					{
						this.SetWidgetValue();
					});
					this.widget.SelectRegion(0, this.widget.Text.Length);
					this.isKeyPress = false;
				}
			}
		}

		private void SetWidgetValue()
		{
			object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (value == null || !(value.ToString() == this.widget.Text))
			{
				this._propertyItem.SetValue(this._propertyItem.Instance, this.widget.Text.Trim(), null);
				this.oldStr = this.widget.Text;
				object value2 = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				if (value2.ToString() != this.widget.Text)
				{
					this.SetControl();
				}
			}
		}

		private void SetControl()
		{
			if (this._propertyItem != null)
			{
				this.widget.KeyReleaseEvent -= new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
				this.widget.FocusOutEvent -= new FocusOutEventHandler(this.widget_FocusOutEvent);
				object obj = null;
				if (this._propertyItem != null && this._propertyItem.PropertyData != null)
				{
					obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				}
				if (obj != null)
				{
					this.widget.Text = obj.ToString();
					this.oldStr = this.widget.Text;
				}
				this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
				this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
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

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}
	}
}
