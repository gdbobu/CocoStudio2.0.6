// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.IntEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [PropertyEditorType(typeof (int))]
  public class IntEditor : BaseEditor, ITypeEditor
  {
    private int[] comboxList = new int[17]{ 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 18, 20, 22, 24, 36, 48, 72 };
    private bool isKeyPress = false;
    private Widget widget;

    public IntEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public IntEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      if (this._propertyItem.DiaplayName != "Display_FontSize")
      {
        this.widget = (Widget) new UndoEntryIntEx();
        (this.widget as UndoEntryIntEx).SetEntryPRoperty(true, 0, 1.0);
        if (this._propertyItem.InstanceCount > 1)
        {
          this.widget.Sensitive = false;
        }
        else
        {
          this.SetControl();
          if (this._propertyItem.ValueRangeDescriptor != null)
          {
            (this.widget as UndoEntryIntEx).MaxValue = this._propertyItem.ValueRangeDescriptor.MaxValue;
            (this.widget as UndoEntryIntEx).MinValue = this._propertyItem.ValueRangeDescriptor.MinValue;
            (this.widget as UndoEntryIntEx).ScrollNum = this._propertyItem.ValueRangeDescriptor.Step;
          }
          (this.widget as UndoEntryIntEx).EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.IntEditor_Changed);
        }
        return this.widget;
      }
      ComboBoxEntry comboBoxEntry = new ComboBoxEntry();
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      foreach (int combox in this.comboxList)
        listStore.AppendValues(new object[1]
        {
          (object) combox.ToString()
        });
      comboBoxEntry.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      comboBoxEntry.PackStart((CellRenderer) cellRendererText, true);
      comboBoxEntry.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      int index = this.IndexCombox((int) obj);
      if (index == -1)
      {
        comboBoxEntry.Entry.Text = obj.ToString();
      }
      else
      {
        comboBoxEntry.Active = index;
        comboBoxEntry.Entry.Text = this.comboxList[index].ToString();
      }
      this.widget = (Widget) comboBoxEntry;
      (this.widget as ComboBoxEntry).Changed += new EventHandler(this.combox_Changed);
      (this.widget as ComboBoxEntry).Entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.Entry_KeyReleaseEvent);
      (this.widget as ComboBoxEntry).Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent);
      (this.widget as ComboBoxEntry).Entry.Changed += new EventHandler(this.Entry_Changed);
      this.widget = (Widget) comboBoxEntry;
      return this.widget;
    }

    private void Entry_Changed(object sender, EventArgs e)
    {
      ComboBoxEntry widget = this.widget as ComboBoxEntry;
      if (!widget.Entry.IsFocus)
      {
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToInt32(widget.Entry.Text), (object[]) null);
      }
      else
      {
        for (int startIndex = 0; startIndex < widget.Entry.Text.Length; ++startIndex)
        {
          if ((int) widget.Entry.Text[startIndex] < 48 || (int) widget.Entry.Text[startIndex] > 57)
            widget.Entry.Text = widget.Entry.Text.Remove(startIndex, 1);
        }
      }
    }

    private void Entry_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
      {
        ComboBoxEntry widget = this.widget as ComboBoxEntry;
        if (string.IsNullOrEmpty(widget.Entry.Text))
          return;
        widget.Changed -= new EventHandler(this.combox_Changed);
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToInt32(widget.Entry.Text), (object[]) null);
        widget.Changed += new EventHandler(this.combox_Changed);
      }
      this.isKeyPress = false;
    }

    private void Entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      this.isKeyPress = true;
      Gdk.Key key = args.Event.Key;
      ComboBoxEntry widget = this.widget as ComboBoxEntry;
      if (key != Gdk.Key.Return && key != Gdk.Key.KP_Enter && key != Gdk.Key.ISO_Enter || !widget.Entry.IsFocus || string.IsNullOrEmpty(widget.Entry.Text))
        return;
      widget.Changed -= new EventHandler(this.combox_Changed);
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToInt32(widget.Entry.Text), (object[]) null);
      widget.Changed += new EventHandler(this.combox_Changed);
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
      (this.widget as ComboBoxEntry).Changed -= new EventHandler(this.combox_Changed);
      if (comboBoxEntry.Active != -1)
        (this.widget as ComboBoxEntry).Entry.Text = this.comboxList[comboBoxEntry.Active].ToString();
      (this.widget as ComboBoxEntry).Changed += new EventHandler(this.combox_Changed);
    }

    private void SetControl()
    {
      if (this._propertyItem.DiaplayName != "Display_FontSize")
      {
        (this.widget as UndoEntryIntEx).EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.IntEditor_Changed);
        object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (obj != null)
          (this.widget as UndoEntryIntEx).Value = (double) Convert.ToInt32(obj);
        (this.widget as UndoEntryIntEx).EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.IntEditor_Changed);
      }
      else
      {
        (this.widget as ComboBoxEntry).Changed -= new EventHandler(this.combox_Changed);
        if ((this.widget as ComboBoxEntry).Entry != null)
          (this.widget as ComboBoxEntry).Entry.Text = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null).ToString();
        (this.widget as ComboBoxEntry).Changed += new EventHandler(this.combox_Changed);
      }
    }

    private void IntEditor_Changed(object sender, EventArgs e)
    {
      this.UpDateData((System.Action) (() =>
      {
        object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (obj != null && Convert.ToInt32(obj) == Convert.ToInt32((this.widget as UndoEntryIntEx).Value))
          return;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToInt32((this.widget as UndoEntryIntEx).Value), (object[]) null);
      }));
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name) && !(e.PropertyName == "FontSize"))
        return;
      this.SetControl();
    }
  }
}
