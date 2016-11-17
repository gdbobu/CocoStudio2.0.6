// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.EntryComBoxEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class EntryComBoxEditor : BaseEditor, ITypeEditor
  {
    private EntryComBoxEditorWidget widget;
    private SizeValue sizeValue;

    public EntryComBoxEditor()
      : base((PropertyItem) null)
    {
    }

    public EntryComBoxEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new EntryComBoxEditorWidget();
      this.sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      this.SetControl();
      this.widget.Init();
      if (this._propertyItem.ValueRangeDescriptor != null)
        this.widget.SetMaxMin(this._propertyItem.ValueRangeDescriptor.MaxValue, this._propertyItem.ValueRangeDescriptor.MinValue);
      this.widget.ValueChanged += new EventHandler<EntryComboxEvent>(this.widget_ValueChanged);
      return (Widget) this.widget;
    }

    private void widget_ValueChanged(object sender, EntryComboxEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this.sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (e.Type == 0)
          this.sizeValue.Width = e.EntryValue;
        else
          this.sizeValue.Height = e.EntryValue;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.sizeValue, (object[]) null);
      }));
    }

    private void SetControl()
    {
      this.widget.SetValue((System.Action) (() =>
      {
        this.sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        this.widget.SetControl(this.sizeValue.Width, this.sizeValue.Height);
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
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }
  }
}
