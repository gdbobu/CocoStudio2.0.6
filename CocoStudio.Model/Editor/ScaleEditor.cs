// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ScaleEditor
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
  public class ScaleEditor : BaseEditor, ITypeEditor
  {
    private ScaleNumberEditorWidget widget;

    public ScaleEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ScaleEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new ScaleNumberEditorWidget(true);
      this.widget.CanZero = false;
      this.widget.SetMenuVisble(false);
      this.widget.SetLabel(LanguageInfo.Radio_HorizontalGuides, LanguageInfo.Radio_VerticalGuides);
      this.widget.SetEntryPRoperty(false, 2, 1.0);
      this.SetControl();
      this.SetImageStatus();
      this.widget.SetLabelText("%");
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_Pointx);
      this.widget.PointY += new EventHandler<PointEvent>(this.widget_Pointy);
      this.widget.ImageStatusChanged += new EventHandler<PointEvent>(this.widget_ImageStatusChanged);
      if (this._propertyItem.IsEnable)
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void widget_ImageStatusChanged(object sender, PointEvent e)
    {
      this._propertyItem.SetValue("UniformScale", (object) e.IsCheck, (object[]) null);
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
          this.widget.SetX((double) scaleValue.ScaleX * 100.0);
        if (this.IsWhip<ScaleValue>(Func2, ""))
          this.widget.SetWhipY(false);
        else
          this.widget.SetY((double) scaleValue.ScaleY * 100.0);
      }
      else
        this.widget.SetValue((double) scaleValue.ScaleX * 100.0, (double) scaleValue.ScaleY * 100.0, false);
    }

    private void widget_Pointy(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        float num = (float) e.PointX / 100f;
        foreach (object instance in this._propertyItem.InstanceList)
        {
          ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
          if (e.IsCheck)
          {
            scaleValue.ScaleX = scaleValue.ScaleX / scaleValue.ScaleY * num;
            this.widget.SetX((double) scaleValue.ScaleX * 100.0);
          }
          scaleValue.ScaleY = num;
          this._propertyItem.PropertyData.SetValue(instance, (object) scaleValue, (object[]) null);
        }
      }));
    }

    private void widget_Pointx(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        float num = (float) e.PointX / 100f;
        foreach (object instance in this._propertyItem.InstanceList)
        {
          ScaleValue scaleValue = (ScaleValue) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
          if (e.IsCheck)
          {
            scaleValue.ScaleY = scaleValue.ScaleY / scaleValue.ScaleX * num;
            this.widget.SetY((double) scaleValue.ScaleY * 100.0);
          }
          scaleValue.ScaleX = num;
          this._propertyItem.PropertyData.SetValue(instance, (object) scaleValue, (object[]) null);
        }
      }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.SetChildWidget((Widget) this.widget, e.PropertyName);
      if (e.PropertyName == this._propertyItem.PropertyData.Name)
      {
        this.SetControl();
      }
      else
      {
        if (!(e.PropertyName == "UniformScale"))
          return;
        this.SetImageStatus();
      }
    }

    public void SetImageStatus()
    {
      bool status = (bool) this._propertyItem.Instance.GetType().GetProperty("UniformScale").GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        if (this.IsWhip<bool>((Func<bool, bool, bool>) null, "UniformScale"))
          this.widget.SetImageStatus(false);
        else
          this.widget.SetImageStatus(status);
      }
      else
        this.widget.SetImageStatus(status);
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
