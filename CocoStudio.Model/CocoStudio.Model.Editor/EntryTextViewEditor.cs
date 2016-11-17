using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	public class EntryTextViewEditor : BaseEditor, ITypeEditor
	{
		private TextView textView;

		private bool isKeyPress = false;

		public EntryTextViewEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public EntryTextViewEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.textView = new TextView();
			this.textView.WrapMode = WrapMode.Char;
			this.textView.HeightRequest = 80;
			this.SetControl();
			this.textView.KeyReleaseEvent += new KeyReleaseEventHandler(this.textView_KeyReleaseEvent);
			this.textView.FocusOutEvent += new FocusOutEventHandler(this.textView_FocusOutEvent);
			return this.textView;
		}

		private void SetControl()
		{
			if (this._propertyItem != null)
			{
				this.textView.KeyReleaseEvent -= new KeyReleaseEventHandler(this.textView_KeyReleaseEvent);
				this.textView.FocusOutEvent -= new FocusOutEventHandler(this.textView_FocusOutEvent);
				object obj = null;
				if (this._propertyItem != null && this._propertyItem.PropertyData != null)
				{
					obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				}
				if (obj != null)
				{
					this.textView.Buffer.Text = obj.ToString();
				}
				this.textView.KeyReleaseEvent += new KeyReleaseEventHandler(this.textView_KeyReleaseEvent);
				this.textView.FocusOutEvent += new FocusOutEventHandler(this.textView_FocusOutEvent);
			}
		}

		private void textView_FocusOutEvent(object o, FocusOutEventArgs args)
		{
			if (!this.isKeyPress)
			{
				this.UpDateData(delegate
				{
					this.SetTextViewWidget();
				});
			}
		}

		private void textView_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
		{
			if (args.Event.Key == Gdk.Key.Return && this.textView.IsFocus)
			{
				this.isKeyPress = true;
				this.UpDateData(delegate
				{
					this.SetTextViewWidget();
				});
				this.isKeyPress = false;
			}
		}

		private void SetTextViewWidget()
		{
			object value = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			if (value == null || !(value.ToString() == this.textView.Buffer.Text))
			{
				this._propertyItem.SetValue(this._propertyItem.Instance, this.textView.Buffer.Text, null);
				object value2 = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
				if (value2.ToString() != this.textView.Buffer.Text)
				{
					this.SetTextViewWidget();
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

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.SetControl();
			}
		}
	}
}
