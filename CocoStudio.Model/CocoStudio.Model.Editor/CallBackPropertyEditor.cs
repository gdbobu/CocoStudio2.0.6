using CocoStudio.Basic;
using CocoStudio.Model.Interface;
using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class CallBackPropertyEditor : BaseEditor, ITypeEditor
	{
		private Table table;

		private ComboBox combox;

		private EntryCallBackEx entry;

		private bool isSetValue = false;

		public CallBackPropertyEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public CallBackPropertyEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			HBox hBox = new HBox();
			this.table = new Table(1u, 2u, false);
			this.combox = new ComboBox();
			this.entry = new EntryCallBackEx();
			this.combox.WidthRequest = 90;
			this.entry.WidthRequest = 115;
			this.combox.HeightRequest = 22;
			this.entry.HeightRequest = 22;
			this.table.Attach(this.combox, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.Attach(this.entry, 1u, 2u, 0u, 1u, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.table.ShowAll();
			Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
			alignment.RightPadding = 30u;
			alignment.Add(this.table);
			alignment.ShowAll();
			this.entry.Show();
			hBox.Add(alignment);
			Box.BoxChild boxChild = hBox[alignment] as Box.BoxChild;
			boxChild.Position = 1;
			boxChild.Expand = true;
			boxChild.Fill = true;
			hBox.ShowAll();
			this.SetControl();
			this.table.ColumnSpacing = 10u;
			this.combox.Changed += new EventHandler(this.combox_Changed);
			this.entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.entry_KeyReleaseEvent);
			this.entry.FocusOutEvent += new FocusOutEventHandler(this.entry_FocusOutEvent);
			this.ReadLanuageConfigFile();
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

		private void combox_Changed(object sender, EventArgs e)
		{
			if (!this.isSetValue)
			{
				this.UpDateData(delegate
				{
					this._propertyItem.SetValue(this._propertyItem.Instance, (EnumCallBack)(this.combox.Active - 1), null);
				});
			}
		}

		private void SetWidgetValue()
		{
			this.entry.Text = this.entry.Text.Trim(new char[]
			{
				' '
			});
			this._propertyItem.SetValue("CallBackName", this.entry.Text, null);
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
			this.isSetValue = true;
			EnumCallBack enumCallBack = (EnumCallBack)this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, null);
			this.combox.Active = (int)(enumCallBack + 1);
			PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("CallBackName");
			object value = property.GetValue(this._propertyItem.Instance, null);
			this.entry.Text = value.ToString();
			this.isSetValue = false;
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name || e.PropertyName == "CallBackName")
			{
				this.SetControl();
			}
		}

		public void ReadLanuageConfigFile()
		{
			ListStore listStore = new ListStore(new Type[]
			{
				typeof(string)
			});
			string[] names = Enum.GetNames(typeof(EnumCallBack));
			int i = 0;
			while (i < names.Count<string>())
			{
				if (!(((EnumCallBack)(i - 1)).ToString() == EnumCallBack.Event.ToString()))
				{
					goto IL_9E;
				}
				if (!(((EnumCallBack)(i - 1)).ToString() == EnumCallBack.Event.ToString()) || this._propertyItem.Instance is ICallBackEvent)
				{
					goto IL_9E;
				}
				IL_C1:
				i++;
				continue;
				IL_9E:
				listStore.AppendValues(new object[]
				{
					((EnumCallBack)(i - 1)).ToString()
				});
				goto IL_C1;
			}
			this.combox.Model = listStore;
			CellRendererText cell = new CellRendererText();
			this.combox.PackStart(cell, true);
			this.combox.AddAttribute(cell, "text", 0);
		}
	}
}
