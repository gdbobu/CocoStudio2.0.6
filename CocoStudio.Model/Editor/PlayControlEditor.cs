// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PlayControlEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class PlayControlEditor : BaseEditor, ITypeEditor
  {
    private PlayControlWidget widget;
    private IPlayControl proxyCom;

    public PlayControlEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PlayControlEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.proxyCom = this._propertyItem.Instance as IPlayControl;
      this.widget = new PlayControlWidget();
      this.widget.Play += new EventHandler(this.widget_Play);
      this.widget.Stop += new EventHandler(this.widget_Stop);
      this.ControlView(this.proxyCom.HasData());
      return (Widget) this.widget;
    }

    private void widget_Stop(object sender, EventArgs e)
    {
      if (this.proxyCom == null)
        return;
      this.proxyCom.Stop();
    }

    private void widget_Play(object sender, EventArgs e)
    {
      if (this.proxyCom == null)
        return;
      this.proxyCom.Start();
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == "FileData") || this.proxyCom == null)
        return;
      this.ControlView(this.proxyCom.HasData());
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
    }

    private void ControlView(bool canedit = true)
    {
      this.widget.PlayButton.Sensitive = canedit;
      this.widget.StopButton.Sensitive = canedit;
    }
  }
}
