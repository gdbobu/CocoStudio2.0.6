// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ColorsEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using Gtk.Controls;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.Editor
{
  public class ColorsEditor : BaseEditor, ITypeEditor
  {
    private ColorEx widget;

    public ColorsEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ColorsEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new ColorEx();
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj != null)
      {
        Color color = (Color) obj;
        bool flag = 0 == 0;
        this.widget.Color = color;
      }
      this.widget.ColorChanged += new EventHandler<ColorExEvent>(this.widget_ColorChanged);
      return (Widget) this.widget;
    }

    private void widget_ColorChanged(object sender, ColorExEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.widget.Color, (object[]) null)));
    }

    private void SetControl()
    {
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj == null)
        return;
      Color color = (Color) obj;
      bool flag = 0 == 0;
      this.widget.Color = color;
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
