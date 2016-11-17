// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SliderEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class SliderEditor : BaseEditor, ITypeEditor
  {
    private SliderEditorWidget widget;

    public SliderEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public SliderEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item)
    {
      this.widget = new SliderEditorWidget();
      if (this._propertyItem.ValueRangeDescriptor != null)
        this.widget.SetValueSize(this._propertyItem.ValueRangeDescriptor.MinValue, this._propertyItem.ValueRangeDescriptor.MaxValue, (int) this._propertyItem.ValueRangeDescriptor.Step);
      this.SetControl();
      this.widget.ValueChanged += new EventHandler<PointEvent>(this.widget_ValueChanged);
      return (Widget) this.widget;
    }

    private void widget_ValueChanged(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) (int) e.PointX, (object[]) null)));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void SetControl()
    {
      int data = (int) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this.IsWhip<int>((Func<int, int, bool>) null, ""))
        data = (int) byte.MaxValue;
      this.widget.SetValue((System.Action) (() => this.widget.SetControl(data)));
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }
  }
}
