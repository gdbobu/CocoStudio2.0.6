// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.DefaultEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.ToolKit
{
  [PropertyEditorType(typeof (string))]
  public class DefaultEditor : BaseEditor, ITypeEditor
  {
    private bool isKeyPress = false;
    private DefaultEditorGtk widget;

    public DefaultEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public DefaultEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new DefaultEditorGtk();
      HBox hbox = new HBox();
      Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment.RightPadding = 30U;
      alignment.Add((Widget) this.widget);
      alignment.ShowAll();
      this.widget.Show();
      hbox.Add((Widget) alignment);
      Box.BoxChild boxChild = hbox[(Widget) alignment] as Box.BoxChild;
      boxChild.Position = 1;
      boxChild.Expand = true;
      boxChild.Fill = true;
      hbox.ShowAll();
      if (item.DiaplayName == "Display_LabelFirstChar")
        this.widget.MaxLength = 1;
      this.SetControl();
      this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
      return (Widget) hbox;
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
      this.widget.SelectRegion(0, this.widget.Text.Length);
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

    private void SetControl()
    {
      if (this._propertyItem == null)
        return;
      this.widget.KeyReleaseEvent -= new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent -= new FocusOutEventHandler(this.widget_FocusOutEvent);
      object obj = (object) null;
      if (this._propertyItem != null && this._propertyItem.PropertyData != (PropertyInfo) null)
        obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null)
        this.widget.Text = obj.ToString();
      this.widget.KeyReleaseEvent += new KeyReleaseEventHandler(this.widget_KeyReleaseEvent);
      this.widget.FocusOutEvent += new FocusOutEventHandler(this.widget_FocusOutEvent);
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
