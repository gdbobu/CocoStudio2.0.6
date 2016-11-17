using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Gtk.Controls;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	internal class PropertyColorEditor : BaseEditor, ITypeEditor
	{
		private Table Widget;

		private ColorEx color;

		private ComboBoxEntry combox;

		private ResourceFileImport import;

		private int[] comboxList = new int[]
		{
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			16,
			18,
			20,
			22,
			24,
			36,
			48,
			72
		};

		private string colorText = string.Empty;

		private bool isKeyPress = false;

		private int comboxOldValue = 5;

		public PropertyColorEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public PropertyColorEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.Widget = new Table(2u, 2u, false);
			this.color = new ColorEx();
			this.combox = new ComboBoxEntry();
			this.import = new ResourceFileImport(this._propertyItem, LanguageInfo.Property_ImportFont, "");
			this.color.ColorChanged += new EventHandler<ColorExEvent>(this.color_ColorChanged);
			this.combox = new ComboBoxEntry();
			ListStore listStore = new ListStore(new Type[]
			{
				typeof(string)
			});
			int[] array = this.comboxList;
			for (int i = 0; i < array.Length; i++)
			{
				int num = array[i];
				listStore.AppendValues(new object[]
				{
					num.ToString()
				});
			}
			this.combox.Model = listStore;
			CellRendererText cell = new CellRendererText();
			this.combox.PackStart(cell, true);
			this.combox.AddAttribute(cell, "text", 0);
			object value = this._propertyItem.Instance.GetType().GetProperty("FontSize").GetValue(this._propertyItem.Instance, null);
			int num2 = this.IndexCombox((int)value);
			if (num2 == -1)
			{
				this.combox.Entry.Text = value.ToString();
				this.comboxOldValue = (int)value;
			}
			else
			{
				this.combox.Active = num2;
				this.combox.Entry.Text = this.comboxList[num2].ToString();
				this.comboxOldValue = this.comboxList[num2];
			}
			this.combox.WidthRequest = 60;
			this.combox.Changed += new EventHandler(this.combox_Changed);
			this.combox.Entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.Entry_KeyReleaseEvent);
			this.combox.Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent);
			this.combox.Entry.Changed += new EventHandler(this.Entry_Changed);
			object property = this._propertyItem.Instance.GetType().GetProperty("TextColor");
			this.colorText = "TextColor";
			if (property == null)
			{
				property = this._propertyItem.Instance.GetType().GetProperty("CColor");
				this.colorText = "CColor";
			}
			if (property != null)
			{
				this.Widget = new Table(2u, 3u, false);
				this.Widget.Attach(this.color, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
				this.Widget.Attach(this.combox, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
				this.Widget.Attach(new Label(), 2u, 3u, 0u, 1u, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
				this.Widget.Attach(this.import, 0u, 3u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			}
			else
			{
				this.Widget = new Table(2u, 1u, false);
				this.Widget.Attach(this.combox, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
				this.Widget.Attach(this.import, 0u, 2u, 1u, 3u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			}
			this.SetColorValue();
			this.Widget.ShowAll();
			this.Widget.RowSpacing = 6u;
			this.Widget.ColumnSpacing = 30u;
			return this.Widget;
		}

		private void color_ColorChanged(object sender, ColorExEvent e)
		{
			this.color.ColorChanged -= new EventHandler<ColorExEvent>(this.color_ColorChanged);
			using (CompositeTask.Run("ColorChanged"))
			{
				this._propertyItem.SetValue(this.colorText, e.Color, null);
			}
			this.color.ColorChanged += new EventHandler<ColorExEvent>(this.color_ColorChanged);
		}

		private void SetColorValue()
		{
			PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty(this.colorText);
			if (property != null)
			{
				object value = property.GetValue(this._propertyItem.Instance, null);
				if (value != null)
				{
					this.color.SetColor(this.ConvertColor((System.Drawing.Color)value));
				}
			}
		}

		private void SetFontValue()
		{
			PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("FontSize");
			if (property != null)
			{
				if (this.combox != null && this.combox.Entry != null)
				{
					this.combox.Entry.Text = property.GetValue(this._propertyItem.Instance, null).ToString();
				}
			}
		}

		public Gdk.Color ConvertColor(System.Drawing.Color color)
		{
			return new Gdk.Color(color.R, color.G, color.B);
		}

		private int IndexCombox(int num)
		{
			int result;
			for (int i = 0; i < this.comboxList.Length; i++)
			{
				if (this.comboxList[i] == num)
				{
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}

		private void combox_Changed(object sender, EventArgs e)
		{
			ComboBoxEntry comboBoxEntry = sender as ComboBoxEntry;
			if (comboBoxEntry.Active != -1)
			{
				this.combox.Entry.Text = this.comboxList[comboBoxEntry.Active].ToString();
			}
		}

		private void Entry_Changed(object sender, EventArgs e)
		{
			if (!this.combox.Entry.IsFocus)
			{
				this.FontValue();
			}
			else
			{
				for (int i = 0; i < this.combox.Entry.Text.Length; i++)
				{
					if (this.combox.Entry.Text[i] < '0' || this.combox.Entry.Text[i] > '9')
					{
						this.combox.Entry.Text = this.combox.Entry.Text.Remove(i, 1);
					}
				}
			}
		}

		private void Entry_FocusOutEvent(object o, FocusOutEventArgs args)
		{
			if (this.isKeyPress)
			{
				this.FontValue();
			}
			this.isKeyPress = false;
		}

		private void Entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
		{
			this.isKeyPress = true;
			Gdk.Key key = args.Event.Key;
			if ((key == Gdk.Key.Return || key == Gdk.Key.KP_Enter || key == Gdk.Key.ISO_Enter) && this.combox.Entry.IsFocus)
			{
				this.FontValue();
			}
		}

		private void FontValue()
		{
			if (this.combox.Entry == null || string.IsNullOrEmpty(this.combox.Entry.Text))
			{
				this.combox.Changed -= new EventHandler(this.combox_Changed);
				this.combox.Entry.Text = this.comboxOldValue.ToString();
				this.combox.Changed += new EventHandler(this.combox_Changed);
			}
			else
			{
				int num = 5;
				int.TryParse(this.combox.Entry.Text, out num);
				if (num > 100)
				{
					num = 100;
				}
				if (num < 5)
				{
					num = 5;
				}
				this.combox.Entry.Text = num.ToString();
				this.combox.Changed -= new EventHandler(this.combox_Changed);
				this._propertyItem.SetValue("FontSize", num, null);
				this.comboxOldValue = num;
				this.combox.Changed += new EventHandler(this.combox_Changed);
			}
		}

		public void EditorDispose()
		{
		}

		public void RefreshData()
		{
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (propertyName != null)
			{
				if (!(propertyName == "TextColor") && !(propertyName == "CColor"))
				{
					if (!(propertyName == "FontSize"))
					{
						if (propertyName == "FontResource")
						{
							this.import.ScenceSetValue();
						}
					}
					else
					{
						this.SetFontValue();
					}
				}
				else
				{
					this.SetColorValue();
				}
			}
		}
	}
}
