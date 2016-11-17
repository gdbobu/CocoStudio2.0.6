// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SizeEditor
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
  public class SizeEditor : BaseEditor, ITypeEditor
  {
    private PointEditorWidget widget;
    private SizeValue sizeValue;

    public SizeEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public SizeEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      this.widget = new PointEditorWidget(false);
      this.widget.SetLabel(LanguageInfo.NewFile_Width, LanguageInfo.NewFile_Height);
      this.widget.SetMenuVisble(false);
      this.SetControl();
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
      this.widget.PointY += new EventHandler<PointEvent>(this.widget_PointY);
      return (Widget) this.widget;
    }

    private void widget_PointY(object sender, PointEvent e)
    {
      this.sizeValue.Height = (int) e.PointX;
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.sizeValue, (object[]) null);
    }

    private void widget_PointX(object sender, PointEvent e)
    {
      this.sizeValue.Width = (int) e.PointX;
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.sizeValue, (object[]) null);
    }

    private void SetControl()
    {
      this.widget.SetValue((System.Action) (() =>
      {
        this.sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        this.widget.SetXValue((double) this.sizeValue.Width, 0.0, false);
        this.widget.SetYValue((double) this.sizeValue.Height, 0.0, false);
      }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
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
