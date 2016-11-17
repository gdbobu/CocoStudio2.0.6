// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.BoolEditor
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Gtk.Controls;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [PropertyEditorType(typeof (bool))]
  public class BoolEditor : BaseEditor, ITypeEditor
  {
    private CheckButtonEx widget;
    private Table table;

    public BoolEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public BoolEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.table = new Table(1U, 2U, false);
      this.widget = new CheckButtonEx();
      this.widget.Clicked += new EventHandler(this.BoolEditor_Clicked);
      if (this._propertyItem.IsEnable && this._propertyItem.PropertyData.Name == "VisibleForFrame")
        this.widget.Sensitive = false;
      if (!(this._propertyItem.DiaplayName == "Display_CanUse"))
        ;
      this.SetControl();
      this.table.Attach((Widget) this.widget, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) new Label(), 1U, 2U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      return (Widget) this.table;
    }

    private void BoolEditor_Clicked(object sender, EventArgs e)
    {
      if (this.widget.Inconsistent)
      {
        this.widget.Inconsistent = false;
        if (!this.widget.Active)
          this.widget.Active = true;
      }
      this.UpDateData((System.Action) (() => this._propertyItem.SetValue(this._propertyItem.Instance, (object) this.widget.Active, (object[]) null)));
    }

    private void SetControl()
    {
      this.widget.Clicked -= new EventHandler(this.BoolEditor_Clicked);
      if (this._propertyItem.InstanceList != null && this._propertyItem.InstanceList.Count > 1)
      {
        bool flag1 = false;
        bool flag2 = true;
        foreach (object instance in this._propertyItem.InstanceList)
        {
          object obj = this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
          if (obj != null && (bool) obj)
            flag1 = (bool) obj;
          else if (obj != null && !(bool) obj)
            flag2 = (bool) obj;
        }
        this.widget.Inconsistent = (!flag1 || !flag2) && (flag1 || flag2);
        if (!this.widget.Inconsistent)
          this.widget.Active = flag1;
      }
      else
      {
        object obj = this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
        if (obj != null)
          this.widget.Active = (bool) obj;
      }
      this.widget.Clicked += new EventHandler(this.BoolEditor_Clicked);
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
      if (e.PropertyName == "IsTransformEnabled" && this._propertyItem.PropertyData.Name == "VisibleForFrame")
      {
        this.widget.Sensitive = (bool) this._propertyItem.Instance.GetType().GetProperty("IsTransformEnabled").GetValue(this._propertyItem.Instance, (object[]) null);
      }
      else
      {
        if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
          return;
        this.SetControl();
      }
    }
  }
}
