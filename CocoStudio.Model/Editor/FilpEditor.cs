// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.FilpEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class FilpEditor : BaseEditor, ITypeEditor
  {
    private FilpEditorWidget widget;

    public FilpEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public FilpEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item)
    {
      this.widget = new FilpEditorWidget();
      this.SetControl();
      this.widget.BtnVClick += new EventHandler<BtnEvent>(this.widget_BtnVClick);
      this.widget.BtnSClick += new EventHandler<BtnEvent>(this.widget_BtnSClick);
      return (Widget) this.widget;
    }

    private void widget_BtnSClick(object sender, BtnEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue("FlipX", (object) e.IsCheck, (object[]) null)));
    }

    private void widget_BtnVClick(object sender, BtnEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue("FlipY", (object) e.IsCheck, (object[]) null)));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void SetControl()
    {
      bool s = (bool) this._propertyItem.Instance.GetType().GetProperty("FlipX").GetValue(this._propertyItem.Instance, (object[]) null);
      bool v = (bool) this._propertyItem.Instance.GetType().GetProperty("FlipY").GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        if (this.IsWhip<bool>((Func<bool, bool, bool>) null, "FlipX"))
          s = false;
        if (this.IsWhip<bool>((Func<bool, bool, bool>) null, "FlipY"))
          v = false;
      }
      this.widget.SetControl(v, s);
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
