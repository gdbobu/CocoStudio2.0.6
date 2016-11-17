// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.OpacityEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  internal class OpacityEditor : BaseEditor, ITypeEditor
  {
    private Table widget;
    private RadioButton choice;
    private RadioButton unChoice;

    public OpacityEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public OpacityEditor()
      : base((PropertyItem) null)
    {
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }

    private void choice_Clicked(object sender, EventArgs e)
    {
      this.choice.Clicked -= new EventHandler(this.choice_Clicked);
      this.unChoice.Clicked -= new EventHandler(this.choice_Clicked);
      this.choice.Inconsistent = false;
      this.unChoice.Inconsistent = false;
      (sender as RadioButton).Inconsistent = true;
      this.choice.Clicked += new EventHandler(this.choice_Clicked);
      this.unChoice.Clicked += new EventHandler(this.choice_Clicked);
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new Table(1U, 2U, false);
      this.choice = new RadioButton("");
      this.unChoice = new RadioButton("");
      this.widget.Attach((Widget) this.choice, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.widget.Attach((Widget) this.unChoice, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.choice.Clicked += new EventHandler(this.choice_Clicked);
      this.unChoice.Clicked += new EventHandler(this.choice_Clicked);
      this.widget.ShowAll();
      return (Widget) this.widget;
    }

    public void EditorDispose()
    {
    }

    public void RefreshData()
    {
    }
  }
}
