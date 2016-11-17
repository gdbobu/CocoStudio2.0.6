// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PasswordEditor
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
  public class PasswordEditor : BaseEditor, ITypeEditor
  {
    private PasswordEditorWidget widget;
    private PasswordValue passWordValue;

    public PasswordEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PasswordEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item)
    {
      this.widget = new PasswordEditorWidget();
      this.passWordValue = (PasswordValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this.passWordValue != (PasswordValue) null)
        this.widget.SetControl(this.passWordValue.PasswordEnable, this.passWordValue.PasswordStyleText);
      this.widget.TextCangede += new EventHandler<BoolEvent>(this.widget_TextCangede);
      this.widget.IsCheckChanged += new EventHandler<BoolEvent>(this.widget_IsCheckChanged);
      return (Widget) this.widget;
    }

    private void widget_IsCheckChanged(object sender, BoolEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this.passWordValue.PasswordEnable = e.IsCheck;
        this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.passWordValue, (object[]) null);
      }));
    }

    private void widget_TextCangede(object sender, BoolEvent e)
    {
      if (string.IsNullOrEmpty(e.Text))
        return;
      this.passWordValue.PasswordStyleText = e.Text;
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.passWordValue, (object[]) null)));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    public void SetControl()
    {
      this.widget.SetValue((System.Action) (() =>
      {
        this.passWordValue = (PasswordValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (!(this.passWordValue != (PasswordValue) null))
          return;
        this.widget.SetControl(this.passWordValue.PasswordEnable, this.passWordValue.PasswordStyleText);
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
