// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PaddinEditor
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
  public class PaddinEditor : BaseEditor, ITypeEditor
  {
    private NumberEditorWidget widget;

    public PaddinEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PaddinEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem = null)
    {
      this.widget = new NumberEditorWidget(false, true, 30);
      this.widget.SetMaxMin(200, 0);
      this.widget.SetEntryPRoperty(false, 2, 1.0);
      this.widget.SetMaxMin(200, 0);
      this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
      this.SetControl();
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      this.widget.SetValue((System.Action) (() => this.widget.X.SetPositionValue(Convert.ToDouble(this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null)))));
    }

    private void widget_PointX(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) (int) e.PointX, (object[]) null)));
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
