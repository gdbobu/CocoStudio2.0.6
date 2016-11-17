// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.RotationEditor
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
  public class RotationEditor : BaseEditor, ITypeEditor
  {
    private NumberEditorWidget widget;

    public RotationEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public RotationEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem = null)
    {
      this.widget = new NumberEditorWidget(false, true, LanguageOption.CurrentLanguage == LanguageType.Chinese ? 105 : 89);
      this.widget.SetEntryPRoperty(false, 2, 1.0);
      this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
      this.SetControl();
      this.widget.SetLabelText(LanguageOption.CurrentLanguage == LanguageType.Chinese ? "度" : "°");
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
      if (this._propertyItem.IsEnable)
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      object data = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        if (this.IsWhip<float>((Func<float, float, bool>) null, ""))
          this.widget.SetWhipX(false);
        else
          this.widget.SetX(Convert.ToDouble(this.isMultiValue));
      }
      else
        this.widget.SetValue((System.Action) (() => this.widget.X.SetPositionValue(Convert.ToDouble(data))));
    }

    private void widget_PointX(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) Convert.ToSingle(e.PointX), (object[]) null)));
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
