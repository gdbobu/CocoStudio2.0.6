// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.EntryTextViewEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  public class EntryTextViewEditor : BaseEditor, ITypeEditor
  {
    private bool isKeyPress = false;
    private TextView textView;

    public EntryTextViewEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public EntryTextViewEditor()
      : base((PropertyItem) null)
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
      return (Widget) this.textView;
    }

    private void SetControl()
    {
      if (this._propertyItem == null)
        return;
      this.textView.KeyReleaseEvent -= new KeyReleaseEventHandler(this.textView_KeyReleaseEvent);
      this.textView.FocusOutEvent -= new FocusOutEventHandler(this.textView_FocusOutEvent);
      object obj = (object) null;
      if (this._propertyItem != null && this._propertyItem.PropertyData != (PropertyInfo) null)
        obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null)
        this.textView.Buffer.Text = obj.ToString();
      this.textView.KeyReleaseEvent += new KeyReleaseEventHandler(this.textView_KeyReleaseEvent);
      this.textView.FocusOutEvent += new FocusOutEventHandler(this.textView_FocusOutEvent);
    }

    private void textView_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
        return;
      this.UpDateData((System.Action) (() => this.SetTextViewWidget()));
    }

    private void textView_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Return || !this.textView.IsFocus)
        return;
      this.isKeyPress = true;
      this.UpDateData((System.Action) (() => this.SetTextViewWidget()));
      this.isKeyPress = false;
    }

    private void SetTextViewWidget()
    {
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null && obj.ToString() == this.textView.Buffer.Text)
        return;
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.textView.Buffer.Text, (object[]) null);
      if (!(this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null).ToString() != this.textView.Buffer.Text))
        return;
      this.SetTextViewWidget();
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
