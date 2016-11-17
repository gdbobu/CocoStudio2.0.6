// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PropertyColorEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gtk;
using Gtk.Controls;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  internal class PropertyColorEditor : BaseEditor, ITypeEditor
  {
    private int[] comboxList = new int[17]
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
    private Table Widget;
    private ColorEx color;
    private ComboBoxEntry combox;
    private ResourceFileImport import;

    public PropertyColorEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PropertyColorEditor()
      : base((PropertyItem) null)
    {
    }

    public Gtk.Widget ResolveEditor(PropertyItem item = null)
    {
      this.Widget = new Table(2U, 2U, false);
      this.color = new ColorEx();
      this.combox = new ComboBoxEntry();
      this.import = new ResourceFileImport(this._propertyItem, LanguageInfo.Property_ImportFont, "");
      this.color.ColorChanged += new EventHandler<ColorExEvent>(this.color_ColorChanged);
      this.combox = new ComboBoxEntry();
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      foreach (int combox in this.comboxList)
        listStore.AppendValues(new object[1]
        {
          (object) combox.ToString()
        });
      this.combox.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      this.combox.PackStart((CellRenderer) cellRendererText, true);
      this.combox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      object obj = this._propertyItem.Instance.GetType().GetProperty("FontSize").GetValue(this._propertyItem.Instance, (object[]) null);
      int index = this.IndexCombox((int) obj);
      if (index == -1)
      {
        this.combox.Entry.Text = obj.ToString();
        this.comboxOldValue = (int) obj;
      }
      else
      {
        this.combox.Active = index;
        this.combox.Entry.Text = this.comboxList[index].ToString();
        this.comboxOldValue = this.comboxList[index];
      }
      this.combox.WidthRequest = 60;
      this.combox.Changed += new EventHandler(this.combox_Changed);
      this.combox.Entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.Entry_KeyReleaseEvent);
      this.combox.Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent);
      this.combox.Entry.Changed += new EventHandler(this.Entry_Changed);
      object property = (object) this._propertyItem.Instance.GetType().GetProperty("TextColor");
      this.colorText = "TextColor";
      if (property == null)
      {
        property = (object) this._propertyItem.Instance.GetType().GetProperty("CColor");
        this.colorText = "CColor";
      }
      if (property != null)
      {
        this.Widget = new Table(2U, 3U, false);
        this.Widget.Attach((Gtk.Widget) this.color, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
        this.Widget.Attach((Gtk.Widget) this.combox, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
        this.Widget.Attach((Gtk.Widget) new Label(), 2U, 3U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
        this.Widget.Attach((Gtk.Widget) this.import, 0U, 3U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      else
      {
        this.Widget = new Table(2U, 1U, false);
        this.Widget.Attach((Gtk.Widget) this.combox, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
        this.Widget.Attach((Gtk.Widget) this.import, 0U, 2U, 1U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      this.SetColorValue();
      this.Widget.ShowAll();
      this.Widget.RowSpacing = 6U;
      this.Widget.ColumnSpacing = 30U;
      return (Gtk.Widget) this.Widget;
    }

    private void color_ColorChanged(object sender, ColorExEvent e)
    {
      this.color.ColorChanged -= new EventHandler<ColorExEvent>(this.color_ColorChanged);
      using (CompositeTask.Run("ColorChanged"))
        this._propertyItem.SetValue(this.colorText, (object) e.Color, (object[]) null);
      this.color.ColorChanged += new EventHandler<ColorExEvent>(this.color_ColorChanged);
    }

    private void SetColorValue()
    {
      PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty(this.colorText);
      if (!(property != (PropertyInfo) null))
        return;
      object obj = property.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null)
        this.color.SetColor(this.ConvertColor((System.Drawing.Color) obj));
    }

    private void SetFontValue()
    {
      PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("FontSize");
      if (!(property != (PropertyInfo) null) || (this.combox == null || this.combox.Entry == null))
        return;
      this.combox.Entry.Text = property.GetValue(this._propertyItem.Instance, (object[]) null).ToString();
    }

    public Gdk.Color ConvertColor(System.Drawing.Color color)
    {
      return new Gdk.Color(color.R, color.G, color.B);
    }

    private int IndexCombox(int num)
    {
      for (int index = 0; index < this.comboxList.Length; ++index)
      {
        if (this.comboxList[index] == num)
          return index;
      }
      return -1;
    }

    private void combox_Changed(object sender, EventArgs e)
    {
      ComboBoxEntry comboBoxEntry = sender as ComboBoxEntry;
      if (comboBoxEntry.Active == -1)
        return;
      this.combox.Entry.Text = this.comboxList[comboBoxEntry.Active].ToString();
    }

    private void Entry_Changed(object sender, EventArgs e)
    {
      if (!this.combox.Entry.IsFocus)
      {
        this.FontValue();
      }
      else
      {
        for (int startIndex = 0; startIndex < this.combox.Entry.Text.Length; ++startIndex)
        {
          if ((int) this.combox.Entry.Text[startIndex] < 48 || (int) this.combox.Entry.Text[startIndex] > 57)
            this.combox.Entry.Text = this.combox.Entry.Text.Remove(startIndex, 1);
        }
      }
    }

    private void Entry_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
        this.FontValue();
      this.isKeyPress = false;
    }

    private void Entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      this.isKeyPress = true;
      int num;
      switch (args.Event.Key)
      {
        case Gdk.Key.Return:
        case Gdk.Key.KP_Enter:
        case Gdk.Key.ISO_Enter:
          num = !this.combox.Entry.IsFocus ? 1 : 0;
          break;
        default:
          num = 1;
          break;
      }
      if (num != 0)
        return;
      this.FontValue();
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
        int result = 5;
        int.TryParse(this.combox.Entry.Text, out result);
        if (result > 100)
          result = 100;
        if (result < 5)
          result = 5;
        this.combox.Entry.Text = result.ToString();
        this.combox.Changed -= new EventHandler(this.combox_Changed);
        this._propertyItem.SetValue("FontSize", (object) result, (object[]) null);
        this.comboxOldValue = result;
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
      switch (e.PropertyName)
      {
        case "TextColor":
        case "CColor":
          this.SetColorValue();
          break;
        case "FontSize":
          this.SetFontValue();
          break;
        case "FontResource":
          this.import.ScenceSetValue();
          break;
      }
    }
  }
}
