// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.LabelTooltipEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System.ComponentModel;

namespace CocoStudio.Model
{
  public class LabelTooltipEditor : BaseEditor, ITypeEditor
  {
    private Table table;
    private Label label;

    public LabelTooltipEditor()
      : base((PropertyItem) null)
    {
    }

    public LabelTooltipEditor(PropertyItem properItem)
      : base(properItem)
    {
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.table = new Table(1U, 2U, false);
      this.label = new Label();
      this.label.Text = LanguageOption.GetValueBykey(this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null).ToString());
      this.label.ModifyFg(StateType.Normal, WindowStyle.LableToolTipColor);
      this.label.SetFontSize(10.0);
      this.label.Wrap = true;
      this.table.Attach((Widget) this.label, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) new Label(), 1U, 2U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      return (Widget) this.table;
    }

    public void EditorDispose()
    {
    }

    public void RefreshData()
    {
    }
  }
}
