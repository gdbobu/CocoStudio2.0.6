// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SkewEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class SkewEditor : BaseEditor, ITypeEditor
  {
    private NumberEditorWidget widget;

    public SkewEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public SkewEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new NumberEditorWidget(false, false, 30);
      this.widget.SetMenuVisble(false);
      this.widget.SetLabel(LanguageInfo.Radio_HorizontalGuides, LanguageInfo.Radio_VerticalGuides);
      this.widget.SetEntryPRoperty(false, 2, 1.0);
      this.SetControl();
      this.widget.SetLabelText(LanguageOption.CurrentLanguage == LanguageType.Chinese ? "度" : "°");
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_Pointx);
      this.widget.PointY += new EventHandler<PointEvent>(this.widget_Pointy);
      if (this._propertyItem.IsEnable)
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void ScaleEditor_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void SetControl()
    {
      ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        Func<ScaleValue, ScaleValue, bool> Func1 = (Func<ScaleValue, ScaleValue, bool>) ((a, b) => (double) a.ScaleX == (double) b.ScaleX);
        Func<ScaleValue, ScaleValue, bool> Func2 = (Func<ScaleValue, ScaleValue, bool>) ((a, b) => (double) a.ScaleY == (double) b.ScaleY);
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
        this.widget.SetValue((double) scaleValue.ScaleX, (double) scaleValue.ScaleY, false);
    }

    private void widget_Pointy(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        foreach (object instance in this._propertyItem.InstanceList)
        {
          ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
          scaleValue.ScaleY = (float) e.PointX;
          if (e.IsCheck)
            scaleValue.ScaleX = (float) e.PointX;
          this._propertyItem.PropertyData.SetValue(instance, (object) scaleValue, (object[]) null);
        }
      }));
    }

    private void widget_Pointx(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        foreach (object instance in this._propertyItem.InstanceList)
        {
          ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
          scaleValue.ScaleX = (float) e.PointX;
          if (e.IsCheck)
            scaleValue.ScaleY = (float) e.PointX;
          this._propertyItem.SetValue(this._propertyItem.Instance, (object) scaleValue, (object[]) null);
        }
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
