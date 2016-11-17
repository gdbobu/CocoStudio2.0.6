// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.NumberEntryEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Gtk.Controls;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CocoStudio.ToolKit
{
  public class NumberEntryEditor : BaseEditor, ITypeEditor
  {
    private string oldEntryValue = string.Empty;
    private bool isKeyPress = false;
    private Entry widget;

    public NumberEntryEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public NumberEntryEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = (Entry) new EntryEx();
      this.SetControl();
      this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
      this.widget.Changed += new EventHandler(this.widget_Changed);
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      if (this._propertyItem == null)
        return;
      this.widget.KeyReleaseEvent -= new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent -= new FocusOutEventHandler(this.widget_FocusOutEvent);
      this.widget.Changed -= new EventHandler(this.widget_Changed);
      object obj = (object) null;
      if (this._propertyItem != null && this._propertyItem.PropertyData != (PropertyInfo) null)
        obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null)
        this.widget.Text = this.oldEntryValue = obj.ToString();
      this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
      this.widget.Changed += new EventHandler(this.widget_Changed);
    }

    public static bool IsUnsign(string value)
    {
      return Regex.IsMatch(value, "^[0-9]*$");
    }

    private void widget_Changed(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.widget.Text))
      {
        if (!NumberEntryEditor.IsUnsign(this.widget.Text.Replace(".", "").Replace("/", "")))
          this.widget.Text = this.oldEntryValue;
        else
          this.oldEntryValue = this.widget.Text;
      }
      else
        this.oldEntryValue = this.widget.Text;
    }

    private void widget_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
        return;
      this.UpDateData((System.Action) (() => this.SetWidgetValue()));
    }

    private void widget_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Return || !this.widget.IsFocus)
        return;
      this.isKeyPress = true;
      this.UpDateData((System.Action) (() => this.SetWidgetValue()));
      this.isKeyPress = false;
    }

    private void SetWidgetValue()
    {
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null && obj.ToString() == this.widget.Text)
        return;
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.widget.Text, (object[]) null);
      if (!(this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null).ToString() != this.widget.Text))
        return;
      this.SetControl();
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
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }
  }
}
