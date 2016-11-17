// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ResourceGroupEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class ResourceGroupEditor : BaseEditor, ITypeEditor
  {
    private Table widget = (Table) null;
    private List<ImageEventBox> imageEventBoxList;

    public ResourceGroupEditor()
      : base((PropertyItem) null)
    {
    }

    public ResourceGroupEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new Table(1U, 1U, false);
      this.imageEventBoxList = new List<ImageEventBox>();
      List<string> stringList = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null) as List<string>;
      if (stringList != null)
      {
        uint left_attach = 0;
        Table table = new Table(2U, (uint) stringList.Count, false);
        table.ColumnSpacing = 6U;
        foreach (string name in stringList)
        {
          Label lable = new Label();
          this._propertyItem.Instance.GetType().GetProperty(name);
          PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this._propertyItem.Instance.GetType()).Find(name, false);
          lable.Text = LanguageOption.GetValueBykey(propertyDescriptor.DisplayName);
          Color color = new Color((byte) 165, (byte) 168, (byte) 176);
          lable.ModifyFg(StateType.Normal, color);
          lable.SetFontSize(10.0);
          table.Attach((Widget) lable, left_attach, left_attach + 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
          ImageEventBox imageEventBox = new ImageEventBox(this._propertyItem, propertyDescriptor);
          table.Attach((Widget) imageEventBox, left_attach, left_attach + 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
          ++left_attach;
          this.imageEventBoxList.Add(imageEventBox);
        }
        this.widget.Attach((Widget) table, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      this.widget.ShowAll();
      return (Widget) this.widget;
    }

    public void EditorDispose()
    {
      this.imageEventBoxList.ForEach((System.Action<ImageEventBox>) (w => w.ImageDispose()));
      this.Dispose();
    }

    public void RefreshData()
    {
      this.imageEventBoxList.ForEach((System.Action<ImageEventBox>) (w => w.Refresh()));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
  }
}
