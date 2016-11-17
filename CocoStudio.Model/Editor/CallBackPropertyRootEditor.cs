// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.CallBackPropertyRootEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class CallBackPropertyRootEditor : BaseEditor, ITypeEditor
  {
    private EntryCallBackEx entry;

    public CallBackPropertyRootEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public CallBackPropertyRootEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      HBox hbox = new HBox();
      this.entry = new EntryCallBackEx();
      Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment.RightPadding = 30U;
      alignment.Add((Widget) this.entry);
      alignment.ShowAll();
      this.entry.Show();
      hbox.Add((Widget) alignment);
      Box.BoxChild boxChild = hbox[(Widget) alignment] as Box.BoxChild;
      boxChild.Position = 1;
      boxChild.Expand = true;
      boxChild.Fill = true;
      hbox.ShowAll();
      this.SetControl();
      this.entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.entry_KeyReleaseEvent);
      this.entry.FocusOutEvent += new FocusOutEventHandler(this.entry_FocusOutEvent);
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

    private void SetWidgetValue()
    {
      this.entry.Value = this.entry.Text.Trim(' ');
      this._propertyItem.SetValue("CustomClassName", (object) this.entry.Value, (object[]) null);
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
      this.entry.Value = (string) this._propertyItem.Instance.GetType().GetProperty("CustomClassName").GetValue(this._propertyItem.Instance, (object[]) null);
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.SetControl();
    }
  }
}
