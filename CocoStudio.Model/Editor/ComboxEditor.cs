// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ComboxEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class ComboxEditor : BaseEditor, ITypeEditor
  {
    private ComBoxEx combox;

    public ComboxEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ComboxEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.combox = new ComBoxEx();
      this.SetControl();
      this.combox.Changed += new EventHandler(this.combox_Changed);
      return (Widget) this.combox;
    }

    private void combox_Changed(object sender, EventArgs e)
    {
    }

    private void SetControl()
    {
      List<string> stringList = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null) as List<string>;
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      foreach (string str in stringList)
        listStore.AppendValues(new object[1]{ (object) str });
      this.combox.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      this.combox.PackStart((CellRenderer) cellRendererText, true);
      this.combox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
    }

    public void EditorDispose()
    {
    }

    public void RefreshData()
    {
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
  }
}
