// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.FloatEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [PropertyEditorType(typeof (float))]
  public class FloatEditor : BaseEditor, ITypeEditor
  {
    private UndoEntryIntEx widget;

    public FloatEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public FloatEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      double result = 1.0;
      if (item != null && item.DefaultValueDescriptor != null)
        double.TryParse(item.DefaultValueDescriptor.Value.ToString(), out result);
      this.widget = new UndoEntryIntEx();
      this.SetControl();
      this.widget.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.IntEditor_ValueChanged);
      if (this._propertyItem.IsEnable && this._propertyItem.DiaplayName == "Display_Rotation")
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj == null)
        return;
      this.widget.EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.IntEditor_ValueChanged);
      this.widget.Value = (double) (float) obj;
      this.widget.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.IntEditor_ValueChanged);
    }

    private void IntEditor_ValueChanged(object sender, EventArgs e)
    {
      this.UpDateData((System.Action) (() =>
      {
        object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (obj != null && Convert.ToInt32(obj) == Convert.ToInt32(this.widget.Value))
          return;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToInt32(this.widget.Value), (object[]) null);
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
