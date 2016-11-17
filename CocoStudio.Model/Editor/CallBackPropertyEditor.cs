// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.CallBackPropertyEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Model.Interface;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.Model.Editor
{
  public class CallBackPropertyEditor : BaseEditor, ITypeEditor
  {
    private bool isSetValue = false;
    private Table table;
    private ComboBox combox;
    private EntryCallBackEx entry;

    public CallBackPropertyEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public CallBackPropertyEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      HBox hbox = new HBox();
      this.table = new Table(1U, 2U, false);
      this.combox = new ComboBox();
      this.entry = new EntryCallBackEx();
      this.combox.WidthRequest = 90;
      this.entry.WidthRequest = 115;
      this.combox.HeightRequest = 22;
      this.entry.HeightRequest = 22;
      this.table.Attach((Widget) this.combox, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.entry, 1U, 2U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment.RightPadding = 30U;
      alignment.Add((Widget) this.table);
      alignment.ShowAll();
      this.entry.Show();
      hbox.Add((Widget) alignment);
      Box.BoxChild boxChild = hbox[(Widget) alignment] as Box.BoxChild;
      boxChild.Position = 1;
      boxChild.Expand = true;
      boxChild.Fill = true;
      hbox.ShowAll();
      this.SetControl();
      this.table.ColumnSpacing = 10U;
      this.combox.Changed += new EventHandler(this.combox_Changed);
      this.entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.entry_KeyReleaseEvent);
      this.entry.FocusOutEvent += new FocusOutEventHandler(this.entry_FocusOutEvent);
      this.ReadLanuageConfigFile();
      return (Widget) hbox;
    }

    private void entry_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Return || !this.entry.IsFocus)
        return;
      this.UpDateData((System.Action) (() => this.SetWidgetValue()));
    }

    private void entry_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      this.UpDateData((System.Action) (() => this.SetWidgetValue()));
    }

    private void combox_Changed(object sender, EventArgs e)
    {
      if (this.isSetValue)
        return;
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) (EnumCallBack) (this.combox.Active - 1), (object[]) null)));
    }

    private void SetWidgetValue()
    {
      this.entry.Text = this.entry.Text.Trim(' ');
      this._propertyItem.SetValue("CallBackName", (object) this.entry.Text, (object[]) null);
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }

    private void SetControl()
    {
      this.isSetValue = true;
      this.combox.Active = (int) ((EnumCallBack) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null) + 1);
      this.entry.Text = this._propertyItem.Instance.GetType().GetProperty("CallBackName").GetValue(this._propertyItem.Instance, (object[]) null).ToString();
      this.isSetValue = false;
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name) && !(e.PropertyName == "CallBackName"))
        return;
      this.SetControl();
    }

    public void ReadLanuageConfigFile()
    {
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      string[] names = Enum.GetNames(typeof (EnumCallBack));
      for (int index = 0; index < ((IEnumerable<string>) names).Count<string>(); ++index)
      {
        if (!(((EnumCallBack) (index - 1)).ToString() == EnumCallBack.Event.ToString()) || (!(((EnumCallBack) (index - 1)).ToString() == EnumCallBack.Event.ToString()) || this._propertyItem.Instance is ICallBackEvent))
          listStore.AppendValues(new object[1]
          {
            (object) ((EnumCallBack) (index - 1)).ToString()
          });
      }
      this.combox.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      this.combox.PackStart((CellRenderer) cellRendererText, true);
      this.combox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
    }
  }
}
