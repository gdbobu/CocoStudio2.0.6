// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PListLabelEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class PListLabelEditor : BaseEditor, ITypeEditor
  {
    private Table table = new Table(1U, 1U, false);
    private Label widget;

    public PListLabelEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PListLabelEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem = null)
    {
      this.widget = new Label();
      this.widget.WidthRequest = 150;
      this.table.BorderWidth = 5U;
      this.table.Attach((Widget) this.widget, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      this.SetControl();
      return (Widget) this.table;
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }

    private void SetControl()
    {
      SizeValue sizeValue = (SizeValue) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      this.widget.Text = string.Format(" {0}{2} * {1}{2}", (object) sizeValue.Width, (object) sizeValue.Height, (object) LanguageInfo.NewFile_Pixel);
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
