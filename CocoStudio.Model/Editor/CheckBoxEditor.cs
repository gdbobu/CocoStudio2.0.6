// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.CheckBoxEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class CheckBoxEditor : BaseEditor, ITypeEditor
  {
    private bool isSetControl = false;
    private Table widget;
    private RadioButton choice;
    private RadioButton unChoice;

    public CheckBoxEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public CheckBoxEditor()
      : base((PropertyItem) null)
    {
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void choice_Clicked(object sender, EventArgs e)
    {
      if (this.isSetControl)
        return;
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.choice.Active, (object[]) null)));
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new Table(1U, 2U, false);
      this.choice = new RadioButton(LanguageInfo.Display_NormalState);
      this.unChoice = new RadioButton(LanguageInfo.Display_Disable);
      this.widget.Attach((Widget) this.choice, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.widget.Attach((Widget) this.unChoice, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.choice.CanFocus = false;
      this.choice.DrawIndicator = true;
      this.choice.UseUnderline = true;
      this.unChoice.CanFocus = false;
      this.unChoice.DrawIndicator = true;
      this.unChoice.UseUnderline = true;
      this.SetControl();
      this.choice.Clicked += new EventHandler(this.choice_Clicked);
      this.widget.ShowAll();
      return (Widget) this.widget;
    }

    public void SetControl()
    {
      this.isSetControl = true;
      if ((bool) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null))
      {
        this.choice.Group = new SList(IntPtr.Zero);
        this.unChoice.Group = this.choice.Group;
      }
      else
      {
        this.unChoice.Group = new SList(IntPtr.Zero);
        this.choice.Group = this.unChoice.Group;
      }
      this.isSetControl = false;
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
