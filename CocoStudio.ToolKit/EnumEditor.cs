// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EnumEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.ToolKit
{
  [PropertyEditorType(typeof (Enum))]
  public class EnumEditor : BaseEditor, ITypeEditor
  {
    private List<Tuple<string, string>> listStr = new List<Tuple<string, string>>();
    private EnumEditorGtk widget;
    private Type type;
    private string propertyName;

    public EnumEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public EnumEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.propertyName = this._propertyItem.PropertyData.Name;
      this.widget = new EnumEditorGtk();
      this.widget.Sensitive = true;
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      this.type = obj.GetType();
      int active = -1;
      this.widget.Model = (TreeModel) this.InitiData(this.type, obj.ToString(), out active);
      CellRendererText cellRendererText = new CellRendererText();
      this.widget.PackStart((CellRenderer) cellRendererText, true);
      this.widget.AddAttribute((CellRenderer) cellRendererText, "text", 0);
      this.widget.Active = active;
      this.widget.Changed += new EventHandler(this.widget_Changed);
      this.widget.WidthRequest = 20;
      return (Widget) this.widget;
    }

    private void widget_Changed(object sender, EventArgs e)
    {
      this.UpDateData((System.Action) (() =>
      {
        string selectedValue = this.widget.ActiveText;
        this._propertyItem.SetValue(this._propertyItem.Instance, Enum.Parse(this.type, this.listStr.FirstOrDefault<Tuple<string, string>>((Func<Tuple<string, string>, bool>) (w => w.Item2 == selectedValue)).Item1), (object[]) null);
      }));
    }

    private ListStore InitiData(Type type, string value, out int active)
    {
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      string[] names = Enum.GetNames(type);
      if (names != null && ((IEnumerable<string>) names).Count<string>() > 0)
      {
        int num = -1;
        for (int index = 0; index < ((IEnumerable<string>) names).Count<string>(); ++index)
        {
          if (names[index] == value)
            num = index;
          string valueBykey = LanguageOption.GetValueBykey(names[index]);
          listStore.AppendValues(new object[1]
          {
            (object) valueBykey
          });
          this.listStr.Add(Tuple.Create<string, string>(names[index], valueBykey));
        }
        active = num;
      }
      else
        active = -1;
      return listStore;
    }

    private int GetActive(string value)
    {
      string[] names = Enum.GetNames(this.type);
      if (names != null && ((IEnumerable<string>) names).Count<string>() > 0)
      {
        for (int index = 0; index < ((IEnumerable<string>) names).Count<string>(); ++index)
        {
          if (names[index] == this.listStr.FirstOrDefault<Tuple<string, string>>((Func<Tuple<string, string>, bool>) (w => w.Item1 == value)).Item1)
            return index;
        }
      }
      return -1;
    }

    private void SetControl()
    {
      object obj = this._propertyItem.Instance.GetType().GetProperty(this.propertyName).GetValue(this._propertyItem.Instance, (object[]) null);
      if (obj == null)
        return;
      int active = this.GetActive(obj.ToString());
      this.widget.Changed -= new EventHandler(this.widget_Changed);
      this.widget.Active = active;
      this.widget.Changed += new EventHandler(this.widget_Changed);
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this.propertyName))
        return;
      this.SetControl();
    }
  }
}
