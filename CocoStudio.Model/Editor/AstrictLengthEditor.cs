// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.AstrictLengthEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class AstrictLengthEditor : BaseEditor, ITypeEditor
  {
    private AstrictLengthEditorWidget widget;
    private AstrictLengthValue asValue;

    public AstrictLengthEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public AstrictLengthEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new AstrictLengthEditorWidget();
      this.asValue = (AstrictLengthValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this.asValue != (AstrictLengthValue) null)
        this.widget.SetControl(this.asValue.MaxLengthEnable, (double) this.asValue.MaxLengthText);
      this.widget.ValueCangede += new EventHandler<BoolEvent>(this.widget_ValueCangede);
      this.widget.IsCheckChanged += new EventHandler<BoolEvent>(this.widget_IsCheckChanged);
      return (Widget) this.widget;
    }

    private void widget_IsCheckChanged(object sender, BoolEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this.asValue.MaxLengthEnable = e.IsCheck;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.asValue, (object[]) null);
      }));
    }

    private void widget_ValueCangede(object sender, BoolEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this.asValue.MaxLengthText = (int) e.Value;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.asValue, (object[]) null);
      }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void SetControl()
    {
      this.widget.SetValue((System.Action) (() =>
      {
        this.asValue = (AstrictLengthValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        this.widget.SetControl(this.asValue.MaxLengthEnable, (double) this.asValue.MaxLengthText);
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
  }
}
