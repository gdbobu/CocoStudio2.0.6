// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.AnchorPointEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class AnchorPointEditor : BaseEditor, ITypeEditor
  {
    private ScaleEditorWidget widget;

    public AnchorPointEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public AnchorPointEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem)
    {
      this.widget = new ScaleEditorWidget(false);
      this.widget.SetInit((double) int.MinValue, (double) int.MaxValue, 0.1, 2U);
      this.widget.SetMenuVisble(false);
      this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
      this.widget.SetMenuLabel();
      this.SetControl();
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
      this.widget.PointY += new EventHandler<PointEvent>(this.widget_PointY);
      if (this._propertyItem.IsEnable)
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void widget_PointY(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        foreach (object instance in this._propertyItem.InstanceList)
          this._propertyItem.SetValue(this._propertyItem.Instance, (object) new ScaleValue((instance as NodeObject).AnchorPoint.ScaleX, (float) e.PointX, 0.1, -99999999.0, 99999999.0), (object[]) null);
      }));
    }

    private void widget_PointX(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        foreach (object instance in this._propertyItem.InstanceList)
          this._propertyItem.SetValue(this._propertyItem.Instance, (object) new ScaleValue((float) e.PointX, (instance as NodeObject).AnchorPoint.ScaleY, 0.1, -99999999.0, 99999999.0), (object[]) null);
      }));
    }

    private void SetControl()
    {
      ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        Func<ScaleValue, ScaleValue, bool> Func1 = (Func<ScaleValue, ScaleValue, bool>) ((a, b) => Math.Round((double) a.ScaleX, 2) == Math.Round((double) b.ScaleX, 2));
        Func<ScaleValue, ScaleValue, bool> Func2 = (Func<ScaleValue, ScaleValue, bool>) ((a, b) => Math.Round((double) a.ScaleY, 2) == Math.Round((double) b.ScaleY, 2));
        if (this.IsWhip<ScaleValue>(Func1, ""))
          this.widget.SetWhipX(false);
        else
          this.widget.SetX((double) scaleValue.ScaleX);
        if (this.IsWhip<ScaleValue>(Func2, ""))
          this.widget.SetWhipY(false);
        else
          this.widget.SetY((double) scaleValue.ScaleY);
      }
      else
        this.widget.SetValue((System.Action) (() =>
        {
          this.widget.SetXValue((double) scaleValue.ScaleX);
          this.widget.SetYValue((double) scaleValue.ScaleY);
        }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.SetChildWidget((Widget) this.widget, e.PropertyName);
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
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
