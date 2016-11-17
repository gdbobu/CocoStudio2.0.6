// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ChangeColorEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  public class ChangeColorEditor : BaseEditor, ITypeEditor
  {
    private ChangeColorWidget widget;

    public ChangeColorEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ChangeColorEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new ChangeColorWidget();
      this.SetControl();
      this.widget.ColorChanged += new EventHandler<ColorEvent>(this.widget_ColorChanged);
      this.widget.ComBoxChanged += new EventHandler<ComBoxEvnent>(this.widget_ComBoxChanged);
      this.widget.ChangedColorChanged += new EventHandler<ColorEvent>(this.widget_ChangedColorChanged);
      this.widget.PointEventChanged += new EventHandler<PointColorEvent>(this.widget_PointEventChanged);
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      this.widget.SetValue((System.Action) (() =>
      {
        IColorValue instance = this._propertyItem.Instance as IColorValue;
        System.Drawing.Color singleColor = instance.SingleColor;
        int comboBoxIndex = instance.ComboBoxIndex;
        System.Drawing.Color firstColor = instance.FirstColor;
        System.Drawing.Color endColor = instance.EndColor;
        ScaleValue colorVector = instance.ColorVector;
        float num = (float) this._propertyItem.Instance.GetType().GetProperty("ColorAngle").GetValue(this._propertyItem.Instance, (object[]) null);
        this.widget.SetControl(this.ConvertColor(singleColor), comboBoxIndex, this.ConvertColor(firstColor), this.ConvertColor(endColor), (int) num);
        this.SetBgColor();
      }));
    }

    private void SetBgColor()
    {
      PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("BackColorAlpha");
      if (!(property != (PropertyInfo) null))
        return;
      this.widget.SetBGAlthl((int) property.GetValue(this._propertyItem.Instance, (object[]) null));
    }

    private void widget_PointEventChanged(object sender, PointColorEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        IColorValue instance = this._propertyItem.Instance as IColorValue;
        if (e.Type == 0)
          this._propertyItem.SetValue("ColorAngle", (object) (float) e.Value, (object[]) null);
        else
          this._propertyItem.SetValue("BackColorAlpha", (object) (int) e.Value, (object[]) null);
      }));
    }

    private void widget_ChangedColorChanged(object sender, ColorEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        if (e.Type == 0)
          this._propertyItem.SetValue("FirstColor", (object) this.ConvertColor(e.Color), (object[]) null);
        else
          this._propertyItem.SetValue("EndColor", (object) this.ConvertColor(e.Color), (object[]) null);
      }));
    }

    private void widget_ComBoxChanged(object sender, ComBoxEvnent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this._propertyItem.SetValue("ComboBoxIndex", (object) e.SelectIndex, (object[]) null);
        this.SetControl();
      }));
    }

    private void widget_ColorChanged(object sender, ColorEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue("SingleColor", (object) this.ConvertColor(e.Color), (object[]) null)));
    }

    public System.Drawing.Color ConvertColor(Gdk.Color color)
    {
      return System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) ((double) byte.MaxValue * (double) color.Red / (double) ushort.MaxValue), (int) ((double) byte.MaxValue * (double) color.Green / (double) ushort.MaxValue), (int) ((double) byte.MaxValue * (double) color.Blue / (double) ushort.MaxValue));
    }

    public Gdk.Color ConvertColor(System.Drawing.Color color)
    {
      return new Gdk.Color(color.R, color.G, color.B);
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(typeof (IColorValue).GetProperty(e.PropertyName) != (PropertyInfo) null) && !(e.PropertyName == "BackColorAlpha") && !(e.PropertyName == "ColorAngle"))
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
  }
}
