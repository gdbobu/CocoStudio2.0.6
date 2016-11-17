// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SizePrecentEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class SizePrecentEditor : BaseEditor, ITypeEditor
  {
    public SizePrecentEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public SizePrecentEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      return (Widget) null;
    }

    private void SetControl()
    {
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
    }
  }
}
