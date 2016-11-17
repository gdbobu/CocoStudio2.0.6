using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class CallBackPropertyRootEditor : BaseEditor, ITypeEditor
	{
		private EntryCallBackEx entry;

		public CallBackPropertyRootEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public CallBackPropertyRootEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			HBox hBox = new HBox();
			this.entry = new EntryCallBackEx();
			Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
			alignment.RightPadding = 30u;
			alignment.Add(this.entry);
			alignment.ShowAll();
			this.entry.Show();
			hBox.Add(alignment);
			Box.BoxChild boxChild = hBox[alignment] as Box.BoxChild;
			boxChild.Position = 1;
			boxChild.Expand = true;
			boxChild.Fill = true;
			hBox.ShowAll();
			this.SetControl();
			this.entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.entry_KeyReleaseEvent);
			this.entry.FocusOutEvent += new FocusOutEventHandler(this.entry_FocusOutEvent);
			return hBox;
		}

		private void entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
		{
			if (args.Event.Key == Gdk.Key.Return && this.entry.IsFocus)
			{
				this.UpDateData(delegate
				{
					this.SetWidgetValue();
				});
			}
		}

		private void entry_FocusOutEvent(object o, FocusOutEventArgs args)
		{
			this.UpDateData(delegate
			{
				this.SetWidgetValue();
			});
		}

		private void SetWidgetValue()
		{
			this.entry.Value = this.entry.Text.Trim(new char[]
			{
				' '
			});
			this._propertyItem.SetValue("CustomClassName", this.entry.Value, null);
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.SetControl();
		}

		private void SetControl()
		{
			PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("CustomClassName");
			string value = (string)property.GetValue(this._propertyItem.Instance, null);
			this.entry.Value = value;
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
