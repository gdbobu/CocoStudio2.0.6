// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.NameEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  public class NameEditor : BaseEditor, ITypeEditor
  {
    private bool isKeyPress = false;
    private Entry widget;
    public string oldStr;

    public NameEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public NameEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = (Entry) new DefaultEditorGtk();
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
      return (Widget) this.widget;
    }

    private void widget_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
        return;
      this.UpDateData((System.Action) (() =>
      {
        if (string.IsNullOrEmpty(this.widget.Text.Trim()))
          this.widget.Text = this.oldStr;
        else
          this.SetWidgetValue();
      }));
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
          this.UpDateData((System.Action) (() => this.SetWidgetValue()));
          this.widget.SelectRegion(0, this.widget.Text.Length);
          this.isKeyPress = false;
        }
      }
    }

    private void SetWidgetValue()
    {
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null && obj.ToString() == this.widget.Text)
        return;
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.widget.Text.Trim(), (object[]) null);
      this.oldStr = this.widget.Text;
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
      {
        this.widget.Text = obj.ToString();
        this.oldStr = this.widget.Text;
      }
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
