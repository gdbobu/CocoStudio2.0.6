// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ResourceImageEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class ResourceImageEditor : BaseEditor, ITypeEditor
  {
    private Table widget;
    private ImageEventBox imageEventBox;

    public ResourceImageEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ResourceImageEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item)
    {
      this.widget = new Table(2U, 1U, false);
      this.imageEventBox = new ImageEventBox(this._propertyItem, this._propertyItem.PropertyDescriptor);
      this.widget.Attach((Widget) this.imageEventBox, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.widget.ShowAll();
      Label lable = new Label();
      Color color = new Color((byte) 165, (byte) 168, (byte) 176);
      lable.ModifyFg(StateType.Normal, color);
      this.widget.RowSpacing = 6U;
      lable.Text = LanguageOption.GetValueBykey(this._propertyItem.DiaplayName);
      lable.SetFontSize(10.0);
      this.widget.Attach((Widget) lable, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      lable.Show();
      return (Widget) this.widget;
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name) || this.imageEventBox == null)
        return;
      this.imageEventBox.Refresh();
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.imageEventBox.Refresh();
    }
  }
}
