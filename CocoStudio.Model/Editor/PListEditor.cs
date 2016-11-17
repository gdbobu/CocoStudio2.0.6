// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PListEditor
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
  public class PListEditor : BaseEditor, ITypeEditor
  {
    private Table table = new Table(1U, 1U, false);
    private Button widget;

    public PListEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PListEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem = null)
    {
      this.widget = new Button();
      this.widget.WidthRequest = 130;
      this.widget.Label = LanguageInfo.Command_ExportMergeImage;
      this.table.Attach((Widget) this.widget, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      this.widget.Clicked += new EventHandler(this.widget_Clicked);
      return (Widget) this.table;
    }

    private void widget_Clicked(object sender, EventArgs e)
    {
      this._propertyItem.SetValue(this._propertyItem.Instance, (object) "", (object[]) null);
    }

    private void SetControl()
    {
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
