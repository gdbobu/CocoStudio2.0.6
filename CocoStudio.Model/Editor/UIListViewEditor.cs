// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.UIListViewEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  public class UIListViewEditor : BaseEditor, ITypeEditor
  {
    private UIListViewEditorWidget widget;
    private IListViewType CurrentValue;
    private List<string> PropertyName;

    public UIListViewEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public UIListViewEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new UIListViewEditorWidget();
      this.PropertyName = new List<string>();
      this.widget.Init(Enum.GetNames(typeof (ListViewDirectionType)), Enum.GetNames(typeof (ListViewHorizontal)), Enum.GetNames(typeof (ListViewVertical)));
      this.CurrentValue = this._propertyItem.Instance as IListViewType;
      this.SetControl();
      this.CreatePropertyNameList();
      this.widget.ValueChanged += new EventHandler<ListViewEvent>(this.widget_ValueChanged);
      return (Widget) this.widget;
    }

    private void widget_ValueChanged(object sender, ListViewEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        switch (e.TialType)
        {
          case 0:
            this.CurrentValue.DirectionType = (ListViewDirectionType) (e.NumType + 1);
            break;
          case 1:
            this.CurrentValue.HorizontalType = (ListViewHorizontal) e.NumType;
            break;
          case 2:
            this.CurrentValue.VerticalType = (ListViewVertical) (e.NumType + 3);
            break;
        }
      }));
    }

    public void SetControl()
    {
      this.widget.SetValue((System.Action) (() => this.widget.SetControl((int) (this.CurrentValue.DirectionType - 1), (int) this.CurrentValue.HorizontalType, (int) this.CurrentValue.VerticalType)));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      foreach (string str in this.PropertyName)
      {
        if (e.PropertyName == str)
          this.UpDateData((System.Action) (() => this.SetControl()));
      }
    }

    private void CreatePropertyNameList()
    {
      foreach (MemberInfo member in this.CurrentValue.GetType().GetMembers())
        this.PropertyName.Add(member.Name);
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
